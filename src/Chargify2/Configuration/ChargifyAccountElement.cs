#region License, Terms and Conditions

//
// ChargifyAccountElement.cs
//
// Authors: Kori Francis <twitter.com/djbyter>
// Copyright (C) 2013 Kori Franics. All rights reserved.
//
//  THIS FILE IS LICENSED UNDER THE MIT LICENSE AS OUTLINED IMMEDIATELY BELOW:
//
//  Permission is hereby granted, free of charge, to any person obtaining a
//  copy of this software and associated documentation files (the "Software"),
//  to deal in the Software without restriction, including without limitation
//  the rights to use, copy, modify, merge, publish, distribute, sublicense,
//  and/or sell copies of the Software, and to permit persons to whom the
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//  DEALINGS IN THE SOFTWARE.
//

#endregion

namespace Chargify2.Configuration
{
    #region Imports

    using System;
    using System.Configuration;

    #endregion

    /// <summary>
    /// The object that holds information about a Chargify account, including name, site, apikey and password
    /// </summary>
    public class ChargifyAccountElement : ConfigurationElement
    {
        /// <summary>
        /// The "Name" of the site, used when setting the Default
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// The API key (provided in the Chargify account) needed for security reasons
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = true, DefaultValue = "AbCdEfGhIjKlMnOpQrSt")]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        /// <summary>
        /// The API password (provided in the Chargify account) needed for security reasons
        /// </summary>
        [ConfigurationProperty("apiPassword", IsRequired = true, DefaultValue = "P")]
        public string ApiPassword
        {
            get { return (string)this["apiPassword"]; }
            set { this["apiPassword"] = value; }
        }

        /// <summary>
        /// The secret key (used for generating and verifying signatures)
        /// </summary>
        [ConfigurationProperty("secret", IsRequired = true)]
        public string Secret
        {
            get { return (string)this["secret"]; }
            set { this["secret"] = value; }
        }

        /// <summary>
        /// A proxy, if required.
        /// </summary>
        [ConfigurationProperty("proxy", IsRequired = false)]
        public Uri Proxy
        {
            get { return (Uri)this["proxy"]; }
            set { this["proxy"] = value; }
        }
    }
}
