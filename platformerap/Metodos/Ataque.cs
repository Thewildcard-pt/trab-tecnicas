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
    public class Ataque
    {
        Texture2D texture;
        public Rectangle position;
        bool toright;

        int lifespan;
        public bool isVisible;

        public Ataque(Texture2D newtexture,Rectangle position,bool right)
        {
            texture = newtexture;
            isVisible = true;
            lifespan = 15;
            this.position = position;
            this.position.Width = (int)(position.Width * 0.75);
            if (right)
            {
                this.position.X = position.X+position.Width+5;
            }
            else
            {
                this.position.X = position.X - 5-position.Width / 2;
            }
        }

        public void update()
        {
            lifespan -= 1;
            if(lifespan <= 0)
            {
                isVisible = false;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if(isVisible)
            spritebatch.Draw(texture, position, Color.White);
        }
    }
}
