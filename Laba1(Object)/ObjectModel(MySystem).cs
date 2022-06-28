using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_Object_
{
    class ObjectModel_MySystem_
    {
        private const float HEIGHT_OF_TANK = 30f;

        private bool isManual;
        private PID regulator;
        private double dt;
        private double input1;
        private double input2;
        private double zadanie;
        private double zbur;
        private double pid;
        private double output;

        public List<BaseBlock> blocks;
        public List<BaseBlock> gainBlocks;

        public double Output
        {
            get
            {
                return output;
            }
            set
            {
                output = value;
            }
        }
        public bool IsManual
        {
            get
            {
                return isManual;
            }
            set
            {
                isManual = value;
                if (regulator != null)
                {
                    regulator.IsManual = value;
                }
            }
        }
        public PID Regulator
        {
            get
            {
                return regulator;
            }
            set
            {
                regulator = value;
            }
        }
        public double Time { get; set; }
        public double Input1 { get
            {
                return input1;
            }
            set
            {
                var y = value < 0f ? 0f : value;
                input1 = y > 100f ? 100f : y;
            }
        }
        public double Input2
        {
            get
            {
                return input2;
            }
            set
            {
                var y = value < 0f ? 0f : value;
                input2 = y > 100f ? 100f : y;
            }
        }
        public double Zadanie
        {
            get
            {
                return zadanie;
            }
            set
            {
                var y = value < 0f ? 0f : value;
                zadanie = y > 100f ? 100f : y;
            }

        }
        public double Pid
        {
            get
            {
                return pid;
            }
        }

        public ObjectModel_MySystem_(double dt)
        {
            blocks = new List<BaseBlock>();
            blocks.Add(new GainBlock(1));
            blocks.Add(new AperiodicBlock(dt, 5, 0, HEIGHT_OF_TANK));
            blocks.Add(new DelayBlock(4,dt));
            blocks.Add(new Noise(0.5f));
            blocks.Add(new Limit(0f, HEIGHT_OF_TANK));

            regulator = new PID(dt, 1.3, 0.15, 0);

            gainBlocks = new List<BaseBlock>();
            gainBlocks.Add(new GainBlock(1));
            gainBlocks.Add(new GainBlock(0.2));
            gainBlocks.Add(new GainBlock(15));

            Zadanie = 1;
            Time = dt;
            pid = 0;
            this.dt = dt;
        }

        public double GetValue()
        {
            double u = 0;
            if (!IsManual && regulator != null)
            {
                Input1 = pid;
            }
            u =  gainBlocks[0].Transfer(Input1) + gainBlocks[1].Transfer(Input2) - gainBlocks[2].Transfer(1);
            var y = u;
            foreach (var b in blocks)
            {
                y = b.Transfer(y);
            }
            if (regulator != null)
            {
                regulator.Um = Input1;
                pid = regulator.Transfer(zadanie - Output);
            }
            Time += dt;
            Output = y;
            return y;
        }

        public void Reset()
        {
            foreach (var b in blocks)
            {
                b.Reset();
            }
            if (regulator != null)
            {
                regulator.Reset();
            }
            Time = dt;
            Output = 0;
        }
    }
}
