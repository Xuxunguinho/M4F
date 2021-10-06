
using UnityEngine;
using UnityEngine.UI;

public class StarsClassificatorManager : MonoBehaviour {

    public Image[] Stars;  
    private int _starCount;
    public int StarsCount { get { return _starCount; } }
	void Start () {
        ResetStars();
	}
    private void OnEnable()
    {
        ResetStars();
    }
    /// <summary>
    /// 
    /// </summary>
    private void ResetStars()
    {
        for (var i = 0; i < 3; i++)
        {
            Stars[i].gameObject.SetActive(false);
        }
    }
    public void ActivateStars(int stars)
    {
        _starCount = stars;
        ResetStars();
        for (var i = 0; i < stars; i++)
        {
            //if (Stars[i].IsActive() != true)
            //{       
                  Stars[i].gameObject.SetActive(true);
                  
            //}
              
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
