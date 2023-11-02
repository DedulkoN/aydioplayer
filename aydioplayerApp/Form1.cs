using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Threading;

namespace aydioplayerApp
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            // список взят отсуда https://forum.mcmp.su/topic/3812/

            comboBox1.Items.Clear();
            comboBox1.Items.Add("http://ep256.streamr.ru");
            comboBox1.Items.Add("http://stream.nonstopplay.co.uk/nsp-128k-mp3");
            comboBox1.Items.Add("http://ice-the.musicradio.com/CapitalXTRANationalMP3");
            comboBox1.Items.Add("http://dorognoe.hostingradio.ru:8000/dorognoe");
            comboBox1.Items.Add("http://listen.rpfm.ru:9000/premium128");
            comboBox1.Items.Add("http://listen.myradio24.com:9000/8020");
            comboBox1.Items.Add("http://pool.anison.fm:9000/AniSonFM(320)");
            comboBox1.Items.Add("http://radio.soullive.ru:8000/livedj");
            comboBox1.Items.Add("http://stream.srg-ssr.ch/m/rsc_de/mp3_128");
            comboBox1.Items.Add("http://galnet.ru:8000/soft");
            comboBox1.Items.Add("http://galnet.ru:8000/hard");
            comboBox1.Items.Add("http://airtime.joyradio.cc:8000/airtime_192.mp3");
            comboBox1.Items.Add("http://play.russianradio.eu/stream");
            comboBox1.Items.Add("http://nashe1.hostingradio.ru/nashe-128.mp3");
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WMP.controls.stop();
            WMP.settings.volume = 100;
            WMP.URL = comboBox1.Text;
            WMP.controls.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WMP.controls.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {              
                IWMPPlaylist playlist;

                    playlist = WMP.playlistCollection.newPlaylist("myplaylist");

                IWMPMedia media;
                WMP.controls.stop();

                string[] fullfilesPath = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.mp3");

                for (int i = 0; i < fullfilesPath.Count(); i++)
                {
                    this.Text = i.ToString();
                    media = WMP.newMedia( Path.GetFullPath(fullfilesPath[i]));
                    playlist.appendItem(media);
                }

                WMP.currentPlaylist = playlist;
                WMP.controls.play();
                WMP.settings.setMode("loop", true);

            }
        }
    }
}
