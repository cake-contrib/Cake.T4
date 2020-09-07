---
Order: 1
Title: Building on Windows
Author: Kim J. Nordmo
Description: How to build Cake.T4 on Windows operating systems
---

## Requirements

The following are need to build Cake.T4 on Windows:

- Visual Studio 2019 (or as long as MSBuild 16.0 is installed)
- .NET Core SDK 2.1 and 3.1

All other dependencies will be automatically downloaded when invoking the build script.

## Invoking the build itself

1. To build the Cake.T4 library, just open powershell and navigate to the root of
   downloaded/cloned repository.
2. After that just type `.\build.ps1` and everything will be automatically built and all unit tests
   will run.
