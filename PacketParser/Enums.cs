using PacketParser.Services;

namespace PacketParser
{
    public enum EnPartDate
    {
        [PersianNameAttribute.PersianName("سال")] Year = 1,
        [PersianNameAttribute.PersianName("ماه")] Mounth = 2,
        [PersianNameAttribute.PersianName("روز")] Day = 3
    }
    public enum ReturnedState : short
    {
        Information = 1,
        Error = 2,
        Warning = 3
    }
}
