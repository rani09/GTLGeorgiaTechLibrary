using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTLGeorgiaTechLibrary
{
    static class Program
    {
        //public static IContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Container = configure();
            //Den skal ind i Form1
            //Container.Resolve<ITestRepository>()
            Application.Run(new Form1());
        }

        //Setting dependency injection
        //static IContainer configure()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<TestRepository>().As<ITestRepository>();
        //    //apple form1
        //    builder.RegisterType<Form1>();
        //    return builder.Build();
        //}
    }
}
