﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Entities;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Simple.Tests.Mvc.ModelBinder
{
    public class Employee
    {
        public ContactInfo Contact { get; set; }
    }

    public class ContactInfo
    {
        public Address HomeAddress { get; set; }
        public Location Location { get; set; }
    }

    public class Address : IEntity
    {
        public Address() { }
        public Address(int id) { Id = id; }
        public int Id { get; set; }
    }

    public class Location : IEntity
    {
        public Address Address { get; set; }
        public Location(Address address) { Address = address; }
    }

    public class Company<T>
        where T : IEnumerable<Address>
    {
        public T Places { get; set; }
    }

    public class Holding<C, T>
        where C : Company<T>
        where T : IEnumerable<Address>
    {
        public C MyCompany { get; set; }
    }

    public class CompanyArray : Company<Address[]>
    {
    }

    public class CompanyIList : Company<IList<Address>>
    {
    }

    public class CompanyISet : Company<ISet<Address>>
    {
        public CompanyISet() { Places = new HashSet<Address>(); }
    }

    public class CompanyIesiSet : Company<Iesi.Collections.Generic.ISet<Address>>
    {
        public CompanyIesiSet() { Places = new Iesi.Collections.Generic.HashedSet<Address>(); }
    }

    public class CompanyLinkedList : Company<LinkedList<Address>>
    {
    }


}
