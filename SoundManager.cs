using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> soundsGame;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            foreach(AudioSource sound in soundsGame)
            {
                sound.Stop();
            }

            soundsGame[0].Play();
        }
        else if (SceneManager.GetActiveScene().name.Equals("Gameplay"))
        {
            foreach (AudioSource sound in soundsGame)
            {
                sound.Stop();
            }

            soundsGame[1].Play();
        }

        if (PlayerManager.m_PlayerDead)
        {
            foreach (AudioSource sound in soundsGame)
            {
                sound.Stop();
            }

            soundsGame[2].Play();
        }

        //Debug.Log("soundsGame[0]" + soundsGame[0].isPlaying);
        //Debug.Log("soundsGame[1]" + soundsGame[1].isPlaying);
        //Debug.Log("soundsGame[2]" + soundsGame[2].isPlaying);
    }
}
