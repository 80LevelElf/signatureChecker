using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CheckerUI.Entities;
using ConvNetSharp;

namespace Learning
{
	[Serializable]
	public class NeuralNet
	{
		private readonly CircularBuffer<int> _trainAccuracyBuffer = new CircularBuffer<int>(100);
		private readonly CircularBuffer<int> _validationAccuracyBuffer = new CircularBuffer<int>(100);
		private readonly CircularBuffer<double> _lossBuffer = new CircularBuffer<double>(100);

		private Net _net;
		private int _stepCount;
		private Trainer _trainer;
		List<User> _userList;
		int _neededUserId;
		int _imageSize;
		Action<string> _infoOutputFunc;

		public void Start(List<User> userList, int neededUserId, int imageSize, Action<string> infoOutputFunc)
		{
			// Load data
			_userList = userList;
			_neededUserId = neededUserId;
			_imageSize = imageSize;
			_stepCount = 1;
			_infoOutputFunc = infoOutputFunc;

			// Create network
			_net = new Net();
			_net.AddLayer(new InputLayer(_imageSize, _imageSize, 1));
			_net.AddLayer(new ConvLayer(5, 5, 16) { Stride = 1, Pad = 1, Activation = Activation.Relu });
			_net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
			_net.AddLayer(new ConvLayer(5, 5, 8) { Stride = 1, Pad = 1, Activation = Activation.Relu });
			_net.AddLayer(new PoolLayer(2, 2) { Stride = 2 });
			_net.AddLayer(new SoftmaxLayer(2));

			_trainer = new Trainer(_net)
			{
				BatchSize = 20,
				L2Decay = 0.001,
				TrainingMethod = Trainer.Method.Adagrad
			};

			Stopwatch sw = Stopwatch.StartNew();
			do
			{
				var sample = GenerateTrainingInstance();
				if (!Step(sample))
					break;

			} while (true);
			sw.Stop();

			if (_infoOutputFunc != null)
				_infoOutputFunc(string.Format("\nВремя тренировки: {0} мск", sw.ElapsedMilliseconds));

			Console.WriteLine(sw.ElapsedMilliseconds / 1000.0);

			// Output checking
			if (_infoOutputFunc != null)
				_infoOutputFunc("\n\nId пользователя \t\t Неверный пользователь \t\t Верный пользователь");

			foreach (User user in _userList.OrderByDescending(i => i.UserId))
			{
				Random random = new Random();
				var signature = user.SignatureList[random.Next(user.SignatureList.Count)];

				var x = GetVolume(signature);
				var result = _net.Forward(x);

				if (_infoOutputFunc != null)
					_infoOutputFunc(string.Format("{0} \t\t\t {1} \t\t {2}", user.UserId, result.Weights[0], result.Weights[1]));
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
				var valAcc = yhat == y ? 1 : 0;
				_validationAccuracyBuffer.Add(valAcc);
				return true;
			}

			// train on it with network
			_trainer.Train(x, y);

			// keep track of stats such as the average training error and loss
			int prediction = _net.GetPrediction();
			var trainAcc = prediction == y ? 1 : 0;
			_lossBuffer.Add(_trainer.Loss);
			_trainAccuracyBuffer.Add(trainAcc);

			if (_stepCount % 200 == 0)
			{
				double loss = _lossBuffer.Items.Average();
				double trainAvgAcc = _trainAccuracyBuffer.Items.Average();
				double validationAvgAcc = _validationAccuracyBuffer.Items.Average();

				if (_infoOutputFunc != null)
				{
					_infoOutputFunc(
						string.Format("Ошибка: {0}\t\t Пройденных тестовых примеров: {1}\t\t Пройденных валидационных примеров: {2}",
							loss,
							Math.Round(trainAvgAcc*100.0, 2),
							Math.Round(validationAvgAcc*100.0, 2)));
				}

				if (_trainAccuracyBuffer.Items.All(i => i == 1) && _validationAccuracyBuffer.Items.All(i => i == 1))
					return false;
			}

			_stepCount++;

			return true;
		}

		private TrainingItem GenerateTrainingInstance()
		{
			Random random = new Random();
			bool isValidation = random.Next(10) == 0;

			int userId = random.Next(_userList.Count);
			var user = _userList[userId];

			// Calculate signature index
			int signatureIndex;
			var testRange = user.SignatureList.Count*3/4;
			if (!isValidation)
				signatureIndex = random.Next(testRange);
			else
				signatureIndex = testRange + random.Next(user.SignatureList.Count - testRange);

			var signature = user.SignatureList[signatureIndex];

			// Create volume from image data
			var x = GetVolume(signature);

			return new TrainingItem { Volume = x, ClassIndex = user.UserId == _neededUserId? 1 : 0, IsValidation = isValidation };
		}

		private Volume GetVolume(Signature signature)
		{
			var x = new Volume(_imageSize, _imageSize, 1, 0.0);

			foreach (var point in signature.SignaturePointList)
			{
				x.Weights[point.X * _imageSize + point.Y] = 1;
			}

			x = x.Augment(_imageSize);

			return x;
		}

		private class TrainingItem
		{
			public Volume Volume { get; set; }

			public int ClassIndex { get; set; }

			public bool IsValidation { get; set; }
		}
	}
}
