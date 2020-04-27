using System;

namespace PacketParser.EntitiesInterface
{
    public interface ICustomer : IHasGuid
    {
        string Name { get; set; }
        string Description { get; set; }
        string Phone1 { get; set; }
        string Phone2 { get; set; }
        string Address { get; set; }
        string PostalCode { get; set; }
        string NationalCode { get; set; }
        EnNahveAshnaei NahveAshnaei { get; set; }
        Guid GroupGuid { get; set; }
    }
}
