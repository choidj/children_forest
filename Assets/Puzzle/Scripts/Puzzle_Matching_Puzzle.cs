using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Matching_Puzzle : MonoBehaviour{
    public bool mb_classifyWhetherAns = false; //matching되기 전 
    //public Sprite[] msa_changeAnsImg = new Sprite[9];
    public AudioClip audiomatching;
    public AudioClip audiounmatching;
    AudioSource audioSource;

    private void Start(){
        if(!mb_classifyWhetherAns){
            transform.position = new Vector3(Random.Range(19, 26), Random.Range(3, 11), 0);//자리 랜덤 선정
        }
    }

    void OnTriggerEnter2D(Collider2D cCollideObject){
        if (cCollideObject.name[cCollideObject.name.Length - 1] == this.name[this.name.Length - 1]){//매칭퍼즐과 매칭퍼즐과모양이같은퍼즐의 이름 맨 뒤(숫자)가 같은 경우
            if (mb_classifyWhetherAns){ //정답
                //흐렷던 퍼즐조각을 선명하게 변경
                Color tempColor = gameObject.GetComponent<SpriteRenderer>().color;
                tempColor.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = tempColor;

                Invoke("Awake", 1f); //Awake함수 호출
            }
            else{ //오류

                Destroy(this.gameObject);
                //Invoke("Awake", 1f); //Awake함수 호출
            }
        }
    }

    void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();
        }
}