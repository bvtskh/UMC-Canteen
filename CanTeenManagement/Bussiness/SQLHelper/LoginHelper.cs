using CanTeenManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanTeenManagement.Bussiness.SQLHelper
{
    public class LoginHelper
    {
        internal int GetCurrenVersion(Configuration config)
        {
            var settings = config.AppSettings.Settings;
            return ConvertVersion(settings["Version"].Value);
        }
        internal int GetNewVersion()
        {
            using (var context = new DBContext())
            {
                return ConvertVersion(context.Tbl_Version.ToList().LastOrDefault().Version);
            }
        }
        internal string GetNewVersionString()
        {
            using (var context = new DBContext())
            {
                return context.Tbl_Version.ToList().LastOrDefault().Version;
            }
        }
        private int ConvertVersion(string ver)
        {
            // Remove periods from the string
            string numberString = ver.Replace(".", "");

            // Parse the resulting string as an integer
            if (!int.TryParse(numberString, out int versionInt))
            {
                throw new ArgumentException("Invalid version string format.");
            }

            return versionInt;
        }

        internal bool IsValidVersion()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                int currentVersion = GetCurrenVersion(config);
                int newVersion = GetNewVersion();

                if (currentVersion<newVersion)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Tbl_User GetAccount(string tk, string mk)
        {
            using(var context = new DBContext())
            {
                var account = context.Tbl_User.Where(w => w.Account == tk && w.PassWord == mk).FirstOrDefault();
                return account;
            }
        }

        internal string CheckAccount(Tbl_User account)
        {
            if (account.Type == 0) return "ADMIN";
            else return "MEMBER";
        }
    }
}
