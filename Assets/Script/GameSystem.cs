using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class GameSystem : MonoBehaviour
{

    public GameObject mainCamera; //カメラの定義
    public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義

    //クリックでレイ（光線）とばす
    public Ray ray;
    public Ray rayItem;
    public RaycastHit hit;
    public GameObject selectedGameObject;

    //アイテム
    public GameObject item_key;
    public GameObject Door2;
    public GameObject Door3;


    /*------------
	管理
	------------*/
    public string myItem;

    // アイテムボタン
    public GameObject itemBtn_key;

    // Use this for initialization
    void Start()
    {
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_key = GameObject.Find("key");
        item_key.SetActive(false);

        GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key = GameObject.Find("itemBtn_key");
        itemBtn_key.SetActive(false);
        myItem = "noitem";
    }

    // Update is called once per frame
    void Update()
    {
        /*--------------
        画面クリック処理
        --------------*/
        if (Input.GetMouseButtonUp(0))
        { //左クリック
            if (eventsystem.currentSelectedGameObject == null)
            {// UI以外（3D）をさわった
                searchRoom(); //3Dオブジェクトをクリックした時の処理
            }
        }
    }

    public void searchRoom()
    {
        selectedGameObject = null;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10000000, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "Door2":
                    Debug.Log("ドアを押した");
                    var time = 3f;
                    iTween.RotateTo(Door2, iTween.Hash(
                     "z", -90,
                    "time", time,
                    "islocal", true
                      ));
                    item_key.SetActive(true);
                    break;
                case "key":
                    item_key.SetActive(false);
                    itemBtn_key.SetActive(true);
                    break;
                case "Door3":
                    if (myItem == "key")
                    {
                        Debug.Log("ドアを押した");
                        var time1 = 3f;
                        iTween.RotateTo(Door3, iTween.Hash(
                         "y", 90,
                        "time", time1,
                        "islocal", true
                          ));
                    }
                    break;
            }
        }
        rayItem = GameObject.Find("itemListCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayItem, out hit, 10000000, 1 << 9))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "itemBtn_key_plane":
                    if (myItem == "key")
                    {
                        GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
                        myItem = "noitem";
                    }
                    else
                    {
                        GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = true;
                        myItem = "key";
                    }
                    break;
            }
        }
    }
}
