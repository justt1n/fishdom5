using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Athena.Common;
using Athena.Common.UI;
using System.IO;

namespace GamePlay
{
    public class GameController : MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject npcPrefabs;

        [SerializeField] private List<Sprite> _imageList;
        [SerializeField] private List<int> _values;
        [SerializeField] private List<Sprite> _playerImages;
        [SerializeField] private string _jsonFilePath;
        [SerializeField] private GameObject _top;
        [SerializeField] private GameObject _bottom;
        [SerializeField] private GameObject _left;
        [SerializeField] private GameObject _right;

        public static GameController Instance;
        private GameObject _player;
        private GameObject _npc;
        private Level _level;
        private int _step;
        private int[] _order;
        private int _currentStep;
        private int _npcCountInMap;
        private void Awake()
        {
            GameController.Instance = this;
        }
        void Start()
        {
            _currentStep = 0;
            _npcCountInMap = 0;
            initPlayer();
            LoadLevelData();
            initNPC(_currentStep);
        }


        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);


            }

        }

        private void initNPC(int step)
        {
            _npc = Instantiate(npcPrefabs, transform);
            _npc.GetComponent<NPCController>().SetPoint(_values[_order[step]]);
            _npc.GetComponent<NPCView>().SetImage(_imageList[_order[step]]);
            _currentStep += 1;
            _npcCountInMap += 1;
        }

        private void initPlayer()
        {
            _player = Instantiate(playerPrefab, transform);
            _player.GetComponent<Player>().Score = 0;
            _player.GetComponent<Player>().Step = 0;
            _player.GetComponent<PlayerView>().SetImage(_playerImages[0]);
        }

        public void LoadLevelData()
        {
            string jsonString = File.ReadAllText(_jsonFilePath);
            _level = JsonUtility.FromJson<Level>(jsonString);
            _step = _level.step;
            _order = _level.order;
        }

        public void OnSuccess() {
            _player.GetComponent<PlayerController>().OnSuccess(_npc.GetComponent<NPC>().Point, _currentStep-1);
            Destroy(_npc);
            _npcCountInMap -= 1;
            initNPC(_currentStep);
        }

         public float ConvertEdge(int edge)
        {
            switch (edge)
            {
                case 0:
                    {
                        return _top.GetComponent<RectTransform>().localPosition.y;

                    }
                case 1:
                    {
                        return _right.GetComponent<RectTransform>().localPosition.x;
                    }
                case 2:
                    {
                        return _bottom.GetComponent<RectTransform>().localPosition.y;
                    }
                case 3:
                    {
                        return _left.GetComponent<RectTransform>().localPosition.x;
                    }
                default:
                    return 0;

            }
        }
    }
}
