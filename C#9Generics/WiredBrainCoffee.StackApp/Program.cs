StackDoubles();
StackStrings();


Console.ReadLine();

static void StackDoubles()
{
    var stack = new Stack<double>();

    stack.Push(1.2);
    stack.Push(2.8);
    stack.Push(3.0);

    double sum = 0.0;

    while (stack.Count > 0)
    {
        double item = stack.Pop();
        Console.WriteLine($"item: {item}");
        sum += item;
    }
    Console.WriteLine($"sum: {sum}");
}

void StackStrings()
{
    var stack = new Stack<string>();

    stack.Push("Wired Brain Coffee");
    stack.Push("Pluralsight");

    while (stack.Count > 0)
    {
        var item = stack.Pop();
        Console.WriteLine($"item: {item}");
    }

}
