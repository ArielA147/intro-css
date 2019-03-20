using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intro_css
{
    /*
     * the class holds chaining of functions from FunctionsContainer class.
     * in order to opperate the mission needed to call Calculate function in ComposedMission class
     */
    public class ComposedMission : IMission
    {

        private FunctionsContainer.FunctionDelagte _myFunc;
        private List<FunctionsContainer.FunctionDelagte> _functionList;
        public event EventHandler<double> OnCalculate;


        public ComposedMission(string missionName)
        {
            Name = missionName;
            _functionList = new List<FunctionsContainer.FunctionDelagte>();

        }

        /*
         * the fucntion adding a function to the mission list function 
         * @param FunctionsContainer.FunctionDelagte newFunction - delegate function
         * return the composed mission with the update list of functions
         */
        public ComposedMission Add(FunctionsContainer.FunctionDelagte newFunction)
        {
            _functionList.Add(newFunction);
            return this;
        }

        /*
         * the function returns  the name of the mission as given from the user
         */
        public String Name { get; set; }

        /* the function returns the type of the class*/
        public String Type { get => "Composed"; }

        /*the function caclute the composed missions functions with given value.
         @param : double value : double number
         return : the function return a double number the result of the assembling functions of the mission
             */
        public double Calculate(double value)
        {
            double finalValue = value;

            // calculate the update values of the current function with the known value .
            foreach (var currentFunc in _functionList)
            {
                finalValue = currentFunc(finalValue);
            }

            OnCalculate?.Invoke(this, finalValue);
            return finalValue;
        }

    }
}
