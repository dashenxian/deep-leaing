using MachineLearing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPerceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<float, float> acitvation = (input) =>
            {
                if (input > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            };
            Perceptron p = new Perceptron(2, (input) =>
            {
                if (input > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            float[][] inputs = new float[][]
            {
                new float[]{1,1},
                new float[]{1,0 },
                new float[]{0,1},
                new float[]{0,0 }
            };
            float[] labels = new float[] { 1, 0, 0, 0 };
            p.Train(inputs, labels, 10, 0.1f);
            Console.WriteLine(p.ToString());
            Console.WriteLine("1 or 1:" + p.Predict(inputs[0]).ToString());
            Console.WriteLine("1 or 0:" + p.Predict(inputs[1]).ToString());
            Console.WriteLine("0 or 1:" + p.Predict(inputs[2]).ToString());
            Console.WriteLine("0 or 0:" + p.Predict(inputs[3]).ToString());
            Console.ReadKey();
        }
    }
}
