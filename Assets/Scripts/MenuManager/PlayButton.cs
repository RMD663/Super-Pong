using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour
{
  
    public Object sceneToLoad;

    
    public void StartScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}
