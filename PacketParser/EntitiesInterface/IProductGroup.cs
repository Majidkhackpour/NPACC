﻿using System;

namespace PacketParser.EntitiesInterface
{
    public interface IProductGroup : IHasGuid
    {
        string Code { get; set; }
        string Name { get; set; }
        Guid ParentGuid { get; set; }
        string Description { get; set; }
    }
}
