using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProperty.Models
{
    public class Property
    {
        /// <summary>
        ///  identificador de la tabla (PK)  de la tabla Property
        /// </summary>
        [Key]
        public int idProperty { get; set; }

        /// <summary>
        /// campo string refiere al campo name de la tabla Property
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// campo string refiere al campo address de la tabla Property
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// campo decimal refiere al campo price de la tabla Property
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// campo string refiere al campo codeInternal de la tabla Property
        /// </summary>
        public string codeInternal { get; set; }

        /// <summary>
        ///  campo string refiere al campo year de la tabla Property
        /// </summary>
        public int year { get; set; }

        /// <summary>
        ///  campo tipo entero refiere al campo idOwner de la tabla Property (fk de la tabla Owner)
        /// </summary>
        public int idOwner { get; set; }

    }
}
