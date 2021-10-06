using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[SuppressMessage("ReSharper", "CheckNamespace")]
public class PanelAsForm : MonoBehaviour {

    // Use this for initialization
    public GameObject OverDraw;

	void Start () {
        OverDraw.SetActive(true);
	}
    private void OnEnable()
    {
        OverDraw.SetActive(true);
    }
    private void OnDisable()
    {
        OverDraw.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
