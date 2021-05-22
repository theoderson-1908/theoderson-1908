using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentFourFIrstQuestion.Service
{
   public interface IProfileRepo<T>
    {
        bool Register(T t);
    }
}
