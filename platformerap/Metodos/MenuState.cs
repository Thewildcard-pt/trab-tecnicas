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
    public class MenuState : State
    {
        private List<Componente> _componentes;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("botao");
            var buttonFont = _content.Load<SpriteFont>("teste");


            var newGameButton = new Botao(buttonTexture, buttonFont) {

                Position = new Vector2(30, 150),
                text = " New Game",
                PenColour = Color.Black
            };

            newGameButton.Click += newGameButton_click;

            var QuitGameButton = new Botao(buttonTexture, buttonFont)
            {

                Position = new Vector2(30, 350),
                text = "Quit",
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
            Console.Write("detetado");
           // _game.Exit();
        }

        private void newGameButton_click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
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
