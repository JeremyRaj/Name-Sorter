using System;
using System.Collections.Generic;
using name_sorter.engine;
using NSubstitute;
using NUnit.Framework;
using FluentAssertions;

namespace name_sorter_test
{
    [TestFixture]
    public class SortTests
    {
        private Sort _sortEngine;

        [SetUp]
        public void Setup()
        {
            this._sortEngine = new Sort();
        }

        [Test]
        public void InputOutput_ShouldBe_SameLength()
        {
            // act
            char[] delimiters = new char[] { ' ' };
            var results = this._sortEngine.GetSortedData(mockData(), delimiters);

            // assert
            results.Length.Should().Equals(mockData().Count);
        }

        [Test]
        public void PassMockInput_ShouldReturn_SortedList()
        {
            // act
            char[] delimiters = new char[] { ' ' };
            var results = this._sortEngine.GetSortedData(mockData(), delimiters);

            // assert
            results[0].Should().BeEquivalentTo("Hailey Avie Annakin");
            results[4].Should().BeEquivalentTo("Orson Milka Iddins");
        }

        [Test]
        public void PassNullList_ShouldThrow_ArgumentNullException()
        {
            // act
            char[] delimiters = new char[] { ' ' };
          
            //assert
            Assert.Throws<ArgumentNullException>(() => this._sortEngine.GetSortedData(null, delimiters));
        }

        [Test]
        public void PassNullDelimiter_ShouldThrow_ArgumentNullException()
        {
            //assert
            Assert.Throws<ArgumentNullException>(() => this._sortEngine.GetSortedData(mockData(), null));
        }

        private List<string> mockData()
        {
            List<string> inputMockData = new List<string>();
            inputMockData.Add("Orson Milka Iddins");
            inputMockData.Add("Erna Dorey Battelle");
            inputMockData.Add("Flori Chaunce Franzel");
            inputMockData.Add("Odetta Sue Kaspar");
            inputMockData.Add("Roy Ketti Kopfen");
            inputMockData.Add("Madel Bordie Mapplebeck");
            inputMockData.Add("Selle Bellison");
            inputMockData.Add("Leonerd Adda Mitchell Monaghan");
            inputMockData.Add("Debra Micheli");
            inputMockData.Add("Hailey Avie Annakin");

            return inputMockData;
        }

    }
}
