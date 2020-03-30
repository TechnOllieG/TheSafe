using System;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SafeController : MonoBehaviour
{
    //-----------------------------------------------------------------------------
    // Visible in Inspector
    //-----------------------------------------------------------------------------
    public Material acceptMaterial;
    public Material denyMaterial;
    [Tooltip("Element 0 = Digit 1, Element 1 = Digit 2 etc. Don't Change Length!")]
    public int[] correctCode;

    [Tooltip("The Indicator light object")]
    public GameObject indicatorObject;
    //-----------------------------------------------------------------------------

    // Variable to refer to this.circularDrive
    private CircularDrive circularDrive;
    // Variable to save original indicator material (should be idle)
    private Material oldMaterial;
    // Variable to refer to the indicators mesh renderer component
    private MeshRenderer indicatorMeshRenderer;
    // Array to store the code being inputed
    private int[] codeStorage = new int[4];
    // The index of codeStorage the next digit should be written to
    private int storageIndex = 0;

    // Bool to stop Controller when safe is unlocked
    private bool unlocked = false;

    //-----------------------------------------------------------------------------
    void Start()
    {
        // Assign this.CircularDrive to variable circularDrive
        circularDrive = GetComponent<CircularDrive>();
        // Assign the indicators mesh renderer to indicatorMeshRenderer
        indicatorMeshRenderer = indicatorObject.GetComponent<MeshRenderer>();
        // Assign the original material of the indicator to indicatorOldMaterial
        oldMaterial = indicatorMeshRenderer.material;
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
