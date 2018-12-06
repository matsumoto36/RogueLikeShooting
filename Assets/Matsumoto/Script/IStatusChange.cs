using UnityEngine;
using System.Collections;
using RogueLike.Matsumoto.Character;
using UniRx;
using System;

namespace RogueLike.Matsumoto {

	/// <summary>
	/// ステータス変化を実装するインターフェース
	/// </summary>
	public interface IStatusChange {

		/// <summary>
		/// 残り時間のプロパティ
		/// </summary>
		/// <returns></returns>
		ReactiveProperty<float> RemainingTime { get; }

		/// <summary>
		/// ステータス変化を取り付けた瞬間
		/// </summary>
		/// <param name="character"></param>
		void OnAttachStatus(CharacterCore character);

		/// <summary>
		/// 毎フレーム呼ばれる
		/// </summary>
		/// <param name="character"></param>
		void OnUpdateStatus(CharacterCore character);

		/// <summary>
		/// ステータス変化を取り除いたとき
		/// </summary>
		/// <param name="character"></param>
		void OnDetachStatus(CharacterCore character);

		/// <summary>
		/// ステータス変化を組み合わせる
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		IStatusChange GetMixedStatusChange(IStatusChange other);

		/// <summary>
		/// ステータスの名前を取得する
		/// </summary>
		/// <returns></returns>
		string GetStatusName();

	}
}
