using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProjetoLoja.TagHelpers;

[HtmlTargetElement("email")]
public class EmailTagHelper : TagHelper
{
    public string MailAdress { get; set; }
    public string ContentEmail { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", "mailto:" + MailAdress);
        output.Content.SetContent(ContentEmail);
    }
}