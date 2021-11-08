using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour
{
    public GameObject musicPlay;
    void Awake()
    {
        //When the scene loads it checks if there is an object called "MUSIC".
        musicPlay = GameObject.Find("Audio");
        if (musicPlay == null)
        {
            //If this object does not exist then it does the following:
            //1. Sets the object this script is attached to as the music player
            musicPlay = this.gameObject;
            //2. Renames THIS object to "MUSIC" for next time
            musicPlay.name = "Audio";
            //3. Tells THIS object not to die when changing scenes.
            DontDestroyOnLoad(musicPlay);
        }
        else
        {
            if (this.gameObject.name != "Audio")
            {
                //If there WAS an object in the scene called "MUSIC" (because we have come back to
                //the scene where the music was started) then it just tells this object to 
                //destroy itself if this is not the original
                Destroy(this.gameObject);
            }
        }
    }
}
