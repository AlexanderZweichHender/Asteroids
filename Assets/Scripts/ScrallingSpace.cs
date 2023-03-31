using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ScrallingSpace : MonoBehaviour
{
    [SerializeField, Range(0.01f, 1f)] private float scrallingSpeed = 1.0f;

    private MeshRenderer meshRenderer;
    private Material mainMaterial;

    private void Awake() => meshRenderer = GetComponent<MeshRenderer>();
    private void Start() => mainMaterial = meshRenderer.material;
    private void Update() => ScrallBackGround();

    private void ScrallBackGround()
    {
        Vector2 offset = mainMaterial.mainTextureOffset;
        offset.x += scrallingSpeed * Time.deltaTime;
        mainMaterial.mainTextureOffset = offset;
    }
}
