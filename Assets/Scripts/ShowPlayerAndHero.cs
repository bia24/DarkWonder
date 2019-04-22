using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPlayerAndHero : MonoBehaviour {

    private bool nearHero = false;
    public int meatNeed = 3;
    private int meatNow = 0;
    private bool meatEnough = false;
    public bool getControlHero = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //设置 进入标志位；           
            nearHero = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            //设置 退出标志位；           
            nearHero = false;
        }
    }


    private void OnGUI()
    {
        if(nearHero==true &&  getControlHero==false)
        {
            showLog();
        }
    }

    void showLog()
    {
        
            if (Meat.instance.meatCount == 0)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150, 200), "英雄需要食用巨魔肉！");
            }
            else
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 150, 200), "是否把巨魔肉交给英雄？");
                bool yes = GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 50, 70, 30), "是");
                bool no = GUI.Button(new Rect(Screen.width / 2 + 75, Screen.height / 2 + 50, 70, 30), "否");
                if (no)
                {
                    nearHero = false;
                }
                if (yes)
                {
                    meatNow += Meat.instance.meatCount;
                    Meat.instance.meatCount = 0;
                    if (meatNow >= meatNeed) ///  Meat  enough
                    {
                        getControlHero =true;
                        Message.instance.showMessage("你已获得英雄的控制权，按Q键切换控制", 6f);
                    }
                    else
                    {
                        nearHero = false;
                        Message.instance.showMessage("英雄还没有吃饱，请找更多的巨魔肉",4f);
                    }
                }
            }
        
       
    }

}
