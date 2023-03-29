type IDatabase =
    abstract member Save: wef:(int * string) -> unit
    
type Database() =
    interface IDatabase with
        member _.Save user =
            let id, username = user
            ()
            
type IMyService =
    abstract member DoThing: int -> string
    
type MyService(db: IDatabase) =
    interface IMyService with
        member _.DoThing id =

            // We are verifying that this method gets called in the tests
            // db.Save user
            
            $"Saved user"

let db = new Database()
let myService = new MyService(db) :> IMyService

let response = myService.DoThing 1

//printfn $"Response is: '%s{response}'"
