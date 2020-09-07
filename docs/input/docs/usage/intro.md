---
Order: 10
Title: Introduction
Author: Kim J. Nordmo
Description: Getting started with the Cake.T4 addin
---

## Getting Started

This addin is designed to be used inside of cake scripts. To start using it, first you must add a cake [preprocessor directive](http://cakebuild.net/docs/fundamentals/preprocessor-directives) to your script as below.

```cs
// latest version
#addin "Cake.T4"
// or
#addin "nuget?package=Cake.T4"
// for a specific version, use ?version=
#addin "Cake.T4?version=0.1.0"
```

When the cake script is run, this will download the latest version of the `Cake.T4` nuget package and will now be available to use inside of the script.
