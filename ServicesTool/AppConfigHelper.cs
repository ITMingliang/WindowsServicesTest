using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesTool
{
    public class AppConfigHelper
    {
        static AppConfigHelper()
        {

        }

        public static string GetAppSetting(string SectionName, string strDefault)
        {
            return GetAppSetting(Application.ExecutablePath + ".config", SectionName, strDefault);
        }
        public static void SaveAppSetting(string SectionName, string strDefault)
        {
            SaveAppSetting(Application.ExecutablePath + ".config", SectionName, strDefault);
        }
        public static string GetAppSetting(string FilePath, string SectionName, string strDefault)
        {
            ExeConfigurationFileMap FileMap = new ExeConfigurationFileMap();
            FileMap.ExeConfigFilename = FilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(FileMap, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[SectionName] == null)
            {
                config.AppSettings.Settings.Add(SectionName, strDefault);
                config.Save();
                return strDefault;
            }
            else
                return config.AppSettings.Settings[SectionName].Value;
        }
        public static void SaveAppSetting(string FilePath, string SectionName, string strValue)
        {
            ExeConfigurationFileMap FileMap = new ExeConfigurationFileMap();
            FileMap.ExeConfigFilename = FilePath;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(FileMap, ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[SectionName] == null)
                config.AppSettings.Settings.Add(SectionName, strValue);
            else
                config.AppSettings.Settings[SectionName].Value = strValue;
            config.Save();
        }

    }
}
