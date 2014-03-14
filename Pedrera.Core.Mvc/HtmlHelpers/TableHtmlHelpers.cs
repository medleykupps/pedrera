using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Pedrera.Core.Mvc.HtmlHelpers
{
    public static class TableHtmlHelpers
    {
        public static MvcHtmlString Table(this HtmlHelper helper,
            Func<IEnumerable<string>> headers )
        {
            var sb = new StringBuilder();
            


            return MvcHtmlString.Create("<table class='table table-stripped'><thead><th><td>Title</td></th></thead></table");
        }
    }
}
