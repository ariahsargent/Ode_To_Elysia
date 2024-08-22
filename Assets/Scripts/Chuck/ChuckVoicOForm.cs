using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckVoicOForm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ChuckSubInstance>().RunCode(@"

            // music for replicants

            // patch
            VoicForm voc=> JCRev r => Echo a => Echo b => Echo c => dac;

            //inputted **
            .5::second => dur T;

            //Math random seed number
            Std.srand(100);

            // settings
            220.0 => voc.freq;
            0.95 => voc.gain;
            .8 => r.gain;
            .2 => r.mix;
            1000::ms => a.max => b.max => c.max;
            750::ms => a.delay => b.delay => c.delay;
            .50 => a.mix => b.mix => c.mix;

            // shred to modulate the mix
            fun void vecho_Shred( )
            {
                0.0 => float decider;
                0.0 => float mix;
                0.0 => float old;
                0.0 => float inc;
                0 => int n;

                // time loop
                while( true )
                {
                    Math.random2f(0.0,1.0) => decider;
                    if( decider < .3 ) 0.0 => mix;
                    else if( decider < .6 ) .08 => mix;
                    else if( decider < .8 ) .5 => mix;
                    else .15 => mix;

                    // find the increment
                    (mix-old)/1000.0 => inc;
                    1000 => n;
                    while( n-- )
                    {
                        old + inc => old;
                        if( old < 0 ) 0 => old;
                        old => a.mix => b.mix => c.mix;
                        1::ms => now;
                    }
                    mix => old;
                    Math.random2(2,6)::second => now;
                }
            } 

            // let echo shred go
            spork ~ vecho_Shred();
            0.1 => voc.loudness;
            0.01 => voc.vibratoGain;

            // scale
            //[ 2, 4, 7, 9, 11 ] @=> int scale[]; //**
            [ 52, 59, 53, 50 ] @=> int scale[];

            // our main time loop
            while( true )
            {
                2 * Math.random2( 0,2 ) => int bphon;
                bphon => voc.phonemeNum;
                Math.random2f( 0.6, 0.8 ) => voc.noteOn;

                    0 => int i;
                    4 * Math.random2(1, 4) => int pick;
                    0 => int pick_dir;
                    0.0 => float pluck;

                    for (; i < pick; i++)
                    {
                        bphon + 1 * pick_dir => voc.phonemeNum;
                        Math.random2f(.4, .6) + i * .035 => pluck;
                        pluck + 0.0 * pick_dir => voc.noteOn;
                        !pick_dir => pick_dir;
                        T - (now % T) => now;
                    }

                    for (0 => int i; i < 3; i++)
                    {
                        scale[i] => int freq;
                        Std.mtof((25 + Math.random2(0, 2) * 12 + freq)) => voc.freq;
                        T - (now % T) => now;
                    }
                }
        ");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
