//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Change the AlignAIWithGround of the targeted AI. ")]
	public class EAI_AlignAIWithGround : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public Emerald_AI.AlignAIWithGround alignAIWithGroundRef;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			alignAIWithGroundRef =  Emerald_AI.AlignAIWithGround.No;
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
			
			theScript.AlignAIWithGroundRef = alignAIWithGroundRef;            
		}

	}
}