using UnityEngine;

namespace LAIGames.Gameplay
{
    [RequireComponent(typeof(MeshFilter))]
    public class MeshDeformer : MonoBehaviour
    {
        const float SPRINGFORCE = 40f;
        const float DAMPING = 5f;

        Mesh _deformingMesh;
        Vector3[] _originalVertices, _displacedVertices, _vertexVelocities;

        int _currentIndex;

        // Use this for initialization
        void Start()
        {
            // cache the mesh informations needed
            _deformingMesh = GetComponent<MeshFilter>().mesh;
            _originalVertices = _deformingMesh.vertices;
            _displacedVertices = new Vector3[_originalVertices.Length];
            for (int i = 0; i < _originalVertices.Length; i++)
            {
                _displacedVertices[i] = _originalVertices[i];
            }

            _vertexVelocities = new Vector3[_originalVertices.Length];
        }

        void Update()
        {
            for (int i = 0; i < _displacedVertices.Length; i++)
            {
                UpdateVertex(i);
            }
            _deformingMesh.vertices = _displacedVertices;
            _deformingMesh.RecalculateNormals();
        }

        void UpdateVertex(int i)
        {
            Vector3 velocity = _vertexVelocities[i];
            Vector3 displacement = _displacedVertices[i] - _originalVertices[i];
            velocity -= displacement * SPRINGFORCE * Time.deltaTime;
            _vertexVelocities[i] = velocity;
            _displacedVertices[i] += velocity * Time.deltaTime;
        }

        public void AddForceToVertex(float force)
        {
            _currentIndex = _currentIndex % _displacedVertices.Length;
            float attenuatedForce = force / (1f + _displacedVertices[_currentIndex].sqrMagnitude);
            float velocity = attenuatedForce * Time.deltaTime;
            velocity *= 1f - DAMPING * Time.deltaTime;
            _vertexVelocities[_currentIndex] += _displacedVertices[_currentIndex].normalized * velocity;
            _currentIndex++;
        }
    }
}
