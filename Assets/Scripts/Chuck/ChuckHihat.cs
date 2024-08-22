using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckHihat : MonoBehaviour
{
    // Start is called before the first frame update
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
           
              // patch
                BlowBotl bottle => dac;

                .5::second => dur T;       //time **

                //Math random seed number
                Std.srand(200);

                // scale
                //[0, 2, 4, 7, 8, 11] @=> int scale[];
                [ 52, 59, 53, 50, 49 ] @=> int scale[];

                // infinite time loop
                while (true)
                {
                    for (0 => int i; i < 3; i++)
                    {
                        Math.random2f(0, 10) => float noisegain;
                        Math.random2f(20, 40) => float vibratofreq;
                        Math.random2f(0, 10) => float vibratogain;
                        Math.random2f(95, 120) => float volume;

                        //40 => float noisegain;
                        //10 => float vibratofreq;
                        //45 => float vibratogain;
                        //89 => float volume;

                        // noise gain
                        bottle.controlChange(4, noisegain);
                        // vibrato freq
                        bottle.controlChange(11, vibratofreq);
                        // vibrato gain
                        bottle.controlChange(1, vibratogain);
                        // volume
                        bottle.controlChange(128, volume);

                        // set freq
                        scale[i] => Std.mtof => bottle.freq;

                        // go
                        .4 => bottle.noteOn;

                        T - (now % T) => now;   //**
                    }
                    T - (now % T) => now;   //**
                }

        ");
    }

}
