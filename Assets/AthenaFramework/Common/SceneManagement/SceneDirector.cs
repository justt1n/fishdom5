﻿using UnityEngine;
using System.Collections;
using CustomUtils;

namespace Athena.Common
{
    public class SceneDirector : SingletonMono<SceneDirector>
    {
        public static int OverlayLayer
        {
            get
            {
                int layer = LayerMask.NameToLayer("ScreenOverlay");
                if (layer < 0)
                {
                    Debug.LogError("ScreenOverlay layer not found! Please add in your editor!");
                }

                return layer;
            }
        }

        [SerializeField]
        private Camera _overlayCamera = null;
        public Camera OverlayCamera
        {
            get
            {
                return _overlayCamera;
            }

#if UNITY_EDITOR
            set
            {
                _overlayCamera = value;
            }
#endif
        }

        private TransitionDelegate _transition;

        public bool IsRunningTransition()
        {
            return _transition != null;
        }

        public void Transition(TransitionDelegate transition)
        {
            _transition = transition;
            StartCoroutine(RunTransition());
        }

        public static Texture2D GetScreenshotTexture()
        {
            var screenSnapshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false, true);
            screenSnapshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            screenSnapshot.Apply();

            return screenSnapshot;
        }

        public Mesh CreateQuadMesh()
        {
            var halfHeight = _overlayCamera.orthographicSize;
            var halfWidth = halfHeight * ((float)Screen.width / (float)Screen.height);

            var mesh = new Mesh();
            mesh.vertices = new Vector3[]
            {
            new Vector3( -halfWidth, -halfHeight, 0 ),
            new Vector3( -halfWidth, halfHeight, 0 ),
            new Vector3( halfWidth, -halfHeight, 0 ),
            new Vector3( halfWidth, halfHeight, 0 )
            };
            mesh.uv = new Vector2[]
            {
            new Vector2( 0, 0 ),
            new Vector2( 0, 1 ),
            new Vector2( 1, 0 ),
            new Vector2( 1, 1 )
            };
            mesh.triangles = new int[] { 0, 1, 2, 3, 2, 1 };

            return mesh;
        }

        IEnumerator RunTransition()
        {
            _overlayCamera.gameObject.SetActive(true);

            yield return StartCoroutine(_transition.Execute());
            _transition = null;

            _overlayCamera.gameObject.SetActive(false);
        }

        protected override void OnAwake()
        {
            gameObject.layer = OverlayLayer;
            _overlayCamera.orthographic = true;
            _overlayCamera.orthographicSize = 20f;
            _overlayCamera.nearClipPlane = -100f;
            _overlayCamera.farClipPlane = 100f;
            _overlayCamera.depth = float.MaxValue;
            _overlayCamera.cullingMask = 1 << OverlayLayer;
            _overlayCamera.clearFlags = CameraClearFlags.Depth;
            _overlayCamera.gameObject.SetActive(true);
        }
    }

}
