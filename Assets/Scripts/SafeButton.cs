using UnityEngine;

public class SafeButton : MonoBehaviour
{
    [Tooltip("Which button is this?")]
    public int buttonIndex;
    [Tooltip("Should be bound to the physical button object")]
    public GameObject button;
    [Tooltip("Material for when the button is clicked (The color it shines when being pressed down)")]
    public Material clickButton;
    [Tooltip("Should be bound to the object that contains the SafeController/Circular Drive etc.")]
    public GameObject safeController;

    private Material oldMaterial; // Variable to hold the previous material
    private MeshRenderer meshRenderer; // Variable to refer to the buttons Mesh Renderer
    private SafeController safe; // Local reference to the SafeController script
    void Start()
    {
        meshRenderer = button.GetComponent<MeshRenderer>(); // Assigns this.MeshRenderer to meshRenderer
        oldMaterial = meshRenderer.material; // Assigns the original material of the button to oldMaterial
        safe = safeController.GetComponent<SafeController>(); // Assigns the script SafeController to safe
    }
    void OnTriggerEnter(Collider other)
    {
        // Activates when the player starts pressing the button
        safe.AddToStorage(buttonIndex);
        meshRenderer.material = clickButton;
    }
    void OnTriggerExit(Collider other)
    {
        // Activates when button is no longer being pressed
        meshRenderer.material = oldMaterial;
    }
}
