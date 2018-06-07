using System;
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
        int state = 0;
        KeyboardState Kstate;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
            

            
            //   player = new Player(game.GraphicsDevice);
            //   camera = new Camera(graphics.GraphicsDevice.Viewport);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();


            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gametime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}
