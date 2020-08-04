using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
	public AudioSource dieSource;
	public AudioSource meteoreSource;
	public AudioSource winSource;
	public AudioSource loseSource;
	public AudioSource bgSource;

	void Start()
    {
		var p = GameObject.Find("Player");
		if (p != null) {
			p.GetComponent<PlayerCollision>().dieSoundEvent.AddListener(PlayDieSound);
			p.GetComponent<PlayerCollision>().winEvent.AddListener(PlayWinSound);
			p.GetComponent<PlayerCollision>().loseEvent.AddListener(PlayLoseSound);
		}
	}

    void Update()
    {
        
    }

	public void PlayDieSound()
	{
		if (Config.isSound)
			dieSource.PlayOneShot(dieSource.clip, 0.7f);
	}

	public void PlayMeteorSound()
	{
		if (Config.isSound)
			meteoreSource.PlayOneShot(meteoreSource.clip, 0.7f);
	}

	public void PlayLoseSound()
	{
		//if (Config.isSound)
		//	loseSource.PlayOneShot(loseSource.clip, 0.7f);
	}

	public void PlayWinSound()
	{
		//if (Config.isSound)
		//	winSource.PlayOneShot(winSource.clip, 0.7f);
	}

	public void PlayMusic()
	{
		if (Config.isMusic) {
			bgSource.Play();
		} else {
			bgSource.Pause();
		}
	}
}
