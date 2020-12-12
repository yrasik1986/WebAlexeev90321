using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebAlexeev90321.Controllers;
using WebAlexeev90321.DAL.Entities;
using Xunit;


namespace WebAlexeev90321.Tests
{
    public class ProductControllerTests : Controller
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            var controller = new ProductController();
            controller._radioComponents = TestData.GetRadioComponentsList();
            // Act
            var result = controller.Index(pageNo: page, group: null) as ViewResult;
            var model = result?.Model as List<RadioComponent>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].RadioComponentId);
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            var controller = new ProductController();
            var data = TestData.GetRadioComponentsList();
            controller._radioComponents = data;
            var comparer = Comparer<RadioComponent>
            .GetComparer((d1, d2) => d1.RadioComponentId.Equals(d2.RadioComponentId));
            // act
            var result = controller.Index(2) as ViewResult;
            var model = result.Model as List<RadioComponent>;
            // assert
            Assert.Equal(2, model.Count);
            Assert.Equal(data[2], model[0], comparer);

        }
        
    }
    public class TestData
    {

        public static List<RadioComponent> GetRadioComponentsList()
        {
            return new List<RadioComponent>
            {
                new RadioComponent{ RadioComponentId=1, RadioComponentGroupId = 2},
                new RadioComponent{ RadioComponentId=2, RadioComponentGroupId = 2},
                new RadioComponent{ RadioComponentId=3, RadioComponentGroupId = 3},
                new RadioComponent{ RadioComponentId=4, RadioComponentGroupId = 1},
                new RadioComponent{ RadioComponentId=5, RadioComponentGroupId = 3},
                new RadioComponent{ RadioComponentId=6, RadioComponentGroupId = 3} //&&&&&&&&&
            };
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4&&&&&&&&&&
            yield return new object[] { 2, 3, 4 };
        }

    }


}
