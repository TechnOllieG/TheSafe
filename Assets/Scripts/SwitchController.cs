using UnityEngine;

public class SwitchController : MonoBehaviour
{

    [Tooltip("The GameObject representing the switches on-state")]
    public GameObject onState;
    public GameObject offState;

    public bool active = false;
    public void SetOff()
    {
        active = false;
        onState.SetActive(false);
        offState.SetActive(true);
    }
    public void SetOn()
    {
        active = true;
        onState.SetActive(true);
        offState.SetActive(false);
    }
}
