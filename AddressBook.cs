// 주소록 만들기

using System;

class MainClass
{
    public static void Main(string[] args)
    {

        AddressBook Book = new AddressBook();

        string Input;

        string Name;
        string PhoneNumber;

        long Size;

        Size = Convert.ToInt64(Console.ReadLine());

        Book.SetSize(Size);

        for (int i = 0; i < Size; ++i)
        {

            Console.Write("이름: ");
            Name = Console.ReadLine();
            Console.Write("전화번호(01012345678): ");
            PhoneNumber = Console.ReadLine();

            while (true)
            {
                if (Book.SetData(Name, PhoneNumber)) break;

                Console.Write("재입력 전화번호(01012345678): ");
                PhoneNumber = Console.ReadLine();

            }

        }

        while (true)
        {
            Input = Console.ReadLine();

            if (Input == "종료")
            {
                Console.WriteLine("\n종료");
                break;
            }

            switch (Input)
            {
                case "InputData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.SetData(Name, PhoneNumber))
                    {
                        Console.WriteLine("추가 성공");
                    }
                    else
                    {
                        Console.WriteLine("추가 실패");
                    }

                    break;

                case "DelData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.DelData(Name, PhoneNumber))
                    {
                        Console.WriteLine("삭제 성공");
                    }
                    else
                    {
                        Console.WriteLine("삭제 실패");
                    }

                    break;

                case "MotifyData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("새로운 전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.ModifyData(Name, PhoneNumber))
                    {
                        Console.WriteLine("수정 성공");
                    }
                    else
                    {
                        Console.WriteLine("수정 실패");
                    }

                    break;

                case "SearchData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.ModifyData(Name, PhoneNumber))
                    {
                        Console.WriteLine(" 성공");
                    }
                    else
                    {
                        Console.WriteLine("수정 실패");
                    }

                    break;

                default:
                    Console.WriteLine("재입력");
                    break;
            }

        }

        Book.DelData("ddd", "01033333333");

        Book.AllData();
    }

    /*
        시작하면 n개의 정보 입력받기
        
        
     */
}

class AddressBook
{
    private string[] NameArr;
    private string[] PhoneNumberArr;
    private long BookSize;
    private long Index;

    // int[] arr = (int[])arr2.Clone();

    private void ReSize()
    {
        string[] CopyName = (string[])NameArr.Clone();
        string[] CopyPhoneNumber = (string[])PhoneNumberArr.Clone();

        int CheckIndx = 0;

        NameArr = new string[BookSize];
        PhoneNumberArr = new string[BookSize];

        for (int i = 0; i < CopyName.Length; ++i)
        {
            if (CopyName[i] != null)
            {
                if (CopyPhoneNumber[i] != null)
                {
                    NameArr[CheckIndx] = CopyName[i];
                    PhoneNumberArr[CheckIndx] = CopyPhoneNumber[i];
                    ++CheckIndx;
                }
            }
        }
    }

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
        PhoneNumberArr = new string[BookSize];
    }

    // 이름과 전번을 받아 배열에 추가
    public bool SetData(string Name, string PhoneNumber) // 정보 추가
    {
        if (PhoneNumber.Length != 11) return false; // 전화번호의 길이 확인 010####%%%%
        else if (Index + 1 > BookSize)
        {
            ReSize();
        }

        this.NameArr[Index] = Name;
        this.PhoneNumberArr[Index] = PhoneNumber;
        ++Index;
        return true;
    }

    // 이름과 전번을 받아 해당하는 데이터 삭제
    public bool DelData(string Name, string PhoneNumber)
    {
        for (int i = 0; i < BookSize; ++i)
        {
            if (NameArr[i] == Name)
            {
                if (PhoneNumberArr[i] == PhoneNumber)
                {
                    NameArr[i] = null;
                    PhoneNumberArr[i] = null;
                    --Index;
                    return true;
                }
                return false;
            }
        }
        return false;
    }

    // 이름과 새로운 전화번호를 받아 이름에 해당하는 전화번호를 새로운 전화번호로 변경한다.
    public bool ModifyData(string Name, string NewPhoneNumber)
    {
        for (int i = 0; i < Index; ++i)
        {
            if (NameArr[i] == Name)
            {
                PhoneNumberArr[i] = NewPhoneNumber;
                return true;
            }
        }
        return false;
    }

    // 이름을 받아서 이름에 해당하는 데이터를 출력해줌
    public bool SearchData(string Name)
    {
        for (int i = 0; i < Index; ++i)
        {
            if (NameArr[i] == Name)
            {
                Console.WriteLine("데이터 검색\n이름: " + Name + "\t전화번호: " + PhoneNumberArr[i]);
                return true;
            }
        }
        return false;
    }

    // 모든 데이터 출력
    public void AllData()
    {
        Console.WriteLine("**데이터 전체 출력**");
        for (int i = 0; i < Index; ++i)
        {
            if (NameArr[i] != null)
            {
                Console.Write("이름: " + NameArr[i]);
                Console.WriteLine("\t전화번호: " + PhoneNumberArr[i]);
            }
        }
        Console.WriteLine();
    }

}
