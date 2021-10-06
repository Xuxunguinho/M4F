using UnityEngine;
using UnityEngine.UI;


// ReSharper disable once CheckNamespace
  public  class OperatorITC :MonoBehaviour
    {
        /// <summary>
        /// Fields to fill  de Propertys
        /// </summary>
        private bool _visible = true;
        private char _oper;
        /// <summary>
        ///  this to use to locate this in Array of#
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// this is de oper 
        /// </summary>
        public char Value { get { return _oper; }
        set
            {
                _oper = value;
                this.GetComponent<Text>().text = value.ToString();
              
            }
        }
        /// <summary>
        /// Set Stati visible or not;
        /// </summary>
        public bool Visible { get { return _visible; }  set
            {
                _visible = value;
                this.gameObject.transform.Find("op").gameObject.SetActive(_visible);
            }
        }

    }

