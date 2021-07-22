using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEat : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Rake rake;
    private Image imgae;

    void Start()
    {
        imgae = gameObject.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData3)
    {
        imgae.color = Color.red;
        rake.EatFood();
    }
    public void OnPointerUp(PointerEventData eventData3)
    {
        imgae.color = Color.white;
        rake.EatStop();
    }
}
