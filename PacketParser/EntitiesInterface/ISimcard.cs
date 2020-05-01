using System;

namespace PacketParser.EntitiesInterface
{
    public interface ISimcard : IHasGuid
    {
        long Number { get; set; }
        string OwnerName { get; set; }
        string DivarToken { get; set; }
        string ChatToken { get; set; }
        Guid? ChatCat1 { get; set; }
        Guid? ChatCat2 { get; set; }
        Guid? ChatCat3 { get; set; }
    }
}
