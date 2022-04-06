using System.Collections.Generic;


namespace RockPaperScissors
{
    public static class MyExtensions
    {
        public static bool ContainSameElements(this List<string> list)
        {
            List<string> temp = new List<string>(list.Count);

            foreach (string s in list)
                if (temp.Contains(s)) return true;
                else temp.Add(s);

            return false;
        }
    }
}
