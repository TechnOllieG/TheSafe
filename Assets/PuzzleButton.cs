using UnityEngine;

public class PuzzleButton : MonoBehaviour
{
    public GameObject puzzleController;
    public Material activeButton;
    [Tooltip("Starts from 0, index 0 = Light 1 etc.")]
    public int[] connectedLightsIndex;

    private PuzzleBox puzzleBox;
    private Material oldMaterial;
    private MeshRenderer meshRenderer;
    private bool active = false;

    void Start()
    {
        puzzleBox = puzzleController.GetComponent<PuzzleBox>();
        meshRenderer = GetComponent<MeshRenderer>();
        oldMaterial = meshRenderer.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!puzzleBox.solved)
        {
            if (active)
            {
                active = false;
                meshRenderer.material = oldMaterial;
            }
            else
            {
                active = true;
                meshRenderer.material = activeButton;
            }
            puzzleBox.UpdateLights(connectedLightsIndex);
        }
    }
}
