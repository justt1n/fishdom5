using System;
using System.Collections;
using Athena.Common;
using Athena.Common.UI;
using CustomUtils;
using UnityEngine;


namespace Managers
{
    public class AppManager : SingletonMono<AppManager>
    {
        private AppStateMachine _stateMachine;
        public AppManager() {
        }
        protected override void OnAwake()
        {
            base.OnAwake();
            //Inittialize app
            Application.targetFrameRate = 60;
            Input.multiTouchEnabled = false;

            _stateMachine = new AppStateMachine();

            //Setup athena app
            SetupAthenaApp();
        }
        public void Switch (IState newState)
        {
            StartCoroutine(_stateMachine.SwitchProcess(newState));            
        }
        void SetupAthenaApp() {
            Switch(new AppFlow.AppStateInitial());
        }
    }
}