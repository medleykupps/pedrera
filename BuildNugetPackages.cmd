@echo off

SET mynugetpackages=C:\Code\MyNugetPackages\
ECHO %mynugetpackages%

ECHO Building Core
CD Pedrera.Core
nuget pack Pedrera.Core.csproj

IF %errorlevel%==1 (
	ECHO Error occurred
	GOTO ende
)

COPY *.nupkg %mynugetpackages%


CD ..


ECHO Building Pedrera.Core.Mvc

CD Pedrera.Core.Mvc
nuget pack Pedrera.Core.Mvc.csproj -IncludeReferencedProjects

IF %errorlevel%==1 (
	ECHO Error occurred
	GOTO ende
)

COPY *.nupkg %mynugetpackages%

CD ..






:ende