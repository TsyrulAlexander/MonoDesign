using System;
using System.Collections.Generic;

namespace MonoDesign.Core.Messages
{
	public class Messenger: IMessenger {
		public Dictionary<string, List<object>> Messages { get; } = new Dictionary<string, List<object>>();
		public void Subscribe<T>(string message, Action<T> action) {
			if (!Messages.ContainsKey(message)) {
				Messages.Add(message, new List<object>());
			}
			Messages[message].Add(action);
		}
		public void Unsubscribe<T>(string message, Action<T> action) {
			Messages[message].Remove(action);
		}
		public void Publish<T>(string message, T value) {
			if (!Messages.ContainsKey(message)) {
				return;
			}
			Messages[message].ForEach(action => ((Action<T>)action).Invoke(value));
		}
	}
}
