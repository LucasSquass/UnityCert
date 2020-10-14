using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    Scenes scenes;
    public enum Scenes
    {
        BOOTUP,
        TITLE,
        SHOP,
        INITIALSCENE,
        LEVEL1,
        LEVEL2,
        LEVEL3,
        GAMEOVER
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public void BeginGame()
    {
        LoadScene(Scenes.INITIALSCENE);
    }

    public void GameOver()
    {
        Debug.Log("ENDSCORE: " + GameManager.Instance.GetComponent<ScoreManager>().PlayerScore);
        LoadScene(Scenes.GAMEOVER);
    }
}
