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
    public partial class ControlPanel : Form
    {
        String[] MovieState;
        bool[] MovieLights;
        RoomClean[] roomClean = new RoomClean[] {new RoomClean(1), new RoomClean(2), new RoomClean(3) };
        public ControlPanel()
        {
            InitializeComponent();
        }
        private void ControlPanel_Load(object sender, EventArgs e)
        {
            MovieState = new string[] {"Playing", "Playing", "Stopped" };
            MovieLights = new bool[] {false, false, true};
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            GroupBox gb = (GroupBox)s.Parent.Parent.Parent;
            PictureBox p = gb.Controls.OfType<PictureBox>().Where(x => (String)x.Tag== $"{s.Tag}1").ToList()[0];
            int index = int.Parse(s.Tag.ToString()) - 1;
            switch(MovieState[index])
            {
                case "Playing":
                    MovieState[index] = "Paused";
                    s.Image = Properties.Resources.cr_play;
                    p.Enabled = false;
                    break;
                default:
                    p.Visible = true;
                    MovieState[index] = "Playing";
                    s.Image = Properties.Resources.cr_pause;
                    p.Enabled = true;
                    break;
            }
            s.Parent.Parent.Controls.OfType<Label>().Where(x => x.Name == $"txt_status{index + 1}").ToList()[0].Text = $"Movie {MovieState[index]}...";
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            StopMovie(sender);
        }

        private void StopMovie(object sender)
        {
            Button s = (Button)sender;
            GroupBox gb = (GroupBox)s.Parent.Parent.Parent;
            PictureBox p = gb.Controls.OfType<PictureBox>().Where(x => (String)x.Tag == $"{s.Tag}1").ToList()[0];
            int index = int.Parse(s.Tag.ToString()) - 1;
            MovieState[index] = "Stopped";
            s.Parent.Parent.Controls.OfType<Label>().Where(x => x.Name == $"txt_status{index + 1}").ToList()[0].Text = "Movie Stopped...";
            s.Parent.Controls.OfType<Button>().Where(x => x.Name == $"btn_play{index + 1}").ToList()[0].Image = Properties.Resources.cr_play;
            p.Visible = false;
        }

        private void btn_MovieLights_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            GroupBox gb = (GroupBox)s.Parent.Parent;
            PictureBox p = gb.Controls.OfType<PictureBox>().Where(x => (String)x.Tag == $"{s.Tag}2").ToList()[0];
            int index = int.Parse(s.Tag.ToString()) - 1;
            switch (MovieLights[index])
            {
                case true:
                    MovieLights[index] = false;
                    s.Image = Properties.Resources.cr_switch_off;
                    p.Image = Properties.Resources.room_dark;
                    break;
                default:
                    MovieLights[index] = true;
                    s.Image = Properties.Resources.cr_switch_on;
                    p.Image = Properties.Resources.room_light;
                    break;
            }
        }

        private void btn_changemovie_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            StopMovie(s);
            GroupBox gb = (GroupBox)s.Parent.Parent.Parent;
            PictureBox p = gb.Controls.OfType<PictureBox>().Where(x => (String)x.Tag == $"{s.Tag}1").ToList()[0];
            contextMenuStrip1.Show(p, s.Location);
        }

        Image[] movieList = new Image[] { Properties.Resources.godfather, Properties.Resources.pulp_fiction, Properties.Resources.joker, Properties.Resources.cuckoos };

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)contextMenuStrip1.SourceControl;
            p.Image = movieList[contextMenuStrip1.Items.IndexOf((ToolStripItem)sender)];
            Panel pnl = p.Parent.Controls.OfType<Panel>().Where(x => x.Name == $"pnl_movie{p.Parent.Tag}").ToList()[0];
            pnl.Controls.OfType<Label>().Where(x => x.Name == $"txt_status{p.Parent.Tag}").ToList()[0].Text = "Movie Changed...";
        }

        private void btn_mStop_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Button target = button.Parent.Controls.OfType<Button>().Where(x => x.Name == $"btn_mplay{button.Tag}").ToList()[0];
            if ((string)target.Tag == "playing")
            {
                target.Image = Properties.Resources.cr_play;
                target.Tag = "stopped";
            }
        }

        private void btn_mplay_Click(object sender, EventArgs e)
        {
            Button target = (Button)sender;
            if ((string)target.Tag == "playing")
            {
                target.Image = Properties.Resources.cr_play;
                target.Tag = "stopped";
            }
            else
            {
                target.Image = Properties.Resources.cr_pause;
                target.Tag = "playing";
            }
        }

        private void btn_changesong_click(object sender, EventArgs e)
        {
            contextMenuStrip2.Show(MousePosition);
        }

        bool[] lighting = new bool[] { true, true };
        Image[] LghtsOn = new Image[] { Properties.Resources.entrance_light, Properties.Resources.main_hall };
        Image[] LghtsOff = new Image[] { Properties.Resources.entrance_dark, Properties.Resources.main_hall_dark};
        private void btn_Lights_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse((string)button.Tag)-1;
            PictureBox picture = button.Parent.Parent.Controls.OfType<PictureBox>().Where(x => x.Name == $"pct_hall{index+1}").First();
            if (lighting[index])
            {
                lighting[index] = false;
                picture.Image = LghtsOff[index];
                button.Image = Properties.Resources.cr_switch_off;
            }
            else
            {
                lighting[index] = true;
                picture.Image = LghtsOn[index];
                button.Image = Properties.Resources.cr_switch_on;
            }
        }

        private void btn_roomba_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = int.Parse((string)button.Tag) - 1;
            roomClean[index].Show(this);
            roomClean[index].Text = $"Room {index + 1} - Roomba";
            this.Hide();
        }

        private void btn_valTickets_Click(object sender, EventArgs e)
        {
            ValidateTicket validateTicket = new ValidateTicket();
            validateTicket.Show(this);
            this.Hide();
        }

        private void ControlPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();
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
            play("Welcome to the control panel.");

            // LIGHTS
            Button[] btn_lights = new Button[] { btn_lights1, btn_lights2, btn_lights3, btn_lights4, btn_lights5 };
            foreach (Button button in btn_lights)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.White; }));
            }
            play("Firstly you can switch off the light of each room by clicking on the Lights button.");
            foreach (Button button in btn_lights)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.FromArgb(34, 34, 34); }));
            }

            // MUSIC CONTROLS
            List<Button> btn_music = new List<Button>();

            foreach (Button button in musicControls1.Controls.OfType<Button>())
            {
                btn_music.Add(button);
            }
            foreach (Button button in musicControls2.Controls.OfType<Button>())
            {
                btn_music.Add(button);
            }

            foreach (Button button in btn_music)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.White; }));
            }
            play("In the Entrance and Main Hall rooms you can change, stop or start and pause the music playing.");
            foreach (Button button in btn_music)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.FromArgb(34, 34, 34); }));
            }

            // MOVIE CONTROLS
            List<Button> btn_movie = new List<Button>();
            foreach (Button button in movieControls1.Controls.OfType<Button>())
            {
                btn_movie.Add(button);
            }
            foreach (Button button in movieControls2.Controls.OfType<Button>())
            {
                btn_movie.Add(button);
            }
            foreach (Button button in movieControls3.Controls.OfType<Button>())
            {
                btn_movie.Add(button);
            }

            foreach (Button button in btn_movie)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.White; }));
            }
            play("In the Cinema Halls you can change,stop or start and pause the movie playing.");
            foreach (Button button in btn_movie)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.FromArgb(34, 34, 34); }));
            }

            // ROOMBA
            Button[] btn_roomba = new Button[] { roomba1, roomba2, roomba3 };
            foreach (Button button in btn_roomba)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.White; }));
            }
            play("You can also access the robot controls by clicking on the Roomba button.");
            foreach (Button button in btn_roomba)
            {
                button.Invoke(new Action(() => { button.BackColor = Color.FromArgb(34, 34, 34); }));
            }

            // ORDERS AND TICKETS
            btn_valTickets.Invoke(new Action(() => { btn_valTickets.BackColor = Color.White; }));
            play("You can click on the Orders and Tickets button to proceed with the validation services.");
            btn_valTickets.Invoke(new Action(() => { btn_valTickets.BackColor = Color.FromArgb(34, 34, 34); }));

            // BACK
            btn_exit.Invoke(new Action(() => { btn_exit.BackColor = Color.White; }));
            play("Lastly you can click on the Back button to move to the previous form.");
            btn_exit.Invoke(new Action(() => { btn_exit.BackColor = Color.FromArgb(34, 34, 34); }));

        }

        private void play(String txt_to_speech)
        {
            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(txt_to_speech);
            speechSynthesizer.Dispose();
        }

        private void pct_help_Click(object sender, EventArgs e)
        {
            help();
        }
    }
}
