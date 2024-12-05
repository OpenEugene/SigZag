del "*.nupkg"
REN OE.Theme.SigZag.nuspec.REMOVE OE.Theme.SigZag.nuspec
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack OE.Theme.SigZag.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Themes\" /Y
