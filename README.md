# ADAPT

## Building the framework
ADAPT uses NuGet for dependency management and Nunit for unit testing. If you are using Visual Studio 2013 or older, install the "NuGet Package Manager" and "NUnit Test Adapter" extensions. If you are using Visual Studio 2015 or newer, it should work out of the box. 

If you are using Monodevelop, be sure you have installed the NUnit package ("apt-get install monodevelop-nunit" in debian-based systems). Depending on what Monodevelop package you have installed, it may or may not include Nuget support. If not, install the Nuget addin, available from the addin repositories or from https://github.com/mrward/monodevelop-nuget-addin/.

Once you have an IDE with Nuget and NUnit support, simply clone the repository and load the .sln file.