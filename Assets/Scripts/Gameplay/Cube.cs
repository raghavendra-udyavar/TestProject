
using LAIGames.Parser;
using UnityEngine;
using System.Collections;

namespace LAIGames.Gameplay
{
    public class Cube : MonoBehaviour
    {
        [SerializeField]
        Transform _pointA;

        [SerializeField]
        Transform _pointB;

        [SerializeField]
        MeshDeformer _meshDeformer;

        CubeEffectData _cubeEffectData = null;
        bool _isSetToMove = false;
        float _speed = 0.0f;

        float _time = 0.0f;

        const float FORCE = 100f;

        // Use this for initialization
        void Start()
        {
            // get cubeData
            string jsonString = CubeData.GetCubeData();
            CubeEffectDataParser cubeDataParser = new CubeEffectDataParser();
            _cubeEffectData = cubeDataParser.Deserialize(jsonString);
            Debug.Log(_cubeEffectData.AnimationDelay + " ::" + _cubeEffectData.AnimationDuration + "::" + _cubeEffectData.CubeLifetime);
            transform.position = _pointA.position;
            StartCoroutine(WaitAndSetMove());
            StartCoroutine(DestroyAfterDuration());

            _speed = Vector3.Distance(_pointA.position, _pointB.position) / _cubeEffectData.AnimationDuration;
        }

        // Update is called once per frame
        void Update()
        {
            if(_isSetToMove){
                PlayAnimation();
                ChangeShape();
            }
        }

        IEnumerator WaitAndSetMove()
        {
            // start moving after AnimationDelay
            yield return new WaitForSeconds(_cubeEffectData.AnimationDelay);

            _isSetToMove = true;
        }

        IEnumerator DestroyAfterDuration()
        {
            // destroy gameobject after CubeLifetime
            yield return new WaitForSeconds(_cubeEffectData.CubeLifetime);

            Destroy(gameObject);
        }

        void PlayAnimation(){
            float step = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, step);
        }

        void ChangeShape(){
            
            _meshDeformer.AddForceToVertex(FORCE);
        }
    }
}
