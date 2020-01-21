using System;
using System.Windows.Input;
using MonoDesign.Core.Entity.Component;
using MonoDesign.Engine;
using MonoDesign.Engine.Manager;
using MonoDesign.UI.Component.Command;
using MonoDesign.UI.Component.Component;
using MonoDesign.UI.Component.Dialog;

namespace MonoDesign.UI.ViewModel.Component
{
	public class TextureComponentViewModel: BaseComponentViewModel<TextureComponent> {
		private readonly DesignEngine _designEngine;
		private readonly IDialogService _dialogService;
		private readonly IAssetManager _assetManager;
		public ICommand SelectTextureCommand { get; }
		public TextureComponentViewModel(DesignEngine designEngine, IDialogService dialogService, IAssetManager assetManager) {
			_designEngine = designEngine;
			_dialogService = dialogService;
			_assetManager = assetManager;
			SelectTextureCommand = new RelayCommand(SelectTextureExecute);
		}
		private void SelectTextureExecute() {
			try {
				var path = _dialogService.SelectFile("Content file|*.xnb");
				var assetName = _assetManager.SaveTextureToAsset(_designEngine.ProjectInfo, path);
				Value.Texture = _assetManager.LoadTexture(_designEngine.ProjectInfo, assetName);
			} catch (Exception e) {
				
			}
		}
	}
}
