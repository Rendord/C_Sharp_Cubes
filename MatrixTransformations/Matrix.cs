using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        float[,] mat = new float[4, 4];
        
        public Matrix()
        {
            mat[0, 0] = 0; mat[0, 1] = 0; mat[0, 2] = 0; mat[0, 3] = 0;
            mat[1, 0] = 0; mat[1, 1] = 0; mat[1, 2] = 0; mat[1, 3] = 0;
            mat[2, 0] = 0; mat[2, 1] = 0; mat[2, 2] = 0; mat[2, 3] = 0;
            mat[3, 0] = 0; mat[3, 1] = 0; mat[3, 2] = 0; mat[3, 3] = 0;
        }

        public Matrix(float m11, float m12, float m13,
                      float m21, float m22, float m23,
                      float m31, float m32, float m33)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13; mat[0, 3] = 0;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23; mat[1, 3] = 0;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33; mat[2, 3] = 0;
            mat[3, 0] = 0; mat[3, 1] = 0; mat[3, 2] = 0; mat[3, 3] = 0;
        }

        public Matrix(Vector v)
        {
            mat[0, 0] = v.x; mat[0, 1] = 0; mat[0, 2] = 0; mat[0, 3] = 0;
            mat[1, 0] = v.y; mat[1, 1] = 0; mat[1, 2] = 0; mat[1, 3] = 0;
            mat[2, 0] = v.z; mat[2, 1] = 0; mat[2, 2] = 0; mat[2, 3] = 0;
            mat[3, 0] = v.t; mat[3, 1] = 0; mat[3, 2] = 0; mat[3, 3] = 0;
        }

        public Vector ToVector()
        {
            return new Vector(mat[0,0],mat[1,0],mat[2,0],mat[3,0]);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix(
            m1.mat[0, 0] + m2.mat[0, 0],
            m1.mat[0, 1] + m2.mat[0, 1],
            m1.mat[1, 0] + m2.mat[1, 0],
            m1.mat[1, 1] + m2.mat[1, 1]
            );
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return new Matrix(
            m1.mat[0, 0] - m2.mat[0, 0],
            m1.mat[0, 1] - m2.mat[0, 1],
            m1.mat[1, 0] - m2.mat[1, 0],
            m1.mat[1, 1] - m2.mat[1, 1]
            );
        }

        public static Matrix operator *(Matrix m1, float f)
        {
            return new Matrix(
            m1.mat[0, 0] * f,
            m1.mat[0, 1] * f,
            m1.mat[1, 0] * f,
            m1.mat[1, 1] * f
            ); 
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return new Matrix(
            m1.mat[0, 0] * f,
            m1.mat[0, 1] * f,
            m1.mat[1, 0] * f,
            m1.mat[1, 1] * f
            );
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return new Matrix(
            (m1.mat[0, 0] * m2.mat[0, 0]) + (m1.mat[0, 1] * m2.mat[1, 0]),
            (m1.mat[0, 0] * m2.mat[0, 1]) + (m1.mat[0, 1] * m2.mat[1, 1]),
            (m1.mat[1, 0] * m2.mat[0, 0]) + (m1.mat[1, 1] * m2.mat[1, 0]),
            (m1.mat[1, 0] * m2.mat[0, 1]) + (m1.mat[1, 1] * m2.mat[1, 1])
            );
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Matrix m2 = new Matrix(v);
            Matrix m3 = new Matrix(
            (m1.mat[0, 0] * m2.mat[0, 0]) + (m1.mat[0, 1] * m2.mat[1, 0]),
            (m1.mat[0, 0] * m2.mat[0, 1]) + (m1.mat[0, 1] * m2.mat[1, 1]),
            (m1.mat[1, 0] * m2.mat[0, 0]) + (m1.mat[1, 1] * m2.mat[1, 0]),
            (m1.mat[1, 0] * m2.mat[0, 1]) + (m1.mat[1, 1] * m2.mat[1, 1])
            );

            return m3.ToVector();
        }

        public static Matrix Identity()
        {
            return new Matrix(1,0,0,1);
        }

        public static Matrix ScaleMatrix(float s)
        {
            return new Matrix(s, 0, 0, s);
        }

        public static Matrix RotateMatrix(float degrees)
        {
            double radians = degrees * (Math.PI / 180);
            return new Matrix((float)Math.Cos(radians), (float)-Math.Sin(radians), (float)Math.Cos(radians), (float)Math.Sin(radians));
        }

        public override string ToString()
        {
            return "";
        }
    }
}
