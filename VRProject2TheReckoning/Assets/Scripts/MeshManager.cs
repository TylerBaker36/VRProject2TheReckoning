using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("(delta)Time in seconds before the mesh is rebaked.")] 
    private float refreshInterval = 0.5f;

    private SkinnedMeshRenderer meshRenderer;
    private MeshCollider collider;
    private Mesh mesh;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
        collider = GetComponent<MeshCollider>();
        mesh = meshRenderer.sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= refreshInterval)
        {
            time = 0;
            UpdateCollider();
        }
    }

    public void UpdateCollider()
    {
        Mesh colliderMesh = new Mesh();
        meshRenderer.BakeMesh(colliderMesh);
        collider.sharedMesh = null;
        collider.sharedMesh = colliderMesh;
    }
}
