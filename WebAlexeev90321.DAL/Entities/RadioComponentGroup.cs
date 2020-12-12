using System;
using System.Collections.Generic;
using System.Text;

namespace WebAlexeev90321.DAL.Entities
{
    public class RadioComponentGroup
    {
        public int RadioComponentGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<RadioComponent> RadioComponents { get; set; }

    }
}
