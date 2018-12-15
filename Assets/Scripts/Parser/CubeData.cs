using System.IO;
using UnityEngine;

namespace LAIGames
{
    public static class CubeData
    {
        const string DATAJSONPATH = "Assets/Data.json";

        public static string DataString;
        public static string GetCubeData()
        {
            if (string.IsNullOrEmpty(DataString))
            {
                StreamReader reader = new StreamReader(DATAJSONPATH);

                DataString = reader.ReadToEnd();
                Debug.Log(DataString);
                reader.Close();
            }
            return DataString;
        }
    }
}
