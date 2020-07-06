namespace PacketParser.EntitiesInterface
{
    public interface IOpinion : IHasGuid
    {
        string Name { get; set; }
        string Email { get; set; }
        string Opinion { get; set; }
    }
}
