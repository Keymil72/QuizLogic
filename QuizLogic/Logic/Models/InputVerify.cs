using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic.Logic.Models
{
    internal class InputVerify
    {
        internal int VerifyCategory(string key)
        {
            bool parse = int.TryParse(key, out int selected);
            //28 is max category id - 8
            if (parse && selected >= 1 && selected <= 28)
                return selected + 8;
            //0 means random category
            else return 0;
        }

        internal int VerifyAmount(string key) 
        {
            bool pars = int.TryParse(key, out int selected);
            // to do replace by short if
            if (pars && selected >= 1)
                return selected;
            else return 0;

        }
    }
}
