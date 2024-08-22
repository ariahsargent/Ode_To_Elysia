using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckBass : MonoBehaviour
{
    //public ChuckSubInstance myChuck;    //refer to chucksubinstance

    
    void Start()
    {
        //var chuckInstance = GetComponent<ChuckSubInstance>();

        /*
        if (myChuck == null)
        {
            Debug.LogError("ChuckSubInstance is missing from this GameObject!");
            return;
        }
        */

        //run Chuck code with Chuck Sub Instance component
        GetComponent<ChuckSubInstance>().RunCode(@"
            SinOsc bass => dac;

            0.2 => bass.gain;
            50 => bass.freq;

            .5::second => dur T;

            0 => float i;

            while (1)
            {
                if(i < 1)
                {
                    0 => bass.gain;
                    T - (now % T) => now;
                    i + 1 => i;
                } else {
                    0.1 => bass.gain;
                    0 => i;
                    T - (now % T) => now;
                    0 => bass.gain;
                }
   
            }

        "); 
    }


}
