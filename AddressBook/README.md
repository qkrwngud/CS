# AddressBook
2023년 프로그래밍(CS)수행평가 주소록 만들기

### 입력
```
Input, Delete, Motifying, Search, AllData, 종료 중 한가지를 입력하면 해당 기능을 실행한다.

종료를 입력할 떄까지는 계속해서 프로그램이 돌아간다.
Input 추가(매개변수로 이름과 전화번호를 받아 저장함)
Delete 삭제(매개변수로 이름과 전화번호를 받아 해당 데이터를 삭제함)
Motifying 특정 데이터 수정(매개변수로 이름과 변경할 전화번호 입력)

Search 특정 데이터 출력(매개변수로 이름과 전화번호를 받음)
AllData 모든 데이터 출력(매개변수 없음)

종료 (프로그램 종료)

```

#### 변수
```
string[] NameArr; 이름 배열
string[] PhoneNumberArr; 전화번호 배열
long BookSize; 배열 길이
long Index; 마지막으로 들어간 값의 위치 + 1
string[] CopyName; 이름 배열의 복사본
string[] CopyPhoneNumber; 전화번호 배열의 복사본
```

#### 메소드
```
생성자
public AddressBook()


private void ReSize(int DelIndex = -1)
값을 삭제(값을 -1로 변경) 하거나 배열들의 크기를 늘려쥰다
DelIndex가 -1이라면 배열들의 크기를 늘려주고
-1이 아닌 다른 값이라면 배열에서 -1인 값을 없엔다.

public bool SetData(string NewName, string NewPhoneNumber) 데이터 추가
배열에 NewName과 NewPhoneNumber를 넣는다.

public bool DelData(string NewName, string NewPhoneNumber) 데이터 삭제
NewName과 NewPhoneNumber에 해당하는 정보를 배열에서 -1로 변경한다.

public bool ModifyingData(string NewName, string NewPhoneNumber) 데이터 수정
NewName과 NewPhoneNumber를 받아서 NewName에 해당하는 전화번호를 NewPhoneNumber로 변경해준다.

public bool SearchData(string NewName) 데이터 검색
NewName에 해당하는 이름과 전화번호를 출력해준다.

public void ShowAllData()
모든 데이터 출력
```
