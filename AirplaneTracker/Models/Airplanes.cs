//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirplaneTracker.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[MetadataType(typeof(AirplanesMetadata))]
    public partial class Airplanes
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // propConfig.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        //[Column(Order = 1)]
        [Display(Name = "Airplane Name")]
        public string name { get; set; }
        [Display(Name = "Airplane Type")]
        public int? AirplaneType { get; set; }
        [DisplayName("Maximum passengers")]
        [Range(1,1000,ErrorMessage ="passengers can not be more than 1000")]
        public int? maxpass { get; set; }
        [Range(1, 100, ErrorMessage = "input out of range,100")]
        public int? size { get; set; }
        [Display(Name = "Current Airport")]
        public int? currentAirport { get; set; }
        [Display(Name = "current main pilot")]
        //[Display(Name = "current pilot")]
        public int? currentpilot { get; set; }
        //[Display(Name = "current copilot")]
        //[Display(Name = "current pilot")]
        [Display(Name = "currentcopilot",Order =6)]
       // [Column(Order = 6)]
        public int? currentcopilot { get; set; }

     
        public virtual AirplaneType tblAirplaneType { get; set; }
        public virtual Airports Airports { get; set; }
        //[Display(Name = "current pilot")]
        
        public virtual pilots tblpilots { get; set; }
        //[Display(Name = "current copilot")]
        public virtual pilots tblpilots1 { get; set; }
        //public int AirportID { get; set; }
    }
    //public class AirplanesMetadata
    //{
    //    [Display(Name = "current pilot")]
    //    public int? currentpilot { get; set; }
    //    [Display(Name = "current copilot")]
    //    public int? currentcopilot { get; set; }
    //}
}
