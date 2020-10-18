using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour
{
    public AudioSource source;

    public AudioClip[] clips = new AudioClip[0];
    private void Start()
	{
        playRandomSound();
	}
	public void playRandomSound()
	{
        AudioClip clip = clips[Random.Range(0,clips.Length)];
        StartCoroutine(Playsound(clip));
	}


    public IEnumerator Playsound(AudioClip clip)
	{
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length);
        Destroy(this.gameObject);
	}
}
