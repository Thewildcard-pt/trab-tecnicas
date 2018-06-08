using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace platformerap
{
    class AtaqueJogador : Ataque
    {
        public AtaqueJogador(Texture2D newtexture, Rectangle position, bool right) : base(newtexture, position, right)
        {
            if (right)
            {
                this.position.X = (position.X + position.Width/2) + (int)(position.Width / 3);
            }
            else
            {
                this.position.X = (position.X + position.Width / 2) -  position.Width;
            }
        }

        internal void Update(GameTime gameTime)
        {
            lifespan -= 1;
            if (lifespan <= 0)
            {
                isVisible = false;
            }
        }
    }

}
