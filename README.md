# Cake.T4

[![standard-readme compliant][]][standard-readme]
[![All Contributors][all-contributorsimage]](#contributors)
[![Appveyor build][appveyorimage]][appveyor]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

Cake addin for transforming text templates (t4) using monos [dotnet-t4](https://nuget.org/packages/dotnet-t4) utility.

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
  - [Contributors](#contributors)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.T4
```

## Usage

```cs
#addin nuget:?package=Cake.T4

Task("MyTask").Does(() => {
  T4();
});
```

## Maintainer

[Kim J. Nordmo @AdmiringWorm][maintainer]

## Contributing

Cake.T4 follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.
Please see [the contributing file][contributing] for how to contribute to Cake.T4.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

This project follows the [all-contributors][] specification. Contributions of any kind welcome!

### Contributors

Thanks goes to these wonderful people ([emoji key][emoji-key]):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

[MIT License © Kim J. Nordmo][license]

[all-contributors]: https://github.com/all-contributors/all-contributors
[all-contributorsimage]: https://img.shields.io/github/all-contributors/cake-contrib/Cake.T4.svg?color=orange&style=flat-square
[appveyor]: https://ci.appveyor.com/project/cakecontrib/cake-t4
[appveyorimage]: https://img.shields.io/appveyor/ci/cakecontrib/cake-t4.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/cake-contrib/Cake.T4
[codecovimage]: https://img.shields.io/codecov/c/github/cake-contrib/Cake.T4.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[contributing]: CONTRIBUTING.md
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/AdmiringWorm
[nuget]: https://nuget.org/packages/Cake.T4
[nugetimage]: https://img.shields.io/nuget/v/Cake.T4.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
