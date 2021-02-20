using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Apollo
{
	[CreateAssetMenu(fileName = "DataConstraint_Branch_Elements", menuName = "Game/DataConstraint/BranchComposit")]
	public class DataConstraintBranchComposit : DataConstraint
	{
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

			foreach(var it in myBranches) {
				sb.Append("<div>" + it.ToHtml() + "</div>");
			}

			return sb.ToString();
		}
	}
}
