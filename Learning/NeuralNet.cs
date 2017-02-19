using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ConvNetSharp;
using Learning.Entities;
using Learning.Managers;

namespace Learning
{
	public class NeuralNet
	{
		private readonly CircularBuffer<double> _trainAccuracyBuffer = new CircularBuffer<double>(100);
		private readonly CircularBuffer<double> _validationAccuracyBuffer = new CircularBuffer<double>(100);
		private readonly CircularBuffer<double> _weightLossBuffer = new CircularBuffer<double>(100);
		private readonly CircularBuffer<double> _xLossBuffer = new CircularBuffer<double>(100);

		private Net _net;
		private int _stepCount;
		private Trainer _trainer;
		List<User> _userList;
		int neededUserId = 1;
		const int imageSize = 101;

		public void Demo()
		{
			// Load data
			_userList = ReadingManager.ReadData(@"C:\Users\RustamSalakhutdinov\Documents\visual studio 2015\Projects\signatureChecker\data_new");

			// Create network
			_net = new Net();
			_net.AddLayer(new InputLayer(imageSize, imageSize, 1));
			_net.AddLayer(new ConvLayer(5, 5, 16) { Stride = 1, Pad = 1, Activation = Activation.Relu });
			_net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
			_net.AddLayer(new ConvLayer(5, 5, 8) { Stride = 1, Pad = 1, Activation = Activation.Relu });
			_net.AddLayer(new PoolLayer(3, 3) { Stride = 3 });
			_net.AddLayer(new SoftmaxLayer(2));

			_trainer = new Trainer(_net)
			{
				BatchSize = 20,
				L2Decay = 0.001,
				TrainingMethod = Trainer.Method.Sgd
			};

			Stopwatch sw = Stopwatch.StartNew();
			do
			{
				var sample = GenerateTrainingInstance();
				if (!Step(sample))
					break;
			} while (!Console.KeyAvailable);
			sw.Stop();
			Console.WriteLine(sw.ElapsedMilliseconds / 1000.0);

			foreach (User user in _userList)
			{
				Random random = new Random();
				var signature = user.SignatureList[random.Next(user.SignatureList.Count)];

				var x = new Volume(imageSize, imageSize, 1, 0.0);

				foreach (var point in signature.SignaturePointList)
				{
					x.Weights[point.X * imageSize + point.Y] = 1;
				}

				x = x.Augment(imageSize);

				var result = _net.Forward(x);
				Console.WriteLine("UserId: {0}. Result: {1} | {2}", user.UserId, result.Weights[0], result.Weights[1]);
			}
		}

		private bool Step(TrainingItem sample)
		{
			var x = sample.Volume;
			var y = sample.ClassIndex;

			if (sample.IsValidation)
			{
				// use x to build our estimate of validation error
				_net.Forward(x);
				int yhat = _net.GetPrediction();
				var valAcc = yhat == y ? 1.0 : 0.0;
				_validationAccuracyBuffer.Add(valAcc);
				return true;
			}

			// train on it with network
			_trainer.Train(x, y);
			var lossx = _trainer.CostLoss;
			var lossw = _trainer.L2DecayLoss;

			// keep track of stats such as the average training error and loss
			int prediction = _net.GetPrediction();
			var trainAcc = prediction == y ? 1.0 : 0.0;
			_xLossBuffer.Add(lossx);
			_weightLossBuffer.Add(lossw);
			_trainAccuracyBuffer.Add(trainAcc);

			if (_stepCount % 200 == 0)
			{
				if (_xLossBuffer.Count == _xLossBuffer.Capacity)
				{
					var xa = _xLossBuffer.Items.Average();
					var xw = _weightLossBuffer.Items.Average();
					var loss = xa + xw;

					Console.WriteLine("Loss: {0} Train accuray: {1} Test accuracy: {2}", loss,
						Math.Round(_trainAccuracyBuffer.Items.Average() * 100.0, 2),
						Math.Round(_validationAccuracyBuffer.Items.Average() * 100.0, 2));

					Console.WriteLine("Example seen: {0} Fwd: {1}ms Bckw: {2}ms", _stepCount,
						Math.Round(_trainer.ForwardTime.TotalMilliseconds, 2),
						Math.Round(_trainer.BackwardTime.TotalMilliseconds, 2));

					if (Math.Abs(_validationAccuracyBuffer.Items.Average() - 1) < 0.005)
						return false;
				}
			}

			if (_stepCount % 1000 == 0)
			{
				TestPredict();
			}

			_stepCount++;

			return true;
		}

		private void TestPredict()
		{
			/*for (var i = 0; i < 50; i++)
			{
				List<TrainingItem> sample = GenerateTestingInstance();

				// forward prop it through the network
				var average = new Volume(1, 1, 2, 0.0);
				var n = sample.Count;
				for (var j = 0; j < n; j++)
				{
					var a = this._net.Forward(sample[j].Volume);
					average.AddFrom(a);
				}
			}*/
		}

		private TrainingItem GenerateTrainingInstance()
		{
			Random random = new Random();
			int userId = random.Next(_userList.Count);
			if (random.Next(3) == 1)
				userId = neededUserId;

			var user = _userList[userId];
			var signature = user.SignatureList[random.Next(user.SignatureList.Count)];

			// Create volume from image data
			var x = new Volume(imageSize, imageSize, 1, 0.0);
			
			foreach (var point in signature.SignaturePointList)
			{
				x.Weights[point.X * imageSize + point.Y] = 1;
			}

			x = x.Augment(imageSize);
			return new TrainingItem { Volume = x, ClassIndex = user.UserId == neededUserId? 1 : 0, IsValidation = random.Next(10) == 0 };
		}

		private List<TrainingItem> GenerateTestingInstance()
		{
			List<TrainingItem> result = new List<TrainingItem>(4);
			for (int i = 0; i < 4; i++)
			{
				TrainingItem instance = GenerateTrainingInstance();
				instance.IsValidation = false;
				result.Add(instance);
			}

			return result;
		}

		private class TrainingItem
		{
			public Volume Volume { get; set; }

			public int ClassIndex { get; set; }

			public bool IsValidation { get; set; }
		}
	}
}
