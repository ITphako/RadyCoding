

using UnityEngine;
using Zenject;

public class LoadLevelState : ILevelState
    {
        private readonly LevelStateMachine _levelStateMachine;

        private readonly IGameEventsExecuter _gameEventsExecuter;

        public LoadLevelState(LevelStateMachine levelStateMachine, DiContainer diContainer)
        {
            _levelStateMachine = levelStateMachine;

            _gameEventsExecuter = diContainer.Resolve<IGameEventsExecuter>();
        }


        public void Enter()
        {
            _gameEventsExecuter.OnLevelLoaded();
            _levelStateMachine.Enter<LoadLevelProgressState>();
        }


        public void Exit()
        {

        }
    }
