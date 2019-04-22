using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

    public float attack = 5;
    public float skillDestroyTime = 4f;
    private void Start()
    {
        StartCoroutine(DestroySkillEffect());
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Troll>().life -= attack * Time.deltaTime;
            if (other.gameObject.GetComponent<Troll>().life <=0)
            {
                other.gameObject.GetComponent<Troll>().AnimationToDie();
            }
        } 
    }

    IEnumerator DestroySkillEffect()
    {
        yield return new WaitForSeconds(skillDestroyTime);
        Destroy(this.gameObject);
    }



}
