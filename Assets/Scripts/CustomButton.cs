using UnityEngine;

public class CustomButton : MonoBehaviour
{
    [Tooltip("Once the button has been pressed it cannot be unpressed")]
    public bool oneTime = false;
    [Tooltip("Will toggle the pressed bool everytime you press the button")]
    public bool Toggle = false;
    [HideInInspector]
    public bool pressed = false;
    public Material secondMaterial;
    private Material oldMaterial;
    private MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        oldMaterial = meshRenderer.material;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(pressed && Toggle)
        {
            NotPressed();
        }
        else
        {
            Pressed();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(!oneTime && !Toggle)
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
