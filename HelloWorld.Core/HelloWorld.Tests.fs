module HelloWorld.Tests.Hello

open HelloWorld.Core.Hello
open NUnit.Framework
open FsUnit
open FsCheck
open FsCheck.Xunit

[<Test>]
let shouldSayHello () = Assert.AreEqual("Hello World!", SayHello "World")

[<Test>]
let shouldSayHelloWithFsUnit ()
    = SayHello "World" |> should equal "Hello World!"

[<Test>]
let ``There and back again`` ()
    = SayHello "World" |> should equal "Hello World!"



[<Property>]
let commutativeProperty x y =
    let result1 = add x y
    let result2 = add y x
    result1 = result2

[<Test>]
let ``Ayy lmao`` () =
    Check.Quick commutativeProperty
