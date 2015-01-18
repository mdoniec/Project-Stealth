using System;
using rayav_csharp;
//using UnityEditor;

namespace RayaUtility
{
	public class RayaUtility
	{
		public static rayav_csharp.Vector3 fromUnityVector3(UnityEngine.Vector3 unityVector)
		{
			return new rayav_csharp.Vector3(unityVector.z, unityVector.y, unityVector.x);
		}
		
		public static rayav_csharp.Vector3 rayaPosition(UnityEngine.Vector3 unityVector)
		{
			return new rayav_csharp.Vector3(unityVector.z + 0.0386f, unityVector.y, unityVector.x + 0.183f);
		}
	}
}

