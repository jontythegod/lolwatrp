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
            EventHandlers["LWRP_OnPlayerConnected"] += new Action<Player, int>(LWRP_OnPlayerConnected);
            EventHandlers["playerJoining"] += new Action<Player>(LWRP_OnPlayerJoining);
        }

        public void LWRP_OnPlayerJoining([FromSource] Player pl)
        {
            Debug.WriteLine(pl.Name + " joined the server.");
        }

        public void LWRP_OnPlayerConnected([FromSource] Player pl, int identifier)
        {
            Debug.WriteLine("Client initial heartbeat from license: " + pl.Identifiers["license"] + " (" + pl.Name + ")");

            TriggerClientEvent(pl, "LWRP_Handshake", "license=" + pl.Identifiers["license"] + "&realname=Jim_Rayson");
        }
    }
}