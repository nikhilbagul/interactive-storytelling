using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class Gameplay_audioManager : MonoBehaviour
{
    public AudioMixerSnapshot PreInputStageAudio;
    public AudioSource PreInputStageAudio_clip;

    void OnEnable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall += ContentUnit_audio_snapshotSwitcher_PreInput;
        SelectionMechanism.PostChoiceInputEventCall += ContentUnit_audio_snapshotSwitcher_PostInput;
    }


    void OnDisable()
    {
        InteractableChapterSelectBox.loadChapterContentsCall -= ContentUnit_audio_snapshotSwitcher_PreInput;
        SelectionMechanism.PostChoiceInputEventCall -= ContentUnit_audio_snapshotSwitcher_PostInput;
    }

    void ContentUnit_audio_snapshotSwitcher_PreInput()
    {
        if(!PreInputStageAudio_clip.isPlaying)
        {
            PreInputStageAudio_clip.Play();
            PreInputStageAudio.TransitionTo(2.0f);
        }
    }

    void ContentUnit_audio_snapshotSwitcher_PostInput()
    {

    }



}
