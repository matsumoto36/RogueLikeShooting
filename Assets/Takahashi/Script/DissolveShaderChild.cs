using UnityEngine;

namespace DDD.Takahashi
{
	public class DissolveShaderChild : MonoBehaviour
	{
		private DissolveShaderControl _parentController;
		private Renderer _parentRenderer;
		
		public GameObject m_obj;

		public string obj_name;


		// Use this for initialization
		private void Start()
		{
			var parent = transform.parent;
			if (parent == null)
				throw new UnityException("Parent gameobject not found.");

			_parentController = parent.GetComponentInParent<DissolveShaderControl>();
			
			m_obj = GameObject.Find(obj_name);
			//m_obj = transform.root.gameObject;
		}

		// Update is called once per frame
		private void Update()
		{
			var f = m_obj.GetComponent<Renderer>().material.GetFloat("_v_jouge");
			gameObject.GetComponent<Renderer>().material.SetFloat("_v_jouge", f);
			gameObject.GetComponent<Renderer>().material
				.SetFloat("_takasa", m_obj.GetComponent<DissolveShaderControl>().objy);
			gameObject.GetComponent<Renderer>().material
				.SetColor("_emi_color", m_obj.GetComponent<DissolveShaderControl>().c_emistion);
		}
	}
}