using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalCEFCService
{
    public class Class_Doctor
    {
        int doctorID;
        string doctorName, daddress, dcontact, dfaculty;

        public int docID
        {
            get { return doctorID; }
            set { doctorID = value; }
        }

        public string docName
        {
            get { return doctorName; }
            set { doctorName = value; }
        }

        public string address
        {
            get { return daddress; }
            set { daddress = value; }
        }

        public string contact
        {
            get { return dcontact; }
            set { dcontact = value; }
        }

        public string faculty
        {
            get { return dfaculty; }
            set { dfaculty = value; }
        }

    }
}