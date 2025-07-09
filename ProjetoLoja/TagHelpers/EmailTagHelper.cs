using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProjetoLoja.TagHelpers;

public class EmailTagHelper
{
    public string MailAdress { get; set; }
    public string ContentEmail { get; set; }

    public void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("href", "mailto:" + MailAdress);
        output.Content.SetContent(ContentEmail);
    }
}