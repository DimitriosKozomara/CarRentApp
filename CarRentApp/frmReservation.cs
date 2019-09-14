using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpProj
{
    public partial class frmReservation : Form
    {
        Client client;
        frmClientInterface frmCR;

        List<Car> cars;
        List<Car> filteredCars;
        List<Car> chosenCars;
        List<Offer> chosenCarOffers;

        int totalPrice;
        private Offer chosenOffer;

        public delegate void RefreshData();
        public RefreshData refreshData;

        public frmReservation()
        {
            InitializeComponent();
        }
        public frmReservation(Client client, frmClientInterface frmCR) : this()
        {
            this.client = client;
            this.frmCR = frmCR;

            //Reading cars
            cars = Data.ReadAll<Car>();
            chosenCarOffers = new List<Offer>();
            chosenCars = new List<Car>();
        }

        private void frmReservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmCR.Show();
        }

        private void frmReservation_Shown(object sender, EventArgs e)
        {
            var linq = cars.Select(x => x.Make).Distinct();

            if (!linq.Any())
            {
                MessageBox.Show("No available cars!");
                return;
            }

            if (cmbMake.DataSource != null)
                cmbMake.DataSource = null;

            cmbMake.DataSource = linq.ToList();

            cmbMake.DisplayMember = "make";
            cmbMake.SelectedIndex = -1;
        }
        private void ClearComboBox(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.SelectedIndex = -1;
            if (lbTerms.DataSource != null)
                lbTerms.DataSource = null;

            lbTerms.Invalidate();
        }

        private void cmbMake_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMake.SelectedIndex == -1) return;

            ClearComboBox(cmbModel);
            ClearComboBox(cmbYear);
            ResetAllBut1stThree();

            foreach (Car car in cars)
                if (cmbMake.SelectedItem.Equals(car.Make) && !cmbModel.Items.Contains(car.Model))
                    cmbModel.Items.Add(car.Model);
        }

        private void cmbModel_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbModel.SelectedIndex == -1) return;

            ResetAllBut1stThree();
            ClearComboBox(cmbYear);

            filteredCars = new List<Car>();
            foreach (Car car in cars)
                if (cmbMake.SelectedItem.Equals(car.Make) && cmbModel.SelectedItem.Equals(car.Model))
                {
                    filteredCars.Add(car);
                    if (!cmbYear.Items.Contains(car.Year))
                        cmbYear.Items.Add(car.Year);
                }

            if (cmbYear.Items.Count == 1)
            {
                List<Car> tmp = new List<Car>();
                cmbYear.SelectedItem = cmbYear.Items[0];

                foreach (Car a in filteredCars)
                    if (cmbYear.SelectedItem.Equals(a.Year))
                        tmp.Add(a);

                filteredCars = new List<Car>();
                filteredCars.AddRange(tmp);

                foreach (Car car in filteredCars)
                    AddCars(car);

                FillCBoxesValues();
            }
        }

        private void cmbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbYear.SelectedIndex == -1) return;

            if (cmbYear.Items.Count > 1)
            {
                ResetAllBut1stThree();
                filteredCars = new List<Car>();

                foreach (Car car in cars)
                    if (cmbMake.SelectedItem.Equals(car.Make) && cmbModel.SelectedItem.Equals(car.Model) && cmbYear.SelectedItem.Equals(car.Year))
                        filteredCars.Add(car);

                foreach (Car car in filteredCars)
                    AddCars(car);

                FillCBoxesValues();
            }
        }

        private bool ShowOffers()
        {
            if (cmbMake.SelectedItem == null || cmbModel.SelectedItem == null || cmbYear.SelectedItem == null ||
                cmbCubage.SelectedItem == null || cmbBody.SelectedItem == null || cmbDoors.SelectedItem == null ||
                cmbFuel.SelectedItem == null || cmbDrivetrain.SelectedItem == null || cmbTransmission.SelectedItem == null)
            {
                MessageBox.Show("All fields are required!");
                return false;
            }

            lbTerms.Invalidate();

            //Filtering chosen cars (same type)
            chosenCars = new List<Car>();
            var linq = filteredCars
                .Where(car => cmbCubage.SelectedItem.Equals(car.Cubage) && cmbBody.SelectedItem.Equals(car.Body) &&
                    cmbDoors.SelectedItem.Equals(car.Doors) && cmbFuel.SelectedItem.Equals(car.Fuel) &&
                    cmbDrivetrain.SelectedItem.Equals(car.Drivetrain) && cmbTransmission.SelectedItem.Equals(car.Transmission))
                .ToList();

            chosenCars.AddRange(linq);

            chosenCarOffers = new List<Offer>();

            if (chosenCars.Count != 0)
            {
                List<Offer> tmpOffers = new List<Offer>();
                tmpOffers = Data.ReadAll<Offer>();

                foreach (Car car in chosenCars)
                    chosenCarOffers.AddRange(tmpOffers.Where(x => x.CarID == car.CarID).ToList());
            }

            if (chosenCarOffers != null && chosenCarOffers.Count != 0)
            {
                ComparerClass cc = new ComparerClass();
                chosenCarOffers.Sort(cc);

                lbTerms.SelectionMode = SelectionMode.One;
                if (lbTerms.DataSource != null)
                    lbTerms.DataSource = null;

                lbTerms.DataSource = chosenCarOffers;
                lbTerms.Invalidate();
                lbTerms.SelectionMode = SelectionMode.None;
                CalculateTotalPrice();
                lbTerms.Refresh();
                lbTerms.Invalidate();
                txtTotal.Text = totalPrice.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("There are no offers yet.");
                return false;
            }
        }

        private void CalculateTotalPrice()
        {
            totalPrice = 0;
            txtTotal.Text = totalPrice.ToString();

            if (chosenCarOffers == null) return;

            Offer linq = chosenCarOffers.Where(offer => dtpPick.Value.Date >= offer.FromDate &&
            dtpReturn.Value.Date <= offer.ToDate && dtpReturn.Value.Date >= dtpPick.Value.Date).FirstOrDefault();

            if (linq != null)
            {
                TimeSpan ts = dtpReturn.Value.Date - dtpPick.Value.Date;
                totalPrice = (ts.Days + 1) * linq.PricePerDay;
                chosenOffer = linq;
            }
        }

        public void FillCBoxes(object s)
        {
            foreach (Car car in filteredCars)
            {
                if (cmbTransmission.SelectedItem != null && cmbTransmission.SelectedItem.Equals(s))
                    if (cmbTransmission.SelectedItem.Equals(car.Transmission))
                        AddCars(car);
                if (cmbCubage.SelectedItem != null && cmbCubage.SelectedItem.Equals(s))
                    if (cmbCubage.SelectedItem.Equals(car.Cubage))
                        AddCars(car);
                if (cmbFuel.SelectedItem != null && cmbFuel.SelectedItem.Equals(s))
                    if (cmbFuel.SelectedItem.Equals(car.Fuel))
                        AddCars(car);
                if (cmbDrivetrain.SelectedItem != null && cmbDrivetrain.SelectedItem.Equals(s))
                    if (cmbDrivetrain.SelectedItem.Equals(car.Drivetrain))
                        AddCars(car);
                if (cmbBody.SelectedItem != null && cmbBody.SelectedItem.Equals(s))
                    if (cmbBody.SelectedItem.Equals(car.Body))
                        AddCars(car);
                if (cmbDoors.SelectedItem != null && cmbDoors.SelectedItem.Equals(s))
                    if (cmbDoors.SelectedItem.Equals(car.Doors))
                        AddCars(car);
            }
        }
        private void cmbCubage_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbCubage);
        }

        private void cmbBody_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbTransmission);
        }

        private void cmbDoors_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbDoors);
        }

        private void cmbFuel_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbFuel);
        }

        private void cmbDrivetrain_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbDrivetrain);
        }

        private void cmbTransmission_SelectedValueChanged(object sender, EventArgs e)
        {
            CmbFillAndReset(cmbTransmission);
        }

        private void CmbFillAndReset(ComboBox cmb)
        {
            if (cmb.SelectedIndex == -1) return;

            if (cmb.Items.Count > 1)
            {
                ResetCBoxes(cmb.SelectedItem);
                FillCBoxes(cmb.SelectedItem);
                FillCBoxesValues();
            }
        }

        private void FillCBoxesValues()
        {
            if (cmbCubage.Items.Count == 1)
                cmbCubage.SelectedItem = cmbCubage.Items[0];
            if (cmbBody.Items.Count == 1)
                cmbBody.SelectedItem = cmbBody.Items[0];
            if (cmbDoors.Items.Count == 1)
                cmbDoors.SelectedItem = cmbDoors.Items[0];
            if (cmbFuel.Items.Count == 1)
                cmbFuel.SelectedItem = cmbFuel.Items[0];
            if (cmbDrivetrain.Items.Count == 1)
                cmbDrivetrain.SelectedItem = cmbDrivetrain.Items[0];
            if (cmbTransmission.Items.Count == 1)
                cmbTransmission.SelectedItem = cmbTransmission.Items[0];
        }

        private void AddCars(Car car)
        {
            if (!cmbCubage.Items.Contains(car.Cubage))
                cmbCubage.Items.Add(car.Cubage);

            if (!cmbBody.Items.Contains(car.Body))
                cmbBody.Items.Add(car.Body);

            if (!cmbDoors.Items.Contains(car.Doors))
                cmbDoors.Items.Add(car.Doors);

            if (!cmbFuel.Items.Contains(car.Fuel))
                cmbFuel.Items.Add(car.Fuel);

            if (!cmbDrivetrain.Items.Contains(car.Drivetrain))
                cmbDrivetrain.Items.Add(car.Drivetrain);

            if (!cmbTransmission.Items.Contains(car.Transmission))
                cmbTransmission.Items.Add(car.Transmission);
        }

        private void ResetAllBut1stThree()
        {
            Reset();
            ClearComboBox(cmbCubage);
            ClearComboBox(cmbBody);
            ClearComboBox(cmbDoors);
            ClearComboBox(cmbFuel);
            ClearComboBox(cmbDrivetrain);
            ClearComboBox(cmbTransmission);

        }

        //Resets listView, datePickers and txtPrice
        private void Reset()
        {
            lbTerms.SelectionMode = SelectionMode.One;
            if (lbTerms.DataSource == null)
                lbTerms.DataSource = null;
            lbTerms.SelectionMode = SelectionMode.None;

            dtpReturn.Value = DateTime.Now.Date;
            dtpPick.Value = DateTime.Now.Date;

            dtpPick.Enabled = false;
            dtpReturn.Enabled = false;

            totalPrice = 0;
            txtTotal.Text = "0";
        }

        private void btnShowTerms_Click(object sender, EventArgs e)
        {
            if (ShowOffers())
            {
                dtpReturn.Enabled = true;
                dtpPick.Enabled = true;
            }

        }
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (chosenCarOffers.Count != 0)
            {
                CalculateTotalPrice();
                txtTotal.Text = totalPrice.ToString();
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (totalPrice != 0)
            {
                Reservation tmp = new Reservation(chosenOffer.CarID, client.ClientID, dtpPick.Value.Date, dtpReturn.Value.Date, totalPrice);
                tmp.AppointmentOccupation(chosenOffer);
                ShowOffers();
                Data.Save<Reservation>(tmp);
                refreshData();
                MessageBox.Show("The term has been reserved successfully!");
                return;
            }
            MessageBox.Show("Date out of bounds!");
        }

        private List<Car> FilterByCriteria(object s)
        {
            List<Car> filtered = new List<Car>();
            if (s.Equals(cmbCubage.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Cubage == int.Parse(s.ToString()));
                filtered = linq.ToList();
            }
            else if (s.Equals(cmbBody.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Body == s.ToString());
                filtered = linq.ToList();
            }

            else if (s.Equals(cmbDoors.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Doors == int.Parse(s.ToString()));
                filtered = linq.ToList();
            }
            else if (s.Equals(cmbFuel.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Fuel == s.ToString());
                filtered = linq.ToList();
            }
            else if (s.Equals(cmbDrivetrain.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Drivetrain == s.ToString());
                filtered = linq.ToList();
            }
            else if (s.Equals(cmbTransmission.SelectedItem))
            {
                var linq = filteredCars.Where(x => x.Transmission == s.ToString());
                filtered = linq.ToList();
            }
            return filtered;
        }

        private void ResetCBoxes(object s)
        {
            Reset();

            if (s != null)
            {
                List<Car> filtered = FilterByCriteria(s);

                if (s.Equals(cmbCubage.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Cubage == int.Parse(s.ToString()));
                    filtered = linq.ToList();
                }
                else if (s.Equals(cmbBody.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Body == s.ToString());
                    filtered = linq.ToList();
                }
                else if (s.Equals(cmbDoors.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Doors == int.Parse(s.ToString()));
                    filtered = linq.ToList();
                }
                else if (s.Equals(cmbFuel.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Fuel == s.ToString());
                    filtered = linq.ToList();
                }
                else if (s.Equals(cmbDrivetrain.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Drivetrain == s.ToString());
                    filtered = linq.ToList();
                }
                else if (s.Equals(cmbTransmission.SelectedItem))
                {
                    var linq = filteredCars.Where(x => x.Transmission == s.ToString());
                    filtered = linq.ToList();
                }


                if (!s.Equals(cmbCubage.SelectedItem))
                {
                    if (cmbCubage.SelectedItem == null)
                        ClearComboBox(cmbCubage);
                    else
                    {
                        var linq = filtered.Where(x => x.Cubage == int.Parse(cmbCubage.SelectedItem.ToString())).Count();
                        if (linq == 0)
                            ClearComboBox(cmbCubage);
                    }
                }
                if (!s.Equals(cmbBody.SelectedItem))
                {
                    if (cmbBody.SelectedItem == null)
                        ClearComboBox(cmbBody);
                    else
                    {
                        var linq = filtered.Where(x => x.Body == cmbBody.SelectedItem.ToString()).Count();
                        if (linq == 0)
                            ClearComboBox(cmbBody);
                    }
                }

                if (!s.Equals(cmbDoors.SelectedItem))
                {
                    if (cmbDoors.SelectedItem == null)
                        ClearComboBox(cmbDoors);
                    else
                    {
                        var linq = filtered.Where(x => x.Doors == int.Parse(cmbDoors.SelectedItem.ToString())).Count();
                        if (linq == 0)
                            ClearComboBox(cmbDoors);
                    }
                }
                if (!s.Equals(cmbFuel.SelectedItem))
                {
                    if (cmbFuel.SelectedItem == null)
                        ClearComboBox(cmbFuel);
                    else
                    {
                        var linq = filtered.Where(x => x.Fuel == cmbFuel.SelectedItem.ToString()).Count();
                        if (linq == 0)
                            ClearComboBox(cmbFuel);
                    }
                }
                if (!s.Equals(cmbDrivetrain.SelectedItem))
                {
                    if (cmbDrivetrain.SelectedItem == null)
                        ClearComboBox(cmbDrivetrain);
                    else
                    {
                        var linq = filtered.Where(x => x.Drivetrain == cmbDrivetrain.SelectedItem.ToString()).Count();
                        if (linq == 0)
                            ClearComboBox(cmbDrivetrain);
                    }
                }
                if (!s.Equals(cmbTransmission.SelectedItem))
                {
                    if (cmbTransmission.SelectedItem == null)
                        ClearComboBox(cmbTransmission);
                    else
                    {
                        var linq = filtered.Where(x => x.Transmission == cmbTransmission.SelectedItem.ToString()).Count();
                        if (linq == 0)
                            ClearComboBox(cmbTransmission);
                    }
                }
            }
        }
    }
}
