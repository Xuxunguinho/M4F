using System;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable once CheckNamespace
public class StopWatch : MonoBehaviour {

    private TimeSpan _modelo;
    private string _duracao, _hora = "00:00:00";
    private string _h =  "00:00:00";
    public  DateTime Dt;
    public Text TimeText;
    private int _time;

    public bool Stoped { get; set; }

    [SerializeField]


    public int BestTimeHelper
    {
        get
        {
            this.Stoped = true;
            var c = (Dt.Minute * 60) + Dt.Second;
            return c;
        }
    }

    public int Time
    {
        get { return _time; }
        set
        {
            _time = value;
            try
            {
                if (_time >= 60)
                {
                    var op = _time / 60;
                    var rst = _time % 60;
                    _h = string.Format("00:0{0}:0{1}", op, rst);
                }
                else
                {
                    _h = string.Format("00:00:0{0}", _time);
                }


                var tm = TimeSpan.Parse(_h);
                _duracao = DateTime.Now.TimeOfDay.Add(tm).ToString();
                this.Stoped = false;
            }
            catch
            {
            }
        }
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Stoped) return;


        try
        {
            //hora.Substring(0, 5);
            _modelo = TimeSpan.Parse(_duracao);
            var tempoSaida = _modelo.Subtract(DateTime.Now.TimeOfDay).ToString();


            Dt = DateTime.Parse(tempoSaida);

            if (Dt.Hour == 0 & Dt.Minute == 0 & Dt.Second == 0)
            {
                _time = 0;
            }
            else
            {
            }
            _hora = string.Format("{0}:{1}", Dt.Minute, Dt.Second);
            TimeText.text = _hora;
        }
        catch
        {
            // ignored
        }
    }
}
