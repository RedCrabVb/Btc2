using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBox: MonoBehaviour
{
    private AudioSource audioSource;
    private MeshRenderer render;
    private Light light;
    private ParticleSystem particleSysteam;

    [SerializeField] private bool isBurning = false;
    [SerializeField] private float objectSize = 1f;
    [SerializeField] private float timerВestroy = 30f;
    [SerializeField] private float heat = 0.0005f;
  
    private void Start()
    {
        render = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        light = GetComponent<Light>();
        particleSysteam = GetComponent<ParticleSystem>();
    }

    IEnumerator Burning()
    {
        while (isBurning)
        {
            gameObject.transform.localScale = new Vector3(transform.localScale.x * objectSize, transform.localScale.y * objectSize, transform.localScale.z * objectSize);
            objectSize -= 0.000001f;
            //particleSysteam.shape.rotation = Quaternion.Euler(-90, 90, 90);
            Quaternion v = Quaternion.Euler(-90, 90, 90);
            // particleSysteam.shape.Set(-90, 90, 90);//  = Quaternion.Euler(-90, 90, 90);
            //gameObject.transform.rotation = Quaternion.Euler(-90, 90, 90);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fires")//если поднесли спичку и что то горящие
        {
            render.materials[0].SetColor("_EmissionColor", new Color(90F / 255f, 35F / 255f, 20f / 255f));
            isBurning = true;
            particleSysteam.Play();
            light.enabled = true;
            audioSource.Play();
            gameObject.tag = "Fires";
            StartCoroutine("Burning");
            Destroy(gameObject, timerВestroy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBurning && other.tag == "Player")
        {
            other.GetComponent<Frost>().GetWarm();
        }
    }
}
