//Darkhitori v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Emerald AI")]
	[Tooltip("Clears an AI's current target tags and updates them to the ones in the parameters. ")]
	public class EAI_UpdateTargetTags : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Emerald_AI))] 
		public FsmOwnerDefault gameObject;
		
		public FsmString NewAITag;
		public FsmString Tag1;
		public FsmString Tag2;
		public FsmString Tag3;
		public FsmString Tag4;
		public FsmString Tag5;

		public FsmBool everyFrame;

		Emerald_AI theScript;
  

		public override void Reset()
		{
			gameObject = null;
			NewAITag = "";
			Tag1 = "";
			Tag2 = "";
			Tag3 = "";
			Tag4 = "";
			Tag5 = "";
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

			theScript.UpdateTargetTags(NewAITag.Value, Tag1.Value, Tag2.Value, Tag3.Value, Tag4.Value, Tag5.Value);            
		}

	}
}