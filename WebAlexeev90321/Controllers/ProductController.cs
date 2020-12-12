
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlexeev90321.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAlexeev90321.Controllers
{
    public class ProductController : Controller
    {
        List<RadioComponent> _radioComponents;
        List<RadioComponentGroup> _radioComponentGroups;

        public ProductController()
        {
            SetupData();
        }
        public IActionResult Index()
        {
            return View(_radioComponents);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _radioComponentGroups = new List<RadioComponentGroup>
            {
                new RadioComponentGroup {RadioComponentGroupId=1, GroupName="Резисторы"},
                new RadioComponentGroup {RadioComponentGroupId=2, GroupName="Диоды"},
                new RadioComponentGroup {RadioComponentGroupId=3, GroupName="Шнуры"}
            };
            _radioComponents = new List<RadioComponent>
            {
                new RadioComponent {RadioComponentId=1,RadioComponentName="Диод быстропереключающий BAV199 / 0.14А, 85В, SOT-23", Price=2500,RadioComponentGroupId=1, Image="diod.jpg"},
                new RadioComponent {RadioComponentId=2,RadioComponentName="Шнур STA-201A 1m / штекер HDMI на штекер HDMI 1м", Price=180,RadioComponentGroupId=2, Image="hdmi.jpg"},
                new RadioComponent {RadioComponentId=3,RadioComponentName="Резистор выводной 39R 5W ±5% / RX27-1 (SQP)", Price=120,RadioComponentGroupId=3, Image="rez.jpg"},
                new RadioComponent {RadioComponentId=4,RadioComponentName="Шнур MicroUSB M USB-A M 1.8m F / штекер USB A на штекер micro USB B 1.8м", RadioComponentGroupId=2, Price=50, Image="usb.jpg"},
            };
        }
       
    }
}
