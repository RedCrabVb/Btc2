using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonRake : MonoBehaviour, IPointerClickHandler
{
    public Rake rake;

    public void OnPointerClick(PointerEventData eventData)
    {
        rake.button_Control_Android = !rake.button_Control_Android;
        if(rake.button_Control_Android)
            gameObject.GetComponent<Image>().color = new Vector4(255 / 255.0f, 0 / 255.0f, 0 / 255.0f, 1);
        else
            gameObject.GetComponent<Image>().color = new Vector4(255 / 255.0f, 255 / 255.0f, 255 / 255.0f, 1);
    }

}
