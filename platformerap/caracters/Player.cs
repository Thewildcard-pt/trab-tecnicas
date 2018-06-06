using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace platformerap
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(0, 0);
        private Vector2 velocity;
        private int speed=3;
        private int friction;
        private Vector2 maxVelocity = new Vector2((float)15,(float)15);
        private Rectangle rectangle;
        private Texture2D borders;
        public KeyboardState pastkey;
        private int jumpCount = 0;
        private int maxJump = 2;
        public int hp = 100;
        public bool spawned { get; set; }
        private bool falling = false;
        private int invun = 10;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public Player(GraphicsDeviceManager graphics)
        {
            borders = new Texture2D(graphics.GraphicsDevice, 1, 1);
            borders.SetData(new Color[] { Color.Red });
            spawned = false;
        }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("player");
        }

        public void Update(GameTime gameTime)
        {
            Input(gameTime);

            if (velocity.Y < 15)
            {
                velocity.Y += 0.6f;
                    if (velocity.Y > 0)
                        falling = true;
            }

            if(falling && jumpCount == 0)
            {
                jumpCount = 1;
            }

            if(invun > 0)invun--;
            

            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, 100, 100);
        }

        public void dano(int value)
        {
            if(invun <= 0)
            {
                hp -= value;
                invun = 20;
            }
        }

            private void Input(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds * 180;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                velocity.X += (float)speed;
                if (velocity.X > maxVelocity.X) velocity.X = maxVelocity.X;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X -= (float)speed;
            if (velocity.X < -maxVelocity.X) velocity.X = -maxVelocity.X;
            else
                velocity.X -= velocity.X/8;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && jumpCount<maxJump && !pastkey.IsKeyDown(Keys.Space) )
            {
                position.Y -= 17f;
                velocity.Y = -15f;
                jumpCount += 1;
            }

             pastkey = Keyboard.GetState();
           
        }

        public bool intersects(Rectangle newRectangle, int xOffset, int yOffset)
        {

            if (rectangle.TouchTopOf(newRectangle) || (rectangle.TouchLeftOf(newRectangle)) || (rectangle.TouchRightOf(newRectangle)) || (rectangle.TouchBottomOf(newRectangle)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void CollisionT(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                position.Y = newRectangle.Y - rectangle.Height - 1;
                velocity.Y = 0f;
                jumpCount = 0;
            }

            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width - 6;

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && Keyboard.GetState().IsKeyDown(Keys.D) && pastkey.IsKeyUp(Keys.Space))
                {
                    velocity.X = -30;
                    velocity.Y = -10;
                }
            }

            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 6;

                if(Keyboard.GetState().IsKeyDown(Keys.Space) && Keyboard.GetState().IsKeyDown(Keys.A )&& pastkey.IsKeyUp(Keys.Space))
                {
                    velocity.X = 30;
                    velocity.Y = -10;
                }
            }

            if (rectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (spawned)
            {
                spriteBatch.Draw(texture, rectangle, Color.White);

                //draw borders
                spriteBatch.Draw(borders, new Rectangle((int)rectangle.X, (int)rectangle.Y, 1, 100), Color.Red);
                spriteBatch.Draw(borders, new Rectangle((int)rectangle.X, (int)rectangle.Y, 100, 1), Color.Red);
                spriteBatch.Draw(borders, new Rectangle((int)rectangle.X + 100, (int)rectangle.Y, 1, 100), Color.Red);
                spriteBatch.Draw(borders, new Rectangle((int)rectangle.X, (int)rectangle.Y + 100, 100, 1), Color.Red);
            }
        }


    }
}
