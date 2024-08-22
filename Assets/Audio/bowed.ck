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
        0 => bow.vibratoGain;
        .8 => bow.volume;

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
