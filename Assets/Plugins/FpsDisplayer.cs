using UnityEngine;

namespace Common { 
    public class FpsDisplayer : MonoBehaviour {

        #region Debug
        public bool IsShow { get; set; }
        public void ShowOrHide() { IsShow = !IsShow; }
        #endregion
        
        private float deltaTime = 0.0f;
        private GUIStyle style;
        
        void Start()
        {
            style = new GUIStyle();
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = Screen.height * 2 / 70;
            style.normal.textColor = Color.white;
        }

        void Update() {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        }

        void OnGUI() {
            //if (!IsShow) return;

            int w = Screen.width, h = Screen.height;

            var msec = deltaTime * 1000.0f;
            var fps = 1.0f / deltaTime;
            var text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);

            GUILayout.BeginVertical("Box");
            GUILayout.Label(text, style);
            GUILayout.EndVertical();
        }
    }
}
