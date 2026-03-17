using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TKIW_RunBuilder.Models
{
    class Unit
    {
        public string idName { set; get; }
        public string displayName { set; get; }

        public string imageSource
        {
            get 
            {
                var pack = $"pack://application:,,,/TKIW_RunBuilder;component/UnitImages/{idName}.png";
                //if (PackResourceExists(pack))
                return pack;
                //return $"pack://application:,,,/TKIW_RunBuilder;component/UnitImages/default.png";
            }
        }

        private static bool PackResourceExists(string packUri)
        {
            try
            {
                var uri = new Uri(packUri, UriKind.Absolute);
                var info = Application.GetResourceStream(uri);
                return info != null;
            }
            catch
            {
                return false;
            }
        }
    }
}