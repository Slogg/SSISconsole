using Microsoft.SqlServer.Dts.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            Package package = null;
            //Load the SSIS Package which will be executed
            package = app.LoadPackage(@"D:\Downloads\samples\SSMSSamples\SSMSExportl.dtsx", null);

            // Run the package
            try
            {
            package.Execute();

            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine("Dfd");
            Console.ReadKey();
        }

        static void scanUrls_Event(object sender, ScanUrlsEvenArgs e)
        {
            switch (e.Message)
            {
                case "Add":
                    Console.WriteLine("Событие Add для scanUrls");
                    break;
                case "Remove":
                    Console.WriteLine("Событие Remove для scanUrls");
                    break;
            }
        }
    }

    class ScanUrls : List<string>
    {
        public event EventHandler<ScanUrlsEvenArgs> Event;

        new public void Add(string item)
        {
            base.Add(item);
            OnEvent("Add");
        }

        new public void Remove(string item)
        {
            base.Remove(item);
            OnEvent("Remove");

        }

        private void OnEvent(string message)
        {
            if (Event != null)
                Event(this, new ScanUrlsEvenArgs(message));
        }
    }

    class ScanUrlsEvenArgs : EventArgs
    {
        public ScanUrlsEvenArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }

    }
}
