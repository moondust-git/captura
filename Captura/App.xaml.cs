using FirstFloor.ModernUI.Presentation;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Captura
{
    public partial class App
    {
        public static CmdOptions CmdOptions { get; } = new CmdOptions();

        void Application_Startup(object sender, StartupEventArgs optionsArgs)
        {
            Settings.Instance.MeetingParams = null;
            if (optionsArgs.Args.Length > 0 && optionsArgs.Args[0].StartsWith("params="))
            {
                Settings.Instance.MeetingParams = optionsArgs.Args[0];

                AppDomain.CurrentDomain.UnhandledException += (s, args) =>
                {
                    var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "Captura",
                        "Crashes");
                    Directory.CreateDirectory(dir);

                    File.WriteAllText(Path.Combine(dir, $"{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.txt"),
                        args.ExceptionObject.ToString());

                    MessageBox.Show($"Unexpected error occured. Captura will exit.\n\n{args.ExceptionObject}",
                        "App Crash",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    Shutdown();
                };

                if (CmdOptions.Reset)
                {
                    Settings.Instance.Reset();
                }
                if (Settings.Instance.DarkTheme)
                {
                    AppearanceManager.Current.ThemeSource = AppearanceManager.DarkThemeSource;
                }

                var accent = Settings.Instance.AccentColor;

                if (!string.IsNullOrEmpty(accent))
                    AppearanceManager.Current.AccentColor = (Color) ColorConverter.ConvertFromString(accent);

                // A quick fix for WpfToolkit not being copied to build output of console project
                Xceed.Wpf.Toolkit.ColorSortingMode.Alphabetical.ToString();
            }
            else
            {
                throw new Exception("init error");
            }
        }
    }
}