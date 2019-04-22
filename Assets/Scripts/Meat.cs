using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour {

    public static Meat instance;
    public int meatCount=0;
    public GameObject meatCountObj;
	// Use this for initialization
	void Start () {
        instance = this;
        this.gameObject.SetActive(false);
	}

    private void Update()
    {
        meatCountObj.gameObject.GetComponent<Text>().text = meatCount + "";//巨魔肉数字实时更新
    }


    public void IncreaseMeat()
    {
        meatCount++; //巨魔肉增加
        if (!this.gameObject.activeInHierarchy)//巨魔肉图片GUI显示状态判断
        {
            this.gameObject.SetActive(true);
        }
        if (!meatCountObj.activeInHierarchy)//巨魔肉数字GUI显示状态判断
        {
            meatCountObj.gameObject.SetActive(true);
        }
        meatCountObj.gameObject.GetComponent<Text>().text = meatCount + "";
    }
}
