using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour {

    public static Message instance = null;
    private bool showable=false;
    private float timeCount;
	// Use this for initialization
	void Start () {
        instance = this;
        this.gameObject.SetActive(false);
	}
	 
    public void showMessage(string context)
    {
        this.GetComponent<Text>().text = context;
        this.gameObject.SetActive(true);
    }
	
    public void hideSelf()
    {
        this.gameObject.SetActive(false);
    }

    public void showMessage(string context,float stayTime)
    {
        timeCount = stayTime;//以给定的stayTime赋值，用于文字停留时间
        showable = true;//关联update方法中的标识符判断
        this.GetComponent<Text>().text = context + "";
        this.gameObject.SetActive(true);
    }

    private void Update() //更新中央文字停留时间，用于判断
    {
        if (showable)
        {
            timeCount -= Time.deltaTime;
            if (timeCount < 0)
            {
                this.gameObject.SetActive(false);
                showable = false;
            }
        }
    }

}
