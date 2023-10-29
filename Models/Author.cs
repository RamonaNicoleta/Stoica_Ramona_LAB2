﻿using System.ComponentModel.DataAnnotations;

namespace Stoica_Ramona_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
     
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string FullName
        {
            get { return $"{LastName} {FirstName}"; }
        }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public ICollection<Book>? Books { get; set; } // navigation property
    }
}
