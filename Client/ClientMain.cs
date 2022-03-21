using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;

using static CitizenFX.Core.Native.API;

namespace lolwatrp.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            // cfx Event Handlers
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);

            // LWRP Event Handlers
            EventHandlers["LWRP_Handshake"] += new Action<Dictionary<string, object>>(LWRP_Handshake);

            // Spawn me in bitch
            Exports["spawnmanager:setAutoSpawn"](false);
            Exports["spawnmanager:spawnPlayer"](new { });

            Debug.WriteLine("Spawn Manager exports sent.");
        }

        public void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return; // Init the resource -once-

            // Player connected, let serverside know to collect player info payload for sendback
            TriggerServerEvent("LWRP_OnPlayerConnected", PlayerId()); // Send player id
            Debug.WriteLine("Payload request sent.");

            

            // TODO
            // Authentication, what not
        }

        public void LWRP_Handshake(Dictionary<string, object> character)
        {
            Debug.WriteLine("Payload received by client.");
        }
    }
}