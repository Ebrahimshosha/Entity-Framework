﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_First.Models
{
    public partial class Category
    {
        public override string ToString()
            => $"{CategoryName} ::: {Description}";
    }
}
