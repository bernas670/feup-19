/*
*   This script was made following a tutorial video by Brackeys
*   "Introduction to AUDIO in Unity", Brackeys, 31/05/2017
*   https://www.youtube.com/watch?v=6OT43pvUyfY
*/
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
