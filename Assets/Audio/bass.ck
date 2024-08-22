SndBuf kick => dac;

me.dir() + "audio/kick_06.wav" => kick.read;

kick.samples() => kick.pos;

.5::second => dur T;

0 => float i;

while (1)
{
    if(i < 1)
    {
        0 => kick.pos;
        .2 => kick.gain;
        0.5 => kick.rate;
        T - (now % T) => now;
        i + 1 => i;
        //<<< i >>>;
    } else {
        0 => i;
        T - (now % T) => now;
        //<<< i >>>;
    }
   
}
