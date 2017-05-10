using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilboardVideoLedControl
{
    class AlgorithmExecutor
    {
        public void executeAlgorihtms(CheckAlgorithm[] algo)
        {
            foreach(CheckAlgorithm alg in algo){
                alg.execute();
            }
        }
    }
}
