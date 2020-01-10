using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDesign.Core.Annotations;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Core.Serialization;
using MonoDesign.Core.Utilities;

namespace MonoDesign.Core.Entity.GameObject {
	[GameSerializable]
	public class GameObject : IGameObject {
		public SpriteBatch SpriteBatch { get; }
		private Guid _id;
		private string _name;
		private Texture2D _texture;
		private Vector2 _position;
		private Rectangle? _sourceRectangle;
		private Color _color;
		private float _rotation;
		private Vector2 _origin;
		private Vector2 _scale;
		private SpriteEffects _effects;
		private float _layerDepth;
		private bool _isUpdatable;
		private bool _isDrawable;
		public Guid Id {
			get => _id;
			set {
				if (value.Equals(_id))
					return;
				_id = value;
				OnPropertyChanged();
			}
		}
		public string Name {
			get => _name;
			set {
				if (value == _name)
					return;
				_name = value;
				OnPropertyChanged();
			}
		}
		public bool IsDrawable {
			get => _isDrawable;
			set {
				if (value == _isDrawable)
					return;
				_isDrawable = value;
				OnPropertyChanged();
			}
		}
		public Texture2D Texture {
			get => _texture;
			set {
				if (Equals(value, _texture))
					return;
				_texture = value;
				OnPropertyChanged();
			}
		}
		public Vector2 Position {
			get => _position;
			set {
				if (value.Equals(_position))
					return;
				_position = value;
				OnPropertyChanged();
			}
		}
		public Rectangle? SourceRectangle {
			get => _sourceRectangle;
			set {
				if (value.Equals(_sourceRectangle))
					return;
				_sourceRectangle = value;
				OnPropertyChanged();
			}
		}
		public Color Color {
			get => _color;
			set {
				if (value.Equals(_color))
					return;
				_color = value;
				OnPropertyChanged();
			}
		}
		public float Rotation {
			get => _rotation;
			set {
				if (value.Equals(_rotation))
					return;
				_rotation = value;
				OnPropertyChanged();
			}
		}
		public Vector2 Origin {
			get => _origin;
			set {
				if (value.Equals(_origin))
					return;
				_origin = value;
				OnPropertyChanged();
			}
		}
		public Vector2 Scale {
			get => _scale;
			set {
				if (value.Equals(_scale))
					return;
				_scale = value;
				OnPropertyChanged();
			}
		}
		public SpriteEffects Effects {
			get => _effects;
			set {
				if (value == _effects)
					return;
				_effects = value;
				OnPropertyChanged();
			}
		}
		public float LayerDepth {
			get => _layerDepth;
			set {
				if (value.Equals(_layerDepth))
					return;
				_layerDepth = value;
				OnPropertyChanged();
			}
		}
		public bool IsUpdatable {
			get => _isUpdatable;
			set {
				if (value == _isUpdatable)
					return;
				_isUpdatable = value;
				OnPropertyChanged();
			}
		}
		public List<IGameObjectComponent> Components { get; set; } = new List<IGameObjectComponent>();
		public GameObject(SpriteBatch spriteBatch = null) {
			SpriteBatch = spriteBatch ?? GameServices.GetService<SpriteBatch>();
		}
		public IEnumerable<IGameObjectComponent> GetComponents() {
			return Components;
		}
		public void AddComponent(IGameObjectComponent component) {
			Components.Add(component);
		}
		public void RemoveComponent(IGameObjectComponent component) {
			Components.Remove(component);
		}
		public void Update(GameTime gameTime) {
			Components.ForEach(component => component.Update(gameTime));
		}
		public void Draw(GameTime gameTime) {
			Components.ForEach(component => component.Draw(gameTime));
			if (Texture == null) {
				return;
			}
			SpriteBatch.Draw(Texture, Position, SourceRectangle, Color, Rotation, Origin, Scale, Effects, LayerDepth);

		}
		public void Serialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (GameObject) obj;
			info.Serialize(item, o => o.Id);
			info.Serialize(item, o => o.Name);
		}
		public object Deserialize(object obj, SerializationInfo info, StreamingContext context) {
			var item = (GameObject) obj;
			info.Deserialize(item, o => o.Id);
			info.Deserialize(item, o => o.Name);
			return item;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}