using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentCount : MonoBehaviour {

    public Text Count;
    int count;

	// Use this for initialization
	void Start () {
        Count.text = "0";
        count = -1;
	}
	
	// Update is called once per frame
	void Update () {
        count = StudentGenerator.studentNum;
        Count.text=count.ToString();
	}
}
