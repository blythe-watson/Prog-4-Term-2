using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.IO;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ZigZagAT : ActionTask
	{
		public BBParameter<Transform> toolkitBBP;
		public BBParameter<Transform> targetBBP;

		Transform path;

		public bool moveRight;
		public float offset;
		public float hopLength;
		public GameObject hopMarker;


		protected override void OnExecute()
		{
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			path.transform.position = (agent.transform.position - toolkitBBP.value.transform.position);
			
			if(moveRight)
			{
                path.transform.position += Vector3.right;
			}
			else 
			{
				path.transform.position += Vector3.left;
			}

			hopMarker.transform.position = path.transform.position;

				Debug.Log(path);
		}
	}
}