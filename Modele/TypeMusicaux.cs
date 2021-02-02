using System;
using System.Collections.Generic;
using System.Text;

namespace Modele
{ /// <summary>
/// TypeMusicaux permet de lister tous les types de musiques possibles
/// </summary>
    [Flags]
    [Serializable]
    public enum TypeMusicaux : byte
    {
        Rap = 1,      //      0001
        Pop = 2,      //      0010
        Rock = 4,     //      0100
        Electro = 8,  //      1000
        Jazz = 16,    // 0001 0000
        Variété = 32, // 0010 0000
        Classique = 64// 0100 0000
    }
}