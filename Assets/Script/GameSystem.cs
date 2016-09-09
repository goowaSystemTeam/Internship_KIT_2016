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
    public GameObject item_key_gold;
    public GameObject item_Pistol;
    public GameObject Door1;
    public GameObject Door11;
    public GameObject Door2;
    public GameObject Door21;
    public GameObject Door3;
    public GameObject cabinet_door1;
    public GameObject cabinet_Door1;
    public GameObject cabinet_door2;
    public GameObject cabinet_Door2;
    public GameObject Door;
    public GameObject poster1;
    public GameObject item_poster1;
    public GameObject poster2;
    public GameObject item_poster2;
    public GameObject Directional_Light1;
    public GameObject hint;
    public GameObject item_hint;
    public GameObject item_book;
    public GameObject book;
    public GameObject dutchdragon3;


    /*------------
	管理
	------------*/
    public string myItem;

    // アイテムボタン
    public GameObject itemBtn_key;
    public GameObject itemBtn_Pistol01;
    public GameObject itemBtn_key_gold;

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

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_Pistol = GameObject.Find("Pistol");
        item_Pistol.SetActive(false);

        GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_Pistol01 = GameObject.Find("itemBtn_Pistol01");
        itemBtn_Pistol01.SetActive(false);
        myItem = "noitem";

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_poster1 = GameObject.Find("item_poster1");
        item_poster1.SetActive(false);

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_poster2 = GameObject.Find("item_poster2");
        item_poster2.SetActive(false);

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_hint = GameObject.Find("item_hint");
        item_hint.SetActive(false);

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_book = GameObject.Find("item_book");
        item_book.SetActive(false);

        GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
        itemBtn_key_gold = GameObject.Find("itemBtn_key_gold");
        itemBtn_key_gold.SetActive(false);
        myItem = "noitem";

        eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        item_key_gold = GameObject.Find("key_gold");
        item_key_gold.SetActive(false);

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
        else if(Input.GetKeyUp("1"))
        {
            if (eventsystem.currentSelectedGameObject == null)
            {// UI以外（3D）をさわった
                searchRoom(); //3Dオブジェクトをクリックした時の処理
            }
        }
        else if(Input.GetKeyUp("2"))
        {
            if (eventsystem.currentSelectedGameObject == null)
            {// UI以外（3D）をさわった
                searchRoom(); //3Dオブジェクトをクリックした時の処理
            }
        }
        else if (Input.GetKeyUp("3"))
        {
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
        if (Physics.Raycast(ray, out hit, 2, 1 << 8))
        {
            selectedGameObject = hit.collider.gameObject;
            switch (selectedGameObject.name)
            {
                case "Door1":
                    Debug.Log("ドア1を押した");
                    var time1 = 3f;
                    iTween.RotateTo(Door11, iTween.Hash(
                     "z", 90,
                    "time", time1,
                    "islocal", true
                      ));
                    item_Pistol.SetActive(true);
                    break;
                case "Pistol":
                    Destroy(item_Pistol);
                    itemBtn_Pistol01.SetActive(true);
                    break;
                case "Door2":
                    if (myItem == "key_gold")
                    {
                        Debug.Log("ドア2を押した");
                        var time2 = 3f;
                        iTween.RotateTo(Door21, iTween.Hash(
                         "z", -90,
                        "time", time2,
                        "islocal", true
                          ));
                        item_key.SetActive(true);
                        Destroy(itemBtn_key_gold);
                        Destroy(GameObject.Find("itemBtn_key_gold_plane"));
                    }
                    break;
                case "key":
                    Destroy(item_key);
                    itemBtn_key.SetActive(true);
                    break;
                case "Door":
                    if (myItem == "key")
                    {
                        Debug.Log("ドアを押した");
                        var time3 = 3f;
                        iTween.RotateTo(Door3, iTween.Hash(
                         "y", 90,
                        "time", time3,
                        "islocal", true
                          ));
                        Destroy(itemBtn_key);
                        Destroy(GameObject.Find("itemBtn_key_plane"));
                    }
                    break;
                case "cabinet_door1":
                    Debug.Log("キャビネットドア1を押した");
                    var time4 = 3f;
                    iTween.RotateTo(cabinet_Door1, iTween.Hash(
                     "z", 90,
                    "time", time4,
                    "islocal", true
                      ));
                    break;
                case "key_gold":
                    Destroy(item_key_gold);
                    itemBtn_key_gold.SetActive(true);
                    break;
                case "cabinet_door2":
                    Debug.Log("キャビネットドア2を押した");
                    var time5 = 3f;
                    iTween.RotateTo(cabinet_Door2, iTween.Hash(
                     "z", -90,
                    "time", time5,
                    "islocal", true
                      ));
                    break;
                case "poster1":
                    selectedGameObject.name = "poster1";
                    Debug.Log("ポスター1を押した");
                    item_poster1.SetActive(true);
                    Directional_Light1.SetActive(false);
                    break;
                case "item_poster1":
                    selectedGameObject.name = "item_poster1";
                    Debug.Log("ポスター1を押した");
                    item_poster1.SetActive(false);
                    Directional_Light1.SetActive(true);
                    break;
                case "poster2":
                    selectedGameObject.name = "poster2";
                    Debug.Log("ポスター2を押した");
                    item_poster2.SetActive(true);
                    Directional_Light1.SetActive(false);
                    break;
                case "item_poster2":
                    selectedGameObject.name = "item_poster2";
                    Debug.Log("ポスター2を押した");
                    item_poster2.SetActive(false);
                    Directional_Light1.SetActive(true);
                    break;
                case "hint":
                    selectedGameObject.name = "hint";
                    Debug.Log("ヒントを押した");
                    item_hint.SetActive(true);
                    Directional_Light1.SetActive(false);
                    break;
                case "item_hint":
                    selectedGameObject.name = "item_hint";
                    Debug.Log("ヒントを押した");
                    item_hint.SetActive(false);
                    Directional_Light1.SetActive(true);
                    break;
                case "book":
                    selectedGameObject.name = "book";
                    Debug.Log("日記を押した");
                    item_book.SetActive(true);
                    Directional_Light1.SetActive(false);
                    break;
                case "item_book":
                    selectedGameObject.name = "item_book";
                    Debug.Log("日記を押した");
                    item_book.SetActive(false);
                    Directional_Light1.SetActive(true);
                    break;
                case "dutchdragon3":
                    selectedGameObject.name = "dutchdragon3";
                    Debug.Log("植物を押した");
                    item_key_gold.SetActive(true);
                    var time6 = 6f;
                    iTween.MoveTo(dutchdragon3, iTween.Hash(
                     "x", 3,
                    "time", time6,
                    "islocal", true
                    ));
                    break;
            }
        }
        /*rayItem = GameObject.Find("itemListCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayItem, out hit, 10000000, 1 << 9))
        {
            selectedGameObject = hit.collider.gameObject;*/
        /* switch (selectedGameObject.name)
     {
         case "itemBtn_key_plane":*/

        if (myItem == "key" && Input.GetKeyUp("1") && itemBtn_key!=null)
        {
            Debug.Log("1を押した");
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
            myItem = "noitem";
        }

        else if (myItem == "key" && Input.GetKeyUp("2") && item_Pistol == null)
        {
            Debug.Log("2を押した");
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = true;
            myItem = "Pistol01";
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "key" && Input.GetKeyUp("3") && item_key_gold == null && itemBtn_key_gold != null)
        {
            Debug.Log("3を押した");
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key_gold";
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "Pistol01" && Input.GetKeyUp("1") && item_key == null && itemBtn_key != null)
        {
            Debug.Log("1を押した");
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key";
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "Pistol01" && Input.GetKeyUp("2"))
        {
            Debug.Log("2を押した");
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
            myItem = "noitem";
        }

        else if (myItem == "Pistol01" && Input.GetKeyUp("3") && item_key_gold == null && itemBtn_key_gold != null)
        {
            Debug.Log("3を押した");
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key_gold";
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "key_gold" && Input.GetKeyUp("1") && item_key == null && itemBtn_key != null)
        {
            Debug.Log("1を押した");
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key";
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "key_gold" && Input.GetKeyUp("2") && item_Pistol == null)
        {
            Debug.Log("2を押した");
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = true;
            myItem = "Pistol01";
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "key_gold" && Input.GetKeyUp("3") && itemBtn_key_gold != null)
        {
            Debug.Log("3を押した");
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
            myItem = "noitem";
        }

        else if (myItem == "noitem" && Input.GetKeyUp("1") && item_key == null && itemBtn_key != null)
        {
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key";
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "noitem" && Input.GetKeyUp("2") && item_Pistol == null)
        {
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = true;
            myItem = "Pistol01";
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = false;
        }

        else if (myItem == "noitem" && Input.GetKeyUp("3") && item_key_gold == null && itemBtn_key_gold != null)
        {
            GameObject.Find("itemBtn_key_gold_plane").GetComponent<Renderer>().enabled = true;
            myItem = "key_gold";
            GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
        }

        //break;
        // case "itemBtn_Pistol01_plane":
        /*if (myItem == "Pistol01" && Input.GetMouseButtonUp(0))
        {
            Debug.Log("2を押した");
            GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = false;
            myItem = "noitem";
        }*/
        /* else
         {
             GameObject.Find("itemBtn_Pistol01_plane").GetComponent<Renderer>().enabled = true;
             myItem = "Pistol01";
             GameObject.Find("itemBtn_key_plane").GetComponent<Renderer>().enabled = false;
         }*/
        //break;
    }
    }
//}
