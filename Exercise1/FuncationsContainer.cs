using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intro_css
{
    /*
     * this class contain INDEXER , by the name of function returns the reseving function .
     * f:R->R
     */
    public class FunctionsContainer
    {
        public delegate double FunctionDelagte(double number);// declaring a type of a pointer

        private Dictionary<string, FunctionDelagte> dictFucntions;

        public FunctionsContainer()
        {
            dictFucntions = new Dictionary<string, FunctionDelagte>();
        }

        /*
         * creating the operator of [] to the class
         */
        public FunctionDelagte this[string key]
        {
            get
            {
                // if not exsit, add to the dict first
                if (!dictFucntions.ContainsKey(key))
                {
                    dictFucntions.Add(key, x => x);
                }
                return dictFucntions[key];
            }
            set
            {
                // if key exist - will only update the value 
                if (dictFucntions.ContainsKey(key))
                {
                    dictFucntions[key] = value;
                }
                else
                {
                    dictFucntions.Add(key, value);
                }
            }
        }

        /*
         the function return all the missions functions in a list
             */
        public List<string> getAllMissions()
        {
            List<string> missionsNames = new List<string>();
            foreach (KeyValuePair<string, FunctionDelagte> kvp in dictFucntions)
            {
                missionsNames.Add(kvp.Key);
            }
            return missionsNames;
        }

    }
}
