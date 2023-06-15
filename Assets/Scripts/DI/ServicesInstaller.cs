
using Zenject;
using UnityEngine;

public class ServicesInstaller : MonoInstaller
{
    
        [SerializeField] private GameMode _gameMode;

        private GameEvents _gameEvents;
        private CurrencyVault _currencyVault;

         public override void InstallBindings()
        {
            _gameEvents = new GameEvents();
            _currencyVault = new CurrencyVault();

            GameMode();

            GameEventsExecuter();
            GameEventsListener();

            CurrencyVault();
        }

         private void GameMode()
        {
            Container
                .Bind<GameMode>()
                .To<GameMode>()
                .FromInstance(_gameMode)
                .AsSingle()
                .NonLazy();
        }

        private void GameEventsExecuter()
        {
              Container
                .Bind<IGameEventsExecuter>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();
        }

        private void GameEventsListener()
        {
            Container
                .Bind<IGameEventsListener>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();
        }

         private void CurrencyVault()
            {
            Container
                .Bind<ICurrencyVault>()
                .To<CurrencyVault>()
                .FromInstance(_currencyVault)
                .NonLazy();

            Container
                .Bind<ICurrencyVaultState>()
                .To<CurrencyVault>()
                .FromInstance(_currencyVault)
                .NonLazy();
            }

}
