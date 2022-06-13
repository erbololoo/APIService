using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CommunalApartment.Models
{
    public class Paying
    {
        [DataMember]

        int id;
        int personal;
        string service = string.Empty;
        float allsum;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public int Person
        {
            get { return personal; }
            set { personal = value; }
        }
        [DataMember]
        public string Serv
        {
            get { return service; }
            set { service = value; }
        }
        [DataMember]
        public float AllSum
        {
            get { return allsum; }
            set { allsum = value; }
        }
    }
}