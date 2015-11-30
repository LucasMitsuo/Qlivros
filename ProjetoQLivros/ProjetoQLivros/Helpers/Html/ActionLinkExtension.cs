using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace ProjetoQLivros.Helpers.Html
{
    public static class ActionLinkExtension
    {
        public static MvcHtmlString IconActionLink(this AjaxHelper helper, string icon, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] ", actionName, controllerName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        public static MvcHtmlString IconActionLink(this AjaxHelper helper, string icon, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] " + linkText, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        public static MvcHtmlString IconActionLink(this HtmlHelper helper, string icon, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme]", actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        public static MvcHtmlString IconActionLink(this HtmlHelper helper, string icon, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", icon);
            var link = helper.ActionLink("[replaceme] " + linkText, actionName, controllerName, routeValues, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }

        public static MvcHtmlString RouteLink(this HtmlHelper htmlHelper, string icon, string linkText, string routeName, object htmlAttributes)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", icon);
            var link = htmlHelper.RouteLink("[replaceme] " + linkText, routeName, htmlAttributes).ToHtmlString();
            return new MvcHtmlString(link.Replace("[replaceme]", builder.ToString()));
        }
    }
}
