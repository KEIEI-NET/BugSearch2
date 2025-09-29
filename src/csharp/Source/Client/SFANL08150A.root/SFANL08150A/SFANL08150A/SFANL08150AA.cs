using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.Adapter; //DEL 2010/05/18
using Broadleaf.Library.Collections;
using Broadleaf.Application.LocalAccess; // ADD 2010/05/18

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票コンバートアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 既存のデータを自由帳票用にコンバートするためのデータ取得を行います。</br>
	/// <br>Programmer : 30015　橋本　裕毅</br>
	/// <br>Date       : 2007.04.27</br>
    public class FPprSchmGrAcs
    {
        /// <summary>リモートオブジェクト格納バッファ</summary>
        // -- UPD 2010/05/18 --------------------------------------->>>
        //private IFPprSchmGrDB _iFPprSchmGrDB = null;
        private FPprSchmGrLcDB _iFPprSchmGrDB = null;
        // -- UPD 2010/05/18 ---------------------------------------<<<

		private string _errorStr; 		// エラーメッセージ
		// 自由帳票スキーマコンバート
		private List<FPprSchmCvWork> _fPprSchmCvWorkList;
		// 自由帳票ソート順位初期値
		private List<FPSortInitWork> _fPSortInitWorkList;
		// 自由帳票抽出条件初期値
		private List<FPECndInitWork> _fPECndInitWorkList;

		/// <summary>
		/// 自由帳票コンバートアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票コンバートアクセスクラスの新しいインスタンスを初期化します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.04.27</br>
		/// </remarks>
		public FPprSchmGrAcs()
		{
			try
			{
                // -- UPD 2010/05/18 ----------------------------------->>>
                //// リモートオブジェクト取得
                //this._iFPprSchmGrDB = (IFPprSchmGrDB)MediationFPprSchmGrDB.GetFPprSchmGrDB();
                // ローカルＤＢアクセス取得
                this._iFPprSchmGrDB = new FPprSchmGrLcDB();
                // -- UPD 2010/05/18 -----------------------------------<<<

				_fPprSchmCvWorkList = new List<FPprSchmCvWork>();
				_fPSortInitWorkList = new List<FPSortInitWork>();
				_fPECndInitWorkList = new List<FPECndInitWork>();
			}
			catch (Exception)
			{				
                //オフライン時はnullをセット
                this._iFPprSchmGrDB = null;
			}

		}

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.04.27</br>
		/// </remarks>
        public int GetOnlineMode()
        {
            if (this._iFPprSchmGrDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
		}

		#region プロパティ
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>自由帳票スキーマコンバート</summary>
		/// <remarks>読み取り専用</remarks>
		public List<FPprSchmCvWork> FPprSchmCvWorkList
		{
			get {
				if (_fPprSchmCvWorkList == null)
					return new List<FPprSchmCvWork>();
				else
					return _fPprSchmCvWorkList;
			}
		}

		/// <summary>自由帳票ソート順位初期値</summary>
		/// <remarks>読み取り専用</remarks>
		public List<FPSortInitWork> FPSortInitWorkList
		{
			get {
				if (_fPSortInitWorkList == null)
					return new List<FPSortInitWork>();
				else
					return _fPSortInitWorkList;
			}
		}

		/// <summary>自由帳票抽出条件初期値</summary>
		/// <remarks>読み取り専用</remarks>
		public List<FPECndInitWork> FPECndInitWorkList
		{
			get {
				if (_fPECndInitWorkList == null)
					return new List<FPECndInitWork>();
				else
					return _fPECndInitWorkList;
			}
		}
		#endregion

		/// <summary>
		/// 自由帳票コンバートマスタ検索処理
		/// </summary>
		/// <param name="freePrtPprItemGrpCd">自由帳票印字項目グループコード</param>
		/// <<param name="freePrtPprSchmGrpCdArray">自由帳票スキーマコンバート配列</param>
		/// <param name="retList">読込結果コレクション</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票コンバートデータの検索処理を行います。</br>
	    /// <br>Programmer : 30015　橋本　裕毅</br>
	    /// <br>Date       : 2007.04.27</br>
		/// </remarks>
		public int SearchFPprSchmCv(int freePrtPprItemGrpCd ,int[] freePrtPprSchmGrpCdArray)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				object	retObj;
				bool msgDiv;
				string errMsg;
				_errorStr = string.Empty;
				_fPprSchmCvWorkList.Clear();
				_fPSortInitWorkList.Clear();
				_fPECndInitWorkList.Clear();

				// 自由帳票スキーマコンバートマスタ検索処理
				status = this._iFPprSchmGrDB.SearchFPprSchmCv(freePrtPprItemGrpCd, freePrtPprSchmGrpCdArray, out retObj, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						if (retObj != null && retObj is CustomSerializeArrayList)
						{
							CustomSerializeArrayList retList = (CustomSerializeArrayList)retObj;
							foreach (ArrayList wkList in retList)
							{
								if (wkList[0] is FPprSchmCvWork)
								{
									_fPprSchmCvWorkList.AddRange((FPprSchmCvWork[])wkList.ToArray(typeof(FPprSchmCvWork)));
								}
								else if (wkList[0] is FPSortInitWork)
								{
									_fPSortInitWorkList.AddRange((FPSortInitWork[])wkList.ToArray(typeof(FPSortInitWork)));
								}
								else if (wkList[0] is FPECndInitWork)
								{
									_fPECndInitWorkList.AddRange((FPECndInitWork[])wkList.ToArray(typeof(FPECndInitWork)));
								}

							}
						}
						else
						{
							status = (int)ConstantManagement.DB_Status.ctDB_EOF;
							_errorStr = "自由帳票コンバート情報の読込に失敗しました。" + Environment.NewLine;
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						_errorStr = "自由帳票コンバート情報の読込に失敗しました。" + Environment.NewLine + "指定されたデータは存在しません。";
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_errorStr = "「自由帳票コンバート情報」データの取得に失敗しました。\r\n\r\n*詳細=" + errMsg;
						else
							_errorStr = "自由帳票コンバート情報の読込に失敗しました。";
						break;
					}
					default:
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票コンバート情報検索処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;		
		}

		///// <summary>
		///// 自由帳票コンバートマスタ検索処理
		///// </summary>
		///// <param name="retList">読込結果コレクション</param>
		///// <param name="msgDiv">メッセージ区分</param>
		///// <param name="errMsg">エラーメッセージ</param>
		///// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		///// <returns>STATUS</returns>
		///// <remarks>
		///// <br>Note       : 自由帳票コンバートデータの検索処理を行います。</br>
		///// <br>Programmer : 30015　橋本　裕毅</br>
		///// <br>Date       : 2007.04.27</br>
		///// </remarks>
		//public int SearchFPprSchmCv(out ArrayList retList, out bool msgDiv, out string errMsg, int freePrtPprSchmGrpCd)
		//{
		//    int status = 0;

		//    retList = new ArrayList();
		//    retList.Clear();

		//    object retobj = null;

		//    // 自由帳票スキーマコンバートマスタ検索処理
		//    status = this._iFPprSchmGrDB.SearchFPprSchmCv(out retobj, out msgDiv, out errMsg, freePrtPprSchmGrpCd);
		//    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//    {
		//        FPprSchmCvWork[] fPprSchmCvWorkRet = retobj as FPprSchmCvWork[];
		//        if (fPprSchmCvWorkRet != null)
		//        {
		//            foreach (FPprSchmCvWork wkFPprSchmCvWork in fPprSchmCvWorkRet)
		//            {
		//                retList.Add(wkFPprSchmCvWork);
		//            }
		//        }

		//    }
		//    return status;

		//}

    }
}
