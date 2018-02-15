# ADAPT

## Building the framework
ADAPT is built on the .NET Standard 2.0 which works with the following minimum versions; .NET Core 2.0, .NET Framework 2.6.1, Mono 5.4. ADAPT uses NuGet for dependency management and Nunit for unit testing.

To use Visual Studio you will need to have Visual Studio 2017 or later. NuGet is available by default and the Nunit tools will be installed from NuGet when the solution is built.

If you are using Monodevelop, be sure you have installed the NUnit package ("apt-get install monodevelop-nunit" in debian-based systems). Depending on what Monodevelop package you have installed, it may or may not include Nuget support. If not, install the Nuget addin, available from the addin repositories or from https://github.com/mrward/monodevelop-nuget-addin/.

Once you have an IDE with NuGet and NUnit support, simply clone the repository and load the .sln file.
