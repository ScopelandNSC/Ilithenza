using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OWL_REACT.Config
{
    public class OverwatchApiSettings
    {
        [Required]
        public string BaseUrl { get; set; }
    }
}
