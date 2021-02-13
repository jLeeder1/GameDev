using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshExperiemnts : MonoBehaviour
{
    private float viewAngle = 90;
    private float viewRadius = 25;
    private int numberOfTriangles = 21;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();

        //DrawTriangles();
    }

    void DrawTriangles()
    {
        float widthOfEachTriangle = viewAngle / numberOfTriangles;
        List<Vector3> verticesList = new List<Vector3>();



        mesh.vertices = verticesList.ToArray();
        //mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };

        List<int> triangleOrderList = new List<int>();

        for (int index = 0; index < numberOfTriangles; index++)
        {
            triangleOrderList.Add(0);
            triangleOrderList.Add(1);
            triangleOrderList.Add(2);

            triangleOrderList.Add(3);
            triangleOrderList.Add(4);
            triangleOrderList.Add(5);
        }

        mesh.triangles = triangleOrderList.ToArray();

        for (int index = 0; index < mesh.vertices.Length; index++)
        {
            mesh.vertices[index] = Quaternion.Euler(0f, 0f, Random.Range(0, 90)) * (mesh.vertices[index] - transform.position) + transform.position;
        }
    }

    /*
    private List<Vector3> CreateSingleTriangleMesh()
    {
        return new List<Vector3>
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, widthOfEachTriangle * zPosition),
            new Vector3(widthOfEachTriangle * zPosition, 0, viewRadius)
        };
    }
    */
}
