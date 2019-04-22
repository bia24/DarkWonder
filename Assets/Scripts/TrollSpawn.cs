using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSpawn : MonoBehaviour {
    public GameObject troll;
    public static int trollCount ;
    public int trollMaxCount = 10;
    public float timeSet = 5f;
    private float timeCount;

    private void Start()
    {
        timeCount = timeSet;
        trollCount = 0;
    }

    private void Update()
    {
        if (trollCount < trollMaxCount)
        {
            timeCount -= Time.deltaTime;
            if (timeCount < 0)
            {//生产巨魔
                GameObject.Instantiate(troll,transform.position,Quaternion.identity);
                trollCount++;
                timeCount = timeSet;
            }
        }
    }

}
