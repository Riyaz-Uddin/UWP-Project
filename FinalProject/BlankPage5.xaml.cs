using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage5 : Page
    {
        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));

        }

        private void dowork2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage4));
        }
        private void dowork3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        public BlankPage5()
        {
            this.InitializeComponent();
            //Item item;

            //Uri _baseUri = new Uri("ms-appx:///");

            //item = new Item();

            //item.Title = "Acer Aspire S3-391 Laptop";

            //item.Price = "Rs. 66,754";

            //item.SetImage(_baseUri, "Images/wood.jpg");

            //item.Content = "Core i7 (3G), 13.3 Inch4,  GB RAM, 500 GB HD, Win 7";



            //item = new Item();

            //item.Title = "Acer Aspire S3 Aspire S Laptop";

            //item.Price = "Rs. 54,500";

            //item.SetImage(_baseUri, "Images/2.jpg");

            //item.Content = "Core i5 (2G), 13.3 Inch, 4 GB RAM, 320 GB HD, Win 7";

            //Collection.Add(item);



            //item = new Item();

            //item.Title = "Acer Aspire One 725 Laptop";

            //item.Price = "Rs. 19,499";

            //item.SetImage(_baseUri, "Images/3.jpg");

            //item.Content = "AMD APU Dual Core, 11.6 Inch, 2 GB RAM, 320 GB HD, Win 7";

            //Collection.Add(item);



            //item = new Item();

            //item.Title = "Acer Aspire One AOD 270 NU.SGASI.003 Netbook";

            //item.Price = "Rs. 16,560";

            //item.SetImage(_baseUri, "Images/4.jpg");

            //item.Content = "Atom Dual Core (2G), 10.1 Inch, 2 GB RAM, 320 GB HD, Linux";

            //Collection.Add(item);



            //item = new Item();

            //item.Title = "Acer Aspire V3-571G Laptop";

            //item.Price = "Rs. 38,455";

            //item.SetImage(_baseUri, "Images/6.jpg");

            //item.Content = "Core i3 (2G), 15.6 Inch, 4 GB RAM, 500 GB HD, Win 7";

            //Collection.Add(item);
            PopulateProjects();

        }

        private void PopulateProjects()
        {
            //List<Items> Projects = new List<Items>();
            GetRecords();

            //Project2 newProject = new Project2();
            //newProject.Activities.Add(new Items()
            //{ PATIENTID = "P-001", PATIENTNAME = "Sadman Rahman", PATIENTAGE = 24,PATIENTPHONE=01835817766, GENDER=Male, ADDRESS="Nunachara",ADMISSIONDATE="2022-01-02"",IMAGE= @"C:\Users\Sir  Pc\AppData\Local\Packages\a14801bb-9e14-4fa5-ac28-481fd580c4d2_4wfb1cc211pwr\LocalState\avatar.jpg" });
            //newProject.Activities.Add(new Items()
            //{ PATIENTID = "P-002", PATIENTNAME = "Salma Khanom", PATIENTAGE = 35,PATIENTPHONE=01835825840, GENDER=Male, ADDRESS="Potikchari",ADMISSIONDATE="2022-01-06" });
            // Collection.Add(collection);



            //cvsProjects.Source = Projects;
        }
        public async Task GetRecords()
        {

            var folder = ApplicationData.Current.LocalFolder;

            try
            {
                var file = await folder.OpenStreamForReadAsync("sample.txt");

                using (var reader = new StreamReader(file))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        var l = line.Split(",");
                        if (l.Length > 6)
                        {
                            var img = "";
                            if (File.Exists(ApplicationData.Current.LocalFolder.Path + "\\" + l[7]))
                            {
                                img = l[7];
                            }
                            else
                            {
                                img = "Images/Patient1.jpg";
                            }
                            Collection.Add(new Items() { PATIENTID = l[0], PATIENTNAME = l[1], ADDRESS = l[2], PATIENTAGE = int.Parse(l[3]), PATIENTPHONE = l[4], GENDER = l[5], ADMISSIONDATE = l[6], IMAGE = img });
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }
        public ObservableCollection<Items> Activities { get; set; }
        List<Items> collection = new List<Items>();

        protected override void OnNavigatedTo(NavigationEventArgs e)

        {
            //GetRecords();
            BlankPage5 messageData = new BlankPage5();

            PatientListView.ItemsSource = messageData.Collection;

            PatientListView.SelectedIndex = 0;

        }

        public List<Items> Collection

        {

            get

            {

                return this.collection;

            }

        }
    }
    public class Item

    {

        private string _Title;

        public string Title

        {

            get

            {

                return this._Title;

            }

            set

            {

                this._Title = value;

            }

        }

        private string _Price;

        public string Price

        {

            get

            {

                return this._Price;

            }

            set

            {

                this._Price = value;

            }

        }

        private ImageSource _Image;

        public ImageSource Image

        {

            get

            {

                return this._Image;

            }

            set

            {

                this._Image = value;

            }

        }

        public void SetImage(Uri baseUri, String path)

        {

            Image = new BitmapImage(new Uri(baseUri, path));

        }

        private string _Link;

        public string Link

        {

            get

            {

                return this._Link;

            }

            set

            {

                this._Link = value;

            }

        }

        private string _Category;

        public string Category

        {

            get

            {

                return this._Category;

            }

            set

            {

                this._Category = value;

            }

        }

        private string _Description;

        public string Description

        {

            get

            {

                return this._Description;

            }

            set

            {

                this._Description = value;

            }

        }

        private string _Content;

        public string Content

        {

            get

            {

                return this._Content;

            }

            set

            {

                this._Content = value;

            }

        }

    }
}
