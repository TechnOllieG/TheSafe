using UnityEngine;
using Valve.VR.InteractionSystem;

public class Door : MonoBehaviour
{
    [Tooltip("The Button GameObject with the CustomButton script applied to it.")]
    public GameObject doorButton;
    public GameObject openState;
    public float openCloseIncrement = 20;
    public GameObject optionalTeleportPoint;
    
    private CustomButton customButton;
    private float oldYPosition;
    private float diffOpenClosed;
    private Vector3 incrementStep;
    private bool optionalTeleportActive = false;
    private TeleportPoint teleportPoint;
    void Start()
    {
        customButton = doorButton.GetComponent<CustomButton>();
        oldYPosition = transform.position.y;

        diffOpenClosed = oldYPosition - openState.transform.position.y;
        incrementStep = new Vector3(0,diffOpenClosed / openCloseIncrement,0);
        if(optionalTeleportPoint != null)
        {
            teleportPoint = optionalTeleportPoint.GetComponent<TeleportPoint>();
            teleportPoint.markerActive = false;
        }
    }
    void Update()
    {
        if(customButton.pressed && transform.position.y > openState.transform.position.y)
        {
            transform.position -= incrementStep;
            if(optionalTeleportPoint != null && !optionalTeleportActive)
            {
                teleportPoint.markerActive = true;
                optionalTeleportActive = true;
            }
        }
        if(!customButton.pressed && transform.position.y < oldYPosition)
        {
            transform.position += incrementStep;
            if (optionalTeleportPoint != null && optionalTeleportActive)
            {
                teleportPoint.markerActive = false;
                optionalTeleportActive = false;
            }
        }
    }
}
