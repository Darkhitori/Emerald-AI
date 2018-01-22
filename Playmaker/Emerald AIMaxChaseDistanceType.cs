//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Change the MaxChaseDistance of the targeted AI. ")]
	public class EAI_MaxChaseDistanceType : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public Emerald_AI.MaxChaseDistanceType maxChaseDistanceTypeRef;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			maxChaseDistanceTypeRef =  Emerald_AI.MaxChaseDistanceType.TargetDistance;
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
			
			theScript.MaxChaseDistanceTypeRef = maxChaseDistanceTypeRef;            
		}

	}
}