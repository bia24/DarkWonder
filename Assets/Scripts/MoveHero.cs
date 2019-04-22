using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHero : MonoBehaviour {

    private CharacterController heroControl;
    public float speed = 20f;
    private Animator anim;
    private string lastFrameState = "idle";
    public bool isControled = false;
    public GameObject camera;
    private float changeControlTime = 0.5f;
	// Use this for initialization
	void Start () {
        heroControl = this.GetComponent<CharacterController>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isControled )
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 60 * Time.deltaTime, 0));
            heroControl.SimpleMove(transform.forward * speed * Input.GetAxis("Vertical"));

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("Run", false);
                anim.SetBool("Spinkick", true);
            }
            else
            {
                if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.02f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.02f)
                {

                    anim.SetBool("Run", true);

                }
                if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.02f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.02f)
                {


                    anim.SetBool("Run", false);


                }
            }
            changeControlTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q)&&changeControlTime<0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetControl();
                this.LoseControl();
                anim.SetBool("Run", false);
                changeControlTime = 0.5f;
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
