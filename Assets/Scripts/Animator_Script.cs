
using UnityEngine;

public class Animator_Script : MonoBehaviour {

    [Range(0.25f, 5f)]
    public float ScaleSpeed=0.25f;
    public AnimationCurve Acurve;
    public GameObject ObjPlay;
    private float _step;
    public Transform Transform;
    private float _objScale ;
	// Use this for initialization
    // ReSharper disable once UnusedMember.Local
	void Start ()
	{
        Transform = ObjPlay.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _step += ScaleSpeed * Time.deltaTime;
        _objScale = Acurve.Evaluate(_step);
        Transform.localScale = new Vector2(_objScale, _objScale);
        if (_step >= 1) { _step = 0; }
	}
}
