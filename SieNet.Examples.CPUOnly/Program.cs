﻿using CNTK;
using Emgu.CV.Structure;
using SiaNet;
using SiaNet.Application;
using SiaNet.Common;
using SiaNet.Model;
using SiaNet.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieNet.Examples.CPUOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Setting global device
                Logging.OnWriteLog += Logging_OnWriteLog;
                ImageDataFrame frame = new ImageDataFrame(Variable.InputVariable(new int[] { 28, 28, 1 }, DataType.Float), Variable.InputVariable(new int[] { 10 }, DataType.Float));
                //frame.ExtractCifar10();
                frame.Load(@"C:\BDK\Dataset\Cifar10");
                //Housing regression example
                HousingRegression.LoadData();
                HousingRegression.BuildModel();
                HousingRegression.Train();

                //MNIST Classification example
                MNISTClassifier.LoadData();
                MNISTClassifier.BuildModel();
                MNISTClassifier.Train();

                //Cifar - 10 Classification example
                //Cifar10Classification.LoadData();
                //Cifar10Classification.BuildModel();
                //Cifar10Classification.Train();

                //Image classification example
                Console.WriteLine("ResNet50 Prediction: " + ImageClassification.ImagenetTest(SiaNet.Common.ImageNetModel.ResNet50)[0].Name);
                Console.WriteLine("Cifar 10 Prediction: " + ImageClassification.Cifar10Test(SiaNet.Common.Cifar10Model.ResNet110)[0].Name);

                //Object Detection
                //ObjectDetection.PascalDetection();
                //ObjectDetection.GroceryDetection();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private void EvalImageNet()
        {

        }

        private static void Logging_OnWriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
}
