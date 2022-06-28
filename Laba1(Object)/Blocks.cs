using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Object_
{
    public abstract class BaseBlock // базовое звено
    {
        public abstract double Transfer(double x);
        public abstract void Reset();
    }

    public class GainBlock : BaseBlock // пропорциональное звено
    {
        public double Gain { get; set; }

        public GainBlock(double gain)
        {
            this.Gain = gain;
        }

        public override double Transfer(double x)
        {
            return this.Gain * x;
        }
        public override void Reset() { }
    }

    public class IntegralBlock : BaseBlock // интегральное звено
    {
        public double dt { get; set; }
        private double i1;
        private double x1;
        private double ti;
        private Limit limit;

        public double I1
        {
            get
            {
                return i1;
            }
            set
            {
                i1 = value;
            }
        }
        public double X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }
        public double Ti
        {
            get
            {
                return ti;
            }
            set
            {
                ti = value;
            }
        }

        public IntegralBlock(double dt, double ti, double min, double max)
        {
            this.dt = dt;
            this.ti = ti;
            limit = new Limit(min, max);
            x1 = 0;
            i1 = 0;
        }

        public override double Transfer(double x)
        {
            i1 = limit.Transfer(i1 + ti * dt * (x + x1) / 2);
            x1 = x;
            return i1;
        }

        public override void Reset()
        {
            i1 = 0;
            x1 = 0;
        }
    }

    public class AperiodicBlock : BaseBlock //аппериодическое звено
    {
        private Limit limit;
        public double T { get; set; }
        public double dt { get; set; }
        private double y1;

        public AperiodicBlock(double dt, double t, double min, double max)
        {
            limit = new Limit(min, max);
            this.dt = dt;
            this.T = t;
            y1 = 0;
        }

        public override double Transfer(double x)
        {
            y1 = limit.Transfer((x * dt + T * y1) / (T + dt));
            return y1;
        }

        public override void Reset()
        {
            y1 = 0;
        }
    }

    public class DiffBlock : BaseBlock
    {
        private double dt;
        private double prev;
        private double t;
        public double T
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
            }
        }
        public DiffBlock(double dt, double T)
        {
            this.dt = dt;
            t = T;
        }
        public override double Transfer(double x)
        {
            double y = t * (x - prev) / dt;
            prev = x;
            return y;
        }
        public override void Reset()
        {
            prev = 0;
        }
    }

    public class DelayBlock : BaseBlock //звено запаздывания
    {
        public double time { get; set; }
        public double dt { get; set; }
        private int cnt;
        private Queue<double> buff;

        public DelayBlock(double time, double dt)
        {
            this.time = time;
            this.dt = dt;
            cnt = (int)(time / dt);
            buff = new Queue<double>();
        }

        public override double Transfer(double x)
        {
            buff.Enqueue(x);
            if (buff.Count < cnt)
            {
                return 0;
            }
            else
            {
                return buff.Dequeue();
            }
        }

        public override void Reset()
        {
            buff.Clear();
            time = 0;
        }
    }

    public class Noise : BaseBlock //Шум
    {
        private double noise { get; set; }
        private Random rand;

        public Noise(double noise)
        {
            this.noise = noise;
            rand = new Random();
        }
        public override double Transfer(double x)
        {
            var nn = x * noise / 100;
            return x + 2 * nn * rand.NextDouble() - nn;
        }
        public override void Reset() { }
    }
    public class Limit : BaseBlock
    {
        private double min;
        private double max;
        public Limit(double min, double max)
        {
            this.min = min;
            this.max = max;
        }
        public override double Transfer(double x)
        {
            var y = x < min ? min : x;
            return y > max ? max : y;
        }

        public override void Reset() { }
    }

    public class Sum : BaseBlock
    {
        private string digits;
        private double d;
        private double input2;

        public Sum(ref double in2, string dig)
        {
            input2 = in2;
            digits = dig;
        }

        public override double Transfer(double x)
        {
            double x1 = x;
            ref double x2 = ref input2;
            if (digits[0] == '-')
            {
                x1 = -x1;
            }
            if (digits[1] == '-')
            {
                x2 = -x2;
            }
            return x1 + x2;
        }

        public override void Reset() { }
    }

    public class PID : BaseBlock
    {
        private double kp;
        private double ti;
        private double td;
        private double b;
        private double c;
        private double um;
        public bool IsManual;
        private List<BaseBlock> blocks;
        private AperiodicBlock kpDemppher;
        private AperiodicBlock tiDemppher;
        private AperiodicBlock tdDemppher;

        public double Um
        {
            get
            {
                return um;
            }
            set
            {
                um = value;
            }
        }

        public PID(double dt, double Kp = 1, double Ti = 1, double Td = 1, double b = 1, double c = 1)
        {
            kp = Kp;
            ti = Ti;
            td = Td;
            this.b = b;
            this.c = c;
            blocks = new List<BaseBlock>();
            blocks.Add(new GainBlock(1));
            blocks.Add(new IntegralBlock(dt, ti, -100, 100));
            blocks.Add(new DiffBlock(dt, td));
            kpDemppher = new AperiodicBlock(dt, 100, 0, 100);
            tiDemppher = new AperiodicBlock(dt, 100, 0, 100);
            tdDemppher = new AperiodicBlock(dt, 100, 0, 100);
            IsManual = false;
        }
        public double Kp
        {
            get
            {
                return kp;
            }
            set
            {
                kp = value;
            }
        }
        public double Ti
        {
            get
            {
                return ti;
            }
            set
            {
                ti = value;
            }
        }
        public double Td
        {
            get
            {
                return td;
            }
            set
            {
                td = value;
            }
        }

        public override double Transfer(double x)
        {
            double kpDemp = kpDemppher.Transfer(kp);
            double tiDemp = tiDemppher.Transfer(ti);
            double tdDemp = tdDemppher.Transfer(td);
            (blocks[0] as GainBlock).Gain = kpDemp;
            (blocks[1] as IntegralBlock).Ti = tiDemp;
            (blocks[2] as DiffBlock).T = tdDemp;
            double y = 0;
            y += blocks[0].Transfer(x * b);
            y += blocks[2].Transfer(x);
            if (IsManual)
            {
                (blocks[1] as IntegralBlock).I1 = um / kpDemp - y;
                (blocks[1] as IntegralBlock).X1 = x;
                y += (blocks[1] as IntegralBlock).I1;
            }
            else
            {
                y += blocks[1].Transfer(x * c);
            }
            y *= kpDemp;
            return y;
        }

        public void RewriteConfig(double[] K)
        {
            if (K.Length == 3)
            {
                Kp = K[0];
                Ti = K[1];
                Td = K[2];
            }
            else
            {
                throw new Exception("Wrong length");
            }
        }

        public double[] GetConfig()
        {
            double[] ret = new double[3];
            ret[0] = Kp;
            ret[1] = Ti;
            ret[2] = Td;
            return ret;
        }

        public override void Reset()
        {
            foreach (var b in blocks)
            {
                b.Reset();
            }
        }
    }
}
