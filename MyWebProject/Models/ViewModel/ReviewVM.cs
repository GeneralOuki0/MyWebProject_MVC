using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebProject.Models.ViewModel
{
    public class ReviewVM
    {
        public Product Product { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public Review NewReview { get; set; }
    }
}
