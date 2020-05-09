namespace PacketParser.EntitiesInterface
{
    public interface IRolles : IHasGuid
    {
        string RolleTitle { get; set; }
        string RolleName { get; set; }
    }
}
