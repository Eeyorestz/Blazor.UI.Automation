using System.Collections.Generic;
using NUnit.Framework;

namespace Blazor.UI.Automation.Grid
{
    public partial class GridPage
    {
        public void AssertRowDeleted(string rowId)
        {
            Assert.IsFalse(GetGridIds().Contains(rowId));
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
            Assert.AreEqual(totalItems, GetTotalItemsNumber);
        }

        public void AssertPagingSelected(int pageNumber) 
        {
            Assert.IsTrue(Wait.WaitUntillReady(Page(pageNumber)).GetAttribute("class").Contains("selected"));
        }

        public void AssertIdsChanged(List<string> expectedIds)
        {
            Assert.AreNotEqual(expectedIds, GetGridIds());
        }

        public void AssertIdsMatch(List<string> expectedIds)
        {
            Assert.AreEqual(expectedIds, GetGridIds());
        }

        public void AssertGridGrouped(string header)
        {
            Assert.IsTrue(Wait.ElementDisplayed(GroupingParagraph), $"Elements should be grouped by {header}, but aren't");
            Assert.IsTrue(Wait.WaitUntillReady(GroupingParagraph).InnerText().Contains(header));
        }

        public void AssertHeadersRearranged(string firstHeader, string secondHeader, int secondHeaderIndex) 
        {
            Assert.AreEqual(secondHeaderIndex - 1, GetIndexOfHeader(secondHeader));
            Assert.AreEqual(secondHeaderIndex, GetIndexOfHeader(firstHeader));
        }
    }
}
