using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스만들기
{
    internal class BlockValue
    {
        static public readonly int[,,,] bvals = new int[1, 4, 4, 4]
        {
            {
                {       // 짝대기
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
            }
        };
    }

}