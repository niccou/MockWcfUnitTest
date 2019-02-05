using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WcfClient.WcfService;

namespace WcfClient
{
    public class WcfServiceAgent
    {
        IWcfService wcfService;

        public WcfServiceAgent(IWcfService wcfService)
        {
            this.wcfService = wcfService;
        }

        public string HitWCFService()
        {
            int val = 1;

            string retVal = string.Empty;

            retVal = this.wcfService.GetData(val);

            return retVal;
        }
    }

}
