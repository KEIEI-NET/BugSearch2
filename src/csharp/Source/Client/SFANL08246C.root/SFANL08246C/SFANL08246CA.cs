using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Xml.Xsl;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 自由帳票ツール共通部品
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票開発用ツールの共通制御部品です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.07.03</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	public static class SFANL08246CA
	{
		#region Const
		// 各種ファイルパス系CONST定義
		/// <summary>CSV出力用XSLパス</summary>
		public const string ctXSLFileName	= "SFANL08246C.xsl";
		/// <summary>CSV保存ディレクトリ</summary>
		public const string ctCSVSavePath	= @".\CSV\";
		/// <summary>XML保存ディレクトリ</summary>
		public const string ctXMLSavePath	= @".\XML\";
		// CSV保存用CONST定義
		private const string DS_DATASET		= "DataSet";
		private const string TBL_WRITETABLE	= "WriteTable";
		#endregion

		#region PublicMethod
		/// <summary>
		/// CSV出力処理
		/// </summary>
		/// <param name="ds">保存対象DataSet</param>
		/// <param name="tableName">Table名称</param>
		/// <param name="xslPath">XSLファイルパス</param>
		/// <param name="csvPath">CSV保存先パス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 渡されたDataSetをXSLTを利用してCSVに変換します。</br>
		/// <br>			: ※XSLを変更することでHTMLなどの出力も可能</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveCsv(DataSet ds, string tableName, string xslPath, string csvPath, out string errMsg)
		{
			int status = 0;

			status = SaveCsv(ds, tableName, xslPath, csvPath, false, out errMsg);

			return status;
		}

		/// <summary>
		/// CSV出力処理
		/// </summary>
		/// <param name="ds">保存対象DataSet</param>
		/// <param name="tableName">Table名称</param>
		/// <param name="xslPath">XSLファイルパス</param>
		/// <param name="csvPath">CSV保存先パス</param>
		/// <param name="append">追記するか</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 渡されたDataSetをXSLTを利用してCSVに変換します。</br>
		/// <br>			: ※XSLを変更することでHTMLなどの出力も可能</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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

				// XSLに合致するDataSetに作り変え(Namespaceの変換だけだけど)
				DataSet writeDataSet = new DataSet(DS_DATASET);
				DataTable dt = ds.Tables[tableName].Clone();
				dt.TableName = TBL_WRITETABLE;
				writeDataSet.Tables.Add(dt);
				foreach (DataRow dr in ds.Tables[tableName].Rows)
					writeDataSet.Tables[TBL_WRITETABLE].Rows.Add(dr.ItemArray);

				foreach (DataColumn col in writeDataSet.Tables[TBL_WRITETABLE].Columns)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
                    //// 文字型の項目に「"」を付加する
                    //if (col.DataType.Equals(typeof(string)))
                    //{
                    //    foreach (DataRow dr in writeDataSet.Tables[TBL_WRITETABLE].Rows)
                    //        dr[col] = "\"" + dr[col].ToString().Trim() + "\"";
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL

                    // 数値型でDBNullの場合は0をセット(Booleanの場合はfalse)
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

				// DataSet→XML化
				XmlDataDocument xmlDoc = new XmlDataDocument(writeDataSet);

				if (!Directory.Exists(Path.GetDirectoryName(csvPath))) Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

				// XSLT起動！！
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
		/// XML保存処理
		/// </summary>
		/// <param name="ds">保存対象DataSet</param>
		/// <param name="xmlDirectory">XML保存ディレクトリ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 渡されたDataSetよりXMLを作成します。</br>
		/// <br>			: XMLのファイル名はテーブル名となります。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// XML保存処理
		/// </summary>
		/// <param name="ds">保存対象DataSet</param>
		/// <param name="tableName">DataTable名称</param>
		/// <param name="filter">フィルタ</param>
		/// <param name="xmlPath">XML保存先パス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 渡されたDataSetよりXMLを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveXml(DataSet ds, string tableName, string filter, string xmlPath, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			try
			{
				// XSLに合致するDataSetに作り変え
				DataSet writeDataSet = new DataSet(ds.DataSetName);
				DataTable dt = ds.Tables[tableName].Clone();
				writeDataSet.Tables.Add(dt);
				// 指定行のみを抽出
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
		/// XML保存処理
		/// </summary>
		/// <param name="ds">保存対象DataSet</param>
		/// <param name="tableName">DataTable名称</param>
		/// <param name="filter">フィルタ</param>
		/// <param name="sort">ソート</param>
		/// <param name="xmlPath">XML保存先パス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 渡されたDataSetよりXMLを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.07.03</br>
		/// </remarks>
		public static int SaveXml(DataSet ds, string tableName, string filter, string sort, string xmlPath, out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			try
			{
				// XSLに合致するDataSetに作り変え
				DataSet writeDataSet = new DataSet(ds.DataSetName);
				DataTable dt = ds.Tables[tableName].Clone();
				writeDataSet.Tables.Add(dt);
				// 指定行のみを抽出
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
