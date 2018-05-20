using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCounter : MonoBehaviour {
    public static bool triggred = false;
    public static int FallNum = 0;

    // Use this for initialization
    void Start () {
        FallNum = 0;
        triggred = false;
}
	
	// Update is called once per frame
	void Update () {
		
	}


 

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FallNum++;
        if (!triggred)
        {
            triggred = true;
            StudentGenerator.isGene = false;
            float timer = 0f;
            collision.gameObject.SetActive(false);
            Student.isMoves.Clear(); //移動してる生徒のリストを初期化するでゴンス
        }
    }
}
