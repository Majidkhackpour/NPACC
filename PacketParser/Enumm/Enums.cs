using PacketParser.Services;

namespace PacketParser.Enumm
{
    public class Enums
    {
        public enum EnPartDate
        {
            [PersianNameAttribute.PersianName("سال")] Year = 1,
            [PersianNameAttribute.PersianName("ماه")] Mounth = 2,
            [PersianNameAttribute.PersianName("روز")] Day = 3
        }
    }
}
