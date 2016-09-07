using UnityEngine;
using System.Collections;


public class Door : MonoBehaviour
{
    // 左クリックしたオブジェクトを取得する関数(3D)
    public GameObject getClickObject()
    {
        GameObject result = null;
        // 左クリックされた場所のオブジェクトを取得
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                string objectTag = hit.collider.gameObject.tag;
            }
        }
        return result;
    }


    /// <summary>
    /// 表示アニメーション
    /// </summary>
    /// 

    string t1 = "Target";
    string t2 = "getClickObject()";

    void Update()
    {
        if (t2 == t1 )
        {
            // 以下オブジェクトがクリックされた時の処理
            /* 
             * --- iTween.Hash 説明 ---
             * position		: 変化量
             * time			: アニメーション完了までの時間
             * easeType 		: アニメーションの仕方(リファレンス参照)
             * oncomplete		: アニメーション終了時に呼ぶメソッド名
             * oncompletetarget 	: アニメーション終了時に呼ぶメソッドを受け取るオブジェクト
             * 
             * --- iTween 説明 ---
             * MoveTo 	: 現在の位置から指定の位置まで移動
             * 引数1 	: 動かしたいオブジェクト
             * 引数2 	: 動かす挙動を設定するテーブル
             */

            var time = 3f;

            // パターン２ [HashをiTweenの中で宣言いていく方法]

            // 回転
            iTween.RotateTo(gameObject, iTween.Hash(
                "y", 90,
                "time", time
            ));
        }
    }
}