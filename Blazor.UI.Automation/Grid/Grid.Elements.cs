using OpenQA.Selenium;

namespace Blazor.UI.Automation.Grid
{
    public partial class GridPage
    {          
        public By FilterButton => By.XPath("//*[@class='k-button k-primary']");
        public By UpdateButton => By.XPath("//*[@class='k-icon k-i-save']/ancestor::button[@class='k-button telerik-blazor k-button-icontext']");
        public By GridCalendarButton => By.XPath($"//*[@class='k-icon k-i-calendar']");
        public By Cancel => By.XPath("//*[@class='k-icon k-i-cancel']/ancestor::button[@class='k-button telerik-blazor k-button-icontext']");
        public By AddForecast => By.XPath($"//span[@class='k-icon k-i-plus']/ancestor::button");
        public By EditButton => By.XPath(".//following-sibling::td//span[@class='k-icon k-i-edit']");
        public By DeleteButton => By.XPath(".//following-sibling::td//span[@class='k-icon k-i-delete']");  
        public By GridCell(int row, int column) => By.XPath($"//tbody/tr[{row}]/td[{column}]");
        public By GridInputCell(int row, int column) => By.XPath($"//tbody/tr[{row}]/td[{column}]//input");
        public By Header(string headerName) => By.XPath($"//*[@data-text='{headerName}']");
        public By GroupingParagraph => By.XPath("//tbody//*[@class='k-reset']");
        private By Headers => By.TagName($"th");
        private By DragableContainer => By.XPath($"//div[@class='k-indicator-container']");     
        private By RowIndex => By.XPath(".//ancestor::tr/preceding-sibling::tr");
        private By CalendarBody => By.ClassName("k-calendar-header");
        private By PageInfo => By.XPath("//*[@class='k-pager-info k-label']");
        private By CalendarDates => By.XPath("//*[@class='k-widget k-calendar telerik-blazor']//td");
        private By RowIdColumn => By.XPath("//tbody/tr/td[1]");
        private By FilterOptions => By.XPath($"//*[@class='k-list-scroller']/ul/li");
        private By SortIcon => By.XPath("//*[contains(@class,'k-icon k-i-sort')]");
        private By FilterDropdowns(int filterIndex) => By.XPath($"(//*[@aria-haspopup='listbox'])[{filterIndex}]");
        private By FilterIcon(int columnIndex) => By.XPath($"(//*[@aria-label='Filter'])[{columnIndex}]");
        private By FilterInput(int filterIndex) => By.XPath($"(//*[@class='  k-numeric-wrap']/input)[{filterIndex}]");
        private By Page(int page) => By.XPath($"//*[@aria-label='{page}']");
    }
}
