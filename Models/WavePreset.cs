using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TKIW_RunBuilder.Models
{
    class WavePreset : INotifyPropertyChanged
    {
        private int id { set; get; }

        private Unit _unit1;
        public Unit unit_1
        {
            get => _unit1;
            set { _unit1 = value; OnPropertyChanged(); }
        }

        private int _qty1;
        public int qty_1
        {
            get => _qty1;
            set { _qty1 = value; OnPropertyChanged(); }
        }

        private Unit _unit2;
        public Unit unit_2
        {
            get => _unit2;
            set { _unit2 = value; OnPropertyChanged(); }
        }

        private int? _qty2;
        public int? qty_2
        {
            get => _qty2;
            set { _qty2 = value; OnPropertyChanged(); }
        }

        private Unit _unit3;
        public Unit unit_3
        {
            get => _unit3;
            set { _unit3 = value; OnPropertyChanged(); }
        }

        private int? _qty3;
        public int? qty_3
        {
            get => _qty3;
            set { _qty3 = value; OnPropertyChanged(); }
        }

        private Unit _unit4;
        public Unit unit_4
        {
            get => _unit4;
            set { _unit4 = value; OnPropertyChanged(); }
        }

        private int? _qty4;
        public int? qty_4
        {
            get => _qty4;
            set { _qty4 = value; OnPropertyChanged(); }
        }

        private Unit _unit5;
        public Unit unit_5
        {
            get => _unit5;
            set { _unit5 = value; OnPropertyChanged(); }
        }

        private int? _qty5;
        public int? qty_5
        {
            get => _qty5;
            set { _qty5 = value; OnPropertyChanged(); }
        }

        private Unit _unit6;
        public Unit unit_6
        {
            get => _unit6;
            set { _unit6 = value; OnPropertyChanged(); }
        }

        private int? _qty6;
        public int? qty_6
        {
            get => _qty6;
            set { _qty6 = value; OnPropertyChanged(); }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
