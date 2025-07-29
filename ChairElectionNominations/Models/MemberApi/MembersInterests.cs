namespace MemberApi.Models;
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class MembersInterests
    {
        [Newtonsoft.Json.JsonProperty("member", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Member Member { get; set; }

        [Newtonsoft.Json.JsonProperty("interestCategories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RegisteredInterestCategory> InterestCategories { get; set; }

    }