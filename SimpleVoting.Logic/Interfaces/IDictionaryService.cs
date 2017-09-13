using SimpleVoting.Logic.Models;
using System.Collections.Generic;

namespace SimpleVoting.Logic.Interfaces
{
    public interface IDictionaryService
    {
        /// <summary>
        /// Получение списка полов
        /// </summary>
        List<GenderViewModel> GetGenders();
    }
}
