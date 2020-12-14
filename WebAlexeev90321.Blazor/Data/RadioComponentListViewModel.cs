using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WebAlexeev90321.Blazor.Data
{
    public class RadioComponentListViewModel
    {
        [JsonPropertyName("radioComponentId")]
        public int RadioComponentId { get; set; } // id 
        [JsonPropertyName("radioComponentName")]
        public string RadioComponentName { get; set; } // название блюда
    }

    public class RadioComponentDetailsViewModel
    {
        [JsonPropertyName("radioComponentName")]
        public string RadioComponentName { get; set; } // название 
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание блюда
        [JsonPropertyName("price")]
        public int Price { get; set; } // цена
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }

}
