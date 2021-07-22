using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;

public class runButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      /// player.GetComponent<FirstPersonController>().m_IsWalking = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      //  player.GetComponent<FirstPersonController>().m_IsWalking = true;
    }
}
