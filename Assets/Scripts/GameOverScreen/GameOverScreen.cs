using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Object MenuScene;

    public GameObject GameOverSprite;
    
    void Start()
    {
        GameOverSprite.SetActive(false);
    }
    private void CallEndScreen()
    {
        GameOverSprite.SetActive(true);
        Invoke(nameof(EndGame), 3f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene(MenuScene.name);
    }
    
    private void OnEnable()
    {
        ScoreManager.GameOver += CallEndScreen;
    }

    private void OnDisable()
    {
        ScoreManager.GameOver -= CallEndScreen;
    }
}
