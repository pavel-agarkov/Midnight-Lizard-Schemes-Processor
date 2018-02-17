﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidnightLizard.Schemes.Infrastructure.Serialization.Common
{
    public class MessageAttribute : Attribute
    {
        private string version;
        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = System.Version.Parse(value).ToString();
            }
        }

        /// <summary>
        /// Custom message type.
        /// No need to provide if it exactly matches with 
        /// <see cref="IMessageDeserializer"/> generic type parameter TMessage type name
        /// </summary>
        public string Type { get; set; }
    }
}