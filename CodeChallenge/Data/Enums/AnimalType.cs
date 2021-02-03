using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.Data.Enums
{
    public enum AnimalType
    {
        [Description("Carnívoro")]
        Carnívoro = 0,
        [Description("Hervíboro")]
        Hervíboro = 1,
        [Description("Reptil")]
        Reptil = 2,
    }
}
