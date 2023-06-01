class MainClass
{
    public static void Main(string[] args)
    {

        StackQueue SQ = new StackQueue(5);

        SQ.push_back(10);
        SQ.push_front(5);

        SQ.pop_top();
        SQ.pop_front();

        SQ.push_back(20);
        SQ.push_front(1);

        foreach(int i in SQ.SQArr)
        {
            Console.Write(i + " ");
        }Console.WriteLine();

    }
}

class StackQueue
{
    public int[] SQArr;
    private int Size;
    private int Front;
    private int Top;
    private int Index;

    public StackQueue(int Size)
    {
        this.Size = Size;
        Front = 0;
        Top = 0;
        SQArr = new int[Size];
        Index = 0;

    }

    public void push_front(int num)
    {
        int[] Arr;

        if(Index == Size)
        {
            ++Size;
            Arr = new int[Size];

            for(int i = 1; i < Size; ++i)
            {
                Arr[i] = SQArr[i - 1];
            }

            SQArr = new int[Size];
            for(int i = 0; i < Size; ++i)
            {
                SQArr[i] = Arr[i];
            }
            SQArr[0] = num;
        }
        else
        {
            Arr = new int[Size];

            for (int i = 1; i < Size; ++i)
            {
                Arr[i] = SQArr[i - 1];
            }
            for (int i = 0; i < Size; ++i)
            {
                SQArr[i] = Arr[i];
            }
            SQArr[0] = num;
        }

        ++Index;
    }

    public void push_back(int num)
    {
        SQArr[Index] = num;
        ++Index;
    }

    public void pop_top()
    {
        SQArr[Index - 1] = -1;
        --Index;
    }

    public void pop_front()
    {
        SQArr[Front] = -1;

        int[] Arr = new int[Size];

        int a = 0;

        for (int i = 0; i < Size; ++i)
        {
            Arr[i] = SQArr[i];
            SQArr[i] = 0;
        }

        for (int i = 0; i < Size; ++i)
        {
            if (Arr[i] != -1)
            {
                SQArr[a] = Arr[i];
                ++a;
            }
        }
        --Index;
    }

    public int front()
    {
        Front = SQArr[0];
        return Front;
    }

    public int top()
    {
        Top = SQArr[Index - 1];
        return Top;
    }
}
