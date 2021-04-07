using System;
using System.ComponentModel.DataAnnotations;

namespace gregsListC_Wdb.Models
{
    public class Car{
 
    [Required]
    [MinLength(3)]
    public string Make {get; set;}  
    public string Model{get; set;}
    public int? Price{get; set;}    
    public int? Year{get; set;}
    public string ImgUrl{get; set;}
    [MaxLength(200)]
    public string Description{get; set;}
    public int Id { get; set; }
}
}