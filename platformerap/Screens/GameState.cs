﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformerap
{
    class GameState : State
    {
        Map map = new Map();
        Player player;
        Camera camera;
        KeyboardState Kstate;
        

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;

            player = new Player(game.graphics);
            camera = new Camera(game.graphics.GraphicsDevice.Viewport);

            Tiles.Content = content;
            Tiles.Graphics = game.graphics;

          
            /*
             1->12 blocos
             13->15 moving blocks
             22->25 - spikes
             21-serra
             19-porta de spawn
             20-porta de saida
             26-knight
             28-ogre             
             32-passaro
             30-zombie
             */

            map.Generate(new int[,]{
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,32,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,28,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,02,02,02,02,02,02,02,02,02,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,02,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,02,24,02,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,28,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,11,02,02,02,02,02,02,02,02},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,02,02,02,02,02,02,02,00,00,26,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,11,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,02,05,05,05,05,05,05,00,22,22,02,02,02,02,02,02,02,13,14,15,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,05,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,05,23,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,02,23,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,05,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,00,00,00,00,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,32,00,00,00,00,00,00,00,00,00,00,00,24,05,00,00,24,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,32,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,05,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,26,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,05,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,02,02,02,02,02,02,02,22,22,22,22,22,02,02,02,02,02,00,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,24,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,26,00,00,00,00,19,00,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,22,00,00,00,00,00,00,00,00,00,02,02,02,02,02,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,24,02,02,02,23,00,00,00,00,00,00,00,00,00,24,02,02,02,02,02,02,07,23,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,01,02,02,02,02,02,03,00,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05,02,00,00,00,00,22,00,22,00,00,00,00,00,00,00,00,00,00,00,00,00,13,14,15,00,00,00,00,00,00,00,00,00,00,00,13,14,15,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,13,14,15,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05},
                {00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,04,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,22,22,22,22,22,22,22,22,22,05,05,05,05,05,05,05,05,05,00,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,05,05,05,05,05,05,05,05,05},
                {02,02,02,02,02,02,03,30,00,00,00,30,00,00,00,30,00,00,00,00,00,00,00,04,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,02,02,02,02,02,02,02,02,02,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,05,05,05,05,05,05,05,05,05},
                {05,05,05,05,05,05,10,02,02,02,02,02,02,02,02,02,02,02,02,02,02,02,07,08,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,06,00,00,00,00,00,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05},
            }, 100);
            player.Load(content);
            _game._saved_screen = this;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred,
                                 BlendState.AlphaBlend,
                                 null, null, null, null,
                                 camera.Transform);

            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gametime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach (DoorTiles tile in map.DoorTiles)
            {
                if (tile.Spawned && !player.Spawned)
                {
                    player.Spawned = true;
                    player.Position = new Vector2(tile.Rectangle.X, tile.Rectangle.Y);
                }
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.ChangeState(new PauseState(_game, _game.graphics.GraphicsDevice, _game.Content));
            }
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
                    player.Dano(25);
                }
            }

            foreach (SpikeTiles tile in map.SpikeTiles)
            {
                if (player.Intersects(tile.Rectangle, map.Width, map.Height))
                {
                    player.Dano(25);
                }
            }

            foreach (ExitTiles tile in map.ExitTiles)
            {
                if (player.Intersects(tile.Rectangle, map.Width, map.Height))
                {
                    _game.ChangeState(new MenuState(_game, _game.graphics.GraphicsDevice, _game.Content));
                }
            }

            map.Inimigo.RemoveAll(a => a.Hp <= 0);
            foreach (Inimigo knight in map.Inimigo)
            {

                foreach (AtaqueJogador a in player.Ataque)
                {
                    if (knight.Intersects(a.position, map.Width, map.Height)) knight.Dano(25);
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



            map.Zombie.RemoveAll(a => a.Hp <= 0);
            foreach (Zombie z in map.Zombie)
            {

                if (player.Intersects(z.Rectangle, map.Width, map.Height))
                {
                    player.Dano(20);
                }

                foreach (AtaqueJogador a in player.Ataque)
                {
                    if (z.Intersects(a.position, map.Width, map.Height)) z.Dano(25);
                }
                z.UpdateI(gameTime);
            }

            

            map.Birb.RemoveAll(a => a.Hp <= 0);
            foreach (Birb b in map.Birb)
            {
                b.Update(gameTime, player.Rectangle);

                foreach (AtaqueJogador a in player.Ataque)
                {
                    if (b.Intersects(a.position, map.Width, map.Height)) b.Dano(25);
                }

                b.Fball.RemoveAll(a => a.hit == true);
                b.Fball.RemoveAll(a => a.lifespan <= 0);
                foreach (Firebal f in b.Fball)
                {
                    if (player.Intersects(f._rectangle, map.Width, map.Height))
                    {
                        player.Dano(f.dano);
                        f.hit = true;
                    }
                    f.Update(player.Rectangle);
                }
            }

   
            #endregion



            player.Update(gameTime);
            if (player.hp < 0)
            {
                _game.ChangeState(new LossState(_game, _game.graphics.GraphicsDevice, _game.Content));
            }


           foreach(MovingTiles m in map.MovingTiles)
            {
                if (player.Intersects(m.Rectangle, map.Width, map.Height))
                {
                    player.Move(m.goingRight, m.Velocity +6 ,gameTime);
                }
            }

            Kstate = Keyboard.GetState();

        }
    }
}
