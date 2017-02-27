using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource startScene;
    public AudioSource GameScene;

    public static SoundManager soundManager;

    void Awake()
    {
        if(!soundManager)
        {
            soundManager = this;
            DontDestroyOnLoad(soundManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartMusic();
    }

    public void StartMusic()
    {
        GameScene.Stop();
        startScene.Play();
    }

    public void GameSceneMusic()
    {
        startScene.Stop();
        GameScene.Play();
    }
}
