using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SeekSproutAT : ActionTask
    {
        public Blackboard agentBB;
        public BBParameter<float> seekRadiusBBP;
        public BBParameter<Transform> sproutTargetBBP;

        public BBParameter<LayerMask> sproutLayerBBP;

        public bool sproutTargeted;

        public float scanDuration = 3f;

        protected override string OnInit()
        {
            agentBB = agent.GetComponent<Blackboard>();
            return (null);
        }

		protected override void OnExecute()
		{
            DrawCircle(agent.transform.position, seekRadiusBBP.value, Color.red, 8, 2f);

            Collider[] sprouts = Physics.OverlapSphere(agent.transform.position, seekRadiusBBP.value, sproutLayerBBP.value);
            foreach (Collider sprout in sprouts)
            {
                sproutTargetBBP.value = sprout.GetComponent<Transform>().transform;
                sproutTargeted = true;
                agentBB.SetVariableValue("Sprout Target", sproutTargetBBP);
                Debug.Log("I smell a sprout");
                EndAction(true);
            }

            if(sprouts.Length == 0)
            {
                sproutTargetBBP.value = null;
                Debug.Log("no succulent sprouts detected");
            }

                EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			
		}
        private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints, float duration)
        {
            Vector3 startPoint, endPoint;
            int anglePerPoint = 360 / numberOfPoints;
            for (int i = 1; i <= numberOfPoints; i++)
            {
                startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i - 1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i - 1)));
                startPoint = center + startPoint * radius;
                endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
                endPoint = center + endPoint * radius;
                Debug.DrawLine(startPoint, endPoint, colour, duration);
            }


        }

    }
}