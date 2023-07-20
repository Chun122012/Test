using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalData
{
    public class Interval
    {
        private string _prefix;
        private int _start;
        private int _end;

        public Interval() { }
        public Interval(string prefix, int start, int end)
        {
            _prefix = prefix;
            _start = start;
            _end = end;
        }

        public string Prefix { get { return _prefix; } set { _prefix = value; } }
        public int Start { get { return _start; } set { _start = value; } }
        public int End { get { return _end; } set { _end = value; } }
    }
}
