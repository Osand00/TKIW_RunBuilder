using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TKIW_RunBuilder.Models
{
    class WaveTemplate : INotifyPropertyChanged
    {
        private int id { set; get; }
        public int week { set; get; }
        public string reqWaveId { set; get; }
        public string? extraWaveId_1 { set; get; }
        public string? extraWaveId_2 { set; get; }
        public string waveType { set; get; }
        public string secondaryWaveType { set; get; }
        public string tertiaryWaveType { set; get; }


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
