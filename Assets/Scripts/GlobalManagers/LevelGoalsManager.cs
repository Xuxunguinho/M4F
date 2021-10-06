using UnityEngine;

// ReSharper disable once CheckNamespace
public class LevelGoalsManager : MonoBehaviour {

    //public Sprite ActiveStar;
    //public Sprite InactiveSprite;
    public  LevelInterfaceManager LevelManager;
    public GameObject OverDrawPanel;
    public GamingOverDrawPanelManager OverDrawObject;
    //public Image[] StarsItems;
    private StarsClassificatorManager _stClassificator;
    private GameDataManager _gameData;

    private int _score;
    public int ScoreOfStarsInLevel { get { return _score; } set { _score = value;
            LevelManager.World.Levels[LevelManager.World.SelectedLevel-1].Score = _score;
        }
    }

    //private fields
    public  bool EventsMonitor=false;
    private int _seconds;
    private int _sone, _stwo, _stree;
    private int  _time ;
    public int Time { get { return _time; }

        set { _time = value;



        }
    }
    private int _interv;
    private int _stars;
    private int _starsGoals;
    private int _levelId;
   
    

    public int Stars { get { return _stars; } }
    public int  StarLevelClassificationGoals {get {return GetLevelclassification(); }}
    // Use this for initialization
    void Start ()
    {
        EventsMonitor = true;
        //inicializando com zero para nao poder incrementar em valores de outros niveis
        ScoreOfStarsInLevel = 0;
        _gameData = FindObjectOfType<GameDataManager>();
        //
        _stClassificator = FindObjectOfType<StarsClassificatorManager>();        
        _levelId = LevelManager.World.SelectedLevel;
        // o numero de estralas a alcancar e igual a muitiplicacao do target final vezes 3
        _starsGoals = LevelManager.World.Levels[_levelId - 1].TargetGoals.Final * 3;
    }
    public void CompleteLevel()
    {
        if (_gameData.SaveData == null) return;
             
        if (LevelManager.World.Levels[_levelId - 1].TargetGoals.Init == LevelManager.World.Levels[_levelId - 1].TargetGoals.Final)
        {
            LevelManager.StopWatch.Stoped = true;
            LevelManager.World.Levels[_levelId - 1].Stars = GetLevelclassification();
            SaveWin();
                LevelManager.OverDrawPanel.SetActive(true);
               if( LevelManager.OverdrawObject.Show(3))
                       EventsMonitor = false;
        }
        if (LevelManager.StopWatch.Time == 0)
        {
           
        }
    }
   
    public bool SaveWin()
    {
        try
        {
            
           // ON PLAY AGAIN THE LEVEL
                if(_gameData.SaveData.CurrentTarget[_levelId - 1] != 0){

                  var count = (LevelManager.World.Levels[_levelId - 1].Score - _gameData.SaveData.ScoreOfStarsInLevel[_levelId - 1] );
                  _gameData.SaveData.ScoreOfStarsInGame += count;
                  //int countStar = levelManager.World.Levels[levelId - 1].Stars - gameData.saveData.Stars[levelId - 1];
                  //gameData.saveData.ScoreOfStarsInGame += countStar;
            }
            else
            {
                _gameData.SaveData.ScoreOfStarsInGame += LevelManager.World.Levels[_levelId - 1].Score;
            }
            _gameData.SaveData.Stars[_levelId - 1] = LevelManager.World.Levels[_levelId - 1].Stars;
            _gameData.SaveData.CurrentTarget[_levelId - 1] = LevelManager.World.Levels[_levelId - 1].TargetGoals.Init;
            _gameData.SaveData.ScoreOfStarsInLevel[_levelId - 1] = LevelManager.World.Levels[_levelId - 1].Score;
            _gameData.SaveData.BestTime[_levelId - 1] = LevelManager.World.Levels[_levelId - 1].BestTime;            /// unlock next nivel 
            _gameData.SaveData.IsLocked[_levelId] = false; 
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }

    }
    public bool SaveGameOVer()
    {
        try
        {
            _gameData.SaveData.BestTime[_levelId - 1] = LevelManager.World.Levels[_levelId - 1].TimeSeconds;  
            _gameData.SaveData.CurrentTarget[_levelId - 1] = 0;
            _gameData.SaveData.Stars[_levelId - 1] = 0;
            _gameData.SaveData.ScoreOfStarsInLevel[_levelId - 1] = 0;           
           
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }

    }
    public void GameOver()
    {
        OverDrawPanel.SetActive(true);
        OverDrawObject.Show(2);
        EventsMonitor = true;
    }
    /// <summary>
    /// reset all star 
    /// </summary>
     
    public int GetLevelclassification() {

        var intervalScore = _starsGoals / 3;
        //var Ione =starsGoals -
        if (ScoreOfStarsInLevel >= (intervalScore * 1) & ScoreOfStarsInLevel < (intervalScore * 2))
        {
            return   1;
        }
        else if (ScoreOfStarsInLevel >= (intervalScore * 2) & ScoreOfStarsInLevel < (intervalScore * 3))
        {
            return   2;
        }
        else if (ScoreOfStarsInLevel == (intervalScore * 3))
        {
          return  3;
        }
        else
        {
          return  0;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void GetBoardCurrentScore() {

        if (LevelManager != null)
        {
            _interv = (int)(LevelManager.World.Levels[LevelManager.World.SelectedLevel - 1].TimeSeconds / 3);

            _sone = LevelManager.World.Levels[LevelManager.World.SelectedLevel - 1].TimeSeconds;
            _stwo = LevelManager.World.Levels[LevelManager.World.SelectedLevel - 1].TimeSeconds - (_interv * 1);
            _stree = LevelManager.World.Levels[LevelManager.World.SelectedLevel - 1].TimeSeconds - (_interv * 2);
            Time = (LevelManager.StopWatch.Dt.Minute * 60) + LevelManager.StopWatch.Dt.Second;
            
            if (Time <= _sone & Time > _stwo)
            {              
             
               _stClassificator.ActivateStars(3);
                _stars = 3;
            }
            else if (Time <= _stwo & Time > _stree)
            {
               _stClassificator. ActivateStars(2);
                _stars = 2;
            }
            else if (Time <= _stree & Time > 0)
            {
               _stClassificator. ActivateStars(1);
                _stars = 1;

            }
            else if (Time == 0)
            {
                _stars = 0;
                _stClassificator. ActivateStars(0);
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        GetBoardCurrentScore();
        if (EventsMonitor) { CompleteLevel();}
       
    }
}

