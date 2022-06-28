using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Object_
{
    public class Simplex
    {
        private int PROCESS_TIME = 200;
        private double EPSILON = 0.00001;
        private int CYCLE_ITERATION_COUNT = 20;

        public List<Vector> Vertex;

        public Simplex()
        {
            Vertex = new List<Vector>();
        }

        private Vector CenterOfMass(int i)
        {
            Vector center = new Vector(Vertex[0].Transform.N);
            for (int j = 0; j < center.Transform.N; j++)
            {
                if (i != j)
                    center += Vertex[j];
            }
            return center / Vertex.Count;
        }

        private void SetRegularSimplex(Vector center, double a = 1) //пока что только для построения в первых 3 измерениях
        {
            int dimenCnt = Vertex[0].Transform.N; //Количество измерений
            if (center.Transform.N != dimenCnt)
                throw new Exception("Wrong coordinates");
            List<Matrix> rotMatrixes = new List<Matrix>();
            for (int k = 0; k < dimenCnt; k++)//Создание матрицы поворота на рандомный угол вокруг всех осей
            {
                Vector vector = new Vector(dimenCnt);
                double ang = new Random().NextDouble() * 360;
                for (int i = 0; i < dimenCnt; i++)
                    if (i == k)
                        vector[i] = 1;
                    else
                        vector[i] = 0;
                rotMatrixes.Add(new Matrix(dimenCnt, dimenCnt));
                rotMatrixes[k].ProcessFunctionOverData((i, j) =>
                {
                    if (i == j)
                    {
                        double cos = Math.Cos(ang);
                        rotMatrixes[k][i, j] = cos + (1 - cos) * Math.Pow(vector[i], 2);
                    }
                    else
                    {
                        double cos = Math.Cos(ang);
                        double sin = Math.Sin(ang);
                        rotMatrixes[k][i, j] = (1 - cos) * vector[i] * vector[j] + sin * ((i + j) % 2 != 0 ? 1 : -1) * vector[k];
                    }
                });

            }
            Vertex[0] = center;
            Vertex[1] = Vertex[0] + new Vector(new double[] { a, 0, 0 });
            if (dimenCnt >= 3)
            {
                Vertex[2].Transform[0, 0] = 0.5 * a;
                Vertex[2].Transform[0, 1] = Math.Sqrt(3) / 2 * a;
                Vertex[2].Transform[0, 2] = 0;
            }
            if (dimenCnt == 4)
            {
                Vertex[3].Transform[0, 0] = 0.5 * a;
                Vertex[3].Transform[0, 1] = Math.Sqrt(3) / 6 * a;
                Vertex[3].Transform[0, 2] = Math.Sqrt(6) / 3 * a;
            }
            //for (int i = 0; i < dimenCnt; i++)
            //{
            //    for (int j = 0; j < rotMatrixes.Count; j++)
            //    {
            //        Vertex[i].Transform = Vertex[i].Transform * rotMatrixes[j];
            //    }
            //}
        }

        public double[] Calc(double[] Base, double[,] Limits, bool isFindMin = true)
        {
            for (int i = 0; i <= Base.Length; i++)
                Vertex.Add(new Vector(Base.Length));
            SetRegularSimplex(new Vector(Base), 0.5);
            double e0 = 0;
            double e1 = 0;
            int iter = 0;
            int searchedIndex = 0;
            double multiplier = 1;
            do
            {
                e1 = e0;
                int index = isFindMin ? FindMaxPointIndex() : FindMinPointIndex();
                if (iter > CYCLE_ITERATION_COUNT)
                    multiplier = 0.9;
                RebaseVertex(index, multiplier, Limits);
                multiplier = 1;
                searchedIndex = !isFindMin ? FindMinPointIndex() : FindMaxPointIndex();
                e0 = Func(Vertex[searchedIndex]);
                iter++;
            }
            while (Math.Abs(e0 - e1) > EPSILON);
            return Vertex[searchedIndex].ToArray();
        }

        private void RebaseVertex(int i, double multiplier, double[,] limits)
        {
            if (i >= 0 && i < Vertex.Count)
            {
                Vector center = CenterOfMass(i);
                Vector vec = center - Vertex[i];
                Vector newVertex;
                while (!ConfigInArrange(center + (vec * multiplier), limits))
                {
                    multiplier *= 0.9;
                }
                Vertex[i] = center + (vec * multiplier);
            }
            else
                throw new IndexOutOfRangeException();
        }

        private int FindMaxPointIndex()
        {
            int index = 0;
            double e = double.Epsilon;
            for (int i = 0; i < Vertex.Count; i++)
            {
                double newE = Func(Vertex[i]);
                if (Math.Abs(e) < Math.Abs(newE))
                {
                    index = i;
                    e = newE;
                }
            }
            return index;
        }

        private int FindMinPointIndex()
        {
            int index = 0;
            double e = double.MaxValue;
            for (int i = 0; i < Vertex.Count; i++)
            {
                double newE = Func(Vertex[i]);
                if (Math.Abs(e) < Math.Abs(newE))
                {
                    index = i;
                    e = newE;
                }
            }
            return index;
        }

        private double Func(Vector config)
        {
            double dt = 1;
            ObjectModel_MySystem_ system = new ObjectModel_MySystem_(dt);
            system.Regulator.Kp = config[0];
            system.Regulator.Ti = config[1];
            system.Regulator.Td = config[2];
            system.Zadanie = 1;
            double ret = 0;
            for (int i = 0; i < PROCESS_TIME; i++)
                ret += Math.Pow(1 - system.GetValue(), 2) * dt;
            return Math.Sqrt(ret);
        }

        private bool ConfigInArrange(Vector config, double[,] limits)
        {
            bool flag = true;
            for (int i = 0; i < config.Transform.N; i++)
            {
                if (!(config[i] >= limits[0, i] && config[i] <= limits[1, i]))
                    flag = false;
            }
            return flag;
        }
    }

    public class Vector
    {
        public Matrix Transform;

        public double Lenght
        {
            get
            {
                double ret = 0;
                for (int i = 0; i < Transform.N; i++)
                {
                    ret += Math.Pow(Transform[0, i], 2);
                }
                return Math.Sqrt(ret);

            }
        }

        public Vector Normalize
        {
            get
            {
                Vector normalized = new Vector(Transform.N);
                for (int i = 0; i < Transform.N; i++)
                {
                    normalized[i] = this[i] / Lenght;
                }
                return normalized;
            }
        }

        public Vector(int Size)
        {
            Transform = new Matrix(1, Size);
        }

        public Vector(double[] vs)
        {
            Transform = new Matrix(1, vs.Length);
            for (int i = 0; i < vs.Length; i++)
            {
                Transform[0, i] = vs[i];
            }
        }

        public double this[int index]
        {
            get
            {
                if (index > -1 && index < Transform.N)
                    return Transform[0, index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Transform.N)
                    Transform[0, index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public double[] ToArray()
        {
            double[] array = new double[Transform.N];
            for (int i = 0; i < Transform.N; i++)
            {
                array[i] = this[i];
            }
            return array;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if (v1.Transform.N != v2.Transform.N)
            {
                throw new Exception("Size isn't equal");
            }
            Vector ret = new Vector(v1.Transform.N);
            for (int i = 0; i < ret.Transform.N; i++)
            {
                ret[i] = v1[i] + v2[i];
            }
            return ret;
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if (v1.Transform.N != v2.Transform.N)
            {
                throw new Exception("Size isn't equal");
            }
            Vector ret = new Vector(v1.Transform.N);
            for (int i = 0; i < ret.Transform.N; i++)
            {
                ret[i] = v1[i] - v2[i];
            }
            return ret;
        }

        public static Vector operator *(Vector v1, double value)
        {
            if (value == 0)
                throw new DivideByZeroException();
            Vector ret = new Vector(v1.Transform.N);
            for (int i = 0; i < ret.Transform.N; i++)
            {
                ret[i] = v1[i] * value;
            }
            return ret;
        }

        public static Vector operator /(Vector v1, double value)
        {
            if (value == 0)
                throw new DivideByZeroException();
            Vector ret = new Vector(v1.Transform.N);
            for (int i = 0; i < ret.Transform.N; i++)
            {
                ret[i] = v1[i] / value;
            }
            return ret;
        }
    }
}
