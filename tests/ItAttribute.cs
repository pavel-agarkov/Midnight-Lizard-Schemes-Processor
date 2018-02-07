﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace MidnightLizard.Schemes.Tests
{
    /// <summary>
    /// Xunit Fact with custom test name processing
    /// </summary>
    public class ItAttribute : FactAttribute
    {
        public ItAttribute(string fullName) : base()
        {
            //DisplayName = Regex.Replace(Regex.Replace(Regex.Replace(
            //    displayName, @"((?:[A-Z])+[^A-Z]*)", "$1 "), "_", " "), "  ", " ")
            //    .Trim().ToLower();

            //DisplayName = string.Join(" ", Regex
            //    .Split(displayName, @"_|((?:[A-Z])+[^A-Z_]*)")
            //    .Select(x => x.Trim()));

            DisplayName = fullName.Replace("__", ".").Replace("_", " ");
        }

        public ItAttribute(string it, string should) : this($"{it} - {should}")
        {

        }

    }
}
