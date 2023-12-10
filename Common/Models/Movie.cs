using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Movie : MongoDocument
    {
        public string Name { get; set; }
        public List<string> Actors { get; set; }
        public decimal? Buget { get; set; }
        public string Description { get; set; }
    }
}
