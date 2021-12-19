using MonoTorrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Synthesis;
using MonoTorrent.Client;

namespace TorrentClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SpeechSynthesizer debugger;

        public MainWindow()
        {
            InitializeComponent();

            debugger = new SpeechSynthesizer();

            string _downloadPath = @"C:\custom_download_torrents\";

            TorrentSettings torrentSettings = new TorrentSettings();
            /*torrentSettings.UploadSlots = 5;
            torrentSettings.MaximumConnections = 100;
            torrentSettings.MaximumDownloadSpeed = 0;
            torrentSettings.MaximumUploadSpeed = 0;*/


            Torrent torrent = Torrent.Load(@"C:\Users\ПК\Downloads\Lego MARVEL Super Heroes [P] [RUS ENG] (2013) [rutracker-5433808].torrent");

            /*TorrentManager _manager = new TorrentManager(torrent, _downloadPath, torrentSettings,
                new FastResume((BEncodedDictionary)
                _fastResume[_torrent.InfoHash]));*/
            TorrentManager _manager;

            int _port = 31337;
            EngineSettings _engineSettings = new EngineSettings();
            // _engineSettings.SavePath = _downloadPath;
            // _engineSettings.ListenPort = _port;

            ClientEngine _engine = new ClientEngine(_engineSettings);

            // _engine.Register(_manager);
            /*_manager.TorrentStateChanged +=
                delegate (object o, TorrentStateChangedEventArgs e)
                {
                    lock (_listener)
                        _listener.WriteLine("Last status: " +
                        e.OldState.ToString() + " Current status: " +
                        e.NewState.ToString());
                };
            }*/

            debugger.Speak("размер торрента: " + torrent.Size.ToString());
            debugger.Speak("торрент создан автором: " + torrent.CreatedBy.ToString());
            debugger.Speak("размер создан в: " + torrent.CreationDate.ToString());
            debugger.Speak("комментарий торрента: " + torrent.Comment.ToString());
            debugger.Speak("url торрента: " + torrent.PublisherUrl.ToString());
            debugger.Speak("длина кусков торрента: " + torrent.PieceLength.ToString());
            debugger.Speak("куски торрента: " + torrent.Pieces.Count.ToString());

        }
    }
}
