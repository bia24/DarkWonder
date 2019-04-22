using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFence : MonoBehaviour {

    public static bool isdestroyed = false;
    public void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.tag == "Hero") {
            if (Input.GetButtonDown("Fire1"))
            {
                Destroy(this.gameObject);
                isdestroyed = true;
            }
        }
    }

   
}
