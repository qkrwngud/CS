// 주소록 만들기

using System;

class MainClass
{
    public static void Main(string[] args)
    {
        AddressBook Book = new AddressBook();


    }

    /*
        시작하면 n개의 정보 입력받기
        
        
     */
}

class AddressBook
{
    private string[] NameArr;
    private string[] AddressArr;
    private long BookSize;
    private long Index;

    // int[] arr = (int[])arr2.Clone();


    // 값 초기화
    public AddressBook()
    {
        this.BookSize = 1;
        this.Index = 0;
    }

    // 주소록 배열의 크기 설정
    public void SetSize(long DefaultSize)
    {
        this.BookSize = DefaultSize;
        NameArr = new string[BookSize];
        AddressArr = new string[BookSize];
    }

    // 이름과 전번을 받아 배열에 추가
    public void SetData(string Name, string Address) // 정보 추가
    {
        if(Index >= BookSize)
        {
            
        }

        this.NameArr[Index] = Name;
        this.AddressArr[Index] = Address;
        ++Index;
    }

    // 이름과 전번을 받아 해당하는 데이터 삭제
    public bool DelData(string Name, string Address)
    {
        for(int i = 0;i < BookSize; ++i)
        {
            if (NameArr[i] == Name)
            {
                if (AddressArr[i] == Address)
                {
                    NameArr[i] = "-1";
                    AddressArr[i] = "-1";
                    --Index;
                    return true;
                }
                return false;
            }
        }
        return false;
    }

    // 이름과 새로운 전화번호를 받아 이름에 해당하는 전화번호를 새로운 전화번호로 변경한다.
    public bool ModifyData(string Name, string NewAddress)
    {
        for(int i = 0; i < Index; ++i)
        {
            if (NameArr[i] == Name)
            {
                AddressArr[i] = NewAddress;
                return true;
            }
        }
        return false;
    }

    // 이름을 받아서 이름에 해당하는 데이터를 출력해줌
    public bool SearchData(string Name)
    {
        for(int i = 0; i < Index; ++i)
        {
            if (NameArr[i] == Name)
            {
                Console.WriteLine("데이터 검색\n이름: " + Name + "\t전화번호: " + AddressArr[i]);
                return true;
            }
        }
        return false;
    }

    // 모든 데이터 출력
    public void AllData()
    {
        Console.WriteLine("**데이터 전체 출력**");
        for(int i = 0; i < Index; ++i)
        {
            if (NameArr[i] != "-1")
            {
                Console.WriteLine("이름: " + NameArr[i] + "전화번호: " + AddressArr[i]);
            }
        }
        Console.WriteLine();
    }

}
