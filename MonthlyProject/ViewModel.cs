using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MonthlyProject
{
    public class ViewModel : INotifyPropertyChanged
    {
        private List<Vehicles> V;
        private int currentCustomer;
        public Command NextCustomer { get; private set; }
        public Command PreviousCustomer { get; private set; }
        public ViewModel()
        {
            currentCustomer = 0;
            this.IsAtStart = true;
            this.IsAtEnd = false;
            this.NextCustomer = new Command(this.Next, () =>
this.V.Count > 1 && !this.IsAtEnd);
            this.PreviousCustomer = new Command(this.Previous, () =>
            this.V.Count > 0 && !this.IsAtStart);
            this.V = new List<Vehicles>();
            string fileName = "TextFile1.txt";
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var l = line.Split(",");
                        V.Add(new Vehicles() { RegNo = l[0], RegdOwner = l[1], Address = l[2], MakersClass = l[3], VehiclesClass = l[4], FuelUsed = l[5], EngineCC = l[6] });
                    }
                }
            }
            catch (Exception exp)
            {
                MessageDialog a = new MessageDialog(exp.Message);
                a.ShowAsync();
            }

        }
        public Vehicles Current
        {
            get => this.V.Count > 0 ? this.V[currentCustomer] :
            null;
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
        private bool _isAtStart;
        public bool IsAtStart
        {
            get => this._isAtStart;
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged(nameof(IsAtStart));
            }
        }
        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get => this._isAtEnd;
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged(nameof(IsAtEnd));
            }
        }
        private void Next()
        {
            if (this.V.Count - 1 > this.currentCustomer)
            {
                this.currentCustomer++;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtStart = false;
                this.IsAtEnd = (this.V.Count - 1 == this.currentCustomer);
            }
        }
        private void Previous()
        {
            if (this.currentCustomer > 0)
            {
                this.currentCustomer--;
                this.OnPropertyChanged(nameof(Current));
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentCustomer == 0);
            }

        }
    }

}
