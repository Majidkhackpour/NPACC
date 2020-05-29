using System;

namespace PacketParser.EntitiesInterface
{
    public interface ISlider : IHasGuid
    {
        string Title { get; set; }
        string ImageName { get; set; }
        string URL { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool IsActive { get; set; }
    }
}
