using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")] 
    public GameObject   basketPrefab;
    public int  numBaskets = 3;
    public float  basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public Text scoreGT;
   public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
            
        }
        scoreGT = GameObject.Find("ScoreCounter").GetComponent<Text>();
        
    }

   

    public void AppleDestroyed() {

        GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tGO in tAppleArray ) {
            Destroy( tGO );
        }

        int basketindex = basketList.Count-1;

        GameObject tBasketGO = basketList[basketindex];

        basketList.RemoveAt( basketindex );
        Destroy( tBasketGO );
        if ( basketList.Count == 0 ) {
            SceneManager.LoadScene( "_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
