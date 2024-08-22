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

    playChord(Std.rand2(37,40), "major", tempo);
}

fun void playChord(int root, string quality, dur howLong)
{
    //root of chord
    Std.mtof(root) => chord[0].freq;
    //fifht of chord
    Std.mtof(root+7) => chord[2].freq;
    //sets quality of major or minor
    if (quality == "major")
    {
        //major chord
        Std.mtof(root+4) => chord[1].freq;
    }
    else if (quality == "minor")
    {
        //minor chord
        Std.mtof(root+3) => chord[1].freq;
    }
    else
    {
        <<< "You must specify major or minor!!" >>>;
    }
    howLong => now;
}