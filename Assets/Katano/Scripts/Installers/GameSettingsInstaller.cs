using DDD.Katano.Managers;
using DDD.Katano.Model;
using DDD.Matsumoto;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Inject/Game Settings")]
	public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
	{
		public GamePlayers GamePlayers;

		public PlayerCore.Settings PlayerSettings;
		
		public GameTitleManager.Settings TitleSettings;
		public MainGameManager.Settings MainGameSettings;
		public GameResultManager.Settings ResultSettings;

		public override void InstallBindings()
		{
			Container.BindInstance(GamePlayers);
			Container.BindInstance(PlayerSettings);
			
			Container.BindInstance(TitleSettings);
			Container.BindInstance(MainGameSettings);
			Container.BindInstance(ResultSettings);
		}
	}
}