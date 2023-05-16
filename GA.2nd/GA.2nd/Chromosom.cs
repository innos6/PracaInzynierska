using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GA._2nd
{
    // tutaj mamy model danych wejściowych 

    public class Chromosom
    {
        public List<Zadanie>? Geny { get; set; }



        public Chromosom(string input)
        {
            Geny = JsonConvert.DeserializeObject<List<Zadanie>>(input);
        }



        public Chromosom(int Przyklad)
        {
            switch (Przyklad)
            {
                case 1:
                    {
                        Geny = new List<Zadanie>()
                        {
                            new Zadanie
                            {
                                NrZadania = 'A',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 65,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 2,
                                        NrMaszyny = 2,
                                        Czas = 170,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 3,
                                        NrMaszyny = 2,
                                        Czas = 75,
                                        
                                    },
                                }

                            },
                            new Zadanie
                            {
                                NrZadania = 'B',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 1,
                                        NrMaszyny = 2,
                                        Czas = 105,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'C',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'C',
                                        NrOperacji = 1,
                                        NrMaszyny = 2,
                                        Czas = 105,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'D',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 55,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 2,
                                        NrMaszyny = 2,
                                        Czas = 170,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 3,
                                        NrMaszyny = 2,
                                        Czas = 74,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'E',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 76,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 2,
                                        NrMaszyny = 8,
                                        Czas = 100,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 3,
                                        NrMaszyny = 9,
                                        Czas = 250,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 4,
                                        NrMaszyny = 3,
                                        Czas = 172,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 5,
                                        NrMaszyny = 5,
                                        Czas = 77,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 6,
                                        NrMaszyny = 4,
                                        Czas = 64,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 7,
                                        NrMaszyny = 4,
                                        Czas = 73,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'F',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 1,
                                        NrMaszyny = 6,
                                        Czas = 145,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 2,
                                        NrMaszyny = 4,
                                        Czas = 64,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'G',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 1,
                                        NrMaszyny = 6,
                                        Czas = 410,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 2,
                                        NrMaszyny = 4,
                                        Czas = 80,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'H',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'H',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 200,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'I',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 74,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 2,
                                        NrMaszyny = 5,
                                        Czas = 76,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 3,
                                        NrMaszyny = 4,
                                        Czas = 72,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 4,
                                        NrMaszyny = 5,
                                        Czas = 89,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 5,
                                        NrMaszyny = 7,
                                        Czas = 156,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 6,
                                        NrMaszyny = 7,
                                        Czas = 125,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 7,
                                        NrMaszyny = 3,
                                        Czas = 83,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 8,
                                        NrMaszyny = 3,
                                        Czas = 80,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 9,
                                        NrMaszyny = 9,
                                        Czas = 78,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'I',
                                        NrOperacji = 10,
                                        NrMaszyny = 4,
                                        Czas = 84,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'J',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 75,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 2,
                                        NrMaszyny = 8,
                                        Czas = 115,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 3,
                                        NrMaszyny = 9,
                                        Czas = 345,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 4,
                                        NrMaszyny = 3,
                                        Czas = 207,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 5,
                                        NrMaszyny = 5,
                                        Czas = 68,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 6,
                                        NrMaszyny = 4,
                                        Czas = 66,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'J',
                                        NrOperacji = 7,
                                        NrMaszyny = 4,
                                        Czas = 82,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'K',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'K',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 75,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'K',
                                        NrOperacji = 2,
                                        NrMaszyny = 2,
                                        Czas = 285,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'K',
                                        NrOperacji = 3,
                                        NrMaszyny = 2,
                                        Czas = 95,
                                        
                                    }
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'L',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 72,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 2,
                                        NrMaszyny = 5,
                                        Czas = 81,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 3,
                                        NrMaszyny = 4,
                                        Czas = 82,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 4,
                                        NrMaszyny = 5,
                                        Czas = 101,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 5,
                                        NrMaszyny = 7,
                                        Czas = 201,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 6,
                                        NrMaszyny = 7,
                                        Czas = 159,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 7,
                                        NrMaszyny = 3,
                                        Czas = 95,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 8,
                                        NrMaszyny = 9,
                                        Czas = 91,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 9,
                                        NrMaszyny = 3,
                                        Czas = 88,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'L',
                                        NrOperacji = 10,
                                        NrMaszyny = 4,
                                        Czas = 99,
                                        
                                    },
                                }
                            },
                        };
                        break;
                    }
                case 2: //str 218
                    {
                        Geny = new List<Zadanie>()
                        {
                            new Zadanie
                            {
                                NrZadania = 'A',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 44,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 2,
                                        NrMaszyny = 7,
                                        Czas = 116,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 3,
                                        NrMaszyny = 8,
                                        Czas = 108,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 4,
                                        NrMaszyny = 2,
                                        Czas = 96,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 5,
                                        NrMaszyny = 3,
                                        Czas = 212,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 6,
                                        NrMaszyny = 3,
                                        Czas = 203,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 7,
                                        NrMaszyny = 7,
                                        Czas = 127,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'A',
                                        NrOperacji = 8,
                                        NrMaszyny = 10,
                                        Czas = 54,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'B',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 28,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 2,
                                        NrMaszyny = 5,
                                        Czas = 485,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 3,
                                        NrMaszyny = 11,
                                        Czas = 67,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 4,
                                        NrMaszyny = 12,
                                        Czas = 240,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 5,
                                        NrMaszyny = 9,
                                        Czas = 72,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'B',
                                        NrOperacji = 6,
                                        NrMaszyny = 9,
                                        Czas = 114,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'C',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'C',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 476,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'C',
                                        NrOperacji = 2,
                                        NrMaszyny = 4,
                                        Czas = 148,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'C',
                                        NrOperacji = 3,
                                        NrMaszyny = 8,
                                        Czas = 76,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'C',
                                        NrOperacji = 4,
                                        NrMaszyny = 9,
                                        Czas = 76,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'D',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 29,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 2,
                                        NrMaszyny = 6,
                                        Czas = 532,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 3,
                                        NrMaszyny = 11,
                                        Czas = 53,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 4,
                                        NrMaszyny = 2,
                                        Czas = 480,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 5,
                                        NrMaszyny = 11,
                                        Czas = 62,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'D',
                                        NrOperacji = 6,
                                        NrMaszyny = 10,
                                        Czas = 69,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'E',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 1,
                                        NrMaszyny = 6,
                                        Czas = 500,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'E',
                                        NrOperacji = 2,
                                        NrMaszyny = 8,
                                        Czas = 92,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'F',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 1,
                                        NrMaszyny = 4,
                                        Czas = 583,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 2,
                                        NrMaszyny = 11,
                                        Czas = 47,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 3,
                                        NrMaszyny = 9,
                                        Czas = 76,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 4,
                                        NrMaszyny = 10,
                                        Czas = 73,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 5,
                                        NrMaszyny = 7,
                                        Czas = 185,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 6,
                                        NrMaszyny = 10,
                                        Czas = 73,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 7,
                                        NrMaszyny = 13,
                                        Czas = 180,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'F',
                                        NrOperacji = 8,
                                        NrMaszyny = 9,
                                        Czas = 110,
                                        
                                    },
                                }
                            },
                            new Zadanie
                            {
                                NrZadania = 'G',
                                Operacje = new List<Operacja>
                                {
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 1,
                                        NrMaszyny = 1,
                                        Czas = 44,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 2,
                                        NrMaszyny = 7,
                                        Czas = 116,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 3,
                                        NrMaszyny = 8,
                                        Czas = 108,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 4,
                                        NrMaszyny = 2,
                                        Czas = 96,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 5,
                                        NrMaszyny = 5,
                                        Czas = 212,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 6,
                                        NrMaszyny = 3,
                                        Czas = 203,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 7,
                                        NrMaszyny = 7,
                                        Czas = 107,
                                        
                                    },
                                    new Operacja
                                    {
                                        NrZadania = 'G',
                                        NrOperacji = 8,
                                        NrMaszyny = 10,
                                        Czas = 54,
                                        
                                    },
                                }
                            },
                        };
                        break;
                    }
                default:
                    break;
            }
            
        }
    }

    public class Zadanie
    {
        public char NrZadania { get; set; }
        public List<Operacja> Operacje { get; set; }
        public Zadanie()
        {
            Operacje = new List<Operacja>();
        }
    }

    public class Operacja
    {
        public char NrZadania { get; set; }
        public int NrOperacji { get; set; } 
        public int NrMaszyny { get; set; }
        public int Czas { get; set; }
    }

}
