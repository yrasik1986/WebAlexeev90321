using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAlexeev90321.Blazor.Data
{
    public class CounterModel
    {
        [DataType("int")]
        [Range(0, int.MaxValue)]
        public int CounterValue { get; set; }
    }
}
