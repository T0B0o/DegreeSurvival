using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACpercentCounter : MonoBehaviour {

    public Text percentText;
    public Text pinchCall;
    int allDegree;
    int acDegree;
    public static int percent;
    
	// Use this for initialization
	void Start () {
        percentText.text = "100%";
        acDegree = allDegree = 0;
        percent = 100;
        pinchCall.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        allDegree = StudentGenerator.studentNum;
        acDegree = allDegree-FallCounter.FallNum;
        if(allDegree>0) percent =(int)((float)acDegree / (float)allDegree*100);
        percentText.text = percent.ToString() + "%";
        if (percent < 70)
        {
            pinchCall.gameObject.SetActive(true);
        }
        else
        {
            pinchCall.gameObject.SetActive(false);
        }
	}
}
