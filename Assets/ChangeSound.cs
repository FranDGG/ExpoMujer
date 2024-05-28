using UnityEngine;
using UnityEngine.UI;

public class ChangeSound : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;

    public AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        soundOnImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            SetAudioSourcesMute(true);
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true; 
            SetAudioSourcesMute(false);
        }
    }

    void SetAudioSourcesMute(bool mute)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.mute = mute;
        }
    }
}
