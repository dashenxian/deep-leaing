using System;
using System.Text;

namespace MachineLearing
{
    public class Perceptron
    {
        /// <summary>
        /// 偏置项
        /// </summary>
        float bais;
        /// <summary>
        /// 权重
        /// </summary>
        float[] waights;
        /// <summary>
        /// 激活函数
        /// </summary>
        Func<float, float> activation;
        public Perceptron(int waightsCout, Func<float, float> activation)
        {
            waights = new float[waightsCout];
            this.activation = activation;
        }
        /// <summary>
        /// 预测
        /// </summary>
        /// <param name="inputs">输入向量</param>
        /// <returns></returns>
        public float Predict(float[] inputs)
        {
            int count = Math.Min(waights.Length, inputs.Length);
            float sum = 0;
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                sum += waights[i] * inputs[i];
            }
            sum += bais;
            return activation(sum);
        }
        /// <summary>
        /// 训练
        /// </summary>
        /// <param name="inputs">输入向量数组</param>
        /// <param name="labels">结果数组</param>
        /// <param name="interation">训练次数</param>
        /// <param name="rate">学习速率</param>
        public void Train(float[][] inputs, float[] labels, int interation, float rate)
        {
            for (int i = 0; i < interation; i++)
            {
                oneTrain(inputs, labels, rate);
            }
        }
        /// <summary>
        /// 单次训练
        /// </summary>
        /// <param name="inputs">输入向量数组</param>
        /// <param name="labels">结果数组</param>
        /// <param name="rate">学习速率</param>
        private void oneTrain(float[][] inputs, float[] labels, float rate)
        {
            for (int i = 0; i < inputs.GetLength(0); i++)
            {
                UpdateWaights(inputs[i], labels[i], rate);
            }
        }
        /// <summary>
        /// 更新权重和偏置项
        /// </summary>
        /// <param name="inputs">输入向量</param>
        /// <param name="labels">结果数组</param>
        /// <param name="rate">学习速率</param>
        private void UpdateWaights(float[] inputs, float label, float rate)
        {
            float result = Predict(inputs);
            int count = Math.Min(waights.Length, inputs.Length);
            for (int i = 0; i < waights.Length; i++)
            {
                waights[i] += rate * (label - result) * inputs[i];
            }
            bais += rate * (label - result);
        }
        /// <summary>
        /// 输出权重和偏置项
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(50);
            sb.AppendLine("Waights:");
            foreach (var waight in waights)
            {
                sb.AppendLine(waight.ToString());
            }
            sb.Append("bais:").AppendLine(bais.ToString());
            return sb.ToString();
        }
    }
}
