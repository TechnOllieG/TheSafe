using System;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SafeController : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    // Visible in Inspector
    //-----------------------------------------------------------------------------
    public Material acceptMaterial; // The material to apply to the indicator light when code is correct.
    public Material denyMaterial; // The material to apply to the indicator light when code is incorrect.
    [Tooltip("Element 0 = Digit 1, Element 1 = Digit 2 etc. Don't Change Length!")]
    public int[] correctCode;

    [Tooltip("The Indicator light object")]
    public GameObject indicatorObject;
    //-----------------------------------------------------------------------------

    private CircularDrive circularDrive; // Variable to refer to this gameObject's circularDrive script
    private Material oldMaterial; // Previously applied material to the indicator light (should be idle)
    private MeshRenderer indicatorMeshRenderer;
    private int[] codeStorage = new int[4];
    private int storageIndex = 0; // The index of codeStorage the next digit should be written to

    private bool unlocked = false;  // Bool to stop Controller when safe is unlocked

    //-----------------------------------------------------------------------------
    void Start()
    {
        circularDrive = GetComponent<CircularDrive>(); // Assign the component this.CircularDrive to variable circularDrive
        indicatorMeshRenderer = indicatorObject.GetComponent<MeshRenderer>(); // Assign the indicators mesh renderer to indicatorMeshRenderer
        oldMaterial = indicatorMeshRenderer.material; // Assign the original material of the indicator to indicatorOldMaterial
    }

    void Update()
    {
        // Turns off the script if unlocked = true and checks if 4 digits have been entered
        if(!unlocked && storageIndex == 4)
        {
            if (codeStorage.SequenceEqual(correctCode))
            {
                indicatorMeshRenderer.material = acceptMaterial;
                circularDrive.enabled = true;
                unlocked = true;
            }
            else
            {
                indicatorMeshRenderer.material = denyMaterial;
                storageIndex = 0;
                Array.Clear(codeStorage, 0, codeStorage.Length);
                Invoke("ResetMaterial", 2);
            }
        }
    }
    // Adds the pressed digit to the storage and ups the storageIndex
    public void AddToStorage(int digit)
    {
        codeStorage[storageIndex] = digit;
        storageIndex++;
    }
    void ResetMaterial()
    {
        indicatorMeshRenderer.material = oldMaterial;
    }
}
