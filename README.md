# ADAPT

## Building the Framework
The ADAPT Framework requires the .NET Core 2.x SDK and the .NET 4.5.1 SDK to be built correctly. It is possible to build the projects with just the .NET Core 2.x SDK if you use the .NET CLI and use the *-Framework* flag.

### CI Builds
The ADAPT Framework has it's tests run every time any code changes through a Travis CI job.

### Release Builds
The ADAPT Framework is built by creating a GitHub Release that triggers a Travis CI job. The release tag version should conform to the pattern *vX.X.X-alphaX* for an alpha release, *vX.X.X-betaX* for a beta release, *vX.X.X-rcX* for a release candidate release and *vX.X.X* for a production release. The job takes the release tag version and publishes a NuGet package using that.

An example would be that the release tag version *v1.2.3-beta2* will create a NuGet package with the version *1.2.3-beta2* and the assemblies would have the file version *1.2.3.N* where **N** is the Travis CI build number.

### Local Builds
The ADAPT Framework can be built locally on a developer machine if the repository is cloned.

#### Visual Studio Code
- Open the repository directory with Visual Studio Code
- Run the *Build* or *Test* task

#### Visual Studio 2017
- Open *ADAPT.sln* in the repository directory with Visual Studio 2017
- Run the *Build > Rebuild Solution* command

#### .NET CLI
- Navigate to the repository directory in a shell
- Run `dotnet build ./ADAPT.sln -c Debug` for a debug build
- Run `dotnet build ./ADAPT.sln -c Release` for a release build (with the addition argument ` /p:Version=<VERSION>` if you want a version other than *0.0.0*)

#### NuGet Package

- Make sure that the code has been build for the *Release* configuration
- Navigate to the repository directory in a shell
- Run `nuget pack ./AgGatewayADAPTFramework.nuspec -outputdirectory ./dist` (with the addition argument `-version <VERSION>` if you want a package version other than *0.0.0*)
