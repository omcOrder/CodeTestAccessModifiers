using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleLib
{
    //This is for Question 4
    public class MaskName
    {
       
        private string _searchIn;
        public MaskName(string SearchIn)
        {
            _searchIn = SearchIn;
            
        }
      
        public string ReplaceNamesWithX(char c, List<string> ListNames)
        {
            //sorted by longer name first, so Bobby will be selected before Bob. 
            //Otherwise it will not replace "by" inside "Bobby" for example
            ListNames = ListNames.OrderByDescending(x => x.Length).ToList(); 
            StringBuilder sb = new StringBuilder(this._searchIn);
            foreach (string name in ListNames)
            {
                sb.Replace(name, new string(c, name.Length));
            }
            return sb.ToString();
        }

        public string ReplaceNamesWithX(char c, string[] stringArrayOfNames)
        {
            StringBuilder sb = new StringBuilder(this._searchIn);
            var sortedNames = from a in stringArrayOfNames
                    orderby a.Length descending
                    select a;
            foreach (string name in sortedNames)
            {
                sb.Replace(name, new string(c, name.Length));
            }
            return sb.ToString();
        }

        public string ReplaceNamesWithX(char c, string namesSeparatedByComma)
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder(this._searchIn);
            string[] arrNames = namesSeparatedByComma.Replace(" ", "").Split(','); //replace white spaces first
            if (arrNames.Length > 0)
            {
               result = ReplaceNamesWithX(c, arrNames);
            }

            return result;
        }
    }
}
