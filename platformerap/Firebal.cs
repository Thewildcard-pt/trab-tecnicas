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
    public class Firebal
    {
        public Rectangle _rectangle;
        private Texture2D _texture;
        private int velocity;
        public int dano = 20;
        

        public Firebal(Rectangle rectangle,Texture2D texture)
        {
            _rectangle = rectangle;
            _rectangle.Width = _rectangle.Width / 2;
            _rectangle.Height = _rectangle.Height / 2;
            velocity = 10;
            _texture = texture;
        }

        public void Update(Rectangle player)
        {
            _rectangle.Y += velocity;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
