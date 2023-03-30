using System;
using System.Collections;
using Athena.Common;
using Athena.Common.UI;
using Managers;
using UnityEngine;

namespace AppFlow
{
    public class AppStateInitial: IState
    {
        public bool IsInitialized => _isInitialized;
        private bool _isInitialized = false;

        private UIControllers.HomeUI _homeUI;
        public void Initialize() 
        {
            _isInitialized = true;
            _homeUI = UIManager.Instance.ShowUIOnTop<UIControllers.HomeUI>(C.Layer.Home, 0);
            _homeUI.OnStartGame += onPlay;
        }

        private void onPlay() {
            Debug.Log("Press PlayBtn");
            //AppManager.Instance.Switch(new AppStateGameplay());
        }

        public void Resume() { }
        public void Clear() { }
        public void Exit() { }
    }
}