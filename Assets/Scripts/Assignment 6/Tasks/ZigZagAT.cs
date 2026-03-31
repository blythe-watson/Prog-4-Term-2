using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ZigZagAT : ActionTask
	{
		public BBParameter<Transform> targetBBP;
		public BBParameter<Transform> waypointBBP;

		//the vector between the agent and the target
		Vector3 path;
		Vector3 hopSegment;

		public bool moveRight;
		public float offsetAngle;
		public float hopLength;

		public GameObject hopMarker;

		Quaternion offsetQuaternion;

        protected override void OnExecute()
		{
			offsetQuaternion = Quaternion.Euler(0, offsetAngle *= -1, 0);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			path = (targetBBP.value.transform.position - agent.transform.position);
			hopSegment = path.normalized;

			Vector3 firstSegment = offsetQuaternion * hopSegment;
            firstSegment *= hopLength;
			firstSegment.y = 0;
			
			waypointBBP.value.transform.position = agent.transform.position + firstSegment;
			
            //Debug.Log("finding hop point");
			EndAction(true);
		}
	}
}