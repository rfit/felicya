using System;
using System.ComponentModel.DataAnnotations;

namespace FelicyaClient.Models
{
    public class WelcomeModel
    {
        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Please specify a valid email")]
        public string ProjectID { get; set; }

        //[Required(ErrorMessage = "You must accept this condition to apply for a volunteerings job a Roskilde Festvalen")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept this condition to apply for a volunteerings job a Roskilde Festvalen")]
        //[Display(Name = "I hereby give my express permission that my personal information may be used and processed by Roskilde Kulturservice and the Roskilde Festival Charity Society including organisations that are engaging volunteers for this year's Roskilde Festival.")]
        //public bool AcceptConditions { get; set; }
    }
}