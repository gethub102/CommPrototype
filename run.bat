@echo --- This run.bat will succeed when handling files because it uses
@echo --- the same current working directory than Visual Studio

cd Client\bin\debug
Client1.exe
cd ..\..
cd Client2\bin\debug
Client2.exe
cd ..\..
cd Server\bin\debug
Server.exe
cd ..\..
cd WpfClient\bin\debug
WpfApplication1.exe
cd ..\..
