/// Developed by Julio Jose de Andrade Reis
/// 2018 All rigth reserved 
/// This game was created for my knowlodge test.
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    
    private LevelInterfaceManager _levelManager;
    private LevelGoalsManager _levelGoals;

	void Start ()
    {
        _levelGoals = FindObjectOfType<LevelGoalsManager>();
        _levelManager = FindObjectOfType<LevelInterfaceManager>();
	}
    public void IncreaseStars(int stars)
    {   
        /// scoreof stars in level ...Form LevelGoals and set here;
        _levelGoals.ScoreOfStarsInLevel += stars;
        ///
        _levelManager.World.ScoreOfStars += stars;
    }
    public void DecreaseStars(int stars)
    {
        _levelManager.World.ScoreOfStars -= stars;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
