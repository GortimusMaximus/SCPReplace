using Exiled.API.Features;
using System;

namespace SCPReplace
{
    public class Plugin : Plugin<Config>
    {
        private EventHandler eventHandler;

        public override void OnEnabled()
        {

            eventHandler = new EventHandler();

            Exiled.Events.Handlers.Player.Left += eventHandler.OnPlayerLeaving;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            eventHandler = null;

            Exiled.Events.Handlers.Player.Left -= eventHandler.OnPlayerLeaving;
            base.OnDisabled();
        }
    }
}
