using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql;
using System.Reflection;

namespace HospitalCEFCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        MySql.Data.MySqlClient.MySqlConnection Msqlconn =
    new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1;uid=root;pwd=root;database=hospital;");
        SqlConnection conn2 = new SqlConnection("Server=192.168.1.3\\SQLEXPRESS;Database=hospital;User ID=root;Password=root");
        static bool msoff = false, mysql = true, s08off = false, sql2008 = true;
        string qtype;

        void checkDB()
        {

            if (isMySqlOnline())
            {
                if (msoff == true)
                {
                    UpdateMySQL();
                    msoff = false;
                }
                mysql = true;
            }
            else
            {
                msoff = true;
                mysql = false;
            }

            if (isSql2008Online())
            {
                if (s08off == true)
                {
                     UpdateSQL2008();
                    s08off = false;
                }
                sql2008 = true;
            }
            else
            {
                s08off = true;
                sql2008 = false;
            }
        }

        public Class_Patient Find(int id)
        {
            Class_Patient p = new Class_Patient();
            if (isMySqlOnline())
            {
                using (var db = new MySQLBase.MySQL_Model())
                {
                    try
                    {

                        var query = from p1 in db.patients
                                    where p1.patientNo.Equals(id)
                                    select p1;

                        foreach (var item in query)
                        {
                            p.patientNo = item.patientNo;
                            p.patientName = item.PatientName;
                            p.Paddress = item.address;
                            p.Psex = item.sex;
                            p.PregDate = item.regDate;
                            p.PdisDate = item.disDate;
                            p.PempID = item.empID;
                            p.Page = Convert.ToInt32(item.age);
                        }

                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("NO DATA FOUND");
                    }
                }
            }
              else if (isSql2008Online())
                    {
                        using (var db = new SQL2008.hospitalEntities())
                        {
                            try
                            {
                                var query = from p1 in db.DBpatients
                                            where p1.patientNo.Equals(id)
                                            select p1;
                                foreach (var item in query)
                                {
                                    p.patientNo = item.patientNo;
                                    p.patientName = item.PatientName;
                                    p.Paddress = item.address;
                                    p.Psex = item.sex;
                                    p.PregDate = item.regDate;
                                    p.PdisDate = item.disDate;
                                    p.PempID = item.empID;
                                    p.Page = Convert.ToInt32(item.age);
                                }
                            }
                            catch (Exception)
                            {
                                //MessageBox.Show("NO DATA FOUND");
                            }
                        }
                    }
            else
            {
                    
            }

            return p;
        }

        private bool isMySqlOnline()
        {
            try
            {
                Msqlconn.Open();
                Msqlconn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

                return false;
            }
            return true;
        }

        private bool isSql2008Online()
        {
            try
            {
                conn2.Open();
                conn2.Close();
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public string UpdateMySQL()
        {
            try
            {

                using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                {
                    string sFilePath = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    System.IO.StreamReader or = new System.IO.StreamReader(sFilePath);
                    do
                    {
                        qtype = or.ReadLine();
                        if (qtype == "Insert")
                        {
                            var p1 = new MySQLBase.patient
                            {
                                patientNo = Convert.ToInt32(or.ReadLine()),
                                PatientName = or.ReadLine(),
                                age = Convert.ToInt32(or.ReadLine()),
                                sex = or.ReadLine(),
                                address = or.ReadLine(),
                                regDate = Convert.ToDateTime(or.ReadLine()).Date,
                                disDate = Convert.ToDateTime(or.ReadLine()).Date,
                                remarks = or.ReadLine(),
                                empID = Convert.ToInt32(or.ReadLine())
                            };
                            db.patients.Add(p1);
                            db.SaveChanges();
                        }
                        else if (qtype == "Update")
                        {
                            var original = db.patients.Find(Convert.ToInt32(or.ReadLine()));
                            if (original != null)
                            {
                                original.patientNo = Convert.ToInt32(or.ReadLine());
                                original.PatientName = or.ReadLine();
                                original.age = Convert.ToInt32(or.ReadLine());
                                original.address = or.ReadLine();
                                original.sex = or.ReadLine();
                                original.regDate = Convert.ToDateTime(or.ReadLine()).Date;
                                original.disDate = Convert.ToDateTime(or.ReadLine()).Date;
                                original.remarks = or.ReadLine();
                            }
                            db.SaveChanges();
                        }
                    } while (qtype != null);
                    or.Close();
                }
                return "done";

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                return "notdone    " + ex.Message;
            }
        }

        public string UpdateSQL2008()
        {
            try
            {
                using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                {
                    string sFilePath = @"C:\Users\Pratik\Desktop\SQL2008.txt";
                    System.IO.StreamReader or = new System.IO.StreamReader(sFilePath);
                    do
                    {
                        qtype = or.ReadLine();
                        if (qtype == "Insert")
                        {
                            var p1 = new SQL2008.DBpatient
                            {
                                patientNo = Convert.ToInt32(or.ReadLine()),
                                PatientName = or.ReadLine(),
                                age = Convert.ToInt32(or.ReadLine()),
                                sex = or.ReadLine(),
                                address = or.ReadLine(),
                                regDate = Convert.ToDateTime(or.ReadLine()).Date,
                                disDate = Convert.ToDateTime(or.ReadLine()).Date,
                                remarks = or.ReadLine(),
                                empID = Convert.ToInt32(or.ReadLine())
                            };
                            db.DBpatients.Add(p1);
                            db.SaveChanges();
                        }
                        else if (qtype == "Update")
                        {
                            var original = db.DBpatients.Find(Convert.ToInt32(or.ReadLine()));
                            if (original != null)
                            {
                                original.patientNo = Convert.ToInt32(or.ReadLine());
                                original.PatientName = or.ReadLine();
                                original.age = Convert.ToInt32(or.ReadLine());
                                original.address = or.ReadLine();
                                original.sex = or.ReadLine();
                                original.regDate = Convert.ToDateTime(or.ReadLine()).Date;
                                original.disDate = Convert.ToDateTime(or.ReadLine()).Date;
                                original.remarks = or.ReadLine();
                            }
                            db.SaveChanges();
                        }
                    } while (qtype != null);
                    or.Close();
                }
                return "done";

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                return "notdone    " + ex.Message;
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string InsertNewPatients(Class_Patient pa)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                    {
                        var p = new MySQLBase.patient
                        {
                            patientNo = pa.patientNo,
                            PatientName = pa.patientName,
                            age = pa.Page,
                            sex = pa.Psex,
                            address = pa.Paddress,
                            regDate = pa.PregDate.Date,
                            disDate = pa.PdisDate.Date,
                            remarks = pa.Premarks,
                            empID = pa.PempID,
                        };
                        db.patients.Add(p);
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(pa);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                    {
                        var p = new SQL2008.DBpatient
                        {
                            patientNo = pa.patientNo,
                            PatientName = pa.patientName,
                            age = pa.Page,
                            sex = pa.Psex,
                            address = pa.Paddress,
                            regDate = pa.PregDate,
                            disDate = pa.PdisDate,
                            remarks = pa.Premarks,
                            empID = pa.PempID,
                        };
                        db.DBpatients.Add(p);
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\SQL2008.txt";
                    string sDateTime = GetLogFor(pa);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                return "not done" + ex.Message;
            }

            return "hell";
        }

        public string UpdatePatient(Class_Patient pa)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (var db = new MySQLBase.MySQL_Model())
                    {
                        var original = db.patients.Find(pa.patientNo);
                        if (original != null)
                        {
                            original.PatientName = pa.patientName;
                            original.remarks = pa.Premarks;
                            original.regDate = pa.PregDate;
                            original.age = pa.Page;
                            original.disDate = pa.PdisDate;
                            original.empID = pa.PempID;
                            original.sex = pa.Psex;
                            original.address = pa.Paddress;
                        }

                        db.SaveChanges();
                    }
                }

                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(pa);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {

                    using (var db = new SQL2008.hospitalEntities())
                    {
                        var original = db.DBpatients.Find(pa.patientNo);
                        if (original != null)
                        {
                            original.PatientName = pa.patientName;
                            original.remarks = pa.Premarks;
                            original.regDate = pa.PregDate;
                            original.age = pa.Page;
                            original.disDate = pa.PdisDate;
                            original.empID = pa.PempID;
                            original.sex = pa.Psex;
                            original.address = pa.Paddress;
                        }
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\SQL2008.txt";
                    string sDateTime = GetLogFor(pa);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
            catch (Exception e)
            {
                return "not done" + e.Message;
            }
            return "hell";
        }

        public string InsertNewEmployee(Class_Employee ce)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                    {
                        var e = new MySQLBase.employee
                        {
                            empID = ce.empID,
                            empName = ce.empName,
                            counterNo = ce.counterNo
                        };
                        db.employees.Add(e);
                        db.SaveChanges();
                    }
                }           
                 else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(ce);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                    {
                        var e = new SQL2008.DBemployee
                        {
                            empID = ce.empID,
                            empName = ce.empName,
                            counterNo = ce.counterNo
                        };
                        db.DBemployees.Add(e);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }

            catch (Exception ex)
            {
                return "not done" + ex.Message;
            }
            return "hell";
        }


        public string UpdateEmployee(Class_Employee ce)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (var db = new MySQLBase.MySQL_Model())
                    {
                        var original = db.employees.Find(ce.empID);
                        if (original != null)
                        {
                            original.counterNo = ce.counterNo;
                            original.empID = ce.empID;
                            original.empName = ce.empName;
                        }
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(ce);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (var db = new SQL2008.hospitalEntities())
                    {
                        var original = db.DBemployees.Find(ce.empID);
                        if (original != null)
                        {
                            original.counterNo = ce.counterNo;
                            original.empID = ce.empID;
                            original.empName = ce.empName;
                        }
                        db.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
            catch (Exception e)
            {
                return "not done" + e.Message;
            }
            return "hell";
        }


        public string InsertNewDoctor(Class_Doctor da)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                    {
                        var d = new MySQLBase.doctor
                        {
                            docID = da.docID,
                            docName = da.docName,
                            address = da.address,
                            contact = da.contact,
                            faculty = da.faculty
                        };
                        db.doctors.Add(d);
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(da);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                    {
                        var d = new SQL2008.DBdoctor
                        {
                            docID = da.docID,
                            docName = da.docName,
                            address = da.address,
                            contact = da.contact,
                            faculty = da.faculty
                        };
                        db.DBdoctors.Add(d);
                        db.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                return "not done" + ex.Message;
            }
            return "hell";
        }


        public string UpdateDoctor(Class_Doctor cd)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (var db = new MySQLBase.MySQL_Model())
                    {
                        var original = db.doctors.Find(cd.docID);
                        if (original != null)
                        {
                            original.docID = cd.docID;
                            original.docName = cd.docName;
                            original.address = cd.address;
                            original.contact = cd.contact;
                        }
                        db.SaveChanges();
                    }
                }
                else 
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(cd);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                 }
                if (sql2008 == true)
                {
                    using (var db = new SQL2008.hospitalEntities())
                    {
                        var original = db.DBdoctors.Find(cd.docID);
                        {
                            if (original != null)
                            {
                                original.docID = cd.docID;
                                original.docName = cd.docName;
                                original.address = cd.address;
                                original.contact = cd.contact;
                            }
                            db.SaveChanges();
                        }

                    }
                }
                }

             catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }


            catch (Exception e)
            {
                return "not done" + e.Message;
            }
            return "hell";
        }


        public string InsertNewTest(Class_Test ct)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                    {
                        var t = new MySQLBase.test
                        {
                            patientNo = ct.patientNo,
                            testdate = ct.testdate,
                            testhead = ct.testhead,
                            amount = ct.amount,
                            remarks = ct.remarks
                        };
                        db.tests.Add(t);
                        db.SaveChanges();
                    }
                }
                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(ct);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                    {
                        var t = new SQL2008.DBtest
                        {
                            patientNo = ct.patientNo,
                            testdate = ct.testdate,
                            testhead = ct.testhead,
                            amount = ct.amount,
                            remarks = ct.remarks
                        };
                        db.DBtests.Add(t);
                        db.SaveChanges();
                    }
                    return "done";
                }
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                return "not done" + ex.Message;
            }
            return "hell";
        }

        public string InsertNewChecking(Class_Checking cc)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (MySQLBase.MySQL_Model db = new MySQLBase.MySQL_Model())
                    {
                        var c = new MySQLBase.checking
                        {
                            docID = cc.docID,
                            patientNo = cc.patientNo,
                            checkDate = cc.checkdate,
                            fee = cc.fee,
                            remarks = cc.remarks
                        };
                        db.checkings.Add(c);
                        db.SaveChanges();
                    }
                }

                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(cc);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();
                }

                if (sql2008 == true)
                {
                    using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                    {
                        var c = new SQL2008.DBchecking
                        {
                            docID = cc.docID,
                            patientNo = cc.patientNo,
                            checkDate = cc.checkdate,
                            fee = cc.fee,
                            remarks = cc.remarks
                        };
                        db.DBcheckings.Add(c);
                        db.SaveChanges();
                    }
                }
            }

            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }


            catch (Exception ex)
            {
                return "not done" + ex.Message;
            }
            return "hell";
        }

        public static string GetLogFor(object target)
        {
            var properties =
                from property in target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                select new
                {
                    Name = property.Name,
                    Value = property.GetValue(target, null)
                };

            var builder = new StringBuilder();

            foreach (var property in properties)
            {
                builder
                    //  .Append(property.Name)
                    //  .Append(" = ")
                    .Append(property.Value)
                    .AppendLine();
            }
            return (builder.ToString()).Substring(0, (builder.ToString().Length) - 2);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Fire2008()
        {
            try
            {
                using (SQL2008.hospitalEntities db = new SQL2008.hospitalEntities())
                {
                    for (int i = 33; i < 100; i++)
                    {
                        var p = new SQL2008.DBpatient
                        {
                            patientNo = i,
                            PatientName = "praney",
                            age = 12,
                            sex = "Male",
                            address = "Nashik",
                            regDate = Convert.ToDateTime("11/2/2013"),
                            disDate = Convert.ToDateTime("11/2/2013"),
                            remarks = "asdasdfd",
                            empID = 1,
                        };
                        db.DBpatients.Add(p);
                        db.SaveChanges();
                    }
                }
                return "done";
            }
          catch(Exception exp)
         {
             return "nd " + exp.Message;
          }

    }


        public string UpdateDoctor(Class_Doctor doc)
        {
            checkDB();
            try
            {
                if (mysql == true)
                {
                    using (var db = new MySQLBase.MySQL_Model())
                    {
                        var original = db.doctors.Find(doc.docID);
                        if (original != null)
                        {
                            original.docID = doc.docID;
                            original.address = doc.address;
                            original.docName = doc.docName;
                            original.contact = doc.contact;
                            original.faculty = doc.faculty;

                        }
                        db.SaveChanges();
                    }
                }

                else
                {
                    string sFilePath1 = @"C:\Users\Pratik\Desktop\MySQL.txt";
                    string sDateTime = GetLogFor(doc);
                    sDateTime.Remove((sDateTime.Length - 2), 1);
                    System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(sFilePath1, true);
                    oFileWriter.WriteLine("Insert");
                    oFileWriter.WriteLine(sDateTime);
                    oFileWriter.Close();

                }

                if (sql2008 == true)
                {
                    using (var db = new SQL2008.hospitalEntities())
                    {
                        var original = db.DBdoctors.Find(doc.docID);
                        if (original != null)
                        {
                            original.docID = doc.docID;
                            original.address = doc.address;
                            original.docName = doc.docName;
                            original.contact = doc.contact;
                            original.faculty = doc.faculty;

                        }
                        db.SaveChanges();
                    }

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        return "Property: " + validationError.PropertyName + "Error: " + validationError.ErrorMessage;
                    }
                }
            }
                
            catch (Exception e)
            {
                return "not done" + e.Message;
            }
            return "hell";
        }


    }
}