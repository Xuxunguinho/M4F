using UnityEngine;


// ReSharper disable once CheckNamespace
public class HomeScript : MonoBehaviour {

    public PanelAsForm OverDrawPanel;
    private SoundManager _soundManager;
	// Use this for initialization
	void Start () {
        _soundManager = FindObjectOfType<SoundManager>();
	}

    // Update is called once per frame
    public void BtnDetails_Clicked()
    {
       OverDrawPanel.gameObject.SetActive(true);
    }
    public void OverClose()
    {
        _soundManager.PlayOnClick();
        OverDrawPanel.gameObject.SetActive(false);
    }
    public void BtnPlay_Clicked()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");      
    }
    
	void Update () {
		
	}
}
