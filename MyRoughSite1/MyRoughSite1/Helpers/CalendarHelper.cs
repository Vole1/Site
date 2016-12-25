using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRoughSite1.Helpers
{
    public static class CalendarHelper
    {
        public static MvcHtmlString CreateCalendar(DateTime monthToDisplay)
        {


            var days = new string[7] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };

            TagBuilder calendar = new TagBuilder("div");
            calendar.MergeAttribute("class", "calendar");                                                              //<div class="calendar">
            calendar.MergeAttribute("name", "calendar");                                                               //<div name="calendar">
            TagBuilder table = new TagBuilder("table");
            TagBuilder caption = new TagBuilder("caption");
            TagBuilder month = new TagBuilder("b");
            month.SetInnerText(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthToDisplay.Month));          // <span>Month</span>

            caption.InnerHtml += month.ToString() +" " + monthToDisplay.Year.ToString();                               // <caption><span>Month</span> Year</caption>
            table.InnerHtml += caption.ToString();
            TagBuilder tr = new TagBuilder("tr");
            for (var d = 0; d < 7; d++)
            {
                TagBuilder th = new TagBuilder("th");
                th.SetInnerText(days[d]);
                tr.InnerHtml += th.ToString();
            }
            table.InnerHtml += tr.ToString();

            

            var daysInMonth= DateTime.DaysInMonth(monthToDisplay.Year, monthToDisplay.Month);
            var dayCounter = 1;
            var firstMonthDay = (int) new DateTime(monthToDisplay.Year, monthToDisplay.Month, 1).DayOfWeek;
            for (var i = 0; i < 6; i++)
            {
                if (daysInMonth <= dayCounter)
                    continue;
                tr = new TagBuilder("tr");
                for (var j = 0; j < 7; j++)
                {
                    TagBuilder td = new TagBuilder("td");
                    if ((i == 0 && j >= firstMonthDay) || (i != 0 && dayCounter <= daysInMonth))
                    {
                        TagBuilder input = new TagBuilder("input");
                        input.MergeAttribute("type", "submit");
                        input.MergeAttribute("class", "dayButton");
                        input.MergeAttribute("value", dayCounter.ToString());
                        td.InnerHtml += (input.ToString());
                        dayCounter++;
                    }
                    
                    tr.InnerHtml += td.ToString();

                }
                table.InnerHtml += tr.ToString();
            }

            calendar.InnerHtml += table.ToString();
            return new MvcHtmlString(calendar.ToString());

        }
    }
}