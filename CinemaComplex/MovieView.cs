using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace CinemaComplex
{
    public partial class MovieView : Form
    {
        DataTable dt = new DataTable();
        public static String movieTitle, movieRoom, movieTime;
        public static SeatSelect selectedMovie;
        public static List<SeatSelect> ss = new List<SeatSelect>();

        public MovieView()
        {
            InitializeComponent();
        }

        private void MovieView_Load(object sender, EventArgs e)
        {
            ReadCSV();
        }

        private void ReadCSV()
        {
            using (TextFieldParser tfp = new TextFieldParser("movie schedule.csv"))
            {
                tfp.SetDelimiters(",");
                bool firstline = true;

                while (!tfp.EndOfData)
                {
                    string[] movieData = tfp.ReadFields();
                    if (firstline)
                    {
                        foreach (var header in movieData)
                        {
                            dt.Columns.Add(header);
                        }

                        firstline = false;
                        continue;
                    }

                    dt.Rows.Add(movieData);
                    String movieEntry = $"{dt.Rows[dt.Rows.Count - 1].ItemArray[1]} - {dt.Rows[dt.Rows.Count - 1].ItemArray[6]} - {dt.Rows[dt.Rows.Count - 1].ItemArray[7]}";

                    cmb_movies.Items.Add(movieEntry);
                    ss.Add(new SeatSelect());
                }
            }
        }

        private void ChangeMovie()
        {
            txtTitle.Text = dt.Rows[cmb_movies.SelectedIndex]["title"].ToString();
            txtActor.Text = dt.Rows[cmb_movies.SelectedIndex]["leading actor"].ToString();
            txtDirector.Text = dt.Rows[cmb_movies.SelectedIndex]["director"].ToString();
            txtDate.Text = dt.Rows[cmb_movies.SelectedIndex]["date"].ToString();
            txtTime.Text = dt.Rows[cmb_movies.SelectedIndex]["watchtime"].ToString();
            txtSTime.Text = dt.Rows[cmb_movies.SelectedIndex]["screening time"].ToString();
            txtRoom.Text = dt.Rows[cmb_movies.SelectedIndex]["screening room"].ToString();
        }            

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_movies.SelectedIndex.Equals(-1))
            {
                return;
            }
            ChangeMovie();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox button = (PictureBox)sender;
            MainHall mh = Application.OpenForms.OfType<MainHall>().First();
            if (mh.waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
            {
                button.Image = Properties.Resources.icons8_no_audio_80px;
                mh.waveOut.Pause();
            }
            else
            {
                button.Image = Properties.Resources.icons8_sound_80px;
                mh.PlayMusic();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmb_movies.SelectedIndex.Equals(-1))
            {
                MessageBox.Show("Please select a movie in order to continue.");
                return;
            }
            MessageBox.Show("Please select your seats in the following screen.");
            movieTitle = txtTitle.Text;
            movieRoom = txtRoom.Text;
            movieTime = txtSTime.Text;
            selectedMovie = ss[cmb_movies.SelectedIndex];
            selectedMovie.Show(this.Owner);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Hide();
        }

        SpeechSynthesizer speechSynthesizer;

        private class async_lock
        {
            public static bool flag = true;
        }

        private async void help()
        {
            if (async_lock.flag)
            {
                pct_audio.Image = Properties.Resources.icons8_no_audio_80px;
                Application.OpenForms.OfType<MainHall>().First().waveOut.Pause();
                async_lock.flag = false;
            }
            else
            {
                return;
            }
            await Task.Run(new Action(() => { playIntro(); }));
            async_lock.flag = true;
        }

        private async Task playIntro()
        {
            cmb_movies.Invoke(new Action(() => { cmb_movies.BackColor = Color.White; }));
            play("By clicking on the movie you would like to watch you will be presented with some information.");
            panel1.Invoke(new Action(() => { 
                cmb_movies.BackColor = Color.FromArgb(45, 45, 48);
                btnOk.BackColor = Color.Blue;
                btnCancel.BackColor = Color.Blue;
            }));
            play("Click on the Next button to proceed to the seat selection form or click the Cancel button if you want to stop the purchase process.");
            panel1.Invoke(new Action(() => {
                btnOk.BackColor = Color.Transparent;
                btnCancel.BackColor = Color.Transparent;
            }));
        }

        private void MovieView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pct_help_Click_1(object sender, EventArgs e)
        {
            help();
        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }
    }
}
