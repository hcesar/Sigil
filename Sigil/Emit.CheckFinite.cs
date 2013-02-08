﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Sigil.Impl;

namespace Sigil
{
    public partial class Emit<DelegateType>
    {
        /// <summary>
        /// Throws an ArithmeticException on runtime if the value on the stack is not a finite number.
        /// 
        /// This leaves the value checked on the stack, rather than popping it as might be expected.
        /// </summary>
        public Emit<DelegateType> CheckFinite()
        {
            var onStack = Stack.Top();

            if (onStack == null)
            {
                throw new SigilVerificationException("CheckFinite expects a value to be on the stack, but it was empty", IL, Stack);
            }

            var val = onStack[0];

            if (val != TypeOnStack.Get<float>() && val != TypeOnStack.Get<double>())
            {
                throw new SigilVerificationException("CheckFinite expects a floating point value, found " + val, IL, Stack);
            }

            // ckfinite leaves the value on the stack, oddly enough
            UpdateState(OpCodes.Ckfinite);

            return this;
        }
    }
}
