using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    public class SettingBusiness
    {
        public List<Setting> All()
        {
            var settingDac = new SettingDAC();
            var result = settingDac.Select();
            return result;
        }

        public Setting Find(int id)
        {
            var settingDac = new SettingDAC();
            var result = settingDac.SelectById(id);
            return result;
        }

        public Setting Add(Setting setting)
        {
            var settingDac = new SettingDAC();
            return settingDac.Create(setting);
        }

        public void Remove(int id)
        {
            var settingDac = new SettingDAC();
            settingDac.DeleteById(id);
        }

        public void Edit(Setting setting)
        {
            var settingDac = new SettingDAC();
            settingDac.UpdateById(setting);
        }
    }
}
