using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour {

    bool _strlocked;
    public bool IsLocked { get { return _strlocked; } set {

            _strlocked = value;
            if (_strlocked)
            {
                LockedImage.gameObject.SetActive(true);
                TheButton.enabled = false;
                LevelText.enabled = false;
                StarClassification.ActivateStars(0);
            }
            else
            {
                LockedImage.gameObject.SetActive(false);
                TheButton.enabled = true;                
            }
        }
    }
    [Header("Button & Propertys")]
    public Image LockedImage;
    
    public Button TheButton;

    int _stars=0;
    public int Stars { get { return _stars; } set { _stars = value;
            StarClassification.ActivateStars(_stars);
        } }
  
   
    [Header("Level Data")]
    public int ScoreOfStars;
    public int BestTimeGamed;

    [Header("Hubs")]
    public World WorldGame;
    public LevelsSelectManager LselectManager;
    public GameObject ConfirmPanel;
    public ConfirmPanelManager ConfirmPanelDataTransfer;
    public  StarsClassificatorManager StarClassification;
    [Header("Level UI")]    
    public Text LevelText;
    [Header("Level ID")]
    public int Level;

    // Use this for initialization
    void Start ()
    {                
    }
    private void Awake()
    {
        LoadData();
    }
    void LoadData()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    private bool ResetStars() {
       
        return true;
    }


   
    /// <summary>
    /// 
    /// </summary>
    private void ShowLevel() {
        LevelText.text = "" + Level;
    }
    /// <summary>
    ///  
    /// </summary>
  
    public void OnClick()
    {
        //Debug.Log("FuiClicado");
        ConfirmPanelDataTransfer.DataTransport(Stars, ScoreOfStars, (3 * WorldGame.Levels[Level - 1].TargetGoals.Final), BestTimeGamed);
        WorldGame.SelectedLevel = this.Level;
        ConfirmPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
        ShowLevel();        
    }
}
