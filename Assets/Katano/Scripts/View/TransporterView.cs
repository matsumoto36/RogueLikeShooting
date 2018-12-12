using System;
using System.Threading;
using RogueLike.Katano.Model;
using UniRx;
using UniRx.Async;
using UniRx.Async.Triggers;
using UnityEngine;

namespace RogueLike.Katano.View
{
	/// <summary>
	/// 転送システム
	/// </summary>
	public class TransporterView : MonoBehaviour
	{
		private const float NextRoomJumpTime = 1f;
		
		[SerializeField]
		private GamePlayers _gamePlayers;
		
		public RoomView Owner { get; private set; }
		public TransporterView CounterSide { get; private set; }
		
		private float _overlappedElapsedTime;
		
		private readonly Subject<Unit> _onTransportStartSubject = new Subject<Unit>();
		/// <summary>
		/// 転送開始イベント
		/// </summary>
		public IObservable<Unit> OnTransportStartObservable => _onTransportStartSubject;

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="owner"></param>
		/// <param name="counterSide"></param>
		public void Initialze(RoomView owner, TransporterView counterSide)
		{
			Owner = owner;
			CounterSide = counterSide;
		}

		
		private async UniTaskVoid OnPlayerRiding(CancellationToken token = default)
		{
			while (!token.IsCancellationRequested)
			{
				// 当たっているプレイヤー
				var collidee = Physics.OverlapSphere(transform.position, 2, LayerMask.NameToLayer("Player"));
				if (collidee.Length == _gamePlayers.JoinedPlayerCount)
					_overlappedElapsedTime += Time.fixedDeltaTime;
				else
					_overlappedElapsedTime = 0;

				if (_overlappedElapsedTime >= NextRoomJumpTime)
				{
					_onTransportStartSubject.OnNext(Unit.Default);
					_overlappedElapsedTime = 0;
				}

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			}
		}

		/// <summary>
		/// 有効化する
		/// </summary>
		public void SetVisible()
		{
			if (CounterSide != null)
			{
				var token = this.GetCancellationTokenOnDestroy();
				
				gameObject.SetActive(true);
				OnPlayerRiding(token).Forget();
			}
		}
	}
}