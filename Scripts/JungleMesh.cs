using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ThroughTheJungle
{
    public class JungleMesh : MonoBehaviour
    {
        public float radius = 0.2f;
        public float height = 3f;
        private List<Vector3> nodes = new List<Vector3>();
        private MeshFilter meshFilter;

        //! Bakes the navigation mesh
        public void Bake()
        {
            nodes.Clear();

            meshFilter = GetComponent<MeshFilter>();
            if(meshFilter == null)
            {
                return;
            }

            Vector3[] vertices = meshFilter.sharedMesh.vertices;
            foreach(Vector3 vertex in vertices)
            {
                Vector3 product = Vector3.Scale(vertex, transform.localScale);
                RaycastHit hit;
                Physics.Raycast(product + Vector3.up * height, Vector3.down, out hit);
                if (hit.collider.gameObject == gameObject)
                {
                    nodes.Add(product);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            foreach(Vector3 node in nodes.ToArray())
            {
                Gizmos.DrawSphere(node, 0.1f);
            }
        }
    }
}
