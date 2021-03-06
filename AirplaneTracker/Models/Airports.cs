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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Airports
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airports()
        {
            this.Airplanes = new HashSet<Airplanes>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
        //[Range(1, maximum: 900000,ErrorMessage ="id must be double number and positive  ")]
        //[Required(ErrorMessage ="id is required and and is to be unique and positive")]
        public int id { get; set; }
        [Required(ErrorMessage = "name is required")]
        [Display(Name = "Airport Name")]
        public string name { get; set; }
        [Required(ErrorMessage ="city is required")]
        [Display(Name ="Airport city")]
        public string city { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Airplanes> Airplanes { get; set; }
    }
}
