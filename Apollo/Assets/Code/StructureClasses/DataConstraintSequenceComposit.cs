using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Sequence_Elements", menuName = "Game/DataConstraint/SequenceComposit")]
	public class DataConstraintSequenceComposit : DataConstraint
	{
		[SerializeField] DataConstraint[] mySequence;

		public override bool IsInConstraint() {
			foreach(var it in mySequence) {
				if(!it.IsInConstraint()) {
					return false;
				}
			}
			return true;
		}

		public override string ToHtml() {
			var sb = new StringBuilder();

			sb.Append("<div style = 'display: flex;'>");
			foreach(var it in mySequence) {
				sb.Append("<div>" + it.ToHtml() + "</div>");
			}
			sb.Append("</div>");

			return sb.ToString();
		}
	}
}
