using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearOrGameOver : MonoBehaviour {

    const int ALL_DEG = 20;
    public Text DegreeNum;
    public Text Percent;
    public Text CLEAR;
    public Text GAMEOVER;
    public Button Retry;
    public Button End;
    public Text EndText;
    public GameObject Tottaro;
    public GameObject Rakudaitaro;

    int score;
    int percent;
    public static bool GOSOTUGYO=false;

	// Use this for initialization
	void Start () {
        GOSOTUGYO = false;
        score = percent =0;
        CLEAR.gameObject.SetActive(false);
        GAMEOVER.gameObject.SetActive(false);
        Retry.gameObject.SetActive(false);
        End.gameObject.SetActive(false);
        Tottaro.gameObject.SetActive(false);
        Rakudaitaro.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        percent = ACpercentCounter.percent;
        score = int.Parse(DegreeNum.text);
        if (score > ALL_DEG)
        {
            if (percent >= 70)
            {
                GOSOTUGYO = true;
            }
            StudentGenerator.isGameOver = true;

            Retry.gameObject.SetActive(true);
            End.gameObject.SetActive(true);
            if (GOSOTUGYO)
            {
                CLEAR.gameObject.SetActive(true);
                EndText.text = "ご卒業？";
                Tottaro.gameObject.SetActive(true);
            }
            else
            {
                GAMEOVER.gameObject.SetActive(true);
                EndText.text = "自主退学？";
                Rakudaitaro.gameObject.SetActive(true);
            }
        }


	}
}
