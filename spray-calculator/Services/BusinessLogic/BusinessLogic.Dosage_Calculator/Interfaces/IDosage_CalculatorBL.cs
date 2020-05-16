using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dosage_Calculator.Interfaces
{
    public interface IDosage_CalculatorBL
    {
        Task<(double agent, double water)> CalculateAgent(double requiredAgentVolume, double requiredHectare, double minimumSprayRate);
    }
}
