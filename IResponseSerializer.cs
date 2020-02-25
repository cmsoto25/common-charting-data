namespace TC.AmiBroker.Data
{
    public interface IResponseSerializer<T>
    {
        string Serialize(T data);
        T Deserialize(string data);
    }
}
