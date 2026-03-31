using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

	public class AvoidAT : ActionTask
	{
		public BBParameter<Vector3> moveDirectionBBP;
		public LayerMask obstacleLayers;
		public float closeRadius, nearRadius, farRadius;
		public float closeWeight, nearWeight, farWeight;

		protected override void OnUpdate()
		{
			Collider[] detectedObstacles = Physics.OverlapSphere(agent.transform.position, farRadius, obstacleLayers);
			foreach(Collider obstacle in detectedObstacles)
			{
				float weight;
				float distanceToObstacle = Vector3.Distance(agent.transform.position, obstacle.transform.position);

				if (distanceToObstacle < closeRadius)
					weight = closeWeight;
				else if (distanceToObstacle < nearRadius)
					weight = nearWeight;
				else
					weight = farWeight;

				Vector3 directionFromObstacle = (agent.transform.position - obstacle.transform.position).normalized;
				moveDirectionBBP.value += directionFromObstacle * weight;
			}
		}
	}
}