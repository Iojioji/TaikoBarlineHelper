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

        public static string Version { get => _version; set => _version = value; }

        public static void Init()
        {

        }
    }
}
