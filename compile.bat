:Compile.bat
@echo --- this batch file must be run from the VS2015 x64 Native Tools Command Prompt
@echo on
:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\devenv.exe" CommPrototype.sln /rebuild debug
devenv CommPrototype.sln /rebuild debug
pause



