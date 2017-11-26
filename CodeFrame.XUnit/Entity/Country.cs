using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
