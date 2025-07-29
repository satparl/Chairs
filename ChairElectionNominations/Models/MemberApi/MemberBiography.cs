namespace MemberApi.Models;
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class MemberBiography
    {
        [Newtonsoft.Json.JsonProperty("representations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RepresentationItem> Representations { get; set; }

        [Newtonsoft.Json.JsonProperty("electionsContested", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> ElectionsContested { get; set; }

        [Newtonsoft.Json.JsonProperty("houseMemberships", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> HouseMemberships { get; set; }

        [Newtonsoft.Json.JsonProperty("governmentPosts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> GovernmentPosts { get; set; }

        [Newtonsoft.Json.JsonProperty("oppositionPosts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> OppositionPosts { get; set; }

        [Newtonsoft.Json.JsonProperty("otherPosts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> OtherPosts { get; set; }

        [Newtonsoft.Json.JsonProperty("partyAffiliations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> PartyAffiliations { get; set; }

        [Newtonsoft.Json.JsonProperty("committeeMemberships", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<BiographyItem> CommitteeMemberships { get; set; }

    }
