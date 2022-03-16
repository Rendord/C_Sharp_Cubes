using System;
using System.Text;

namespace MatrixTransformations
{
    public class Vector
    {
        public float x, y, z, t;

        public Vector()
        {

        }

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            t = 1;
        }

        public static Vector operator +(Vector v1, Vector v2) //addition
        {
            float x = v1.x + v2.x;
            float y = v1.y + v2.y;
            float z = v1.z + v2.z;
            return new Vector(x,y,z);
        }

        public static Vector operator -(Vector v1, Vector v2) //subtraction
        {
            float x = v1.x - v2.x;
            float y = v1.y - v2.y;
            float z = v1.z - v2.z;
            return new Vector(x, y, z);
        }

        public static Vector operator *(Vector v1, Vector v2) //vector multiplication
        {
            float x = v1.x * v2.x;
            float y = v1.y * v2.y;
            float z = v1.z * v2.z;
            return new Vector(x, y, z);
        }

        public static Vector operator *(float v1, Vector v2) //scalar multiplation
        {
            float x = v1 * v2.x;
            float y = v1 * v2.y;
            float z = v1 * v2.z;
            return new Vector(x, y, z);
        }


        public override string ToString()
        {
            return "x: " + x + "y: " + y + "z: " + z;
        }
    }
}
