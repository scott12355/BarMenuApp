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

        [MaxLength(300)]
        public string Catagory { get; set; }

        [MaxLength(300)]
        public string AlcholType { get; set; }

	}
}
