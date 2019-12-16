﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceModel.Type
{
    public class AuthOptions
    {      
        public string SecureKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
    }
}
