namespace DeepSpace.Local
{
    public class Client
    {
        public Client(string name, long id) {ClientName = name; ClientId = id;}
        
        public readonly string ClientName;
        public readonly long ClientId;
    }
}