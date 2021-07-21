# 마트게임
***
 - 작성 및 제작 : 김명현
 - 작성 언어 : C#
***
 - Update Log
    - 21.07.08 : 코드 작성완료
    - 21.07.09 : 오답또는 정답일 경우 OX이미지를 띄워 좀더 생동감있게 제작
    - 21.07.20 : 인코딩형식 UTF8로 수정
    - 21.07.21 : 정답 또는 오답인 경우 음성기능 추가

***
 - 구동화면 및 내용

![마트게임](https://user-images.githubusercontent.com/37494407/126114297-dc1d8758-c20f-4b8c-abe8-846a56ab6482.png)

    - 주인공이 원하는 아이템을 랜덤으로 정하여 말풍선으로 표시된다.
    - 주인공이 원하는 아이템을 카트안에 담으면 되는 게임이다.
    
![마트X](https://user-images.githubusercontent.com/37494407/126114536-5d26f958-1947-4f0d-9681-67306dcd411f.png)

    - 만약 주인공이 원하지 않는 아이템을 담을 경우 X표시가 나타나며 아이템은 다시 제자리로 돌아간다.
![마트o](https://user-images.githubusercontent.com/37494407/126114600-a052aeee-68ed-4f92-b45a-e5f0c8dfb5b7.png)

    - 주인공이 아이템을 카트에 담을경우 O표시가 나타나고 아이템이 사라진다.
    - 그 뒤 남은 아이템 중 랜덤으로 바꿔준다.
    
    
***

- Mart 구성 정보
  - Image
    - 씬에 사용되는 이미지들 저장
  - Scripts
    - Mart_ControlOX.cs : 정답 또는 오답일경우 OX를 띄우는 스크립트
    - Mart_ControlUI.cs : 정답관리, 남은 아이템중 랜덤으로 아이템을 정해주는 스크립트
    - Mart_Kart.cs : 카트 오브젝트에 관련된 스크립트
    - Mart_MouseDrag.cs : 드래그 기능을 추가시켜주는 스크립트
    - Mart_RandomItem.cs : 정답을 띄우는 스크립트

***



