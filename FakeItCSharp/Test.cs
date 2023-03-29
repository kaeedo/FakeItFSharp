using FakeItEasy;

namespace TestProject1;

public interface IDatabase
{
    void Save(int id, string username);
}

public class Database : IDatabase
{
    public void Save(int id, string username)
    {
        Console.WriteLine("Saved");
    }
}

interface IMyService
{
    string DoThing(int id);
}

public class MyService : IMyService
{
    private readonly IDatabase _db;

    public MyService(IDatabase db)
    {
        _db = db;
    }
    public string DoThing(int id)
    {
        //_db.Save(id, "wefwef");
        return "Saved user";
    }
}

public class Test
{
    [Fact]
    public void Test1()
    {
        var fakeThing = A.Fake<IDatabase>();
        IMyService myService = new MyService(fakeThing);

        myService.DoThing(1);
        
        // This is the good assertion message
        // Assertion failed for the following call:
        // TestProject1.IDatabase.Save(id: <Ignored>, username: <Ignored>)
        // Expected to find it once or more but no calls were made to the fake object.
        A.CallTo(() => fakeThing.Save(A<int>.Ignored, A<string>.Ignored)).MustHaveHappened();
    }
}