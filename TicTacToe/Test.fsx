// sets the current directory to be same as the script directory
System.IO.Directory.SetCurrentDirectory (__SOURCE_DIRECTORY__)

#I @"C:\Users\sebastianas.malinaus\Dropbox\Workspace\F#\TicTacToe\packages\"
#r @"FsCheck.2.2.4\lib\net45\FsCheck.dll"
#r @"FsCheck.Nunit.2.2.4\lib\net45\FsCheck.NUnit.dll"
#r @"NUnit.3.0.1\lib\net45\nunit.framework.dll"
#load "Parser.fs"

open NUnit.Framework
open FsCheck
open FsCheck.NUnit


[<Property>]
let ``Commutative`` x y = 
    Parser.parse x
