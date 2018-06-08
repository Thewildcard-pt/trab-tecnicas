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

        public int lifespan;
        public bool isVisible;

        public Ataque(Texture2D newtexture,Rectangle Nposition,bool right)
        {
            texture = newtexture;
            isVisible = true;
            lifespan = 15;


            this.position = Nposition;

            if (right)
            {
                this.position.X = (position.X + position.Width / 2) + (int)(position.Width / 3);
            }
            else
            {
                this.position.X = (position.X + position.Width / 2) - position.Width;
            }

            this.position.Width = (int)(position.Width * 0.75);

        }

        public void Update()
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
