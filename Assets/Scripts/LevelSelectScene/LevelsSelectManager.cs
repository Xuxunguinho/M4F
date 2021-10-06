using UnityEngine;

public class LevelsSelectManager : MonoBehaviour {

    [Header("WORLD GAME")]
    public World World;
    [Header("BUTTON STATUS")]
    public Sprite LockedSprite;
    public Sprite UnLockedSprite;
    [Header("STARS STATUS")]
    public Sprite ActiveStar;
    public Sprite InactiveSprite;
    [Header("LEVELS")]
    public LevelButtonManager[] Levels;

    // Use this for initialization
   public  GameDataManager GameData;
    void Start () {
        GameData = FindObjectOfType<GameDataManager>();
        LoadData();
    }
    private void LoadData()
    {
        //if (gameData != null)
        {
            World.ScoreOfStars = GameData.SaveData.ScoreOfStarsInGame;
            World.GoldHarts = GameData.SaveData.GoldHarts;
            World.Tips = GameData.SaveData.Tips;


            for (var i = 0;i< Levels.Length;i++)
            {
                 // seting the text in the button level
                 Levels[i].Level = i + 1;
                 // geting data to load

                Levels[i].IsLocked = this.GameData.SaveData.IsLocked[i];
                Levels[i].Stars = GameData.SaveData.Stars[i];

                // obtendo dados  e preechendo os Leveles<ScriptableObjects>
                 if (GameData.SaveData.CurrentTarget[i] != 0)
                      World.Levels[i].TargetGoals.Init = 0;              
             
                 World.Levels[i].BestTime = GameData.SaveData.BestTime[i];
                 World.Levels[i].Stars = GameData.SaveData.Stars[i];
                 World.Levels[i].Score = GameData.SaveData.ScoreOfStarsInLevel[i];
                 World.Levels[i].IsLocked = GameData.SaveData.IsLocked[i];
                // decide how many stars is active             
               
                 Levels[i].ScoreOfStars = GameData.SaveData.ScoreOfStarsInLevel[i];
                 Levels[i].BestTimeGamed = GameData.SaveData.BestTime[i];
            }
            //decide if level is unlocked or locked
          
        }
    }
    public void PlayAgainLevel()
    {


    }
    public void BackToHomeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
    }
    // Update is called once per frame
    void Update () {
        LoadData();
    }
}
