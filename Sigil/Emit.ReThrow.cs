﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sigil
{
    public partial class Emit<DelegateType>
    {
        /// <summary>
        /// From within a catch block, rethrows the exception that caused the catch block to be entered.
        /// </summary>
        public void ReThrow()
        {
            if(!CatchBlocks.Any(c => c.Value.Item2 == -1))
            {
                throw new InvalidOperationException("ReThrow is only legal in a catch block");
            }

            UpdateState(OpCodes.Rethrow);
        }
    }
}
