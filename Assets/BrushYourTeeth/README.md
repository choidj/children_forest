# 양치게임
***
 - 작성 및 제작 : 김명현
 - 언어 : C#
***
 - 수정 기록
  - 21.07.07 : 코드 작성완료
  - 21.07.16 : 인코딩형식 UTF8로 수정

***

- BrushYourTeeth 구성 정보
  - Animation
    - Virus[1,2]_Attack.anim : 세균을 터치하였을때 작동되는 에니메이션
    - Virus[1,2]_Die.anim : 세균 죽었을때 에니메이션
    - Virus[1,2]_Idle.anim : 평상시 에니메이션
    - Virus1_Prefab.controller : 세균1 에니메이션 동작 연결
    - Virus2.controller : 세균2 에니메이션 동작 연결
  - Image
    - 씬에 사용되는 이미지들 저장
  - Scripts
    - BrushYourTeeth_Virus[1,2].cs : 세균설정 관련 스크립트
    - BrushYourTeeth_Virus[1,2]Generator.cs : 세균 생성 스크립트
    - BrushYourTeeth_ControlUI.cs : 안내 UI 설정 스크립트
  - clean_teeth_scene.unity : 씬 파일

***

 - 참고사항

   - ※주의 : 총 남은 세균 수를 감소 시킨 경우 따로 각 세균의 생성 개수를 변경해 줘야된다.


1. 남은 세균 수를 감소하고 싶은경우

    - BrushYourTeeth_ControlUI.cs의 mn_LeftVirus 변수 값 변경

2. 몇번 터치하면 세균이 퇴치될 것인지 수정하고 싶은경우

    - BrushYourTeeth_Virus[1,2].cs의 mn_Virus[1,2]_HP 변수 값 변경

3. 세균의 생성주기를 변경하고 싶은경우

    - BrushYourTeeth_Virus[1,2]Generator.cs 의 mf_span 변수 값 변경 (단위 : 초)

4. 생성되는 세균 수를 변경하고 싶은경우

    - BrushYourTeeth_Virus[1,2]Generator.cs 의 update문 안의 if문 숫자 변경




