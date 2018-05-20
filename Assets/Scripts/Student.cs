using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{

    public static List<Moving> isMoves = new List<Moving>();//移動してる生徒がいないかチェックするリスト

    Rigidbody2D rigid;
    Moving moving = new Moving();//移動チェック変数

    public bool isFallDegree=false;

    /// <summary>
    /// リストに追加&Rigidbody2D取得
    /// </summary>
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        isMoves.Add(moving);
    }

    /// <summary>
    /// 固定フレームレートで移動チェック
    /// </summary>
    void FixedUpdate()
    {
        if (rigid.velocity.magnitude > 0.01f)//少しでも移動していれば動いてると判定
        {
            //Debug.Log("動いてる");
            moving.isMove = true;
        }
        else
        {
            //Debug.Log("動いてねぇッピ！");
            moving.isMove = false;
        }

    }

}

/// <summary>
/// 移動チェッククラス
/// </summary>
public class Moving
{
    public bool isMove;
}