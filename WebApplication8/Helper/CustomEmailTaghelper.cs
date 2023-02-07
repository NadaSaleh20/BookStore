using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Helper
{
    public class CustomEmailTaghelper : TagHelper
    {

        //the output of this method will genreated html tag (output)
        public override  void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";     //the output will be emty (a) tag  <a></a>

            //this will added attrubite to a tag <a herf="nadasaleh987@gmail.com"></a>

            output.Attributes.SetAttribute("herf", "mailto:nadasaleh987@gmail.com");


            //to add content to a tag we will use  <a herf="nadasaleh987@gmail.com">my email</a>
            output.Content.SetContent("myemail");

        }


    }
}
