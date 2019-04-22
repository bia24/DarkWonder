using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour {

    private bool isTraingFinish = false;
    private bool isTraing = false;
    public float trainingTimeSet = 5f;
    private float trainingTime;

    public GameObject skillGUI;
	// Update is called once per frame
	void Update () {
        if (isTraing == true && isTraingFinish == false)
        {
            if (trainingTime > 0)
            {
                trainingTime -= Time.deltaTime;
                //print("left time : " + trainingTime);
                Message.instance.showMessage("剩余时间： " + trainingTime.ToString("0.0")+"秒");
            }
            else
            {
                isTraingFinish = true;
                skillGUI.SetActive(true);
                Message.instance.showMessage("恭喜你，修炼完成");
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getMagic = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTraing = true;
            trainingTime = trainingTimeSet;
            // print("isTrainingFinish: "+ isTraingFinish);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isTraing = false;
            Message.instance.hideSelf();
        }
    }

}
