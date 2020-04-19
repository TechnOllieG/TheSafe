using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Throwable))]
public class SnapToPoint : MonoBehaviour
{
    public float snapRadius = 0.5f;
    public bool showHint = true;
    [Tooltip("Whether or not the object should be kinematic when not snapped to point")]
    public bool isKinematic;

    public GameObject snapToObject;
    [HideInInspector]
    public MeshRenderer snapToMeshRenderer;

    private bool holding = false;
    private Rigidbody rb;
    void Start()
    {
        snapToMeshRenderer = snapToObject.GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(transform.position != snapToObject.transform.position)
        {
            if (Mathf.Abs(transform.position.x - snapToObject.transform.position.x) <= snapRadius && Mathf.Abs(transform.position.y - snapToObject.transform.position.y) <= snapRadius && Mathf.Abs(transform.position.z - snapToObject.transform.position.z) <= snapRadius)
            {
                if(holding)
                {
                    snapToMeshRenderer.enabled = true;
                }
                else
                {
                    snapToMeshRenderer.enabled = false;
                    if (!isKinematic)
                    {
                        rb.isKinematic = true;
                    }
                    transform.position = snapToObject.transform.position;
                    transform.rotation = snapToObject.transform.rotation;
                }
            }
            else
            {
                if(!holding && !isKinematic)
                {
                    rb.isKinematic = false;
                }
                snapToMeshRenderer.enabled = false;
            }
        }
    }
    private void OnAttachedToHand()
    {
        holding = true;
    }

    private void OnDetachedFromHand()
    {
        holding = false;
    }
}
