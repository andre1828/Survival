using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

	public AudioClip[] AudioClips = new AudioClip[0]; //Array of audioclips

	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource> ().clip = AudioClips [Random.Range (0, AudioClips.Length)]; //Picks a random music from the array of audioclips
		GetComponent<AudioSource> ().Play (); //Plays the randomly selected music

	}
	
	// Update is called once per frame
	void Update () 
	{


		AutoChangeMusic ();
	}
	
	void AutoChangeMusic()
	{
		if (!GetComponent<AudioSource> ().isPlaying) //if there  music playing 
		{ 
			GetComponent<AudioSource> ().clip = AudioClips [Random.Range (0, AudioClips.Length)]; //Picks a random music from the array of audioclips
			GetComponent<AudioSource> ().Play (); //Plays the randomly selected music
		} 
	}

}
