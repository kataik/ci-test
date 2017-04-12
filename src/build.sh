#!/bin/bash

dotnet restore
dotnet build -c Debug
dotnet build -c Release

for d in ./**/*Test*.csproj
do
  dotnet test --no-build --logger "trx;LogFileName=$PWD/test/$(basename $d).trx" $d
done

dotnet publish -o "$PWD/publish" ./EnvironmentTracker/EnvironmentTracker.csproj