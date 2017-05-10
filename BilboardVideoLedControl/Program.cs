using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilboardVideoLedControl
{
    class LedControl
    {
        public void InitLedman(string[] args)
        {
            /*
            ** Sender initialization
            */
            try
            {
                Console.WriteLine("Start!");
                Console.WriteLine("Processing...");
                if (NativeMethods.ReConnectSender())
                {
                    Console.WriteLine("Is connected");
                }
                else
                {
                    Console.WriteLine("Reconnect is false;");
                }
            }
            catch (Exception e9)
            {
                Console.WriteLine(e9.Message);
            }
            Console.ReadKey();
            /*
             ** Reciver initialization
             */

            /*
             ** Modules initialization
             */

        }
        
        public ushort getSenders()
        {
            return NativeMethods.GetConnectSenderCount();
        }

        public int getReceivers()
        {
            return NativeMethods.GetFoundReceiverCount();
        }


    }

    interface CheckAlgorithm
    {
        Boolean execute();
        String getResult();
        void setLedControl(LedControl control);
    }

    class SenderCheck : CheckAlgorithm
    {
        private LedControl control;
        public bool execute()
        {
            Boolean result = false;
            int senders = (int)control.getSenders();
            for(int step=0; step < senders; step++)
            {
                NativeMethods.GetSenderId((byte)step);
            }
            throw new NotImplementedException();
        }

        public string getResult()
        {
            throw new NotImplementedException();
        }

        public void setLedControl(LedControl control)
        {
            this.control = control;
        }
    }


    class ReceiverCheck : CheckAlgorithm
    {
        public bool execute()
        {
            throw new NotImplementedException();
        }

        public string getResult()
        {
            throw new NotImplementedException();
        }

        public void setLedControl(LedControl control)
        {
            throw new NotImplementedException();
        }
    }

    class ModuleCheck : CheckAlgorithm
    {
        private LedControl control;
        public bool execute()
        {
            throw new NotImplementedException();
        }

        public string getResult()
        {
            throw new NotImplementedException();
        }

        public void setLedControl(LedControl control)
        {
            throw new NotImplementedException();
        }
    }


}
