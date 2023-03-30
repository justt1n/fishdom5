using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class NPCController : MonoBehaviour
    {
        public float swimSpeed = 5f;    // The speed the fish swims at
        public float size = 10f;


        private float _leftEdge;
        private float _rightEdge;
        private float _topEdge;
        private float _bottomEdge;

        void Start()
        {
            _topEdge = GameController.Instance.ConvertEdge(0) - transform.localScale.y;
            _rightEdge = GameController.Instance.ConvertEdge(1) - transform.localScale.x;
            _bottomEdge = GameController.Instance.ConvertEdge(2) + transform.localScale.y;
            _leftEdge = GameController.Instance.ConvertEdge(3) + transform.localScale.x;
        }


        void Update()
        {
            if (transform.localPosition.x >= _rightEdge || transform.localPosition.x <= _leftEdge)
            {
                if (transform.localPosition.x >= _rightEdge)
                {
                    transform.localPosition = new Vector3(_rightEdge, transform.localPosition.y, 0);
                }
                else if (transform.localPosition.x <= _leftEdge)
                {
                    transform.localPosition = new Vector3(_leftEdge, transform.localPosition.y, 0);
                }
                swimSpeed *= -1;
                transform.localScale = new Vector3(swimSpeed / Mathf.Abs(swimSpeed) * size, size, size);
            }
            transform.Translate(new Vector3(swimSpeed, 0, 0) * Time.deltaTime);
        }
        public void SetPoint(float point)
        {
            this.GetComponent<NPC>().Point = point;
        }
    }
}