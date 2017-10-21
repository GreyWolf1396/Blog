using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreyApplication.Models;

namespace GreyApplication.Helpers
{
    public static class InputList
    {
        public static MvcHtmlString CreateRBList(this HtmlHelper html, IEnumerable<Variant> variants)
        {
            TagBuilder div = new TagBuilder("div");
            foreach (var variant in variants)
            {
                TagBuilder p = new TagBuilder("p");
                TagBuilder radioButton = new TagBuilder("input");
                radioButton.Attributes.Add("type","radio");
                radioButton.Attributes.Add("value", variant.Text);
                radioButton.Attributes.Add("name", variant.Question.Number.ToString());
                radioButton.SetInnerText(variant.Text);
                p.InnerHtml += radioButton;
                div.InnerHtml += p;
            }
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString CreateCheckBoxList(this HtmlHelper html, IEnumerable<Variant> variants)
        {
            TagBuilder div = new TagBuilder("div");
            foreach (var variant in variants)
            {
                TagBuilder p = new TagBuilder("p");
                TagBuilder checkBox = new TagBuilder("input");
                checkBox.Attributes.Add("type", "checkbox");
                checkBox.Attributes.Add("value", variant.Text);
                checkBox.Attributes.Add("name", variant.Question.Number.ToString());
                checkBox.SetInnerText(variant.Text);
                p.InnerHtml += checkBox;
                div.InnerHtml += p;
            }
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString CreateComboBoxList(this HtmlHelper html, IEnumerable<Variant> variants, int qNumber)
        {
            TagBuilder comboBox = new TagBuilder("select");
            comboBox.Attributes.Add("name", qNumber.ToString());
            foreach (var variant in variants)
            {
                TagBuilder option = new TagBuilder("option");
                option.Attributes.Add("value",variant.Text);
                option.SetInnerText(variant.Text);
                comboBox.InnerHtml += option;
            }
            return new MvcHtmlString(comboBox.ToString());
        }
    }


}