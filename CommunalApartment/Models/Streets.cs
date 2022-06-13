using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CommunalApartment.Models
{
    public class Streets
    {
        [DataMember]

        int id;
        string name = string.Empty;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}