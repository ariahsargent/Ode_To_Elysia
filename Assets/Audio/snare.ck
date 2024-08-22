SndBuf mySound => Pan2 Peter => dac;

string kick_samples[6];

me.dir() + "audio/kick_01.wav" => kick_samples[0];
me.dir() + "audio/kick_02.wav" => kick_samples[1];
me.dir() + "audio/kick_03.wav" => kick_samples[2];
me.dir() + "audio/kick_04.wav" => kick_samples[3];
me.dir() + "audio/kick_05.wav" => kick_samples[4];
me.dir() + "audio/kick_06.wav" => kick_samples[5];

me.dir() => string path;

"audio/kick_01.wav" => string filename;
path + filename => filename;

filename => mySound.read;

mySound.samples() => int mySamples;

0 => mySound.pos;
.6 => mySound.gain;
1 => mySound.rate;
.5::second => now;

for ( 1 => float i; i < 10; i + .25 => i )
{
    0 => mySound.pos;
    .6 => mySound.gain;
    i => mySound.rate;
    
    
    .3::second => now;
    <<< i >>>; 
}