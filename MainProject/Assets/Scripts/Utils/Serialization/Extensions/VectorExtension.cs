using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public static class VectorExtension
{
	public static string ToSerializeString(this Vector3 vector)
	{
		StringBuilder builder = new StringBuilder();

		builder.Append(vector.x).Append("_").Append(vector.y).Append("_").Append(vector.z);

		return builder.ToString();
	}

	public static Vector3 ToVector(this string vectorStr)
	{
		string[] elements = vectorStr.Split('_');

		float x = 0;
		float y = 0;
		float z = 0;

		float.TryParse(elements[0], out x);
		float.TryParse(elements[1], out y);
		float.TryParse(elements[2], out z);

		return new Vector3(x, y, z);
	}
}
