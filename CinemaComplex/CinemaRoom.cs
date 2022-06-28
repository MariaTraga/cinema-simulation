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
    public partial class CinemaRoom : Form
    {
        public CinemaRoom()
        {
            InitializeComponent();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();
        }

        private void CinemaRoom_Load(object sender, EventArgs e)
        {
            Application.OpenForms.OfType<MainHall>().First().StopMusic();
            LoadMovie();
        }

        private void LoadMovie()
        {
            String movieTitle = MovieView.movieTitle;
            txtMovie.Text = movieTitle;
            txtSeats.Text = String.Join(", ", MovieView.selectedMovie.seatsTicket);
            switch (movieTitle)
            {
                case "The Godfather":
                    pbScreen.Image = Properties.Resources.godfather;        
                    break;
                case "Pulp Fiction":
                    pbScreen.Image = Properties.Resources.pulp_fiction;
                    break;
                case "Joker":
                    pbScreen.Image = Properties.Resources.joker;
                    break;
                case "One Flew Over the Cuckoo's Nest":
                    pbScreen.Image = Properties.Resources.cuckoos;
                    break;
            }
        }

        private void CinemaRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
