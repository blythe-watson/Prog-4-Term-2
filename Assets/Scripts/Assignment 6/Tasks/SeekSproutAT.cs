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
            Collider[] plantables = Physics.OverlapSphere(agent.transform.position, seekRadiusBBP.value, sproutLayerBBP.value);
            foreach (Collider plot in plantables)
            {
                bool planted = plot.GetComponent<SproutManager>().planted;
                bool harvestable = plot.GetComponent<SproutManager>().harvestable;


                if (planted == false)
                {
                    sproutTargetBBP.value = plot.GetComponent<Transform>().transform;
                    sproutTargeted = true;
                    Debug.Log("I smell a sprout");
                }
                else
                {
                    sproutTargeted = true;
                    Debug.Log("no succulent sprouts nearby");
                }
            }
                EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			
		}
	}
}