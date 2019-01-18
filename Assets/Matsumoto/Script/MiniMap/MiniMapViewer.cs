using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DDD.Katano.Maze;

namespace DDD.Matsumoto.Minimap {

	/// <summary>
	/// ミニマップを表示する
	/// </summary>
	public class MiniMapViewer : MonoBehaviour {

		public RectTransform MapParent;

		public Image PlayerIcon;
		public Image StairIcon;
		public Image FloorImagePre;

		public Color MiniMapColor;

		public float RoomSize = 100.0f;
		public float AisleWidth = 80.0f;
		public float AisleLength = 50.0f;

		public Vector2 PlayerIconOffset;
		public Vector2 StairIconOffset;

		private MiniMapSystem _miniMapSystem;

		private Image[,] _mapImages;
		private Vector2[,] _imagePositions;

		private Point _mapSize;

		// Use this for initialization
		void Start() {

			_miniMapSystem = FindObjectOfType<MiniMapSystem>();

			//イベント登録
			//_miniMapSystem.OnMapChanged += Draw;
			_miniMapSystem.OnStarted += SetMapFloorImage;

		}

		/// <summary>
		/// 床を配置する
		/// </summary>
		void SetMapFloorImage() {

			_mapSize = _miniMapSystem.MapSize;
			_mapImages = new Image[_mapSize.Y, _mapSize.X];
			_imagePositions = new Vector2[_mapSize.Y, _mapSize.X];

			Vector2 position = new Vector2();
			for (int i = 0; i < _mapSize.Y; i++) {
				for (int j = 0; j < _mapSize.X; j++) {
					//Todo 加算の仕方がおかしい気がする
					if (i % 2 != 0 && j % 2 != 0) {
						position.x += RoomSize;
						continue;
					}

					var image = Instantiate(FloorImagePre, MapParent);

					//両方偶数の時は床
					if(i % 2 == 0 && j % 2 == 0) {

						image.rectTransform.sizeDelta = new Vector2(RoomSize, RoomSize);

						image.rectTransform.anchoredPosition = position;
						_imagePositions[i, j] = position;
						_mapImages[i, j] = image;

						position.x += RoomSize;
					}
					//そのほかは廊下
					else {

						Vector2 aisleSize;
						//縦方向の接続
						if (i % 2 == 0) {
							aisleSize = new Vector2(AisleLength, AisleWidth);
						}
						else {
							aisleSize = new Vector2(AisleWidth, AisleLength);
						}

						image.rectTransform.sizeDelta = aisleSize;

						image.rectTransform.anchoredPosition = position;
						_imagePositions[i, j] = position;
						_mapImages[i, j] = image;

						position.x += aisleSize.x;
					}
				}

				position.x = 0.0f;

				//Yの加算
				if (i % 2 == 0) {
					position.y += RoomSize;
				}
				else {
					position.y += AisleLength;
				}
			}

		}

		/// <summary>
		/// マップを表示する
		/// </summary>
		/// <param name="map"></param>
		void Draw(int[,] map) {

			//アイコン非表示
			PlayerIcon.enabled = false;
			StairIcon.enabled = false;

			for (int i = 0; i < _mapSize.Y; i++) {
				for (int j = 0; j < _mapSize.X; j++) {

					var target = _mapImages[i, j];
					if(!target) continue;
					
					var mapData = map[i, j];

					if((mapData & (int)MinimapObject.Floor) != 0) {
						target.enabled = true;
					}
					if((mapData & (int)MinimapObject.Players) != 0) {
						PlayerIcon.enabled = true;
						PlayerIcon.rectTransform.anchoredPosition
							= _imagePositions[i, j] + PlayerIconOffset;

					}
					if((mapData & (int)MinimapObject.Stair) != 0) {
						StairIcon.enabled = true;
						StairIcon.rectTransform.anchoredPosition
							= _imagePositions[i, j] + StairIconOffset;
					}
					if(mapData == (int)MinimapObject.None) {
						target.enabled = false;
					}
				}
			}
		}
	}
}
