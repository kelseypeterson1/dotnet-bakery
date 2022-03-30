using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    // an enumeration, a list
        public enum BreadType
        {
            Sourdough,      // 0
            Pumpernickel,   // 1
            French,         // 2
            Brioche,
            Artisan,
            Wheat,
        }
    public class Bread 
    {
        public int id {get;set;}
        public string name {get;set;}
        public string description {get;set;}

        // bread type from the above enum
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BreadType type {get;set;}

        // how many
        public int count {get;set;}

        // relate this bread to the baker in the DB
        [ForeignKey("bakedBy")]
        public int bakedById {get;set;}

        public Baker bakedBy {get;set;}
    }
}
