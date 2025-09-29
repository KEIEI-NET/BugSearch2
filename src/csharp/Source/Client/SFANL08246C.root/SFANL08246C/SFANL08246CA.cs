using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Xml.Xsl;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���R���[�c�[�����ʕ��i
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�J���p�c�[���̋��ʐ��䕔�i�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.07.03</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	public static class SFANL08246CA
	{
		#region Const
		// �e��t�@�C���p�X�nCONST��`
		/// <summary>CSV�o�͗pXSL�p�X</summary>
		public const string ctXSLFileName	= "SFANL08246C.xsl";
		/// <summary>CSV�ۑ��f�B���N�g��</summary>
		public const string ctCSVSavePath	= @".\CSV\";
		/// <summary>XML�ۑ��f�B���N�g��</summary>
		public const string ctXMLSavePath	= @".\XML\";
		// CSV�ۑ��pCONST��`
		private const string DS_DATASET		= "DataSet";
		private const string TBL_WRITETABLE	= "WriteTable";
		#endregion

		#region PublicMethod
		/// <summary>
		/// CSV�o�͏���
		/// </summary>
		/// <param name="ds">�ۑ��Ώ�DataSet</param>
		/// <param name="tableName">Table����</param>
		/// <param name="xslPath">XSL�t�@�C���p�X</param>
		/// <param name="csvPath">CSV�ۑ���p�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �n���ꂽDataSet��XSLT�𗘗p����CSV�ɕϊ����܂��B</br>
		/// <br>			: ��XSL��ύX���邱�Ƃ�HTML�Ȃǂ̏o�͂��\</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveCsv(DataSet ds, string tableName, string xslPath, string csvPath, out string errMsg)
		{
			int status = 0;

			status = SaveCsv(ds, tableName, xslPath, csvPath, false, out errMsg);

			return status;
		}

		/// <summary>
		/// CSV�o�͏���
		/// </summary>
		/// <param name="ds">�ۑ��Ώ�DataSet</param>
		/// <param name="tableName">Table����</param>
		/// <param name="xslPath">XSL�t�@�C���p�X</param>
		/// <param name="csvPath">CSV�ۑ���p�X</param>
		/// <param name="append">�ǋL���邩</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �n���ꂽDataSet��XSLT�𗘗p����CSV�ɕϊ����܂��B</br>
		/// <br>			: ��XSL��ύX���邱�Ƃ�HTML�Ȃǂ̏o�͂��\</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveCsv(DataSet ds, string tableName, string xslPath, string csvPath, bool append, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			try
			{
				XslCompiledTransform xslTran = new XslCompiledTransform();

				string xslFileName = Path.GetFileName(xslPath);
				if (xslFileName == ctXSLFileName)
				{
					XmlDocument doc = new XmlDocument();
					doc.LoadXml(Properties.Resources.SFANL08246C);
					xslTran.Load(doc);
				}
				else
				{
					xslTran.Load(xslPath);
				}

				// XSL�ɍ��v����DataSet�ɍ��ς�(Namespace�̕ϊ�����������)
				DataSet writeDataSet = new DataSet(DS_DATASET);
				DataTable dt = ds.Tables[tableName].Clone();
				dt.TableName = TBL_WRITETABLE;
				writeDataSet.Tables.Add(dt);
				foreach (DataRow dr in ds.Tables[tableName].Rows)
					writeDataSet.Tables[TBL_WRITETABLE].Rows.Add(dr.ItemArray);

				foreach (DataColumn col in writeDataSet.Tables[TBL_WRITETABLE].Columns)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
                    //// �����^�̍��ڂɁu"�v��t������
                    //if (col.DataType.Equals(typeof(string)))
                    //{
                    //    foreach (DataRow dr in writeDataSet.Tables[TBL_WRITETABLE].Rows)
                    //        dr[col] = "\"" + dr[col].ToString().Trim() + "\"";
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL

                    // ���l�^��DBNull�̏ꍇ��0���Z�b�g(Boolean�̏ꍇ��false)
					if (col.DataType.IsPrimitive)
					{
						foreach (DataRow dr in writeDataSet.Tables[TBL_WRITETABLE].Rows)
						{
							if (col.DataType.Equals(typeof(bool)) && dr[col].Equals(DBNull.Value))
								dr[col] = false;
							else if (dr[col].Equals(DBNull.Value))
								dr[col] = 0;
						}
					}
				}

				// DataSet��XML��
				XmlDataDocument xmlDoc = new XmlDataDocument(writeDataSet);

				if (!Directory.Exists(Path.GetDirectoryName(csvPath))) Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

				// XSLT�N���I�I
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
                //using (StreamWriter baseWriter = new StreamWriter(csvPath, append, Encoding.UTF8))
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
                using ( StreamWriter baseWriter = new StreamWriter( csvPath, append, Encoding.GetEncoding("SHIFT-JIS") ) )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
				{
					XmlTextWriter writer = new XmlTextWriter(baseWriter);

					xslTran.Transform(xmlDoc, null, writer);
					writer.Close();
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message + "\r\n" + ex.StackTrace;
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// XML�ۑ�����
		/// </summary>
		/// <param name="ds">�ۑ��Ώ�DataSet</param>
		/// <param name="xmlDirectory">XML�ۑ��f�B���N�g��</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �n���ꂽDataSet���XML���쐬���܂��B</br>
		/// <br>			: XML�̃t�@�C�����̓e�[�u�����ƂȂ�܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveXml(DataSet ds, string xmlDirectory, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			foreach (DataTable dt in ds.Tables)
			{
				string filePath = Path.Combine(xmlDirectory, dt.TableName + ".xml");
				status = SaveXml(ds, dt.TableName, string.Empty, filePath, out errMsg);
				if (status != 0)
					break;
			}

			return status;
		}

		/// <summary>
		/// XML�ۑ�����
		/// </summary>
		/// <param name="ds">�ۑ��Ώ�DataSet</param>
		/// <param name="tableName">DataTable����</param>
		/// <param name="filter">�t�B���^</param>
		/// <param name="xmlPath">XML�ۑ���p�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �n���ꂽDataSet���XML���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveXml(DataSet ds, string tableName, string filter, string xmlPath, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			try
			{
				// XSL�ɍ��v����DataSet�ɍ��ς�
				DataSet writeDataSet = new DataSet(ds.DataSetName);
				DataTable dt = ds.Tables[tableName].Clone();
				writeDataSet.Tables.Add(dt);
				// �w��s�݂̂𒊏o
				DataRow[] rowArray = ds.Tables[tableName].Select(filter);
				foreach (DataRow dr in rowArray)
					writeDataSet.Tables[tableName].Rows.Add(dr.ItemArray);

				if (!Directory.Exists(Path.GetDirectoryName(xmlPath))) Directory.CreateDirectory(Path.GetDirectoryName(xmlPath));

				writeDataSet.WriteXml(xmlPath);
			}
			catch (Exception ex)
			{
				errMsg = ex.Message + "\r\n" + ex.StackTrace;
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// XML�ۑ�����
		/// </summary>
		/// <param name="ds">�ۑ��Ώ�DataSet</param>
		/// <param name="tableName">DataTable����</param>
		/// <param name="filter">�t�B���^</param>
		/// <param name="sort">�\�[�g</param>
		/// <param name="xmlPath">XML�ۑ���p�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �n���ꂽDataSet���XML���쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveXml(DataSet ds, string tableName, string filter, string sort, string xmlPath, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			try
			{
				// XSL�ɍ��v����DataSet�ɍ��ς�
				DataSet writeDataSet = new DataSet(ds.DataSetName);
				DataTable dt = ds.Tables[tableName].Clone();
				writeDataSet.Tables.Add(dt);
				// �w��s�݂̂𒊏o
				DataRow[] rowArray = ds.Tables[tableName].Select(filter, sort);
				foreach (DataRow dr in rowArray)
					writeDataSet.Tables[tableName].Rows.Add(dr.ItemArray);

				if (!Directory.Exists(Path.GetDirectoryName(xmlPath))) Directory.CreateDirectory(Path.GetDirectoryName(xmlPath));

				writeDataSet.WriteXml(xmlPath);
			}
			catch (Exception ex)
			{
				errMsg = ex.Message + "\r\n" + ex.StackTrace;
				status = -1;
			}

			return status;
		}
		#endregion
	}
}
