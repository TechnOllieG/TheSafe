using UnityEngine;

public class Door : MonoBehaviour
{
    [Tooltip("The Button GameObject with the CustomButton script applied to it.")]
    public GameObject doorButton;
    public GameObject openState;
    public float openCloseIncrement = 20;
    private CustomButton customButton;
    private Vector3 oldPosition;
    private Vector3 diffOpenClosed;
    private Vector3 incrementStep;
    void Start()
    {
        customButton = doorButton.GetComponent<CustomButton>();
        oldPosition = transform.position;

        diffOpenClosed = oldPosition - openState.transform.position;
        incrementStep = diffOpenClosed / openCloseIncrement;
    }
    void Update()
    {
        if(customButton.pressed && transform.position != openState.transform.position)
        {
            transform.position -= incrementStep;
        }
        if(!customButton.pressed && transform.position != oldPosition)
        {
            transform.position += incrementStep;
        }
    }
}
