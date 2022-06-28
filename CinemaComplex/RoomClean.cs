using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaComplex
{

    public partial class RoomClean : Form
    {
        int room;
        public static List<int> randValSeats = createRandomValSeats();
        public static List<int> randDirtySeats = createRandomDirtySeats();
        List<String> valuables = new List<String> { "id_card", "jewelery", "keys", "money", "wallet", "watch" };
        List<int> valX = new List<int>();
        List<int> valY = new List<int>();
        List<int> dirtyX = new List<int>();
        List<int> dirtyY = new List<int>();
        public static int breakX, breakY, valCount, dirtyCount;
        int currentCountVal, currentCountDirty = 0;
        int idcard, wallet, watch, jewelery, money, keys = 0;
        int movement = 2;
        PictureBox pbroom;

        public RoomClean(int newRoom)
        {
            InitializeComponent();
            room = newRoom;
        }
        public RoomClean()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createRandomStop();
            valuablesSeatsLocations();
            dirtySeatsLocations();
            btn_Restart.Enabled = false;
            lblRoom.Text = room.ToString();
        }


        private void moveRoomba()
        {
            if (picRoomba.Location.X >= 1243 && picRoomba.Location.Y >= 550)
            {
                timer1.Stop();
                PlaySound(false);
                MessageBox.Show("The roomba has finished cleaning and found the following:\n\nValuables: " + valCount + "\nDirty Seats: " + dirtyCount +
                    "\n\nThe users that lost valuable items will be informed by email.\nThe users that used the dirty seats will be informed the next time they enter the cinema.");
            }
            else if (picRoomba.Location.X >= breakX && picRoomba.Location.Y >= breakY && movement == 2)
            {
                timer1.Stop();
                picRoomba.BackgroundImage = Properties.Resources.roomba_error;
                picRoomba.Cursor = Cursors.Hand;
                btn_Restart.Enabled = false;
                btn_StopStart.Enabled = false;
                PlaySound(true);
                MessageBox.Show("The roomba has encountered a problem and can not continue.\nClick on the roomba to help it.");
            }
            else if (picRoomba.Location.X <= breakX && picRoomba.Location.Y >= breakY && movement == -2)
            {
                timer1.Stop();
                picRoomba.BackgroundImage = Properties.Resources.roomba_error;
                picRoomba.Cursor = Cursors.Hand;
                btn_Restart.Enabled = false;
                btn_StopStart.Enabled = false;
                PlaySound(true);
                MessageBox.Show("The roomba has encountered a problem and can not continue.\nClick on the roomba to help it.");
            }
            else if (picRoomba.Location.X >= 1243 && movement == 2)
            {
                picRoomba.Location = new Point(picRoomba.Location.X, picRoomba.Location.Y + 63);
                movement = -2;
            }
            else if (picRoomba.Location.X <= 10 && movement == -2)
            {
                picRoomba.Location = new Point(picRoomba.Location.X, picRoomba.Location.Y + 63);
                movement = 2;
            }
            else
            {
                checkRoombaValuables();
                checkRoombaDirty();
                picRoomba.Location = new Point(picRoomba.Location.X + movement, picRoomba.Location.Y);
            }
        }

        private static List<int> createRandomValSeats()
        {
            Random rand = new Random();
            List<int> randValSeats = new List<int>();
            int count = rand.Next(15, 30);
            int numb;

            while (!(count == 0))
            {
                numb = rand.Next(1, 213);
                if (!randValSeats.Contains(numb))
                {
                    randValSeats.Add(numb);
                    count--;
                }
            }
            randValSeats.Sort();
            valCount = randValSeats.Count();

            return randValSeats;
        }



        private void valuablesSeatsLocations()
        {

            foreach (int i in randValSeats)
            {
                foreach (PictureBox p in panel1.Controls.OfType<PictureBox>())
                {
                    if (int.Parse((string)p.Tag).Equals(i))
                    {
                        valX.Add(p.Location.X);
                        valY.Add(p.Location.Y);
                    }
                }
            }
        }



        private void checkRoombaValuables()
        {
            PictureBox pb;
            if (currentCountVal < valCount)
            {
                if (movement == 2)
                {
                    if (picRoomba.Location.X >= valX[currentCountVal] && picRoomba.Location.Y >= valY[currentCountVal] + 29)
                    {
                        pb = panel1.Controls.OfType<PictureBox>().Where(x => x.Tag.Equals(randValSeats[currentCountVal].ToString())).ToList()[0];
                        changePBValuables(pb);
                    }
                }
                else
                {
                    if (picRoomba.Location.X <= valX[currentCountVal] && picRoomba.Location.Y >= valY[currentCountVal] + 29)
                    {
                        pb = panel1.Controls.OfType<PictureBox>().Where(x => x.Tag.Equals(randValSeats[currentCountVal].ToString())).ToList()[0];
                        changePBValuables(pb);
                    }
                }
            }
        }

        private void changePBValuables(PictureBox p)
        {
            Random rand = new Random();
            int index = rand.Next(valuables.Count);
            String imgname = valuables[index];
            var image = (Bitmap)Properties.Resources.ResourceManager.GetObject(imgname);

            switch (imgname)
            {
                case "id card":
                    idcard++;
                    lblIdCard.Text = "x" + idcard;
                    break;
                case "wallet":
                    wallet++;
                    lblWallet.Text = "x" + wallet;
                    break;
                case "jewelery":
                    jewelery++;
                    lblJewelery.Text = "x" + jewelery;
                    break;
                case "watch":
                    watch++;
                    lblWatch.Text = "x" + watch;
                    break;
                case "keys":
                    keys++;
                    lblKeys.Text = "x" + keys;
                    break;
                case "money":
                    money++;
                    lblMoney.Text = "x" + money;
                    break;
            }

            p.BackColor = Color.Gold;
            p.Image = image;
            currentCountVal++;
        }

        private static List<int> createRandomDirtySeats()
        {
            Random rand = new Random();
            List<int> randDirtySeats = new List<int>();
            int count = rand.Next(20, 30);
            int numb;

            while (!(count == 0))
            {
                numb = rand.Next(1, 213);
                if (!randDirtySeats.Contains(numb) && !randValSeats.Contains(numb))
                {
                    randDirtySeats.Add(numb);
                    count--;
                }
            }
            randDirtySeats.Sort();
            dirtyCount = randDirtySeats.Count();

            return randDirtySeats;
        }

        private void dirtySeatsLocations()
        {

            foreach (int i in randDirtySeats)
            {
                foreach (PictureBox p in panel1.Controls.OfType<PictureBox>())
                {
                    if (int.Parse(p.Tag.ToString()).Equals(i))
                    {
                        dirtyX.Add(p.Location.X);
                        dirtyY.Add(p.Location.Y);
                    }
                }
            }
        }

        private void checkRoombaDirty()
        {
            PictureBox p;
            if (currentCountDirty < dirtyCount)
            {
                if (movement == 2)
                {
                    if (picRoomba.Location.X >= dirtyX[currentCountDirty] && picRoomba.Location.Y >= dirtyY[currentCountDirty] + 29)
                    {
                        p = panel1.Controls.OfType<PictureBox>().Where(x => x.Tag.Equals(randDirtySeats[currentCountDirty].ToString())).ToList()[0];
                        p.BackColor = Color.Red;
                        cleanAnimation();
                        currentCountDirty++;
                    }
                }
                else
                {
                    if (picRoomba.Location.X <= dirtyX[currentCountDirty] && picRoomba.Location.Y >= dirtyY[currentCountDirty] + 29)
                    {
                        p = panel1.Controls.OfType<PictureBox>().Where(x => x.Tag.Equals(randDirtySeats[currentCountDirty].ToString())).ToList()[0];
                        p.BackColor = Color.Red;
                        cleanAnimation();

                        currentCountDirty++;
                    }
                }

                lblDirtySeats.Text = currentCountDirty.ToString();

            }

        }

        private async Task cleanAnimation()
        {
            pbroom = new PictureBox();
            pbroom.Location = new Point(picRoomba.Right, picRoomba.Top);
            pbroom.Image = Properties.Resources.broom_clean;
            pbroom.Size = new Size(25, 25);
            pbroom.SizeMode = PictureBoxSizeMode.StretchImage;
            panel1.Controls.Add(pbroom);
            btn_StopStart.Enabled = false;
            btn_Restart.Enabled = false;
            timer1.Stop();
            await Task.Delay(1000);
            timer1.Start();
            btn_StopStart.Enabled = true;
            btn_Restart.Enabled = true;
            pbroom.Dispose();
        }

        public void createRandomStop()
        {
            Random rand = new Random();
            breakX = rand.Next(10, 1243);
            breakY = rand.Next(50, 550);
        }

        private void picRoomba_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                breakX = 1300;
                breakY = 600;
                picRoomba.BackgroundImage = Properties.Resources.roomba;
                picRoomba.Cursor = Cursors.Arrow;
                btn_Restart.Enabled = true;
                btn_StopStart.Enabled = true;
                timer1.Start();
            }
        }

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            if(btn_StopStart.Text.Equals("Resume"))
            {
                btn_StopStart.Text = "Stop";
                btn_StopStart.BackColor = Color.Red;
                btn_StopStart.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("roomba_pause");
            }
            picRoomba.Location = new Point(42, 52);
            movement = 2;
            moveRoomba();
            timer1.Start();
        }

        private void btn_StopStart_Click(object sender, EventArgs e)
        {
            btn_Restart.Enabled = true;
            if (timer1.Enabled)
            {
                timer1.Stop();
                btn_StopStart.Text = "Resume";
                btn_StopStart.BackColor = Color.Green;
                btn_StopStart.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("roomba_play");
            }
            else
            {
                timer1.Start();
                btn_StopStart.Text = "Stop";
                btn_StopStart.BackColor = Color.Red;
                btn_StopStart.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("roomba_pause");
            }
        }

        private void RoomClean_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveRoomba();
        }
        private void PlaySound(bool error)
        {
            using (Stream ms = new MemoryStream())
            {
                Stream stream;
                if (error)
                {
                    stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CinemaComplex.Resources.cleaningError.mp3");
                }
                else
                {
                    stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CinemaComplex.Resources.cleaningComplete.mp3");
                }
                using (stream)
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
                        waveOut.Volume = 0.3f;
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(160);
                        }
                    }
                }
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
            play("Welcome to the roomba cleaning panel.");
            btn_StopStart.Invoke(new Action(() => { btn_StopStart.BackColor = Color.Blue; }));
            play("Here you can start or stop the robot in place by clicking on the Start or Stop button.");
            btn_StopStart.Invoke(new Action(() => { btn_StopStart.BackColor = Color.Green; }));
            btn_Restart.Invoke(new Action(() => { btn_Restart.BackColor = Color.Blue; }));
            play("In order to restart the cleaning process you can click on the Restart button.");
            btn_Restart.Invoke(new Action(() => { btn_Restart.BackColor = Color.DarkOrange; }));
            btn_exit.Invoke(new Action(() => { btn_exit.BackColor = Color.Blue; }));
            play("Lastly click on the Back button to move to the previous form.");
            btn_exit.Invoke(new Action(() => { btn_exit.BackColor = Color.Transparent; }));
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
    }
}
