namespace TC.AmiBroker.Data
{
    using System;
    using Newtonsoft.Json;

    public partial class AnalysisData : ICloneable
    {
        [JsonProperty("instrumentSymbol")]
        public string InstrumentSymbol { get; set; }

        [JsonProperty("amiBrokerSymbol", DefaultValueHandling = DefaultValueHandling.Populate, NullValueHandling = NullValueHandling.Ignore)]
        public string AmiBrokerSymbol { get; set; }

        [JsonProperty("productId", DefaultValueHandling = DefaultValueHandling.Populate)]
        public int ProductId { get; set; }

        [JsonProperty("pricePeriod")]
        public string PricePeriod { get; set; }

        [JsonProperty("analystOpinions")]
        public AnalystOpinions AnalystOpinions { get; set; }
        public AnalysisData()
        {
            AnalystOpinions = new AnalystOpinions();

            // Fix up the first arrow point buffer to be one bar after the last price bar to leave some additional breathing space
            if (AnalystOpinions.ArrowPoints.Length > 0)
            {
                AnalystOpinions.ArrowPoints[0].BufferIndex = 1;
            }
        }

        public static AnalysisData FromJson(string json)
        {
            JsonResponseSerializer<AnalysisData> serializer = new JsonResponseSerializer<AnalysisData>();
            return serializer.Deserialize(json);
        }

        public object Clone()
        {
            return new AnalysisData()
            {
                InstrumentSymbol = string.Copy(this.InstrumentSymbol),
                AmiBrokerSymbol = this.AmiBrokerSymbol,
                ProductId = this.ProductId,
                PricePeriod = string.Copy(this.PricePeriod),
                AnalystOpinions = this.AnalystOpinions.Clone() as AnalystOpinions
            };
        }
    }
}
