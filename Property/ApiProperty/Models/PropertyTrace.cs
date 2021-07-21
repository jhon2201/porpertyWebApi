using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProperty.Models
{
    public class PropertyTrace
    {
        /// <summary>
        /// identificador de la tabla (PK)  de la tabla PropertyTrace
        /// </summary>
        [Key]
        public int IdPropertyTrace { get; set; }

        /// <summary>
        /// campo date refiere al campodateSale  de la tabla PropertyTrace
        /// </summary>
        public DateTime dateSale { get; set; }

        /// <summary>
        /// campo tipo string refiere al camponame de la tabla PropertyTrace
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// campo tipo decimal refiere al campovalue de la tabla PropertyTrace
        /// </summary>
        public decimal value { get; set; }

        /// <summary>
        /// campo tipo decimal refiere al campotax de la tabla PropertyTrace
        /// </summary>
        public decimal tax { get; set; }

        /// <summary>
        /// campo tipo decimal refiere al campoidProperty de la tabla PropertyTrace (fk de la tabla Property)
        /// </summary>
        public int idProperty { get; set; }

    }
}
