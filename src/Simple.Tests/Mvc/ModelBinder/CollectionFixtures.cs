﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Simple.Tests.Mvc.ModelBinder
{
    [TestFixture]
    public class IesiSetCollectionFixture : BaseCollectionFixture<CompanyIesiSet, Iesi.Collections.Generic.ISet<Address>>
    {
        protected override bool AllowNulls
        {
            get { return false; }
        }
    }

    [TestFixture]
    public class ISetCollectionFixture : BaseCollectionFixture<CompanyISet, ISet<Address>>
    {
    }

    [TestFixture]
    public class CollectionFixtures : BaseCollectionFixture<CompanyArray, Address[]>
    {
    }

    [TestFixture]
    public class IListCollectionFixture : BaseCollectionFixture<CompanyIList, IList<Address>>
    {
    }

    [TestFixture]
    public class LinkedListCollectionFixture : BaseCollectionFixture<CompanyLinkedList, LinkedList<Address>>
    {
    }
}
