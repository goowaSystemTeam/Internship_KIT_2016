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

    /*------------
	管理
	------------*/
    public string standName; //現在の立ち位置
    public string myItem;


    // アイテムボタン
    public GameObject itemBtn_key;

    void Start()
    {
        standName = "centerN"; //現在の立ち位置 =　北向き
        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 90, 0);

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
             //3Dオブジェクトをクリックした時の処理　ここはまたあとで
            }
            else
            { // UIをさわった
                switch (eventsystem.currentSelectedGameObject.name)
                {
                    case "turnLBtn":
                        turnL();
                        break;
                }
            }
        }
    }
    public void turnL()
    {
        switch (standName)
        {
            case "centerN":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 270, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-1, 7, -20);
                standName = "centerW";
                break;
            case "centerW":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 180, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-1, 7, -20);
                standName = "centerS";
                break;
            case "centerS":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-5, 7, -20);
                standName = "centerE";
                break;
            case "centerE":
                GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 0, 0);
                GameObject.Find("mainCamera").transform.position = new Vector3(-6, 7, -26);
                standName = "centerN";
                break;
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
                case "desk/desk/Door2":
                    Debug.Log("机の扉を開けた");
                    item_key.SetActive(true);
                    break;

                case "Door":
                    if (myItem == "key")
                    {
                        iTween.MoveTo(GameObject.Find("Door"), iTween.Hash(
                            "x", -40, "time", 0.4, "islocal", true
                        ));
                    }
                    break;

                case "key":
                    item_key.SetActive(false);
                    itemBtn_key.SetActive(true);
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