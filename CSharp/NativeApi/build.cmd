@echo off
REM //---------- copy binaries and include for MavLinkCom in deps ----------
msbuild build\ImuFusion.Native.sln  /target:Clean /target:Build  /property:Configuration=Release /property:Platform=x64
if ERRORLEVEL 1 goto :buildfailed

REM //---------- done building ----------
exit /b 0

:buildfailed
echo(
echo #### Build failed - see messages above. 1>&2
exit /b 1