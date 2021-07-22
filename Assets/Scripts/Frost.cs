using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Frost : MonoBehaviour
{
    private const float MAX_TEMPERATURE = 39;
    private float freezeSpead = 0.01f;
    private float temperature = 36.6f;
    private float warm = 0.1f;
    public Text textUI;
    public GameObject camera;
    public GameObject cameraDead;

    void Start()
    {
        textUI.text = temperature.ToString() + "°C";
        StartCoroutine("Enumerator");
    }

    IEnumerator Enumerator()
    {
        while (temperature > 30)
        {
            float temperatureUI = ((int)(temperature * 10)) / 10f;
            textUI.text = temperatureUI.ToString() + "°C";
            Freezing();
     
            yield return new WaitForSecondsRealtime(0.05f);
        }

        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        camera.SetActive(false);
        cameraDead.SetActive(true);
        Debug.Log("dead" + temperature);
    }

    public void GetWarm()
    {
        if (MAX_TEMPERATURE > temperature)
        {
            temperature += warm;
        }
    }

    public void Freezing()
    {
        temperature -= freezeSpead;
    }

}
