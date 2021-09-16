using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class IdentityApiServiceErrorResponseModel
{
    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("errors")]
    public List<string> Errors { get; set; }

    [JsonProperty("isError")]
    public bool IsError { get; set; }

}