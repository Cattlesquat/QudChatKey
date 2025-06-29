using System;
using XRL;
using XRL.UI;
using XRL.World;
using XRL.Core; // For PerformSmartUse
using XRL.World.Capabilities; // For SmartUse
using XRL.World.Parts; // For HasPart

namespace Cattlesquat_ChatKey
{
    public class ChatKey_Part : IPlayerPart
    {
        public override bool WantEvent(int ID, int cascade)
        {
            return base.WantEvent(ID, cascade) || ID == CommandEvent.ID;
        }

        public override bool HandleEvent(CommandEvent E)
        {
            if (E.Command == "ChatKey_Chat")
            {
                ChatKey(E.Actor);
            }
            return base.HandleEvent(E);
        }

		public void ChatKey(GameObject who)
        {
			if (!who.IsPlayer()) return;

            XRLCore.Core.PerformSmartUse(filter: ChatKeyFilter); // Do a "smart use" (what "spacebar" does by default), but filter out anything/anyone who can't be chatted with
		}
        
        public bool ChatKeyFilter(GameObject who, GameObject go)
        {
            return go.HasPart<ConversationScript>(); // Filter out anything/anyone who can't be chatted with 
        }
	}
}
