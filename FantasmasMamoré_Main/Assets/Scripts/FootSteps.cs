using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] int surfaceIndex;
    public float range;
    public Terrain terrain;
    public LayerMask myLayerMask;
    [SerializeField] GameObject objeto;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        surfaceIndex = TerrainSurface.GetMainTexture(transform.localPosition, terrain);
    }

    private void LateUpdate()
    {

        Vector3 position = transform.position;
        Vector3 target = -Vector3.up * range;
        Debug.DrawRay(transform.position, -Vector3.up * range, Color.green);
        RaycastHit raycastHit;
        

        if (Physics.Linecast(position, target, out raycastHit, myLayerMask))
        {
            objeto = raycastHit.collider.gameObject;
        }

        if (objeto.GetComponent<Terrain>() == true)
        {
            terrain = objeto.GetComponent<Terrain>();
        }

    }
}
