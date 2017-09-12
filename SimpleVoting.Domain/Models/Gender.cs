using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleVoting.Domain.Models
{
    /// <summary>
    /// Пол
    /// </summary>
    [Table("Gender", Schema = "dbo")]
    public class Gender
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string GenderName { get; set; }

        /// <summary>
        /// Пользователи данного пола
        /// </summary>
        public List<User> Users { get; set; }
    }
}
