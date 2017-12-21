using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSchool.ReceiptPrints
{
    internal class StudentDetails
    {
        public string StudentAdminNo { get; set; }

        public string StudentName { get; set; }
        public StudentDetails(Student_Basic stud)
        {
            StudentAdminNo = $"REG NO: {stud.Admin_No}";
            StudentName = $"{stud.First_Name} {stud.Last_Name}";
        }
    }
}
