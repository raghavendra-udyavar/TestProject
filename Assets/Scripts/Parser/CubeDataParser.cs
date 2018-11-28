using LAIGames.Parser.Interface;
using LAIGames.Gameplay;
using UnityEngine;

namespace LAIGames.Parser
{
    public class CubeDataParser : IDataDeserializer<CubeEffects>
    {
        public CubeEffects Deserialize(string jsonString)
        {
            return JsonUtility.FromJson<CubeEffects>(jsonString);
        }
    }
}