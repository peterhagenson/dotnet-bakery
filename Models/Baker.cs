using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        //properties -> colums
        //EF knows this is a primary key and serial
        public int id {get; set;}

        [Required] // C# attribute, NOT NULL
        public string name {get; set;}
    }
}
