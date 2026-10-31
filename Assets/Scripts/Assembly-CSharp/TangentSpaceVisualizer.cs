using UnityEngine;

public class TangentSpaceVisualizer : MonoBehaviour
{
	public float offset = 0.01f;

	public float scale = 0.1f;

	private void OnDrawGizmos()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		if ((bool)component)
		{
			Mesh sharedMesh = component.sharedMesh;
			if ((bool)sharedMesh)
			{
				ShowTangentSpace(sharedMesh);
			}
		}
	}

	private void ShowTangentSpace(Mesh mesh)
	{
		Vector3[] vertices = mesh.vertices;
		Vector3[] normals = mesh.normals;
		Vector4[] tangents = mesh.tangents;
		for (int i = 0; i < vertices.Length; i++)
		{
			ShowTangentSpace(base.transform.TransformPoint(vertices[i]), base.transform.TransformDirection(normals[i]), base.transform.TransformDirection(tangents[i]), tangents[i].w);
		}
	}

	private void ShowTangentSpace(Vector3 vertex, Vector3 normal, Vector3 tangent, float binormalSign)
	{
		vertex += normal * offset;
		Gizmos.color = Color.green;
		Gizmos.DrawLine(vertex, vertex + normal * scale);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(vertex, vertex + tangent * scale);
		Vector3 vector = Vector3.Cross(normal, tangent) * binormalSign;
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(vertex, vertex + vector * scale);
	}
}
