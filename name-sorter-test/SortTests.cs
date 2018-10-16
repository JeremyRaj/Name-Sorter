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
        private List<string> inputMockData = new List<string>();
        private List<string> expectedOutputData = new List<string>();
        private Sort _sortEngine;

        [SetUp]
        public void Setup()
        {
            this.inputMockData.Add("Orson Milka Iddins");
            this.inputMockData.Add("Erna Dorey Battelle");
            this.inputMockData.Add("Flori Chaunce Franzel");
            this.inputMockData.Add("Odetta Sue Kaspar");
            this.inputMockData.Add("Roy Ketti Kopfen");
            this.inputMockData.Add("Madel Bordie Mapplebeck");
            this.inputMockData.Add("Selle Bellison");
            this.inputMockData.Add("Leonerd Adda Mitchell Monaghan");
            this.inputMockData.Add("Debra Micheli");
            this.inputMockData.Add("Hailey Avie Annakin");

            this.expectedOutputData.Add("Hailey Avie Annakin");
            this.expectedOutputData.Add("Erna Dorey Battelle");
            this.expectedOutputData.Add("Selle Bellison");
            this.expectedOutputData.Add("Flori Chaunce Franzel");
            this.expectedOutputData.Add("Orson Milka Iddins");
            this.expectedOutputData.Add("Odetta Sue Kaspar");
            this.expectedOutputData.Add("Roy Ketti Kopfen");
            this.expectedOutputData.Add("Madel Bordie Mapplebeck");
            this.expectedOutputData.Add("Debra Micheli");
            this.expectedOutputData.Add("Leonerd Adda Mitchell Monaghan");

            this._sortEngine = new Sort();
            //this.searchIndexProver.HasAccessToCloudSearch("license1", "deployment1").Returns(true);
            //this.searchClient = Substitute.For<ISearchClient>();

            //this.searchController = new SearchController(this.searchIndexProver, this.searchClient);
            //this.searchController.Request = new HttpRequestMessage(HttpMethod.Get, "http://google.com");
        }

        [Test]
        public void PassMockInput_ShouldReturn_SortedList()
        {
            // act
            char[] delimiters = new char[] { ' ' };
            var results = this._sortEngine.GetSortedData(this.inputMockData, delimiters);

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
            Assert.Throws<ArgumentNullException>(() => this._sortEngine.GetSortedData(this.inputMockData, null));
        }

    }
}
