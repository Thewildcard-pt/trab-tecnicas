using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace platformerap
{
    class Botao : Componente
    {
        #region fields
        private MouseState currentMouse;
        private SpriteFont _font;
        private bool _ihovering;
        private MouseState previousMouse;
        private Texture2D _texture;

        

        public EventHandler Click;
        
        public bool Cilcked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string text { get; set; }

        #endregion

        #region Metodos
        public Botao(Texture2D texture,SpriteFont font)
        {
            _texture = texture;
            _font = font;
        }

        public override void draw(GameTime gametime, SpriteBatch spritebatch)
        {
            var colour = (Color.White);

            if (_ihovering) colour = Color.Gray;
            spritebatch.Draw(_texture, rectangle, colour);

            if (!string.IsNullOrEmpty(text))
            {
                var x = (rectangle.X + (rectangle.Width / 2) - (_font.MeasureString(text).X / 2));
                var y = (rectangle.Y + (rectangle.Height / 2) - (_font.MeasureString(text).Y / 2));
                spritebatch.DrawString(_font, text, new Vector2(x, y), PenColour);
            }
        }

        public override void update(GameTime gametime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(currentMouse.X, currentMouse.Y, 1, 1);


            _ihovering = false;

            if (mouseRectangle.Intersects(rectangle))_ihovering = true;
            if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed && _ihovering) Click?.Invoke(this, new EventArgs());

        }
        #endregion
    }
}
