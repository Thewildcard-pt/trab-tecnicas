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
        public bool hit = false;
        public int lifespan;
        

        public Firebal(Rectangle rectangle,Texture2D texture)
        {
            _rectangle = rectangle;
            _rectangle.Width = _rectangle.Width / 2;
            _rectangle.Height = _rectangle.Height / 2;
            velocity = 5;
            _texture = texture;
            lifespan = 180;
        }

        public void Update(Rectangle player)
        {
            if (player.X + 10 > this._rectangle.X)
                this._rectangle = new Rectangle(this._rectangle.X + velocity, this._rectangle.Y, this._rectangle.Width, this._rectangle.Height);
            if (player.X + 10 < this._rectangle.X)
                this._rectangle = new Rectangle(this._rectangle.X - velocity, this._rectangle.Y, this._rectangle.Width, this._rectangle.Height);
            if (player.Y + 20 > this._rectangle.Y)
                this._rectangle = new Rectangle(this._rectangle.X, this._rectangle.Y + velocity, this._rectangle.Width, this._rectangle.Height);
            if (player.Y + 20 < this._rectangle.Y)
                this._rectangle = new Rectangle(this._rectangle.X, this._rectangle.Y - velocity, this._rectangle.Width, this._rectangle.Height);

            lifespan--;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
