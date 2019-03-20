using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace intro_css
{
    /*
     * the class contains one mission from the FunctionsContainer class.
     * in order to opperate the mission needed to call Calculate function in SingleMission class
     */
    public class SingleMission : IMission
    {

        private FunctionsContainer.FunctionDelagte _myFunc;
        public event EventHandler<double> OnCalculate;


        public SingleMission(FunctionsContainer.FunctionDelagte inputFunction, string missionName)
        {
            Name = missionName;
            _myFunc = inputFunction;
        }

        public String Name { get; set; }
        public String Type { get => "Single"; }

        /* the function caclute the single missions function with a given value.
            @param : double value : double number
            return : double number of the result of functions of the mission
     */
        public double Calculate(double value)
        {
            double finalValue = 0;
            finalValue = _myFunc(value);
            OnCalculate?.Invoke(this, finalValue);
            return finalValue;
        }
    }
}
