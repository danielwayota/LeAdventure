using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicList;

    private AudioSource source;

    private void Start()
    {
        this.source = GetComponent<AudioSource>();
    }

    public void PlayRandomMusic()
    {
        int index = Random.Range(0, this.musicList.Length);

        if (this.source.isPlaying)
        {
            this.source.Stop();
        }

        this.source.clip = this.musicList[index];

        this.source.Play();
    }
}
