using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using lolwat.Client.Helpers;
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

        public void LWRP_Handshake(string payload)
        { 
            Debug.WriteLine("Received data: " + payload);

            // Spawn me in bitch
            SpawnHelper.SpawnPlayer("player_three", -262.849f, 793.404f, 118.087f, 0.0f);
        }
    }
}