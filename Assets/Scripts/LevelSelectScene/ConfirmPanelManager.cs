using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class ConfirmPanelManager : MonoBehaviour {

    public string LevelToLoad;
    [Header("Classification")]
    public GameObject[] Stars;
    [Header("Fill UI")]
    public Text ScoreOfStarsCount;
    public Text BestTimeCount;

    public LevelsSelectManager LselectManager;
    private SoundManager _soundManager;
	// Use this for initialization 

	void Start ()
    {       
        //lselectManager = FindObjectOfType<LevelsSelectManager>();
        this._soundManager = FindObjectOfType<SoundManager>();
	}

    /// <summary>
    /// Este metodo serve para preencher os dados deste painel... 
    /// </summary>
    /// <param name="stars">Numero de estralas que arecadou no nivel selecionado</param>
    /// <param name="scoreOfStars">score especifico feito neste mesmo nivel</param>
    /// <param name="totalOfScoreStars"></param>
    /// <param name="bestimeGamed">o melhor tempo de resposta </param>
    public void DataTransport(int stars , int scoreOfStars,int totalOfScoreStars,int bestimeGamed)
    {
        ScoreOfStarsCount.text =string.Format("{0}/{1}",scoreOfStars,totalOfScoreStars);
        BestTimeCount.text = string.Format("{0} S",bestimeGamed);
        ActivateStars(stars);
    }
    /// <summary>
    ///  poe as estrelas todas inativas
    /// </summary>
    private void ResetStars()
    {
        for (var i = 0; i < 3; i++)
        {
            Stars[i].GetComponent<SpriteRenderer>().sprite = LselectManager.InactiveSprite;
        }
    }
    /// <summary>
    /// modo para reativalcao das determinadas estrelas
    /// </summary>
    /// <param name="stars"></param>
    private  void ActivateStars(int stars)
    {
        ResetStars();
        for (var i = 0; i < stars; i++)
        {
            Stars[i].GetComponent<SpriteRenderer>().sprite = LselectManager.ActiveStar;
        }
    }
    /// <summary>
    /// Jogar o o nivel selecionado
    /// </summary>
    public void Play()
    {       
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);
    }
    /// <summary>
    /// Nao jogar o nivel selecionado
    /// </summary>
    public void Cancel()
    {
        _soundManager.PlayOnClick();        
        this.gameObject.SetActive(false);
        
    }
    /// <summary>
    /// Jogar novamente o mesmo nivel, quando este ja tivera sido jogado e claro
    /// </summary>
    public void PlayAgain() {


    }
	// Update is called once per frame
	void Update () {
		
	}
}
