#!/bin/sh

echo Building...
dotnet build src/CoreSandbox/CoreSandbox.csproj
pushd src/CoreSandbox
echo Creating a self-contained app package...
dotnet publish
popd
