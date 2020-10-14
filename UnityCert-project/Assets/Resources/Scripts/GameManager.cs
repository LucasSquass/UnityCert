using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public static ScenesManager.Scenes currentScene = 0;
    public static int gameLevelScene = 3;
    public static int playerLives = 3;

    bool died = false;
    public bool Died
    {
        get { return died; }
        set { died = value; }
    }

    private void Awake()
    {
        CheckGameManagerIsInTheScene();
        DontDestroyOnLoad(gameObject);

        currentScene = (ScenesManager.Scenes)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex; //TODO Use ScenesManager
        LightAndCameraSetup(currentScene);
    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LifeLost()
    {
        //lose life
        if(playerLives >= 1)
        {
            playerLives--;
            Debug.Log("Lives left: " + playerLives);
            GetComponent<ScenesManager>().ResetScene();
        }
        else
        {
            playerLives = 3;
            GetComponent<ScenesManager>().GameOver();
        }
    }

    private void CameraSetup()
    {
        GameObject gameCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //Camera Transform
        gameCamera.transform.position = new Vector3(0, 0, -300);
        gameCamera.transform.eulerAngles = new Vector3(0, 0, 0);

        //Camera Properties
        gameCamera.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        gameCamera.GetComponent<Camera>().backgroundColor = new Color32(0, 0, 0, 255);
    }

    private void LightSetup()
    {
        GameObject dirLight = GameObject.Find("Directional Light");
        dirLight.transform.eulerAngles = new Vector3(50, -30, 0);
        dirLight.GetComponent<Light>().color = new Color32(152, 204, 255, 255);
    }

    void LightAndCameraSetup(ScenesManager.Scenes sceneNumber)
    {
        switch (sceneNumber)
        {
            case ScenesManager.Scenes.INITIALSCENE:
            case ScenesManager.Scenes.LEVEL1:
            case ScenesManager.Scenes.LEVEL2:
            case ScenesManager.Scenes.LEVEL3:
            {
                LightSetup();
                CameraSetup();
                break;
            }
        }
    }

    private void CheckGameManagerIsInTheScene()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
