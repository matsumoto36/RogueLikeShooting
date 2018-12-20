using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using RogueLike.Katano.Model;
using RogueLike.Matsumoto;
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

		public ParticleSystem ParticleSystem;
		
		public RoomView Owner { get; private set; }
		public TransporterView CounterSide { get; private set; }
		
		private float _overlappedElapsedTime;
		
		private readonly Subject<TransporterView> _onTransportStartSubject = new Subject<TransporterView>();
		/// <summary>
		/// 転送開始イベント
		/// </summary>
		public IObservable<TransporterView> OnTransportStartObservable => _onTransportStartSubject;

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
				var collidee = Physics.OverlapSphere(transform.position, 0.5f, LayerMask.GetMask("Player"));
				int playerCount = 0;
				for (int i = 0; i < collidee.Length; i++)
				{
					var player = collidee[i].GetComponentInParent<PlayerCore>();
					if (player != null)
					{
						playerCount++;
					}
				}
				
				
				if (playerCount == _gamePlayers.JoinedPlayerCount)
					_overlappedElapsedTime += Time.fixedDeltaTime;
				else
					_overlappedElapsedTime = 0;

				if (_overlappedElapsedTime >= NextRoomJumpTime)
				{
					_onTransportStartSubject.OnNext(CounterSide);
					await UniTask.Delay(TimeSpan.FromSeconds(10), cancellationToken: token);
				}

				await UniTask.Yield(PlayerLoopTiming.FixedUpdate);
			}
		}

		/// <summary>
		/// 有効化する
		/// </summary>
		public bool SetVisible()
		{
			if (CounterSide != null)
			{
				var token = this.GetCancellationTokenOnDestroy();
				
				gameObject.SetActive(true);
				OnPlayerRiding(token).Forget();

				return true;
			}

			return false;
		}
	}
}