using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;				
using Broadleaf.Application.Remoting.ParamData;	
using Broadleaf.Application.Remoting.Adapter;		
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

using Broadleaf.Application.Common; 
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票グループテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票グループテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 22011 柏原 頼人</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: </br>
    /// <br>             </br>
    /// </remarks>
	public class FreePprGrpAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IFreePprGrpDB _iFreePprGrpDB = null;
		// 自由帳票グループ振替キャッシュ
		private Hashtable _frePprGrTrTable = null;
		// 自由帳票グループ情報キャッシュ用
		private static SortedList _guideBuf_FreePprGrp = null;

        #region const
        /// <summary>最大表示順位</summary>
        private const Int32 LAST_DISPORDER_KEYWORD = 9999;
        
        #endregion

        #region Constructor
        /// <summary>
		/// 自由帳票グループテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自由帳票グループテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public FreePprGrpAcs()
		{
			this._frePprGrTrTable = null;
			try
			{
				// リモートオブジェクト取得
				this._iFreePprGrpDB = (IFreePprGrpDB)MediationFreePprGrpDB.GetFreePprGrpDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iFreePprGrpDB = null;
			}
        }
        #endregion

        #region 自由帳票グループクラスデシリアライズ処理
        ///**********************************************************************
		/// <summary>
		/// 自由帳票グループクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自由帳票グループクラス</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループクラスをデシリアライズします。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// **********************************************************************
		public FreePprGrp FreePprGrpDeserialize(string fileName)
		{
			FreePprGrp freePprGrp = null;

            FreePprGrpWork freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(fileName, typeof(FreePprGrpWork));
			
			//デシリアライズ結果を自由帳票グループクラスへコピー
            if (freePprGrpWork != null) freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWork);
			return freePprGrp;
        }
        #endregion

        #region 自由帳票グループListクラスデシリアライズ処理
        /// ********************************************************************
		/// <summary>
		/// 自由帳票グループListクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自由帳票グループクラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループリストクラスをデシリアライズします。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ********************************************************************
		public ArrayList FreePprGrpListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// ファイル名を渡して自由帳票グループワーククラスをデシリアライズする
            FreePprGrpWork[] freePprGrpWorks;
            freePprGrpWorks = (FreePprGrpWork[])XmlByteSerializer.Deserialize(fileName, typeof(FreePprGrpWork[]));

			//デシリアライズ結果を自由帳票グループＵＩクラスへコピー
			if (freePprGrpWorks != null) 
			{
				al.Capacity = freePprGrpWorks.Length;
				for(int i=0; i < freePprGrpWorks.Length; i++)
				{
                    al.Add(CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWorks[i]));
				}
			}
			return al;
        }
        #endregion

        #region 自由帳票グループ登録・更新処理
        /// **********************************************************
		/// <summary>
		/// 自由帳票グループ登録・更新処理
		/// </summary>
		/// <param name="freePprGrp">自由帳票グループクラス</param>
        /// <param name="errmsg"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ情報の登録・更新を行います。
		///					 XML形式へ書込為、一旦全件読込後に登録する</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ************************************************************
		public int WriteFreePprGrp(ref FreePprGrp freePprGrp,out string errmsg)
		{
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列
            errmsg = "";

			//自由帳票グループクラスから自由帳票グループワーカークラスにメンバコピー
            FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
			
			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(freePprGrpWork);

			int status = 0;
			try
			{
				//自由帳票グループ書き込み
                status = this._iFreePprGrpDB.WriteFreePprGrp(ref parabyte, out msgDiv, out errMsg);
                if (status == (int)(ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    // ファイル名を渡して自由帳票グループワーククラスをデシリアライズする
                    freePprGrpWork = (FreePprGrpWork)XmlByteSerializer.Deserialize(parabyte, typeof(FreePprGrpWork));
                    // クラス内メンバコピー
                    freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(freePprGrpWork);

                    // キャッシュ更新
                    if (_guideBuf_FreePprGrp != null)
                    {
                        _guideBuf_FreePprGrp[freePprGrp.FreePrtPprGroupCd] = freePprGrp;
                    }
                }
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iFreePprGrpDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*詳細 = " + errMsg;
            }

			return status;
        }
        #endregion

        #region 自由帳票グループキャッシュ内データ検索処理
        /// <summary>
		/// 自由帳票グループキャッシュ内データ検索処理
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャッシュ用スタティック領域から自由帳票グループの検索を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SearchStaticMemoryProc( out ArrayList retList, string enterpriseCode )
		{
			int status = 0;
			retList = new ArrayList();
			retList.Clear();

            //キャッシュがなければ取得する
			if( ( _guideBuf_FreePprGrp == null ) || ( _guideBuf_FreePprGrp.Count == 0 ) ) 
			{
				status = GetFreePprGrpDataBuffer( enterpriseCode );
				switch( status ) 
				{
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					{
						break;
					}
					default:
					{
						return status;
					}
				}
			}

			//キャッシュから展開
            foreach( FreePprGrp freePprGrp in _guideBuf_FreePprGrp.Values ) 
			{
				if( freePprGrp.LogicalDeleteCode == 0 ) 
				{
					retList.Add( freePprGrp.Clone() );
				}
			}

			if( retList.Count == 0 ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}
			return status;
        }
        #endregion

        #region 自由帳票グループキャッシュ取得処理
        /// <summary>
		/// 自由帳票グループキャッシュ取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループのキャッシュを取得します</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 22007.04.03</br>
		/// </remarks>
		private int GetFreePprGrpDataBuffer( string enterpriseCode )
		{
			int status = 0;

			if( _guideBuf_FreePprGrp == null ) 
			{
				_guideBuf_FreePprGrp = new SortedList();
			}

			ArrayList freePprGrps = null;
			bool nextData;
			int	 retTotalCnt;
            //リモートで情報を取得
			status = SearchFreePprGrpProc(out freePprGrps,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
			{   
                //振替情報を展開
				foreach( FreePprGrp freePprGrp in freePprGrps ) 
				{
					if( _guideBuf_FreePprGrp.ContainsKey( freePprGrp.FreePrtPprGroupCd) == false ) 
					{
						_guideBuf_FreePprGrp.Add( freePprGrp.FreePrtPprGroupCd, freePprGrp.Clone() );
					}
				}
			}
			return status;
        }
        #endregion

        #region 自由帳票グループキャッシュ内データ検索処理
        /// <summary>
		/// 自由帳票グループキャッシュ内データ検索処理
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャッシュ用スタティック領域から自由帳票グループの検索を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchStaticMemoryFreePprGrp( out ArrayList retList, string enterpriseCode )
		{
			return SearchStaticMemoryProc( out retList, enterpriseCode );
        }
        #endregion

        #region 自由帳票グループシリアライズ処理
        /// ************************************************************
		/// <summary>
		/// 自由帳票グループシリアライズ処理
		/// </summary>
		/// <param name="freePprGrp">シリアライズ対象従自由帳票グループクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ情報のシリアライズを行います。
		///                  この関数は使用ていないので明細データ分割は未組み込み</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ************************************************************
		public void FreePprGrpSerialize(FreePprGrp freePprGrp,string fileName)
		{
			//自由帳票グループクラスから自由帳票グループワーカークラスにメンバコピー
            FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
			//自由帳票グループワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(freePprGrpWork,fileName);
        }
        #endregion

        #region 自由帳票グループ物理削除処理
        /// <summary>
		///	自由帳票グループ物理削除処理
		/// </summary>
		/// <param name="freePprGrp">自由帳票グループオブジェクト</param>
		/// <param name="frePprGrTrList">自由帳票グループ振替リスト</param>
        /// <param name="errmsg"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ情報の物理削除を行います。
		///					 自由帳票グループ振替も一緒に削除します</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int DeleteFreePprGrpAndGrTr(FreePprGrp freePprGrp, ArrayList frePprGrTrList,out string errmsg)
		{
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列
            int status = 0;
            errmsg = "";

			try
			{
                FreePprGrpWork freePprGrpWork = CopyToFreePprGrpWorkFromFreePprGrp(freePprGrp);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte1 = XmlByteSerializer.Serialize(freePprGrpWork);
				byte[] parabyte2 = null;

				if (frePprGrTrList.Count != 0)
				{
					FrePprGrTrWork[] frePprGrTrWork = new FrePprGrTrWork[frePprGrTrList.Count];
					int ix=0;
					foreach(FrePprGrTr detail in frePprGrTrList)
					{
						frePprGrTrWork[ix] = CopyToFrePprGrTrWorkFromFrePprGrTr(detail);
						ix++;
					}
					//↑配列の場合のロジック
					parabyte2 = XmlByteSerializer.Serialize(frePprGrTrWork);
				}
				// 物理削除
                status = this._iFreePprGrpDB.DeleteFreePprGrpAll(ref parabyte1, ref parabyte2, out msgDiv, out errMsg);
								
				// 明細側キャッシュ削除
				if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					foreach (FrePprGrTr frePprGrTr in frePprGrTrList)
					{
						RemoveCache( frePprGrTr );
					}
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iFreePprGrpDB = null;
				//通信エラーは-1を戻す
				status =  -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*詳細 = " + errMsg;
            }
            return status;
        }
        #endregion

        #region 自由帳票グループ検索処理（論理削除区分は無視）
        /// <summary>
		/// 自由帳票グループ検索処理（論理削除区分は無視）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchAllFreePprGrp(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchFreePprGrpProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
        }
        #endregion

        #region 自由帳票グループ検索処理
        /// <summary>
		/// 自由帳票グループ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevFreePprGrpがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループの検索処理を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SearchFreePprGrpProc(out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode)
		{
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
            freePprGrpWork.EnterpriseCode = enterpriseCode;
			
			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;
            retList = new ArrayList();
            Object retObj;
            Object paraObj = freePprGrpWork as Object;

            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列


            // 自由帳票グループ検索
            int status = 0;
            status = this._iFreePprGrpDB.SearchFreePprGrp(out retObj, paraObj, 0, logicalMode, out msgDiv, out errMsg);

            if (status == 0)
            {
                // パラメータが渡って来ているか確認
                ArrayList paraList;
                paraList = retObj as ArrayList;

                FreePprGrpWork[] al = new FreePprGrpWork[paraList.Count];

                // データを元に戻す
                for (int i = 0; i < paraList.Count; i++)
                {
                    al[i] = (FreePprGrpWork)paraList[i];
                }
                for (int i = 0; i < al.Length; i++)
                {
                    // サーチ結果取得
                    FreePprGrpWork wkFreePprGrpWork = (FreePprGrpWork)al[i];
                    //自由帳票グループクラスへメンバコピー
                    FreePprGrp freePprGrp = CopyToFreePprGrpFromFreePprGrpWork(wkFreePprGrpWork);
                   
                    retList.Add(freePprGrp);

                }
            }
            retTotalCnt = retList.Count;
            if (msgDiv == true)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    "FreePprGrpAcs", 				    // アセンブリＩＤまたはクラスＩＤ
                    "自由帳票グループアクセスクラス", 	// プログラム名称
                    "SearchFreePprGrpProc", 			// 処理名称
                    TMsgDisp.OPE_READ, 		    		// オペレーション
                    "検索に失敗しました。\r\n\r\n*詳細 = " + errMsg, 	// 表示するメッセージ
                    status, 							// ステータス値
                    this._iFreePprGrpDB, 				// エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }
			return status;
        }
        #endregion

        #region workclass ⇔ dataclass　コンバート関係

        #region 自由帳票グループワーククラス⇒自由帳票グループクラス
        /// ***************************************************************************************
		/// <summary>
		/// クラスメンバーコピー処理（自由帳票グループワーククラス⇒自由帳票グループクラス）
		/// </summary>
		/// <param name="freePprGrpWork">自由帳票グループワーククラス</param>
		/// <returns>自由帳票グループクラス</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループワーククラスから自由帳票グループクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		/// ****************************************************************************************
        private FreePprGrp CopyToFreePprGrpFromFreePprGrpWork(FreePprGrpWork freePprGrpWork)
		{
			FreePprGrp freePprGrp = new FreePprGrp();
			freePprGrp.CreateDateTime			= freePprGrpWork.CreateDateTime;
			freePprGrp.UpdateDateTime			= freePprGrpWork.UpdateDateTime;
			freePprGrp.EnterpriseCode			= freePprGrpWork.EnterpriseCode;
			freePprGrp.FileHeaderGuid			= freePprGrpWork.FileHeaderGuid;
			freePprGrp.UpdEmployeeCode		    = freePprGrpWork.UpdEmployeeCode;
			freePprGrp.UpdAssemblyId1			= freePprGrpWork.UpdAssemblyId1;
			freePprGrp.UpdAssemblyId2			= freePprGrpWork.UpdAssemblyId2;
			freePprGrp.LogicalDeleteCode		= freePprGrpWork.LogicalDeleteCode;

			freePprGrp.FreePrtPprGroupCd		= freePprGrpWork.FreePrtPprGroupCd;
            freePprGrp.FreePrtPprGroupNm        = freePprGrpWork.FreePrtPprGroupNm;
			
			return freePprGrp;
        }
        #endregion

        #region 自由帳票グループクラス⇒自由帳票グループワーククラス
        /// <summary>
		/// クラスメンバーコピー処理（自由帳票グループクラス⇒自由帳票グループワーククラス）
		/// </summary>
		/// <param name="freePprGrp">自由帳票グループワーククラス</param>
		/// <returns>自由帳票グループクラス</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループクラスから自由帳票グループワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private FreePprGrpWork CopyToFreePprGrpWorkFromFreePprGrp(FreePprGrp freePprGrp)
		{
            FreePprGrpWork freePprGrpWork = new FreePprGrpWork();
			freePprGrpWork.CreateDateTime			= freePprGrp.CreateDateTime;
			freePprGrpWork.UpdateDateTime			= freePprGrp.UpdateDateTime;
			freePprGrpWork.EnterpriseCode			= freePprGrp.EnterpriseCode;
			freePprGrpWork.FileHeaderGuid			= freePprGrp.FileHeaderGuid;
			freePprGrpWork.UpdEmployeeCode		    = freePprGrp.UpdEmployeeCode;
			freePprGrpWork.UpdAssemblyId1			= freePprGrp.UpdAssemblyId1;
			freePprGrpWork.UpdAssemblyId2			= freePprGrp.UpdAssemblyId2;
			freePprGrpWork.LogicalDeleteCode		= freePprGrp.LogicalDeleteCode;

            freePprGrpWork.FreePrtPprGroupCd        = freePprGrp.FreePrtPprGroupCd;
            freePprGrpWork.FreePrtPprGroupNm        = freePprGrp.FreePrtPprGroupNm;
			return freePprGrpWork;
        }
        #endregion

        #region 自由帳票グループ振替クラス⇒自由帳票グループ振替ワーククラス
        /// <summary>
        ///	クラスメンバーコピー処理（自由帳票グループ振替ワーククラス⇒自由帳票グループ振替クラス）
		/// </summary>
		/// <param name="frePprGrTrWork"></param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note		: 自由帳票グループ振替ワーククラスから自由帳票グループ振替クラスへのメンバコピーを行います。</br>
		///	<br>Programer	: 22011 柏原 頼人</br>
		///	<br>Date		: 2007.04.03</br>
		/// </remarks>						
		private FrePprGrTr CopyToFrePprGrTrFromFrePprGrTrWork(FrePprGrTrWork frePprGrTrWork)
		{
			FrePprGrTr frePprGrTr = new FrePprGrTr();

			frePprGrTr.CreateDateTime			= frePprGrTrWork.CreateDateTime;
			frePprGrTr.UpdateDateTime			= frePprGrTrWork.UpdateDateTime;
			frePprGrTr.EnterpriseCode			= frePprGrTrWork.EnterpriseCode;
			frePprGrTr.FileHeaderGuid			= frePprGrTrWork.FileHeaderGuid;
			frePprGrTr.UpdEmployeeCode			= frePprGrTrWork.UpdEmployeeCode;
			frePprGrTr.UpdAssemblyId1			= frePprGrTrWork.UpdAssemblyId1;
			frePprGrTr.UpdAssemblyId2			= frePprGrTrWork.UpdAssemblyId2;
			frePprGrTr.LogicalDeleteCode		= frePprGrTrWork.LogicalDeleteCode;

            frePprGrTr.FreePrtPprGroupCd        = frePprGrTrWork.FreePrtPprGroupCd;
            frePprGrTr.TransferCode             = frePprGrTrWork.TransferCode;
            frePprGrTr.DisplayOrder             = frePprGrTrWork.DisplayOrder;
            frePprGrTr.DisplayName              = frePprGrTrWork.DisplayName;
            frePprGrTr.OutputFormFileName       = frePprGrTrWork.OutputFormFileName;
            frePprGrTr.UserPrtPprIdDerivNo      = frePprGrTrWork.UserPrtPprIdDerivNo;
			return frePprGrTr;
        }
        #endregion

        #region 自由帳票グループ振替クラス⇒自由帳票グループ振替ワーククラス
        /// <summary>　
        ///	クラスメンバーコピー処理（自由帳票グループ振替クラス⇒自由帳票グループ振替ワーククラス）
		/// </summary>
		/// <param name="frePprGrTr"></param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note		: 自由帳票グループ振替クラスから自由帳票グループ振替ワーククラスへのメンバコピーを行います。</br>
		///	<br>Programer	: 22011 柏原 頼人</br>
		///	<br>Date		: 2007.04.03</br>
		/// </remarks>						
		private FrePprGrTrWork CopyToFrePprGrTrWorkFromFrePprGrTr(FrePprGrTr frePprGrTr)
		{
			FrePprGrTrWork frePprGrTrWork = new FrePprGrTrWork();
			frePprGrTrWork.CreateDateTime			= frePprGrTr.CreateDateTime;
			frePprGrTrWork.UpdateDateTime			= frePprGrTr.UpdateDateTime;
			frePprGrTrWork.EnterpriseCode			= frePprGrTr.EnterpriseCode;
			frePprGrTrWork.FileHeaderGuid			= frePprGrTr.FileHeaderGuid;
			frePprGrTrWork.UpdEmployeeCode			= frePprGrTr.UpdEmployeeCode;
			frePprGrTrWork.UpdAssemblyId1			= frePprGrTr.UpdAssemblyId1;
			frePprGrTrWork.UpdAssemblyId2			= frePprGrTr.UpdAssemblyId2;
			frePprGrTrWork.LogicalDeleteCode		= frePprGrTr.LogicalDeleteCode;

            frePprGrTrWork.FreePrtPprGroupCd        = frePprGrTr.FreePrtPprGroupCd;
            frePprGrTrWork.TransferCode             = frePprGrTr.TransferCode;
            frePprGrTrWork.DisplayOrder             = frePprGrTr.DisplayOrder;
            frePprGrTrWork.DisplayName              = frePprGrTr.DisplayName;
            frePprGrTrWork.OutputFormFileName       = frePprGrTr.OutputFormFileName;
            frePprGrTrWork.UserPrtPprIdDerivNo      = frePprGrTr.UserPrtPprIdDerivNo;

			return frePprGrTrWork;
        }
        #endregion

        #endregion


        #region freePprGrpdtlのI/O関連

        #region 自由帳票グループ振替明細Listクラスデシリアライズ処理
        /// <summary>
		/// 自由帳票グループ振替明細Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>自由帳票グループ振替クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ振替リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public ArrayList FrePprGrTrListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// ファイル名を渡して自由帳票グループワーククラスをデシリアライズする
			FrePprGrTrWork[] frePprGrTrWorks;
			frePprGrTrWorks = (FrePprGrTrWork[])XmlByteSerializer.Deserialize(fileName,typeof(FrePprGrTrWork[]));
			//デシリアライズ結果を自由帳票グループＵＩクラスへコピー
			if (frePprGrTrWorks != null) 
			{
				al.Capacity = frePprGrTrWorks.Length;
				for(int i=0; i < frePprGrTrWorks.Length; i++)
				{
					al.Add(CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrWorks[i]));
				}
			}
			return al;
        }
        #endregion

        #region 自由帳票グループ振替Listシリアライズ処理
        /// <summary>
		/// 自由帳票グループ振替Listシリアライズ処理
		/// </summary>
		/// <param name="freePprGrpdtls">シリアライズ対象自由帳票グループ振替Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ振替List情報のシリアライズを行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public void FrePprGrTrListSerialize(ArrayList freePprGrpdtls, string fileName)
		{
			FrePprGrTrWork[] frePprGrTrWorks = new FrePprGrTrWork[freePprGrpdtls.Count];
			for(int i= 0; i < freePprGrpdtls.Count; i++)
			{
				frePprGrTrWorks[i] = CopyToFrePprGrTrWorkFromFrePprGrTr((FrePprGrTr)freePprGrpdtls[i]);
			}
			XmlByteSerializer.Serialize(frePprGrTrWorks,fileName);
        }
        #endregion

        #region 自由帳票グループ振替全検索処理（論理削除区分を無視）
        /// <summary>
		/// 自由帳票グループ振替全検索処理（論理削除区分を無視）グループコード毎
		/// </summary>
		/// <param name="frePprGrTrList">自由帳票グループ振替クラス</param>
		/// <param name="enterpriseCode">企業コード</param>	
		/// <param name="freePrtPprGroupCd">自由帳票グループコード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ振替の全検索処理を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public int SearchAllFreePprGrTr(out ArrayList frePprGrTrList,string enterpriseCode,Int32 freePrtPprGroupCd)
		{			
			int status =0;

			status = SearchFrePprGrTrProc(out frePprGrTrList,freePrtPprGroupCd,enterpriseCode,ConstantManagement.LogicalMode.GetData01);			
			return status;
        }

        /// <summary>
        /// 自由帳票グループ振替全検索処理（論理削除区分を無視）
        /// </summary>
        /// <param name="frePprGrTrList">自由帳票グループ振替クラス</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自由帳票グループ振替の全検索処理を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks>
        public int SearchAllFreePprGrTr(out ArrayList frePprGrTrList, string enterpriseCode)
        {
            int status = 0;

            status = SearchFrePprGrTrProc(out frePprGrTrList, enterpriseCode);
            return status;
        }
        #endregion

        #region 自由帳票グループ振替情報検索読込
        /// <summary>
		///	自由帳票グループ振替情報検索読込
		/// </summary>
		/// <param name="freePprGrp"></param>
		/// <param name="retTotalCnt"></param>
		/// <param name="nextData"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="logicalMode"></param>
		/// <param name="readCnt"></param>
		/// <param name="prevFreePprGrp"></param>
		/// <returns>
		/// <br>Note		:	指定の自由帳票グループに付随する明細のみを展開する</br>
		/// <br>Programer	:	22011 柏原 頼人</br>
		/// <br>Date		:	2007.04.03</br>
		/// </returns>
		private int SearchFrePprGrTrProc( ref FreePprGrp freePprGrp,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			FreePprGrp prevFreePprGrp)
		{
			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

			ArrayList retList = null;
			int status = SearchCache(out retList, enterpriseCode, freePprGrp.FreePrtPprGroupCd, logicalMode);

			freePprGrp.FrePprGrTrs.AddRange(retList);
			retTotalCnt = freePprGrp.FrePprGrTrs.Count;
			return status;
        }
        #endregion

        #region 自由帳票グループ振替情報検索読込
        /// <summary>
		///	自由帳票グループ振替情報検索読込
		/// </summary>
		/// <param name="retList"></param>
		/// <param name="freePrtPprGroupCd"></param>
		/// <param name="enterpriseCode"></param>
		/// <param name="logicalMode"></param>
		/// <returns>
		/// <br>Note		:	指定の自由帳票グループに付随する明細のみを展開する</br>
		/// <br>Programer	:	22011 柏原 頼人</br>
		/// <br>Date		:	2007.04.03</br>
		/// </returns>
		private int SearchFrePprGrTrProc(out ArrayList retList,Int32 freePrtPprGroupCd,
			string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			return SearchCache(out retList, enterpriseCode, freePrtPprGroupCd, logicalMode);
        }

        /// <summary>
        ///	自由帳票グループ振替情報検索読込
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns>
        /// <br>Note		:	指定の自由帳票グループに付随する明細のみを展開する</br>
        /// <br>Programer	:	22011 柏原 頼人</br>
        /// <br>Date		:	2007.04.03</br>
        /// </returns>
        private int SearchFrePprGrTrProc(out ArrayList retList, string enterpriseCode)
        {
            return SearchCache(out retList, enterpriseCode);
        }
        #endregion

        #region 自由帳票グループ振替物理削除処理
        /// <summary>
		///	自由帳票グループ振替物理削除処理
		/// </summary>
		/// <param name="frePprGrTr">自由帳票グループ振替オブジェクト</param>
		/// <param name="errmsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自由帳票グループ振替情報の物理削除を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
        public int DeleteFrePprGrTr(ref FrePprGrTr frePprGrTr, out string errmsg)
		{
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列
            int status = 0;
            errmsg = "";

			try
			{
				FrePprGrTrWork frePprGrTrWork = CopyToFrePprGrTrWorkFromFrePprGrTr(frePprGrTr);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(frePprGrTrWork);
				//自由帳票グループ振替物理削除
                status = this._iFreePprGrpDB.DtlDelete(parabyte, out msgDiv, out errMsg);

				if (status == 0)
				{
					frePprGrTrWork = (FrePprGrTrWork)XmlByteSerializer.Deserialize(parabyte,typeof(FrePprGrTrWork));
					// クラス内メンバコピー
					frePprGrTr = CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrWork);
					RemoveCache( frePprGrTr );
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iFreePprGrpDB = null;
				//通信エラーは-1を戻す
				status =  -1;
			}
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*詳細 = " + errMsg;
            }
            return status;
        }
        #endregion

        #region 自由帳票グループ振替マスタ書込み
        /// ModuleName WriteFrePprGrTr
		/// <summary>
		///	自由帳票グループ振替マスタ書込み
		/// </summary>
		/// <param name="frePprGrTr">自由帳票グループ振替オブジェクト</param>
		/// <param name="errmsg">エラーメッセージ</param>
        /// <returns>status</returns>
		/// ---------------------------------------------
		/// <remarks>
		/// <br>Note		:	自由帳票グループ振替マスタの書込みを行います</br>
		/// <br>Programer	:	22011 柏原 頼人</br>
		/// <br>Date		:	2007.04.03</br>
		/// </remarks>
        public int WriteFrePprGrTr(ref FrePprGrTr frePprGrTr, out string errmsg)
        {
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列
            int status = 0;
            errmsg = "";
            List<FrePprGrTrWork> wkList = new List<FrePprGrTrWork>();
            FrePprGrTr frepprgrtr;
            object paraObj;

            try
            {
                FrePprGrTrWork frePprGrTrWork;
                frePprGrTrWork = CopyToFrePprGrTrWorkFromFrePprGrTr(frePprGrTr);
                
                //表示順位変更リスト取得処理
                wkList = ChangeFrePprGrTrDispOrder(frePprGrTrWork);
                if (wkList.Count == 0) return -1;

                //DB更新処理
                paraObj = wkList;
                status = this._iFreePprGrpDB.WriteFrePprGrTr(ref paraObj, out msgDiv, out errMsg);

                if (status == 0)
                {
                    wkList = (List<FrePprGrTrWork>)paraObj;
                    frePprGrTr = CopyToFrePprGrTrFromFrePprGrTrWork(wkList[0]);
                    foreach (FrePprGrTrWork frePprGrTrwk in wkList)
                    {
                        //自由帳票グループクラスへメンバコピー
                        frepprgrtr = CopyToFrePprGrTrFromFrePprGrTrWork(frePprGrTrwk);
                        // キャッシュ更新
                        UpdateCache(frepprgrtr.Clone());
                    }
                }
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iFreePprGrpDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            if (msgDiv == true)
            {
                errmsg = "\r\n\r\n*詳細 = " + errMsg;
            }
            return status;
        }

        /// <summary>
        /// 表示順位変更リスト取得処理
        /// </summary>
        /// <param name="frePprGrTrWk">オブジェクト</param>
        /// <returns>表示順位の変更を行う作業部品オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 表示順位の変更を行うオブジェクトのリストを取得します。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private List<FrePprGrTrWork> ChangeFrePprGrTrDispOrder(FrePprGrTrWork frePprGrTrWk)
        {
            List<FrePprGrTrWork> resultList = new List<FrePprGrTrWork>();
            List<FrePprGrTrWork> changeList = null;

            // 更新しようとするデータ
            resultList.Add(frePprGrTrWk);
            // 表示順位繰り下げ対象リスト取得
            GetFrePprGrTrSequenceNumberData(out changeList, frePprGrTrWk);
            // 表示順位繰り下げ対象リストから追加
            foreach (FrePprGrTrWork wkFrePprGrTrWk in changeList)
            {
                // 表示順位を+1
                wkFrePprGrTrWk.DisplayOrder++;
                // 最大表示順位を超えたとき
                if (wkFrePprGrTrWk.DisplayOrder > LAST_DISPORDER_KEYWORD)
                {
                    wkFrePprGrTrWk.DisplayOrder = LAST_DISPORDER_KEYWORD;
                }
                resultList.Add(wkFrePprGrTrWk);
            }
            return resultList;
        }

        /// <summary>
        /// 連番レコード取得処理
        /// </summary>
        /// <param name="retList">結果格納リスト</param>
        /// <param name="frePprGrTrWk">変更予定オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 既存のレコードで表示順位がパッディングした場合の表示順位繰り下げ対象レコードを取得します。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void GetFrePprGrTrSequenceNumberData(out List<FrePprGrTrWork> retList, FrePprGrTrWork frePprGrTrWk)
        {
            retList = new List<FrePprGrTrWork>();
            ArrayList retwkList = new ArrayList();
            List<FrePprGrTrWork> workList = new List<FrePprGrTrWork>();
            
            //キャッシュを確保
            SearchCache(out retwkList, frePprGrTrWk.EnterpriseCode);

            //変更が必要なレコードを抽出
            foreach (FrePprGrTr wk in retwkList)
            {
                // 表示順位 >= 指定表示順位
                // コード != 変更予定レコードのコード（変更対象と同一レコードを除外）
                if(wk.FreePrtPprGroupCd == frePprGrTrWk.FreePrtPprGroupCd)
                    if (wk.DisplayOrder >= frePprGrTrWk.DisplayOrder)
                        if (wk.TransferCode != frePprGrTrWk.TransferCode)
                            workList.Add(CopyToFrePprGrTrWorkFromFrePprGrTr(wk));
            }
            //表示順位を昇順でソート
            workList.Sort(new FrePprGrTrWkDispOrderComparer());

            // レコードが存在したとき
            int order = frePprGrTrWk.DisplayOrder;
            if (workList.Count > 0)
            {
                foreach (FrePprGrTrWork wkFrePprGrTrWk in workList)
                {
                    if (wkFrePprGrTrWk.DisplayOrder == order)
                    {
                        retList.Add(wkFrePprGrTrWk);
                        order++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        #endregion

        
        #endregion

        #region キャッシュ関係

        #region キャッシュデータ取得設定処理
        /// <summary>
		/// キャッシュデータ取得設定処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全件取得したセット作業明細データをキャッシュに格納します。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private int SetFrePprGrTrCache( string enterpriseCode)
		{
			int status = 0;
            bool msgDiv = false;       //メッセージ有無区分
            string errMsg = "";     //エラーメッセージ文字列

			try 
			{
				// キャッシュ用ハッシュテーブルのインスタンスを生成
				this._frePprGrTrTable = new Hashtable();

			
                Object retObj;

                status = this._iFreePprGrpDB.SearchFrePprGrTrAll(out retObj, enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01, out msgDiv, out errMsg);
                
                if (status == 0)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList paraList = new ArrayList();
                    paraList = retObj as ArrayList;

                    FrePprGrTrWork[] al = new FrePprGrTrWork[paraList.Count];

                    // データを元に戻す
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        al[i] = (FrePprGrTrWork)paraList[i];
                    }
                    for (int i = 0; i < al.Length; i++)
                    {
                        //サーチ結果取得
                        FrePprGrTrWork wkFrePprGrTrWork = (FrePprGrTrWork)al[i];
                        UpdateCache((CopyToFrePprGrTrFromFrePprGrTrWork(wkFrePprGrTrWork)));
                    }
                }
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iFreePprGrpDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}
            if (msgDiv)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                    "FreePprGrpAcs", 				    // アセンブリＩＤまたはクラスＩＤ
                    "自由帳票グループアクセスクラス", 	// プログラム名称
                    "SetFrePprGrTrCache", 			    // 処理名称
                    TMsgDisp.OPE_READ, 				// オペレーション
                    "検索に失敗しました。\r\n\r\n*詳細 = " + errMsg, 	// 表示するメッセージ
                    status, 							// ステータス値
                    this._iFreePprGrpDB, 				// エラーが発生したオブジェクト
                    MessageBoxButtons.OK, 				// 表示するボタン
                    MessageBoxDefaultButton.Button1);	// 初期表示ボタン
            }



            return status;
        }
        #endregion

        #region キャッシュ内データ更新処理
        /// <summary>
		/// キャッシュ内データ更新処理
		/// </summary>
		/// <param name="frePprGrTr">自由帳票グループ振替オブジェクト</param>
		/// <remarks>
		/// <br>Note       : キャッシュを更新します</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void UpdateCache( FrePprGrTr frePprGrTr )
		{
			if( this._frePprGrTrTable == null )
			{
				this._frePprGrTrTable = new Hashtable();
			}
			Hashtable workCodeTable  = null;

            //グループのテーブルが存在するか
			if( this._frePprGrTrTable.ContainsKey( frePprGrTr.FreePrtPprGroupCd) == true)
			{
				workCodeTable = ( Hashtable )this._frePprGrTrTable[ frePprGrTr.FreePrtPprGroupCd ];
			}
			else
			{
				workCodeTable = new Hashtable();
				this._frePprGrTrTable.Add( frePprGrTr.FreePrtPprGroupCd, workCodeTable );
			}
           
            workCodeTable[frePprGrTr.TransferCode] = frePprGrTr.Clone();

            //if( workCodeTable.ContainsKey( frePprGrTr.TransferCode ) )
            //{
            //    workCodeTable.Remove( frePprGrTr.TransferCode );
            //}
            //workCodeTable.Add( frePprGrTr.TransferCode, frePprGrTr.Clone() );
        }
        #endregion

        #region キャッシュ内データ削除処理
        /// <summary>
		/// キャッシュ内データ削除処理
		/// </summary>
		/// <param name="frePprGrTr">自由帳票グループ振替オブジェクト</param>
		/// <remarks>
		/// <br>Note       : キャッシュ内データから指定された自由帳票グループ振替オブジェクトを削除します。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void RemoveCache( FrePprGrTr frePprGrTr )
		{
			if( this._frePprGrTrTable == null ) 
			{
				// データが存在していない
				return;
			}

			Hashtable workCodeTable  = null;

			// ハッシュテーブルに自由帳票グループ振替が登録されているか？
			if( this._frePprGrTrTable.ContainsKey( frePprGrTr.FreePrtPprGroupCd ) == false ) 
			{
				// データが存在していない
				return;
			}

			workCodeTable = ( Hashtable )this._frePprGrTrTable[ frePprGrTr.FreePrtPprGroupCd ];

			if( workCodeTable.ContainsKey( frePprGrTr.TransferCode ) == false ) 
			{
				// データが存在していない
				return;
			}

			// データを削除
			workCodeTable.Remove( frePprGrTr.TransferCode );
        }
        #endregion

        #region キャッシュ内データ検索処理
        /// <summary>
		/// キャッシュ内データ検索処理(グループコード毎)
		/// </summary>
		/// <param name="retList">検索結果リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="freePrtPprGroupCd">自由帳票グループコード</param>
		/// <param name="logicalMode">削除区分</param>
		/// <br>Note       : キャッシュ内データからデータの検索を行います。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// <returns></returns>
		private int SearchCache( out ArrayList retList, string enterpriseCode, Int32 freePrtPprGroupCd, ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;

			retList = new ArrayList();
			retList.Clear();

			// キャッシュが存在していないとき
			if( this._frePprGrTrTable == null ) 
			{
				// キャッシュデータを取得
				status = SetFrePprGrTrCache( enterpriseCode );
				switch( status ) 
				{
					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
					{
						return status;
					}
					default:
					{
						return status;
					}
				}
			}

			if( this._frePprGrTrTable.ContainsKey( freePrtPprGroupCd ) == true ) 
			{
				Hashtable retHashTable = ( Hashtable )this._frePprGrTrTable[ freePrtPprGroupCd ];
				// 論理削除されていないレコードのみ
				if( logicalMode == 0)
				{
					foreach( FrePprGrTr frePprGrTr in retHashTable.Values ) 
					{
						if( frePprGrTr.LogicalDeleteCode == 0 )
						{
							retList.Add( frePprGrTr.Clone() );
						}
					}
				}	
				else
				{
					foreach( FrePprGrTr frePprGrTr in retHashTable.Values ) 
					{
						retList.Add( frePprGrTr.Clone() );
					}
				}
			}
			
			if( retList.Count > 0 ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}

			// 表示順位順位並び替え
			retList.Sort(new FrePprGrTrDispOrderComparer() );
			return status;
        }

        /// <summary>
        /// キャッシュ内データ検索処理(全件取得)
        /// </summary>
        /// <param name="retList">検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <br>Note       : キャッシュ内データからデータの検索を行います。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.03</br>
        /// <returns></returns>
        private int SearchCache(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            // キャッシュが存在していないとき
            if (this._frePprGrTrTable == null)
            {
                // キャッシュデータを取得
                status = SetFrePprGrTrCache(enterpriseCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            return status;
                        }
                    default:
                        {
                            return status;
                        }
                }
            }

            // グループコードごとのハッシュ
            foreach (Hashtable retHashTable in _frePprGrTrTable.Values)
            {
                foreach (FrePprGrTr frePprGrTr in retHashTable.Values)
                {
                    retList.Add(frePprGrTr.Clone());
                }
            }
        
            if (retList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            // 表示順位順位並び替え
            retList.Sort(new FrePprGrTrDispOrderComparer());
            return status;
        }
        #endregion

        #endregion

        #region ソートクラス
        /// <summary>
		/// 自由帳票グループ設定明細表示順位比較用クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : IComparable インターフェイスの実装。</br>
		/// <br>Programmer : 22011 柏原 頼人</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		public class FrePprGrTrDispOrderComparer : IComparer
		{
			/// <summary>
			/// 自由帳票グループ設定明細表示順位比較メソッド
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <remarks>
			/// <br>Note       : xとyを比較し、小さいときはマイナス、</br>
			/// <br>           : 大きいときはプラス、同じときはゼロを返します。</br>
			/// <br>Programmer : 22011 柏原 頼人</br>
			/// <br>Date       : 2007.04.03</br>
			/// </remarks>
			public int Compare(object x, object y) 
			{
				FrePprGrTr px = ( FrePprGrTr )x;
				FrePprGrTr py = ( FrePprGrTr )y;
				return (px.DisplayOrder - py.DisplayOrder);
			}
		}

        /// <summary>
        /// 自由帳票グループ振替ワーク表示順位比較用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : IComparable インターフェイスの実装。</br>
        /// <br>Programmer : 22011 柏原 頼人</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks>
        public class FrePprGrTrWkDispOrderComparer : IComparer<FrePprGrTrWork>
        {
            /// <summary>
            /// 自由帳票グループ振替ワーク表示順位比較メソッド
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <remarks>
            /// <br>Note       : xとyを比較し、小さいときはマイナス、</br>
            /// <br>           : 大きいときはプラス、同じときはゼロを返します。</br>
            /// <br>Programmer : 22011 柏原 頼人</br>
            /// <br>Date       : 2007.04.03</br>
            /// </remarks>
            public int Compare(FrePprGrTrWork x, FrePprGrTrWork y)
            {
                FrePprGrTrWork px = x;
                FrePprGrTrWork py = y;
                return (px.DisplayOrder - py.DisplayOrder);
            }
        }
		#endregion
	}
}