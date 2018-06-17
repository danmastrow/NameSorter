# NameSorter

[![Build Status](https://travis-ci.org/danmastrow/NameSorter.svg?branch=master)](https://travis-ci.org/danmastrow/NameSorter)

## Requirements
- Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A
name must have at least 1 given name and may have up to 3 given names.

## So what does it do?
- What doesn't it do?
- Ok what it actually does is that given a file, it will Parse the Names by the Regex Expression, map those to the Name class and then sort by Surname, then Given Names. Then it outputs to the console, and also to an output file.

###### Example
The unsorted list:
```
    Robert DeNiro
    Jack First AAAA
    Marlon Brando
    Tom Hanks
    Brad C Pitt
    Leonardo DiCaprio
    Leonardo DiCaprion
    Humphrey Bogart
    Johnny Depp
    Marlon Brandon
    Al Pacino
    Denzel Washington
    Laurence Olivier
    Brad Pitt
    Brad A Pitt

```
Will become:
```
    Jack First AAAA
    Humphrey Bogart
    Marlon Brando
    Marlon Brandon
    Robert DeNiro
    Johnny Depp
    Leonardo DiCaprio
    Leonardo DiCaprion
    Tom Hanks
    Laurence Olivier
    Al Pacino
    Brad Pitt
    Brad A Pitt
    Brad C Pitt
    Denzel Washington
```

## Getting Started
- After building run the NameSorter application with a filepath argument. 
  - Depending on whether you have built/deployed the application as Self Contained or as Framework dependent, run the .dll or .exe with the filename parameter.
  - Eg:
  - For a *Framework Dependent* .NET Core Application build use:
	- dotnet NameSorter.dll ./unsortedfile.txt
  - For a *Self Contained* .NET Core Application build use:
	- NameSorter.exe ./unsortedfile.txt
  
## Configuration
- At the moment a Regex Pattern is being used to determine what is mapped as a GivenName and what is mapped as a Surname to the Name class.
To modify this simply change the givenNameregexPattern in the Program.Main entry point. Ideally this would be in a config file or database if it was continually changing.

## Testing
- The tests are written using the Xunit Test Framework.