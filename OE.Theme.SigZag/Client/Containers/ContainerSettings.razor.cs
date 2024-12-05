using Microsoft.AspNetCore.Components;
using Oqtane.Interfaces;
using Oqtane.Modules;
using Oqtane.Services;
using System;
using System.Threading.Tasks;

namespace OE.Theme.SigZag
{
    public partial class ContainerSettings : ModuleBase, ISettingsControl
    {
        [Inject] ISettingService SettingService { get; set; }
        private string resourceType = "OE.Theme.SigZag.ContainerSettings, OE.Theme.SigZag.Client.Oqtane"; // for localization
        private string _title = "true";

        protected override void OnInitialized()
        {
            try
            {

                _title = SettingService.GetSetting(ModuleState.Settings, GetType().Namespace + ":Title", "true");

            }
            catch (Exception ex)
            {
                AddModuleMessage(ex.Message, MessageType.Error);
            }
        }

        public async Task UpdateSettings()
        {
            try
            {
                var settings = await SettingService.GetModuleSettingsAsync(ModuleState.ModuleId);
                settings = SettingService.SetSetting(settings, GetType().Namespace + ":Title", _title);
                await SettingService.UpdateModuleSettingsAsync(settings, ModuleState.ModuleId);
            }
            catch (Exception ex)
            {
                AddModuleMessage(ex.Message, MessageType.Error);
            }
        }
    }
}
