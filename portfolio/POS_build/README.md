## 개인 토이프로젝트
- 포스기 프로그램

## 프로젝트 소개
- 포스기를 관리하는 프로그램입니다.

## 개발환경
- C#
- IDE: : Visual Studio 2022
- Database : SSMS(SQL Server Management Studio 20)

## 주요기능
- 상품 판매 기능
    - 상품명, 가격, 개수를 입력하고 DB에 추가
    - 구매할려는 상품 가격 합계 구해줌
- 계산하기 기능
    - 계산을 하게 되면 재고에서 상품 개수가 빠짐
- 판매 내역 기능
    - 현재 판매한 물품 검색, 수정, 품목 삭제
- 재고 현황 기능
    - 보유한 재고 현황을 보여줌
    - 재고 검색, 추가, 수정, 삭제

## Operating 사진

![상품판매](https://raw.githubusercontent.com/JinyongSon/basic-csharp-2024/main/images/상품판매.png)


- 상품명, 가격, 개수를 입력 후 담기를 누르면 왼쪽 화면 장바구니에 담긴다.


![계산화면](https://raw.githubusercontent.com/JinyongSon/basic-csharp-2024/main/images/계산화면.png)


- 계산하기를 누르면 왼쪽 장바구니가 비워지게 되고 계산이 완료된다.


![판매내역](https://raw.githubusercontent.com/JinyongSon/basic-csharp-2024/main/images/판매내역.png)


- 판매내역을 누르면 장바구니에서 계산이 완료된 품목이 화면에 나온다.
- 물품 검색, 수정, 삭제기능까지 가능하다.


![재고현황](https://raw.githubusercontent.com/JinyongSon/basic-csharp-2024/main/images/재고현황.png)


- 재고현황을 누르면 현재 남아있는 재고 화면이 나온다. 위의 사진은 계산하기 전 재고 화면이다.
- 재고현황은 추가와 삭제기능은 가능한데 수정이 잘 안되는것으로 확인되었다.


![판매후재고현황](https://raw.githubusercontent.com/JinyongSon/basic-csharp-2024/main/images/판매후재고현황.png)


- 계산 후 재고현황으로 수량이 계산 전 보다 줄어든걸로 확인 할 수 있다.

## 배운점
- 생각보다 화면을 구성하기 조금 까다롭고 시간이 오래 걸렸고 로그인 화면을 구성해서 기능을 넣는 것 까지 생각했는데 못해서 아쉽다.
- 스스로 화면을 구성하여 기능을 넣어서 작동을 잘 되는 것이 조금 신기했다.