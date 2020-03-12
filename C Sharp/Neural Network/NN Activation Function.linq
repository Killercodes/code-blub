<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>Microsoft.Crm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Crm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Xrm.Sdk</Namespace>
  <Namespace>Microsoft.Xrm.Sdk</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Client</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Client</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Metadata</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Query</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Query</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Diagnostics.Tracing</Namespace>
  <Namespace>System.IO.Compression</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.ServiceModel.Description</Namespace>
  <Namespace>System.ServiceModel.Description</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Xml.Xsl</Namespace>
</Query>

void Main()
{
	string p1 = @"The demo program illustrates three common neural network activation functions: logistic sigmoid, hyperbolic tangent and softmax. 
	Using the logistic sigmoid activation function for both the input-hidden and hidden-output layers, the output values are 0.6395 and 0.6649. 
	The same inputs, weights and bias values yield outputs of 0.5006 and 0.5772 when the hyperbolic tangent activation function is used. 
	And the outputs when using the softmax activation function are 0.4725 and 0.5275.";
	
	string p2 = @"The neural network is defined in the DummyNeuralNetwork class. 
	You should be able to determine the meaning of the weight and bias class members. 
	For example, 
		class member ihWeights01 holds the weight value for input node 0 to hidden node 1. 	
		Member hoWeights10 holds the weight for hidden node 1 to output node 0.
		Member ihSum0 is the sum of the products of inputs and weights, plus the bias value, for hidden node 0, before an activation function has been applied. 
		Member ihResult0 is the value emitted from hidden node 0 after an activation function has been applied to ihSum0.";
	
	string sigmoid = @"
	In neural network literature, the most common activation function discussed is the logistic sigmoid function. 
	The function is also called log-sigmoid, or just plain sigmoid. The function is defined as:
		f(x) = 1.0 / (1.0 + e-x)
	The log-sigmoid function accepts any x value and returns a value between 0 and 1. 
	Values of x smaller than about -10 return a value very, very close to 0.0. Values of x greater than about 10 return a value very, very close to 1.

	Because the log-sigmoid function constrains results to the range (0,1), the function is sometimes said to be a squashing function in neural network literature. 
	It is the non-linear characteristics of the log-sigmoid function (and other similar activation functions) that allow neural networks to model complex data.

	The demo program implements the log-sigmoid function as:

	public double LogSigmoid(double x)
	{
	  if (x < -45.0) return 0.0;
	  else if (x > 45.0) return 1.0;
	  else return 1.0 / (1.0 + Math.Exp(-x));
	}
	
	In the early days of computing, arithmetic overflow and underflow were not always handled well by compilers, so input parameter checks like x < -45.0 were often used. 
	Although compilers are now much more robust, it's somewhat traditional to include such boundary checks in neural network activation functions.";
	
	
	Console.WriteLine(p1);
	
	try
      {
        Console.WriteLine("\n Begin neural network activation function demo\n");
        Console.WriteLine("Creating a 2-input, 2-hidden, 2-output node neural network");
        DummyNeuralNetwork dnn = new DummyNeuralNetwork();

        Console.WriteLine("Setting inputs to 1.0 and 2.0");
        double[] inputs = new double[] { 1.0, 2.0 };
        dnn.SetInputs(inputs);

        Console.WriteLine("Setting input-hidden weights to  0.01, 0.02, 0.03, 0.04");
        Console.WriteLine("Setting input-hidden biases to   0.3, 0.4");
        Console.WriteLine("Setting hidden-output weights to 0.05, 0.06, 0.07, 0.08");
        Console.WriteLine("Setting hidden-output biases to  0.5, 0.6");
         
        double[] weights = new double[] {0.01, 0.02, 0.03, 0.04,
          0.3, 0.4,
          0.05, 0.06, 0.07, 0.08,
          0.5, 0.6 };
        dnn.SetWeights(weights);

        Console.WriteLine("\nComputing outputs using Log-Sigmoid activation");
        dnn.ComputeOutputs("logsigmoid");
        Console.Write("- Log-Sigmoid NN outputs are: ");
        Console.Write(dnn.outputs[0].ToString("F4") + " & ");
        Console.WriteLine(dnn.outputs[1].ToString("F4"));

        Console.WriteLine("\n Computing outputs using Hyperbolic Tangent activation");
        dnn.ComputeOutputs("hyperbolictangent");
        Console.Write("- Hyperbolic Tangent NN outputs are: ");
        Console.Write(dnn.outputs[0].ToString("F4") + " & ");
        Console.WriteLine(dnn.outputs[1].ToString("F4"));

        Console.WriteLine("\n Computing outputs using Softmax activation");
        dnn.ComputeOutputs("softmax");
        Console.Write("- Softmax NN outputs are: ");
        Console.Write(dnn.outputs[0].ToString("F4") + " & ");
        Console.WriteLine(dnn.outputs[1].ToString("F4"));
 
        Console.WriteLine("\n" + p2);
        //Console.ReadLine();
		
		Console.WriteLine(sigmoid);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
      }
}

