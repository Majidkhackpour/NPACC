using System;

namespace PacketParser.EntitiesInterface
{
    public interface IPrdFeatures : IHasGuid
    {
        Guid PrdGuid { get; set; }
        Guid FeatureGuid { get; set; }
        string Value { get; set; }
    }
}
