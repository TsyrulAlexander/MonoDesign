using System;

namespace MonoDesign.Core.Messages
{
	public interface IMessenger {
		void Subscribe<T>(string message, Action<T> action);
		void Unsubscribe<T>(string message, Action<T> action);
		void Publish<T>(string message, T value);
	}
}
