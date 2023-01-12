// See https://aka.ms/new-console-template for more information


using FindLastAndRemoveAt;

var list = new MyList<TestClass>(10);

for (var i = 0; i < 10; i++)
{
    list.Add(new TestClass());
}

var readTask0 = Task.Run(() => {
    while (true)
    {
        try
        {
            var indexOfLastMatch = list.FindLastAt(_ => _.IsTestClass());
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
        }
    }
});

await Task.Delay(10000); // подождем, когда таски на чтение запустятся
for (var i = 0; i < 10; i++)
{
    list.RemoveAt(i);
}


public class TestClass
{
    public bool IsTestClass()
        => true;
}