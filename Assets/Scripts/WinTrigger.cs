using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {

    private bool isWin = false;
    public RawImage winGui;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWin = true;
            winGui.gameObject.SetActive(true);
        }
    }

    private void OnGUI()
    {
        if (isWin)
        {
            GUI.Label(new Rect(Screen.width / 2+60, Screen.height / 2, 100, 30), "You Win!!!!");
            bool yes=GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 20, 50, 30), "Quit");
            if (yes)
            {
                Application.Quit();
            }
        }
    }


}
