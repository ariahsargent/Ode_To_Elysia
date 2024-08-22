using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckOrgan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //run Chuck code with Chuck Sub Instance component
        GetComponent<ChuckSubInstance>().RunCode(@"
            
            //3 oscillators for chord
            SinOsc chord[3];

            for (0 => int i; i < chord.cap(); i++)
            {
                //connects them to dac
                chord[i] => dac;
                //sets gains so no overload
                0.08/chord.cap() => chord[i].gain;
            }

            .5::second => dur T;

            T*4 => dur tempo;

            while(true)
            {

                playChord(Std.rand2(37,40), tempo);
            }

            fun void playChord(int root, dur howLong)
            {
                //root of chord
                Std.mtof(root) => chord[0].freq;
                //fifth of chord
                Std.mtof(root + 7) => chord[2].freq;
                //sets quality of major or minor
               
                    //major chord
                    Std.mtof(root + 4) => chord[1].freq;
                
                
                howLong => now;
            }
            

        ");
    }

}
