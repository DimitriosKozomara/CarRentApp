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
    public partial class frmClientInterface : Form
    {
        Client client;
        frmLogIn frmLogIn;
        List<Reservation> reservations;
        List<Reservation> clientReservations;
        int chosenResID;

        public frmClientInterface()
        {
            InitializeComponent();
        }

        public frmClientInterface(Client client, frmLogIn frmLogIn) : this()
        {
            this.client = client;
            this.frmLogIn = frmLogIn;
            reservations = new List<Reservation>();
            clientReservations = new List<Reservation>();
            chosenResID = -1;
        }

        private void btnNewRes_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReservation frm = new frmReservation(client, this);
            frm.refreshData += RefreshReservations;
            frm.Show();

        }

        private void ClientReservations_Shown(object sender, EventArgs e)
        {
            RefreshReservations();
            this.Text = client.Name + lblClientName.Text;
            lblClientName.Text = client.Name + lblClientName.Text;
            lblClientName.Left = (this.ClientSize.Width - lblClientName.Size.Width) / 2;
            lblNoReservations.Left = (this.ClientSize.Width - lblNoReservations.Size.Width) / 2;
        }

        private void btnCancelRes_Click(object sender, EventArgs e)
        {
            if (chosenResID != -1)
            {
                Reservation reservation = reservations.Where(x => x.ReservationID == chosenResID).FirstOrDefault();
                reservation.ReturnAppointment();
                reservations.Remove(reservation);
                Data.Update(reservations);
                RefreshReservations();
                MessageBox.Show("The reservation has been deleted successfully");
            }
        }

        private void RefreshReservations()
        {
            chosenResID = -1;
            List<Car> cars = Data.ReadAll<Car>();
            reservations = Data.ReadAll<Reservation>();
            clientReservations = new List<Reservation>();

            if (reservations != null)
                clientReservations = reservations.Where(x => x.ClientID == client.ClientID).ToList();
            //colResID, colClientID, ColCarID, Car information, Pick date, Return date, Price 

            if (!clientReservations.Any())
            {
                dgvReservations.Visible = false;
                lblNoReservations.Visible = true;
            }
            else
            {
                dgvReservations.Visible = true;
                lblNoReservations.Visible = false;
            }


            int row = 0;

            dgvReservations.Rows.Clear();
            dgvReservations.Refresh();
            dgvReservations.Invalidate();

            if (clientReservations.Count > 0)
                foreach (Reservation res in clientReservations)
                {
                    string carToString = "Car deleted";
                    //for Cell[3].Value --> foundCar.ToString()
                    Car foundCar = cars.Where(x => x.CarID == res.CarID).FirstOrDefault();
                    if (foundCar != null)
                        carToString = foundCar.ToString();


                    dgvReservations.Rows.Add();
                    dgvReservations.Rows[row].Cells[0].Value = res.ReservationID;
                    dgvReservations.Rows[row].Cells[1].Value = res.CarID;
                    dgvReservations.Rows[row].Cells[2].Value = res.ClientID;
                    dgvReservations.Rows[row].Cells[3].Value = carToString;//(cars.Where(x => x.CarID == res.CarID).FirstOrDefault() as Car).ToString();
                    dgvReservations.Rows[row].Cells[4].Value = res.FromDate.ToShortDateString();
                    dgvReservations.Rows[row].Cells[5].Value = res.ToDate.ToShortDateString();
                    dgvReservations.Rows[row].Cells[6].Value = res.Price;
                    //Hopefully works
                    row++;
                }

            dgvReservations.ClearSelection();
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count != 0 && dgvReservations.SelectedRows[0].Cells[0].Value != null)
                chosenResID = int.Parse(dgvReservations.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogIn.Show();
            frmLogIn.ClearPassword();
        }

        private void ClientReservations_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
