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
            EventHandlers.Add("LWRP_Handshake", new Action<string>(LWRP_Handshake));
        }

        public void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return; // Init the resource -once-

            TriggerServerEvent("LWRP_OnPlayerConnected", PlayerId());
        }

        public void LWRP_Handshake([FromSource] string payload)
        {
            Debug.WriteLine("Payload received by client: " + payload);

            // Spawn me in bitch
            //Exports["spawnmanager:setAutoSpawn"](false);
            //Exports["spawnmanager:forceRespawn"]();
        }
    }
}