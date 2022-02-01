﻿namespace SelfWashSystem.Abstractions.Models
{
    public class Service
    {
        public ushort KeyNumber { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public uint SecondsPerToken { get; private set; }
        public ushort LiquidContainerIndex { get; private set; }
        public ushort PumpIndex { get; private set; }

        public Service(ushort keyNumber, string name, string description, uint secondsPerToken, ushort liquidContainerIndex, ushort pumpIndex)
        {
            Name = name;
            Description = description;
            SecondsPerToken = secondsPerToken;
            LiquidContainerIndex = liquidContainerIndex;
            PumpIndex = pumpIndex;
            KeyNumber = keyNumber;
        }
    }
}
