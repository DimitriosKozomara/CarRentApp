using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvpProj
{
    public partial class frmLogIn : Form
    {
        //Needed to call methods
        frmAdminPanel adminPanel;

        public frmLogIn()
        {
            InitializeComponent();
            adminPanel = new frmAdminPanel();
        }

        private void txt_EnterClick(object sender, EventArgs e)
        {
            SetCursor(sender as MaskedTextBox);
        }

        public static void SetCursor(MaskedTextBox textBox)
        {
            if (textBox == null)
                return;

            int pos = textBox.SelectionStart;

            if (pos > textBox.Text.Length)
                pos = textBox.Text.Length;

            textBox.Select(pos, 0);
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            pnlRegistration.Enabled = true;
            pnlLogIn.Enabled = false;

            txtUsername.Focus();
            this.Text = "Registration";
            errorProvider1.Clear();
            errorProvider2.Clear();
            ClearTextBoxes();
        }

        private void btnLogInForm_Click(object sender, EventArgs e)
        {
            pnlRegistration.Enabled = false;
            pnlLogIn.Enabled = true;

            txtUsername.Focus();
            this.Text = "Log in";
            ClearTextBoxes();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Trim().Length > 0)
            {
                string s = txtName.Text.Substring(0, 1);
                char c = s[0];

                adminPanel.ValidateControls(txtName, Char.IsNumber(s[0]) || Char.IsLower(c) || txtName.Text.Contains(" "),
                    "Wrong name format!");
            }
            else
            {
                errorProvider1.SetError(txtName, "This field is required!");
                errorProvider2.SetError(txtName, "");
            }

        }

        private bool IsErrorProviderValid(Panel panel)
        {
            foreach (Control c in panel.Controls)
                if (errorProvider1.GetError(c).Length > 0)
                    return false;
            return true;

        }

        private bool IsValid()
        {
            if (txtName.Text.Trim() != "" && !txtName.Text.Contains(" ") &&
                txtSurname.Text.Trim() != "" && !txtSurname.Text.Contains(" ") &&
                txtRegUsername.Text.Trim() != "" && !txtRegUsername.Text.Contains(" ") &&
                txtRegPassword.Text.Trim() != "" && !txtRegPassword.Text.Contains(" ") &&
                txtPIN.Text != "" && txtPhone.Text != "" && dpBirthDate.Value.Date != DateTime.Now.Date)
                return true;
            return false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (IsValid() && IsErrorProviderValid(pnlRegistration))
            {
                string username = txtRegUsername.Text;
                string password = txtRegPassword.Text;
                string name = txtName.Text;
                string surname = txtSurname.Text;
                string PIN = txtPIN.Text;
                string phone = txtPhone.Text;
                DateTime birthDate = dpBirthDate.Value;

                if (!User.UsernameExists(username))
                {
                    Data.Save<Client>(new Client(username, password, name, surname, PIN, birthDate, phone));
                    MessageBox.Show("Successfully registered!");
                }
                else
                    MessageBox.Show("Username \"" + username + "\" exists!");
            }
            else
                MessageBox.Show("Registration form is not filled correctly!");
        }

        private void ClearRegistration()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtPIN.Clear();
            txtPhone.Clear();
            dpBirthDate.Value = DateTime.Now;

        }

        public void LogInClear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            //Data.Make1stUsers();
            Data.Make1stCars();
            pnlRegistration.Enabled = false;
        }

        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            if (txtSurname.Text.Trim().Length > 0)
            {
                string s = txtSurname.Text.Substring(0, 1);
                char c = s[0];

                adminPanel.ValidateControls(txtSurname, Char.IsNumber(c) || Char.IsLower(c) || txtSurname.Text.Contains(" "),
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
            adminPanel.ValidateControls(dpBirthDate,
                DateTime.Today.Year - dpBirthDate.Value.Year < 18 || DateTime.Today.Year - dpBirthDate.Value.Year > 80,
                "Persons under 18 and above 80 are not allowed to order vehicles!");
        }

        private void txtRegUsername_Validating(object sender, CancelEventArgs e)
        {
            if (txtRegUsername.Text.Length > 0)
            {
                string s = txtRegUsername.Text.Substring(0, 1);
                char c = s[0];
                adminPanel.ValidateControls(txtRegUsername, Char.IsNumber(c) || txtRegUsername.Text.Contains(" "),
                    "Wrong username format!");
            }
            else
            {
                errorProvider1.SetError(txtRegUsername, "This field is required!");
                errorProvider2.SetError(txtRegUsername, "");
            }
        }

        private void txtRegPassword_Validating(object sender, CancelEventArgs e)
        {
            adminPanel.ValidateControls(txtRegPassword, txtRegPassword.Text.Length < 5,
                "The password must be longer than 4 caracters!");
        }

        private void txtPIN_Validating(object sender, CancelEventArgs e)
        {
            adminPanel.ValidateControls(txtPIN, txtPIN.Text.Length != 13, "Not enough digits!");
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            adminPanel.ValidateControls(txtPhone, txtPhone.Text.Length < 9, "Not enough digits!");
        }

        private void ClearTextBoxes()
        {
            txtUsername.Clear();
            txtPassword.Clear();

            txtName.Clear();
            txtSurname.Clear();
            txtPIN.Clear();
            dpBirthDate.Value = DateTime.Today;
            txtPhone.Clear();
            txtRegUsername.Clear();
            txtRegPassword.Clear();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("All fields are required!");
                return;
            }
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User k = User.Login(username, password);

            //Exit when no users
            if (k == null)
                return;

            if (k is Administrator)
                new frmAdminPanel(this).Show();
            else
                new frmClientInterface(k as Client, this).Show();

            ClearPassword();

            this.Hide();
            ClearRegistration();

        }

        public void ClearPassword()
        {
            txtPassword.Clear();
        }

        private void btnLogInForm_MouseDown(object sender, MouseEventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
        }

        private void btnAdminFill_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
            btnLogIn.PerformClick();
        }

        private void btnClientFill_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "dimitrios";
            txtPassword.Text = "12345";
            btnLogIn.PerformClick();
        }
    }
}