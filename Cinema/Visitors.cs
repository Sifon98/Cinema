using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    internal class Visitors
    {
        private List<Age> Visitor { get; set; }

        public Visitors()
        {
            Visitor = new List<Age>();
        }

        internal void AddVisitor(int age)
        {
            Visitor.Add(new Age(age));
        }

        internal void ClearVisitors()
        {
            Visitor.Clear();
        }

        internal List<Age> GetVisitors()
        {
            return Visitor;
        }
    }
}
