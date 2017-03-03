@echo off
echo Building...
dotnet build src\CoreSandbox\project.json
cd src\CoreSandbox
echo Creating a self-contained app package...
dotnet publish
cd ..\..
