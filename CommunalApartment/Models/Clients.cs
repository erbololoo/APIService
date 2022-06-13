using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CommunalApartment.Models
{
    public class Clients
    {
        [DataMember]

        int id;
        int personal;
        string name = string.Empty;
        int phone_num;
        string street= string.Empty;
        int house;
        int apartment;
        int amountofroom;
        int square;
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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public int Phone
        {
            get { return phone_num; }
            set { phone_num = value; }
        }
        [DataMember]
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        [DataMember]
        public int House
        {
            get { return house; }
            set { house = value; }
        }
        [DataMember]
        public int Apartment
        {
            get { return apartment; }
            set { apartment = value; }
        }
        [DataMember]
        public int AmountOfRoom
        {
            get { return amountofroom; }
            set { amountofroom = value; }
        }
        [DataMember]
        public int Square
        {
            get { return square; }
            set { square = value; }
        }

        public static implicit operator Clients(SqlCommand v)
        {
            throw new NotImplementedException();
        }
    }
}