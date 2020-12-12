using System;
using System.Collections.Generic;
using System.Text;
using WebAlexeev90321.DAL.Entities;
using WebAlexeev90321.Models;
using Xunit;


namespace WebAlexeev90321.Tests
{
   public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<RadioComponent>
           .GetModel(TestData.GetRadioComponentsList(), 1, 3);
            // Assert
            Assert.Equal(2, model.TotalPages);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
       MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty,
       int id)
        {
            // Act
            var model = ListViewModel<RadioComponent>
           .GetModel(TestData.GetRadioComponentsList(), page, 3);
            // Assert
            Assert.Equal(qty, model.Count);
        }
        [Theory]
        [MemberData(memberName: nameof(TestData.Params),
       MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int
       id)
        {
            // Act
            var model = ListViewModel<RadioComponent>
           .GetModel(TestData.GetRadioComponentsList(), page, 3);
            // Assert
            Assert.Equal(id, model[0].RadioComponentId);
        }
    }
}
