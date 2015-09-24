using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalCEFCService
{
    public class Class_Checking
    {
        int cdocID, cpatientNo;
        string cfee, cremerks;
        DateTime ccdate;

        public int docID
        {
            get { return cdocID; }
            set { cdocID = value; }
        }

        public int patientNo
        {
            get { return cpatientNo; }
            set { cpatientNo = value; }
        }

        public string fee
        {
            get { return cfee; }
            set { cfee = value; }
        }

        public string remarks
        {
            get { return cremerks; }
            set { cremerks = value; }
        }

        public DateTime checkdate
        {
            get { return ccdate; }
            set { ccdate = value; }
        }
    }
}