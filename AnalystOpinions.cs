namespace TC.AmiBroker.Data
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public partial class AnalystOpinions : ICloneable
    {
        [JsonProperty("supports")]
        public float[] Supports { get; set; }

        [JsonProperty("analystTime")]
        public string AnalystTime { get; set; }

        [JsonProperty("pivot")]
        public float Pivot { get; set; }

        [JsonProperty("resistances")]
        public float[] Resistances { get; set; }

        [JsonProperty("opportunityType")]
        public string OpportunityType { get; set; }

        [JsonProperty("arrowPoints")]
        public ArrowPoint[] ArrowPoints { get; set; }

        [JsonProperty("trendLines")]
        public TrendLines TrendLines { get; set; }

        public AnalystOpinions()
        {
            ArrowPoints = new ArrowPoint[0];
        }

        public object Clone()
        {
            return new AnalystOpinions()
            {
                Supports = (float[])this.Supports.Clone(),
                AnalystTime = string.Copy(this.AnalystTime),
                Pivot = this.Pivot,
                Resistances = (float[])this.Resistances.Clone(),
                OpportunityType = string.Copy(this.OpportunityType),
                ArrowPoints = this.ArrowPoints != null ?
                    this.ArrowPoints.Select(
                        ap => ap.Clone() as ArrowPoint
                    ).ToArray() :
                    Array.Empty<ArrowPoint>(),
                TrendLines = this.TrendLines.Clone() as TrendLines
            };
        }
    }
}
