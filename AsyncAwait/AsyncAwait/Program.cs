// See https://aka.ms/new-console-template for more information


CallAsync();
SimpleMethod();
Console.ReadLine();



// METHODS BELOW---------------------------//



// Using this method to test if the thread is released by the
// await keyword in TestThreadAsync().
static void SimpleMethod()
{
    int currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine("Simple Method executes");
    Console.WriteLine($"Thread {currentThread}");

}
static async void CallAsync()
{
    await TestThreadAsync();
}
static async Task TestThreadAsync()
{
    int currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"No. 1");
    Console.WriteLine($"Thread {currentThread}");
    var httpClient = new HttpClient();

    currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"No. 2");
    Console.WriteLine($"Thread {currentThread}");
    var uri = "https://www.google.com";
    var taskToRun = httpClient.GetStringAsync(uri);


    currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"No. 3");
    Console.WriteLine($"Thread {currentThread}");

    var a = 0;
    for (int i = 0; i < 1000000; i++)
    {
        a++;
    }
    Console.WriteLine($"Done with while loop");

    currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"No. 4");
    Console.WriteLine($"Thread {currentThread}");

    // await will release the current cpu thread to other parts of the program,
    // when information is retreived, the thread pool is notified,
    // which passes the pool to the OS responsible for CPU scheduling
    // OS schedules and places the task to continue on assigned thread.
    var page = await taskToRun;
    currentThread = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"No. 5");
    Console.WriteLine($"Thread {currentThread}");
    Console.WriteLine($"-------------------------");
    Console.WriteLine();
    Console.WriteLine($"{page}");

}
