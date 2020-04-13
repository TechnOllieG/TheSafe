using UnityEngine;

public class SwitchCollision : MonoBehaviour
{
    [Tooltip("Which state is this switch object in? True = on/False = off")]
    public bool state;
    public GameObject switchController;
    private SwitchController switchScript;
    void Start()
    {
        switchScript = switchController.GetComponent<SwitchController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(state)
        {
            switchScript.SetOff();
        }
        else
        {
            switchScript.SetOn();
        }
    }
}
