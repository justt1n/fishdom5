using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay
{
    public class NPCView : MonoBehaviour
    {
        public void SetImage(Sprite image)
        {
            this.GetComponent<SpriteRenderer>().sprite = image;
        }
    }

}