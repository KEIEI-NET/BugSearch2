using Broadleaf.Library.Windows.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	internal class TEditValueEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (value is TExtEdit)
			{
				TExtEditEditorForm tExtEditEditorForm = new TExtEditEditorForm();
				tExtEditEditorForm.SetValue((TExtEdit)value);
				if (tExtEditEditorForm.ShowDialog() == DialogResult.OK)
				{
					value = tExtEditEditorForm.GetValue();
				}
			}
			if (value is TExtCase)
			{
				TExtCaseEditorForm tExtCaseEditorForm = new TExtCaseEditorForm();
				tExtCaseEditorForm.SetValue((TExtCase)value);
				if (tExtCaseEditorForm.ShowDialog() == DialogResult.OK)
				{
					value = tExtCaseEditorForm.GetValue();
				}
			}
			return value;
		}
	}
}
