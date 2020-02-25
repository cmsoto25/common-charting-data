namespace TC.AmiBroker.Data
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public partial class TrendLines : ICloneable
    {
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public Price[][] Price { get; set; }

        [JsonProperty("rsi", NullValueHandling = NullValueHandling.Ignore)]
        public Price[][] Rsi { get; set; }

        public object Clone()
        {
            return new TrendLines()
            {
                Price = this.Price != null ? 
                    this.Price.Select(
                        p => p.Select(
                            p1 => p1.Clone() as Price
                        ).ToArray()
                    ).ToArray() : 
                    Array.Empty<Price[]>(),
                Rsi = this.Rsi != null ? 
                    this.Rsi.Select(
                        r => r.Select(
                            r1 => r1.Clone() as Price
                        ).ToArray()
                    ).ToArray() : 
                    Array.Empty<Price[]>()
            };
        }
    }
}
