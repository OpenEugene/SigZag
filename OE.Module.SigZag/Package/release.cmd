REN  OE.Module.SigZag.nuspec.REMOVE OE.Module.SigZag.nuspec 
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack OE.Module.SigZag.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

