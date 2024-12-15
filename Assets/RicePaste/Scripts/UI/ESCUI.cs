using UnityEngine;
using UnityEngine.SceneManagement;

namespace RicePaste.Scripts.UI
{
 
    public class ESCUI : MonoBehaviour
    {
        public void EscUI()
        {
            if (gameObject.activeSelf == false)
            {
                gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
        
        public void RetryBtn()
        {
            gameObject.SetActive(false);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            Time.timeScale = 1;
        }

        public void ExitBtn()
        {
            Application.Quit();
        }
    }   
}
