using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingMenu : MonoBehaviour
{
   private string sceneKey = "Scenes/MainMenu";
   [SerializeField] private Slider _slider;
   private void Start()
   {
      Invoke("LoadMainMenu",2f);  
   }

   private void LoadMainMenu()
   {
      StartCoroutine(LoadAsynchronously());
   }

   IEnumerator LoadAsynchronously()
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneKey);
      while (!operation.isDone)
      {
         _slider.value = operation.progress;
         yield return null;
      }
      
   }
   
}
