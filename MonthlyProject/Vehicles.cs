using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyProject
{
    public class Vehicles : INotifyPropertyChanged
    {
        public String RegNo { get; set; }
        public string _regdOwner;
        public string RegdOwner
        {
            get => this._regdOwner;
            set
            {
                this._regdOwner = value;
                this.OnPropertyChanged(nameof(RegdOwner));
            }
        }
        public string _address;
        public string Address
        {
            get => this._address;
            set
            {
                this._address = value;
                this.OnPropertyChanged(nameof(Address));
            }
        }
        public string _makersClass;
        public string MakersClass
        {
            get => this._makersClass;
            set
            {
                this._makersClass = value;
                this.OnPropertyChanged(nameof(MakersClass));
            }
        }
        public string _vehiclesClass;
        public string VehiclesClass
        {
            get => this._vehiclesClass;
            set
            {
                this._vehiclesClass = value;
                this.OnPropertyChanged(nameof(VehiclesClass));
            }
        }

        public string _fuelUsed;
        public string FuelUsed
        {
            get => this._fuelUsed;
            set
            {
                this._fuelUsed = value;
                this.OnPropertyChanged(nameof(FuelUsed));
            }
        }
        public string _engineCC;
        public string EngineCC
        {
            get => this._engineCC;
            set
            {
                this._engineCC = value;
                this.OnPropertyChanged(nameof(EngineCC));
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
