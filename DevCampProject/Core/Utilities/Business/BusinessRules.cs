using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                //şu logic hatalı diyip o nesneyi gönderiyoruz.
                if (!logic.IsSuccess)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
