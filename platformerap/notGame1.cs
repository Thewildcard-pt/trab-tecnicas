using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace platformerap
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BackupGame1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Map map = new Map();
        Player player;
        Camera camera;
        int state = 0;


        KeyboardState Kstate;
        // 0=em jogo 1 = em pausa 2 = em menu
        public BackupGame1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();
            Tiles.Content = Content;
            Tiles.Graphics = graphics;
            player = new Player(graphics);
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            map.Generate(new int[,]{
                {00,00,00,00,00,00,00,00,00,00,00,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {32,00,00,00,00,00,00,00,00,00,21,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,00,00,00,00,01,02,03,00,00,00,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,00,00,00,00,04,05,06,00,00,00,00,00,0,13,14,14,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,14,14,14,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,00,00,00,00,04,05,06,00,00,00,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,00,00,00,24,04,05,06,23,00,00,00,00,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {00,19,00,00,24,04,05,06,23,00,00,00,00,0,0,0,0,0,28,0,0,0,0,0,0,0,26,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,20,0,0,0,0,0},
                {02,02,34,02,07,08,05,10,11,02,03,17,17,17,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
                {05,05,05,05,05,05,05,05,05,05,06,18,18,18,4,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,6},
            }, 80);
            player.Load(Content);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            foreach (DoorTiles tile in map.DoorTiles)
            {
                if (tile.Spawned && !player.Spawned)
                {
                    player.Spawned = true;
                    player.Position = new Vector2(tile.Rectangle.X, tile.Rectangle.Y);
                }
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) && Kstate.IsKeyUp(Keys.Escape) && state == 0)
            {
                state = 1;
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) && Kstate.IsKeyUp(Keys.Escape) && state == 1)
                state = 0;

            if (state == 0)
            {
                // For Mobile devices, this logic will close the Game when the Back button is pressed
                // Exit() is obsolete on iOS

                #region to_each_their_own
                foreach (MovingTiles tile in map.MovingTiles)
                {
                    tile.Update(gameTime);
                    player.CollisionT(tile.Rectangle, map.Width, map.Height);
                }

                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    player.CollisionT(tile.Rectangle, map.Width, map.Height);
                    camera.Update(player.Position, map.Width, map.Height);
                }

                foreach (Sawtile tile in map.Sawtile)
                {
                    tile.Update(gameTime);
                    if (player.Intersects(tile.Rectangle, map.Width, map.Height))
                    {
                        Exit();
                    }
                }

                foreach (SpikeTiles tile in map.SpikeTiles)
                {
                    if (player.Intersects(tile.Rectangle, map.Width, map.Height))
                    {
                        Exit();
                    }
                }

                foreach (ExitTiles tile in map.ExitTiles)
                {
                    if (player.Intersects(tile.Rectangle, map.Width, map.Height))
                    {
                        Exit();
                    }
                }

                map.Inimigo.RemoveAll(a => a.Hp <= 0);
                foreach (Inimigo knight in map.Inimigo)
                {

                    if (player.Intersects(knight.Rectangle, map.Width, map.Height))
                    {
                        knight.Timer -= 1;
                    }

                    if (Math.Abs(player.Rectangle.X - knight.Rectangle.X) <= 160 && knight.grace == 0)
                    {
                        knight.UpdateA(gameTime, player.Rectangle);
                    }
                    else
                    {
                        knight.UpdateI(gameTime);
                    }

                    foreach (Ataque a in knight.Ataque)
                        if (player.Intersects(a.position, map.Width, map.Height))
                        {
                            player.Dano(knight.dano);
                        }
                }

                foreach (Zombie z in map.Zombie)
                {

                    if (player.Intersects(z.Rectangle, map.Width, map.Height))
                    {
                        z.Timer -= 1;
                        player.hp -= 1;
                    }
                    z.UpdateI(gameTime);
                }

                foreach(Birb b in map.Birb)
                {
                    b.Update(gameTime,player.Rectangle);

                    foreach(Firebal f in b.Fball)
                    {
                        if (player.Intersects(f._rectangle, map.Width, map.Height))
                        {
                            player.Dano(f.dano);
                        }
                        f.Update(player.Rectangle);
                    }
                }

            }
            #endregion


            player.Update(gameTime);



            base.Update(gameTime);
            if (player.hp < 0)
            {
                Exit();
            }


            Kstate = Keyboard.GetState();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                                 BlendState.AlphaBlend,
                                 null, null, null, null,
                                 camera.Transform);

            switch (state)
            {
                case 0:
                    map.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    break;
                case 1:

                    break;


            }







            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}