using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 테트리스만들기
{
     class Board
    {
            int count;
            internal static Board GameBoard
            {
                get;
                private set;
            }
            static Board()
            {
                GameBoard = new Board();
            }
            Board()
            {
            }
            int[,] board = new int[GameRule.BX, GameRule.BY];
            int[,] cboard = new int[GameRule.BX, GameRule.BY];
        internal int this[int x, int y]
            {
                get
                {
                    return board[x, y];
                }
            }
            internal bool MoveEnable(int bn, int tn, int x, int y)
            {
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                        {
                            if (board[x + xx, y + yy] != 0)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            internal void Store(int bn, int turn, int x, int y)
            {
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        if (((x + xx) >= 0) && (x + xx < GameRule.BX) && (y + yy >= 0) && (y + yy < GameRule.BY))
                        {

                            board[x + xx, y + yy] += BlockValue.bvals[bn, turn, xx, yy];
                        }
                    }
                }
            CheckLines(y + 3);
            }
        internal void CopyBoard(int xx, int yy)
        {
                    cboard[xx,yy]=board[xx,yy];
        }

        internal void LStore(int bn, int turn, int x, int y)
        {
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                for (int yy = 0; yy < GameRule.BY; yy++)
                {    
                        CopyBoard(xx,yy);
                }
            }
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                for (int yy = 0; yy < GameRule.BY; yy++)
                {
                    board[xx, yy] = cboard[yy, GameRule.BX - xx - 1];
                }
            }
          
        }
        internal void RStore(int bn, int turn, int x, int y)
        {
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                for (int yy = 0; yy < GameRule.BY; yy++)
                {
                    CopyBoard(xx, yy);
                }
            }
            for (int xx = 0; xx < GameRule.BX; xx++)
            {
                for (int yy = 0; yy < GameRule.BY; yy++)
                {
                    board[xx, yy] = cboard[GameRule.BY-yy-1, xx ];


                }
            }
        }
            //internal void DAB()
            //{
     
            //for (int yy = GameRule.BY-1; yy >= 0; yy--)
            //{
            //    for (int xx = 0; xx < GameRule.BX; xx++)
            //    {
            //        if (board[xx, yy] == 1)
            //        {
            //            int breakpoint = 0;
                      
            //            for (int yi = yy; yi < GameRule.BY; yi++)
            //            {
            //                int count = 0;
            //                for (int xi = 0; xi < GameRule.BX; xi++)
            //                {
            //                    if (board[xi, yi] == 0)
            //                    {
            //                        count++;
            //                    }
            //                    else
            //                    {
            //                        breakpoint++;
            //                        break;
            //                    }

            //                }
            //                if (breakpoint == 1)
            //                {
            //                    for (int xi = 0; xi < GameRule.BX; xi++)
            //                    {
            //                        //왜안대지
            //                        //board[xi, yi + count/20] = board[xi, yi];
            //                        //board[xi, yi] = 0;
            //                    }
            //                }
                         
            //            }
            //        }
                  
                    
            //        }
            //    }
              
            //}
            internal void CheckBlocks()
        {
            for(int yy = GameRule.BY-1; yy >= 0; yy--) { 
            for(int xx = 0; xx < GameRule.BX; xx++)
            {
                    if (board[xx, yy] == 1)
                    {
                        DownBlocks(CountBlank(yy-1),yy-1);
                        
                        break;
                    }
                }   
            }
        }
      internal int CountBlank(int yy)
        {
            int Blankcount = 0;
            int x = 0;
            while (board[x, yy] != 1)
            {
                
                x++;
                if (x == GameRule.BX)
                {
                    x = 0;
                    Blankcount++;
                    yy++;
                }
            }
            return Blankcount;
        }
        internal void DownBlocks(int count,int y)
        {
            for (; y > 0; y--)
            {
                for (int xx = 0; xx < GameRule.BX; xx++)
                {
                    //윗줄의 내용을 아랫줄에 줄복사하는코드

                    board[xx, y] = board[xx, y - count];
                }
            }
        }
        
        private void CheckLines(int y)
        {
            int yy = 0;
            for (yy = 0; yy < 4; yy++)
            {
                if (y - yy < GameRule.BY)
                {
                    if (CheckLine(y - yy))
                    {
                        ClearLine(y - yy);
                        y++;
                    }
                }
            }
        }

        private void ClearLine(int y) 
        {
            for (; y > 0; y--)
            {
                for(int xx=0; xx <GameRule.BX; xx++)
                {
                    //윗줄의 내용을 아랫줄에 줄복사하는코드

                    board[xx, y] = board[xx, y - 1]; 
                }
            }
        }

        private bool CheckLine(int y)
        {
        for(int xx = 0; xx < GameRule.BX; xx++)
            {
                if (board[xx, y] == 0) //비어있는게있으면 거짓 반환
                {                      //꽉찬게 아니라는 뜻
                    return false;
                }
            }
            return true;
        }
        internal void ClearBoard()
        {
            for(int xx = 0; xx < GameRule.BX; xx++)
            {
                for(int yy = 0; yy < GameRule.BY; yy++)
                {
                    board[xx, yy] = 0;//모든 보드 클리어 
                }
            }
        }
    }
}