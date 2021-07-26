/*
 * - Name : SoundManager.cs
 * - Writer : 최대준
 * - Content : SoundManager은 효과음을 관리하기 위해서 만든 오브젝트 클래스이다. 인스펙터 창에서 AudioClip과 name을 파라미터 값으로 받아서 다른 오브젝트에서 본 클래스의 함수인 playSound 함수를 호출하면 효과음을 출력하도록 되어 있다.
* - Where the code is applied : /Asset/Utils/Scripts/SoundManger.cs
 *             -사용법-
 *            1. 효과음이 필요한 행위를 구현하는 스크립트 코드에서, 이 사운드매니저 클래스를 가져온다음, playSound로 설정해놓은 AudioClip의 name 이나 id를 입력해주면 효과음이 출력된다.
 * 
 *            -작성 기록-
 *            2021-07-19 : 제작 완료
 *            2021-07-20 : 주석 처리
 *            2021-07-23 : SoundManager 추가.
 *
 * - SoundManager Member Variable 
 * SoundManager msm_soundManager : 효과음 관리하는 클래스이다.
 * Sound[] mssl_saveSounds : 인스펙터창에서 사용자가 설정하는 struct로 안을 보자면, {
     public string name : clip의 이름을 나타내주는 변수이다.
     public AudioClip sound : 효과음 파일을 가지는 변수이다.
 }
 * AudioSource mas_outputSounds : 씬에서 실질적으로 효과음을 출력해주는 변수이다.
 * 
 * - SoundManager Member Function
 * Start() : SoundManager 오브젝트를 가져오는 초기화 코드가 있다.
 * playSound() : 본 함수는 매개변수로 id 나 name을 매개변수로 받으면, (본 함수는 오버로딩 되어 있다.) mas_outputSounds에서 PlayOneShot함수를 호출하여 씬에 효과음을 출력한다.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 인스펙터 창에 struct 형태가 나타나도록 하기 위해서는 아래와 같이 [System.Serializable]이라는 특별한 어노테이션이 필요하다.
[System.Serializable]
public struct Sound {
    public string name;
    public AudioClip sound;
}   
// 본 클래스는 효과음을 담당하는 클래스이다.
public class SoundManager : MonoBehaviour
{
    public Sound[] mssl_saveSounds;
    private AudioSource mas_outputSounds;
    // AudioSource 컴포넌트를 가져온다.
    void Start() {
        mas_outputSounds = this.GetComponent<AudioSource>();
    }
    // 인스펙터 창에서 저장한 clip 중 id or name이 같은 
    public void playSound(int id) {
        mas_outputSounds.PlayOneShot(mssl_saveSounds[id].sound);
    }
    public void playSound(string soundName) {
        for(int i = 0; i < mssl_saveSounds.Length; i++) {
            if(mssl_saveSounds[i].name == soundName)
                mas_outputSounds.PlayOneShot(mssl_saveSounds[i].sound);
        }
    }
}
