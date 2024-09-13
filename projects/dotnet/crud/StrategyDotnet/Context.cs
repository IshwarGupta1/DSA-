using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyDotnet
{
    public class Context
    {
        private IStrategy _strategy;
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }
        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }
}
