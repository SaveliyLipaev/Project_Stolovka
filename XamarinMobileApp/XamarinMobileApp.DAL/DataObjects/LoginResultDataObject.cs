﻿using Newtonsoft.Json;
using System;

namespace XamarinMobileApp.DAL.DataObjects
{
    public class LoginResultDataObject
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Distributor { get; set; }
        public DateTimeOffset ExpireAt { get; set; }

        [JsonIgnore]
        public LoginState LoginState { get; set; }

        [JsonIgnore]
        public string ErrorString { get; set; }
    }

    public enum LoginState
    {
        Failed,
        Canceled,
        Success
    }
}
