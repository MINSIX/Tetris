using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스만들기
{
    internal class BlockValue
    {
        static public readonly int[,,,] bvals = new int[7, 4, 4, 4]
        {
            {
                {       // 블록 1 짝대기
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,0,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,0 },
                    {1,1,1,1 },
                    {0,0,0,0 }
                },
                {
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,0,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,0 },
                    {1,1,1,1 },
                    {0,0,0,0 }
                }
            },
             {
                {       // 블록2 네모
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                }
            },
              {
                {       // 블록 3 긴짝대기
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,0,1,0 },
                    {0,0,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,1 },
                    {0,1,1,1 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,0,1,1 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,0 },
                    {0,1,1,1 },
                    {0,1,0,0 }
                }
            }
            , {
                {       // 블록 4 긴짝대기2
                    {0,0,0,0 },
                    {0,0,1,1 },
                    {0,0,1,0 },
                    {0,0,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,0 },
                    {0,1,1,1 },
                    {0,0,0,1 }
                },
                {
                    {0,0,0,0 },
                    {0,0,1,0 },
                    {0,0,1,0 },
                    {0,1,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,0,0 },
                    {0,1,1,1 },
                    {0,0,0,0 }
                }
            }
            , {
                {       // 블록5 요철
                    {0,0,1,0 },
                    {0,0,1,1 },
                    {0,0,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,1,1 },
                    {0,0,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,1,0 },
                    {0,1,1,0 },
                    {0,0,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,1,0 },
                    {0,1,1,1 },
                    {0,0,0,0 },
                    {0,0,0,0 }
                }
            }
            , {
                {       // 블록6 z모양 1
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,0,1,1 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,1 },
                    {0,0,1,1 },
                    {0,0,1,0 }
                },
                {
                    {0,0,0,0 },
                    {0,1,1,0 },
                    {0,0,1,1 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,0,1 },
                    {0,0,1,1 },
                    {0,0,1,0 }
                }
            }
            , {
                {       // 블록7 z모양 2
                    {0,0,0,0 },
                    {0,0,1,1 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,1,0 },
                    {0,1,1,0 },
                    {0,1,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,1,1 },
                    {0,1,1,0 },
                    {0,0,0,0 }
                },
                {
                    {0,0,0,0 },
                    {0,0,1,0 },
                    {0,1,1,0 },
                    {0,1,0,0 }
                },
            }
        };
    }

}