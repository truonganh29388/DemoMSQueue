using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMSMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var idList = new string[]{"838614FF-A237-48D6-A07A-007E5BC39414",
                                      "AB783A24-38F9-49E0-B6DF-FFB535E0CE1A" };

            //foreach (var id in idList)
            //{
            //    SendTestMsg(id);
            //}
            SendTestMsg("ba74d76f-ddc7-4227-870f-0f77c8a11e10");

            //while (true)
            //{
            // Thread.Sleep(2000);
            //for (int i = 0; i < 1000; i++)
            //{
            //    ////  Task task = Task.Factory.StartNew(() => SendTestMsg());
            //    SendTestMsg();
            //}

            // Task task2 = Task.Factory.StartNew(() => SendTestMsg());
            // Task task3 = Task.Factory.StartNew(() => SendTestMsg());
            //   ThreadStart thread1 = new ThreadStart();
            //  SendTestMsg();
            // }
        }


        private static void SendTestMsg(string id = null)
        {
            id = id ?? "667A40D1-6E53-4A2A-B899-FBEBADE4CE45";
            //  var body = new DocumentCheckMessage { Guid = Guid.Parse("667A40D1-6E53-4A2A-B899-FBEBADE4CE45") };
            var body = new DocumentCheckMessage { Guid = Guid.Parse(id) };
            body.AgencyId = 1;
            body.CaseId = "1";
            body.DocumentName = "Test";

            var msg = new QueueMessage(body.Serialise(), null, "1", "test", "test", 2);

            SendMessage(@".\private$\vuportal", msg);
        }

        private static void SendMessage(string queueName, QueueMessage msg)
        {
            MessageQueue testQueue = null;

            if (!MessageQueue.Exists(queueName))
                testQueue = MessageQueue.Create(queueName);
            else
                testQueue = new MessageQueue(queueName);
            try
            {

                testQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(QueueMessage) });
                testQueue.Send(msg);
            }

            catch

            {
                //Write code here to do the necessary error handling.
            }

            finally

            {
                testQueue.Close();

            }

        }
    }



}
