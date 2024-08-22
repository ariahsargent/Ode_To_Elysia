using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckBowed : MonoBehaviour
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
            Bowed bow => dac;

            // scale
            [ 52, 59, 53, 50 ] @=> int scale[];

            .3 => bow.gain;

            .5::second => dur T;


            // infinite time-loop
            while( true )
            {
                for(0 => int i; i < 3; i++)
                {
                    // set
                    .3 => bow.bowPressure;
                    .9 => bow.bowPosition;
                    0.1 => bow.vibratoFreq;
                    0.3 => bow.vibratoGain;
                    0.8 => bow.volume;

                    // set freq
                    Std.mtof( scale[i] ) => bow.freq;
     
                    T + (now % T) => now;
                    // go
                    .3 => bow.noteOn;
                }
                //rest before playing again
                //gives a bit of an echo to last note ... i like it
                T - ( now % T ) => now;   
    
            }


        ");
    }

}
