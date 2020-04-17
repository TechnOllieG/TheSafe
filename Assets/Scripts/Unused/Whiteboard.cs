using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Texture2D texture = Instantiate(meshRenderer.material.mainTexture) as Texture2D;
        meshRenderer.material.mainTexture = texture;

        Color[] colors = new Color[3];
        colors[0] = Color.red;
        colors[1] = Color.green;
        colors[2] = Color.blue;
        int mipCount = Mathf.Min(3, texture.mipmapCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
