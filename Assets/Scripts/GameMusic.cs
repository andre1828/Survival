using UnityEngine;
using System.Collections;

public class GameMusic : MonoBehaviour {

	public AudioClip[] AudioClips = new AudioClip[0]; //Array of audioclips
	private int NextClipID;
	private int ClipID;
	// Use this for initialization
	void Start () 
	{
		GetComponent<AudioSource> ().clip = AudioClips [Random.Range (0, AudioClips.Length)]; //Picks a random music from the array of audioclips
		GetComponent<AudioSource> ().Play (); //Plays the randomly selected music
	    ClipID = GetComponent<AudioSource> ().GetInstanceID(); //Stores the played Clip

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
			NextClipID = GetComponent<AudioSource> ().clip.GetInstanceID (); //Stores the new clip ID

				while (NextClipID == ClipID) //While the chosen next clip is the same as the last played
				{
					GetComponent<AudioSource> ().clip = AudioClips [Random.Range (0, AudioClips.Length)]; //Picks a random music from the array of audioclips
					NextClipID = GetComponent<AudioSource> ().clip.GetInstanceID (); //Stores the new clip ID
				}
			ClipID = NextClipID; //Recently chosen clip id is stored in ClipID for next comparison
			GetComponent<AudioSource> ().Play (); //Plays the randomly selected music
		}
	}

}
