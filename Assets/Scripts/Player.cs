using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController controller;
    public float speed = 10f;
    public bool getMagic = false;
    public float magicTimeSet = 2f;
    public float magicTimeCount;
    public GameObject magicPrefab;
    public bool isControled = true;
    public GameObject camera;
    private float changeControlTime = 0.5f;
    // Use this for initialization
    void Start () {
        controller = this.GetComponent<CharacterController>();
        magicTimeCount = magicTimeSet;
	}
	
	// Update is called once per frame
	void Update () {
        if (isControled)
        {
            controller.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);

            if (getMagic)
            {
                magicTimeCount -= Time.deltaTime;
                if (Input.GetKeyDown(KeyCode.LeftControl) && magicTimeCount <= 0)
                {
                    //  print("magic");
                    Instantiate(magicPrefab, transform.position, Quaternion.identity);
                    magicTimeCount = magicTimeSet;
                }
            }
            changeControlTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q) && changeControlTime < 0&&
                GameObject.Find("HeroModel").GetComponent<ShowPlayerAndHero>().getControlHero)
            {
                GameObject.FindGameObjectWithTag("Hero").GetComponent<MoveHero>().GetControl();
                this.LoseControl();
                changeControlTime = 0.5f;
                MusicManager._instance.PlayGetHeroAudio();
            }

        }
       

	}


   public void GetControl()
    {
        this.isControled = true;
        camera.SetActive(true);
    }

    public void LoseControl()
    {
        this.isControled = false;
        camera.SetActive(false);
    }

}
