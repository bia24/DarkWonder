using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUITest : MonoBehaviour {

    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width/2, Screen.height/2, 100, 20);
        GUI.Label(rect, "努力奋斗！");
        rect = new Rect(Screen.width / 2, Screen.height / 2 + 20, 200, 20);
        GUI.Button(rect,"天亮之后就会有星星哦");
    }
}
