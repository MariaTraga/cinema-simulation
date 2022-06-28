using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{
    public partial class SelectUserForm : Form
    {
        public SelectUserForm()
        {
            InitializeComponent();
        }

        private void btn_enterCustomer_Click(object sender, EventArgs e)
        {
            MainHall mainHall = new MainHall();
            mainHall.Show(this);
            this.Hide();
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();
            cp.Show(this);
            this.Hide();
        }

        private void SelectUserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
