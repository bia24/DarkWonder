using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMessageCollider : MonoBehaviour {

    public float messageStayTime = 4f;
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if (!DestroyFence.isdestroyed)
            {
                //触发屏幕中央GUItext显示
                Message.instance.showMessage("你需要借助英雄的力量来打开栅栏。", messageStayTime);
            }
        }

    }
}
