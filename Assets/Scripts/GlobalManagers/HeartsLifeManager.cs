using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.GlobalManagers
{
    public class HeartsLifeManager: MonoBehaviour 
    {
        public Image[] Hearts;  
        private int _starCount;
        private GameDataManager _gameData;
        public World World;
        public int HeartsCount { get { return _starCount; } }
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
                Hearts[i].gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stars"></param>
        public void ActivateStars(int stars)
        {
            _starCount = stars;
            ResetStars();
            for (var i = 0; i < stars; i++)
            {
                //if (Stars[i].IsActive() != true)
                //{       
              Hearts[i].gameObject.SetActive(true);
                  
                //}
              
            }
        }
        // Update is called once per frame
        void Update () {
		
          ActivateStars(World.GoldHarts);
        }
    }
}