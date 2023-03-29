using FakeItEasy;

namespace TestProject1;

public class TestFSharpClass
{
    [Fact]
    public void Test1()
    {
        var fakeThing = A.Fake<Program.IDatabase>();
        Program.IMyService myService = new Program.MyService(fakeThing);

        myService.DoThing(1);
        
        // Not nice assertion message
        // System.ArgumentNullException: Value cannot be null. (Parameter 'value')
        A.CallTo(() => fakeThing.Save(A<Tuple<int, string>>.Ignored)).MustHaveHappened();
    }
}