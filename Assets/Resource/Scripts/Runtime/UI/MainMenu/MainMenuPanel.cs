using UnityEngine;
using UnityEngine.UI;

namespace Resource.Scripts.Runtime.UI.MainMenu
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