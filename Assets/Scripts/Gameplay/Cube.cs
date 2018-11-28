
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

        CubeEffects _cubeEffects = null;
        bool _isSetToMove = false;

        // Use this for initialization
        void Start()
        {
            // get cubeData
            string jsonString = CubeData.GetCubeData();
            CubeDataParser cubeDataParser = new CubeDataParser();
            _cubeEffects = cubeDataParser.Deserialize(jsonString);
            Debug.Log(_cubeEffects.AnimationDelay + " ::" + _cubeEffects.AnimationDuration + "::" + _cubeEffects.CubeLifetime);
            transform.position = _pointA.position;
            StartCoroutine(WaitAndSetMove());
            StartCoroutine(DestroyAfterDuration());
        }

        // Update is called once per frame
        void Update()
        {
            if(_isSetToMove){
                PlayAnimation();
            }
        }

        IEnumerator WaitAndSetMove()
        {
            // suspend execution for 5 seconds
            yield return new WaitForSeconds(_cubeEffects.AnimationDelay);

            _isSetToMove = true;
        }

        IEnumerator DestroyAfterDuration()
        {
            // suspend execution for 5 seconds
            yield return new WaitForSeconds(_cubeEffects.AnimationDuration);

            Destroy(this.gameObject);
        }

        void PlayAnimation(){
            float step = _cubeEffects.AnimationDuration * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, step);
        }
    }
}
