using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProperty.Models
{
    public class PropertyImage
    {
        /// <summary>
        /// identificador de la tabla (PK)  de la tabla PropertyImage
        /// </summary>
        [Key]
        public int idPropertyImage { get; set; }

        /// <summary>
        /// campo string refiere al campo file de la tabla PropertyImage
        /// </summary>
        public string file { get; set; }

        /// <summary>
        ///  campo string refiere al campo enabled de la tabla PropertyImage
        /// </summary>
        public Boolean enabled { get; set; }

        /// <summary>
        ///  campo tipo entero refiere al campo idProperty de la tabla PropertyTrace (fk de la tabla Property)
        /// </summary>
        public int idProperty { get; set; }

    }
}
