using System;
using System.Collections.Generic;
using System.Linq;
using Blazor.UI.Automation.Attributes;
using OpenQA.Selenium;

namespace Blazor.UI.Automation.Grid
{
    public partial class GridPage : BasePage
    {
        public int GetTotalItemsNumber => int.Parse(Wait.WaitUntillReady(PageInfo).InnerText().Replace(" items", string.Empty).Split("of ")[1]);

        public int GetRowIndexById(string id) => GetRowById(id).FindElements(RowIndex).Count + 1;

        public void OpenPageByNumber(int pageNumber)
        {
            Wait.WaitUntillReady(Page(pageNumber)).Click();
        }

        public void EditRowById(string id)
        {
            var row = GetRowById(id);
            row.FindElement(EditButton).Click();
        }

        public void DeleteRowById(string id)
        {
            var row = GetRowById(id);
            row.FindElement(DeleteButton).Click();
            Wait.WaitUntillReady(RowIdColumn);
        }

        public List<string> GetGridIds()
        {
            var ids = new List<string>();
            var rows = Wait.WaitUntillListReady(RowIdColumn);

            foreach (var row in rows)
            {
                ids.Add(row.InnerText());
            }

            return ids;
        }

        public List<string> GetHeaderNames()
        {
            var ids = new List<string>();
            var headers = Wait.WaitUntillListReady(Headers);
            foreach (var row in headers)
            {
                ids.Add(row.InnerText());
            }

            return ids;
        }

        public void SortByHeader(string headerName, Directions direction)
        {
            if (!Wait.ElementDisplayed(SortIcon))
            {
                Header(headerName).Click();
            }

            var sortIcon = Wait.WaitUntillReady(SortIcon);
            if (!sortIcon.GetAttribute("class").Contains(direction.ToString().ToLower()))
            {
                sortIcon.Click();
            }
        }

        public void DragHeader(string headerName, string secondHeader= "") 
        {
            if (string.IsNullOrEmpty(secondHeader))
            {
                DragAndDrop(Wait.WaitUntillReady(Header(headerName)), Wait.WaitUntillReady(DragableContainer));
            }
            else 
            {
                DragAndDrop(Wait.WaitUntillReady(Header(headerName)), Wait.WaitUntillReady(Header(secondHeader)));
            } 
        }

        public string GetRandomId()
        {
            var listOfIds = GetGridIds();

            return listOfIds[new Random().Next(listOfIds.Count)];
        }

        public void FillGridRow(GridModel model)
        {
            FillDate(model);
            HeaderServices headerServices = new HeaderServices();
            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                var header = headerServices.GetHeaderNameByProperty(property);
                if (value != default && header != default)
                {
                    GridInputCell(model.RowIndex, GetIndexOfHeader(header))
                      .SetText(value.ToString());
                }
            }

            UpdateButton.Click();
            Wait.WaitUntillReady(RowIdColumn);
        }

        public void OpenFilter(string headerName)
        {
            FilterIcon(GetIndexOfHeader(headerName)).Click();
        }

        public void SelectFilter(string filterOption, int filterIndex = 1)
        {
            FilterDropdowns(filterIndex).Click();
            Wait.WaitUntillListReady(FilterOptions).Where(f => f.InnerText().Equals(filterOption))
                            .FirstOrDefault().Click();
        }

        public void FillFilter(string filterText, int filterIndex = 1)
        {
            Wait.WaitUntillReady(FilterInput(filterIndex)).SendKeys(filterText);
        }

        public int GetIndexOfHeader(string headerName) => GetHeaderNames().IndexOf(headerName) + 1;

        private void FillDate(GridModel model)
        {
            if (model.Date != default)
            {
                if (!Wait.ElementDisplayed(CalendarBody))
                {
                    GridCalendarButton.Click();
                    Wait.WaitToBeClickable(CalendarDates);
                }

                GetCalendarDate(DateToFill(model.Date)).Click();
            }
        }

        private string DateToFill(DateTime date) => date.Day.ToString();

        private IWebElement GetCalendarDate(string day) => Wait.WaitUntillListReady(CalendarDates).Where(e => e.InnerText().Equals(day)).FirstOrDefault();

        private IWebElement GetRowById(string id) => Wait.WaitUntillListReady(RowIdColumn).Where(e => e.InnerText().Equals(id)).FirstOrDefault();
    }
}
