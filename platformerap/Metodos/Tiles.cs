using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace platformerap
{
    public class Tiles
    {
        public Texture2D texture;

        public Rectangle Rectangle { get; set;}
        public static ContentManager Content { get; set; }
        public static GraphicsDeviceManager Graphics { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Rectangle, Color.White);
        }
    }

    public class WaterTiles : Tiles
    {
        public WaterTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }

    public class DoorTiles : Tiles
    {
        public bool Spawned { get; set; }
        public DoorTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
            Spawned = true;
        }
    }

    public class ExitTiles : Tiles
    {
        public ExitTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }

    public class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }

    public class SpikeTiles : Tiles
    {
        public SpikeTiles(int i, Rectangle newRectangle)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
        }
    }

    public class MagicTiles : Tiles
    {
        private bool Visible { get; set; }
        public float delay = 2f;

        public MagicTiles(int i, Rectangle newRectangle, bool newVisible)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
            Visible = newVisible;
        }

        public void Update(GameTime gameTime)
        {
            
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            delay -= dt;

            if (delay < 0f) {
                System.Diagnostics.Debug.WriteLine(delay);
                this.Visible = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                delay = 2f;
                this.Visible = true;
            }
                
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Visible) spriteBatch.Draw(texture, Rectangle, Color.White);
        }
    }

    public class MovingTiles : Tiles
    {
        private bool Horizontally { get; set; }
        private bool Vertically { get; set; }
        public int Velocity;
        int x, y, topBoundry, bottomBoundry;
           public  bool goingRight = true, goingUp = true;
        int hboundry;

        public int leftBoundry , rightBoundry;


        public int X
        {
            get { return x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return y; }
            set { this.y = value; }
        }

        public MovingTiles(int i, Rectangle newRectangle, int newVelocity, bool newVertically, bool newHorizontally,int hboundry)
        {
            texture = Content.Load<Texture2D>(i.ToString());
            Rectangle = newRectangle;
            Vertically = newVertically;
            Horizontally = newHorizontally;
            Velocity = newVelocity;

            leftBoundry = Rectangle.X;
            rightBoundry = Rectangle.X + Rectangle.Width * hboundry;

            topBoundry = Rectangle.Y - Rectangle.Height * hboundry;
            bottomBoundry = Rectangle.Y;

            x = Rectangle.X;
            y = Rectangle.Y;
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Horizontally)
            {
                if (Rectangle.X < rightBoundry && goingRight)
                {
                    x = Rectangle.X + (int)(Velocity * dt);
                }
                else if (Rectangle.X > leftBoundry)
                {
                    goingRight = false;
                    x = Rectangle.X - (int)(Velocity * dt);
                }
                else
                {
                    goingRight = true;
                }
            }

            if (Vertically)
            {
                if (Rectangle.Y > topBoundry && goingUp)
                {
                    y = Rectangle.Y - (int)(Velocity * dt);
                }
                else if (Rectangle.Y < bottomBoundry)
                {
                    goingUp = false;
                    y = Rectangle.Y + (int)(Velocity * dt);
                }
                else
                {
                    goingUp = true;
                }
            }

            Rectangle = new Rectangle(x, y, Rectangle.Width, Rectangle.Height);
        }
     
    }

   public class Sawtile : MovingTiles
        {
            public Sawtile(int i, Rectangle newRectangle, int newVelocity, bool newVertically, bool newHorizontally) : base( i, newRectangle, newVelocity, newVertically, newHorizontally,5)
            {
            }
        }

    public class Inimigo : MovingTiles
    {
        public int Hp,Timer,TimerA,grace,timermax,dano;
        Rectangle lifeBarBase,lifeBarCurrent;
        Texture2D texturabase, texturacurrent,texturaAtaque; 
        Texture2D textura2;
        List<Ataque> Lataque = new List<Ataque>();
        int modifier;
        public List<Ataque> Ataque
        {
            get { return Lataque; }
        }

        public Inimigo(int i,int i2, int dano,int timer, Rectangle newRectangle, int newVelocity, bool newVertically, bool newHorizontally,int hp,int speed) : base(i, newRectangle, newVelocity+speed, newVertically, newHorizontally,6)
        {
            this.Hp = hp;
            this.Timer = 30;
            this.timermax = timer;
            TimerA = timermax;
            this.dano = dano;
            texturabase = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturacurrent = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturaAtaque = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturabase.SetData(new Color[] { Color.Red });
            texturacurrent.SetData(new Color[] { Color.Green });
            texturaAtaque.SetData(new Color[] { Color.Red });
            textura2 = Content.Load<Texture2D>(i2.ToString());
            grace = 0;
            
          

        }

        public void UpdateG(GameTime h)
        {
            foreach (Ataque a in Lataque)
            {
                a.Update();
            }

            Lataque.RemoveAll(a => a.isVisible == false);

            if(grace > 0)
            {
                grace--;
            }

            if (Timer <= 0)
            {
                Timer = 30;
                Hp -= 20;
            }

            lifeBarBase = new Rectangle((int)Rectangle.X -10, (int)Rectangle.Y - Rectangle.Height / 3,(int)(Rectangle.Width + 20), 10);
            lifeBarCurrent = new Rectangle((int)Rectangle.X -10 , (int)Rectangle.Y - Rectangle.Height / 3 , (int)((Rectangle.Width + 20) * Hp/100 ), 10);
        }


        public void UpdateI(GameTime h)
        {
            UpdateG(h);
            base.Update(h);
        }

        public void UpdateA(GameTime h, Rectangle player)
        {
            if (player.X < Rectangle.X)
            {
                goingRight = false;
            }
            else
            {
                goingRight = true;
            }
            TimerA -= 1;
            if (TimerA <= 0)
            {
                TimerA = timermax;
                grace = 60;
                if (goingRight)
                {
                    Lataque.Add(new Ataque(texturaAtaque, Rectangle,true));
                }
                else
                {
                    Lataque.Add(new Ataque(texturaAtaque, Rectangle,false));

                }
                UpdateG(h);
                
            }
        }

          public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturabase, lifeBarBase , Color.White);
            spriteBatch.Draw(texturacurrent, lifeBarCurrent, Color.White);
            foreach(Ataque a in Lataque)
            {
                a.Draw(spriteBatch);
            }
            if (goingRight)
            {
                spriteBatch.Draw(textura2,Rectangle,Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, Rectangle, Color.White);
            }
            
        }

        
    }

    public class Zombie : MovingTiles
    {
        public int Hp, Timer, TimerA, grace, timermax, dano;
        Rectangle lifeBarBase, lifeBarCurrent;
        Texture2D texturabase, texturacurrent, texturaAtaque;
        Texture2D textura2;
        int modifier;
        public Zombie(int i, int i2, int dano, int timer, Rectangle newRectangle, int newVelocity, bool newVertically, bool newHorizontally, int hp, int speed) : base(i, newRectangle, newVelocity + speed, newVertically, newHorizontally, 6)
        {
            this.Hp = hp;
            this.Timer = 30;
            this.timermax = timer;
            TimerA = timermax;
            this.dano = dano;
            texturabase = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturacurrent = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturaAtaque = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            texturabase.SetData(new Color[] { Color.Red });
            texturacurrent.SetData(new Color[] { Color.Green });
            texturaAtaque.SetData(new Color[] { Color.Red });
            textura2 = Content.Load<Texture2D>(i2.ToString());
            grace = 0;



        }

        public void UpdateG(GameTime h)
        {
            if (Timer <= 0)
            {
                Timer = 30;
                Hp -= 20;
            }
            lifeBarBase = new Rectangle((int)Rectangle.X - 10, (int)Rectangle.Y - Rectangle.Height / 3, (int)(Rectangle.Width + 20), 10);
            lifeBarCurrent = new Rectangle((int)Rectangle.X - 10, (int)Rectangle.Y - Rectangle.Height / 3, (int)((Rectangle.Width + 20) * Hp / 100), 10);
        }


        public void UpdateI(GameTime h)
        {
            UpdateG(h);
            base.Update(h);
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texturabase, lifeBarBase, Color.White);
            spriteBatch.Draw(texturacurrent, lifeBarCurrent, Color.White);

            if (goingRight)
            {
                spriteBatch.Draw(textura2, Rectangle, Color.White);
            }
            else
            {
                spriteBatch.Draw(texture, Rectangle, Color.White);
            }

        }
    }

    public class Birb  : MovingTiles
    {
        int i,timer = 60;
        Texture2D _ataque;
        public List<Firebal> Fball = new List<Firebal>();


        public Birb(int i, Rectangle newRectangle, int newVelocity, bool newVertically, bool newHorizontally, int hboundry) : base(i, newRectangle, newVelocity, newVertically, newHorizontally, hboundry)
        {
            this.i = i;
            _ataque = Content.Load<Texture2D>("fireBall");
        }

        public new void Update(GameTime gameTime,Rectangle player)
        {
            base.Update(gameTime);
            if (goingRight)
            {
                texture = Content.Load<Texture2D>((string)(i+1).ToString());
            }
            else
            {
                texture = Content.Load<Texture2D>(i.ToString());
            }
            timer -= 1;
            if(Math.Abs(player.X - Rectangle.X) < 250 && timer<=0)
            {
                Fball.Add(new Firebal(Rectangle,_ataque));
                timer = 60;
            }

        }    
        
        public new void Draw(SpriteBatch spritebatch)
        {
            base.Draw(spritebatch);
            foreach(Firebal f in Fball)
            {
                f.Draw(spritebatch);
            }
        }

    }
    }
