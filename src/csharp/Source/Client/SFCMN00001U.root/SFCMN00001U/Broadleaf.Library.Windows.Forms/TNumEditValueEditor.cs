using Broadleaf.Library.Windows.Forms.Design;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
namespace Broadleaf.Library.Windows.Forms
{
	internal class TNumEditValueEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (value is TNumEdit)
			{
				TNumEditEditorForm tNumEditEditorForm = new TNumEditEditorForm();
				tNumEditEditorForm.SetValue((TNumEdit)value);
				if (tNumEditEditorForm.ShowDialog() == DialogResult.OK)
				{
					value = tNumEditEditorForm.GetValue();
				}
			}
			return value;
		}
	}
}
