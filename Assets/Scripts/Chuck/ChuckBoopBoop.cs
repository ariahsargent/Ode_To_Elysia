using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckBoopBoop : MonoBehaviour
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

            Impulse imp => ResonZ filt => NRev rev => dac;
            0.04 => rev.mix;
            200.0 => filt.Q => filt.gain;
            1.0 => dac.gain;

            .5::second => dur T;

            while (1) {
                Std.mtof(Math.random2(40,65)) => filt.freq;
                1.0 => imp.next;
                //100::ms => now;
                T - (now % T) => now;
                //.25::T => now;
            }

        ");
    }
}
