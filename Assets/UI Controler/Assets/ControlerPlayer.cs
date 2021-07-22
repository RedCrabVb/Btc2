using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class ControlerPlayer : MonoBehaviour
{
    public Joystick MoveJostic;
    public FixedTouchField TochFild;

    private FirstPersonController fps;
    private MouseLook mouseLook;
    private void Start()
    {
        fps = GetComponent<FirstPersonController>();
        mouseLook = fps.MouseLook;
    }
    private void Update()
    {
        mouseLook.lookAxise.vector = TochFild.TouchDist;
        fps.RunAxes.x = MoveJostic.Horizontal;
        fps.RunAxes.y = MoveJostic.Vertical;
    }
}
