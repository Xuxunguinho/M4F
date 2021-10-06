using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class LevelInterfaceManager : MonoBehaviour {

    [Header("LEVEL OPTIONS")]
    public StopWatch StopWatch;
    public World World;
    public int Level;     
    [Header("INTERFACE INTERATORES")]
    public BoardITC Board;   
    public BoardAnswerITC Answers;
    public Text TargetText;
//    public Text HartsText;
    //public Text Tips;
    public Text ScoreOfStarsText;
    public Text StopWatchText;
//    public Text BestTimeText;
    
  

    [Header("OverDrawPanel")]
    public GameObject OverDrawPanel;
    public GamingOverDrawPanelManager OverdrawObject;    

    public LevelGoalsManager LevelGoals;
  
   
    public int Id { get; set; }
    public string LevelName { get; set; }
    public bool Completed { get; set; }
    public int Stars { get; set; }
    public bool  Locked {get;set;}

    private void Update()
    {
        
    }
    private void Start()
    {
       
        StopWatch = FindObjectOfType<StopWatch>();
    }

    /// <summary>
    /// when de level is completed
    /// </summary>
    public void  Complete()
    {
        this.Completed = true;
    }
    /// <summary>
    /// when de level is completed
    /// </summary>
    /// <param name="stars">Quanty of stars</param>
    public void Complete(int stars)
    {
        Complete();
        this.Stars = stars;
    }
    public void Score(int score) {

    }

    public void Lock() {
        Locked = true;
    }
    public void Unlock() {
        Locked = false;
    }
    /// <summary>
    /// Load board and your propertys
    /// </summary>
    public virtual void LoadBoard() { }
}