// Define other methods and classes here

public class DummyNeuralNetwork
{
    public double[] inputs;

    public double ihWeight00;
    public double ihWeight01;
    public double ihWeight10;
    public double ihWeight11;
    public double ihBias0;
    public double ihBias1;

    public double ihSum0;
    public double ihSum1;
    public double ihResult0;
    public double ihResult1;

    public double hoWeight00;
    public double hoWeight01;
    public double hoWeight10;
    public double hoWeight11;
    public double hoBias0;
    public double hoBias1;

    public double hoSum0;
    public double hoSum1;
    public double hoResult0;
    public double hoResult1;

    public double[] outputs;

    public DummyNeuralNetwork()
    {
      this.inputs = new double[2];
      this.outputs = new double[2];
    }

    public void SetInputs(double[] inputs)
    {
      inputs.CopyTo(this.inputs, 0);
    }

    public void SetWeights(double[] weightsAndBiases)
    {
      int k = 0;
      ihWeight00 = weightsAndBiases[k++];
      ihWeight01 = weightsAndBiases[k++];
      ihWeight10 = weightsAndBiases[k++];
      ihWeight11 = weightsAndBiases[k++];
      ihBias0 = weightsAndBiases[k++];
      ihBias1 = weightsAndBiases[k++];

      hoWeight00 = weightsAndBiases[k++];
      hoWeight01 = weightsAndBiases[k++];
      hoWeight10 = weightsAndBiases[k++];
      hoWeight11 = weightsAndBiases[k++];
      hoBias0 = weightsAndBiases[k++];
      hoBias1 = weightsAndBiases[k++];
    }

    public void ComputeOutputs(string activationType)
    {
      // Assumes this.inputs[] have values
      ihSum0 = (inputs[0] * ihWeight00) + (inputs[1] * ihWeight10);
      ihSum0 += ihBias0;
      ihSum1 = (inputs[0] * ihWeight01) + (inputs[1] * ihWeight11);
      ihSum1 += ihBias1;
      ihResult0 = Activation(ihSum0, activationType, "ih");
      ihResult1 = Activation(ihSum1, activationType, "ih");

      hoSum0 = (ihResult0 * hoWeight00) + (ihResult1 * hoWeight10);
      hoSum0 += hoBias0;
      hoSum1 = (ihResult0 * hoWeight01) + (ihResult1 * hoWeight11);
      hoSum1 += hoBias1;
      hoResult0 = Activation(hoSum0, activationType, "ho");
      hoResult1 = Activation(hoSum1, activationType, "ho");

      outputs[0] = hoResult0;
      outputs[1] = hoResult1;
    }

    public double Activation(double x, string activationType, string layer)
    {
      if (activationType == "logsigmoid")
        return LogSigmoid(x);
      else if (activationType == "hyperbolictangent")
        return HyperbolicTangtent(x);
      else if (activationType == "softmax")
        return SoftMax(x, layer);
      else
        throw new Exception("Not implemented");
    }

    public double LogSigmoid(double x)
    {
      if (x < -45.0) return 0.0;
      else if (x > 45.0) return 1.0;
      else return 1.0 / (1.0 + Math.Exp(-x));
    }

    public double HyperbolicTangtent(double x)
    {
      if (x < -45.0) return -1.0;
      else if (x > 45.0) return 1.0;
      else return Math.Tanh(x);
    }

    public double SoftMax(double x, string layer)
    {
      // Determine max
      double max = double.MinValue;
      if (layer == "ih")
        max = (ihSum0 > ihSum1) ? ihSum0 : ihSum1;
      else if (layer == "ho")
        max = (hoSum0 > hoSum1) ? hoSum0 : hoSum1;

      // Compute scale
      double scale = 0.0;
      if (layer == "ih")
        scale = Math.Exp(ihSum0 - max) + Math.Exp(ihSum1 - max);
      else if (layer == "ho")
        scale = Math.Exp(hoSum0 - max ) + Math.Exp(hoSum1 - max);

      return Math.Exp(x - max) / scale;
    }
  }