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
    public class PauseState : State
    {
        private List<Componente> _componentes;

        public PauseState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("botao");
            var buttonFont = _content.Load<SpriteFont>("teste");


            var newGameButton = new Botao(buttonTexture, buttonFont) {

                Position = new Vector2((_game.graphics.PreferredBackBufferWidth / 2 - buttonTexture.Width / 2), game.graphics.PreferredBackBufferHeight / 2 - 200),
                text = "Resume Game",
                PenColour = Color.Black
            };

            newGameButton.Click += newGameButton_click;

            var QuitGameButton = new Botao(buttonTexture, buttonFont)
            {

                Position = new Vector2((_game.graphics.PreferredBackBufferWidth / 2 - buttonTexture.Width / 2), game.graphics.PreferredBackBufferHeight / 2),
                text = "Quit Game",
                PenColour = Color.Black
            };

            QuitGameButton.Click += QuitGameButton_click;
            _componentes =new List<Componente>()
            {
                newGameButton,QuitGameButton
            };

        }

        private void QuitGameButton_click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void newGameButton_click(object sender, EventArgs e)
        {
            _game.ChangeState((_game._saved_screen));
        }

        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var componente in _componentes)
            {
                componente.draw(gameTime,spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gametime)
        {
            //remove sprites if not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach(var componente in _componentes)
            {
                componente.update(gameTime);
            }
        }
    }
}
