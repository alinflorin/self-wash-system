namespace SelfWashSystem.Abstractions.Models
{
    public class Service
    {
        public ushort KeyNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint SecondsPerToken { get; set; }
        public ushort LiquidContainerIndex { get; set; }
        public ushort PumpIndex { get; set; }

        public Service() { }

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
