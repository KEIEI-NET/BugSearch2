using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace WindowsApplication
{
	public partial class Form1 : Form
	{
		private DataTable dt1,dt2,dt3;
		private IFrePrtPSetDB iFrePrtPSetDB;

		public Form1()
		{
			InitializeComponent();

			iFrePrtPSetDB = MediationFrePrtPSetDB.GetFrePrtPSetDB();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.txtEnterpriseCode.Text = LoginInfoAcquisition.EnterpriseCode;

			dt1 = new DataTable("FrePrtPSetWork");
			PropertyInfo[] propertyInfoArray = typeof(FrePrtPSetWork).GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfoArray)
				dt1.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
			this.gridFrePrtPSet.DataSource = dt1;

			dt2 = new DataTable("FrePprECndWork");
			propertyInfoArray = typeof(FrePprECndWork).GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfoArray)
				dt2.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
			this.gridFrePprECnd.DataSource = dt2;

			dt3 = new DataTable("FrePprSrtOWork");
			propertyInfoArray = typeof(FrePprSrtOWork).GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfoArray)
				dt3.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
			this.gridFrePprSrtO.DataSource = dt3;
		}

		private void btnReadFrePrtPSet_Click(object sender, EventArgs e)
		{
			this.gridFrePrtPSet.ReadOnly = true;
			this.gridFrePprECnd.ReadOnly = true;
			this.gridFrePprSrtO.ReadOnly = true;

			this.btnWrite.Enabled = false;

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				object retObj;
				byte[] printPosClassData;
				bool msgDiv;
				string errMsg;
				status = iFrePrtPSetDB.Read(
					this.txtEnterpriseCode.Text,
					this.txtOutputFormFileName.Text,
					TStrConv.StrToIntDef(this.txtUserPrtPprIdDerivNo.Text, 0),
					out retObj,
					out printPosClassData,
					out msgDiv,
					out errMsg
					);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
						DispData(retList);
						break;
					}
					default:
					{
						MessageBox.Show("status:" + status.ToString().PadLeft(4));
						dt1.Rows.Clear();
						dt2.Rows.Clear();
						dt3.Rows.Clear();
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		private void btnNewRow1_Click(object sender, EventArgs e)
		{
			this.btnWrite.Enabled = true;

			this.gridFrePrtPSet.ReadOnly = false;
			this.dt1.Rows.Clear();
			
			DataRow dr = this.dt1.NewRow();
			this.dt1.Rows.Add(dr);
			dr["EnterpriseCode"]		= this.txtEnterpriseCode.Text;
			dr["OutputFormFileName"]	= this.txtOutputFormFileName.Text;
			dr["UserPrtPprIdDerivNo"]	= this.txtUserPrtPprIdDerivNo.Text;
		}

		private void btnNewRow2_Click(object sender, EventArgs e)
		{
			this.btnWrite.Enabled = true;

			this.gridFrePprECnd.ReadOnly = false;
			this.dt2.Rows.Clear();

			DataRow dr = this.dt2.NewRow();
			this.dt2.Rows.Add(dr);
			dr["EnterpriseCode"]		= this.txtEnterpriseCode.Text;
			dr["OutputFormFileName"]	= this.txtOutputFormFileName.Text;
			dr["UserPrtPprIdDerivNo"]	= this.txtUserPrtPprIdDerivNo.Text;
		}

		private void btnNewRow3_Click(object sender, EventArgs e)
		{
			this.btnWrite.Enabled = true;

			this.gridFrePprSrtO.ReadOnly = false;
			this.dt3.Rows.Clear();

			DataRow dr = this.dt3.NewRow();
			this.dt3.Rows.Add(dr);
			dr["EnterpriseCode"] = this.txtEnterpriseCode.Text;
			dr["OutputFormFileName"] = this.txtOutputFormFileName.Text;
			dr["UserPrtPprIdDerivNo"] = this.txtUserPrtPprIdDerivNo.Text;
		}

		private void ExtrCond_Leave(object sender, EventArgs e)
		{
			if (!this.txtOutputFormFileName.Text.Equals(string.Empty) &&
				!this.txtUserPrtPprIdDerivNo.Text.Equals(string.Empty))
			{
				this.btnNewRow1.Enabled			= true;
				this.btnNewRow2.Enabled			= true;
				this.btnNewRow3.Enabled			= true;
				this.btnReadFrePrtPSet.Enabled	= true;
			}
			else
			{
				this.btnNewRow1.Enabled			= false;
				this.btnNewRow2.Enabled			= false;
				this.btnNewRow3.Enabled			= false;
				this.btnWrite.Enabled			= false;
				this.btnReadFrePrtPSet.Enabled	= false;
			}
		}

		private void btnSearchFrePExCndD_Click(object sender, EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			object retObj;
			bool msgDiv;
			string errMsg;
			status = iFrePrtPSetDB.SearchFrePExCndD(
				LoginInfoAcquisition.EnterpriseCode,
				ConstantManagement.LogicalMode.GetData0,
				out retObj,
				out msgDiv,
				out errMsg
				);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					this.gridFrePExCndD.DataSource = retObj;
					break;
				}
				default:
				{
					MessageBox.Show("status:" + status.ToString().PadLeft(4));
					this.gridFrePExCndD.DataSource = null;
					break;
				}
			}
		}

		private void btnWrite_Click(object sender, EventArgs e)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			DataRow dr = null;
			CustomSerializeArrayList writeList = new CustomSerializeArrayList();
			if (!this.gridFrePrtPSet.Rows[0].IsNewRow)
			{
				dr = dt1.Rows[this.gridFrePrtPSet.Rows[0].Index];

				FrePrtPSetWork frePrtPSetWork = new FrePrtPSetWork();
				PropertyInfo[] propertyInfoArray = typeof(FrePrtPSetWork).GetProperties();
				foreach (PropertyInfo propertyInfo in propertyInfoArray)
				{
					if (!propertyInfo.Name.Equals("PrintPosClassData") &&
						!propertyInfo.Name.Equals("PrintPprBgImageData"))
					{
						if (!dr[propertyInfo.Name].Equals(DBNull.Value))
							propertyInfo.SetValue(frePrtPSetWork, dr[propertyInfo.Name], null);
					}
				}

				ArrayList wkList = new ArrayList();
				frePrtPSetWork.PrintPosClassData	= new byte[0];
				wkList.Add(frePrtPSetWork);
				writeList.Add(wkList);

				// 抽出条件
				List<FrePprECndWork> frePprECndWorkList = new List<FrePprECndWork>();
				foreach (DataGridViewRow dataGridViewRow in this.gridFrePprECnd.Rows)
				{
					if (!dataGridViewRow.IsNewRow)
					{
						dr = dt2.Rows[dataGridViewRow.Index];

						FrePprECndWork frePprECndWork = new FrePprECndWork();
						propertyInfoArray = typeof(FrePprECndWork).GetProperties();
						foreach (PropertyInfo propertyInfo in propertyInfoArray)
						{
							if (!dr[propertyInfo.Name].Equals(DBNull.Value))
								propertyInfo.SetValue(frePprECndWork, dr[propertyInfo.Name], null);
						}
						frePprECndWork.FrePrtPprExtraCondCd = dataGridViewRow.Index + 1;
						frePprECndWork.DisplayOrder = frePprECndWork.FrePrtPprExtraCondCd;
						frePprECndWorkList.Add(frePprECndWork);
					}
				}
				if (frePprECndWorkList.Count > 0)
					writeList.Add(new ArrayList(frePprECndWorkList.ToArray()));

				// ソート条件
				List<FrePprSrtOWork> frePprSrtOWorkList = new List<FrePprSrtOWork>();
				foreach (DataGridViewRow dataGridViewRow in this.gridFrePprSrtO.Rows)
				{
					if (!dataGridViewRow.IsNewRow)
					{
						dr = dt3.Rows[dataGridViewRow.Index];

						FrePprSrtOWork frePprSrtOWork = new FrePprSrtOWork();
						propertyInfoArray = typeof(FrePprSrtOWork).GetProperties();
						foreach (PropertyInfo propertyInfo in propertyInfoArray)
						{
							if (!dr[propertyInfo.Name].Equals(DBNull.Value))
								propertyInfo.SetValue(frePprSrtOWork, dr[propertyInfo.Name], null);
						}
						frePprSrtOWorkList.Add(frePprSrtOWork);
					}
				}
				if (frePprSrtOWorkList.Count > 0)
					writeList.Add(new ArrayList(frePprSrtOWorkList.ToArray()));

				object writeObj = (object)writeList;
				bool msgDiv;
				string errMsg;
				status = iFrePrtPSetDB.Write(
					ref writeObj,
					new byte[0],
					true,
					out msgDiv,
					out errMsg
					);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = (CustomSerializeArrayList)writeObj;
						DispData(retList);
						break;
					}
					default:
					{
						MessageBox.Show("status:" + status.ToString().PadLeft(4));
						dt1.Rows.Clear();
						dt2.Rows.Clear();
						break;
					}
				}
			}
		}

		private void btnGetLastUserPrtPprIdDerivNo_Click(object sender, EventArgs e)
		{
		}

		private void DispData(CustomSerializeArrayList retList)
		{
			for (int ix = 0 ; ix != retList.Count ; ix++)
			{
				ArrayList wkList = (ArrayList)retList[ix];
				if (wkList[0] is FrePrtPSetWork)
				{
					dt1.Rows.Clear();
					DataRow dr = dt1.NewRow();
					dt1.Rows.Add(dr);

					PropertyInfo[] propertyInfoArray = wkList[0].GetType().GetProperties();
					foreach (PropertyInfo propertyInfo in propertyInfoArray)
						dr[propertyInfo.Name] = propertyInfo.GetValue(wkList[0], null);
				}
				else if (wkList[0] is FrePprECndWork)
				{
					dt2.Rows.Clear();
					foreach (FrePprECndWork frePprECndWork in wkList)
					{
						DataRow dr = dt2.NewRow();
						dt2.Rows.Add(dr);

						PropertyInfo[] propertyInfoArray = frePprECndWork.GetType().GetProperties();
						foreach (PropertyInfo propertyInfo in propertyInfoArray)
							dr[propertyInfo.Name] = propertyInfo.GetValue(frePprECndWork, null);
					}
				}
				else if (wkList[0] is FrePprSrtOWork)
				{
					dt3.Rows.Clear();
					foreach (FrePprSrtOWork frePprSrtOWork in wkList)
					{
						DataRow dr = dt3.NewRow();
						dt3.Rows.Add(dr);

						PropertyInfo[] propertyInfoArray = frePprSrtOWork.GetType().GetProperties();
						foreach (PropertyInfo propertyInfo in propertyInfoArray)
							dr[propertyInfo.Name] = propertyInfo.GetValue(frePprSrtOWork, null);
					}
				}
			}
		}

		private void btnDeleteFrePprSrtO_Click(object sender, EventArgs e)
		{
		}

		private void gridFrePprSrtO_SelectionChanged(object sender, EventArgs e)
		{
			if (this.gridFrePprSrtO.SelectedRows.Count > 0)
				this.btnDeleteFrePprSrtO.Enabled = true;
			else
				this.btnDeleteFrePprSrtO.Enabled = false;
		}
	}
}