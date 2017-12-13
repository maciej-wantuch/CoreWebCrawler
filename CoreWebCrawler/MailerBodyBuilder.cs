using System.Text;

namespace CoreWebCrawler
{
    public class MailerBodyBuilder
    {
        public static string BuildBody()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table>");
            sb.Append("<tbody>");
            sb.Append("<tr>");

            sb.Append(AddTrinketBoxes());
            sb.Append(AddTrinketBoxes());

            sb.Append("</tr>");
            sb.Append("</tbody>");
            sb.Append("</table>");

            return sb.ToString();
        }

        static string AddTrinketBoxes()
        {
            StringBuilder tb = new StringBuilder();

            tb.Append("<td class=\"product_box\">");
            tb.Append("<div><a href = \"http://www.amiami.com/top/detail/detail?gcode=FIGURE-006054-R&page=top%2Fsearch%2Flist%3Fs_condition_flg%3D1%24s_sortkey%3Dpreowned%24pagemax%3D50%24getcnt%3D0%24pagecnt%3D1\"><img src=\"http://img.amiami.jp/images/product/thumbnail/142/FIGURE-006054.jpg\" alt=\"\" width=\"80\" height=\"80\" /></a></div>");
            tb.Append("<ul class=\"product_ul\">");
            tb.Append("<li class=\"product_name_list\"><a href = \"http://www.amiami.com/top/detail/detail?gcode=FIGURE-006054-R&page=top%2Fsearch%2Flist%3Fs_condition_flg%3D1%24s_sortkey%3Dpreowned%24pagemax%3D50%24getcnt%3D0%24pagecnt%3D1\">7th Dragon 2020 - Psychic(Pink Harley) 1/7 Complete Figure</a></li>");
            tb.Append("<li class=\"product_icon\"><div class=\"icon_preowned\"></div></li>");
            tb.Append("<li class=\"product_day\"><font style = \"color:#CC0000;\"></font ></li>");
            tb.Append("<li class=\"product_price\">");
            tb.Append("<span class=\"product_off\">49% OFF</span>");
            tb.Append("5,980 JPY");
            tb.Append("</il>");
            tb.Append("</td>");

            return tb.ToString();
        }
    }
}
