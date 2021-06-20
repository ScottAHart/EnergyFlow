using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilder : MonoBehaviour
{
    MeshFilter mFilter = null;
    MeshCollider mCollider = null;
    Mesh pathMesh = null;

    public float gridSize = 0.1f;
    private void Awake()
    {
        mFilter = GetComponent<MeshFilter>();
        mCollider = GetComponent<MeshCollider>();
        pathMesh = mFilter.mesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        {
            Mesh mesh = new Mesh();

            int[,] grid = new int[,]
            {
                {0, 0, 1 },
                {1, 0, 1 },
                {1, 1, 1 }
            };

            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Debug.LogError(grid[col, row]);
                }
            }
            return;
            //Vector3[] vertices = new Vector3[4]
            //{
            //new Vector3(0, 0, 0),
            //new Vector3(gridSize, 0, 0),
            //new Vector3(0, 0, gridSize),
            //new Vector3(gridSize, 0, gridSize)
            //};

            //int[] tris = new int[6]
            //{
            //// lower left triangle
            //0, 2, 1,
            //// upper right triangle
            //2, 3, 1
            //};

            //Vector3[] normals = new Vector3[4]
            //{
            //-Vector3.forward,
            //-Vector3.forward,
            //-Vector3.forward,
            //-Vector3.forward
            //};

            //Vector2[] uv = new Vector2[4]
            //{
            //new Vector2(0, 0),
            //new Vector2(1, 0),
            //new Vector2(0, 1),
            //new Vector2(1, 1)
            //};


            //mesh.vertices = vertices;
            //mesh.triangles = tris;
            //mesh.normals = normals;
            //mesh.uv = uv;

            //mFilter.mesh = mesh;
            //mCollider.sharedMesh = mesh;
        }
    }

}
