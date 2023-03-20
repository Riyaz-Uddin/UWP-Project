using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
            StorageFolder appFolder = ApplicationData.Current.LocalFolder;
            loc2.Text = "Path: " + appFolder.Path;
            loc1.Text = "Path: " + appFolder.Path;
            CreateTextFile2();




        }
        private void login(object sender, RoutedEventArgs e)
        {
            bool isInLandscapeMode =
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation ==
            Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape;
            if (!isInLandscapeMode)
                GetRecords();
            else
                GetRecordLanscapes();
        }
        public async Task GetRecords()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if (l[0] == user.Text && l[1] == pass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error1.Text = "Invalid User Name or Password. Please try again .....";
                }

            }
            catch (Exception)
            {

            }

        }
        public async Task GetRecordLanscapes()
        {
            var all = "";
            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("users.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 1)
                        {
                            if (l[0] == tuser.Text && l[1] == tpass.Password)
                            {
                                this.Frame.Navigate(typeof(MainPage));
                                return;
                            }

                        }
                    }
                    error2.Text = "Invalid User Name or Password. Please try again .....";
                }

            }
            catch (Exception)
            {

            }

        }
        private void CreateTextFile2()
        {
            CreateTextFile();
        }
        private async Task CreateTextFile()
        {

            Windows.Storage.StorageFolder storageFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
            if (!File.Exists(storageFolder.Path + "\\sample.txt"))
            {
                Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                string s = "P-001,Sadman Rahman,Nunachara,24,01835817766,Male,2022-01-02,Grey.JPG" + Environment.NewLine +
                "P-0012,Salma Khanom,Potikchari,35,01835825840,Female,2022-01-06,Grey.JPG";

                await Windows.Storage.FileIO.AppendTextAsync(sampleFile, s + Environment.NewLine);
            }
            if (!File.Exists(storageFolder.Path + "\\users.txt"))
            {
                Windows.Storage.StorageFile sampleFile2 = await storageFolder.CreateFileAsync("users.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
                var s = "riyazuddin,4545" + Environment.NewLine +
                "nizamuddin,5656";

                await Windows.Storage.FileIO.AppendTextAsync(sampleFile2, s + Environment.NewLine);
            }
        }
    }
}
