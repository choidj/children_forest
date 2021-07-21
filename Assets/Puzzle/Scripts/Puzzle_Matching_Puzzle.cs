/*
  * - Name : Puzzle_Matching_Puzzle.cs
  * - Writer : 이윤교
  * - Content : 퍼즐을 맞추는 스크립트
  * 
  *            -작성 기록-
  *            2021-07-19 : 제작 완료
  *
  * 
  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour{
    bool mb_classifyWhetherAns = false; //matching되기 전 
    //public Sprite[] msa_changeAnsImg = new Sprite[9];
    public GameObject matching;
    public GameObject answer;
    AudioSource auSource;

    private void Start(){
        if(!mb_classifyWhetherAns){
            matching.transform.position = new Vector3(Random.Range(19, 26), Random.Range(3, 11), 0);//자리 랜덤 선정
        }
    }

    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){//매칭퍼즐과 매칭퍼즐과모양이같은퍼즐의 이름 맨 뒤(숫자)가 같은 경우
            if (!mb_classifyWhetherAns){ //정답
                //흐렷던 퍼즐조각을 선명하게 변경
                Color tempColor = answer.GetComponent<SpriteRenderer>().color;
                tempColor.a = 1f;
                answer.GetComponent<SpriteRenderer>().color = tempColor;
                Destroy(matching);
                auSource.Play();
            }
            else{ //오류
                Destroy(matching);
                //Destroy(this.gameObject);
                //Invoke("Awake", 1f); //Awake함수 호출
            }
        }
    }

    void Awake()
        {
            auSource = GetComponent<AudioSource>();
        }
}