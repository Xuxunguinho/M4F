using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource Background;
    public AudioSource AcertSound;
    public AudioSource ErrorSound;
    public AudioSource OnClick;
    public void PlayOnAcert()
    {
        if (AcertSound != null)
            AcertSound.Play();
    }
    public void PlayOnError()
    {
        if (ErrorSound != null)
            ErrorSound.Play();
    }
    public void PlayOnClick()
    {
        if (OnClick != null)
            OnClick.Play();
    }
}
