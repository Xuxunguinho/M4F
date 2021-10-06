using UnityEngine;

public class GameOverPanel : MonoBehaviour {

    // Use this for initialization
    public GameObject I;
    public SoundManager SoundManager;
    public LevelInterfaceManager LevelManager;
    public LevelGoalsManager LevelGoalsManager;
    public ScoreManager ScoreManager;
    private int _levelId;
	void Start () {
        _levelId = LevelManager.World.SelectedLevel;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RepeatGame()
    {       
            LevelManager.World.Levels[_levelId - 1].TargetGoals.Init = 0;
            LevelManager.World.Levels[_levelId - 1].BestTime = LevelManager.World.Levels[_levelId - 1].TimeSeconds;          
            LevelManager.World.Levels[_levelId - 1].Stars = 0;
            ScoreManager.DecreaseStars(LevelGoalsManager.ScoreOfStarsInLevel);
            LevelGoalsManager.ScoreOfStarsInLevel = 0;
            LevelGoalsManager.EventsMonitor = true;
            LevelManager.OverDrawPanel.SetActive(false);
            LevelManager.LoadBoard();

    }
    public void QuitLevel()
    {
        SoundManager.PlayOnClick();
        I.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");
    }
}
