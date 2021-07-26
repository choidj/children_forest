# 잭과콩나무 - Episode3
***
 - 작성 및 제작 : 김명현
 - 언어 : C#
***
 - Update Log
     - 21.07.13 : 코드 작성완료
     - 21.07.16 : 이벤트시 화살표로 방향성 추가, 씬 연결
     - 21.07.19 : 해상도 변경 및 스크립트 크기 수정
     - 21.07.26 : 효과음 추가
***
 - 구동화면 및 내용

![잭과콩나무 episode3](https://user-images.githubusercontent.com/37494407/126118568-05882a3c-5841-4e20-9f0b-4c33d248caa7.png)


    - 에피소드3 첫 구동화면이다.
    - 화면을 터치하며 스토리를 이어간다.
    
![잭과콩나무 episode3 이벤트1](https://user-images.githubusercontent.com/37494407/126121823-e65947b9-6944-4ca1-a09d-18888a2e80ce.png)

    - 이벤트화면
    - 무엇을 드래그 해야 되는지 화살표를 통해 가르켜준다.
    
 ![잭과콩나무 episode3 이벤트2](https://user-images.githubusercontent.com/37494407/126121935-bcfb0c8b-bf70-4b31-b10e-069c00c66072.png)

    - 오브젝트 드래그시 기존 화살표가 사라지고 누구한테 드래그를 해야되는지 나타낸다.
    
    
    

***


- Jack (Episode3) 구성 정보
  - Image
    - 씬에 사용되는 이미지들 저장
  - Scripts
    - Jack3_Blink.cs : 반짝이는 효과를 내는 스크립트, 화살표에 적용
    - Jack3_EventController.cs : 메인 스크립트, 이벤트를 설정하고 진행하는 스크립트
    - Jack3_GFScript.cs : 할아버지 대사 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack3_GrandFather.cs : 할아버지 오브젝트에 대한 스크립트, 할아버지 오브젝트에 대한 충돌 처리 등을 담당하는 스크립트
    - Jack3_Jack.cs : 잭에 대한 스크립트, 잭 오브젝트에 대한 충돌 처리 등을 담당하는 스크립트
    - Jack3_JackScript.cs : 잭 대사 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack3_MainScript.cs : 메인 대사 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack3_MissionScript.cs : 이벤트 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack3_MouseDrag.cs : 드래그가 가능하게 해주는 함수, Flag를 통해 드래그중인지 확인하는 용도로도 사용되는 스크립트
  - Jack_Epi3.unity : 씬 파일

***

 - 참고사항

1. 대사를 수정하고싶은 경우

    - Jack3_ㅁㅁㅁㅁScript.cs 안의 ms_ScriptText 변수에 대사를 작성해준다. 대사간 구분자는 @로 작성하였으니 문장이끝나는부분에 @를 작성해준다.
    - ㅁㅁㅁㅁ는 스크립트의 주체에따라 들어가 설정해주면 된다.

2. 스크립트를 띄우는 방법

    - 메인 스크립트인 Jack3_EventController.cs 에서 각 스크립트를 오브젝트를 통해 연결을하고 v_NextScript() 함수를 작동하면 다음 스크립트가 나타난다.

3. 대화를 지우는 방법

    - v_NoneScript()함수를 사용하면 된다.

***

