using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource source;
    public List<AudioClip> clips;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    public void playClip(int index)
    {
        source.clip = clips[index];
        source.Play();
    }
}
