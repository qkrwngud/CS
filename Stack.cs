class MainClass
{
    public static void Main(string[] args)
    {
        Stack S = new Stack(5);

        S.push(10);
        S.push(20);
        S.push(30);

        Console.WriteLine(S.top());
        S.pop();
        Console.WriteLine(S.top());

    }
}

class Stack
{
    private int[] SArr;
    private int Size;
    private int Index;
    private int Top;

    public Stack(int Size)
    {
        this.Size = Size;
        SArr = new int[Size];
        Index = 0;
        Top = 0;
    }

    public void push(int num)
    {
        SArr[Index] = num;
        ++Index;
        Top = num;
    }

    public void pop()
    {
        --Index;
        SArr[Index] = -1;

        Top = SArr[Index - 1];

    }

    public int top()
    {
        return Top;
    }
}
