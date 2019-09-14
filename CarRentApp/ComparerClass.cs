using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvpProj
{
    public class ComparerClass : IComparer<Offer>
    {
        public int Compare(Offer x, Offer y)
        {
            return x.FromDate.Date.CompareTo(x.FromDate.Date);
        }
    }
}
