/*
 * - Name : Jack9_Gentreasure.cs
 * - Writer : �����
 * - Content : ����ᳪ�� ���Ǽҵ�9 - ������ ���� ��ũ��Ʈ
 * 
 *           
 *            
 *            
 *            
 *            
 *            
 *            -�ۼ� ���-
 *            2021-07-15 : ���� �Ϸ�
 *            
 *            
 *            
 *            
 * 
 * -Variable 
 * 
 * -Function
 * 
 * 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack9_Gentreasure : MonoBehaviour
{
    public GameObject mg_Chicken_Prefab;
    public GameObject mg_Harp_Prefab;
    public GameObject mg_Treasure_Prefab;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void v_GenTreasure()
    {
        GameObject g_GenChicken = Instantiate(mg_Chicken_Prefab) as GameObject;
        GameObject g_GenHarp = Instantiate(mg_Harp_Prefab) as GameObject;
        GameObject g_GenTreasure = Instantiate(mg_Treasure_Prefab) as GameObject;
    }
}
