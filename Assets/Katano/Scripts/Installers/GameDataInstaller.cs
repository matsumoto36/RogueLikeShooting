using DDD.Chikazawa;
using DDD.Katano.Model;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	[CreateAssetMenu(fileName = "GameDataInstaller", menuName = "Inject/Game Data")]
	public class GameDataInstaller : ScriptableObjectInstaller<GameDataInstaller>
	{
		public PlayerBindData BindData;
		public GameResultData ResultData;

		public override void InstallBindings()
		{
			Container.BindInstance(BindData);
			Container.BindInstance(ResultData);
		}
	}
}