using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : MonoBehaviour {

    private bool move = false;
    public float idleTimeSet = 2f;
    public float moveTimeSet = 5f;
    public float speed = 3f;
    public float life = 10f;    
    private float timeCount;
    private float angle;
    public float dieTimeCount=2.5f;
    private Animator anim;
    private CharacterController controller;
    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        timeCount = idleTimeSet;
        //dieTimeCount = 2f;
    }
	
	// Update is called once per frame
	void Update () {        
        if (life > 0)
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                if (!move)
                {
                    //transform to move
                    TransformToWalk();

                    AnimationToWalk();

                }
                else
                {
                    TransformToIdle();

                    AnimationToIdle();
                }
            }
            if (move)
            {
                if (Mathf.Abs(angle) >= 0.2f)
                {
                    float temp = angle * 0.05f;
                    transform.Rotate(new Vector3(0, temp, 0));
                    angle -= temp;
                }
                controller.SimpleMove(transform.forward * speed);
                //transform.position += transform.forward*Time.deltaTime*speed;
            }
        }
        else
        {
            if (dieTimeCount <= 0)
            {
                Destroy(this.gameObject);
                TrollSpawn.trollCount--;
                MusicManager._instance.PlayGetMeatAudio();
                if (Random.Range(1, 11) <= 10)
                {
                    //巨魔死亡，调用meat脚本，显示巨魔肉信息
                    Meat.instance.IncreaseMeat();
                }
            }
            else
            {
                dieTimeCount -= Time.deltaTime;
            }
        }
        
	}


    private void TransformToWalk()
    {
        move = true;
        timeCount = moveTimeSet;
        angle = Random.Range(-180  , 180);
        //transform.Rotate(new Vector3(0, Random.Range(-90, 90), 0));
    }

    private void TransformToIdle()
    {
        move = false;
        timeCount = idleTimeSet;
    }



    private void AnimationToWalk()
    {
        anim.SetFloat("run", 0.0F);
        anim.SetFloat("idle", 0F);
        anim.SetFloat("walk", 1.0F);
    }

    private void AnimationToIdle()
    {
        anim.SetFloat("idle", 1F);
        anim.SetFloat("walk", 0.0F);
        anim.SetFloat("run", 0F);
    }

    public void AnimationToDie()
    {
        //GameObject.Destroy(this.gameObject);
        anim.SetFloat("death", 1.0F);
     }
}
