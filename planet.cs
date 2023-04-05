using Raylib_cs;
using System.Numerics;

namespace planet{
    public class Planet{
        public int mass;
        public Vector2 pos;
        public Vector2 velocity;

        public Planet(int mass, Vector2 pos, Vector2 vel){
            this.mass = mass;
            this.pos = pos;
            this.velocity = vel;
        }


    }
}