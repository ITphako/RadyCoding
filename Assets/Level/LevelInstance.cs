using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelInstance : MonoBehaviour
{
        private LevelStateMachine _levelStateMachine;

        private DiContainer _diContainer;
        private IGameEventsExecuter _gameEventsExecuter;
        private GameMode _gameMode;


        [Inject]
        private void Construct(DiContainer diContainer, IGameEventsExecuter gameEventsExecuter, GameMode gameMode)
        {
            _diContainer = diContainer;
            _gameEventsExecuter = gameEventsExecuter;
            _gameMode = gameMode;
        }


        private void Awake()
        {
            _gameEventsExecuter.OnLevelBootstrap();

            _levelStateMachine = new LevelStateMachine( _diContainer, _gameMode);

            _levelStateMachine.Enter<LoadLevelState>();
        }

        private void OnDestroy()
        {
            _levelStateMachine.Enter<LevelDestroyState>();
        }
    
}
