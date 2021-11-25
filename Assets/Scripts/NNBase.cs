using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNBase {
   static float e = 2.71828f;

   private int HiddenNodes;
   private int HiddenLayers;
   private int InputCount;
   private int OutputCount;

   public float[,,] HiddenWeights;
   public float[,] HiddenBiases;
   public float[,] OutputWeights;
   public float[] OutputBiases;

   private float Sigmoid(float x) {
      return 1f / (float) (1f + Mathf.Pow(e, -x));
   }

   public NNBase(int hl, int ln, int inputn, int on) {

      // Setting Variables
      HiddenLayers = hl;
      HiddenNodes = ln;
      InputCount = inputn;
      OutputCount = on;

      HiddenWeights = new float[HiddenLayers, HiddenNodes, HiddenNodes];
      HiddenBiases = new float[HiddenLayers, HiddenNodes];
      OutputWeights = new float[OutputCount, HiddenNodes];
      OutputBiases = new float[OutputCount];

      // Creating Layers
      for (int i = 0; i < HiddenLayers; i++) {
         for (int j = 0; j < HiddenNodes; j++) {
            HiddenBiases[i, j] = (Random.value - .5f) * 2f;
            for (int k = 0; k < HiddenNodes; k++) {
               HiddenWeights[i, j, k] = (Random.value - .5f) * 2f;
            }
         }
      }

      // Creating Outputs
      for (int i = 0; i < OutputCount; i++) {
         OutputBiases[i] = (Random.value - .5f) * 2f;
         for (int j = 0; j < HiddenNodes; j++) {
            OutputWeights[i,j] = (Random.value - .5f) * 2f;
         }
      }
   }

   public float[] Run(float[] Inputs) {
      float[] Output = new float[HiddenNodes];

      // Input
      for (int i = 0; i < HiddenNodes; i++) {
         float _out = HiddenBiases[0,i];
         for (int j = 0; j < InputCount; j++) {
            _out += HiddenWeights[0,i,j] * Inputs[j];
         }
         Output[i] = Sigmoid(_out);
      }

      // Hidden Layers
      for (int i = 1; i < HiddenLayers; i++) {
         for (int j = 0; j < HiddenNodes; j++) {
            float _out = HiddenBiases[i,j];
            for (int k = 0; k < HiddenNodes; k++) {
               _out += HiddenWeights[i,j,k] * Output[k];
            }
            Output[j] = Sigmoid(_out);
         }
      }

      // Output Layer
      float[] Final = new float[OutputCount];
      for (int i = 0; i < OutputCount; i++) {
         float _out = OutputBiases[i];
         for (int j = 0; j < HiddenNodes; j++) {
            _out += OutputWeights[i,j] * Inputs[j];
         }
         Final[i] = Sigmoid(_out);
      }

      return Final;
   }

   public NNBase(NNBase parent, float changeWeight)
   {
      int[] Build = parent.GetBuild();

      HiddenLayers = Build[0];
      HiddenNodes = Build[1];
      InputCount = Build[2];
      OutputCount = Build[3];

      HiddenWeights = new float[HiddenLayers,HiddenNodes,HiddenNodes];
      HiddenBiases = new float[HiddenLayers,HiddenNodes];
      OutputWeights = new float[OutputCount,HiddenNodes];
      OutputBiases = new float[OutputCount];

      // Creating Layers
      for (int i = 0; i < HiddenLayers; i++) {
         for (int j = 0; j < HiddenNodes; j++) {
            HiddenBiases[i,j] = parent.HiddenBiases[i,j] + (Random.value- .5f) * 2f * changeWeight;
            for (int k = 0; k < HiddenNodes; k++) {
               HiddenWeights[i,j,k] = parent.HiddenWeights[i,j,k] + (Random.value - .5f) * 2f * changeWeight;
            }
         }
      }

      // Creating Outputs
      for (int i = 0; i < OutputCount; i++) {
         OutputBiases[i] = parent.OutputBiases[i] + (Random.value - .5f) * 2f * changeWeight;
         for (int j = 0; j < HiddenNodes; j++) {
            OutputWeights[i,j] = parent.OutputWeights[i,j] + (Random.value - .5f) * 2f * changeWeight;
         }
      }
   }

   public int[] GetBuild() {
      return new int[] { HiddenLayers, HiddenNodes, InputCount, OutputCount };
   }
}