#region Imports
using Core.Utilities.Results;
using System;

#endregion

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return logic;
            }
            return null;
        }
    }
}
