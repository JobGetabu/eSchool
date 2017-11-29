using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.MyPrints
{
    public partial class AnnualFeeStructure
    {
        public string overHeadName { get; set; }
        public decimal costTerm1 { get; set; }
        public decimal costTerm2 { get; set; }
        public decimal costTerm3 { get; set; }
        public decimal costAllTerms
        {
            get
            {
                return costTerm1 + costTerm2 + costTerm3;
            }
        }

        public AnnualFeeStructure()
        {

        }
        public AnnualFeeStructure(string overHeadName, decimal costTerm1, decimal costTerm2, decimal costTerm3)
        {
            this.overHeadName = overHeadName;
            this.costTerm1 = costTerm1;
            this.costTerm2 = costTerm2;
            this.costTerm3 = costTerm3;
        }
    }
}
