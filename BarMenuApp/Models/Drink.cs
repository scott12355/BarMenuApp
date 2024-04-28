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
        [PrimaryKey, AutoIncrement, SQLite.Column("_id")]
        public int Id { get; set; }
        [MaxLength(100),Unique]
		public string Name { get; set; }

        [MaxLength(10000)]
        public string Description { get; set; }

        
        public string Ingredients { get; set; }

        [MaxLength(300)]
        public string AlcholType { get; set; }

         public static Drink FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",,");
            Drink drinkValue = new Drink();
            drinkValue.Name = Convert.ToString(values[0]);
            drinkValue.Description = Convert.ToString(values[1]);
            drinkValue.Ingredients = Convert.ToString(values[2]);
            return drinkValue;
        }

	}
}
