using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
    public class MeshInverter : MonoBehaviour
    {
        void Start()
        {
            var meshFilter = GetComponent<MeshFilter>();
            var triss = meshFilter.sharedMesh.triangles;
            var normals=meshFilter.sharedMesh.normals;
            for (int i=0;i<normals.Length;i++)
                normals[i]=-normals[i];
            for (int i = 0; i < triss.Length / 3; i++)
            {
                int temp = triss[i * 3 + 1];
                triss[i * 3 + 1] = triss[i * 3];
                triss[i * 3] = temp;
            }
            Mesh mesh=Instantiate(meshFilter.sharedMesh);
            mesh.triangles=triss;
            mesh.normals=normals;
            meshFilter.mesh=mesh;
        }
    }
