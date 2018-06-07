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
    public abstract class Componente
    {
        public abstract void draw(GameTime gametime,SpriteBatch spritebatch);

        public abstract void update(GameTime gametime);
    }
}
