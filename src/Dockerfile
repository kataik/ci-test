FROM microsoft/dotnet:1.1.1-sdk
MAINTAINER Kornel Balint Katai <kataik@gmail.com>

WORKDIR /build

COPY . .

RUN /bin/bash ./build.sh

WORKDIR /publish

RUN rm -rf /build

VOLUME /data

ENTRYPOINT ["dotnet", "EnvironmentTracker.dll"]