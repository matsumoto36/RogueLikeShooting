using System.Collections.Generic;
using System.Linq;
using ProBuilder.MeshOperations;
using UnityEngine;

public class OriginalMesh : MonoBehaviour
{
	private MeshFilter _meshFilter;

	// Start is called before the first frame update
	private void Start()
	{
		_meshFilter = GetComponent<MeshFilter>();
	}

	// Update is called once per frame
	private void Update()
	{
		var mesh = new Mesh();

		const int ySize = 11;
		const int xSize = 6;

		

		var vertices = new List<Vector3>();
		var colors = new List<Color>();
		var triangles = new List<int>();
		
		var matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.AngleAxis(90, Vector3.forward), Vector3.one);

		var indexOffset = vertices.Count;
		
		vertices.AddRange(
			from y in Enumerable.Range(0, ySize)
			from x in Enumerable.Range(0, xSize)
			from y2 in new[] {-0.5f, 0.5f}.Select(v => v + y - ySize / 2.0f)
			from x2 in new[] {-0.5f, 0.5f}.Select(v => v + x - xSize / 2.0f)
			select matrix.MultiplyPoint(
				Quaternion.AngleAxis(x2 / xSize * 360f, Vector3.up) 
				* Vector3.forward 
				* Mathf.Clamp01(y2 + ySize / 2) * 0.05f 
				+ Vector3.up * y2 / ySize 
				* 2.0f));
		
		colors.AddRange(Enumerable.Range(0, vertices.Count - indexOffset).Select(_ => new Color(0.2f, 0.1f, 0.1f)));

		foreach (var x in Enumerable.Range(0, (vertices.Count - indexOffset) / 4))
		{
			triangles.AddRange(new []
			{
				0, 1, 2,
				2, 1, 3,
			}.Select(i => indexOffset + x * 4 + i));
		}

		mesh.SetVertices(vertices);
		mesh.SetTriangles(triangles, 0);
		mesh.SetColors(colors);
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		_meshFilter.mesh = mesh;
	}
}