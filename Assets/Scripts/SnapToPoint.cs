using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Throwable))]
public class SnapToPoint : MonoBehaviour
{
    public float snapRadius = 0.05f;
    public bool showHint = true;
    
    public GameObject snapToObject;
    [HideInInspector]
    public MeshRenderer snapToMeshRenderer;

    private bool withinRadius = false;
    private bool holding = false;
    private Rigidbody rb;
    private bool isKinematic;
    void Start()
    {
        snapToMeshRenderer = snapToObject.GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        if(rb.isKinematic)
        {
            isKinematic = true;
        }
        else
        {
            isKinematic = false;
        }
    }
    void Update()
    {
        if(holding)
        {
            if (Mathf.Abs(transform.position.x - snapToObject.transform.position.x) <= snapRadius || Mathf.Abs(transform.position.y - snapToObject.transform.position.y) <= snapRadius || Mathf.Abs(transform.position.z - snapToObject.transform.position.z) <= snapRadius)
            {
                withinRadius = true;
                snapToMeshRenderer.enabled = true;
            }
            else
            {
                withinRadius = false;
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
        if(withinRadius)
        {
            if(!isKinematic)
            {
                rb.isKinematic = true;
            }
            transform.position = snapToObject.transform.position;
            transform.rotation = snapToObject.transform.rotation;
        }
        else
        {
            if(!isKinematic)
            {
                rb.isKinematic = false;
            }
        }
        snapToMeshRenderer.enabled = false;
        holding = false;
    }
}
