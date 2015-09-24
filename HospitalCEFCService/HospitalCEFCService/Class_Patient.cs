using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalCEFCService
{
    public class Class_Patient
    {
        int pNo, age, empID;
        string pname, sex, address, remarks;
        DateTime regDate, disDate;

        public int patientNo
        {
            get { return pNo; }
            set { pNo = value; }
        }

        public string patientName
        {
            get { return pname; }
            set { pname = value; }
        }

        public int Page
        {
            get { return age; }
            set { age = value; }
        }

        public string Psex
        {
            get { return sex; }
            set { sex = value; }
        }

        public string Paddress
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime PregDate
        {
            get { return regDate.Date; }
            set { regDate = value.Date; }
        }
        
        public DateTime PdisDate
        {
            get { return disDate.Date; }
            set { disDate = value.Date; }
        }

        public string Premarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public int PempID
        {
            get { return empID; }
            set { empID = value; }
        }


    }
}