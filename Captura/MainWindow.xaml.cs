using Captura.Models;
using Captura.ViewModels;
using Captura.Views;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Captura
{
    public partial class MainWindow
    {
        FFMpegDownloader _downloader;

        public MainWindow()
        {
            ServiceProvider.RegionProvider = new RegionSelector();

            ServiceProvider.MessageProvider = new MessageProvider();

            ServiceProvider.WebCamProvider = new WebCamProvider();


            FFMpegService.FFMpegDownloader += () =>
            {
                if (_downloader == null)
                {
                    _downloader = new FFMpegDownloader();
                    _downloader.Closed += (s, args) => _downloader = null;
                }

                _downloader.ShowAndFocus();
            };

            Settings.Instance.Expanded = false;
            InitializeComponent();

            ServiceProvider.MainWindow = new MainWindowProvider(this);

            if (App.CmdOptions.Tray)
                Hide();

            // Register for Windows Messages
            ComponentDispatcher.ThreadPreprocessMessage += (ref MSG Message, ref bool Handled) =>
            {
                const int WmHotkey = 786;

                if (Message.message == WmHotkey)
                {
                    var id = Message.wParam.ToInt32();

                    ServiceProvider.RaiseHotKeyPressed(id);
                }
            };

            ServiceProvider.SystemTray = new SystemTray(SystemTray);

            Closing += (s, e) =>
            {
                if (!TryExit())
                    e.Cancel = true;
            };

            (DataContext as MainViewModel).Init(!App.CmdOptions.NoPersist, true, !App.CmdOptions.Reset,
                !App.CmdOptions.NoHotkeys);
            try
            {
                UrlParse.validate(Settings.Instance.MeetingParams,
                    Properties.Resources.ResourceManager.GetString("validateName"),
                    Properties.Resources.ResourceManager.GetString("validateId"));
            }
            catch (Exception e)
            {
                ServiceProvider.MessageProvider.ShowError(
                    Properties.Resources.ResourceManager.GetString("StartParamError"));
                this.TryExit();
            }
            if (Settings.Instance.CheckForUpdates)
                Task.Factory.StartNew(CheckForUpdates);

            ServiceProvider.SystemTray.ShowTextNotification(Settings.Instance.MeetingName, 60_000, null);
        }

        async void CheckForUpdates()
        {
            try
            {
                var link = "https://api.github.com/repos/MathewSachin/Captura/releases/latest";

                string result;

                using (var web = new WebClient {Proxy = Settings.Instance.GetWebProxy()})
                {
                    web.Headers.Add(HttpRequestHeader.UserAgent, Properties.Resources.AppName);

                    result = await web.DownloadStringTaskAsync(link);
                }

                var node = JsonConvert.DeserializeXmlNode(result, "Releases");

                var latestVersion = node.SelectSingleNode("Releases/tag_name").InnerText.Substring(1);

                if (new Version(latestVersion) > AboutViewModel.Version)
                {
                    ServiceProvider.SystemTray.ShowTextNotification($"Captura: Update (v{latestVersion}) Available",
                        60_000, () =>
                        {
                            try
                            {
                                Process.Start("https://github.com/MathewSachin/Captura/releases/latest");
                            }
                            catch
                            {
                                // Swallow Exceptions.
                            }
                        });
                }
            }
            catch
            {
                // Swallow any Exceptions.
            }
        }

        void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();

            e.Handled = true;
        }

        void MinButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        void SystemTray_TrayMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Hide();
            }
            else
            {
                Show();

                WindowState = WindowState.Normal;

                Activate();
            }
        }

        bool TryExit()
        {
            var vm = DataContext as MainViewModel;

            if (vm.RecorderState == RecorderState.Recording)
            {
                bool l = ServiceProvider.MessageProvider.ShowYesNo(
                    Properties.Resources.ResourceManager.GetString("recordingExit"),
                    Properties.Resources.ResourceManager.GetString("ConfirmExit"));
                return false;
            }

            vm.Dispose();
            SystemTray.Dispose();
            Application.Current.Shutdown();
            return true;
        }

        void MenuExit_Click(object sender, RoutedEventArgs e) => TryExit();

        void HideButton_Click(object Sender, RoutedEventArgs E) => Hide();
    }
}