using System.Configuration;
using Zanella.MF7.Infra.Settings.Entities;

namespace Zanella.MF7.Infra.Settings
{
    public class ZanellaSettings
    {
        #region private fields
        static AuthenticationSettings _authSettings;
        #endregion private fields

        public static AuthenticationSettings AuthenticationSettings
        {
            get
            {
                return _authSettings ?? ((AuthenticationSettings)ConfigurationManager.GetSection("Zanella/AuthenticationSettings"));
            }
        }
    }
}
