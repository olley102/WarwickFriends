using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friends.Models
{
    class Person
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
    }
}
