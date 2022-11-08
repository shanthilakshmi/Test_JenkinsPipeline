using System.ComponentModel.DataAnnotations; 


namespace WebApplication1.Models
{
    public class SimpleApp
    {
        [Required] //to mark field as required, by importing DataAnnotations
        public string expression { get; set; }

     
    }
}