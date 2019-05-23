using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] int surfaceIndex;

    private void Update()
    {
        surfaceIndex = TerrainSurface.GetMainTexture(transform.position);
    }
}