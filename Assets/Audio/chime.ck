SndBuf hihat => dac;

me.dir() + "audio/chime_01.wav" => hihat.read;

hihat.samples() => hihat.pos;

.5::second => dur T;

0 => float i;

while (1)
{
    if(i < 3)
    {
        T - (now % T) => now;
        
        i + 1 => i;
        //<<< i >>>;
    } else {
        0 => i;
        
        0 => hihat.pos;
        .1 => hihat.gain;
        .5 => hihat.rate;
        T - (now % T) => now;
        
        //<<< i >>>;
        
    }
   
}
