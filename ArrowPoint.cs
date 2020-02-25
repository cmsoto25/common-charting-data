namespace TC.AmiBroker.Data
{
    using System;
    using Newtonsoft.Json;

    public partial class ArrowPoint : ICloneable
    {
        [JsonProperty("bufferIndex")]
        public long BufferIndex { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        public object Clone()
        {
            return new ArrowPoint()
            {
                BufferIndex = this.BufferIndex,
                Value = this.Value
            };
        }
    }
}
