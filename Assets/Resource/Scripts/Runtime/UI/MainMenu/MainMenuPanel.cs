using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityScreenNavigator.Runtime.Core.Shared.View;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [SerializeField] private Button Start;
        private void Awake()
        {
            Start.onClick.AddListener(OnClick);
            
        }

        void OnClick()
        {
            
        }
        
    }
}