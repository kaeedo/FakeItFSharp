module Tests

open System
open FakeItEasy
open Program
open Xunit

[<Fact>]
let ``Fake it easy with mocking`` () =
    let dbFake = A.Fake<IDatabase>()
    
    let myService = MyService(dbFake) :> IMyService
    
    let _ = myService.DoThing 1
    
    // Not nice assertion message
    // System.ArgumentNullException: Value cannot be null. (Parameter 'value')
    A.CallTo(fun _ -> dbFake.Save(A.Ignored)).MustHaveHappenedOnceExactly()