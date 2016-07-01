using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;
using System.Collections;

public class Gameplay_audioManager : MonoBehaviour
{
    public AudioMixerSnapshot MasterMute, Contentunit_audioSnapshot;
    public AudioMixer GameplayAudioMixer;
    public AudioSource Chapter_contentaudio;

    void OnEnable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall += LoadChapterAudio;
        SelectionMechanism.PostChoiceInputEventCall += FadeoutAudio;
    }


    void OnDisable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall -= LoadChapterAudio;
        SelectionMechanism.PostChoiceInputEventCall -= FadeoutAudio;
    }   

    void LoadChapterAudio()
    {
        if (!Chapter_contentaudio.isPlaying)
        {
            Chapter_contentaudio.Play();
            Contentunit_audioSnapshot.TransitionTo(5.0f);
            //GameplayAudioMixer.DOSetFloat("MasterVol", 0.0f, 1.0f);
        }
             
    }

    void ContentUnit_audio_snapshotSwitcher_PostInput()
    {
        
        Chapter_contentaudio.Play();
        //Contentunit_audioSnapshot.TransitionTo(3.0f);
        GameplayAudioMixer.DOSetFloat("MasterVol", 0.0f, 3.0f);
    }

    void FadeoutAudio()
    {
        if(DisplayInterface.changeChapterAudio)
        {
            print("change audio clip !");
            GameplayAudioMixer.DOSetFloat("MasterVol", -80.0f, 3.0f).OnComplete(ContentUnit_audio_snapshotSwitcher_PostInput);
            //Chapter_contentaudio.PlayScheduled(AudioSettings.dspTime + 2);
        }
    }




}
