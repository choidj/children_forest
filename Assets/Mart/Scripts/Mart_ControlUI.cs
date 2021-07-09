using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * -Name : Mart_ControlUI.cs
 * -Content : Manage random value generation and item change flags
 * 
 * -Variable 
 * mba_MarketRandomItemArr : An arrangement to check if the item is in the cart.
 * mn_RandomValue
 * mb_ChangeItemFlag
 * n_i
 * 
 * 
 * -Function
 * v_MartCheckRandomItemArr()
 * n_MartRandomItemValue()
 * n_HowManyleftArr()
 * v_ChangeFlagTrue()
 * v_ChangeFlagFalse()
 * b_checkFlag()
 * 
 */


public class Mart_ControlUI : MonoBehaviour{
    private bool[] mba_MarketRandomItemArr = new bool[6];
    private int mn_RandomValue;


    private bool mb_ChangeItemFlag;
    

    void Start(){
        mb_ChangeItemFlag = false;

        for (int n_i = 0; n_i < 6; n_i++){
            mba_MarketRandomItemArr[n_i] = false;
        }
    }

    void Update(){

    }

    //Ʈ�簪 �Է� �Լ�
    public void v_MartCheckRandomItemArr(int num){
        mba_MarketRandomItemArr[num] = true;
        Debug.Log(num + "��° �迭 Ʈ�簪 �Է�");

    }


    //������ �̴� �Լ�
    public int n_MartRandomItemValue(){

        while (true){
            mn_RandomValue = Random.Range(0, 6);
            if (mba_MarketRandomItemArr[mn_RandomValue] == false){
                break;
            }
        }
        return mn_RandomValue;
    }

    public int n_HowManyleftArr(){         //���� false��
        int left = 0;
        for (int n_i = 0; n_i < 6; n_i++){
            if (mba_MarketRandomItemArr[n_i] == true){
                Debug.Log(n_i + "��° �迭�� true");
            }
            if (mba_MarketRandomItemArr[n_i] == false){
                Debug.Log(n_i + "��° �迭�� false");
                left += 1;
            }
        }
        Debug.Log(left + "�� ���ҽ��ϴ�.");
        return left;
    }

    public void v_ChangeFlagTrue(){
        mb_ChangeItemFlag = true;
        Debug.Log("Flag�� True");
    }

    public void v_ChangeFlagFalse(){
        mb_ChangeItemFlag = false ;
        Debug.Log("Flag�� False");
    }

    public bool b_checkFlag(){
        return mb_ChangeItemFlag;
    }


}
