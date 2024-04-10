
using UnityEngine;

public class Background_Scroller : MonoBehaviour
{
    public float speed = 5f;
    public Renderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset += new Vector2(0, speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
    }

}
