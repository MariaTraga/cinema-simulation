using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{
    public partial class MainHall : Form
    {
        TimeSpan ETA;
        DateTime movieTime;
        public WaveOut waveOut;
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        public MainHall()
        {
            InitializeComponent();
        }

        private void main_hall_Load(object sender, EventArgs e)
        {
            PlayMusic();   
        }

        private class async_lock
        {
            public static bool flag = true;
        }

        public async Task PlayMusic()
        {
            pct_speakerL.Enabled = true;
            pct_speakerR.Enabled = true;
            await Task.Run(new Action(() => { PlayMp3(); }));
        }

        public void PlayMp3()
        {
            using (Stream ms = new MemoryStream())
            {
                
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CinemaComplex.song.mp3"))
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Volume = 0.2f;
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(160);
                        }
                    }
                }
                try
                {
                    pct_speakerL.Invoke(new Action(() => { pct_speakerL.Enabled = false; }));
                    pct_speakerR.Invoke(new Action(() => { pct_speakerR.Enabled = false; }));
                }
                catch (Exception) { }
            }
        }

        public void pct_speaker_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState.Equals(PlaybackState.Playing)){
                pct_speakerL.Enabled = false;
                pct_speakerR.Enabled = false;
                waveOut.Pause();
            }
            else
            {
                Task.Run(new Action(() => { PlayMp3(); }));
                pct_speakerL.Enabled = true;
                pct_speakerR.Enabled = true;
            }
        }

        public void StopMusic()
        {
            waveOut.Pause();
        }

        private void pct_switch_Click(object sender, EventArgs e)
        {
            if (pct_switch.Tag.Equals("on"))
            {
                btn_BuySnacks.ForeColor = Color.White;
                btn_BuyTickets.ForeColor = Color.White;
                btn_MovieRoom.ForeColor = Color.White;
                this.BackgroundImage = Properties.Resources.main_hall_dark;
                pct_switch.Image = Properties.Resources.icons8_switch_off_128px;
                pct_switch.Tag = "off";
            }
            else
            {
                btn_BuySnacks.ForeColor = Color.Blue;
                btn_BuyTickets.ForeColor = Color.Blue;
                btn_MovieRoom.ForeColor = Color.Blue;
                this.BackgroundImage = Properties.Resources.main_hall;
                pct_switch.Image = Properties.Resources.icons8_switch_on_128px;
                pct_switch.Tag = "on";
            }
        }

        private void btn_BuyTickets_MouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.BorderSize = 0;
        }

        private void btn_BuyTickets_MouseEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.FlatAppearance.BorderSize = 2;
        }

        private void btn_BuyTickets_Click(object sender, EventArgs e)
        {
            new MovieView().Show(this);
            this.Hide();
        }

        private void btn_BuySnacks_Click(object sender, EventArgs e)
        {
            new CinemaMenu().Show(this);
            this.Hide();
        }

        private void btn_MovieRoom_Click(object sender, EventArgs e)
        {
            if (MovieView.movieTitle?.Length.Equals(0) ??true)
            {
                PlaySound();
                MessageBox.Show("Please purchase a ticket in order to watch a movie.");
                return;
            }
            CinemaRoom room = new CinemaRoom();
            room.Text = $"Room {txt_Room.Text}";
            room.Show(this);
            this.Hide();
        }

        public void ChangeFoodBeverage(int popcorn, int nachos, int coke, int water)
        {
            txt_Corn.Text = $"x {popcorn}";
            txt_Nachos.Text = $"x {nachos}";
            txt_Coke.Text = $"x {coke}";
            txt_Water.Text = $"x {water}";
        }

        public void LoadMovie()
        {
            txt_Movie.Text = MovieView.movieTitle.ToString();
            txt_Room.Text = MovieView.movieRoom.ToString();
            movieTime = DateTime.Parse(MovieView.movieTime);
            var dateCompare = DateTime.Compare(movieTime, DateTime.Now).ToString();
            if (!dateCompare.Equals(1))
            {
                movieTime = movieTime.AddDays(1);
            }

            ETA = movieTime.Subtract(DateTime.Now);

            txt_ETA.Text = $"{ETA.Hours}:{ETA.Minutes}:{ETA.Seconds}";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ETA = movieTime.Subtract(DateTime.Now);
            if (ETA.Hours.Equals(0) && ETA.Minutes.Equals(0) && ETA.Seconds.Equals(0))
            {
                txt_ETA.ForeColor = Color.Red;
                timer1.Stop();
                MessageBox.Show("Attention! Your Movie is starting!");
            }
            txt_ETA.Text = $"{ETA.Hours}:{ETA.Minutes}:{ETA.Seconds}";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application was created by:\nDimitris Malliaris & Maria Traga");
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState.Equals(PlaybackState.Playing))
            {
                pct_speakerL.Enabled = false;
                pct_speakerR.Enabled = false;
                waveOut.Pause();
            }
            if(speechSynthesizer.State == SynthesizerState.Speaking)
            {
                speechSynthesizer.Pause();
                async_lock.flag = true;
            }
            else
            {
                playHelp();
            }
        }

        private async void playHelp()
        {
            if (async_lock.flag)
            {
                async_lock.flag = false;
            }
            else
            {
                return;
            }
            await Task.Run(new Action(() => { help(); }));
            async_lock.flag = true;
        }

        private async Task help()
        {
            speechSynthesizer = new SpeechSynthesizer();
            panel3.Invoke(new Action(() => { panel3.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("On the top left of the screen you can see info about your movie and the snacks you have bought");
            panel3.Invoke(new Action(() => { panel3.BackColor = Color.Black; }));
            pct_JukeBox.Invoke(new Action(() => { pct_JukeBox.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("You can click on the jukebox to start or pause the music");
            pct_JukeBox.Invoke(new Action(() => { pct_JukeBox.BackColor = Color.Transparent; }));
            btn_BuySnacks.Invoke(new Action(() => { btn_BuySnacks.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("Click on the Snacks icon to buy snacks and beverages for your movie.");
            btn_BuySnacks.Invoke(new Action(() => { btn_BuySnacks.BackColor = Color.Transparent; }));
            btn_BuyTickets.Invoke(new Action(() => { btn_BuyTickets.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("Click on the Tickets icon to buy your movie tickets.");
            btn_BuyTickets.Invoke(new Action(() => { btn_BuyTickets.BackColor = Color.Transparent; }));
            btn_MovieRoom.Invoke(new Action(() => { btn_MovieRoom.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("Lastly click on the Movie icon to move to the movie halls.");
            btn_MovieRoom.Invoke(new Action(() => { btn_MovieRoom.BackColor = Color.Transparent; }));
            button1.Invoke(new Action(() => { button1.BackColor = Color.DarkSlateGray; }));
            speechSynthesizer.Speak("You can exit by pressing the back button");
            button1.Invoke(new Action(() => { button1.BackColor = Color.Transparent; }));
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Owner.Show();
            waveOut.Dispose();
            this.Dispose();
        }

        public void PlaySound()
        {
            using (Stream ms = new MemoryStream())
            {

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CinemaComplex.Resources.bloop.mp3"))
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(160);
                        }
                    }
                }
            }
        }

        private void MainHall_FormClosed(object sender, FormClosedEventArgs e)
        {
            waveOut.Dispose();
            Application.Exit();
        }
    }
}
