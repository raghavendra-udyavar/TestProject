using UnityEngine;
using LAIGames.Parser;
using LAIGames.Gameplay;
using LAIGames;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    [SerializeField]
    Transform _cubePrefab;

    [SerializeField]
    Text _guiText;

    int _cubeCount;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)){
            SpawnCube();

            _guiText.text = "CUBECOUNT: " + _cubeCount;
        }
    }

    void SpawnCube(){

        _cubeCount++;
        Instantiate(_cubePrefab);
    }
}
