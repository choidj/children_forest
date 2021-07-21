# 잭과콩나무 - Episode5
***
 - 작성 및 제작 : 김명현
 - 제작 언어 : C#
***
 - Update Log
     - 21.07.15 : 코드 작성완료
     - 21.07.16 : 이벤트시 화살표로 방향성 추가, 씬 연결
     - 21.07.19 :  해상도 변경 및 스크립트 크기 수정

***
 - 구동화면 및 내용

![잭과콩나무5](https://user-images.githubusercontent.com/37494407/126125833-38b505f3-daa7-41d5-bbb1-eb477f2d5a7a.png)

    - 에피소드5 첫 구동화면이다.
    - 화면을 터치하며 스토리를 이어간다.
    
![잭과콩나무5 이벤트1](https://user-images.githubusercontent.com/37494407/126125854-8ed674fc-032c-4081-903a-6a3ac59c72cf.png)

    - 이벤트화면
    - 무엇을 드래그 해야 되는지 화살표를 통해 가르켜준다.
    
![잭과콩나무5 이벤트2](https://user-images.githubusercontent.com/37494407/126125872-dd18864b-59c4-4a2d-8d93-9fb6dbcca20a.png)

    - 오브젝트 드래그시 기존 화살표가 사라지고 누구한테 드래그를 해야되는지 나타낸다.

***


- Jack (Episode5) 구성 정보
  - Image
    - 씬에 사용되는 이미지들 저장
  - Scripts
    - Jack5_Blink.cs : 반짝이는 효과를 내는 스크립트, 화살표에 적용
    - Jack5_EndPoint.cs : 콩나물 끝 지점 오브젝트에 대한 스크립트, 오브젝트에 대한 충돌 처리 등을 담당하는 스크립트
    - Jack5_EventController.cs : 메인 스크립트, 이벤트를 설정하고 진행하는 스크립트
    - Jack5_JackScript.cs : 잭 대사 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack5_MainScript.cs : 메인 대사 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack5_MissionScript.cs : 이벤트 스크립트, 스크립트를 설정해두고 함수를 통해 다음 스크립트가 작동할수 있게 설정
    - Jack5_MouseDrag.cs : 드래그가 가능하게 해주는 함수, Flag를 통해 드래그중인지 확인하는 용도로도 사용되는 스크립트
  - Jack_Epi5.unity : 씬 파일

***

 - 참고사항

1. 대사를 수정하고싶은 경우

    - Jack5_ㅁㅁㅁㅁScript.cs 안의 ms_ScriptText 변수에 대사를 작성해준다. 대사간 구분자는 @로 작성하였으니 문장이끝나는부분에 @를 작성해준다.
    - ㅁㅁㅁㅁ는 스크립트의 주체에따라 들어가 설정해주면 된다.

2. 스크립트를 띄우는 방법

    - 메인 스크립트인 Jack5_EventController.cs 에서 각 스크립트를 오브젝트를 통해 연결을하고 v_NextScript() 함수를 작동하면 다음 스크립트가 나타난다.

3. 스크립트를 지우는 방법

    - v_NoneScript()함수를 사용하면 된다.

***
