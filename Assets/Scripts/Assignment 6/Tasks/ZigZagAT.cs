using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.IO;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ZigZagAT : ActionTask
	{
		public BBParameter<Transform> toolkitBBP;
		public BBParameter<Transform> targetBBP;

		Vector3 path;

		public float offset;
		public float hopLength;


		protected override void OnExecute()
		{
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			path = (agent.transform.position - toolkitBBP.value.transform.position).normalized;
			Debug.Log(path);
		}
	}
}