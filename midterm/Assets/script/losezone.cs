using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class losezone : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("AI"))
        {
            Debug.Log("LOSE");
            Time.timeScale = 0;
        }
    }

  
}
