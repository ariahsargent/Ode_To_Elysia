TriOsc s => Pan2 p => dac;
//new class called Pan2. create instance of it called p

//setting random seed number
Std.srand(200);

1.0 => p.pan;   //pan values between -1 (left) and 1 (right)
.1 => p.gain;

//setting tempo
.5::second => dur T;

1.0 => float panPosition;

while ( panPosition > -1.0 )
{
    panPosition => p.pan;       //set the pan
    <<< panPosition >>>;
    panPosition - 0.1 => panPosition;
    Math.random2(50,100) => s.freq;
    T*8 => now;
}