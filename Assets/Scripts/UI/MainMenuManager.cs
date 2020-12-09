using System.Collections;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuManager : MonoBehaviour
    {
        #region UI Element Variables
        
        [SerializeField] private GameObject uiCanvas;
        [SerializeField] private Button startButton;
        [SerializeField] private Button quitButton;

        #endregion
        
        #region Unity Events

        private void Awake()
        {
            Time.timeScale = 0f;
            startButton.onClick.AddListener(StartDemo);
            quitButton.onClick.AddListener(QuitDemo);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
            quitButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region Method Definitions

        /// <summary>
        /// This method is callback for StartButton onclick listener.
        /// </summary>
        public void StartDemo()
        {
            // Disable main menu canvas
            uiCanvas.SetActive(false);
            
            // Notify the game starts
            EventManager.GetInstance().Notify(Events.StartGame);
            
            Time.timeScale = 1f;
        }
        
        /// <summary>
        /// This method is callback for QuitButton onclick listener.
        /// </summary>
        public void QuitDemo()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        #endregion Method Definitions
    }
}