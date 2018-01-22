//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Change the DetectionType of the targeted AI. ")]
	public class EAI_SetDetectionType : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public Emerald_AI.DetectionType detectionTypeRef;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			detectionTypeRef =  Emerald_AI.DetectionType.Trigger;
			everyFrame = true;
		}
       
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<Emerald_AI>();


			if (!everyFrame.Value)
			{
				DoTheMagic();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				DoTheMagic();
			}
		}

		void DoTheMagic()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			theScript.DetectionTypeRef = detectionTypeRef;            
		}

	}
}