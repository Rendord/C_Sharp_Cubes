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

        public Matrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34,
                      float m41, float m42, float m43, float m44)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13; mat[0, 3] = m14;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23; mat[1, 3] = m24;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33; mat[2, 3] = m34;
            mat[3, 0] = m41; mat[3, 1] = m42; mat[3, 2] = m43; mat[3, 3] = m44;
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
            return new Vector(mat[0,0],mat[1,0],mat[2,0]);
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix(
            m1.mat[0, 0] + m2.mat[0, 0], m1.mat[0, 1] + m2.mat[0, 1], m1.mat[0, 2] + m2.mat[0, 2],
            m1.mat[1, 0] + m2.mat[1, 0], m1.mat[1, 1] + m2.mat[1, 1], m1.mat[1, 2] + m2.mat[1, 2],
            m1.mat[2, 0] + m2.mat[2, 0], m1.mat[2, 1] + m2.mat[2, 1], m1.mat[2, 2] + m2.mat[2, 2]

            );
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return new Matrix(
            m1.mat[0, 0] - m2.mat[0, 0], m1.mat[0, 1] - m2.mat[0, 1], m1.mat[0, 2] - m2.mat[0, 2], 
            m1.mat[1, 0] - m2.mat[1, 0], m1.mat[1, 1] - m2.mat[1, 1], m1.mat[1, 2] - m2.mat[1, 2],
            m1.mat[2, 0] - m2.mat[2, 0], m1.mat[2, 1] - m2.mat[2, 1], m1.mat[2, 2] - m2.mat[2, 2]

            );
        }

        public static Matrix operator *(Matrix m1, float f)
        {
            return new Matrix(
            m1.mat[0, 0] * f, m1.mat[0, 1] * f, m1.mat[0, 2] * f, 
            m1.mat[1, 0] * f, m1.mat[1, 1] * f, m1.mat[1, 2] * f,
            m1.mat[2, 0] * f, m1.mat[2, 1] * f, m1.mat[2, 2] * f

            ); 
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return new Matrix(
            m1.mat[0, 0] * f, m1.mat[0, 1] * f, m1.mat[0, 2] * f,
            m1.mat[1, 0] * f, m1.mat[1, 1] * f, m1.mat[1, 2] * f,
            m1.mat[2, 0] * f, m1.mat[2, 1] * f, m1.mat[2, 2] * f
            );
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            return new Matrix(

            //-----------------------------------------------------------row 1------------------------------------------------------------            
            // [0,0]
            (m1.mat[0, 0] * m2.mat[0, 0]) + (m1.mat[0, 1] * m2.mat[1, 0]) + (m1.mat[0, 2] * m2.mat[2, 0]) + (m1.mat[0, 3] * m2.mat[3, 0]), 

            //[0,1]
            (m1.mat[0, 0] * m2.mat[0, 1]) + (m1.mat[0, 1] * m2.mat[1, 1]) + (m1.mat[0, 2] * m2.mat[2, 1]) + (m1.mat[0, 3] * m2.mat[3, 1]),

            //[0,2]
            (m1.mat[0, 0] * m2.mat[0, 2]) + (m1.mat[0, 1] * m2.mat[1, 2]) + (m1.mat[0, 2] * m2.mat[2, 2]) + (m1.mat[0, 3] * m2.mat[3, 2]),

            //[0,3]
            (m1.mat[0, 0] * m2.mat[0, 3]) + (m1.mat[0, 1] * m2.mat[1, 3]) + (m1.mat[0, 2] * m2.mat[2, 3]) + (m1.mat[0, 3] * m2.mat[3, 3]),

            //-----------------------------------------------------------row 2------------------------------------------------------------            
            // [1,0]
            (m1.mat[1, 0] * m2.mat[0, 0]) + (m1.mat[1, 1] * m2.mat[1, 0]) + (m1.mat[1, 2] * m2.mat[2, 0]) + (m1.mat[1, 3] * m2.mat[3, 0]),

            //[1,1]
            (m1.mat[1, 0] * m2.mat[0, 1]) + (m1.mat[1, 1] * m2.mat[1, 1]) + (m1.mat[1, 2] * m2.mat[2, 1]) + (m1.mat[1, 3] * m2.mat[3, 1]),

            //[1,2]
            (m1.mat[1, 0] * m2.mat[0, 2]) + (m1.mat[1, 1] * m2.mat[1, 2]) + (m1.mat[1, 2] * m2.mat[2, 2]) + (m1.mat[1, 3] * m2.mat[3, 2]),

            //[1,3]
            (m1.mat[1, 0] * m2.mat[0, 3]) + (m1.mat[1, 1] * m2.mat[1, 3]) + (m1.mat[1, 2] * m2.mat[2, 3]) + (m1.mat[1, 3] * m2.mat[3, 3]),

            //-----------------------------------------------------------row 3------------------------------------------------------------            
            // [2,0]
            (m1.mat[2, 0] * m2.mat[0, 0]) + (m1.mat[2, 1] * m2.mat[1, 0]) + (m1.mat[2, 2] * m2.mat[2, 0]) + (m1.mat[2, 3] * m2.mat[3, 0]),

            //[2,1]
            (m1.mat[2, 0] * m2.mat[0, 1]) + (m1.mat[2, 1] * m2.mat[1, 1]) + (m1.mat[2, 2] * m2.mat[2, 1]) + (m1.mat[2, 3] * m2.mat[3, 1]),

            //[2,2]
            (m1.mat[2, 0] * m2.mat[0, 2]) + (m1.mat[2, 1] * m2.mat[1, 2]) + (m1.mat[2, 2] * m2.mat[2, 2]) + (m1.mat[2, 3] * m2.mat[3, 2]),

            //[2,3]
            (m1.mat[2, 0] * m2.mat[0, 3]) + (m1.mat[2, 1] * m2.mat[1, 3]) + (m1.mat[2, 2] * m2.mat[2, 3]) + (m1.mat[2, 3] * m2.mat[3, 3]),

            //-----------------------------------------------------------row 4------------------------------------------------------------            
            // [3,0]
            (m1.mat[3, 0] * m2.mat[0, 0]) + (m1.mat[3, 1] * m2.mat[1, 0]) + (m1.mat[3, 2] * m2.mat[2, 0]) + (m1.mat[3, 3] * m2.mat[3, 0]),

            //[3,1]
            (m1.mat[3, 0] * m2.mat[0, 1]) + (m1.mat[3, 1] * m2.mat[1, 1]) + (m1.mat[3, 2] * m2.mat[2, 1]) + (m1.mat[3, 3] * m2.mat[3, 1]),

            //[3,2]
            (m1.mat[3, 0] * m2.mat[0, 2]) + (m1.mat[3, 1] * m2.mat[1, 2]) + (m1.mat[3, 2] * m2.mat[2, 2]) + (m1.mat[3, 3] * m2.mat[3, 2]),

            //[3,3]
            (m1.mat[3, 0] * m2.mat[0, 3]) + (m1.mat[3, 1] * m2.mat[1, 3]) + (m1.mat[3, 2] * m2.mat[2, 3]) + (m1.mat[3, 3] * m2.mat[3, 3])
            );
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Matrix m2 = new Matrix(v);
            Matrix m3 = m1 * m2;

            return m3.ToVector();
        }

        public static Matrix Identity()
        {
            return new Matrix(1,0,0,0,
                              0,1,0,0,
                              0,0,1,0,
                              0,0,0,1);
        }

        public static Matrix ScaleMatrix(float s)
        {
            return new Matrix(s, 0, 0, 0,
                              0, s, 0, 0,
                              0, 0, s, 0,
                              0, 0, 0, 1);
        }

        public static Matrix TranslationMatrix(Vector t)
        {
            return new Matrix(1, 0, 0, t.x,
                              0, 1, 0, t.y,
                              0, 0, 1, t.z,
                              0, 0, 0, 1);
        }

        public static Matrix RotateMatrixZ(float degrees)
        {
            double radians = degrees * (Math.PI / 180);
            return new Matrix(
                (float)Math.Cos(radians), (float)Math.Sin(-radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }
        public static Matrix RotateMatrixX(float degrees)
        {
            double radians = degrees * (Math.PI / 180);
            return new Matrix(
                1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(-radians), 0, 
                0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        public static Matrix RotateMatrixY(float degrees)
        {
            double radians = degrees * (Math.PI / 180);
            return new Matrix(
                (float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
                -(float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        public static Matrix ViewMatrix(float theta, float phi, float r)
        {
            double _theta = theta * (Math.PI / 180);
            double _phi = phi * (Math.PI / 180);
            return new Matrix(

                  (float)-Math.Sin(_theta), (float)Math.Cos(_theta), 0, 0,
                  (float)-Math.Cos(_theta) * (float)Math.Cos(_phi), -(float)Math.Cos(_phi) * (float)Math.Sin(_theta), (float)Math.Sin(_phi), 0,
                  (float)Math.Cos(_theta) * (float)Math.Sin(_phi), (float)Math.Sin(_theta) * (float)Math.Sin(_phi), (float)Math.Cos(_phi), -r,
                  0, 0, 0, 1
                  
                  );
        }

        public static Matrix ProjectionMatrix(float depth, Vector t)
        {
            return new Matrix(
                  -(depth/t.z), 0, 0, 0,
                  0, -(depth/t.z), 0, 0,
                  0, 0, 1, 0,
                  0, 0, 0, 1
                  );
        }

        public override string ToString()
        {
            string array = "";
            for(int i1 = 0; i1 < mat.GetLength(0); i1++)
            {
                for(int i2 = 0; i2 < mat.GetLength(1); i2++)
                {
                    array += " " + mat[i1, i2];
                }
                array += "\n";
            }
            return array;
        }
    }
}
