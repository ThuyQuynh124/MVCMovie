using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class EmployGenreViewModel
    {
        public List<Employee> Employees { get; set; }
        public SelectList Genres { get; set; }
        public string EmployGenre { get; set; } 
        public string SearchString { get; set; }
    }
}
