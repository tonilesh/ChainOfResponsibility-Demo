using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns.COR
{
    public enum ChainResult { Sucess, Failure,Pass };

    public interface IResponsible<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns>
        ///     true... means action performed. break chain
        ///     false... means pass to next member
        /// </returns>
        ChainResult Action(T action);
    }
}
