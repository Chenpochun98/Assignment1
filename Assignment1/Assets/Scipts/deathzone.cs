using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    [SerializeField] private GameObject losetext;
    void OnTriggerEnter()
    {
        losetext.SetActive(true);
    }

}
