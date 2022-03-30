using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        // attribute assumed
        public int id {get;set;} // EF knows this is serial primary key

        [Required] // attribute
        // just like NOT NULL
        public string name {get;set;}

    }
}
