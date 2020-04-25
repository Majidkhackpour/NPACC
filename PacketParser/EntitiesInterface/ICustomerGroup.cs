using System;

namespace PacketParser.EntitiesInterface
{
    public interface ICustomerGroup : IHasGuid
    {
        string Name { get; set; }
        Guid ParentGuid { get; set; }
        string Description { get; set; }
    }
}
