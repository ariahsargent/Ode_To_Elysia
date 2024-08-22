SndBuf stereo => dac;

//setting random seed number
Std.srand(203);

//importing audio file
me.dir() + "audio/stereo_fx_02.wav" => stereo.read;
stereo.samples() => stereo.pos;

//setting tempo
.5::second => dur T;

//write granular function
fun void  granularize( int steps )
{
    stereo.samples() / steps => int grain;
    //the size (in samples) of each grain
    //<<< grain >>>;
    .2 => stereo.gain;
    //slowed down track to sound deeper
    .6 => stereo.rate;
    //randomlly set grain position
    Math.random2(0, stereo.samples()-grain) => stereo.pos;
    //how long each sample plays
    T*.5 => now;
}

//main program
while(true)
{
    //audio split into 20 parts
    granularize(20);   
}