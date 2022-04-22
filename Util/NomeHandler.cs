using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Util
{
    public static class NomeHandler
    {
      public static string GetFirstTwoInitials(this string name)
        {
            string[] nameSplit = name.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            string initials = "";
            int initialsLimit = 2;
            int initialsCounter = 0;
            foreach (string item in nameSplit)
            {
                if (initialsCounter >= initialsLimit)
                    break;
                initials += item.Substring(0, 1).ToUpper();
                initialsCounter++;
            }

            return initials;
        }
    }
}
