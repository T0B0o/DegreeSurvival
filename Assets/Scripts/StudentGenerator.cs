using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentGenerator : MonoBehaviour
{

    public GameObject[] animals;//生徒取得配列
    public Camera mainCamera;//カメラ取得用変数
    public float pivotHeight = 2.0f;//生成位置の基準

    public static int studentNum = 0;//生成された生徒の人数を保管

    public static int FallNum = 0;

    public static bool isGameOver = false;//ゲームオーバー判定
   
    private GameObject geneStudent;//生徒生成（単品）
    public  static bool isGene;//生成されているか
    public  static bool isFall;//生成された生徒が落下中か

  
    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Init()
    {
        studentNum = 0;
        FallNum = 0;
        isGameOver = false;
        Student.isMoves.Clear();//移動してる生徒のリストを初期化
        StartCoroutine(StateReset());
    }

    // 毎フレーム呼び出される(60fpsだったら1秒間に60回)
    void Update()
    {

        if (isGameOver)
        {
            return;//ゲームオーバーならここで止める
        }

        if (CheckMove(Student.isMoves))
        {
            return;//移動中なら処理はここまで
        }

        if (!isGene)//生成されてるものがない
        {
            StartCoroutine(GenerateStudent());//生成するコルーチンを動かす
            isGene = true;
            return;
        }

        Vector2 v = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, pivotHeight);

        if (Input.GetMouseButtonUp(0))//もし（マウス左クリックが離されたら）
        {
            if (!RotateButton.onButtonDown)//ボタンをクリックしていたら反応させない
            {
                geneStudent.transform.position = v;
                geneStudent.GetComponent<Rigidbody2D>().isKinematic = false;//――――物理挙動・オン
                isFall = true;//落ちて、どうぞ
                FallCounter.triggred = false;
                studentNum++;//生徒の生成
            }
            RotateButton.onButtonDown = false;//マウスが上がったらボタンも離れたと思う
        }
        else if (Input.GetMouseButton(0))//ボタンが押されている間
        {
            geneStudent.transform.position = v;
        }

    }

    /// <summary>
    /// 生成・落下状態をリセットするコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator StateReset()
    {
        while (!isGameOver)
        {
            yield return new WaitUntil(() => isFall);//落下するまで処理が止まる
            yield return new WaitForSeconds(0.1f);//少しだけ物理演算処理を待つ（ないと無限ループ）
            isFall = false;
            isGene = false;
        }
    }

    /// <summary>
    /// 生徒の生成コルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateStudent()
    {
      
        while (CameraController.isCollision)
        {

            yield return new WaitForEndOfFrame();//フレームの終わりまで待つ（無いと無限ループ）
            mainCamera.transform.Translate(0, 0.1f, 0);//カメラを少し上に移動
            pivotHeight += 0.1f;//生成位置も少し上に移動
        }
        geneStudent = Instantiate(animals[Random.Range(0, animals.Length)], new Vector2(0, pivotHeight), Quaternion.identity);//回転せずに生成
        geneStudent.GetComponent<Rigidbody2D>().isKinematic = true;//物理挙動をさせない状態にする
    }

    /// <summary>
    /// 生徒の回転
    /// ボタンにつけて使います
    /// </summary>
    public void RotateStudent()
    {
        if (!isFall)
            geneStudent.transform.Rotate(0, 0, -30);//30度ずつ回転
    }

    /// <summary>
    /// リトライボタン
    /// </summary>
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// 移動中かチェック
    /// </summary>
    /// <returns></returns>
    bool CheckMove(List<Moving> isMoves)
    {
        if (isMoves == null)
        {
            return false;
        }
        foreach (Moving b in isMoves)
        {
            if (b.isMove)
            {
                //Debug.Log("移動中(*'ω'*)");
                return true;
            }
        }
        return false;
    }
}