using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {
        GreatPyramidOfGizza = 0b_0000_0000, 
        HangingGardensOfBabylon = 0b_0000_0001,
        StatueOfZeusAtOlympia = 0b_0000_0010,
        TemplateOfArtemisAtEphesus = 0b_0000_0011,
        MausoleumAtHalicarnassus = 0b_0000_0100,
        ColossusOfRhodes = 0b_0000_0101,
        LighthouseOfAlexandria = 0b_0000_0110
    }
}
