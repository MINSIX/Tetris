using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 테트리스만들기
{
    public partial class Form1 : Form
    {
        Game game;
        int bx;
        int by;
        int bwidth;
        int bheight;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = Game.Singleton;
            bx = GameRule.BX;
            by = GameRule.BY;
            bwidth = GameRule.B_WIDTH;
            bheight = GameRule.B_HEIGHT;
            SetClientSizeCore(bx * bwidth+50, by * bheight+50); //폭과 높이를 갖는 윈도우
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            DrawGraduation(e.Graphics); //라인그리기
            DrawDiagram(e.Graphics);
            DrawBoard(e.Graphics);
        }

        private void DrawBoard(Graphics graphics)
        {
           for(int xx=0; xx<bx; xx++)
            {
                for(int yy=0; yy<by; yy++)
                {
                    if (game[xx, yy] != 0)
                    {
                        Rectangle now_rt = new Rectangle(xx * bwidth + 2, yy* bheight + 2, bwidth - 4, bheight - 4);
                        graphics.DrawRectangle(Pens.Green, now_rt);
                        graphics.FillRectangle(Brushes.Red, now_rt);
                    }
                }
            }
        }

        private void DrawDiagram(Graphics graphics) //박스그리기
        {
            Pen dpen = new Pen(Color.Red, 4);
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;
            for(int xx = 0; xx < 4; xx++)
            {
                for(int yy = 0; yy < 4; yy++) { 
                    if(BlockValue.bvals[bn,tn,xx,yy]!=0)
                    {
                        Rectangle now_rt = new Rectangle((now.X + xx) * bwidth + 2, (now.Y + yy) * bheight + 2, bwidth - 4, bheight - 4);
                        graphics.DrawRectangle(dpen, now_rt);
                    }
                }
            }
        }

        private void DrawGraduation(Graphics graphics)
        {
            DrawHorizons(graphics);     //수평선
            DrawVerticals(graphics);    //수직
        }

        private void DrawVerticals(Graphics graphics)
        {
            Point st = new Point();
            Point et = new Point();
            for(int cx = 0; cx < bx+1; cx++)
            {
                st.X= cx*bwidth;
                st.Y = 0;
                et.X = cx*bwidth;
                et.Y = by * bheight;
                graphics.DrawLine(Pens.Purple, st, et);
            }
        }

        private void DrawHorizons(Graphics graphics)
        {
            Point st = new Point();
            Point et = new Point();
            for (int cy = 0; cy < by+1; cy++)
            {
                st.X = 0;
                st.Y = cy * bheight;
                et.X = bx * bwidth;
                et.Y = st.Y;
                graphics.DrawLine(Pens.Green, st, et);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right: MoveRight();return;
                case Keys.Left: MoveLeft(); return;
                case Keys.Down: MoveDown(); return;
                case Keys.Up: MoveTurn(); return;
                case Keys.Space: MoveSSDown(); return;
            }
        }

        private void MoveSSDown()
        {
            while (game.MoveDown())
            {
                Region rg = MakeRegion(0, -1);
                Invalidate(rg);
            }
            EndingCheck();
            
        }

        private void EndingCheck()
        {
            if (game.Next())
            {
                Invalidate();
            }
            else
            {
                timer_down.Enabled = false;
                DialogResult re = MessageBox.Show("다시 시작", "의사", MessageBoxButtons.YesNo);
                if (re == DialogResult.Yes)
                {
                    game.Restart();
                    timer_down.Enabled=true;
                    Invalidate();
                }
                else
                {
                    Close();
                }
            }
        }

        private void MoveTurn()
        {
            if (game.MoveTurn())
            {
                Region rg= MakeRegion();
                Invalidate(rg);
            }
        }

        private void MoveDown()
        {
            if (game.MoveDown())
            {
                Region rg = MakeRegion(0, -1);
                Invalidate(rg);
            }
            else
            {
                EndingCheck();
               
            }
        }

  

        private void MoveLeft()
        {
            MoveSSDown();
            game.MoveLeft();
        }

        private void MoveRight()
        {
            MoveSSDown();
            game.MoveRight();
        }
        private Region MakeRegion(int cx, int cy)
        {
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;
            Region region = new Region();
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X + xx) * bwidth, (now.Y + yy) * bheight, bwidth, bheight);
                        Rectangle rect2 = new Rectangle((now.X +cx+ xx) * bwidth, (now.Y+cy + yy) * bheight, bwidth, bheight);
                        Region rg1 = new Region(rect1);
                        region.Union(rg1); 
                        Region rg2 = new Region(rect2);
                        region.Union(rg2);
                    }
                  
                }
            }
            return region;
        }
        private Region MakeRegion()
        {
            Point now = game.NowPosition;
            int bn = game.BlockNum;
            int tn = game.Turn;
            int oldtn = (tn + 3) % 4;
            Region region = new Region();
            for(int xx = 0; xx < 4; xx++)
            {
                for(int yy = 0; yy < 4; yy++)
                {
                    if (BlockValue.bvals[bn, tn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X+xx) * bwidth, (now.Y+yy) * bheight, bwidth, bheight);
                        Region rg1 = new Region(rect1);
                        region.Union(rg1);
                    }
                    if (BlockValue.bvals[bn, oldtn, xx, yy] != 0)
                    {
                        Rectangle rect1 = new Rectangle((now.X + xx) * bwidth, (now.Y + yy) * bheight, bwidth, bheight);
                        Region rg1 = new Region(rect1);
                        region.Union(rg1);
                    }
                }
            }
          return region;   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveDown();
        }
    }
}
