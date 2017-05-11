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

        /*public int getModules()
        {
            
        }*/

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
        private String result;

        private String buildJsonResult(int id,bool outSignal,bool signal)
        {

            return "{\"senderId\":\""+id.ToString()+"\",\"outSignal\":\""+outSignal.ToString()+"\",\"inSignal\":\""+signal.ToString()+"\"";
        }


        public bool execute()
        {
            Boolean res = false;
            int senders = (int)control.getSenders();
            for(int step=0; step < senders; step++)
            {
                int id = NativeMethods.GetSenderId((byte)step);
                bool inputSignail = NativeMethods.GetSenderDviInput((byte)step, out ushort rHorResolution, out ushort rVerResolution); // What is are resolutions?
                if (true)
                {
                    result = buildJsonResult(id, false, inputSignail);
                    res = true;
                }
            }
            return res;
        }

        public string getResult()
        {
            return result;
        }

        public void setLedControl(LedControl control)
        {
            this.control = control;
        }
    }


    class ReceiverCheck : CheckAlgorithm
    {
        private LedControl control;
        private String result;

        private String buildJsonResult(int recId, bool recInfo, bool recBadPanelsInfo)
        {
            return "{\"receiverd\":\"" + recId.ToString() + "\",\"outSignal\":\"" + recInfo.ToString() + "\",\"inSignal\":\"" + recBadPanelsInfo.ToString() + "\"";
        }
        public bool execute()
        {
            Boolean res = false;
            int reseivers = (int)control.getReceivers();
            
            NativeMethods.tagReceiverIdInfo recIdInfo;
            NativeMethods.tagReceiverBadPanels recBadPanels;
            
            for (int step = 0; step < reseivers; step++)
            {
                int recId = step;
                bool recInfo = NativeMethods.GetReceiverIdInfo(out recIdInfo, (ushort)step);
                bool recBadPanelsInfo = NativeMethods.GetReceiverBadPanels((ushort)step, out recBadPanels);
                if (true)
                {
                    result = buildJsonResult(recId, recInfo, recBadPanelsInfo);
                    res = true;
                }
            }

                return res;
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
        private String buildJsonResult(bool moduleFullInfo)
        {
            return "{\"receiverd\":\"" + moduleFullInfo.ToString() + "\"";
        }

        private LedControl control;
        private String result;
        public bool execute()
        {
            Boolean res = false;
            int reseivers = (int)control.getReceivers();
            NativeMethods.tagReceiverModuleDetailInfo moduleInfo;

            for (int step = 0; step < reseivers; step++)
            {
                bool moduleFullInfo = NativeMethods.QueryReceiverModuleDetailInfo(out moduleInfo, (ushort)step);
                if (true)
                {
                    result = buildJsonResult(moduleFullInfo);
                    res = true;
                }
            }
            return res;
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
