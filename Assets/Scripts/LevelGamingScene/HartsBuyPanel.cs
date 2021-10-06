using UnityEngine;
using UnityEngine.UI;

public class HartsBuyPanel : MonoBehaviour {

    private bool _istobuy=false;
    public Text Message;
    public Text HartText;
    private GameDataManager _gameData;
    public LevelInterfaceManager LevelM;
    private SoundManager _soundManager;
    public StopWatch TimerLeft;
    public bool IsToBuy { get { return _istobuy; }set { _istobuy = value;
            if (_istobuy)
				Message.text = "Assista um Vídeo e obtém uma vida";
            else
                Message.text = "Clique para continuar";
        } }
	void Start () {

        _soundManager = FindObjectOfType<SoundManager>();     
       
        _gameData = FindObjectOfType<GameDataManager>();
      
    }
    private void OnEnable()
    {
        if (LevelM.World.GoldHarts > 0)
        {
            IsToBuy = false;
        }
        else
        {
            IsToBuy = true;
            TimerLeft.Time = 20;
        }
    }
    public void HartButtonClick()
    {
       if(this.IsToBuy)
        {
            
        }
        else
        {
            LevelM.World.GoldHarts -= 1;
            _gameData.SaveData.GoldHarts = LevelM.World.GoldHarts;    
            LevelM.OverDrawPanel.SetActive(false);
            LevelM.LoadBoard();
            _soundManager.PlayOnAcert();
        }
    }
    // Update is called once per frame
    void Update () {

        if (IsToBuy)
        {
            if(TimerLeft.Time  == 0){
                LevelM.OverdrawObject.Show(1);
                IsToBuy = false;
            }
        }
        else
        {
            HartText.text = "" + LevelM.World.GoldHarts;
        }
    }
}
