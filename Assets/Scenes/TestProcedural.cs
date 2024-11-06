using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TestProcedural : MonoBehaviour
{
    [Header("云片周围分布角度")]
    [Range(0, 360)]
    public float angle = 180.0f;
    
    private Mesh mesh;

    private MeshFilter meshFilter;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        //该对象应该隐藏、随场景一起保存还是由用户修改？
        mesh.hideFlags = HideFlags.DontSave;
        mesh.name = "DyanmicCludMesh";
        //优化网格以便频繁更新
        //持续更新网格时，在分配顶点之前调用此函数可获得更佳性能。 这在内部使网格在底层图形 API 中使用“动态缓冲区”，这 在网格数据经常更改时更加高效。
        mesh.MarkDynamic();
        meshFilter = this.GetComponent<MeshFilter>();
        
        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-200.0f, 200.0f, 0.0f),
            new Vector3(200.0f, 200.0f, 0.0f),
            new Vector3(-200.0f, -200.0f, 0.0f),
            new Vector3(200.0f, -200.0f, 0.0f)
        };

        int[] triangles = new int[]
        {
            0, 1, 2,
            1, 3, 2
        };

        Vector3[] normals = new Vector3[]
        {
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f),
            new Vector3(0.0f, 0.0f, -1.0f)
        };

        Vector2[] uv = new Vector2[]
        {
            new Vector2(0.25f, 1.0f),
            new Vector2(0.5f, 1.0f),
            new Vector2(0.25f, 0.75f),
            new Vector2(0.5f, 0.75f)
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;
        mesh.name = "Zhang";
        meshFilter.mesh = mesh;
        
        Vector3 sphericalPosition = new Vector3(0, 0, 10);
        Debug.LogError(Quaternion.Euler(-angle + 4 * Random.Range(-0.5f, 0.5f), 0, 0));
        sphericalPosition = Quaternion.Euler(-angle + 4 * Random.Range(-0.5f, 0.5f), 0, 0) * sphericalPosition;
        //sphericalPosition = Quaternion.Euler(-8 + 4 * Random.Range(-0.5f, 0.5f), angle + 36 * Random.Range(-0.5f, 0.5f), 0) * sphericalPosition;
        //sphericalPosition += Vector3.up * 500.0f;
        transform.position = sphericalPosition;
        //transform.rotation = Quaternion.LookRotation(sphericalPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
