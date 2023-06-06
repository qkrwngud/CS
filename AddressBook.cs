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

        while (true)
        {
            Console.Write("행동(InputData, DelData, MotiftData, SearchData, AllData) : ");
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
                    Console.WriteLine();
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
                    Console.WriteLine();
                    break;

                case "MotifyData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("새로운 전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.ModifyingData(Name, PhoneNumber))
                    {
                        Console.WriteLine("수정 성공");
                    }
                    else
                    {
                        Console.WriteLine("수정 실패");
                    }
                    Console.WriteLine();
                    break;

                case "SearchData":

                    Console.Write("이름: ");
                    Name = Console.ReadLine();
                    Console.Write("전화번호(01012345678): ");
                    PhoneNumber = Console.ReadLine();

                    if (Book.ModifyingData(Name, PhoneNumber))
                    {
                        Console.WriteLine("검색 성공");
                    }
                    else
                    {
                        Console.WriteLine("검색 실패");
                    }
                    Console.WriteLine();
                    break;

                case "AllData":

                    Book.ShowAllData();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("재입력");
                    break;
            }

        }
    }

    /*
        시작하면 n개의 정보 입력받기
        
        
     */
}

class AddressBook
{
    private string[] NameArr;
    private string[] PhoneNumberArr;
    private long ArraySize;
    private long Index;
    private string[] CopyName;
    private string[] CopyPhoneNumber;

    private void ReSize(int DelIndex = -1)
    {

        CopyName = new string[ArraySize];
        CopyPhoneNumber = new string[ArraySize];

        for (int i = 0; i < ArraySize; ++i)
        {
            CopyName[i] = NameArr[i];
            CopyPhoneNumber[i] = PhoneNumberArr[i];
        }

        switch (DelIndex)
        {
            case -1:
                ++ArraySize;
                NameArr = new string[ArraySize];
                PhoneNumberArr = new string[ArraySize];

                for (int i = 0; i < ArraySize; ++i)
                {
                    NameArr[i] = CopyName[i];
                    PhoneNumberArr[i] = CopyPhoneNumber[i];
                }

                break;

            case 1:
                int CheckIndx = 0;

                NameArr = new string[ArraySize];
                PhoneNumberArr = new string[ArraySize];

                for (int i = 0; i < ArraySize; ++i)
                {
                    if (CopyName[i] != "-1" && CopyPhoneNumber[i] != "-1")
                    {
                        NameArr[CheckIndx] = CopyName[i];
                        PhoneNumberArr[CheckIndx] = CopyPhoneNumber[i];
                        ++CheckIndx;
                    }
                }
                this.Index = CheckIndx - 1;
                break;
        }
    }


    // 값 초기화
    public AddressBook()
    {
        this.ArraySize = 1;
        this.Index = 0;

        NameArr = new string[ArraySize];
        PhoneNumberArr = new string[ArraySize];
    }

    // 이름과 전번을 받아 배열에 추가
    public bool SetData(string NewName, string NewPhoneNumber) // 정보 추가
    {
        if (NewPhoneNumber.Length != 11) return false; // 전화번호의 길이 확인 010####%%%%

        if(Index == ArraySize)
        {
            ReSize(-1);
        }

        this.NameArr[Index] = NewName;
        this.PhoneNumberArr[Index] = NewPhoneNumber;
        ++Index;

        return true;
    }

    // 이름과 전번을 받아 해당하는 데이터 삭제
    public bool DelData(string NewName, string NewPhoneNumber)
    {
        for (int i = 0; i < ArraySize; ++i)
        {
            if (NameArr[i] == NewName && PhoneNumberArr[i] == NewPhoneNumber)
            {
                NameArr[i] = "-1";
                PhoneNumberArr[i] = "-1";

                ReSize(1);
                --Index;
                return true;
            }
        }
        return false;
    }

    // 이름과 새로운 전화번호를 받아 이름에 해당하는 전화번호를 새로운 전화번호로 변경한다.
    public bool ModifyingData(string Name, string NewPhoneNumber)
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
                Console.Write("데이터 검색\t이름: " + NameArr[i]);
                Console.WriteLine("\t전화번호: " + PhoneNumberArr[i]);
                return true;
            }
        }
        return false;
    }

    // 모든 데이터 출력
    public void ShowAllData()
    {
        Console.WriteLine("**데이터 전체 출력**");
        for (int i = 0; i < Index; ++i)
        {
            if (NameArr[i] != "-1" && PhoneNumberArr[i] != "-1")
            {
                Console.Write("이름: " + NameArr[i]);
                Console.WriteLine("\t전화번호: " + PhoneNumberArr[i]);
            }
        }
        Console.WriteLine();
    }

}
