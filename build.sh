#!/bin/sh

echo Building...
dotnet build src/CoreSandbox/project.json
pushd src/CoreSandbox
echo Creating a self-contained app package...
dotnet publish
popd
