﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFrame.XUnit.Entity
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
