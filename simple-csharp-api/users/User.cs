using simple_csharp_api.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simple_csharp_api.users
{
    //[Table("users", Schema = "public")]
    [Table("users")]
    public partial class User : IEntity
    {
        public int id { get; set; }

        [Required]
        [Column("email")]
        public String email { get; set; }

        [Required]
        [Column("given_name")]
        public String givenName { get; set; }

        [Required]
        [Column("surname")]
        public String surname { get; set; }

        [Column("country_code")]
        public String countryCode { get; set; }
    }
}
