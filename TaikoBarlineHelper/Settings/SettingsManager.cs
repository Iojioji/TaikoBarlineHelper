using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaikoBarlineHelper.Settings
{
    public static class SettingsManager
    {
        static string _version;
        static string _loadedMap;

        public static string Version { get => _version; set => _version = value; }
        public static string LoadedMap 
        { 
            get => _loadedMap; 
            set
            {
                _loadedMap = value;
                Properties.Settings.Default.LoadedMap = _loadedMap;
                Properties.Settings.Default.Save();
            }
        }

        public static void Init()
        {
            _loadedMap = Properties.Settings.Default.LoadedMap;
        }
    }
}
