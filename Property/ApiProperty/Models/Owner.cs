using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProperty.Models
{
    public class Owner
    {
        /// <summary>
        /// identificador de la tabla (PK)  de la tabla Owner
        /// </summary>
        [Key]
        public int idOwner { get; set; }

        /// <summary>
        /// campo string refiere al campo name de la tabla Owner
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// campo string refiere al campo address de la tabla Owner
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// campo string refiere al campo photo de la tabla Owner
        /// </summary>
        public string photo { get; set; }

        /// <summary>
        /// campo date refiere al campo birthdate de la tabla Owner
        /// </summary>
        public DateTime birthdate { get; set; }

    }
}
