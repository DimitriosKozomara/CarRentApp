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
    public partial class frmAdminPanel : Form
    {
        frmLogIn frmLogIn;
        List<Client> clients;
        List<Car> cars;
        List<Offer> offers;
        List<Offer> chosenCarOffers;
        List<Reservation> chosenClientReservations;
        List<Reservation> reservations;

        Client chosenClient;
        Car chosenCar;
        Offer chosenOffer;
        Reservation chosenReservation;

        int totalPrice;

        Dictionary<int, int> statistics;
        List<Color> colors;
        int chosenYear;
        int chosenMonth;
        public frmAdminPanel()
        {
            InitializeComponent();
        }

        public frmAdminPanel(frmLogIn frm) : this()
        {
            frmLogIn = frm;
            tabPane.TabPages[4].Paint += PaintPie;
        }

        private void TabClients_Enter(object sender, EventArgs e)
        {
            ClearErrorProviders();
            RefreshClients();
            cmbClientsOption.SelectedIndex = 0;
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                frmLogIn.Close();
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        private void LblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn.Show();
        }

        private void EnableForms(Panel panel, bool check)
        {
            //Doesn't affect btns, lbls, cmbs (exept cmbs from pnlCarCmb, and cmbResCar)
            foreach (Control c in panel.Controls)
                if (!(c is Button) && !(c is Label) &&
                    (!(c is ComboBox) || c.Equals(cmbResCar) || panel.Equals(pnlCarCmb)))
                    c.Enabled = check;
            ClearErrorProviders();
        }

        private bool IsValidClient()
        {
            if (!txtName.Enabled)
                return true;
            if (txtName.Text.Trim().Length != 0 && !txtName.Text.Contains(" ") &&
                txtSurname.Text.Trim().Length != 0 && !txtSurname.Text.Contains(" ") &&
                txtUsername.Text.Trim().Length != 0 && !txtUsername.Text.Contains(" ") &&
                txtPassword.Text.Trim().Length != 0 && !txtPassword.Text.Contains(" ") &&
                mtxPIN.Text.Length != 0 && mtxPhone.Text.Length != 0 && dpBirthDate.Value.Date != DateTime.Now.Date)
                return true;
            return false;
        }

        private bool IsValidCar()
        {
            if (!txtMake.Enabled)
                return true;
            if (txtMake.Text.Trim() != "" && txtModel.Text.Trim() != "" &&
                mtxYear.Text != "" && mtxCubage.Text != "" &&
                cmbFuel.SelectedIndex != -1 && cmbDoors.SelectedIndex != -1 && cmbBody.SelectedIndex != -1 &&
                cmbDrivetrain.SelectedIndex != -1 && cmbTransmission.SelectedIndex != -1)
                return true;
            return false;
        }

        private bool IsErrorProviderValid(Panel panel)
        {
            foreach (Control c in panel.Controls)
                if (errorProvider1.GetError(c).Length > 0)
                    return false;
            return true;

        }

        private void ClearErrorProviders()
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
        }

        private void BtnClSubmit_Click(object sender, EventArgs e)
        {
            if (cmbClientsOption.SelectedIndex == 0 && IsValidClient() && IsErrorProviderValid(pnlClients)) //new
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string pin = mtxPIN.Text;
                string number = mtxPhone.Text;
                DateTime dateOfBirth = dpBirthDate.Value.Date;

                if (!User.UsernameExists(username))
                {
                    Data.Save<Client>(new Client(username, password, name, surname, pin, dateOfBirth, number));
                    MessageBox.Show("A client has been successfully registered!");
                    ClearErrorProviders();
                    RefreshClients();
                    ClearClientForm();
                }
                else
                    MessageBox.Show("Username \"" + username + "\" exists!");
            }
            else if (cmbClientsOption.SelectedIndex == 1 && IsValidClient() && IsErrorProviderValid(pnlClients) &&
                chosenClient != null && dgvClients.SelectedRows.Count == 1) //update
            {
                if (txtUsername.Text != chosenClient.Username && User.UsernameExists(txtUsername.Text))
                {
                    MessageBox.Show("Username \"" + txtUsername.Text + "\" exists!");
                    return;
                }

                chosenClient.Username = txtUsername.Text;
                chosenClient.Password = txtPassword.Text;
                chosenClient.Name = txtName.Text;
                chosenClient.Surname = txtSurname.Text;
                chosenClient.PIN = mtxPIN.Text;
                chosenClient.Number = mtxPhone.Text;
                chosenClient.DateOfBirth = dpBirthDate.Value.Date;

                Data.Update<Client>(clients);
                MessageBox.Show("A client has been successfully updated!");
                ClearErrorProviders();
                RefreshClients();
                ClearClientForm();

            }
            else if (cmbClientsOption.SelectedIndex == 2 && chosenClient != null && dgvClients.SelectedRows.Count > 0) //delete
            {
                clients.Remove(chosenClient);
                Data.Update<Client>(clients);
                MessageBox.Show("A client has been successfully deleted!");
                ClearErrorProviders();
                RefreshClients();
                ClearClientForm();
            }
            else
                MessageBox.Show("Clients form is not filled correctly!");
        }

        private void DgvClients_SelectionChanged(object sender, EventArgs e)
        {
            FindChosenAndFillForm<Client>(cmbClientsOption, dgvClients, "clientID");
        }

        private void FillForm<T>(T t) where T : class
        {
            if (typeof(T) == typeof(Client))
            {
                Client c = t as Client;
                txtUsername.Text = c.Username;
                txtPassword.Text = c.Password;
                txtName.Text = c.Name;
                txtSurname.Text = c.Surname;
                mtxPIN.Text = c.PIN;
                mtxPhone.Text = c.Number;
                dpBirthDate.Value = c.DateOfBirth;
            }
            else if (typeof(T) == typeof(Car))
            {
                Car c = t as Car;
                txtMake.Text = c.Make;
                txtModel.Text = c.Model;
                mtxYear.Text = c.Year.ToString();
                mtxCubage.Text = c.Cubage.ToString();
                cmbDrivetrain.SelectedItem = c.Drivetrain;
                cmbTransmission.SelectedItem = c.Transmission;
                cmbBody.SelectedItem = c.Body;
                cmbFuel.SelectedItem = c.Fuel;
                cmbDoors.SelectedItem = c.Doors.ToString();
            }
            else if (typeof(T) == typeof(Offer))
            {
                Offer offer = t as Offer;
                dtpFrom.Value = offer.FromDate.Date;
                dtpTo.Value = offer.ToDate.Date;
                txtPpday.Text = offer.PricePerDay.ToString();
            }
        }
        private void ClearClientForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtSurname.Clear();
            mtxPIN.Clear();
            mtxPhone.Clear();
            dpBirthDate.Value = DateTime.Now;
        }

        private void RefreshClients()
        {
            clients = Data.ReadAll<Client>();

            if (clients == null || clients.Count == 0)
                return;

            if (dgvClients.DataSource != null)
                dgvClients.DataSource = null;

            dgvClients.DataSource = clients;
            dgvClients.Columns["password"].Visible = false;
            dgvClients.AutoResizeColumns();
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvClients.ClearSelection();
        }

        private void MaskedTextBox_ClickAndEnter(object sender, EventArgs e)
        {
            frmLogIn.SetCursor(sender as MaskedTextBox);
        }

        public void ValidateControls(Control c, bool cond, string errorText)
        {
            if (cond)
            {
                errorProvider1.SetError(c, errorText);
                errorProvider2.SetError(c, "");
            }
            else
            {
                errorProvider1.SetError(c, "");
                errorProvider2.SetError(c, "Correct");
            }
        }

        private void txtPIN_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(mtxPIN, mtxPIN.Text.Length != 13, "Not enough digits!");
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(mtxPhone, mtxPhone.Text.Length < 9, "Not enough digits!");
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim().Length > 0)
            {
                string s = txtName.Text.Substring(0, 1);
                char c = s[0];
                ValidateControls(txtName,
                    Char.IsNumber(c) || Char.IsLower(c) || txtName.Text.Contains(" "),
                    "Wrong name format!");
            }
            else
            {
                errorProvider1.SetError(txtName, "This field is required!");
                errorProvider2.SetError(txtName, "");
            }
        }
        /*
        private void ControlsValidating(object sender, CancelEventArgs e)
        {
             (sender as Control).Validated();
        }*/

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (txtSurname.Text.Trim().Length > 0)
            {
                string s = txtSurname.Text.Substring(0, 1);
                char c = s[0];
                ValidateControls(txtSurname,
                    Char.IsNumber(c) || Char.IsLower(c) || txtSurname.Text.Contains(" "),
                    "Wrong surname format!");
            }
            else
            {
                errorProvider1.SetError(txtSurname, "This field is required!");
                errorProvider2.SetError(txtSurname, "");
            }
        }

        private void dpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(dpBirthDate, DateTime.Today.Year - dpBirthDate.Value.Year < 18,
                "Persons under 18 are not allowed to order vehicles!");
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsername.Text.Length > 0)
            {
                string s = txtUsername.Text.Substring(0, 1);
                char c = s[0];
                ValidateControls(txtUsername,
                    Char.IsNumber(c) || txtUsername.Text.Contains(" "),
                    "Wrong username format!");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "This field is required!");
                errorProvider2.SetError(txtUsername, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(txtPassword, txtPassword.Text.Length < 5,
                "The password must be longer than 4 caracters!");
        }

        private void btnCarSubmit_Click(object sender, EventArgs e)
        {
            if (cmbCarOption.SelectedIndex == 0 && IsErrorProviderValid(pnlCars) && IsValidCar()) //new
            {
                string make = txtMake.Text;
                string model = txtModel.Text;
                int year = int.Parse(mtxYear.Text);
                int cubage = int.Parse(mtxCubage.Text);
                string drivetrain = cmbDrivetrain.SelectedItem.ToString();
                string transmission = cmbTransmission.SelectedItem.ToString();
                string body = cmbBody.SelectedItem.ToString();
                string fuel = cmbFuel.SelectedItem.ToString();
                int doors = int.Parse(cmbDoors.SelectedItem.ToString());

                Data.Save<Car>(new Car(make, model, year, cubage, drivetrain, transmission, body, fuel, doors));
                MessageBox.Show("A car has been successfully added!");
                ClearErrorProviders();
                ClearCarForm();
                RefreshCars();
            }
            else if (cmbCarOption.SelectedIndex == 1 && IsErrorProviderValid(pnlCars) && IsValidCar() &&
                chosenCar != null && dgvCars.SelectedRows.Count == 1) //update
            {
                chosenCar.Make = txtMake.Text;
                chosenCar.Model = txtModel.Text;
                chosenCar.Year = int.Parse(mtxYear.Text);
                chosenCar.Cubage = int.Parse(mtxCubage.Text);
                chosenCar.Drivetrain = cmbDrivetrain.SelectedItem.ToString();
                chosenCar.Transmission = cmbTransmission.SelectedItem.ToString();
                chosenCar.Body = cmbBody.SelectedItem.ToString();
                chosenCar.Fuel = cmbFuel.SelectedItem.ToString();
                chosenCar.Doors = int.Parse(cmbDoors.SelectedItem.ToString());

                Data.Update<Car>(cars);
                MessageBox.Show("A car has been successfully updated!");
                ClearErrorProviders();
                ClearCarForm();
                RefreshCars();

            }
            else if (cmbCarOption.SelectedIndex == 2 && chosenCar != null && dgvCars.SelectedRows.Count > 0) //delete
            {
                cars.Remove(chosenCar);
                Data.Update<Car>(cars);
                MessageBox.Show("A car has been successfully deleted!");
                ClearErrorProviders();
                ClearCarForm();
                RefreshCars();
            }
            else
                MessageBox.Show("Car form is not filled correctly!");
        }

        private void RefreshCars()
        {
            cars = Data.ReadAll<Car>();

            if (dgvCars.DataSource != null)
                dgvCars.DataSource = null;

            dgvCars.DataSource = cars;
            dgvCars.AutoResizeColumns();
            dgvCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void FindChosenAndFillForm<T>(ComboBox cmb, DataGridView dgv, string cellId)
        {
            if ((cmb.SelectedIndex == 1 || cmb.SelectedIndex == 2) &&
                dgv.DataSource != null && dgv.SelectedRows.Count != 0)
            {
                int id = int.Parse(dgv.SelectedRows[0].Cells[cellId].Value.ToString());

                if (typeof(T) == typeof(Client))
                {
                    chosenClient = clients.Where(x => x.ClientID == id).FirstOrDefault();

                    if (cmb.SelectedIndex == 1) //update Client form
                        FillForm(chosenClient);
                }
                else if (typeof(T) == typeof(Car))
                {
                    chosenCar = cars.Where(x => x.CarID == id).FirstOrDefault();

                    if (cmb.SelectedIndex == 1) //update Car form
                        FillForm(chosenCar);
                }
                else if (typeof(T) == typeof(Offer))
                {
                    chosenOffer = chosenCarOffers.Where(x => x.OfferID == id).FirstOrDefault();

                    if (cmb.SelectedIndex == 1) //update Offer form
                        FillForm(chosenOffer);
                }
                else if (typeof(T) == typeof(Reservation))
                    chosenReservation = chosenClientReservations.Where(x => x.ReservationID == id).FirstOrDefault();

                ClearErrorProviders();
            }
        }

        private void dgvCars_SelectionChanged(object sender, EventArgs e)
        {
            FindChosenAndFillForm<Car>(cmbCarOption, dgvCars, "carID");
        }

        private void ClearCarForm()
        {
            txtMake.Clear();
            txtModel.Clear();
            mtxYear.Clear();
            mtxCubage.Clear();
            cmbDrivetrain.SelectedIndex = -1;
            cmbTransmission.SelectedIndex = -1;
            cmbBody.SelectedIndex = -1;
            cmbFuel.SelectedIndex = -1;
            cmbDoors.SelectedIndex = -1;
            dgvCars.ClearSelection();
        }

        private void tabCars_Enter(object sender, EventArgs e)
        {
            ClearErrorProviders();
            RefreshCars();
            List<string> makeList = Data.ReadAll<string>();
            var source = new AutoCompleteStringCollection();
            source.AddRange(makeList.ToArray());
            txtMake.AutoCompleteCustomSource = source;
            cmbCarOption.SelectedIndex = 0;
        }

        private void txtMake_Validating(object sender, CancelEventArgs e)
        {
            if (txtMake.Text.Trim().Length > 0)
            {
                string s = txtMake.Text.Substring(0, 1);
                char c = s[0];

                ValidateControls(txtMake, Char.IsNumber(c) || Char.IsLower(c), "Wrong make format!");
            }
            else
            {
                errorProvider1.SetError(txtMake, "This field is required!");
                errorProvider2.SetError(txtMake, "");
            }
        }

        private void txtModel_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(txtModel, txtModel.Text.Trim().Length == 0, "This field is required!");
        }

        private void mtxYear_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(mtxYear.Text, out int test))
            {
                ValidateControls(mtxYear, true, "Numbers required!");
                return;
            }

            ValidateControls(mtxYear, int.Parse(mtxYear.Text) < 2000, "Cars older than 2000 are not allowed!");
        }

        private void mtxCubage_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(mtxCubage.Text, out int test))
            {
                ValidateControls(mtxCubage, true, "Numbers required!");
                return;
            }

            ValidateControls(mtxCubage,
                mtxCubage.Text.Length < 4 || int.Parse(mtxCubage.Text) < 1000 || int.Parse(mtxCubage.Text) > 10000,
                "Wrong cubage format!");
        }

        private void ComboBoxValidation(ComboBox comboBox)
        {
            ValidateControls(comboBox, comboBox.SelectedIndex < 0, "This field is required!");
        }

        private void Cmb_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxValidation(sender as ComboBox);
        }

        private bool IsOfferFormValid()
        {
            if (!dtpFrom.Enabled)
                return true;
            if (cmbOfferCar.Text.Trim().Length == 0 || cmbOfferOption.Text.Trim().Length == 0 ||
                dtpFrom.Value.Date > dtpTo.Value.Date || txtPpday.Text.Trim().Length == 0 || txtPpday.Text == "0")
                return false;
            return true;
        }

        private void btnOfferSubmit_Click(object sender, EventArgs e)
        {
            if (!IsErrorProviderValid(pnlOffers) || !IsOfferFormValid())
            {
                MessageBox.Show("Form is not filled correctly!");
                return;
            }

            DateTime from = DateTime.Now;
            DateTime to = DateTime.Now;
            int price = -1;

            if (cmbOfferOption.SelectedIndex != 2)
            {
                from = dtpFrom.Value.Date;
                to = dtpTo.Value.Date;
                price = int.Parse(txtPpday.Text);
            }

            if (cmbOfferOption.SelectedIndex == 0) // new
            {
                Data.Save<Offer>(new Offer(chosenCar.CarID, from, to, price));

                MessageBox.Show("Car offer has been successfully created!");
                ClearErrorProviders();
                RefreshOffers();
                ClearOffersForm();

            }
            else if (cmbOfferOption.SelectedIndex == 1 && chosenOffer != null && dgvOffers.SelectedRows.Count == 1) //update
            {
                chosenOffer.ToDate = to;
                chosenOffer.FromDate = from;
                chosenOffer.PricePerDay = price;

                Data.Update<Offer>(offers);

                MessageBox.Show("Car offer has been successfully updated!");
                RefreshOffers();
                ClearOffersForm();
            }
            else if (cmbOfferOption.SelectedIndex == 2 && chosenOffer != null && dgvOffers.SelectedRows.Count > 0) //delete
            {
                offers.Remove(chosenOffer);
                Data.Update(offers);
                MessageBox.Show("Car offer has been successfully deleted!");
                RefreshOffers();
            }
        }

        private void ClearOffersForm()
        {
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now;
            txtPpday.Clear();
        }
        private void tabOffers_Enter(object sender, EventArgs e)
        {
            ClearErrorProviders();

            cars = Data.ReadAll<Car>();
            if (cmbOfferCar.DataSource != null)
                cmbOfferCar.DataSource = null;

            cmbOfferCar.DataSource = cars;
            cmbOfferCar.SelectedIndex = -1;

            if (dgvOffers.DataSource != null)
                dgvOffers.DataSource = null;

            cmbOfferOption.SelectedIndex = 0;
            cmbOfferOption.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RefreshOffers()
        {
            chosenCar = null;
            if (cmbOfferCar.SelectedIndex != -1)
            {
                chosenCar = cmbOfferCar.SelectedItem as Car;

                offers = Data.ReadAll<Offer>();

                if (dgvOffers.DataSource != null)
                    dgvOffers.DataSource = null;

                if (offers != null)
                {
                    chosenCarOffers = offers.Where(x => x.CarID == chosenCar.CarID).ToList();
                    dgvOffers.DataSource = chosenCarOffers;
                    dgvOffers.ClearSelection();
                }
            }
        }

        private void cmbOfferCar_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshOffers();
        }

        //if CheckControl is false, then we set other controls to true
        private void CBOption_SelectedIndexCheck(ComboBox cb, Panel p, Control checkControl = null)
        {
            ClearErrorProviders();

            string item = cb.SelectedItem.ToString().ToLower();

            if (item.Equals("new") || item.Equals("register") ||                            // new, register,
                (item.Equals("update") && (checkControl == null || !checkControl.Enabled))) // update
                EnableForms(p, true);
            else if (item.Equals("delete"))                                                 // delete
                EnableForms(p, false);
        }

        private void cmbOfferOption_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvOffers.ClearSelection();
            ClearOffersForm();
            CBOption_SelectedIndexCheck(cmbOfferOption, pnlOffers, dtpTo);
        }

        private void dgvOffers_SelectionChanged(object sender, EventArgs e)
        {
            FindChosenAndFillForm<Offer>(cmbOfferOption, dgvOffers, "offerID");
        }

        private void dtpResFrom_ValueChanged(object sender, EventArgs e)
        {
            CalculateFullPrice();
        }

        private void tabReservations_Enter(object sender, EventArgs e)
        {
            ClearErrorProviders();

            clients = Data.ReadAll<Client>();
            if (cmbResClient.DataSource != null)
                cmbResClient.DataSource = null;

            cmbResClient.DataSource = clients;
            cmbResClient.SelectedIndex = -1;

            if (dgvReservations.DataSource != null)
                dgvReservations.DataSource = null;

            cmbResOption.SelectedIndex = 0;
            cmbResOption.DropDownStyle = ComboBoxStyle.DropDownList;

            cars = Data.ReadAll<Car>();
            if (cmbResCar.DataSource != null)
                cmbResCar.DataSource = null;

            cmbResCar.DataSource = cars;
            cmbResCar.SelectedIndex = -1;

            lstResOffers.DataSource = null;
        }

        private void cmbResOption_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvReservations.ClearSelection();
            ClearResForm();
            CBOption_SelectedIndexCheck(cmbResOption, pnlReservations, dtpResFrom);
        }

        public void ClearResForm()
        {
            cmbResCar.SelectedIndex = -1;
            dtpResTo.Value = DateTime.Now;
            dtpResFrom.Value = DateTime.Now;
            if (lstResOffers.DataSource != null)
                lstResOffers.DataSource = null;
            txtTotal.Clear();
        }
        private void cmbResCar_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbResCar.SelectedIndex != -1)
            {
                offers = Data.ReadAll<Offer>();
                chosenCar = (Car)cmbResCar.SelectedItem;
                if (offers != null)
                {
                    chosenCarOffers = offers.Where(x => x.CarID == chosenCar.CarID).ToList();
                    if (lstResOffers.DataSource != null)
                        lstResOffers.DataSource = null;

                    lstResOffers.DataSource = chosenCarOffers;
                }
                CalculateFullPrice();
            }
        }

        private void CalculateFullPrice()
        {
            if (chosenCar != null)
            {
                totalPrice = 0;
                txtTotal.Text = totalPrice.ToString();

                if (chosenCarOffers == null)
                    return;

                chosenOffer = chosenCarOffers.Where(x => dtpResTo.Value.Date >= dtpResFrom.Value.Date &&
                dtpResFrom.Value.Date >= x.FromDate && dtpResTo.Value.Date <= x.ToDate).FirstOrDefault();

                if (chosenOffer != null)
                {
                    TimeSpan ts = dtpResTo.Value.Date - dtpResFrom.Value.Date;
                    totalPrice = (ts.Days + 1) * chosenOffer.PricePerDay;
                    txtTotal.Text = totalPrice.ToString();
                }
            }
        }

        private void dtpResTo_ValueChanged(object sender, EventArgs e)
        {
            CalculateFullPrice();
        }

        private void btnResSubmit_Click(object sender, EventArgs e)
        {
            if (!IsErrorProviderValid(pnlReservations) || !IsReservationFormValid())
            {
                MessageBox.Show("Form is not filled correctly!");
                return;
            }
            DateTime from = DateTime.Now;
            DateTime to = DateTime.Now;
            int id = -1;

            if (cmbResOption.SelectedIndex == 0) // new
            {
                from = dtpResFrom.Value.Date;
                to = dtpResTo.Value.Date;
                id = ((Car)cmbResCar.SelectedItem).CarID;

                Reservation tmp = new Reservation(chosenCar.CarID, chosenClient.ClientID, from, to, totalPrice);
                tmp.AppointmentOccupation(chosenOffer);
                Data.Save<Reservation>(tmp);

                totalPrice = 0;
                txtTotal.Clear();
                MessageBox.Show("Reservation has been successfully created!");
                ClearErrorProviders();
                RefreshReservations();
                ClearResForm();

            }
            else if (cmbResOption.SelectedIndex == 1 && chosenReservation != null && dgvReservations.SelectedRows.Count != 0) //delete
            {
                chosenReservation.ReturnAppointment();
                reservations.Remove(chosenReservation);
                Data.Update(reservations);
                MessageBox.Show("Reservation has been successfully deleted!");
                RefreshReservations();
            }
        }

        private void cmbResClient_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshReservations();
        }

        private void RefreshReservations()
        {
            chosenClient = null;

            if (cmbResClient.SelectedIndex != -1)
            {
                reservations = Data.ReadAll<Reservation>();
                chosenClient = (Client)cmbResClient.SelectedItem;

                if (dgvReservations.DataSource != null)
                    dgvReservations.DataSource = null;

                if (reservations != null)
                {
                    chosenClientReservations = reservations.Where(x => x.ClientID == chosenClient.ClientID).ToList();
                    dgvReservations.DataSource = chosenClientReservations;
                    dgvReservations.ClearSelection();
                }
            }
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            FindChosenAndFillForm<Reservation>(cmbResOption, dgvReservations, "reservationID");
        }

        private void dtpFrom_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(dtpFrom, dtpFrom.Value.Date > dtpTo.Value.Date, "Invalid date range!");
            ValidateControls(dtpTo, dtpTo.Value.Date < dtpFrom.Value.Date, "Invalid date range!");
        }

        private void dtpTo_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(dtpFrom, dtpFrom.Value.Date > dtpTo.Value.Date, "Invalid date range!");
            ValidateControls(dtpTo, dtpTo.Value.Date < dtpFrom.Value.Date, "Invalid date range!");
        }

        private void txtPpday_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtPpday_Validating(object sender, CancelEventArgs e)
        {

            if (txtPpday.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPpday, "This field is required!");
                errorProvider2.SetError(txtPpday, "");
            }
            else if (!int.TryParse(txtPpday.Text, out int test))
            {
                errorProvider1.SetError(txtPpday, "This field requires numbers!");
                errorProvider2.SetError(txtPpday, "");
            }
            else
            {
                errorProvider1.SetError(txtPpday, "");
                errorProvider2.SetError(txtPpday, "Correct");
            }
        }

        private void dtpResFrom_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(dtpResFrom, dtpResFrom.Value.Date > dtpResTo.Value.Date, "Invalid date range!");
            ValidateControls(dtpResTo, dtpResTo.Value.Date < dtpResFrom.Value.Date, "Invalid date range!");
        }

        private void dtpResTo_Validating(object sender, CancelEventArgs e)
        {
            ValidateControls(dtpResFrom, dtpResFrom.Value.Date > dtpResTo.Value.Date, "Invalid date range!");
            ValidateControls(dtpResTo, dtpResTo.Value.Date < dtpResFrom.Value.Date, "Invalid date range!");
        }

        private bool IsReservationFormValid()
        {
            if (!dtpResFrom.Enabled)
                return true;
            if (cmbResClient.Text.Length == 0 || cmbResCar.Text.Length == 0 || cmbResOption.Text.Length == 0 ||
                dtpResFrom.Value.Date > dtpResTo.Value.Date || txtTotal.Text.Length == 0 || txtTotal.Text == "0")
                return false;
            return true;
        }

        private void tabStatistics_Enter(object sender, EventArgs e)
        {
            ClearErrorProviders();
            // statistics
            flpStatLegend.HorizontalScroll.Enabled = false;
            flpStatLegend.AutoScroll = true;
            chosenMonth = -1;
            chosenYear = -1;
            int brMeseca = DateTime.Now.Date.Month;
            cmbStatMonth.SelectedItem = null;
            cmbStatMonth.SelectedIndex = brMeseca - 1;

            List<Reservation> allReservations = Data.ReadAll<Reservation>();
            if (allReservations == null)
                return;


            foreach (Reservation r in allReservations)
            {
                if (!cmbStatYear.Items.Contains(r.FromDate.Year))
                    cmbStatYear.Items.Add(r.FromDate.Year);

                if (!cmbStatYear.Items.Contains(r.ToDate.Year))
                    cmbStatYear.Items.Add(r.ToDate.Year);
            }

            cmbStatYear.SelectedItem = null;
            if (cmbStatYear.Items.Contains(DateTime.Now.Year))
                cmbStatYear.SelectedItem = DateTime.Now.Year;
        }

        public float CalculatePercentage(int noDays, int sum)
        {
            return noDays / (float)sum * 100.0f;
        }

        private void PaintPie(object sender, PaintEventArgs e)
        {
            if (cmbStatMonth.SelectedItem == null)
                return;

            float start = -90.0F;
            Rectangle r = new Rectangle(300, 50, 300, 300);

            if (statistics == null)
                return;

            var sum = statistics.Sum(x => x.Value);
            int i = 0;

            if (statistics.Count == 0)
                return;

            foreach (KeyValuePair<int, int> x in statistics)
            {
                e.Graphics.DrawEllipse(Pens.Gray, r);
                float angle = CalculatePercentage(x.Value, sum) * 3.6F;

                SolidBrush solidBrush = new SolidBrush(colors[i]);

                e.Graphics.FillPie(solidBrush, r, start, angle);

                start += angle;
                i++;
            }
        }

        public void OrganizeStatistics(int noMonth, int year)
        {
            Random rnd = new Random();
            colors = new List<Color>();
            statistics = new Dictionary<int, int>();
            List<Reservation> allReservations = Data.ReadAll<Reservation>();

            if (allReservations == null)
                return;

            var linq = allReservations.Where(x => x.ToDate.Date.Month == noMonth && x.FromDate.Date.Month == noMonth &&
            x.ToDate.Date.Year == year && x.FromDate.Date.Year == year);

            List<Reservation> monthlyReservations = linq.ToList();

            // How many days does a car take for each car
            var car = from x in monthlyReservations
                      group x by x.CarID into g
                      select new
                      {
                          carID = g.Key,
                          noDays = (int)g.Sum(x => (x.ToDate.Date - x.FromDate.Date).TotalDays + 1)
                      };

            foreach (var x in car)
            {
                statistics.Add(x.carID, (int)x.noDays);
                colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
            }
            // For terms in two months
            var linq2 = allReservations.Where(x => !(x.ToDate.Month == noMonth && x.FromDate.Month == noMonth) &&
            (x.ToDate.Month == noMonth || x.FromDate.Month == noMonth) && x.ToDate.Date.Year == year && x.FromDate.Date.Year == year);

            if (linq2.Any())
            {
                foreach (var x in linq2)
                {
                    int noDays = 0;
                    if (x.FromDate.Month == noMonth)
                    {
                        DateTime tmp = DateTime.Parse("" + DateTime.DaysInMonth(DateTime.Now.Year, noMonth) + "." + noMonth + "." + DateTime.Now.Year + ".");
                        noDays = (int)(tmp - x.FromDate).TotalDays + 1;
                    }
                    else if (x.ToDate.Month == noDays)
                        noDays = x.ToDate.Day;

                    statistics.Add(x.CarID, noDays);
                    colors.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                }
            }
        }

        private void PrintStatistics()
        {
            if (cmbStatMonth.SelectedItem != null && cmbStatYear.SelectedItem != null)
            {
                if (cmbStatMonth.SelectedIndex != chosenMonth || cmbStatYear.SelectedIndex != chosenYear)
                {
                    cars = Data.ReadAll<Car>();
                    if (flpStatLegend.Controls.Count != 0)
                        flpStatLegend.Controls.Clear();

                    int month = cmbStatMonth.SelectedIndex + 1;
                    int year = int.Parse(cmbStatYear.SelectedItem.ToString());
                    OrganizeStatistics(month, year);
                    var sum = statistics.Sum(x => x.Value);
                    int i = 0;
                    tabPane.TabPages[4].Invalidate();

                    if (statistics.Count != 0)
                    {
                        foreach (KeyValuePair<int, int> x in statistics)
                        {
                            Label l = new Label();
                            Label label = new Label();
                            label.Text = "●";
                            l.Text = "ID: " + x.Key + ", Number of days: " + x.Value + ", Percentage: " + CalculatePercentage(x.Value, sum).ToString("N") + "%";
                            label.ForeColor = colors[i];
                            label.Width = 10;
                            l.Width = 270;

                            var linq = cars.Where(a => a.CarID == x.Key).FirstOrDefault();
                            if (linq != null)
                            {
                                Car tmp = linq as Car;

                                ToolTip toolTip1 = new ToolTip
                                {
                                    AutoPopDelay = 5000,
                                    InitialDelay = 500,
                                    ReshowDelay = 500,
                                    ShowAlways = true
                                };
                                toolTip1.SetToolTip(l, tmp.ToString());
                            }
                            flpStatLegend.Controls.Add(label);
                            flpStatLegend.Controls.Add(l);
                            i++;


                        }
                    }

                    chosenYear = cmbStatYear.SelectedIndex;
                    chosenMonth = cmbStatMonth.SelectedIndex;
                }
            }
        }

        private void cmbStatYear_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintStatistics();
        }

        private void cmbStatMonth_SelectedValueChanged(object sender, EventArgs e)
        {
            PrintStatistics();
        }

        private void cmbClientsOption_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvClients.ClearSelection();
            ClearClientForm();
            CBOption_SelectedIndexCheck(cmbClientsOption, pnlClients, txtUsername);
        }

        private void cmbCarOption_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvCars.ClearSelection();
            ClearCarForm();
            CBOption_SelectedIndexCheck(cmbCarOption, pnlCars, txtMake);
        }
    }
}
