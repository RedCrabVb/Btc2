using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float increase = 0.001f;
    public bool Eat { get; set; }
    private Starvation starvation;
    private Rake rake;

    private IEnumerator DestroiSeconds()
    {
        while (true)
        {
            if (Eat)
            {
                transform.localScale -= new Vector3(increase, increase, increase);
                starvation.lunch();
                if (transform.localScale.x <= 0.1 || transform.localScale.y <= 0.1 || transform.localScale.y <= 0.1)
                {
                    rake.EatStop();
                    Destroy(gameObject);
                }
            }
            yield return new WaitForSecondsRealtime(0.005f);
        }
    }


    public void SetDependenciesPlayer(Starvation starvation, Rake rake)
    {
        bool isActive = this.rake == null && this.starvation == null;

        this.rake = rake;
        this.starvation = starvation;

        if (isActive)
        {
            StartCoroutine("DestroiSeconds");
        }
    }
}
