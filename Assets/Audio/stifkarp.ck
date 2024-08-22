// STK StifKarp

// patch
//EDITED FOR GAME SOUNDS
StifKarp m => NRev r => dac;
.1 => r.gain;
.02 => r.mix;

//setting random seed number
Std.srand(100);

// our notes
[ 62, 69, 63, 60 ] @=> int notes[];


//tempo of song
.5::second => dur T;


// infinite time-loop
while( true )
{
    for(0 => int i; i < 3; i++)
    {
        0.5 => m.pickupPosition;
        0.5 => m.sustain;
        0.2 => m.stretch;
        
        Std.mtof( notes[i] ) => m.freq;
     
        T + (now % T) => now;
        .6 => m.pluck; 
    }
    //rest before playing again
    //gives a bit of an echo to last note ... i like it
    T - ( now % T ) => now;   
    
}
