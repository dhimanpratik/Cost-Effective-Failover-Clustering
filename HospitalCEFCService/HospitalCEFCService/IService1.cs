using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HospitalCEFCService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string InsertNewPatients(Class_Patient pa);

        [OperationContract]
        string InsertNewEmployee(Class_Employee ce);

        [OperationContract]
        string InsertNewDoctor(Class_Doctor da);

        [OperationContract]
        string InsertNewTest(Class_Test ct);

        [OperationContract]
        string InsertNewChecking(Class_Checking cc);

        [OperationContract]
        string UpdateMySQL();

        [OperationContract]
        string UpdateSQL2008();

        [OperationContract]
        string Fire2008();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}