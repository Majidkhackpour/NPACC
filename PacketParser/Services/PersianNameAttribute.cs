using System;

namespace PacketParser.Services
{
    public static partial class PersianNameAttribute
    {
        public class PersianName : Attribute
        {
            public readonly string Text;

            public PersianName(string text)
            {
                Text = text;
            }
        }
    }
}
