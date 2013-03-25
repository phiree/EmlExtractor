using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace CommonLibrary
{
   public class StringHelper
    {
       public static string RemoveHtml(string input)
       {
           string result = string.Empty;
           result = Regex.Replace(input, @"<[^>]*>", string.Empty);
           return result;
       }
    }
}
