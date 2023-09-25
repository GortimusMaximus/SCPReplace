using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCPReplace
{
    public class Plugin : Plugin<Config>
    {
        private EventHandler eventHandler;

        public override void OnEnabled()
        {

            eventHandler = new EventHandler();

            Exiled.Events.Handlers.Server.RoundStarted += eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += eventHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.Left += eventHandler.OnPlayerLeaving;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            eventHandler = null;

            Exiled.Events.Handlers.Server.RoundStarted -= eventHandler.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= eventHandler.OnRoundEnded;
            Exiled.Events.Handlers.Player.Left -= eventHandler.OnPlayerLeaving;
            base.OnDisabled();
        }

    }
}
