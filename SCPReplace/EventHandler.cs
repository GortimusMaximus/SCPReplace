using System;
using System.Linq;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SCPReplace
{
    public class EventHandler
    {
        public void OnPlayerLeaving(LeftEventArgs ev)
        {
            if(ev.Player.IsScp)
            {
                Log.Debug("Player is an SCP");
                Exiled.API.Features.Player player = Exiled.API.Features.Player.List.FirstOrDefault(x => x.Role == RoleTypeId.Spectator && x.UserId != ev.Player.UserId);
                Log.Debug("Perameters passed");
                if (player != null)
                {
                    RoleTypeId scpID = ev.Player.Role;
                    Log.Debug("SCPID set");
                    player.Role.Set(scpID);
                    Log.Debug("Role set");
                    player.Position = ev.Player.Position;
                    Log.Debug("Position Set");
                    player.Rotation = ev.Player.Rotation;
                    Log.Debug("Rotation Set");
                    player.Health = ev.Player.Health;
                    Log.Debug("Health Set");
                    player.Broadcast(5, "You have replaced an scp");
                }
            }
        }
    }
}