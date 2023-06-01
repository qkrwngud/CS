class MainClass
{
    public static void Main(string[] args)
    {
        Queue Q = new Queue(5);

        Q.push(10);
        Q.push(20);
        Q.push(30);

        Console.WriteLine(Q.front());
        Q.pop();
        Console.WriteLine(Q.front());

    }
}

class Queue
{
    private int[] QArr;
    private int Size;
    private int Rear;
    private int[] Arr;

    public Queue(int Size)
    {
        QArr = new int[Size];
        this.Size = Size;
        this.Rear = 0;
    }

    public void push(int num)
    {
        QArr[Rear] = num;
        ++Rear;
    }

    public void pop()
    {
        QArr[0] = -1;
        --Rear;

        Arr = new int[Size];

        for(int i = 0; i < Size; ++i)
        {
            Arr[i] = QArr[i];
            QArr[i] = 0;
        }

        int a = 0;
        for (int i = 0; i < Size; ++i)
        {
            if (Arr[i] != -1)
            {
                QArr[a] = Arr[i];
                ++a;
            }
        }
    }

    public int front()
    {
        return QArr[0];
    }

}
