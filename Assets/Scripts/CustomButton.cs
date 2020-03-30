using UnityEngine;

public class CustomButton : MonoBehaviour
{
    [Tooltip("Which button is this?")]
    public int buttonIndex;

    [Tooltip("Should be bound to the physical button object")]
    public GameObject button;

    [Tooltip("Material for when the button is clicked (The color it shines when being pressed down)")]
    public Material clickButton;

    [Tooltip("Should be bound to the object that contains the SafeController/Circular Drive etc.")]
    public GameObject safeController;

    // Variable to hold the previous material
    private Material oldMaterial;

    // Variable to refer to the buttons Mesh Renderer
    private MeshRenderer meshRenderer;

    // Local reference to the SafeController script
    private SafeController safe;
    void Start()
    {
        // Assigns this.MeshRenderer to meshRenderer
        meshRenderer = button.GetComponent<MeshRenderer>();
        // Assigns the original material of the button to oldMaterial
        oldMaterial = meshRenderer.material;
        // Assigns the script SafeController to safe
        safe = safeController.GetComponent<SafeController>();
    }
    // Activates when the player starts pressing the button
    void OnTriggerEnter(Collider other)
    {
        safe.AddToStorage(buttonIndex);
        meshRenderer.material = clickButton;
    }
    // Activates when button is no longer being pressed
    void OnTriggerExit(Collider other)
    {
        meshRenderer.material = oldMaterial;
    }
}
