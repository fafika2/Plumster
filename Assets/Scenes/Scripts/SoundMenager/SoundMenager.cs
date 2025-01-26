using UnityEngine;

public class SoundMenager
{
public void PlaySound(AudioSource Audio, Vector2 MinMaxPitch, Vector2 MinMaxVolume)
    {
        Audio.pitch = Random.Range(MinMaxPitch.x, MinMaxPitch.y);
        Audio.volume = Random.Range(MinMaxVolume.x, MinMaxVolume.y);
        Audio.Play();
    }
}
