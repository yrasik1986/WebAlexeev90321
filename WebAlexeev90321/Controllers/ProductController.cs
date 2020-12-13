
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAlexeev90321.DAL.Entities;
using WebAlexeev90321.Models;
using WebAlexeev90321.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace WebAlexeev90321.Controllers
{
    public class ProductController : Controller
    {
        public List<RadioComponent> _radioComponents;
        List<RadioComponentGroup> _radioComponentGroups;
        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
      
        public IActionResult Index(int? group, int pageNo = 1)
        {

            // Поместить список групп во ViewData
            var radioComponentsFiltered = _radioComponents.Where(d => !group.HasValue || d.RadioComponentGroupId == group.Value);
            ViewData["Groups"] = _radioComponentGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
         

            var model = ListViewModel<RadioComponent>.GetModel(radioComponentsFiltered, pageNo,_pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);

            else
                return View(model);

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
                new RadioComponent {RadioComponentId=1,RadioComponentName="Диод быстропереключающий BAV199", Description = "0.14А, 85В, SOT-23", Price=2500,RadioComponentGroupId=2, Image="diod.jpg"},
                new RadioComponent {RadioComponentId=2,RadioComponentName="Диод DGPE30-E3/54",Description = "3А, 1400В, DO-201", Price=2500,RadioComponentGroupId=2, Image="diod2.jpg"},      
                new RadioComponent {RadioComponentId=3,RadioComponentName="Шнур STA-201A ",Description = "штекер HDMI на штекер HDMI 1м", Price=180,RadioComponentGroupId=3, Image="hdmi.jpg"},
                new RadioComponent {RadioComponentId=4,RadioComponentName="Резистор выводной 39R ", Description = " 5W ±5% / RX27-1 (SQP)", Price=120,RadioComponentGroupId=1, Image="rez.jpg"},
                new RadioComponent {RadioComponentId=5,RadioComponentName="Шнур MicroUSB M USB-A M 1.8m ",Description = "/ штекер USB A на штекер micro USB B 1.8м", RadioComponentGroupId=3, Price=340, Image="usb.jpg"},
                new RadioComponent {RadioComponentId=6,RadioComponentName="Шнур CAB-C-3/1",Description = "3в1, micro USB, Lightning, Type C", RadioComponentGroupId=3, Price=66, Image="usb2.jpg"}
            };
        }
       
    }
}
