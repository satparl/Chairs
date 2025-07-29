namespace MemberApi.Models;
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.4.0.0 (NJsonSchema v11.3.2.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class WrittenQuestion
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("askingMemberId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AskingMemberId { get; set; }

        [Newtonsoft.Json.JsonProperty("house", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public House House { get; set; }

        [Newtonsoft.Json.JsonProperty("memberHasInterest", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool MemberHasInterest { get; set; }

        [Newtonsoft.Json.JsonProperty("dateTabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset DateTabled { get; set; }

        [Newtonsoft.Json.JsonProperty("dateForAnswer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset DateForAnswer { get; set; }

        [Newtonsoft.Json.JsonProperty("uin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Uin { get; set; }

        [Newtonsoft.Json.JsonProperty("questionText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string QuestionText { get; set; }

        [Newtonsoft.Json.JsonProperty("answeringBodyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AnsweringBodyId { get; set; }

        [Newtonsoft.Json.JsonProperty("isWithdrawn", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsWithdrawn { get; set; }

        [Newtonsoft.Json.JsonProperty("isNamedDay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsNamedDay { get; set; }

        [Newtonsoft.Json.JsonProperty("groupedQuestions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> GroupedQuestions { get; set; }

        [Newtonsoft.Json.JsonProperty("groupedQuestionsDates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GroupedQuestion> GroupedQuestionsDates { get; set; }

        [Newtonsoft.Json.JsonProperty("answerIsHolding", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AnswerIsHolding { get; set; }

        [Newtonsoft.Json.JsonProperty("answerIsCorrection", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AnswerIsCorrection { get; set; }

        [Newtonsoft.Json.JsonProperty("answeringMemberId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AnsweringMemberId { get; set; }

        [Newtonsoft.Json.JsonProperty("correctingMemberId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CorrectingMemberId { get; set; }

        [Newtonsoft.Json.JsonProperty("dateAnswered", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? DateAnswered { get; set; }

        [Newtonsoft.Json.JsonProperty("answerText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AnswerText { get; set; }

        [Newtonsoft.Json.JsonProperty("attachmentCount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AttachmentCount { get; set; }

        [Newtonsoft.Json.JsonProperty("heading", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Heading { get; set; }

        [Newtonsoft.Json.JsonProperty("answeringMember", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Member AnsweringMember { get; set; }

        [Newtonsoft.Json.JsonProperty("correctingMember", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Member CorrectingMember { get; set; }

        [Newtonsoft.Json.JsonProperty("answeringBody", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnsweringBody AnsweringBody { get; set; }

    }
