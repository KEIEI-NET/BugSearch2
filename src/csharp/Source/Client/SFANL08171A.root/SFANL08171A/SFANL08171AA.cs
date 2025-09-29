using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票印字位置Exportアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置Exportのアクセス制御を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.11.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class FrePrtPSetExportAcs
	{
		#region Delegate
		/// <summary>
		/// 自由帳票Exportイベントハンドラ
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="frePrtExport">自由帳票Exportクラス</param>
		/// <remarks>自由帳票印字位置設定がExportされる度に発生します。</remarks>
		public delegate void FrePrtPSetExportEventHandler(int status, string errMsg, FrePrtExport frePrtExport);
		#endregion

		#region Event
		/// <summary>自由帳票Exportイベント</summary>
		public event FrePrtPSetExportEventHandler FrePrtPSetExported;
		#endregion

		#region Const
		// 拡張子
		private const string ctExtension = ".dat";
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 印字位置ダウンロードアクセスクラス
		private SFANL08230AE		_frePrtPSetDLAcs;

		// --------------------------------------------------------
		// ☆☆☆ データクラス ☆☆☆
		// --------------------------------------------------------
		// 自由帳票ExportクラスList
		private List<FrePrtExport>	_frePrtExportList;
		// 画像管理マスタ
		private ImgManage			_imgManage;
		// 伝票印刷設定マスタList
		private List<SlipPrtSet>	_slipPrtSetList;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// エラーメッセージ
		private string				_errorStr;
		// 画像サーバーアクセスフラグ
		private bool				_isImageAccess;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrePrtPSetExportAcs()
		{
			_frePrtPSetDLAcs = new SFANL08230AE();
		}
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>自由帳票ExportクラスList</summary>
		public List<FrePrtExport> FrePrtExportList
		{
			get {
				if (_frePrtExportList == null)
					return new List<FrePrtExport>();
				else
					return _frePrtExportList;
			}
		}

		/// <summary>伝票印刷設定マスタList</summary>
		public List<SlipPrtSet> SlipPrtSetList
		{
			get {
				if (_slipPrtSetList == null)
					return new List<SlipPrtSet>();
				else
					return _slipPrtSetList;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 自由帳票Export情報検索処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		public int Search(string enterpriseCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			string errMsg = string.Empty;

			try
			{
				FrePrtPSetWork[] frePrtPSetArray;
				status = _frePrtPSetDLAcs.Search(enterpriseCode, string.Empty, out frePrtPSetArray, 0, ConstantManagement.LogicalMode.GetData0, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						_frePrtExportList = DBAndXMLDataMergeParts.CopyProperty<FrePrtExport>(frePrtPSetArray);
						// 帳票使用区分が伝票のものがある場合は伝票印刷設定マスタを取得
						if (_frePrtExportList.Exists(
								delegate(FrePrtExport frePrtExport)
								{
									if (frePrtExport.PrintPaperUseDivcd == 2)
										return true;
									else
										return false;
								}
							))
						{
							SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
							System.Collections.ArrayList retList;
							status = slipPrtSetAcs.SearchSlipPrtSet(out retList, enterpriseCode);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								_slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])retList.ToArray(typeof(SlipPrtSet)));
							}
							else
							{
								_errorStr = "伝票印刷設定の検索に失敗しました。";
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "自由帳票印字位置設定の検索に失敗しました。" + Environment.NewLine + "該当データがありません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						_errorStr = "「自由帳票印字位置設定」データの取得に失敗しました。" + Environment.NewLine + Environment.NewLine + "*詳細=" + errMsg;
						break;
					}
					default:
					{
						_errorStr = "自由帳票印字位置設定の検索処理にて例外が発生しました。" + Environment.NewLine + errMsg;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票Export情報検索処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 自由帳票Export処理
		/// </summary>
		/// <param name="filePath">保存先ファイルパス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: </br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		public int Export(string filePath)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 保存対象を取得
				List<FrePrtExport> targetFrePrtExportList
					= _frePrtExportList.FindAll(
						delegate(FrePrtExport frePrtExport)
						{
							if (frePrtExport.ExtractionItdedFlg == 1)
								return true;
							else
								return false;
						}
					);

				if (targetFrePrtExportList != null && targetFrePrtExportList.Count > 0)
				{
					List<FrePrtExport> writeFrePrtExportList;
					if (File.Exists(filePath))
						writeFrePrtExportList = (List<FrePrtExport>)XmlByteSerializer.Deserialize(filePath, typeof(List<FrePrtExport>));
					else
						writeFrePrtExportList = new List<FrePrtExport>();

					// ----------------------------------------------------
					// 自由帳票印字位置設定系の保存処理
					// ----------------------------------------------------
					// 自由帳票ローカルデータアクセスクラス
					FrePrtPosLocalAcs frePrtPosLocalAcs = new FrePrtPosLocalAcs();
					foreach (FrePrtExport frePrtExport in targetFrePrtExportList)
					{
						FrePrtPSet frePrtPSet = DBAndXMLDataMergeParts.CopyPropertyInClass<FrePrtPSet>(frePrtExport);

						string errMsg = string.Empty;
						try
						{
							List<FrePprECnd> frePprECndList;
							List<FrePprSrtO> frePprSrtOList;
							status = _frePrtPSetDLAcs.Read(ref frePrtPSet, out frePprECndList, out frePprSrtOList, out errMsg);
							if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
							{
								if (frePrtPSet.PrintPaperUseDivcd == 2 && frePrtExport.SlipPrtKind != 0)
									MergeSlipPrtSetMargin(frePrtPSet, frePrtExport.SlipPrtKind);

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //string fileName = frePrtPSet.OutputFormFileName + "_" + frePrtPSet.UserPrtPprIdDerivNo + ctExtension;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                string fileName = string.Empty;
                                if ( frePrtPSet.UserPrtPprIdDerivNo == 0 )
                                {
                                    fileName = frePrtPSet.OutputFormFileName + ctExtension;
                                }
                                else
                                {
                                    fileName = frePrtPSet.OutputFormFileName + "_" + frePrtPSet.UserPrtPprIdDerivNo + ctExtension;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
								string prtPosFilePath = Path.Combine(Path.GetDirectoryName(filePath), fileName);
								// ローカル保存
								status = frePrtPosLocalAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndList, frePprSrtOList, prtPosFilePath);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
								{
									// ローカル保存パスを相対パスに変換してExportクラスにセット
									Uri uri1 = new Uri(filePath);
									Uri uri2 = new Uri(uri1, prtPosFilePath);
									string uriStr = uri1.MakeRelativeUri(uri2).ToString();
									frePrtExport.ExportDataFilePath = System.Web.HttpUtility.UrlDecode(uriStr).Replace('/', '\\');

									// 同一KEYのExport情報がある場合はRemove
									writeFrePrtExportList.RemoveAll(
										delegate(FrePrtExport wkFrePrtExport)
										{
											if (wkFrePrtExport.EnterpriseCode == frePrtExport.EnterpriseCode &&
												wkFrePrtExport.OutputFormFileName == frePrtExport.OutputFormFileName &&
												wkFrePrtExport.UserPrtPprIdDerivNo == frePrtExport.UserPrtPprIdDerivNo)
												return true;
											else
												return false;
										}
									);
									// 自由帳票Export情報へ追加
									writeFrePrtExportList.Add(frePrtExport);

									// 画像データの取得
									if (frePrtPSet.TakeInImageGroupCd != Guid.Empty)
									{
										if (SearchImage(frePrtPSet.EnterpriseCode, frePrtPSet.TakeInImageGroupCd) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
											frePrtExport.SetPrintPprBgImageDataImage(_imgManage.TakeInImage);
									}
								}
								else
								{
									errMsg = frePrtPosLocalAcs.ErrorMessage;
								}
							}
							else if (status != (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
							{
								errMsg = "「" + frePrtPSet.DisplayName + "」の読込に失敗しました。st=" + status;
							}
						}
						catch (Exception ex)
						{
							errMsg = "「" + frePrtPSet.DisplayName + "」のExport処理にて例外が発生しました。" + Environment.NewLine + Environment.NewLine + "*詳細=" + ex.Message;
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
						}
						finally
						{
							this.FrePrtPSetExported(status, errMsg, frePrtExport);
						}
					}

					// ----------------------------------------------------
					// 自由帳票Export情報系の保存処理
					// ----------------------------------------------------
					if (writeFrePrtExportList.Count > 0)
					{
						XmlByteSerializer.Serialize(writeFrePrtExportList, filePath);
					}
					else
					{
						status		= (int)ConstantManagement.DB_Status.ctDB_EOF;
						_errorStr	= "自由帳票Exportに失敗しました。" + Environment.NewLine + "Export出来るデータがありません。";
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票Export処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 伝票印刷設定余白マージ処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定</param>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <remarks>
		/// <br>Note		: 自由帳票の余白設定を指定伝票印刷種別の伝票印刷設定で上書きします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void MergeSlipPrtSetMargin(FrePrtPSet frePrtPSet, int slipPrtKind)
		{
			SlipPrtSet slipPrtSet = _slipPrtSetList.Find(
				delegate(SlipPrtSet wkSlipPrtSet)
				{
					if (wkSlipPrtSet.EnterpriseCode == frePrtPSet.EnterpriseCode &&
						wkSlipPrtSet.DataInputSystem == frePrtPSet.DataInputSystem &&
						wkSlipPrtSet.SlipPrtKind == slipPrtKind &&
						wkSlipPrtSet.SlipPrtSetPaperId == frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo)
						return true;
					else
						return false;
				}
			);

			if (slipPrtSet != null)
			{
				ActiveReport3 rpt = new ActiveReport3();
				// レイアウト情報を呼び出し
				using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
				{
					stream.Position = 0;
					rpt.LoadLayout(stream);
					stream.Close();
				}
				
				// 伝票印刷設定の余白設定を適用
				rpt.PageSettings.Margins.Top	= ActiveReport3.CmToInch((float)slipPrtSet.TopMargin);
				rpt.PageSettings.Margins.Bottom	= ActiveReport3.CmToInch((float)slipPrtSet.BottomMargin);
				rpt.PageSettings.Margins.Left	= ActiveReport3.CmToInch((float)slipPrtSet.LeftMargin);
				rpt.PageSettings.Margins.Right	= ActiveReport3.CmToInch((float)slipPrtSet.RightMargin);

				// レイアウト情報を保存
				using (MemoryStream stream = new MemoryStream())
				{
					rpt.SaveLayout(stream);
					stream.Position = 0;
					frePrtPSet.PrintPosClassData = stream.ToArray();
					stream.Close();
				}
			}
		}

		/// <summary>
		/// 画像検索処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="takeInImageGroupCd">取込画像グループコード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された画像を画像サーバーより取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private int SearchImage(string enterpriseCode, Guid takeInImageGroupCd)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			_imgManage = new ImgManage();

			if (takeInImageGroupCd != null && takeInImageGroupCd != Guid.Empty)
			{
				// 画像管理アクセスクラス
				ImageImgAcs imageImgAcs = new ImageImgAcs();
				imageImgAcs.FileReceived += new EventHandler(ImageImgAcs_FileReceived);

				ImageGroup[] imageGroupArray;
				ImgManage[] imgManageArray;
				_isImageAccess = true;
				status = imageImgAcs.Search(out imageGroupArray, out imgManageArray, enterpriseCode, takeInImageGroupCd, 0, 100, true);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 画像グループマスタ
					if (imageGroupArray == null || imageGroupArray.Length == 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						_isImageAccess = false;
					}
					// 画像管理マスタ
					if (imgManageArray != null && imgManageArray.Length > 0)
					{
						_imgManage = imgManageArray[0];
					}
					else
					{
						status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						_isImageAccess = false;
					}

					// 非同期処理が完了するまでWait処理
					while (_isImageAccess) Thread.Sleep(100);
				}
			}

			return status;
		}

		/// <summary>
		/// ImageImgAcs_FileReceivedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 画像サーバーよりファイルを取得完了した時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ImageImgAcs_FileReceived(object sender, EventArgs e)
		{
			try
			{
				ImgManage[] imgManageArray = sender as ImgManage[];
				if (imgManageArray != null && imgManageArray.Length > 0)
				{
					_imgManage = imgManageArray[0];
				}
			}
			finally
			{
				_isImageAccess = false;
			}
		}
		#endregion
	}
}
