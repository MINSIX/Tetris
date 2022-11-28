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
        internal int BlockNum
        {
            get { return now.BlockNum; }
        }
        internal int Turn
        {
            get { return now.Turn; }
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
            for(int xx = 0; xx < 4; xx++)
            {
                for(int yy= 0; yy < 4; yy++)
                {
                    if(BlockValue.bvals[now.BlockNum,now.Turn,xx,yy]!=0)
                    {
                        if (now.X + xx <= 0)
                        {
                            return false;
                        }//위치 멈추게하기(벽안넘도록)
                    }
                }
            }   now.MoveLeft();
                return true;
          }
        internal bool MoveRight()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, now.Turn, xx, yy] != 0)
                    {
                        if (now.X + xx+1 >= GameRule.BX)
                        {
                            return false;
                        }//위치 멈추게하기(벽안넘도록)
                    }
                }
            }
            now.MoveRight();
            return true;
        }
        internal bool MoveDown()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, now.Turn, xx, yy] != 0)
                    {
                        if (now.Y + yy + 1 >= GameRule.BY)
                        {
                            return false;
                        }//위치 멈추게하기(벽안넘도록)
                    }
                }
            }
            now.MoveDown();
            return true;
        }
        internal bool MoveTurn()
        {
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[now.BlockNum, (now.Turn+1)%4, xx, yy] != 0)
                    {
                        if (((now.X+xx)<0)||(now.X+xx)>=GameRule.BX||((now.Y+yy)>=GameRule.BY))
                        {
                            return false;
                        }//위치 멈추게하기(벽안넘도록)
                    }
                }
            }
            now.MoveTurn();
            return true;
        }
        internal void Next()
        {
            now.Reset();
        }
    }
}
