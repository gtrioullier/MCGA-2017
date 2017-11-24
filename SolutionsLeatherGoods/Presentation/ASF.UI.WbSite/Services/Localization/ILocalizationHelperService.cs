using System;
using System.Threading.Tasks;

namespace ASF.UI.WbSite.Services.Localization
{
    public partial interface ILocalizationHelperService
    {
        string getResourceString(string Key);
    }
}
