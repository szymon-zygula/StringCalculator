using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public static class SCC
    {

        private static int Parse(string str)
        {
            try
            {
                int i = int.Parse(str);
                if(i < 0)
                {
                    throw new ArgumentException();
                }
                
                if(i > 1000)
                {
                    return 0;
                }

                return i;
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        public static int Calc(string str)
        {
            if(str == "")
            {
                return 0;
            }

            try
            {
                return Parse(str);
            }
            catch (Exception e) {}

            List<string> separators = new List<string> { "\n", "," };
            int offset = 0;
            if(str.Length >= 3 && str[0] == '/' && str[1] == '/')
            {
                if(str[2] == '[')
                {
                    string[] arrs = str.Split(']');
                    if(arrs.Length == 1 || arrs.Length == 0)
                    {
                        throw new ArgumentException();
                    }
                    string sepa = arrs[0].Substring(3);
                    separators.Add(sepa);
                    separators.Add("]");
                    offset += 2;
                }
                else
                {
                    separators.Add(str[2].ToString());
                    offset += 1;
                }
            }

            string[] sumParts = str.Split(separators.ToArray(), StringSplitOptions.None);

            try
            {
                int sum = 0;
                for(int i = offset; i < sumParts.Length; ++i)
                {
                    sum += Parse(sumParts[i]);
                }

                return sum;
            }
            catch(Exception e)
            {
                throw new ArgumentException();
            }

            throw new ArgumentException();
        }


    }
}
