using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Throwable))]
public class SnapToWall : MonoBehaviour
{
    public float snapRadius = 0.05f;
    public bool showHint = true;
    
    public GameObject snapToObject;
    [HideInInspector]
    public MeshRenderer snapToMeshRenderer;

    private bool withinRadius = false;
    private bool holding = false;
    void Start()
    {
        snapToMeshRenderer = snapToObject.GetComponent<MeshRenderer>();
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
            transform.position = snapToObject.transform.position;
            transform.rotation = snapToObject.transform.rotation;
        }
        snapToMeshRenderer.enabled = false;
        holding = false;
    }
}
