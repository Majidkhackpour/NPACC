﻿using System;
using PacketParser.EntitiesInterface;

namespace EntityCache.WebBussines
{
    public class WebProductPictures : IProductPictures
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string ImageName { get; set; }
        public Guid PrdGuid { get; set; }
    }
}
