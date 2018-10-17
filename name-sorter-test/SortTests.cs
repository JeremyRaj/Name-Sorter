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
        private Sorter _sortEngine;

        [SetUp]
        public void Setup()
        {
            this._sortEngine = new Sorter();
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

        [Test]
        public void PassOneGivenNameCollection_ShouldSort_Asc()
        {
            char[] delimiters = new char[] { ' ' };
            List<string> singleNameCollection = new List<string>();
            singleNameCollection.Add("John Jeremy");
            singleNameCollection.Add("Adam David");
            var results = this._sortEngine.GetSortedData(singleNameCollection, delimiters);

            // assert
            results[0].Should().BeEquivalentTo("Adam David");
            results[1].Should().BeEquivalentTo("John Jeremy");
        }

        [Test]
        public void PassOneNameCollection_ShouldSort_Asc()
        {
            char[] delimiters = new char[] { ' ' };
            List<string> singleNameCollection = new List<string>();
            singleNameCollection.Add("Jeremy");
            singleNameCollection.Add("David");
            var results = this._sortEngine.GetSortedData(singleNameCollection, delimiters);

            // assert
            results[0].Should().BeEquivalentTo("David");
            results[1].Should().BeEquivalentTo("Jeremy");
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
