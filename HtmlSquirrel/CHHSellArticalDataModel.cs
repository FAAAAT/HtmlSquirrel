using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NETCore.Encrypt;

namespace HtmlSquirrel
{
    public class CHHSellArticalDataModel
    {
        private Regex regex = new Regex("(?<=thread-|tid=)\\d+");
        private int? id = null;
        public int ID
        {
            get
            {
                if (id!=null)
                {
                    return id.Value;
                }
                if (string.IsNullOrEmpty(Url))
                {
                    id = 0;
                    
                }
                else
                {
                    var match = regex.Match(Url.Split('/').Last());
                    return Convert.ToInt32(match.Value);
                }
                return id.Value;
            }
        }
        public string Title { get; set; }
        public string Url { get; set; }


    }
}
