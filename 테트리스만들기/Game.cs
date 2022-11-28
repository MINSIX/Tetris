using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스만들기
{
    internal class Game
    {
        Diagram now;
        internal Point NowPosition
        {
            get
            {
                if(now== null)
                {
                    return new Point(0, 0); //0,0 반환
                }
                return new Point(now.X, now.Y); //now의 x,y 반환
            }
        }

        #region
        //단일객체
        internal static Game Singleton
        {
            get;
            private set;
        }
        static Game()
        {
            Singleton = new Game();
        }
        Game()
        {
            now=new Diagram();
        }
        #endregion
        internal bool MoveLeft()
        {
            if (now.X > 0)
            {
                now.MoveLeft();
                return true;
            }
            return false;
        }
        internal bool MoveRight()
        {
            if ((now.X+1) <GameRule.BX) //벽넘기안하기
            {
                now.MoveRight();
                return true;
            }
            return false;
        }
        internal bool MoveDown()
        {
            if ((now.Y + 1) < GameRule.BY) //지하뚫기 않하기
            {
                now.MoveRight();
                return true;
            }
            return false;
        }
    }
}
