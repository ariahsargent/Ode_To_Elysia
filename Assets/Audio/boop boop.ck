Impulse imp => ResonZ filt => NRev rev => dac;
0.04 => rev.mix;
100.0 => filt.Q => filt.gain;
1 => dac.gain;

.5::second => dur T;

while (1) {
    Std.mtof(Math.random2(40,65)) => filt.freq;
    1.0 => imp.next;
    //100::ms => now;
    T - (now % T) => now;
    //.25::T => now;
}