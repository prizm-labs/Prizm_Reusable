using UnityEngine;
using System;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{

	/** Manages all sound effects... 
   	* Just pass the audio clip to this stattic method group
	* SoundManager.Instance.PlayAudio(SoundManager.Instance.explosionClip); 
	**/
	
	public AudioSource efxSource1; 
	public AudioSource efxSource2;
	public AudioSource efxSource3;
	public AudioSource efxSource4;
	public AudioSource ambienceSource_01;
	public AudioSource ambienceSource_02;

	public AudioSource musicSource_01;
	public AudioSource musicSource_02;
	public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

	public AudioClip popSound;
	public AudioClip ting;



	public AudioClip nuh_uh;




	// Static singleton property
	public static SoundManager Instance { get; private set; }
	
	void Awake()
	{
		// First we check if there are any other instances conflicting
		if(Instance != null && Instance != this)
		{
			// If that is the case, we destroy other instances
			Destroy(gameObject);
		}
		
		// Here we save our singleton instance
		Instance = this;
		
		// Furthermore we make sure that we don't destroy between scenes (this is optional)
		///////DontDestroyOnLoad(gameObject);
	}


	public AudioSource GetMeAn_FX_AudioSourceNotInUse(){
		if (!efxSource1.isPlaying)
			return efxSource1;
		else if (!efxSource2.isPlaying)
			return efxSource2;
		else if (!efxSource3.isPlaying)
			return efxSource3;
		else
			return efxSource4;
		

	}

	public void PlayRandomFromList(List<AudioClip> listToChooseFrom) {
		int clipIndex = UnityEngine.Random.Range (0, listToChooseFrom.Count);
		AudioSource source = GetMeAn_FX_AudioSourceNotInUse ();

		source.clip = listToChooseFrom [clipIndex];
		source.Play ();
	}
	
	// Instance method, this method can be accesed through the singleton instance
	public void PlayAudio(AudioClip clip, Vector3 position, AudioSource source)
	{
		if (source.loop) {		//might be the cause of the robber sound trigger mulitple times
			Debug.LogError ("we were looping");
			source.loop = false;
		}
		if (source.isPlaying) {
			/////////Debug.LogError ("source was playing, we interrupted a sound");
			source.Stop ();
		}
		source.clip = clip;
		source.Play();
		//source.Play
		//source.Pl
	}

	public void NewMusicTrack(AudioClip clip, Vector3 pos, AudioSource source){
		source.clip = clip;
		source.Play ();
	}

	public void PlayAmbientSound(AudioClip clip, Vector3 pos, AudioSource source){
		source.clip = clip;
		source.Play ();
	}

}

