//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myimage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class contactform
    {
        public int ctcid { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Enter Message")]
        public string Message { get; set; }
    }
}
