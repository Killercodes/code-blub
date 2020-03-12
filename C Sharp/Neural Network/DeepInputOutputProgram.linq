<Query Kind="Program" />

void Main()
{

	Console.WriteLine("Deep Neural Network IO Using C#\n https://msdn.microsoft.com/magazine/mt493293 \n\nBegin deep net IO demo \n");

      Console.WriteLine("Creating a 2-(4-2-2)-3 deep neural network ");
      int numInput = 2;
      int[] numHidden = new int[] { 4, 2, 2 }; // 3 hidden layers implied
      int numOutput = 3;
      DeepNet dn = new DeepNet(numInput, numHidden, numOutput);

      int nw = DeepNet.NumWeights(numInput, numHidden, numOutput);
      Console.WriteLine("Setting weights and biases to 0.01 to " + (nw/100.0).ToString("F2") );
      double[] wts = new double[nw];
      for (int i = 0; i < wts.Length; ++i)
        wts[i] = (i + 1) * 0.01;  // [0.01, 0.02, . . 0.37]
      dn.SetWeights(wts);  // weights + biases

      Console.WriteLine("\nComputing output values for input = [1.0, 2.0] \n");
      double[] xValues = new double[] { 1.0, 2.0 };
      dn.ComputeOutputs(xValues);
      dn.Dump(false);  // don't show weights

      Console.WriteLine("\nEnd demo \n");
      Console.ReadLine();
}

