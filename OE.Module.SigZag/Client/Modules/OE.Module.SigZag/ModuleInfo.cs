using Oqtane.Models;
using Oqtane.Modules;

namespace OE.Module.SigZag
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "SigZag",
            Description = "Tools for managing your Special Interest Group",
            Version = "1.0.0",
            ServerManagerType = "OE.Module.SigZag.Manager.SigZagManager, OE.Module.SigZag.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "OE.Module.SigZag.Shared.Oqtane,MudBlazor",
            PackageName = "OE.SigZag" 
        };
    }
}
