using System.Collections.Generic;
using MonoDesign.Core.Entity;
using MonoDesign.Core.Entity.Scene;

namespace MonoDesign.Engine.Manager {
	public class SceneManager: IDataManager<Scene> {
		public IEnumerable<Scene> GetItems() {
			return new[] {
				new Scene{
					Name = "Test"
				},
			};
		}
		public void Save(Scene item) {
			throw new System.NotImplementedException();
		}
		public void SaveAll() {
			throw new System.NotImplementedException();
		}
		public void Create(Scene item) {
			throw new System.NotImplementedException();
		}
		public void Remove(Scene item) {
			throw new System.NotImplementedException();
		}
		public void Reload() {
			throw new System.NotImplementedException();
		}
		public void Load() {
			throw new System.NotImplementedException();
		}
	}
}
