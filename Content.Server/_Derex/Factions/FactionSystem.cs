using Content.Shared.Factions;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Log;
using Robust.Server.Player;
using Robust.Shared.Enums;
using Robust.Shared.Player;
using Robust.Shared.Serialization.Manager;
using Robust.Shared.Prototypes;
using Content.Server.Mind;
using Content.Server.Popups;
using Content.Server.EUI;
using Content.Shared.IdentityManagement;

namespace Content.Server.Factions
{
    public sealed class FactionSystem : EntitySystem
    {	
        public override void Initialize()
        {
            base.Initialize();
            SubscribeNetworkEvent<FactionCreateRequestMessage>(OnFactionCreateRequest);
        }

        private void OnFactionCreateRequest(FactionCreateRequestMessage msg, EntitySessionEventArgs args)
        {
            // Проверяем, что имя фракции корректное
            if (string.IsNullOrWhiteSpace(msg.FactionName))
            {
                return;
            }

            var player = args.SenderSession.AttachedEntity;
			
			if (!player.HasValue)
            return;

            // Проверяем, есть ли уже такая фракция
            //if (FactionExists(msg.FactionName))
            //{
            //    // Отправляем сообщение об ошибке
            //    RaiseNetworkEvent(new FactionCreateResponseMessage
            //    {
            //        Success = false,
            //        ErrorMessage = "Фракция с таким названием уже существует."
            //    }, args.SenderSession);
            //    return;
            //}

            // Создаём фракцию
            CreateFaction(player.Value, msg.FactionName);
        }

        private void CreateFaction(EntityUid player, string factionName)
        {
            // Выдаём компонент фракции
            if (!EntityManager.TryGetComponent<FactionComponent>(player, out var factionComponent))
            {
                factionComponent = EntityManager.AddComponent<FactionComponent>(player);
				
				factionComponent.FactionName = factionName;
				factionComponent.IsCreator = true;
            }
        }
    }
}