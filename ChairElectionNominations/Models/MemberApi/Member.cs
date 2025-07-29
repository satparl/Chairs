namespace MemberApi.Models;
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Member
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("nameListAs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameListAs { get; set; }

        [Newtonsoft.Json.JsonProperty("nameDisplayAs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameDisplayAs { get; set; }

        [Newtonsoft.Json.JsonProperty("nameFullTitle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameFullTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("nameAddressAs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameAddressAs { get; set; }

        [Newtonsoft.Json.JsonProperty("latestParty", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Party LatestParty { get; set; }

        [Newtonsoft.Json.JsonProperty("gender", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [Newtonsoft.Json.JsonProperty("latestHouseMembership", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HouseMembership LatestHouseMembership { get; set; }

        [Newtonsoft.Json.JsonProperty("thumbnailUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ThumbnailUrl { get; set; }

    }