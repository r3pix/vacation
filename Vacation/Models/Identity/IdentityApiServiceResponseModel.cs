using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class IdentityApiServiceResponseModel
{
    [JsonProperty("result")]
    public Result Result { get; set; }
}

public partial class Result
{
    [JsonProperty("requestDateTime")]
    public string RequestDateTime { get; set; }

    [JsonProperty("requestId")]
    public string RequestId { get; set; }

    [JsonProperty("subject")]
    public Subject Subject { get; set; }
}

public partial class Subject
{
    [JsonProperty("accountNumbers")]
    public string[] AccountNumbers { get; set; }

    [JsonProperty("authorizedClerks")]
    public object[] AuthorizedClerks { get; set; }

    [JsonProperty("hasVirtualAccounts")]
    public bool HasVirtualAccounts { get; set; }

    [JsonProperty("krs")]
    public string Krs { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("nip")]
    public string Nip { get; set; }

    [JsonProperty("partners")]
    public object[] Partners { get; set; }

    [JsonProperty("pesel")]
    public object Pesel { get; set; }

    [JsonProperty("registrationDenialBasis")]
    public object RegistrationDenialBasis { get; set; }

    [JsonProperty("registrationDenialDate")]
    public object RegistrationDenialDate { get; set; }

    [JsonProperty("registrationLegalDate")]
    public DateTimeOffset RegistrationLegalDate { get; set; }

    [JsonProperty("regon")]
    public string Regon { get; set; }

    [JsonProperty("removalBasis")]
    public object RemovalBasis { get; set; }

    [JsonProperty("removalDate")]
    public object RemovalDate { get; set; }

    [JsonProperty("representatives")]
    public object[] Representatives { get; set; }

    [JsonProperty("residenceAddress")]
    public string ResidenceAddress { get; set; }

    [JsonProperty("restorationBasis")]
    public object RestorationBasis { get; set; }

    [JsonProperty("restorationDate")]
    public object RestorationDate { get; set; }

    [JsonProperty("statusVat")]
    public string StatusVat { get; set; }

    [JsonProperty("workingAddress")]
    public string WorkingAddress { get; set; }
}