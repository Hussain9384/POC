namespace RmqLibrary
{
    public interface IRmqService
    {
        void Consume();
        void Publish(int mode,string routingKey);
    }
}