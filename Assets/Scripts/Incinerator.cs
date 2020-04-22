using UnityEngine;
using System.Collections;

public class Incinerator : MonoBehaviour
{
    [Tooltip("The incremental degree that the door will close with every frame update")]
    public float doorIncrement;
    public float timeUntilLightsOn;

    public GameObject button;
    public GameObject syringe;
    public GameObject syringeSnapTo;
    public GameObject lights;
    public GameObject leftDoor;
    public GameObject leftDoorClosed;
    public GameObject rightDoor;
    public GameObject rightDoorClosed;

    private CustomButton buttonScript;
    private bool initIncinerator = false;

    private void Start()
    {
        buttonScript = button.GetComponent<CustomButton>();
    }
    private void Update()
    {
        if(buttonScript.pressed && syringe.transform.position == syringeSnapTo.transform.position && !initIncinerator)
        {
            if(leftDoor.transform.localEulerAngles.x != leftDoorClosed.transform.localEulerAngles.x && rightDoor.transform.localEulerAngles.x != rightDoorClosed.transform.localEulerAngles.x)
            {
                leftDoor.transform.localEulerAngles = new Vector3(leftDoor.transform.localEulerAngles.x + doorIncrement, leftDoor.transform.localEulerAngles.y, leftDoor.transform.localEulerAngles.z);
                rightDoor.transform.localEulerAngles = new Vector3(rightDoor.transform.localEulerAngles.x + doorIncrement, rightDoor.transform.localEulerAngles.y, rightDoor.transform.localEulerAngles.z);
                return;
            }
            else
            {
                Debug.Log("Doors at the same rotation");
                StartCoroutine(InitIncinerator());
                initIncinerator = true;
            }
        }
    }
    private IEnumerator InitIncinerator()
    {
        Debug.Log("Inside Coroutine");
        yield return new WaitForSeconds(timeUntilLightsOn);
        Debug.Log("Just Before Lights turn on");
        lights.SetActive(true);
    }
}
