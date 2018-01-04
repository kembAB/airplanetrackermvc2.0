using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AirplaneTracker.Models
{
    [MetadataType(typeof(IdMetaData))]
    public partial class User
    {
    }
    public class IdMetaData
    {
        [Remote("is id available", "Airports",ErrorMessage ="id already been used")]
        public int id { get; set; }
    }
}