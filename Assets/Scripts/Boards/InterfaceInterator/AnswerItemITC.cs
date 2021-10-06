using UnityEngine;
using UnityEngine.UI;

public class AnswerItemITC : MonoBehaviour
{

     
    public BoardAnswerITC Owner;
    private double _vlue = 0;
    
    public double Value { get { return _vlue; } set { _vlue = value;
           this.gameObject.transform.Find("value").GetComponent<Text>().text = _vlue.ToString();
        }
    }
    private void Start()
    {
      
        if (this.gameObject.transform.Find("value").GetComponent<Text>().text != "") {
            Value = double.Parse(this.gameObject.transform.Find("value").GetComponent<Text>().text);
        } 
    }
    /// <summary>
    /// Quando o Item e  clicado 
    /// </summary>
    public void OnMyClick()
    {        
        Owner.Selected = this;
        
    }
}
