using FluentAssertions;
using name_sorter.dataservice;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Linq;

namespace name_sorter_test
{
    [TestFixture]
    public class FileReaderTests
    {
        private IFileProcessor _fileProcessor;
        private IDataReader _fileReader;

        [SetUp]
        public void Setup()
        {

            this._fileProcessor = Substitute.For<IFileProcessor>();
            this._fileProcessor.GetFileContents().Returns(mockNames());
            this._fileReader = new FileReader(this._fileProcessor);
        }

        [Test]
        public void GetData_ShouldReturn_MockData()
        {
            //arrange
            var expectedResults = mockNames().ToList();

            // act
            var results = this._fileReader.GetData();

            // assert
            results.Should().BeEquivalentTo(expectedResults);

            results[0].Should().BeEquivalentTo("Orson Milka Iddins");
        }

        [Test]
        public void FileLocationNull_ShouldThrow_ArgumentNullException()
        {
            // act
            string[] nullData = null;

            this._fileProcessor.GetFileContents().Returns(nullData);
            this._fileReader = new FileReader(this._fileProcessor);
            //assert
            Assert.Throws<ArgumentNullException>(() => this._fileReader.GetData());
        }

        private string[] mockNames()
        {
            string[] mockData = new string[4];
            mockData[0] = "Orson Milka Iddins";
            mockData[1] = "Erna Dorey Battelle";
            mockData[2] = "Flori Chaunce Franzel";
            mockData[3] = "Odetta Sue Kaspar";

            return mockData;
        }
    }
}
