using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Starvation : MonoBehaviour
{
    private float hunger = 100f;
    private float starvation = 0.01f;
    public Slider sliderStarvation;
    private FirstPersonController firstPersonController;
    private Frost forst;

    private void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
        forst = GetComponent<Frost>();
    }

    private void FixedUpdate()
    {
        if (hunger < 1)
        {
            forst.Freezing();
            return;
        }

        starvation = firstPersonController.isWalking() ? 0.01f : 0.1f;
        hunger -= starvation;
        sliderStarvation.value = hunger;
    }

    public void lunch()
    {
        hunger += 0.1f;
    }

    public void lunch(float h)
    {
        hunger += h;
    }

    public bool full()
    {
        return hunger > 100f;
    }

    public bool isHungry()
    {
        return hunger < 5;
    }
}
