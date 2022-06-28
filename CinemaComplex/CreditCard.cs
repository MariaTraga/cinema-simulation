using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{
    public partial class CreditCard : Form
    {
        public static String ticket;
        String senderForm;
        public CreditCard()
        {
            InitializeComponent();
        }

        public CreditCard(String str)
        {
            InitializeComponent();
            senderForm = str;
        }

        private void txtCardNumber_Enter(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Equals("1234567812345678"))
            {
                txtCardNumber.Text = "";
                txtCardNumber.ForeColor = Color.Black;
            }
        }

        private void txtCardNumber_Leave(object sender, EventArgs e)
        {
            if (txtCardNumber.Text.Equals(""))
            {
                txtCardNumber.Text = "1234567812345678";
                txtCardNumber.ForeColor = Color.Silver;
            }
        }

        private void txtCardName_Enter(object sender, EventArgs e)
        {
            if (txtCardName.Text.Equals("John Doe"))
            {
                txtCardName.Text = "";
                txtCardName.ForeColor = Color.Black;
            }
        }

        private void txtCardName_Leave(object sender, EventArgs e)
        {
            if (txtCardName.Text.Equals(""))
            {
                txtCardName.Text = "John Doe";
                txtCardName.ForeColor = Color.Silver;
            }
        }

        private void txtExpDate_Enter(object sender, EventArgs e)
        {
            if (txtExpDate.Text.Equals("MM/YY"))
            {
                txtExpDate.Text = "";
                txtExpDate.ForeColor = Color.Black;
            }
        }

        private void txtExpDate_Leave(object sender, EventArgs e)
        {
            if (txtExpDate.Text.Equals(""))
            {
                txtExpDate.Text = "MM/YY";
                txtExpDate.ForeColor = Color.Silver;
            }
        }

        private void txtSecurityCode_Enter(object sender, EventArgs e)
        {
            if (txtSecurityCode.Text.Equals("000"))
            {
                txtSecurityCode.Text = "";
                txtSecurityCode.ForeColor = Color.Black;
            }
        }

        private void txtSecurityCode_Leave(object sender, EventArgs e)
        {
            if (txtSecurityCode.Text.Equals(""))
            {
                txtSecurityCode.Text = "000";
                txtSecurityCode.ForeColor = Color.Silver;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {  
            if (senderForm.Equals("Snack"))
            {
                MessageBox.Show("Transaction Complete! Enjoy your snacks!");
                CinemaMenu cm = (CinemaMenu)Owner;
                cm.Buy();
            }
            else
            {
                ticket = MovieView.movieTitle + "," + MovieView.movieRoom + "," + MovieView.movieTime;
                SeatSelect ss = (SeatSelect)Owner;
                ss.addSeats();
                MessageBox.Show("Transaction Complete! Here is your ticket! Enjoy your movie!");
                Application.OpenForms.OfType<MainHall>().ToList()[0].LoadMovie();
            }
            Application.OpenForms.OfType<MainHall>().ToList()[0].Show();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();
        }
    }
}
