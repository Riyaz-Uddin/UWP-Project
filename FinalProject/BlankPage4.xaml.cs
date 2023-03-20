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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage4 : Page
    {
        Project2 newProject = new Project2();
        public BlankPage4()
        {
            this.InitializeComponent();
            PopulateProjects();
        }
        private void PopulateProjects()
        {
            List<Project2> Projects = new List<Project2>();
            GetRecords();
            //Project2 newProject = new Project2();
            //newProject.Activities.Add(new Items()
            //{ PATIENTID = "P-001", PATIENTNAME = "Sadman Rahman", PATIENTAGE = 24,PATIENTPHONE=01835817766, GENDER=Male, ADDRESS="Nunachara",ADMISSIONDATE="2022-01-02",IMAGE= @"C:\Users\Sir  Pc\AppData\Local\Packages\a14801bb-9e14-4fa5-ac28-481fd580c4d2_4wfb1cc211pwr\LocalState\avatar.jpg" });
            //newProject.Activities.Add(new Items()
            //{ PATIENTID = "P-001", PATIENTNAME = "Sadman Rahman", PATIENTAGE = 24,PATIENTPHONE=01835817766, GENDER=Male, ADDRESS="Nunachara",ADMISSIONDATE="2022-01-02"});
            Projects.Add(newProject);



            cvsProjects.Source = Projects;
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
                                img = Path.Combine(ApplicationData.Current.LocalFolder.Path, l[7]);
                            }
                            else
                            {
                                img = "Images/Patient1.jpg";
                            }
                            newProject.Activities.Add(new Items() { PATIENTID = l[0], PATIENTNAME = l[1], ADDRESS = l[2], PATIENTAGE = int.Parse(l[3]), PATIENTPHONE = l[4], GENDER = l[5], ADMISSIONDATE = l[6], IMAGE = img });
                        }
                    }
                    reader.Close();
                }

            }
            catch (Exception)
            {

            }

        }
        private void dowork(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1));

        }

        private void dowork2(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void dowork3(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage5));
        }

        private void clickMe(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }

    public class Project2
    {
        public Project2()
        {
            Activities = new ObservableCollection<Items>();
        }

        public ObservableCollection<Items> Activities { get; set; }
    }
}
