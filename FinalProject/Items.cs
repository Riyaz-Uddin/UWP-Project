using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Items : INotifyPropertyChanged
    {
        public string PATIENTID { get; set; }
        public string _patientname;
        public string PATIENTNAME
        {
            get => this._patientname;
            set
            {
                this._patientname = value;
                this.OnPropertyChanged(nameof(PATIENTNAME));
            }
        }
        public string _address;
        public string ADDRESS
        {
            get => this._address;
            set
            {
                this._address = value;
                this.OnPropertyChanged(nameof(ADDRESS));
            }
        }
        public double _patientage;
        public double PATIENTAGE
        {
            get => this._patientage;
            set
            {
                this._patientage = value;
                this.OnPropertyChanged(nameof(PATIENTAGE));
            }
        }
        public string _patientphone;
        public string PATIENTPHONE
        {
            get => this._patientphone;
            set
            {
                this._patientphone = value;
                this.OnPropertyChanged(nameof(PATIENTPHONE));
            }
        }

        public string _gender;
        public string GENDER
        {
            get => this._gender;
            set
            {
                this._gender = value;
                this.OnPropertyChanged(nameof(GENDER));
            }
        }
        public string _admissiondate;
        public string ADMISSIONDATE
        {
            get => this._admissiondate;
            set
            {
                this._admissiondate = value;
                this.OnPropertyChanged(nameof(ADMISSIONDATE));
            }
        }
        public string _image;
        public string IMAGE
        {
            get => this._image;
            set
            {
                this._image = value;
                this.OnPropertyChanged(nameof(IMAGE));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
