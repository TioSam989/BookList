using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookList.Models
{
    internal class Book
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }

    }

}
