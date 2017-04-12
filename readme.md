# Environment Tracker

## Build

Build status: [![build status](https://gitlab.com/kataik/EnvironmentTracker/badges/master/build.svg)](https://gitlab.com/kataik/EnvironmentTracker/commits/master)

Coverage report: [![coverage report](https://gitlab.com/kataik/EnvironmentTracker/badges/master/coverage.svg)](https://gitlab.com/kataik/EnvironmentTracker/commits/master)

## Usage

`docker login registry.gitlab.com`

`docker pull registry.gitlab.com/kataik/environmenttracker:latest`

`docker run --rm -v [host output folder]:/data registry.gitlab.com/kataik/environmenttracker:latest`

`docker logout registry.gitlab.com`

## Pending known issues

- Sonar-[scanner|runner] does not support msbuild analysis, resulting in passing, but meaningless analysis report
- Code coverage tool supporting .NET Core on Linux does not exists yet, keep an eye on [minicover](https://github.com/lucaslorentz/minicover) until MS comes up with one