using XRL; // to abbreviate XRL.PlayerMutator and XRL.IPlayerMutator
using XRL.World; // to abbreviate XRL.World.GameObject

namespace Cattlesquat_ChatKey
{
    [PlayerMutator]
    public class MyPlayerMutator : IPlayerMutator
    {
        public void mutate(GameObject player)
        {
            if (!player.HasPart(nameof(ChatKey_Part)))
            {
                player.AddPart<ChatKey_Part>();
            }
        }
    }
}