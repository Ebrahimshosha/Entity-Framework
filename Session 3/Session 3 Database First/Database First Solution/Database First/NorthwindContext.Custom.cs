using Database_First.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_First.Models
{
    public partial class NorthwindContext : DbContext
	{
		public virtual DbSet<SalesByCategory> SalesByCategories { get; set; }

		  
	}
}
