using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.LocalAccess; // ADD 2010/05/18

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 印字項目グループアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 印字項目グループ情報へのアクセス制御を行います。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.04</br>
	/// <br></br>
    /// <br>Update Note : 2010/05/18 22008 長内 数馬</br>
    /// <br>            : ローカルＤＢ対応</br>
    /// </remarks>
	public class PrtItemGrpAcs : IGeneralGuideData
	{
		#region Const
		// 汎用ガイド抽出条件項目
		private const string ctFreePrtPprItemGrpCd	= "FreePrtPprItemGrpCd";
		private const string ctTotalItemDivCd		= "TotalItemDivCd";
		private const string ctFormFeedItemDivCd	= "FormFeedItemDivCd";
		// 汎用ガイド親XMLファイル名
		private const string ctDifinitionFileName	= "PRTITEMSETGUIDEPARENT.XML";
		#endregion

		#region PrivateMember
        // -- UPD 2010/05/18 ------------------------------>>>
        //// 印字項目設定系リモートインターフェース
        //private IPrtItemSetDB			_iPrtItemSetDB;
        // 印字項目設定系ローカルアクセス
        private PrtItemSetLcDB			_iPrtItemSetDB;
        // -- UPD 2010/05/18 ------------------------------<<<
        // エラーメッセージ
		private string					_errorStr;
		//
		private List<PrtItemSetWork>	_prtItemSetList;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public PrtItemGrpAcs()
		{
            // -- UPD 2010/05/18 ------------------------------>>>
            //_iPrtItemSetDB	= MediationPrtItemSetDB.GetPrtItemSetDB();
            _iPrtItemSetDB	= new PrtItemSetLcDB();
            // -- UPD 2010/05/18 ------------------------------<<<
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
		/// 印字項目グループ取得処理
		/// </summary>
		/// <param name="prtItemGrpList">印字項目グループLIST</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字項目グループLISTを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemGrpWork(out List<PrtItemGrpWork> prtItemGrpList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			prtItemGrpList = null;

			try
			{
				// リモーティング
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemGrp(out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						PrtItemGrpWork[] prtItemGrpWorkArray = retObj as PrtItemGrpWork[];
						if (prtItemGrpWorkArray != null)
							prtItemGrpList = new List<PrtItemGrpWork>(prtItemGrpWorkArray);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "印字項目グループの検索に失敗しました。\r\n該当データがありません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「印字項目グループ」データの取得に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "印字項目グループの検索に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "印字項目グループの検索に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "印字項目グループ検索処理にて例外が発生しました。" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 印字項目設定取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字項目設定LISTを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemSetWork(int freePrtPprItemGrpCd, out List<PrtItemSetWork> prtItemSetList, out List<FPSortInitWork> fPSortInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			prtItemSetList = new List<PrtItemSetWork>();
			fPSortInitList = new List<FPSortInitWork>();

			try
			{
				// リモーティング
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemSet(freePrtPprItemGrpCd, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;
						if (retList != null)
						{
							for (int ix = 0 ; ix != retList.Count ; ix++)
							{
								ArrayList wkList = (ArrayList)retList[ix];
								if (wkList[0] is PrtItemSetWork)
									prtItemSetList = new List<PrtItemSetWork>((PrtItemSetWork[])wkList.ToArray(typeof(PrtItemSetWork)));
								else if (wkList[0] is FPSortInitWork)
									fPSortInitList = new List<FPSortInitWork>((FPSortInitWork[])wkList.ToArray(typeof(FPSortInitWork)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "印字項目設定の検索に失敗しました。\r\n該当データがありません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「印字項目設定」データの取得に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "印字項目設定の検索に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "印字項目設定の検索に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "印字項目設定検索処理にて例外が発生しました。" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}


		/// <summary>
		/// 印字項目設定取得処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <param name="fPprSchmCvList">自由帳票スキーマコンバートLIST</param>
		/// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
		/// <param name="fPECndInitList">自由帳票抽出条件初期値マスタリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字項目設定LIST及び自由帳票スキーマコンバートLISTを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int SearchPrtItemSetWithFPprSchmCv(int freePrtPprItemGrpCd, int freePrtPprSchmGrpCd, out List<PrtItemSetWork> prtItemSetList, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			prtItemSetList = new List<PrtItemSetWork>();
			fPprSchmCvList = new List<FPprSchmCvWork>();
			fPSortInitList = new List<FPSortInitWork>();
			fPECndInitList = new List<FPECndInitWork>();

			try
			{
				// リモーティング
				object retObj;
				bool msgDiv;
				string errMsg;
				status = _iPrtItemSetDB.SearchPrtItemSetWithFPprSchmCv(freePrtPprItemGrpCd, freePrtPprSchmGrpCd, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						CustomSerializeArrayList retList = retObj as CustomSerializeArrayList;
						if (retList != null)
						{
							for (int ix = 0 ; ix != retList.Count ; ix++)
							{
								ArrayList wkList = (ArrayList)retList[ix];
								if (wkList[0] is PrtItemSetWork)
									prtItemSetList = new List<PrtItemSetWork>((PrtItemSetWork[])wkList.ToArray(typeof(PrtItemSetWork)));
								else if (wkList[0] is FPprSchmCvWork)
									fPprSchmCvList = new List<FPprSchmCvWork>((FPprSchmCvWork[])wkList.ToArray(typeof(FPprSchmCvWork)));
								else if (wkList[0] is FPSortInitWork)
									fPSortInitList = new List<FPSortInitWork>((FPSortInitWork[])wkList.ToArray(typeof(FPSortInitWork)));
								else if (wkList[0] is FPECndInitWork)
									fPECndInitList = new List<FPECndInitWork>((FPECndInitWork[])wkList.ToArray(typeof(FPECndInitWork)));
							}
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "印字項目設定の検索に失敗しました。\r\n該当データがありません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「印字項目設定」データの取得に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "印字項目設定の検索に失敗しました。";
						break;
					}
					default:
					{
						_errorStr = "印字項目設定の検索に失敗しました。";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "印字項目設定検索処理にて例外が発生しました。" + "\r\n" + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 印字項目設定ガイド起動
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">印字項目グループコード</param>
		/// <param name="totalItemDivCd">集約項目区分</param>
		/// <param name="formFeedItemDivCd">改頁項目区分</param>
		/// <param name="prtItemSetList">印字項目設定リスト(nullの場合リモートを行います)</param>
		/// <param name="prtItemSetWork">結果印字項目設定マスタ</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定選択ガイドを起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public DialogResult ExecuteGuide(int freePrtPprItemGrpCd, int totalItemDivCd, int formFeedItemDivCd, List<PrtItemSetWork> prtItemSetList, out PrtItemSetWork prtItemSetWork)
		{
			DialogResult dlgRet = DialogResult.Abort;

			_prtItemSetList = prtItemSetList;

			prtItemSetWork = null;

			TableGuideParent tableGuideParent = new TableGuideParent(ctDifinitionFileName);

			Hashtable outObj	= new Hashtable();
			Hashtable inObj		= new Hashtable();
			inObj[ctFreePrtPprItemGrpCd]	= freePrtPprItemGrpCd;
			inObj[ctTotalItemDivCd]			= totalItemDivCd;
			inObj[ctFormFeedItemDivCd]		= formFeedItemDivCd;

			// 汎用ガイド起動処理
			if (tableGuideParent.Execute(0, inObj, ref outObj))
			{
				Object prtItemSetObj = new PrtItemSetWork();
				TableGuideParent.HashTableToClassProperty(outObj, ref prtItemSetObj);
				prtItemSetWork = (PrtItemSetWork)prtItemSetObj;

				dlgRet = DialogResult.OK;
			}
			else
			{
				dlgRet = DialogResult.Cancel;
			}

			return dlgRet;
		}
		#endregion

		#region IGeneralGuideData メンバ
		/// <summary>
		/// ガイドデータ取得処理
		/// </summary>
		/// <param name="mode">モード</param>
		/// <param name="inParm">検索条件</param>
		/// <param name="guideList">ガイド表示データ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: ガイドに表示するデータを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.06.04</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			int freePrtPprItemGrpCd	= (int)inParm[ctFreePrtPprItemGrpCd];
			int totalItemDivCd		= (int)inParm[ctTotalItemDivCd];
			int formFeedItemDivCd	= (int)inParm[ctFormFeedItemDivCd];

			if (_prtItemSetList == null)
			{
				List<FPSortInitWork> dummyFPSortInitList;
				status = SearchPrtItemSetWork(freePrtPprItemGrpCd, out _prtItemSetList, out dummyFPSortInitList);
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				List<PrtItemSetWork> prtItemSetList
					= _prtItemSetList.FindAll(
						delegate(PrtItemSetWork prtItemSetWork)
						{
							if (totalItemDivCd != 0)
							{
								if (prtItemSetWork.TotalItemDivCd == totalItemDivCd)
									return true;
								else
									return false;
							}
							else if (formFeedItemDivCd != 0)
							{
								if (prtItemSetWork.FormFeedItemDivCd == formFeedItemDivCd)
									return true;
								else
									return false;
							}
							else
							{
								if (prtItemSetWork.AddItemUseDivCd == 1)
									return true;
								else
									return true;
							}
						}
					);

				if (prtItemSetList != null && prtItemSetList.Count > 0)
				{
					byte[] wkByte = XmlByteSerializer.Serialize(prtItemSetList);
					XmlByteSerializer.ReadXml(ref guideList, wkByte);
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			return status;
		}
		#endregion
	}
}
