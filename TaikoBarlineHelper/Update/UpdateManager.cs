using System;
using System.Xml;
using System.Windows;
using TaikoBarlineHelper.Settings;
using System.Diagnostics;

namespace TaikoBarlineHelper
{
    public static class UpdateManager
    {
        public static bool HasUpdate()
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(Properties.Settings.Default.UpdateXML);
                bool nextIsVersion = false;
                string version = "";
                while (reader.Read())
                {
                    if (nextIsVersion && reader.NodeType == XmlNodeType.Text)
                    {
                        version = reader.Value;
                        break;
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "version")
                    {
                        //Debug.WriteLine("Hijuesu el siguiente es el bueno");
                        nextIsVersion = true;
                    }
                }
                Debug.WriteLine($"Latest version is '{version}', current is '{SettingsManager.Version}'");

                return IsVersionNewer(SettingsManager.Version, version);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Something went wrong, tell Iojioji to get his stuff together!\r\n\r\nMessage: {ex.Message}\r\n\r\nStackTrace: {ex.StackTrace}", "Error while checking for updates!",MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        static bool IsVersionNewer(string currentVersion, string newVersion)
        {
            Debug.WriteLine($"Current Version: {currentVersion}, New Version: {newVersion}");
            string[] currentVer = currentVersion.Split('.');
            string[] newVer = newVersion.Split('.');

            if (currentVer.Length < newVer.Length)
            {
                return true;
            }
            for (int i = 0; i < currentVer.Length; i++)
            {
                int currentNumber = int.Parse(currentVer[i]);
                int newNumber = int.Parse(newVer[i]);
                if (newNumber > currentNumber)
                {
                    return true;
                }
                else if (newNumber < currentNumber)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
