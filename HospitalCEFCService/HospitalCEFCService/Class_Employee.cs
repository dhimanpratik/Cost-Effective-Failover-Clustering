using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalCEFCService
{
    public class Class_Employee
    {
        int eID, cNO;
        string eName;

        public int empID
        {
            get { return eID; }
            set { eID = value; }
        }

        public string empName
        {
            get { return eName; }
            set { eName = value; }
        }

        public int counterNo
        {
            get { return cNO; }
            set { cNO = value; }
        }
    }
}