// Define other methods and classes here
public class DeepNet
  {
    public static Random rnd;  // weight init and train shuffle

    public int nInput;  // number input nodes
    public int[] nHidden;  // number hidden nodes, each layer
    public int nOutput;  // number output nodes
    public int nLayers;  // number hidden node layers

    public double[] iNodes;  // input nodes
    public double [][] hNodes;
    public double[] oNodes;

    public double[][] ihWeights;  // input- 1st hidden
    public double[][][] hhWeights; // hidden-hidden
    public double[][] hoWeights;  // last hidden-output

    public double[][] hBiases;  // hidden node biases
    public double[] oBiases;  // output node biases

    public DeepNet(int numInput, int[] numHidden, int numOutput)
    {
      rnd = new Random(0);  // seed could be a ctor parameter

      this.nInput = numInput;
      this.nHidden = new int[numHidden.Length];
      for (int i = 0; i < numHidden.Length; ++i)
        this.nHidden[i] = numHidden[i];
      this.nOutput = numOutput;
      this.nLayers = numHidden.Length;

      iNodes = new double[numInput];
      hNodes = MakeJaggedMatrix(numHidden);
      oNodes = new double[numOutput];

      ihWeights = MakeMatrix(numInput, numHidden[0]);
      hoWeights = MakeMatrix(numHidden[nLayers - 1], numOutput);

      hhWeights = new double[nLayers - 1][][];  // if 3 h layer, 2 h-h weights[][]
      for (int h = 0; h < hhWeights.Length; ++h)
      {
        int rows = numHidden[h];
        int cols = numHidden[h + 1];
        hhWeights[h] = MakeMatrix(rows, cols); 
      }

      hBiases = MakeJaggedMatrix(numHidden);  // pass an array of lengths
      oBiases = new double[numOutput];

      // InitializeWeights() here

    } // ctor

    public double[] ComputeOutputs(double[] xValues)
    {
      // 'xValues' might have class label or not
      // copy vals into iNodes
      for (int i = 0; i < nInput; ++i)  // possible trunc
        iNodes[i] = xValues[i];

      // zero-out all hNodes, oNodes
      for (int h = 0; h < nLayers; ++h)
        for (int j = 0; j < nHidden[h]; ++j)
          hNodes[h][j] = 0.0;
 
      for (int k = 0; k < nOutput; ++k)
        oNodes[k] = 0.0;

      // input to 1st hid layer
      for (int j = 0; j < nHidden[0]; ++j)  // each hidden node, 1st layer
      {
        for (int i = 0; i < nInput; ++i)
          hNodes[0][j] += ihWeights[i][j] * iNodes[i];
        // add the bias
        hNodes[0][j] += hBiases[0][j];
        // apply activation
        hNodes[0][j] = Math.Tanh(hNodes[0][j]);
      }

      // each remaining hidden node
      for (int h = 1; h < nLayers; ++h)
      {
        for (int j = 0; j < nHidden[h]; ++j)  // 'to index'
        {
          for (int jj = 0; jj < nHidden[h - 1]; ++jj)  // 'from index'
          {
            hNodes[h][j] += hhWeights[h-1][jj][j] * hNodes[h-1][jj];
          }
          hNodes[h][j] += hBiases[h][j];  // add bias value
          hNodes[h][j] = Math.Tanh(hNodes[h][j]);  // apply activation
        }
      }

      // compute ouput node values
      for (int k = 0; k < nOutput; ++k)
      {
        for (int j = 0; j < nHidden[nLayers - 1]; ++j)
        {
          oNodes[k] += hoWeights[j][k] * hNodes[nLayers - 1][j];
        }
        oNodes[k] += oBiases[k];  // add bias value
        //Console.WriteLine("Pre-softmax output node [" + k + "] value = " + oNodes[k].ToString("F4"));
      }

      double[] retResult = Softmax(oNodes);  // softmax activation all oNodes

      for (int k = 0; k < nOutput; ++k)
        oNodes[k] = retResult[k];
      return retResult;  // calling convenience

    } // ComputeOutputs

    private static double MyTanh(double x)
    {
      if (x < -20.0) return -1.0; // approximation is correct to 30 decimals
      else if (x > 20.0) return 1.0;
      else return Math.Tanh(x);
    }

    private static double[] Softmax(double[] oNodes) // does all output nodes at once so scale doesn't have to be re-computed each time
    {
      // Softmax using the max trick to avoid overflow
      // determine max output node value
      double max = oNodes[0];
      for (int i = 0; i < oNodes.Length; ++i)
        if (oNodes[i] > max) max = oNodes[i];

      // determine scaling factor -- sum of exp(each val - max)
      double scale = 0.0;
      for (int i = 0; i < oNodes.Length; ++i)
        scale += Math.Exp(oNodes[i] - max);

      double[] result = new double[oNodes.Length];
      for (int i = 0; i < oNodes.Length; ++i)
        result[i] = Math.Exp(oNodes[i] - max) / scale;

      return result; // now scaled so that xi sum to 1.0
    }


    public void SetWeights(double[] wts)
    {
      // order: ihweights - hhWeights[] - hoWeights - hBiases[] - oBiases
      int nw = NumWeights(this.nInput, this.nHidden, this.nOutput);  // total num wts + biases
      if (wts.Length != nw)
        throw new Exception("Bad wts[] length in SetWeights()");
      int ptr = 0;  // pointer into wts[]

      for (int i = 0; i < nInput; ++i)  // input node
        for (int j = 0; j < hNodes[0].Length; ++j)  // 1st hidden layer nodes
          ihWeights[i][j] = wts[ptr++];

      for (int h = 0; h < nLayers - 1; ++h)  // not last h layer
      {
        for (int j = 0; j < nHidden[h]; ++j)  // from node
        {
          for (int jj = 0; jj < nHidden[h + 1]; ++jj)  // to node
          {
            hhWeights[h][j][jj] = wts[ptr++];
          }
        }
      }

      int hi = this.nLayers - 1;  // if 3 hidden layers (0,1,2) last is 3-1 = [2]
      for (int j = 0; j < this.nHidden[hi]; ++j)
      {
        for (int k = 0; k < this.nOutput; ++k)
        {
          hoWeights[j][k] = wts[ptr++];
        }
      }

      for (int h = 0; h < nLayers; ++h)  // hidden node biases
      {
        for (int j = 0; j < this.nHidden[h]; ++j)
        {
           hBiases[h][j] = wts[ptr++];
        }
      }

      for (int k = 0; k < nOutput; ++k)
      {
        oBiases[k] = wts[ptr++];
      }
    } // SetWeights

    public static int NumWeights(int numInput, int[] numHidden, int numOutput)
    {
      // total num weights and biases
      int ihWts = numInput * numHidden[0];
 
      int hhWts = 0;
      for (int j = 0; j < numHidden.Length - 1; ++j)
      {
        int rows = numHidden[j];
        int cols = numHidden[j + 1];
        hhWts += rows * cols;
      }
      int hoWts = numHidden[numHidden.Length - 1] * numOutput;

      int hbs = 0;
      for (int i = 0; i < numHidden.Length; ++i)
        hbs += numHidden[i];

      int obs = numOutput;
      int nw = ihWts + hhWts + hoWts + hbs + obs;
      return nw;
    }

    public static double[][] MakeJaggedMatrix(int[] cols)
    {
      // array of arrays using size info in cols[]
      int rows = cols.Length;  // num rows inferred by col count
      double[][] result = new double[rows][];
      for (int i = 0; i < rows; ++i)
      {
        int ncol = cols[i];
        result[i] = new double[ncol];
      }
      return result;
    }

    public static double[][] MakeMatrix(int rows, int cols)
    {
      double[][] result = new double[rows][];
      for (int i = 0; i < rows; ++i)
        result[i] = new double[cols];
      return result;
    }

    public void Dump(bool showWeights)
    {
      for (int i = 0; i < nInput; ++i)
      {
        Console.WriteLine("input node [" + i + "] = " + iNodes[i].ToString("F4"));
      }
      for (int h = 0; h < nLayers; ++h)
      {
        Console.WriteLine("");
        for (int j = 0; j < nHidden[h]; ++j)
        {
          Console.WriteLine("hidden layer " + h + " node [" + j + "] = " + hNodes[h][j].ToString("F4"));
        }
      }
      Console.WriteLine("");
      for (int k = 0; k < nOutput; ++k)
      {
        Console.WriteLine("output node [" + k + "] = " + oNodes[k].ToString("F4"));
      }

      if (showWeights == false)
        return; // bail out

      Console.WriteLine("");
      for (int i = 0; i < nInput; ++i)
      {
        for (int j = 0; j < nHidden[0]; ++j)
        {
          Console.WriteLine("input-hidden wt [" + i + "][" + j + "] = " + ihWeights[i][j].ToString("F4"));
        }
      }

      for (int h = 0; h < nLayers - 1; ++h)  // note
      {
        Console.WriteLine("");
        for (int j = 0; j < nHidden[h]; ++j)
        {
          for (int jj = 0; jj < nHidden[h + 1]; ++jj)
          {
            Console.WriteLine("hidden-hidden wt layer " + h + " to layer " + (h + 1) + " node [" + j + "] to [" + jj + "] = " + hhWeights[h][j][jj].ToString("F4")); 
          }
        }
      }

      Console.WriteLine("");
      for (int j = 0; j < nHidden[nLayers - 1]; ++j)
      {
        for (int k = 0; k < nOutput; ++k)
        {
          Console.WriteLine("hidden-output wt [" + j + "][" + k+ "] = " + hoWeights[j][k].ToString("F4"));
        }
      }

      for (int h = 0; h < nLayers; ++h)
      {
        Console.WriteLine("");
        for (int j = 0; j < nHidden[h]; ++j)
        {
          Console.WriteLine("hidden layer " + h + " bias [" + j + "] = " + hBiases[h][j].ToString("F4"));
        }
      }

      Console.WriteLine("");
      for (int k = 0; k < nOutput; ++k)
      {
        Console.WriteLine("output node bias [" + k + "] = " + oBiases[k].ToString("F4"));
      }

    } // Dump
  } // class DeepNet