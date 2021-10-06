using UnityEngine;
using UnityEngine.UI;

public class LevelGoalsScene : MonoBehaviour {

    // Use this for initialization
    [Header("Fill UI")]
    public Text ScoreOfStarsCount;
    public Text BestTimeCount;
    //public Text LifeHarts;
    public Text LevelNumber;
    public LevelGoalsManager LevelGoalsManager;
    public ScoreManager ScoreManager;
    public StarsClassificatorManager StClassificator;
    public LevelInterfaceManager LevelManager;
    private int _levelId;
    public World WorldGame;
    void Start ()
    {
        _levelId = WorldGame.SelectedLevel;
        //stClassificator = FindObjectOfType<StarsClassificatorManager>();
    }
    /// <summary>
    /// Este metodo serve para preencher os dados deste painel... 
    /// </summary>
    /// <param name="stars">Numero de estralas que arecadou no nivel selecionado</param>
    /// <param name="scoreOfStars">score especifico feito neste mesmo nivel</param>
    /// <param name="bestimeGamed">o melhor tempo de resposta </param>
    public void DataTransport()
    {
        LevelNumber.text = string.Format("Board {0} Solved", _levelId);
        //LifeHarts.text =""+ worldGame.GoldHarts;
        ScoreOfStarsCount.text = string.Format("{0} /{1}", WorldGame.Levels[_levelId-1].Score, WorldGame.Levels[_levelId-1].TargetGoals.Final* 3);
        BestTimeCount.text = string.Format("{0} s", WorldGame.Levels[_levelId -1].BestTime);
        StClassificator.ActivateStars(WorldGame.Levels[_levelId - 1].Stars);
    }
    // Update is called once per frame
    void Update () {
        DataTransport();
	}
    public void PlayClick() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");
    }
    public void RepeatGame()
    {
        WorldGame.Levels[_levelId - 1].TargetGoals.Init = 1
            ;
        WorldGame.Levels[_levelId - 1].Stars = 0;
        ScoreManager.DecreaseStars(LevelGoalsManager.ScoreOfStarsInLevel);
        LevelGoalsManager.ScoreOfStarsInLevel = 0;
        LevelGoalsManager.EventsMonitor = true;
        LevelManager.OverDrawPanel.SetActive(false);
        LevelManager.LoadBoard();

    }
}
