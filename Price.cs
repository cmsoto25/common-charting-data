namespace TC.AmiBroker.Data
{
    using System;
    using Newtonsoft.Json;

    public partial class Price : ICloneable
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public float Value { get; set; }

        public object Clone()
        {
            return new Price()
            {
                Date = this.Date,
                Value = this.Value
            };
        }
    }
}
