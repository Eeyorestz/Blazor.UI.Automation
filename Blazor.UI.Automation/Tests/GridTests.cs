using System;
using System.Collections.Generic;
using Blazor.UI.Automation.Grid;
using NUnit.Framework;

namespace Blazor.UI.Automation
{
    public class GridTests
    {
        private GridPage _gridPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Browser.SetupDriver();
            _gridPage = new GridPage();    
        }

        [SetUp]
        public void TestSetup()
        {
            Browser.Driver.Navigate().GoToUrl("http://local.blazor/grid");
        }

        [Test]
        public void RowAdded_When_ClickAddForecastButton_And_FillInfo_And_ClickUpdateButton()
        {
            int expectedId = _gridPage.GetTotalItemsNumber + 1;
            var expectedGridData = new GridModel()
            {
                Id = expectedId.ToString(),
                Date = DateTime.Now.AddDays(1),
                TempC = "15",
                Summary = "Random Text",
                RowIndex = 1,
            };

            _gridPage.AddForecast.Click();
            _gridPage.FillGridRow(expectedGridData);

            _gridPage.AssertRow(expectedGridData);
            _gridPage.AssertTotalItemsNumber(expectedId);
        }

        [Test]
        public void RowNotAdded_When_ClickAddForecastButton_And_ClickCancelButton()
        {
            int expectedTotalNumber = _gridPage.GetTotalItemsNumber;

            _gridPage.AddForecast.Click();
            _gridPage.Cancel.Click();

            _gridPage.AssertTotalItemsNumber(expectedTotalNumber);
        }

        [Test]
        public void RowDeleted_When_ClickDeleteButton()
        {
            var rowForDeletion = _gridPage.GetRandomId();

            _gridPage.DeleteRowById(rowForDeletion);

            _gridPage.AssertRowIsDeleted(rowForDeletion);
        }

        [Test]
        public void RowEdited_When_ClickEditButton()
        {
            var rowForEdit = _gridPage.GetRandomId();
            var expectedGridData = new GridModel()
            {
                Id = rowForEdit,
                Summary = DateTime.Now.ToString(),
                RowIndex = _gridPage.GetRowIndexById(rowForEdit),
            };

            _gridPage.EditRowById(rowForEdit);
            _gridPage.FillGridRow(expectedGridData);

            _gridPage.AssertRow(expectedGridData);
        }

        [Test]
        public void PageNavigatedToPage_When_ClickPagingButton()
        {
            int expectedPageNumber = 3;
            var expectedIds = _gridPage.GetGridIds();

            _gridPage.OpenPageByNumber(expectedPageNumber);

            _gridPage.AssertPagingSelected(expectedPageNumber);
            _gridPage.AssertIdsChanged(expectedIds);
        }

        [Test]
        public void ResultsFiltered_When_EnterValidFilter()
        {
            _gridPage.OpenFilter("Id");
            _gridPage.SelectFilter("Is less than");
            _gridPage.FillFilter("5");
            _gridPage.FilterButton.Click();

            _gridPage.AssertIdsMatch(new List<string>() { "1", "2", "3", "4" });
        }

        [Test]
        public void GridSorted_When_ClickOnHeader()
        {
            var expectedIds = _gridPage.GetGridIds();

            _gridPage.SortByHeader("Id", Directions.DESC);

            _gridPage.AssertIdsChanged(expectedIds);

            _gridPage.SortByHeader("Id", Directions.ASC);

            _gridPage.AssertIdsMatch(expectedIds);
        }

        [Test]
        public void GridGrouped_When_DragAndDropColumn()
        {
            var header = "Date";

            _gridPage.DragHeader(header);

            _gridPage.AssertGridGrouped(header);
        }

        [Test]
        public void HeadersRearranged_When_DragAndDropHeader()
        {
            var firstHeader = "Date";
            var secondHeader = "Summary";
            var secondHeaderIndex = _gridPage.GetIndexOfHeader(secondHeader);

            _gridPage.DragHeader(firstHeader, secondHeader);

            _gridPage.AssertHeadersRearranged(firstHeader, secondHeader, secondHeaderIndex);
        }

        [OneTimeTearDown]
        public void TestCleanUp()
        {
            Browser.Driver.Quit();
        }
    }
}