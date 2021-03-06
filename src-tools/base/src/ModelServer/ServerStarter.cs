using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.Project;
using Simple.Entities;
using Simple;
using NHibernate.Tool.hbm2ddl;
using System.Xml.Linq;
using System.Xml;
using System.Reflection;
using System.Threading;
using Example.Project.Services;

namespace Example.Project
{
    public class ServerStarter
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(x => new Configurator().StartServer<ServerStarter>());
            Simply.Do.WaitRequests();
        }
    }
}
