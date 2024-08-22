using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckVoices : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ChuckSubInstance>().RunCode(@"

            // patch
            Bowed bow => dac;

            //setting random seed number
            Std.srand(100);

            // scale
            [ 2, 9, 3, 0 ] @=> int scale[];

            .5::second => dur T;

            // infinite time loop
            while( true )
            {
                // set
                .3 => bow.bowPressure;
                .9 => bow.bowPosition;
                2 => bow.vibratoFreq;
                1 => bow.vibratoGain;
                0.8 => bow.volume;

                // set freq
                scale[Math.random2(0,scale.size()-1)] + 37 => Std.mtof => bow.freq;
                // go
                .4 => bow.noteOn;

                // advance time
                T*2 => now;
            }

            

        ");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
