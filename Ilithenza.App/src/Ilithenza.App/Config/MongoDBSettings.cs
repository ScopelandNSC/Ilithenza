using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ilithenza.App.Config
{
    public class MongoDBSettings
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
