using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonChangeObj : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public GameObject t1;
    public GameObject t2;
    private float startClick;
    private float duration = 3;
    private bool isDown;

    public void OnPointerEnter(PointerEventData eventData)
    {
        startClick = Time.time;
        t1.SetActive(false);
        t2.SetActive(true);
        gameObject.GetComponent<Image>().color = Color.red;
        isDown = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Time.time - startClick > duration && isDown)
        {
            t2.GetComponent<MatchesController>().Ignite();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        t1.SetActive(true);
        t2.SetActive(false);
        gameObject.GetComponent<Image>().color = Color.white;
        isDown = false;
    }

}
