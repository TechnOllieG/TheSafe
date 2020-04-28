using UnityEngine;

public class CustomButton : MonoBehaviour
{
    [Tooltip("Once the button has been pressed it cannot be unpressed")]
    public bool oneTime = false;
    [Tooltip("Will toggle the pressed bool everytime you press the button")]
    public bool Toggle = false;
    [HideInInspector]
    public bool pressed = false;
    public bool active = false;
    public Material secondMaterial;
    private Material oldMaterial;
    private MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        oldMaterial = meshRenderer.material;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (pressed && Toggle && active)
        {
            NotPressed();
        }
        else if(active)
        {
            Pressed();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!oneTime && !Toggle && active)
        {
            NotPressed();
        }
    }
    private void NotPressed()
    {
        meshRenderer.material = oldMaterial;
        pressed = false;
    }
    private void Pressed()
    {
        meshRenderer.material = secondMaterial;
        pressed = true;
    }
}
