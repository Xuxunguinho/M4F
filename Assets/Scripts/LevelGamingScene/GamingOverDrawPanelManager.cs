using UnityEngine;

public class GamingOverDrawPanelManager : MonoBehaviour {

    // Use this for initialization

    //public GameObject MainPanelOverDraw;
    public GameObject[] Panels;
   
	void Start () {
        this.gameObject.SetActive(true);
	}
    private void ResetPanels()
    {  
        for (var i = 0; i < Panels.Length; i++) {
         
            Panels[i].SetActive(false);
        
        }
         
    }
    /// <summary>
    /// Event to show the especific panel
    /// </summary>
    /// <param name="index"></param>
    public bool Show(int index)
    {
        try
        {
            ResetPanels();
            Panels[index].SetActive(true);
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
