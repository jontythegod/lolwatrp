using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using static CitizenFX.Core.Native.API;

namespace lolwatrp.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            EventHandlers["LWRP_OnPlayerConnected"] += new Action<int>(LWRP_OnPlayerConnected);
        }

        public void LWRP_OnPlayerConnected(int identifier)
        {
            Debug.WriteLine("Player connected with uid: " + identifier);

            // Fetch details, do things, trigger pincode auth for fivem id if account exists.
            // If not exists, trigger backstory setup.
            // If exists and pincode is legit, fetch data from mysql
            Dictionary<string, object> data = new Dictionary<string, object>();

            // Send payload to the client script.
            TriggerClientEvent(Players[identifier], "LWRP_Handshake", data);
        }
    }
}