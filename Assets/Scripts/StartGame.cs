using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    private RawImage image;
    public Texture[] images;
    private int index = 0;
    // Use this for initialization
	void Start () {
        image = this.GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            if (index == 10)
            {
                //load new main scene;
                Application.LoadLevel("MainScene");
            }
            else
            {
                image.texture = images[index];
            }
        }
	}
}
