// Dveloped by : Julio Jose de Andrade Reis

using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class BoardAnswerITC : MonoBehaviour {
   
    /// <summary>
    ///  The Algs will set in de Interface design in Unity editor , cause it isn't propertys
    /// </summary>
    public  AnswerItemITC[] Answers;
    public  BoardITC Owner;
    public  LevelInterfaceManager LevelM;
    private GameDataManager _gameData;
    private List<double> _lst;
    //private GameDataManager gameData;
    private SoundManager _soundManager;
    private ScoreManager _scoreManager;
    private LevelGoalsManager _levelGoalManager;
    [Header("ClicEvent Songs")]
    public AudioClip TrueValue;
    public AudioClip FalseValue;
  
    private void Start()
    {
        
        _gameData = FindObjectOfType<GameDataManager>();
        _levelGoalManager = FindObjectOfType<LevelGoalsManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _soundManager = FindObjectOfType<SoundManager>();
        Owner = FindObjectOfType<BoardITC>();
        LevelM = FindObjectOfType<LevelInterfaceManager>();
   
        
    }
    public List<double> Nresults 
    {
        get { return _lst; }
        set
        {
           
            _lst = value;      
           
            var srtSc = new SortedNumbers().Execute(0,4,4);
            //var N = new SortedNumbers().Execute(0, 4, 4);
            //Debug.Log("Na Lista " + lst.Count);
            Answers[0].Value = _lst[srtSc[1]];
            Answers[1].Value = _lst[srtSc[3]];
            Answers[3].Value = _lst[srtSc[2]];
            Answers[2].Value = _lst[srtSc[0]];
        }
    }
    /// <summary>
    ///  Fields to fill propertys
    /// </summary>  
    private AnswerItemITC _aitc;
   /// <summary>
   /// Capture the besttime of answer
   /// </summary>
    private void GetBestIme() {
        var t = LevelM.World.Levels[LevelM.World.SelectedLevel - 1].TimeSeconds - LevelM.StopWatch.BestTimeHelper;
        if (LevelM.World.Levels[LevelM.World.SelectedLevel - 1].BestTime > t)
            LevelM.World.Levels[LevelM.World.SelectedLevel - 1].BestTime = t ;
    }
    /// <summary>
    /// whe the player choose an of possibles result
    /// </summary>
    public AnswerItemITC Selected
    {
        get
        {
            return _aitc;
        }
        set
        {
            _aitc = value;
            var level = LevelM.World.Levels[LevelM.World.SelectedLevel - 1];
            if (_aitc == null) return;
            if (Equals(_aitc.Value, LevelM.Board.Lines.First(l => l.IsIcognitLine).Result))
            {
                _soundManager.PlayOnAcert();
                if (level.TargetGoals.Init <= level.TargetGoals.Final + 1)
                {
                    level.TargetGoals.Init += 1;

                    GetBestIme();

                    _scoreManager.IncreaseStars(_levelGoalManager.Stars);
                    LevelM.LoadBoard();
                }
                else
                {
                    GetBestIme();
                    _scoreManager.IncreaseStars(_levelGoalManager.Stars);
                }
            }
            else if (LevelM.World.GoldHarts > 0)
            {
                LevelM.StopWatch.Stoped = true;
                _soundManager.PlayOnError();
               // LevelM.OverDrawPanel.SetActive(true);
                //LevelM.OverdrawObject.Show(0);
                 OnWrongAnswer();
            }
            else
            {
                LevelM.StopWatch.Stoped = true; //How the lose event or panel                }
                _soundManager.PlayOnError();
                LevelM.OverDrawPanel.SetActive(true);
                LevelM.OverdrawObject.Show(0);
            }
        }
        
        
    }

    private void OnWrongAnswer()
    {
         LevelM.World.GoldHarts -= 1;
        _gameData.SaveData.GoldHarts = LevelM.World.GoldHarts;
         LevelM.LoadBoard();
        //_soundManager.PlayOnAcert();
    }

    // Update is called once per frame
}
