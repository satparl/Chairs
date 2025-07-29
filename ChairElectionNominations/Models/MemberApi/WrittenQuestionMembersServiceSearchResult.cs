namespace MemberApi.Models;
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class WrittenQuestionMembersServiceSearchResult
    {
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<WrittenQuestionItem> Items { get; set; }

        [Newtonsoft.Json.JsonProperty("totalResults", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TotalResults { get; set; }

        [Newtonsoft.Json.JsonProperty("resultContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResultContext { get; set; }

        [Newtonsoft.Json.JsonProperty("skip", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Skip { get; set; }

        [Newtonsoft.Json.JsonProperty("take", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Take { get; set; }

        [Newtonsoft.Json.JsonProperty("links", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Link> Links { get; set; }

        [Newtonsoft.Json.JsonProperty("resultType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MatchedBy? ResultType { get; set; }

    }