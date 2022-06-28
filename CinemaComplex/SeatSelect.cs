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

namespace CinemaComplex
{
    
    public partial class SeatSelect : Form
    {
        public List<int> seatList = new List<int>();
        public List<String> seatsTicket = new List<string>();
        public List<int> randSeats = randomSeats();

        public SeatSelect()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox p in panel1.Controls.OfType<PictureBox>())
            {
                String seatNUM;
                int seatCount = int.Parse(p.Tag.ToString());
                if (seatCount < 26)
                {
                    seatNUM = $"A{seatCount}";
                }
                else if(seatCount < 51)
                {
                    seatNUM = $"B{seatCount - 25}";
                }
                else if (seatCount < 76)
                {
                    seatNUM = $"C{seatCount - 50}";
                }
                else if (seatCount < 101)
                {
                    seatNUM = $"D{seatCount - 75}";
                }
                else if (seatCount < 126)
                {
                    seatNUM = $"E{seatCount - 100}";
                }
                else if (seatCount < 149)
                {
                    seatNUM = $"G{seatCount - 125}";
                }
                else if (seatCount < 172)
                {
                    seatNUM = $"H{seatCount - 148}";
                }
                else if (seatCount < 193)
                {
                    seatNUM = $"H{seatCount - 171}";
                }
                else
                {
                    seatNUM = $"I{seatCount - 192}";
                }
                toolTip1.SetToolTip(p, seatNUM);
            }
            takenSeats();
        }

        private void picSeat_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            if(pb.BackColor == Color.Chartreuse)
            {
                pb.BackColor = Color.Blue;
                seatList.Add(int.Parse(pb.Tag.ToString()));
            }
            else if(pb.BackColor == Color.Blue)
            {
                pb.BackColor = Color.Chartreuse;
                seatList.Remove(int.Parse(pb.Tag.ToString()));
            }
            else
            {
                pb.Cursor = Cursors.Default;
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (seatList.Count().Equals(0))
                {
                    throw new Exception();
                }
                MessageBox.Show("The price for the ticket(s) selected will be " + 10*seatList.Count() + "€.\n" +
                        "Please add your card information to proceed with the transaction.");
                new CreditCard("Ticket").Show(this);
                this.Hide();
            }
            catch(Exception)
            {
                MessageBox.Show("Please select the amount of seats you would like and then click 'OK'.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            seatList.Clear();
            this.Owner.Show();
            this.Hide();
        }

        private static List<int> randomSeats()
        {
            Random rand = new Random();
            List<int> randSeats = new List<int>();
            int count = rand.Next(10, 80);
            int numb;

            while (!(count == 0))
            {
                numb = rand.Next(1, 213);
                if (!randSeats.Contains(numb))
                {
                    randSeats.Add(numb);
                    count--;
                }
            }

            return randSeats;
        }

        private void takenSeats()
        {
            foreach(int i in randSeats)
            {
                foreach(PictureBox p in panel1.Controls.OfType<PictureBox>())
                {
                    if (int.Parse(p.Tag.ToString()).Equals(i))
                    {
                        p.BackColor = Color.Orange;
                        p.Cursor = Cursors.Default;
                    }
                }
            }
        }

        public void addSeats()
        {
            foreach(PictureBox p in panel1.Controls.OfType<PictureBox>())
            {
                if (seatList.Contains(int.Parse(p.Tag.ToString())))
                {
                    seatsTicket.Add(toolTip1.GetToolTip(p));
                    p.BackColor = Color.Purple;
                    p.Cursor = Cursors.Default;
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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
            play("In order to select a seat for your movie, please click on one of the green available seats presented on the form.");
            btnOk.Invoke(new Action(() =>
            {
                btnOk.BackColor = Color.Blue;
            }));
            play("Click on the Purchase button to move to the next step where you will be asked for your credit card information.");
            btnOk.Invoke(new Action(() => 
            { 
                btnOk.BackColor = Color.DarkSlateGray;
                btn_cancel.BackColor = Color.Blue;
            }));
            play("Lastly, if you want to stop the purchase process, click on the Cancel button.");
            btn_cancel.Invoke(new Action(() =>
            {
                btn_cancel.BackColor = Color.DarkSlateGray;
            }));
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            help();
        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }

        private void SeatSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
