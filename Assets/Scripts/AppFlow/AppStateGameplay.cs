using System;
using System.Collections;
using System.Diagnostics;
using Athena.Common;
using Athena.Common.UI;
using Managers;
using UIControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppFlow
{
    public class AppStateGameplay : IState
    {
        public bool IsInitialized => _isInitialized;
        private bool _isInitialized = false;

        public int LevelId;

        #region App States
        public void Initialize()
        {
            SceneManager.sceneLoaded += onSceneLoaded;
            SceneManager.LoadScene(C.Scenes.Game, LoadSceneMode.Single);
            
        }

        private void onSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.sceneLoaded -= onSceneLoaded;
            _isInitialized = true;
        }

        public void Resume()
        {

        }

        public void Clear()
        {
        }

        public void Exit()
        {
            // _gameplayMonoBehaviour.ResetAll();
        }
        #endregion App States

    }
}