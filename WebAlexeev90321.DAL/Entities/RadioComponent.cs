using System;
using System.Collections.Generic;
using System.Text;

namespace WebAlexeev90321.DAL.Entities
{
    public class RadioComponent
    {
        public int RadioComponentId { get; set; } // id радидетали
        public string RadioComponentName { get; set; } // название радидетали
        public string Description { get; set; } // описание радидетали
        public int Price { get; set; } // цена радидетали
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int RadioComponentGroupId { get; set; }
        public RadioComponentGroup Group { get; set; }
    }
}
