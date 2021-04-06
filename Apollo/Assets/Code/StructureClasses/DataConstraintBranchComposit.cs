using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Branch_Elements", menuName = "Game/DataConstraint/BranchComposit")]
	public class DataConstraintBranchComposit : DataConstraint
	{
		[Tooltip("eather one of the branches have to return true for this to return true")]
		[SerializeField] DataConstraint[] myBranches;

		public override bool IsInConstraint() {
			foreach(var it in myBranches) {
				if(it.IsInConstraint()) {
					return true;
				}
			}
			return false;
		}

		public override string ToHtml() {
			var sb = new StringBuilder();

			sb.Append("<div class='lLine'>");
			foreach(var it in myBranches) {
				sb.Append("<div style='display: flex;'>");
				sb.Append("<div><div class='bLine'> </div></div>");
				sb.Append(it.ToHtml());
				sb.Append("</div>");
			}
			sb.Append("</div>");

			return sb.ToString();
		}
	}
}
