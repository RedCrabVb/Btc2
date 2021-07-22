using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class Scroll : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    public bool FireRake = true;
    void FixedUpdate()
    {
        if (FireRake) {
            t2.SetActive(false);
            t1.SetActive(true);
        }
        if(!FireRake)
        {
            t1.SetActive(false);
            t2.SetActive(true);
        }
    }
}
