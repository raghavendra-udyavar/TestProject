using LAIGames.Parser.Interface;
using LAIGames.Gameplay;
using UnityEngine;

namespace LAIGames.Parser
{
    public class CubeEffectDataParser : IDataDeserializer<CubeEffectData>
    {
        public CubeEffectData Deserialize(string jsonString)
        {
            return JsonUtility.FromJson<CubeEffectData>(jsonString);
        }
    }
}