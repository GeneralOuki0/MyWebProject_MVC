using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace MyWebProject.Models
{
    public class ApplicationUser : IdentityUser //only if it's ApplicationUser these below data are seen
    {
        [Required]
        public int Name {  get; set; }
        public String? StreetAddress { get; set; }
        public String? City { get; set; }
        public String? State { get; set; }
        public String? PostalCode { get; set; }       
    }
}
