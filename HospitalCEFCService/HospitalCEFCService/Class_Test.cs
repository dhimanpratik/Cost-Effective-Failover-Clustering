using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalCEFCService
{
    public class Class_Test
    {
        int pNo;
        string ttesthead, tamount, tremarks;
        DateTime ttestdate;

        public int patientNo
        {
            get { return pNo; }
            set { pNo = value; }
        }

        public string testhead
        {
            get { return ttesthead; }
            set { ttesthead = value; }
        }

        public string amount
        {
            get { return tamount; }
            set { tamount = value; }
        }

        public string remarks
        {
            get { return tremarks; }
            set { tremarks = value; }
        }

        public DateTime testdate
        {
            get { return ttestdate; }
            set { ttestdate = value; }
        }

    }
}