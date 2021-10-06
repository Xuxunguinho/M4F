// Dveloped by : Julio Jose de Andrade Reis

using System;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class LineItemITC : MonoBehaviour
{
    /// <summary>
    ///  This is to set in de Interface design in Unity editor , cause it isn't propertys
    /// </summary>  
    private bool _isresult = false;
    private LineItemITC _otherItem;
    public Vector2 Location;
    private Vector2 _firstTouchPosition;
    private Vector2 _tempPosition;
    private Vector2 _finalTouchPosition;
    public float swipeAngle;
    public int column, row,targetX , targetY;
    private BoardITC _board;
    
    private double  _vl=0;
    private int _vzsr = 1, _expor=1;
    public BoardLineITC Owner;
   
    public int Index { get; set; }

    public Text ValueText;
    public Text VzsText;
    public Text ExpoenteText;
    public Text OperatorText;
    public Image MaskIView;

    // Use this for initialization
    private   void Start()
    {
        _board = FindObjectOfType<BoardITC>();
        targetX = (int) transform.position.x;
        targetY = (int) transform.position.y;
        row = targetX;
        column = targetY;
    }

    private void Update()
    {
        OperatorText.gameObject.SetActive(IsResult != true);
        targetX = column;
        targetY = row;
      /*  if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            _tempPosition = new  Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, _tempPosition, .4f);
        }
        else
        {
            _tempPosition = new  Vector2(targetX, transform.position.y);
            transform.position = _tempPosition;
                // _board.Lines[row].Algs[collumn, row] = this.gameObject;
        }*/
    }
    private void OnMouseDown()
    {
        _firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        _finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalulateAnge();
    }

    void CalulateAnge()
    {
        swipeAngle = Mathf.Atan2(_finalTouchPosition.y - _firstTouchPosition.y,
            _finalTouchPosition.x - _firstTouchPosition.x
        ) * 180 / Mathf.PI;
        
        Debug.Log(swipeAngle);
    }

    void MoveAlgs()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && column < _board.Lines[row].Algs.Length) 
        {
            //right swipe
            //_otherItem = _board.Lines[row].Algs[2,1];
        }else if (swipeAngle > 45 && swipeAngle <= 135 && row < 1)
        {
            //Up swipe
        }else if (swipeAngle > 135 || swipeAngle <= -135 && column > 0)
        {
            //Left swipe
        }
        else if (swipeAngle > -45 && swipeAngle >= 145 && row > 0)
        {
            //down swipe
            
        }

    }

    /// <summary>
    /// used to set or unset this an result
    /// </summary>
    public bool IsResult {
        get { return _isresult; }
        set
        {
            _isresult = value;

            if (_isresult)
            {
                ShowMask = false;
                this.ValueText.text = Owner.IsIcognitLine ? "?" : ""+ Value;
                OperatorText.gameObject.SetActive(false);
            }            
            else
            
            {
                ShowMask = true;
                OperatorText.gameObject.SetActive(true);
            }
        }
    }
    public int Exponent
    {
        get { return _expor; }
        set
        {
            _expor = 0;
            _expor = value;
          
            if (UseExpo)
            {
                this.ExpoenteText.text = value.ToString();
                this.ExpoenteText.gameObject.SetActive(true);

                if (Owner.AlgsExponentsType != Enums.ExpoType.ByValue) return;
             
            }
            else
            {
                this.ExpoenteText.text = string.Empty;
                this.ExpoenteText.gameObject.SetActive(true);

            }

        }
    }
    public int MultiplicationFactor
    {
        get { return _vzsr; }
        set
        {
            _vzsr = value;
            if (_vzsr > 1)
            {
                this.VzsText.text = value.ToString();
                this.VzsText.gameObject.SetActive(true);
            }
            else
            {
                this.VzsText.text = value.ToString();
                this.VzsText.gameObject.SetActive(false);
            }
        }
    }

    public void Reset()
    {
        UseExpo = false;
        MultiplicationFactor = 1;
        Exponent = 1;
        ShowMask = true;
        IsResult = false;
        Value = 0;
        this.gameObject.SetActive(false);
      
    }

    public bool UseExpo { get; set; }

    /// <summary>
    /// this is the value of this.
    /// </summary>     
    public double Value
    {
        get { return _vl; }
        set
        {
            _vl = value;
            this.ValueText.text =""+ _vl;
            if (!IsResult)
            {
                this.gameObject.SetActive((_vl != 0));
                OperatorText.gameObject.SetActive(true);
            }

            else
            {
                this.gameObject.SetActive(true);
                OperatorText.gameObject.SetActive(false);
            }

           
            
        }
    }
    
    /// <summary>
    ///  used to show or hide mask
    /// </summary>
     private bool _smask =true;


    public LineItemITC()
    {
        UseExpo = false;
    }

    public bool ShowMask {
        get { return _smask; }
        set
        {
            _smask = value;
            if (_smask)
            {
                this.MaskIView.gameObject.SetActive(true);
                this.ValueText.gameObject.SetActive(false);
            }
            else {
                this.ValueText.gameObject.SetActive(true);
                this.MaskIView.gameObject.SetActive(false);
            }
                
        }

    }
   
    /// <summary>
    /// this is to mask the Number behind ther
    /// </summary>
    public  Sprite Mask
    {       
        set
        {                        
            this.MaskIView.GetComponent<Image>().sprite = value;
            ShowMask = !IsResult;
          
        }
    }
   
}
