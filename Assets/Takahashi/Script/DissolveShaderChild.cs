using UnityEngine;

namespace DDD.Takahashi
{
	public class DissolveShaderChild : MonoBehaviour
	{
		private static readonly int VJouge = Shader.PropertyToID("_v_jouge");
		private static readonly int Emission = Shader.PropertyToID("_emi_color");
		private static readonly int Height = Shader.PropertyToID("_takasa");

		
		private DissolveShaderControl _parentController;
		private Renderer _parentRenderer;
		private Renderer _renderer;
		
//		public GameObject m_obj;

		// public string obj_name;


		// Use this for initialization
		private void Start()
		{
			var parent = transform.parent;
			if (parent == null)
				throw new UnityException("Parent gameobject not found.");
			
			_parentController = parent.GetComponentInParent<DissolveShaderControl>();
			if (_parentController == null)
				throw new UnityException("Parent Shader Controller not found.");

			_renderer = GetComponent<Renderer>();
			_parentRenderer = _parentController.GetComponent<Renderer>();
			
//			m_obj = GameObject.Find(obj_name);
			//m_obj = transform.root.gameObject;
		}

		// Update is called once per frame
		private void Update()
		{
			var value = _parentRenderer.material.GetFloat(VJouge);
			
			_renderer.material.SetFloat(VJouge, value);
			_renderer.material.SetFloat(Height, _parentController.PositionY);
			_renderer.material.SetColor(Emission, _parentController.EmissionColor);
			
//			var f = m_obj.GetComponent<Renderer>().material.GetFloat("_v_jouge");
//			gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", f);
//			gameObject.GetComponent<Renderer>().material
//				.SetFloat("_takasa", m_obj.GetComponent<DissolveShaderControl>().PositionY);
//			gameObject.GetComponent<Renderer>().material
//				.SetColor("_emi_color", m_obj.GetComponent<DissolveShaderControl>().EmissionColor);
		}
	}
}