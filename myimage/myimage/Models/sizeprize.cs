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
    
    public partial class sizeprize
    {
        public int sizeid { get; set; }
        public string size { get; set; }
        public int prize { get; set; }
    
        public virtual userproduct userproduct { get; set; }
    }
}
