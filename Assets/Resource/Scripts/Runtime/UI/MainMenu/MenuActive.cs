using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Screen;
using UnityScreenNavigator.Runtime.Core.Shared.View;

namespace Assets.Scripts.Runtime.UI.MainMenu
{
    public class MenuActive:MonoBehaviour
    {
        [SerializeField] private ScreenContainer _screenContainer;
        private void Awake()
        {
            var windowOption =new WindowOptions("screen_main_menu",true);
            _screenContainer.Push(windowOption);
        }
    }
}