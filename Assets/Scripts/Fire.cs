using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float u;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Frost>().GetWarm();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Player")
        {
            try
            {
                gag.GetComponent<AudioSource>().clip = mu_veter;
                gag.GetComponent<AudioSource>().enabled = false;
                gag.GetComponent<AudioSource>().enabled = true;
            }
            catch(Exception e) {
            }
        }*/
    }
}