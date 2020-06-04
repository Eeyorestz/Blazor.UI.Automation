using System.Collections.Generic;
using NUnit.Framework;

namespace Blazor.UI.Automation.Grid
{
    public partial class GridPage
    {
        public void AssertRowIsDeleted(string rowId)
        {
            Assert.IsFalse(GetGridIds().Contains(rowId),$"Row with id {rowId} should be deleted, but it is not.");
        }

        public void AssertRow(GridModel gridModel)
        {
            var row = GetRowIndexById(gridModel.Id);

            Assert.Multiple(() =>
            {
                if (gridModel.Id != null) { Assert.AreEqual(gridModel.Id, GridCell(row, GetIndexOfHeader("Id")).InnerText()); };
                if (gridModel.Date != default) { Assert.AreEqual(gridModel.Date.FormatDateTime(), GridCell(row, GetIndexOfHeader("Date")).InnerText()); };
                if (gridModel.TempC != null) { Assert.AreEqual(gridModel.TempC, GridCell(row, GetIndexOfHeader("Temp. C")).InnerText()); };
                if (gridModel.TempF != null) { Assert.AreEqual(gridModel.TempF, GridCell(row, GetIndexOfHeader("Temp. F")).InnerText()); };
                if (gridModel.Summary != null) { Assert.AreEqual(gridModel.Summary, GridCell(row, GetIndexOfHeader("Summary")).InnerText()); };
            });
        }

        public void AssertTotalItemsNumber(int totalItems) 
        {
            Assert.AreEqual(totalItems, GetTotalItemsNumber, $"Total numbers of items is different. It should be{totalItems}, but it is {GetTotalItemsNumber}");
        }

        public void AssertPagingSelected(int pageNumber) 
        {
            Assert.IsTrue(Wait.WaitUntillReady(Page(pageNumber))
                .GetAttribute("class").Contains("selected"), $"Page {pageNumber} should be selected, but it is not.");
        }

        public void AssertIdsChanged(List<string> expectedIds)
        {
            Assert.AreNotEqual(expectedIds, GetGridIds(),"The ids on the page should be changed, but they remained the same.");
        }

        public void AssertIdsMatch(List<string> expectedIds)
        {
            Assert.AreEqual(expectedIds, GetGridIds(), "The ids on the page should be match, but they did not.");
        }

        public void AssertGridGrouped(string header)
        {
            Assert.IsTrue(Wait.ElementDisplayed(GroupingParagraph), $"Elements should be grouped by {header}, but aren't.");
            Assert.IsTrue(Wait.WaitUntillReady(GroupingParagraph)
                .InnerText().Contains(header), $"Paragraph should contain {header}, but it is not.");
        }

        public void AssertHeadersRearranged(string firstHeader, string secondHeader, int secondHeaderIndex) 
        {
            Assert.AreEqual(secondHeaderIndex - 1, GetIndexOfHeader(secondHeader), 
                $"Header {secondHeader} should moved to {secondHeaderIndex -1} position, but it is not.");
            Assert.AreEqual(secondHeaderIndex, GetIndexOfHeader(firstHeader), 
                $"Header {firstHeader} should moved to {secondHeaderIndex} position, but it is not.");
        }
    }
}
