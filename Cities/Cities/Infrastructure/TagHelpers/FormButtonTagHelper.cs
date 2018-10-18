using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

namespace Cities.Infrastructure.TagHelpers
{
	[HtmlTargetElement("formbutton")]
	public class FormButtonTagHelper : TagHelper
	{
		public string Type { get; set; }
		public string BgColor { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "button";
			output.TagMode = TagMode.StartTagAndEndTag;
			output.Attributes.SetAttribute("class", !String.IsNullOrEmpty(BgColor) ? $"btn btn-{BgColor}" : $"btn btn-primary");
			output.Attributes.SetAttribute("type", Type);
			output.Content.SetContent(Type == "submit" ? "Add" : "Clear");
		}
	}
}
