using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundFXManager SharedInstance;
    Dictionary<AudioName, AudioSource> AudioDict;
    Dictionary<string, AudioName> AudioNameDict;



    AudioSource[] AudioLists;
    private void Awake()
    {
        SharedInstance = this;
        AudioNameDict = new Dictionary<string, AudioName>(){
            {"sfx_coin",AudioName.Coin},
            {"sfx_single",AudioName.BulletSingle},
            {"sfx_triple",AudioName.BulletTriple},
            {"sfx_fan",AudioName.BulletFan},
            {"sfx_shield",AudioName.Shield},
            {"sfx_enemy-explosion",AudioName.EnemyExplosion}
        };
    }
    void Start()
    {
        AudioDict = new Dictionary<AudioName, AudioSource>();

        AudioLists = gameObject.GetComponents<AudioSource>();
        foreach (AudioSource audio in AudioLists)
        {
            if (!audio) new MissingComponentException();
            AudioDict.Add(AudioNameDict[audio.clip.name], audio);
            Debug.Log("name" + audio.clip.name + AudioNameDict[audio.clip.name]);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayAudioName(AudioName audioName)
    {
        Debug.Log($"PLAYING {AudioDict[audioName].clip.name} ---{audioName}");
        AudioDict[audioName].Play();
    }

    public enum AudioName
    {
        Coin,
        BulletSingle,
        BulletFan,
        BulletTriple,
        EnemyExplosion,
        Shield
    }
}
