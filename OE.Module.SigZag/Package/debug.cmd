XCOPY "..\Client\bin\Debug\net9.0\OE.Module.SigZag.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Client\bin\Debug\net9.0\OE.Module.SigZag.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Server\bin\Debug\net9.0\OE.Module.SigZag.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Server\bin\Debug\net9.0\OE.Module.SigZag.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Shared\bin\Debug\net9.0\OE.Module.SigZag.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Shared\bin\Debug\net9.0\OE.Module.SigZag.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
XCOPY "..\Client\bin\Debug\net9.0\MudBlazor.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net9.0\" /Y

