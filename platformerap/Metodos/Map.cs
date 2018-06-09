using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace platformerap
{
    public class Map
    {
        // Private variables
        private List<CollisionTiles> collisionTiles = new List<CollisionTiles>();
        private List<WaterTiles> waterTiles = new List<WaterTiles>();
        private List<MovingTiles> movingTiles = new List<MovingTiles>();
        private List<MagicTiles> magicTiles = new List<MagicTiles>();
        private List<DoorTiles> doorTiles = new List<DoorTiles>();
        private List<ExitTiles> exitTiles = new List<ExitTiles>();
        private List<Sawtile> sawtile = new List<Sawtile>();
        private List<SpikeTiles> spikeTiles = new List<SpikeTiles>();
        private List<Inimigo> inimigo = new List<Inimigo>();
        private List<Zombie> zombie = new List<Zombie>();
        private List<Birb> birb = new List<Birb>();


        //public access methods
        public List<CollisionTiles> CollisionTiles
        {
            get { return collisionTiles; }
        }
        public List<WaterTiles> WaterTiles
        {
            get { return waterTiles; }
        }
        public List<MovingTiles> MovingTiles
        {
            get { return movingTiles; }
        }
        public List<MagicTiles> MagicTiles
        {
            get { return magicTiles; }
        }
        public List<DoorTiles> DoorTiles
        {
            get { return doorTiles; }
        }

        public List<ExitTiles> ExitTiles
        {
            get { return exitTiles; }
        }

        public List<Sawtile> Sawtile
        {
            get { return sawtile; }
        }

        public List<SpikeTiles> SpikeTiles
        {
            get { return spikeTiles; }
        }

        public List<Inimigo> Inimigo
        {
            get { return inimigo; }
        }

        public List<Zombie> Zombie
        {
            get { return zombie; }
        }

        public List<Birb> Birb
        {
            get { return birb; }
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];

                    if (number > 0 && number != 13 && number != 14 && number != 15 && number != 17 && number != 18 && number != 19 && number != 20 && number != 21 && number != 25 && number != 22 && number != 23 && number != 24 && number != 26 && number != 28 && number != 30 && number != 32)
                        collisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));
                    else if (number == 13 || number == 14 || number == 15)
                        movingTiles.Add(new MovingTiles(number, new Rectangle(x * size, y * size, size, size), 120, false, true, 6));
                    else if (number == 17 || number == 18)
                        waterTiles.Add(new WaterTiles(number, new Rectangle(x * size, y * size, size, size)));
                    else if (number == 19)
                        doorTiles.Add(new DoorTiles(number, new Rectangle(x * size, y * size, size, size)));
                    else if (number == 20)
                        ExitTiles.Add(new ExitTiles(number, new Rectangle(x * size, y * size, size, size)));
                    else if (number == 21)
                        Sawtile.Add(new Sawtile(number, new Rectangle(x * size + size / 4, y * size + size / 4, size / 2, size / 2), 120, false, true));
                    else if (number == 22)
                        SpikeTiles.Add(new SpikeTiles(number, new Rectangle((x * size), y * size + size/2, size, size / 2)));
                    else if (number == 23)
                        SpikeTiles.Add(new SpikeTiles(number, new Rectangle((x * size), y * size, size / 2, size)));
                    else if (number == 24)
                        SpikeTiles.Add(new SpikeTiles(number, new Rectangle((x * size) + size / 2, y * size, size / 2, size)));
                    else if (number == 25)
                        SpikeTiles.Add(new SpikeTiles(number, new Rectangle((x * size) + size / 2, y * size, size, size / 2)));
                    else if (number == 26)
                        Inimigo.Add(new Inimigo(number, number + 1, 40, 30, new Rectangle(x * size, ((y * size)), size, size), 120, false, true, 100, 150));
                    else if (number == 28)
                        inimigo.Add(new Inimigo(number, number + 1, 60, 100, new Rectangle(x * size, ((y * size)), size, size), 120, false, true, 130, 0));
                    else if (number == 30)
                        Zombie.Add(new Zombie(number, number + 1, 60, 50, new Rectangle(x * size, ((y * size)), size, size), 120, false, true, 130, 50));
                    else if (number == 32)
                        Birb.Add(new Birb(number, new Rectangle(x * size, y * size, size, size / 2), 120, false, true, 3));
                    Width = (x + 1) * size;
                    Height = (y + 1) * size;
                }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionTiles tile in CollisionTiles)
                tile.Draw(spriteBatch);
            foreach (MovingTiles tile in MovingTiles)
                tile.Draw(spriteBatch);
            foreach (WaterTiles tile in WaterTiles)
                tile.Draw(spriteBatch);
            foreach (DoorTiles tile in DoorTiles)
                tile.Draw(spriteBatch);
            foreach (ExitTiles tile in ExitTiles)
                tile.Draw(spriteBatch);
            foreach (Sawtile tile in sawtile)
                tile.Draw(spriteBatch);
            foreach (SpikeTiles tile in SpikeTiles)
                tile.Draw(spriteBatch);
            foreach (Inimigo tile in Inimigo)
                tile.Draw(spriteBatch);
            foreach (Zombie tile in Zombie)
                tile.Draw(spriteBatch);
            foreach (Birb tile in Birb)
                tile.Draw(spriteBatch);
        }

    }
}
