using DDD.Katano.View.Character;
using UnityEngine;
using Zenject;

namespace DDD.Katano.Installers
{
	public class CharacterInstaller : MonoInstaller<CharacterInstaller>
	{
		public Transform ArmAnchor;
		
		public override void InstallBindings()
		{
			Container.BindInstance(ArmAnchor);
			Container.Bind<CharacterArm>().FromNewComponentOn(gameObject).AsSingle();
		}
	}
}