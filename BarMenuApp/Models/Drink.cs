using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarMenuApp.Models
{
	[SQLite.Table("drink")]
    public class Drink
    {

        public int id { get; set; }

		public string Name { get; set; }


        public string Description { get; set; }

        
        public string Ingredients { get; set; }


        public string Price { get; set; }



	}
}
