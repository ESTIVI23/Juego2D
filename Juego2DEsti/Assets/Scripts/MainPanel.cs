using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainPanel: MonoBehaviour
{
    [Header("options")]
    public Slider VolumeFX;
    public Slider VolumenMaster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    



    private void Awake()
    {
        VolumeFX.onValueChanged.AddListener(ChangevolumeFX);
        VolumenMaster.onValueChanged.AddListener(ChangevolumeMaster);
    }


    public void OpenPanel (GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);

        PlaySoundButton();
    }


    public void ChangevolumeMaster(float v)
    {
        mixer.SetFloat("volMaster", v);
    }
    public void ChangevolumeFX(float v)
    {
        mixer.SetFloat("volFX", v);
    }


    public void PlaySoundButton()
    {

        fxSource.PlayOneShot(clickSound);

    }
}



