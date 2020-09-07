---
Order: 2
Title: Building on Linux
Author: Kim J. Nordmo
Description: How to build Cake.T4 on Linux operating systems
---

## Requirements

The following are need to build Cake.T4 on Linux:

- .NET Core SDK 2.1 and 3.1 is required.
- Mono 6.0+ (only when publishing packages)

All other dependencies will be automatically downloaded when invoking the build script.

## Invoking the build itself

1. To build the Cake.T4 library, just open any shell and navigate to the root of
   downloaded/cloned repository.
2. After that just type `sh build.sh` and everything will be automatically built and all unit tests
   will run.
