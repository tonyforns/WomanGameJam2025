using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioList", menuName = "Audio/Audio List")]
public class AudioListSO : ScriptableObject
{
    public List<AudioDef> audioDefs;
}

[Serializable]
public class AudioDef
{
    public enum ClipName
    {
        Music,
        Ambient,
        SFX,
        Voice
    }

    public ClipName clipName;
    public AudioClip audioClip;
}