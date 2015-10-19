@echo off

setlocal

:: location of XSD tool
set VISUAL_STUDIO_SDK=C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools
set XSD_EXE=%VISUAL_STUDIO_SDK%\xsd.exe

:: input directory
set XML_SCHEMA_DIR=.

:: setup input files
set FILES=
set FILES=%FILES% %XML_SCHEMA_DIR%\jdtypes.xsd
set FILES=%FILES% %XML_SCHEMA_DIR%\RepresentationSystem.xsd
set FILES=%FILES% %XML_SCHEMA_DIR%\UnitSystem.xsd

echo FILES
echo %FILES%

:: output directory
set XML_PROJECT_ROOT=%XML_SCHEMA_DIR%

:: XSD tool flags
set XSD_FLAGS=
set XSD_FLAGS=%XSD_FLAGS% /classes
set XSD_FLAGS=%XSD_FLAGS% /fields
set XSD_FLAGS=%XSD_FLAGS% /namespace:JohnDeere.Representation.RepresentationSystem.Generated
set XSD_FLAGS=%XSD_FLAGS% /out:%XML_PROJECT_ROOT%

mkdir %XML_PROJECT_ROOT%\..\Generated
echo %XSD_EXE%
:: generate setup classes
"%XSD_EXE%" %FILES% %XSD_FLAGS%

echo Moving UnitSystem.cs to GeneratedClasses.cs
move %XML_PROJECT_ROOT%\UnitSystem.cs %XML_PROJECT_ROOT%\..\Generated\GeneratedClasses.cs