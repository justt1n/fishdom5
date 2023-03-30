using UnityEngine;
using Athena.Common.UI;
using System;
using UI;

namespace UIControllers 
{
    public class HomeUI : UIController
    {
        public event Action OnStartGame;

        public UI.XButton StartBtn;

        public void Setup() {
            
        }

        protected override void OnUIStart()
        {
            StartBtn.OnClicked += _ => startGame();
        }
        protected override void OnUIRemoved()
        {
            StartBtn.RemoveAllListeners();
        }

        private void startGame() 
        {
            OnStartGame?.Invoke();
        }
        
    }
}