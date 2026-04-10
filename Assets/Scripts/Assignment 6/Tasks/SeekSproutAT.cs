using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SeekSproutAT : ActionTask
    {
        public BBParameter<float> seekRadiusBBP;
        public BBParameter<Transform> sproutTargetBBP;

        public BBParameter<LayerMask> sproutLayerBBP;

        public bool sproutTargeted;

		protected override void OnExecute()
		{
            Collider[] sprouts = Physics.OverlapSphere(agent.transform.position, seekRadiusBBP.value, sproutLayerBBP.value);
            foreach (Collider sprout in sprouts)
            {
                    sproutTargetBBP.value = sprout.GetComponent<Transform>().transform;
                    sproutTargeted = true;
                    Debug.Log("I smell a sprout");
               
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
	}
}