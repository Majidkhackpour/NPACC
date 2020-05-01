namespace PacketParser.EntitiesInterface
{
    public interface IChatNumbers : IHasGuid
    {
        long FromNumber { get; set; }
        string Number { get; set; }
        string City { get; set; }
        string Category { get; set; }
        bool IsSendChat { get; set; }
        bool IsSendSMS { get; set; }
    }
}
