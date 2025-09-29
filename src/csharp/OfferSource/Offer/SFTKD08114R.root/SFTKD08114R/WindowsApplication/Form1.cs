using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplication
{
	public partial class Form1 : Form
	{
		private IPrtItemSetDB _iPrtItemSetDB = null;

		public Form1()
		{
			InitializeComponent();

			_iPrtItemSetDB = MediationPrtItemSetDB.GetPrtItemSetDB();
		}

		private void btnSearchPrtItemGrp_Click(object sender, EventArgs e)
		{
			try
			{
				object retObj;
				bool msgDiv;
				string errMsg;
				int status = _iPrtItemSetDB.SearchPrtItemGrp(out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.gridPrtItemGrp.DataSource = retObj;
						break;
					}
					default:
					{
						MessageBox.Show("Status:" + status.ToString().PadRight(3));
						this.gridPrtItemGrp.DataSource = null;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		private void btnSearchPrtItemSet_Click(object sender, EventArgs e)
		{
			try
			{
				int freePrtPprItemGrpCd = TStrConv.StrToIntDef(this.txtFreePrtPprItemGrpCd.Text, 0);
				object retObj;
				bool msgDiv;
				string errMsg;
				int status = _iPrtItemSetDB.SearchPrtItemSet(freePrtPprItemGrpCd, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.gridPrtItemSet.DataSource = retObj;
						break;
					}
					default:
					{
						MessageBox.Show("Status:" + status.ToString().PadRight(3));
						this.gridPrtItemSet.DataSource = null;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}
	}
}