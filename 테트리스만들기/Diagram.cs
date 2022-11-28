using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스만들기
{
    internal class Diagram
    {
        internal int X  //x좌표
        {
            get;
            private set;
        }
        internal int Y //y좌표
        {
            get;
            private set;
        }
        internal Diagram() //블록 초기화
        {
            Reset();
        }
        internal void Reset() //시작위치로 초기화
        {
            X = GameRule.SX;
            Y=GameRule.SY;
        }
        internal void MoveLeft() //왼쪽누르면 x--
        {
            X--;
        }
        internal void MoveRight() //오른쪽누르면 x++
        {
            X++;
        }
        internal void moveDown() //밑으로누르면 y++
        {
            Y++;
        }
    }
}
