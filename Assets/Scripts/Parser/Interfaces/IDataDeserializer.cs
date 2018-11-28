
namespace LAIGames.Parser.Interface
{
    public interface IDataDeserializer<T>   {
        T Deserialize(string jsonString);
    }
}
