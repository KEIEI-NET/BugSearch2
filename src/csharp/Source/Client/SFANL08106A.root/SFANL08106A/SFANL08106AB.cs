using System;
using System.IO;
using System.Text;
using System.Collections;
using System.IO.Compression;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

using ar=DataDynamics.ActiveReports;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票印字位置設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置情報へのアクセス制御を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.04</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	public class FrePrtPSetAcs
	{
		#region PrivateMember
		// 印字位置設定系リモートインターフェース
		private IFrePrtPSetDB	_iFrePrtPSetDB;
		// エラーメッセージ
		private string			_errorStr;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrePrtPSetAcs()
		{
			_iFrePrtPSetDB	= MediationFrePrtPSetDB.GetFrePrtPSetDB();
		}
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ログ出力処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="logMessage">ログメッセージ</param>
		/// <remarks>
		/// <br>Note		: 指定されたログメッセージを保存します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		internal void WriteLog(string enterpriseCode, string employeeCode, string logMessage)
		{
			_iFrePrtPSetDB.WriteLog(enterpriseCode, employeeCode, logMessage);
		}

		/// <summary>
		/// ユーザー帳票ID枝番号取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <returns>ユーザー帳票ID枝番号</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報の枝番号を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int GetUserPrtPprIdDerivNo(string enterpriseCode, string outputFormFileName)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// 最終ユーザー帳票ID枝番号取得処理
            //int userPrtPprIdDerivNo = _iFrePrtPSetDB.GetLastUserPrtPprIdDerivNo(enterpriseCode, outputFormFileName);

            //return ++userPrtPprIdDerivNo;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            // 枝番はゼロ固定
            return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		}

		/// <summary>
		/// 自由帳票印字位置設定読込処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="frePprECndList">自由帳票抽出条件LIST</param>
		/// <param name="frePprSrtOList">自由帳票ソート順位LIST</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int ReadDBFrePrtPSet(ref FrePrtPSet frePrtPSet, out List<FrePprECnd> frePprECndList, out List<FrePprSrtO> frePprSrtOList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			frePprECndList	= new List<FrePprECnd>();
			frePprSrtOList	= new List<FrePprSrtO>();

			try
			{
				object retObj;
				bool msgDiv;
				byte[] printPosClassData;
				string errMsg;
				// リモーティング
				status = _iFrePrtPSetDB.Read(
					frePrtPSet.EnterpriseCode,
					frePrtPSet.OutputFormFileName,
					frePrtPSet.UserPrtPprIdDerivNo,
					out retObj,
					out printPosClassData,
					out msgDiv,
					out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList customRetList = (CustomSerializeArrayList)retObj;
						for (int ix = 0 ; ix != customRetList.Count ; ix++)
						{
							ArrayList retList = (ArrayList)customRetList[ix];
							if (retList[0] is FrePrtPSetWork)
							{
								frePrtPSet = (FrePrtPSet)DBAndXMLDataMergeParts.CopyPropertyInClass(retList[0], typeof(FrePrtPSet));
								frePrtPSet.PrintPosClassData = printPosClassData;

								FrePrtSettingController.DecryptPrintPosClassData(frePrtPSet);
							}
							else if (retList[0] is FrePprECndWork)
							{
								ArrayList wkList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(FrePprECnd));
								frePprECndList.AddRange((FrePprECnd[])wkList.ToArray(typeof(FrePprECnd)));
							}
							else if (retList[0] is FrePprSrtOWork)
							{
								ArrayList wkList = DBAndXMLDataMergeParts.CopyPropertyInList(retList, typeof(FrePprSrtO));
								frePprSrtOList.AddRange((FrePprSrtO[])wkList.ToArray(typeof(FrePprSrtO)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					{
						_errorStr = "自由帳票印字位置設定の読込に失敗しました。";
						_errorStr += "\r\n" + "指定されたデータは存在しません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「自由帳票印字位置設定」データの取得に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "自由帳票印字位置設定の読込に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "自由帳票印字位置設定の読込に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票印字位置設定の読込処理にて例外が発生しました。";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 自由帳票印字位置設定書き込み処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="frePprECndList">自由帳票抽出条件LIST</param>
		/// <param name="frePprSrtOList">自由帳票ソート順位LIST</param>
		/// <param name="isNewWrite">新規登録</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報を登録します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, bool isNewWrite)
		{
            //return WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, null, isNewWrite );
            return WriteDBFrePrtPSet( ref frePrtPSet, ref frePprECndList, ref frePprSrtOList, null, null, isNewWrite );
        }

		/// <summary>
		/// 自由帳票印字位置設定書き込み処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="frePprECndList">自由帳票抽出条件LIST</param>
		/// <param name="frePprSrtOList">自由帳票ソート順位LIST</param>
		/// <param name="slipPrtSetList">伝票印刷設定LIST</param>
        /// <param name="dmdPrtPtnList">請求書印刷パターン設定LIST</param>
		/// <param name="isNewWrite">新規登録</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された自由帳票印字位置情報を登録します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, List<SlipPrtSetWork> slipPrtSetList, bool isNewWrite)
        public int WriteDBFrePrtPSet(ref FrePrtPSet frePrtPSet, ref List<FrePprECnd> frePprECndList, ref List<FrePprSrtO> frePprSrtOList, List<SlipPrtSetWork> slipPrtSetList, List<DmdPrtPtnWork> dmdPrtPtnList, bool isNewWrite)
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ☆☆☆ パラメータの作成 ☆☆☆
				// パラメータ用CustomSerializeArrayListを作成
				CustomSerializeArrayList writeList = new CustomSerializeArrayList();

				// 伝票印刷設定LIST（伝票の新規登録だったら処理）
				if (slipPrtSetList != null && slipPrtSetList.Count > 0)
				{
					ArrayList slipPrtSetWorkList = new ArrayList(slipPrtSetList);
					writeList.Add(slipPrtSetWorkList);
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                // 請求書印刷パターン設定LIST（請求書の新規登録だったら処理）
                if ( dmdPrtPtnList != null && dmdPrtPtnList.Count > 0 )
                {
                    ArrayList dmdPrtPtnWorkList = new ArrayList( dmdPrtPtnList );
                    writeList.Add( dmdPrtPtnWorkList );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
				
				// 自由帳票印字位置設定マスタ
				byte[] buffPrintPosClassData = frePrtPSet.PrintPosClassData;
				// バイナリデータの暗号化
				FrePrtSettingController.EncryptPrintPosClassData(frePrtPSet);
				ArrayList frePrtPSetWorkList = new ArrayList();
				frePrtPSetWorkList.Add((FrePrtPSetWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePrtPSet, typeof(FrePrtPSetWork)));
				writeList.Add(frePrtPSetWorkList);
				
				// 自由帳票抽出条件設定LIST
				if (frePprECndList != null && frePprECndList.Count > 0)
				{
					ArrayList frePprECndWorkList = DBAndXMLDataMergeParts.CopyPropertyInArray(frePprECndList.ToArray(), typeof(FrePprECndWork));
					writeList.Add(frePprECndWorkList);
				}
				
				// 自由帳票ソート順位LIST
				if (frePprSrtOList != null && frePprSrtOList.Count > 0)
				{
					ArrayList frePprSrtOWorkList = DBAndXMLDataMergeParts.CopyPropertyInArray(frePprSrtOList.ToArray(), typeof(FrePprSrtOWork));
					writeList.Add(frePprSrtOWorkList);
				}
				object writeObj = (object)writeList;

				// リモーティング
				bool msgDiv;
				string errMsg;
				status = _iFrePrtPSetDB.Write(ref writeObj, frePrtPSet.PrintPosClassData, isNewWrite, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						writeList = (CustomSerializeArrayList)writeObj;
						for (int ix = 0 ; ix != writeList.Count ; ix++)
						{
							ArrayList wkList = (ArrayList)writeList[ix];
							if (wkList[0] is FrePrtPSetWork)
							{
								frePrtPSet = (FrePrtPSet)DBAndXMLDataMergeParts.CopyPropertyInClass(wkList[0], typeof(FrePrtPSet));
								frePrtPSet.PrintPosClassData	= buffPrintPosClassData;
							}
							else if (wkList[0] is FrePprECndWork)
							{
								frePprECndList.Clear();
								wkList = DBAndXMLDataMergeParts.CopyPropertyInList(wkList, typeof(FrePprECnd));
								frePprECndList.AddRange((FrePprECnd[])wkList.ToArray(typeof(FrePprECnd)));
							}
							else if (wkList[0] is FrePprSrtOWork)
							{
								frePprSrtOList.Clear();
								wkList = DBAndXMLDataMergeParts.CopyPropertyInList(wkList, typeof(FrePprSrtO));
								frePprSrtOList.AddRange((FrePprSrtO[])wkList.ToArray(typeof(FrePprSrtO)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					{
						_errorStr = "既に他端末より更新されています。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						_errorStr = "既に他端末より削除されています。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「自由帳票印字位置設定」データの保存に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "自由帳票印字位置設定の保存に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "自由帳票印字位置設定の保存処理に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票印字位置設定の保存処理にて例外が発生しました。";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 自由帳票抽出条件明細LIST取得処理（全件）
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="frePExCndDList">自由帳票抽出条件明細LIST</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件明細ワークマスタ配列を全件取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchFrePExCndDList(string enterpriseCode, out List<FrePExCndD> frePExCndDList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			frePExCndDList = null;

			try
			{
				// リモーティング
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iFrePrtPSetDB.SearchFrePExCndD(enterpriseCode, ConstantManagement.LogicalMode.GetData0, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ArrayList wkFrePExCndDList = DBAndXMLDataMergeParts.CopyPropertyInArray((FrePExCndDWork[])retObj, typeof(FrePExCndD));
						frePExCndDList = new List<FrePExCndD>((FrePExCndD[])wkFrePExCndDList.ToArray(typeof(FrePExCndD)));
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「自由帳票抽出条件明細」データの保存に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "自由帳票抽出条件明細の検索に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "自由帳票抽出条件明細の検索に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票抽出条件明細の検索処理にて例外が発生しました。";
				_errorStr += "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
		#endregion

		#region PublicStaticMethod
		/// <summary>
		/// 伝票印刷設定LIST作成処理
		/// </summary>
		/// <param name="slipPrtKindList">伝票印刷種別LIST</param>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <param name="prtItemGrpList">印字項目グループマスタリスト</param>
		/// <returns>伝票印刷設定LIST</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票印字位置設定より伝票印刷設定をCreateします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public static List<SlipPrtSetWork> CreateSlipPrtSet(List<int> slipPrtKindList, FrePrtPSet frePrtPSet, List<PrtItemGrpWork> prtItemGrpList)
		{
			List<SlipPrtSetWork> slipPrtSetList = new List<SlipPrtSetWork>();

			// 印字項目グループコードを取得
			PrtItemGrpWork prtItemGrpWork = prtItemGrpList.Find(
					delegate(PrtItemGrpWork wkPrtItemGrpWork)
					{
						if (wkPrtItemGrpWork.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

			ar.ActiveReport3 rpt = new ar.ActiveReport3();
			using (MemoryStream stream = new MemoryStream(frePrtPSet.PrintPosClassData))
			{
				rpt.LoadLayout(stream);

				foreach (int slipPrtKind in slipPrtKindList)
				{
					SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
					// 新規登録用なので共通ファイルヘッダーは企業コード以外設定しない
					slipPrtSetWork.EnterpriseCode		= frePrtPSet.EnterpriseCode;		// 企業コード
					slipPrtSetWork.SlipPrtKind			= slipPrtKind;						// 伝票種別
					slipPrtSetWork.DataInputSystem		= frePrtPSet.DataInputSystem;		// データ入力システム
					// 伝票印刷設定用帳票ID
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //slipPrtSetWork.SlipPrtSetPaperId	= frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/02/19 ADD
                    slipPrtSetWork.SlipPrtSetPaperId = GetPaperId( slipPrtKind, frePrtPSet );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/02/19 ADD
					slipPrtSetWork.OutputPgId			= frePrtPSet.OutputPgId;			// 出力プログラムID
					slipPrtSetWork.OutputPgClassId		= frePrtPSet.OutputPgClassId;		// 出力プログラムクラスID
					slipPrtSetWork.OutputFormFileName	= frePrtPSet.OutputFormFileName;	// 出力ファイル名
					slipPrtSetWork.OutConfimationMsg	= frePrtPSet.OutConfimationMsg;		// 出力確認メッセージ
					slipPrtSetWork.OptionCode			= frePrtPSet.OptionCode;			// オプションコード
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //slipPrtSetWork.ExtractionPgId		= frePrtPSet.ExtractionPgId;		// 抽出プログラムID
                    //slipPrtSetWork.ExtractionPgClassId	= frePrtPSet.ExtractionPgClassId;	// 抽出プログラムクラスID
                    //slipPrtSetWork.UserPrtPprIdDerivNo	= frePrtPSet.UserPrtPprIdDerivNo;	// ユーザー帳票ID枝番号
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					slipPrtSetWork.SlipComment			= frePrtPSet.DisplayName;			// 伝票コメント
					slipPrtSetWork.PrtCirculation		= 1;								// 印刷部数
					//slipPrtSetWork.PrinterMngNo			= 1;								// プリンタ管理No
					slipPrtSetWork.PrtPreviewExistCode	= 0;								// 印刷プレビュ有無区分
					slipPrtSetWork.SlipFontName			= "ＭＳ 明朝";						// 伝票フォント名称
					slipPrtSetWork.CopyCount			= 1;								// 複写枚数
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 DEL
                    //slipPrtSetWork.TitleName1			= frePrtPSet.DisplayName;			// タイトル1
                    //slipPrtSetWork.TitleName2			= frePrtPSet.DisplayName;			// タイトル2
                    //slipPrtSetWork.TitleName3			= frePrtPSet.DisplayName;			// タイトル3
                    //slipPrtSetWork.TitleName4			= frePrtPSet.DisplayName;			// タイトル4
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
                    slipPrtSetWork.TitleName1 = GetTitle( slipPrtKind, frePrtPSet ); // タイトル1
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD
					slipPrtSetWork.SpecialPurpose1		= "20";								// 特殊用途1
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                    //slipPrtSetWork.SpecialPurpose2 = frePrtPSet.UserPrtPprIdDerivNo.ToString(); // 特殊用途2
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
					slipPrtSetWork.EnterpriseNamePrtCd	= 0;								// 自社名印刷区分
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //slipPrtSetWork.CustTelNoPrtDivCd	= 1;								// 得意先電話番号印字区分（0:印字しない,1:印字する）
                    //slipPrtSetWork.MainWorkLinePrtDivCd	= 1;								// 主作業行印字区分（0:非印字,1:印字）
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					if (prtItemGrpWork != null)
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                        //slipPrtSetWork.LinkSlipDataInputSys	= prtItemGrpWork.LinkSlipDataInputSys;	// リンク伝票データ入力システム
                        //slipPrtSetWork.LinkSlipPrtKind		= prtItemGrpWork.LinkSlipPrtKind;		// リンク伝票印刷種別
                        //slipPrtSetWork.LinkSlipPrtSetPprId	= prtItemGrpWork.LinkSlipPrtSetPprId;	// リンク伝票印刷設定用帳票ID
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
                    slipPrtSetWork.DetailRowCount = frePrtPSet.FormFeedLineCount; // 明細行数
                    slipPrtSetWork.ReissueMark = "再発行";
                    slipPrtSetWork.HonorificTitle = "様";
                    slipPrtSetWork.RefConsTaxDivCd = 1;
                    slipPrtSetWork.RefConsTaxPrtNm = "参考消費税";
                    slipPrtSetWork.ConsTaxPrtCd = 1; // ?
                    slipPrtSetWork.ConsTaxPrtCdRF = 1; // ?
                    slipPrtSetWork.TimePrintDivCd = 1;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD

					if (rpt != null)
					{
						// 上余白
						slipPrtSetWork.TopMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Top), 0);
						// 左余白
						slipPrtSetWork.LeftMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Left), 0);
						// 下余白
						slipPrtSetWork.BottomMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Bottom), 0);
						// 右余白
						slipPrtSetWork.RightMargin	= Math.Round(ar.ActiveReport3.InchToCm(rpt.PageSettings.Margins.Right), 0);
					}

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/20 ADD
                    switch ( slipPrtKind )
                    {
                        // 見積書
                        case 10:
                            {
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "品番", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BLｺｰﾄﾞ", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "標準価格", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "売価", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "原価", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "担当者", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "受注者", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "発行者", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "取寄マーク(*)", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // 仕入返品
                        case 40:
                            {
                            }
                            break;
                        // 売上
                        case 30:
                        // 受注
                        case 120:
                        // 貸出
                        case 130:
                        // 見積
                        case 140:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "品番", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BLｺｰﾄﾞ", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "標準価格", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "売価", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "原価", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "担当者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "受注者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "発行者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "取寄マーク(*)", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // ＵＯＥ伝票
                        case 160:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "品番", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BLｺｰﾄﾞ", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "標準価格", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "SalesPrice", "売価", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "Cost", "原価", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesEmployee", "担当者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "FrontEmployee", "受注者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "SalesInput", "発行者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "SalesOrderDiv", "取寄マーク(*)", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        // 在庫移動
                        case 150:
                            {
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 1, "GoodsNo", "品番", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 2, "BLGoodsCode", "BLｺｰﾄﾞ", 1 );
                                //ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice", "標準価格", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 3, "ListPrice1", "標準価格", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 4, "Cost", "原価", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 5, "SalesEmployee", "担当者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 6, "SalesInput", "発行者", 1 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 7, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 8, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 9, "", "", 0 );
                                ReflectSlipPrtSetEachSlipTypeCol( ref slipPrtSetWork, 10, "", "", 0 );
                            }
                            break;
                        default:
                            break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/20 ADD

					slipPrtSetList.Add(slipPrtSetWork);
				}
				stream.Close();
			}

			return slipPrtSetList;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/11 ADD
        /// <summary>
        /// 伝票ID取得処理
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private static string GetPaperId( int slipPrtKind, FrePrtPSet frePrtPSet )
        {
            //------------------------------------------------------
            // 伝票印刷パターン設定の帳票IDを返します。
            //------------------------------------------------------
            switch ( slipPrtKind )
            {
                // 売上
                case 30:
                default:
                    return frePrtPSet.OutputFormFileName;
                // 受注
                case 120:
                    return GetPaperIdProc( "J", frePrtPSet.OutputFormFileName );
                // 貸出
                case 130:
                    return GetPaperIdProc( "K", frePrtPSet.OutputFormFileName );
                // 見積
                case 140:
                    return GetPaperIdProc( "M", frePrtPSet.OutputFormFileName );
                // 見積書
                case 10:
                // 仕入返品
                case 40:
                // ＵＯＥ伝票
                case 160:
                // 在庫移動
                case 150:
                    return frePrtPSet.OutputFormFileName;
            }
        }
        /// <summary>
        /// 伝票ID取得処理サブ
        /// </summary>
        /// <param name="head"></param>
        /// <param name="originName"></param>
        /// <returns></returns>
        private static string GetPaperIdProc( string head, string originName )
        {
            // Aで始まる場合のみJ,K,Mなどと差し替える
            if ( originName.StartsWith( "A" ) )
            {
                return (head + originName.Substring( 1, originName.Length - 1 ));
            }
            else
            {
                return originName;
            }
        }
        /// <summary>
        /// 伝票タイトル（初期値）取得処理
        /// </summary>
        /// <param name="slipPrtKind"></param>
        /// <param name="frePrtPSet"></param>
        /// <returns></returns>
        private static string GetTitle( int slipPrtKind, FrePrtPSet frePrtPSet )
        {
            switch ( slipPrtKind )
            {
                // 見積書
                case 10:
                    return "見積書";
                // 仕入返品
                case 40:
                    return "返品伝票";
                // 売上
                case 30:
                default:
                    return "納品書";
                // 受注
                case 120:
                    return "受注伝票";
                // 貸出
                case 130:
                    return "貸出伝票";
                // 見積
                case 140:
                    return "見積伝票";
                // ＵＯＥ伝票
                case 160:
                    return "ＵＯＥ伝票";
                // 在庫移動
                case 150:
                    return "在庫移動伝票";
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/11 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        /// <summary>
        /// 伝票タイプ別設定項目のセット処理
        /// </summary>
        /// <param name="slipPrtSetWork"></param>
        /// <param name="index"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="printDiv"></param>
        private static void ReflectSlipPrtSetEachSlipTypeCol( ref SlipPrtSetWork slipPrtSetWork, int index, string id, string name, int printDiv )
        {
            switch ( index )
            {
                case 1:
                    {
                        slipPrtSetWork.EachSlipTypeColId1 = id;
                        slipPrtSetWork.EachSlipTypeColNm1 = name;
                        slipPrtSetWork.EachSlipTypeColPrt1 = printDiv;
                    }
                    break;
                case 2:
                    {
                        slipPrtSetWork.EachSlipTypeColId2 = id;
                        slipPrtSetWork.EachSlipTypeColNm2 = name;
                        slipPrtSetWork.EachSlipTypeColPrt2 = printDiv;
                    }
                    break;
                case 3:
                    {
                        slipPrtSetWork.EachSlipTypeColId3 = id;
                        slipPrtSetWork.EachSlipTypeColNm3 = name;
                        slipPrtSetWork.EachSlipTypeColPrt3 = printDiv;
                    }
                    break;
                case 4:
                    {
                        slipPrtSetWork.EachSlipTypeColId4 = id;
                        slipPrtSetWork.EachSlipTypeColNm4 = name;
                        slipPrtSetWork.EachSlipTypeColPrt4 = printDiv;
                    }
                    break;
                case 5:
                    {
                        slipPrtSetWork.EachSlipTypeColId5 = id;
                        slipPrtSetWork.EachSlipTypeColNm5 = name;
                        slipPrtSetWork.EachSlipTypeColPrt5 = printDiv;
                    }
                    break;
                case 6:
                    {
                        slipPrtSetWork.EachSlipTypeColId6 = id;
                        slipPrtSetWork.EachSlipTypeColNm6 = name;
                        slipPrtSetWork.EachSlipTypeColPrt6 = printDiv;
                    }
                    break;
                case 7:
                    {
                        slipPrtSetWork.EachSlipTypeColId7 = id;
                        slipPrtSetWork.EachSlipTypeColNm7 = name;
                        slipPrtSetWork.EachSlipTypeColPrt7 = printDiv;
                    }
                    break;
                case 8:
                    {
                        slipPrtSetWork.EachSlipTypeColId8 = id;
                        slipPrtSetWork.EachSlipTypeColNm8 = name;
                        slipPrtSetWork.EachSlipTypeColPrt8 = printDiv;
                    }
                    break;
                case 9:
                    {
                        slipPrtSetWork.EachSlipTypeColId9 = id;
                        slipPrtSetWork.EachSlipTypeColNm9 = name;
                        slipPrtSetWork.EachSlipTypeColPrt9 = printDiv;
                    }
                    break;
                case 10:
                    {
                        slipPrtSetWork.EachSlipTypeColId10 = id;
                        slipPrtSetWork.EachSlipTypeColNm10 = name;
                        slipPrtSetWork.EachSlipTypeColPrt10 = printDiv;
                    }
                    break;
                default:
                    break;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
        /// <summary>
        /// 請求書印刷パターン設定LIST作成処理
        /// </summary>
        /// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
        /// <param name="prtItemGrpList">印字項目グループマスタリスト</param>
        /// <returns>請求書印刷パターン設定LIST</returns>
        /// <remarks>
        /// <br>Note         : 自由帳票印字位置設定より請求書印刷パターン設定をCreateします。</br>
        /// <br>               　なお、返却値がListになっているのは伝票印刷設定作成メソッドに合わせる為で、</br>
        /// <br>               　実際には１レコードしか生成しません。</br>
        /// <br>Programmer   : 22018 鈴木 正臣</br>
        /// <br>Date         : 2007.06.11</br>
        /// </remarks>
        public static List<DmdPrtPtnWork> CreateDmdPrtPtnList( FrePrtPSet frePrtPSet, List<PrtItemGrpWork> prtItemGrpList )
        {
            List<DmdPrtPtnWork> dmdPrtPtnWorkList = new List<DmdPrtPtnWork>();

            // 印字項目グループコードを取得
            PrtItemGrpWork prtItemGrpWork = prtItemGrpList.Find(
                    delegate( PrtItemGrpWork wkPrtItemGrpWork )
                    {
                        if ( wkPrtItemGrpWork.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd )
                            return true;
                        else
                            return false;
                    }
                );

            ar.ActiveReport3 rpt = new ar.ActiveReport3();
            using ( MemoryStream stream = new MemoryStream( frePrtPSet.PrintPosClassData ) )
            {
                rpt.LoadLayout( stream );

                DmdPrtPtnWork dmdPrtPtnWork = new DmdPrtPtnWork();
                // 新規登録用なので共通ファイルヘッダーは企業コード以外設定しない
                dmdPrtPtnWork.EnterpriseCode = frePrtPSet.EnterpriseCode;		// 企業コード
                dmdPrtPtnWork.SlipPrtKind = frePrtPSet.FreePrtPprSpPrpseCd;     // 伝票印刷種別（←請求書種別を格納）
                dmdPrtPtnWork.DataInputSystem = frePrtPSet.DataInputSystem;		// データ入力システム
                // 伝票印刷設定用帳票ID
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
                //dmdPrtPtnWork.SlipPrtSetPaperId = frePrtPSet.OutputFormFileName + frePrtPSet.UserPrtPprIdDerivNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 ADD
                dmdPrtPtnWork.SlipPrtSetPaperId = frePrtPSet.OutputFormFileName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 ADD
                dmdPrtPtnWork.OutputFormFileName = frePrtPSet.OutputFormFileName;	// 出力ファイル名
                dmdPrtPtnWork.SlipComment = frePrtPSet.DisplayName;			// 伝票コメント
                dmdPrtPtnWork.CopyCount = 1;								// 複写枚数

                if ( rpt != null )
                {
                    // 上余白
                    dmdPrtPtnWork.TopMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Top ), 1 );
                    // 左余白
                    dmdPrtPtnWork.LeftMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Left ), 1 );
                    // 下余白
                    dmdPrtPtnWork.BottomMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Bottom ), 1 );
                    // 右余白
                    dmdPrtPtnWork.RightMargin = Math.Round( ar.ActiveReport3.InchToCm( rpt.PageSettings.Margins.Right ), 1 );
                }


                // ※↓注意！ 以下の鑑項目のタイトル・区分値は保守が必要になる可能性があります。
                //     変更になった場合は、請求書印刷パターンマスメンを参考にして下さい。
                dmdPrtPtnWork.DmdTtlFormTitle1 = "前回請求額";
                dmdPrtPtnWork.DmdTtlFormTitle2 = "今回入金額";
                dmdPrtPtnWork.DmdTtlFormTitle3 = "繰越請求額";
                dmdPrtPtnWork.DmdTtlFormTitle4 = "今回税抜相殺請求額";
                dmdPrtPtnWork.DmdTtlFormTitle5 = "今回相殺消費税額";
                dmdPrtPtnWork.DmdTtlFormTitle6 = "今回税込相殺請求額";
                dmdPrtPtnWork.DmdTtlFormTitle7 = "御請求額";
                dmdPrtPtnWork.DmdTtlFormTitle8 = string.Empty;
                dmdPrtPtnWork.DmdTtlSetItemDiv1 = 1;    // 前回請求額
                dmdPrtPtnWork.DmdTtlSetItemDiv2 = 2;    // 今回入金額
                dmdPrtPtnWork.DmdTtlSetItemDiv3 = 3;    // 繰越請求額
                dmdPrtPtnWork.DmdTtlSetItemDiv4 = 6;    // 今回税抜相殺請求額
                dmdPrtPtnWork.DmdTtlSetItemDiv5 = 9;    // 今回相殺消費税額
                dmdPrtPtnWork.DmdTtlSetItemDiv6 = 12;   // 今回税込相殺請求額
                dmdPrtPtnWork.DmdTtlSetItemDiv7 = 13;   // 御請求額
                dmdPrtPtnWork.DmdTtlSetItemDiv8 = 0;    // 未使用

                //---------------------------------
                // ※その他の項目は初期値を使用します。
                //---------------------------------

                dmdPrtPtnWorkList.Add( dmdPrtPtnWork );
                stream.Close();
            }

            return dmdPrtPtnWorkList;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
		#endregion

    }
}
