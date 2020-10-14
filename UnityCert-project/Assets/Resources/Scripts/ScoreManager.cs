using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private static int playerScore;
    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
    }

    public void ResetScore()
    {
        playerScore = 00000000;
    }
}
