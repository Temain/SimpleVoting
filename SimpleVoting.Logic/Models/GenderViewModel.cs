using System.ComponentModel.DataAnnotations;

namespace SimpleVoting.Logic.Models
{
    /// <summary>
    /// Пол
    /// </summary>
    public class GenderViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int GenderId { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Required]
        [StringLength(20)]
        public string GenderName { get; set; }
    }
}
