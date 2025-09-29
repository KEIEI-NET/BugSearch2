using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 請求書印刷パターン設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求書印刷パターンマスタへのアクセス制御を行います。</br>
    /// <br>Programmer : 23010  中村　仁</br>
    /// <br>Date       : 2007/07/03</br>
    /// <br>Update Note: 20081 疋田 勇人</br>
    /// <br>           : DC.NS用に変更</br>
    /// <br>UpdateNote : 2008/06/18 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>
    /// <br>UpdateNote : 2010/02/18 30531 大矢 睦美</br>
    /// <br>           : 注釈印字区分追加</br>
    /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>																							
    /// <br>           : 自社名印字区分を追加</br>																						
    /// </remarks>  
    public class DmdPrtPtnAcs : IGeneralGuideData
    {
        #region Constructor
        /// <summary>
        /// 請求書印刷パターン設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求書印刷パターン設定アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 23010  中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public DmdPrtPtnAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iDmdPrtPtnDB = (IDmdPrtPtnDB)MediationDmdPrtPtnDB.GetDmdPrtPtnDB();

                this._slipPrtKind = -1;  // ADD 2008/06/18
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iDmdPrtPtnDB = null;
            }
        }

        #endregion

        #region PrivateMember
        /// <summary>リモートオブジェクト格納バッファ</summary>
        private IDmdPrtPtnDB _iDmdPrtPtnDB = null;   
        /// <summary>キャッシュ用HashTable</summary>
        private Hashtable _dmdPrtPtnDBTable = null;
        ///// <summary>キャッシュ用ArrayList</summary>
        //private static ArrayList _mdPrtPtnCashList = null;

        // --- ADD 2008/06/18 -------------------------------->>>>>
        ///// <summary>印刷種別</summary>
        private int _slipPrtKind;

        struct DataKeys
        {
            public int dataInputSystem;       // データ入力システム
            public int slipPrtKind;           // 伝票印刷種別
            public string slipPrtSetPaperId;  // 伝票印刷設定用帳票ID
        }
        // --- ADD 2008/06/18 --------------------------------<<<<< 
        #endregion

        #region Public enum
        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        #endregion

        #region Public Method

        #region GetOnlineMode
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.07.03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iDmdPrtPtnDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        #endregion

        #region Read
 
        /// <summary>
        /// 読み込み処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターン設定UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="demandPtnNo">請求書パターン番号</param>
        /// <returns>クラス</returns>
        /// <remarks>
        /// <br>Note       : 1レコードRead処理です。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        //public int Read(out DmdPrtPtn dmdPrtPtn, string enterpriseCode,int demandPtnNo)  // DEL 2008/06/18
        public int Read(out DmdPrtPtn dmdPrtPtn, string enterpriseCode, int SlipPrtKind, string SlipPrtSetPaperId)  // ADD 2008/06/18
        {
            try
            {              
                dmdPrtPtn = null;
                //パラメータをセット
                DmdPrtPtnWork dmdPrtPtnWork     = new DmdPrtPtnWork();
                dmdPrtPtnWork.EnterpriseCode    = enterpriseCode;
                //dmdPrtPtnWork.DemandPtnNo       = demandPtnNo;  // DEL 2008/06/13

                // --- ADD 2008/06/18 -------------------------------->>>>>
                dmdPrtPtnWork.SlipPrtKind       = SlipPrtKind;
                dmdPrtPtnWork.SlipPrtSetPaperId = SlipPrtSetPaperId;
                // --- ADD 2008/06/18 --------------------------------<<<<< 

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);

                int status = this._iDmdPrtPtnDB.Read(ref parabyte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));
                    // クラス内メンバコピー
                    dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(dmdPrtPtnWork);

                }
                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                dmdPrtPtn = null;
                //オフライン時はnullをセット
                this._iDmdPrtPtnDB = null;
                return -1;
            }
        }

        #endregion

        #region ReadStaticMemory
        /// <summary>
        /// キャッシュ読み込み処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターン設定UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="demandPtnNo">請求書パターン番号</param>	
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャッシュしたデータより読込みを行います。</br>    
        /// <br>Programmer : 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        //public int ReadStaticMemory(out DmdPrtPtn dmdPrtPtn, string enterpriseCode,int demandPtnNo)  // DEL 2008/06/18
        public int ReadStaticMemory(out DmdPrtPtn dmdPrtPtn, string enterpriseCode, int slipPrtKind, string slipPrtSetPaperId)  // ADD 2008/06/18
        {
            return ReadStaticMemoryProc(out dmdPrtPtn, enterpriseCode, slipPrtKind, slipPrtSetPaperId);
        }

        #endregion

        #region Search
        /// <summary>
		/// 請求書印刷パターン設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 請求書印刷パターン設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.07.03</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			return SearchProc(out retList, enterpriseCode,0);
        }

        #endregion

        #region SearchAll
        /// <summary>
		/// 請求書印刷パターン設定全検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 請求書印刷パターン設定全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2007.07.03</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode) 
		{
			return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        #endregion

        /// <summary>
        /// 請求書印刷パターン設定全検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slipPrtKind">印刷種別</param>	
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求書印刷パターン設定全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int SearchAllPrintKindGroup(out ArrayList retList, string enterpriseCode, int slipPrtKind)
        {
            DmdPrtPtnWork dmdPrtPtnWork = new DmdPrtPtnWork();
            dmdPrtPtnWork.EnterpriseCode = enterpriseCode;

            if (slipPrtKind != 0)
            {
                dmdPrtPtnWork.SlipPrtKind = slipPrtKind;
            }

            retList = new ArrayList();
            retList.Clear();

            Object retObj;
            Object paraObj = dmdPrtPtnWork as Object;

            // 検索処理
            int status = this._iDmdPrtPtnDB.Search(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList wkList = retObj as ArrayList;
                DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();

                foreach (DmdPrtPtnWork wkDmdPrtPtnWork in wkList)
                {
                    dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(wkDmdPrtPtnWork);
                    //読込結果コレクションに追加
                    retList.Add(dmdPrtPtn);
                }
                //ソート処理
                retList.Sort(new CompareDmdPrtPtn());
            }
            return status;
        }

        #region Write
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="dmdPrtPtn">データクラス ArrayList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int Write(ref DmdPrtPtn dmdPrtPtn)
        {
            //請求書印刷パターン設定データクラス→請求書印刷パターン設定ワーククラス
            DmdPrtPtnWork dmdPrtPtnWork = CopyToDmdPrtPtnWorkFromDmdPrtPtn(dmdPrtPtn);
            // XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				//書き込み
				status = this._iDmdPrtPtnDB.Write(ref parabyte);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{					
					// ファイル名を渡して請求書印刷パターン設定ワーククラスをデシリアライズする
					dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte,typeof(DmdPrtPtnWork));
					// クラス内メンバコピー
					dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(dmdPrtPtnWork);
                    //キャッシュを更新
                    if (this._dmdPrtPtnDBTable != null)
                    {
                        UpdateDmdPrtPtnTble(dmdPrtPtn.Clone());
                    }
				}

			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iDmdPrtPtnDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}

			return status;
        }

        #endregion

        #region LogicalDelete
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターン設定データオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除を行います。</br>
        /// <br>Programmer : 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int LogicalDelete(ref DmdPrtPtn dmdPrtPtn)
        {           
            try
            {
                DmdPrtPtnWork dmdPrtPtnWork = CopyToDmdPrtPtnWorkFromDmdPrtPtn(dmdPrtPtn);
        	    //XMLへ変換し、文字列のバイナリ化
			    byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
			    // 請求書印刷パターン設定論理削除
			    int status = this._iDmdPrtPtnDB.LogicalDelete(ref parabyte);

			    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			    {
				    // ファイル名を渡して請求書印刷パターン設定ワーククラスをデシリアライズする
				    dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte,typeof(DmdPrtPtnWork));
				    // クラス内メンバコピー
				    dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(dmdPrtPtnWork);
                    //キャッシュを更新
                    if (this._dmdPrtPtnDBTable != null)
                    {
                        UpdateDmdPrtPtnTble(dmdPrtPtn.Clone());
                    }
			    }
                return status; 
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iDmdPrtPtnDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
             
        }

        #endregion

        #region Delete
        /// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="dmdPrtPtn">請求書印刷パターン設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 請求書印刷パターン設定情報の物理削除を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007/07/03</br>
		/// </remarks>
		public int Delete(DmdPrtPtn dmdPrtPtn)
		{
			try
			{
				DmdPrtPtnWork dmdPrtPtnWork = CopyToDmdPrtPtnWorkFromDmdPrtPtn(dmdPrtPtn);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
				// 請求書印刷パターン設定物理削除
				int status = this._iDmdPrtPtnDB.Delete(parabyte);
				//キャッシュを更新
                if (this._dmdPrtPtnDBTable != null)
                {
                    RemoveDmdPrtPtnTbl(dmdPrtPtn.Clone());
                }
                return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iDmdPrtPtnDB = null;
				//通信エラーは-1を戻す
				return -1;
			}          
        }

        #endregion

        #region Revival
        /// <summary>
		/// 論理削除復活処理
		/// </summary>
		/// <param name="dmdPrtPtn">請求書印刷パターン設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 請求書印刷パターン設定情報の復活を行います。</br>
		/// <br>Programmer : 23002　中村 仁</br>
		/// <br>Date       : 2007/07/03</br>
		/// </remarks>
		public int Revival(ref DmdPrtPtn dmdPrtPtn)
		{
			try
			{
				DmdPrtPtnWork dmdPrtPtnWork = CopyToDmdPrtPtnWorkFromDmdPrtPtn(dmdPrtPtn);
				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
				// 復活処理
				int status = this._iDmdPrtPtnDB.Revival(ref parabyte);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ファイル名を渡して請求書印刷パターン設定ワーククラスをデシリアライズする
					dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte,typeof(DmdPrtPtnWork));
					// クラス内メンバコピー
					dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(dmdPrtPtnWork);
                    //キャッシュを更新
                    if (this._dmdPrtPtnDBTable != null)
                    {
                        UpdateDmdPrtPtnTble(dmdPrtPtn.Clone());
                    }
				}

				return status;
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iDmdPrtPtnDB = null;
				//通信エラーは-1を戻す
				return -1;
			}
		}

        #endregion

        #endregion

        #region Private Method

        #region キャッシュ内データ検索処理(ReadStaticMemoryProc)
        /// <summary>
        /// キャッシュ内データ検索処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターン設定UIデータクラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="demandPtnNo">請求書パターン番号</param>	
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャッシュデータから検索を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        //private int ReadStaticMemoryProc(out DmdPrtPtn dmdPrtPtn, string enterpriseCode,int demandPtnNo)  // DEL 2008/06/18
        private int ReadStaticMemoryProc(out DmdPrtPtn dmdPrtPtn, string enterpriseCode, int slipPrtKind, string slipPrtSetPaperId)  // ADD 2008/06/18
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            dmdPrtPtn = new DmdPrtPtn();

            DataKeys dataKeys = new DataKeys();  // ADD 2008/06/18

            try
            {
                // キャッシュが存在しない時
                //if (this._dmdPrtPtnDBTable == null)  // DEL 2008/06/18
                if ((this._dmdPrtPtnDBTable == null) || (slipPrtKind != this._slipPrtKind))  // ADD 2008/06/18
                {
                    status = GetDmdPrtPtnDataBuffer(enterpriseCode, slipPrtKind);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                //該当データが存在するか？
                                // --- ADD 2008/06/18 -------------------------------->>>>>
                                dataKeys.dataInputSystem = 0;  // 0固定
                                dataKeys.slipPrtKind = slipPrtKind;
                                dataKeys.slipPrtSetPaperId = slipPrtSetPaperId;
                                // --- ADD 2008/06/18 --------------------------------<<<<< 
                                if (this._dmdPrtPtnDBTable.ContainsKey(dataKeys))
                                {
                                    dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnDBTable[dataKeys];
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            {
                                break;
                            }
                        default:
                            {
                                return status;
                            }
                    }

                    // 印刷種別保持
                    this._slipPrtKind = slipPrtKind;  // ADD 2008/06/18
                }
                else
                {                  
                    //該当データが存在するか？
                    // --- ADD 2008/06/18 -------------------------------->>>>>
                    dataKeys.dataInputSystem = 0;  // 0固定
                    dataKeys.slipPrtKind = slipPrtKind;
                    dataKeys.slipPrtSetPaperId = slipPrtSetPaperId;
                    // --- ADD 2008/06/18 --------------------------------<<<<< 
                    if (this._dmdPrtPtnDBTable.ContainsKey(dataKeys))
                    {
                        dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnDBTable[dataKeys];
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    } 
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }          
            return status;
        }

        #endregion

        #region 請求書印刷パターン情報キャッシュ処理(GetDmdPrtPtnDataBuffer)
        /// <summary>
        /// 請求書印刷パターン情報キャッシュ処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求書印刷パターン情報を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        //private int GetDmdPrtPtnDataBuffer(string enterpriseCode)
        private int GetDmdPrtPtnDataBuffer(string enterpriseCode, int slipPrtKind)
        {           
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            DataKeys dataKeys = new DataKeys();  // ADD 2008/06/18

            try
            {
                if (this._dmdPrtPtnDBTable == null)
                {
                    this._dmdPrtPtnDBTable = new Hashtable();
                }

                ArrayList dmdPrtPtnList = null;
                //status = SearchAll(out dmdPrtPtnList, enterpriseCode);  // DEL 2008/06/20
                status = SearchAllPrintKindGroup(out dmdPrtPtnList, enterpriseCode, slipPrtKind);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (dmdPrtPtnList.Count > 0)
                    {                      
                        foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
                        {
                            // 登録済み
                            /* --- DEL 2008/06/18 -------------------------------->>>>>
                            if (this._dmdPrtPtnDBTable.ContainsKey(dmdPrtPtn.DemandPtnNo))
                            {
                                this._dmdPrtPtnDBTable.Remove(dmdPrtPtn.DemandPtnNo);
                            }
                            this._dmdPrtPtnDBTable.Add(dmdPrtPtn.DemandPtnNo, dmdPrtPtn.Clone());  
                               --- DEL 2008/06/18 --------------------------------<<<<< */

                            // --- ADD 2008/06/18 -------------------------------->>>>>
                            dataKeys.dataInputSystem = 0;  // 0固定
                            dataKeys.slipPrtKind = slipPrtKind;
                            dataKeys.slipPrtSetPaperId = dmdPrtPtn.SlipPrtSetPaperId;
                            if (this._dmdPrtPtnDBTable.ContainsKey(dataKeys))
                            {
                                this._dmdPrtPtnDBTable.Remove(dataKeys);
                            }
                            this._dmdPrtPtnDBTable.Add(dataKeys, dmdPrtPtn.Clone());  
                            // --- ADD 2008/06/18 --------------------------------<<<<< 
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }          
            return status;
        }

        #endregion

        #region 検索処理(SearchProc)
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {           
            DmdPrtPtnWork dmdPrtPtnWork     = new DmdPrtPtnWork();
            dmdPrtPtnWork.EnterpriseCode    = enterpriseCode;

            retList = new ArrayList();
            retList.Clear();

            Object retObj;
            Object paraObj = dmdPrtPtnWork as Object;

            // 検索処理
            int status = this._iDmdPrtPtnDB.Search(out retObj, paraObj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList wkList = retObj as ArrayList;                             
                DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();

                foreach (DmdPrtPtnWork wkDmdPrtPtnWork in wkList)
                {
                    dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(wkDmdPrtPtnWork);
                    //読込結果コレクションに追加
                    retList.Add(dmdPrtPtn);
                }
                //ソート処理
                retList.Sort(new CompareDmdPrtPtn());
            }
            return status;
        }

        #endregion

        #region キャッシュデータ更新処理
        /// <summary>
        /// 請求書印刷パターン用Hashtableデータ更新処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターンデータオブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ用HashTableのデータの更新を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void UpdateDmdPrtPtnTble(DmdPrtPtn dmdPrtPtn)
        {
            DataKeys dataKeys = new DataKeys();  // ADD 2008/06/18

            if (this._dmdPrtPtnDBTable == null)
            {
                this._dmdPrtPtnDBTable = new Hashtable();
                this._dmdPrtPtnDBTable.Clear();
            }

            //キャッシュに追加
            if (this._dmdPrtPtnDBTable != null)
            {
                //登録済み
                /* --- DEL 2008/06/18 -------------------------------->>>>>
                if (this._dmdPrtPtnDBTable.ContainsKey(dmdPrtPtn.DemandPtnNo))
                {
                    this._dmdPrtPtnDBTable.Remove(dmdPrtPtn.DemandPtnNo);
                }
                //キャッシュ登録
                this._dmdPrtPtnDBTable.Add(dmdPrtPtn.DemandPtnNo,dmdPrtPtn.Clone());
                   --- DEL 2008/06/18 --------------------------------<<<<< */

                // --- ADD 2008/06/18 -------------------------------->>>>>
                dataKeys.dataInputSystem = 0;  // 0固定
                dataKeys.slipPrtKind = dmdPrtPtn.SlipPrtKind;
                dataKeys.slipPrtSetPaperId = dmdPrtPtn.SlipPrtSetPaperId;

                if (this._dmdPrtPtnDBTable.ContainsKey(dataKeys))
                {
                    this._dmdPrtPtnDBTable.Remove(dataKeys);
                }
                //キャッシュ登録
                this._dmdPrtPtnDBTable.Add(dataKeys, dmdPrtPtn.Clone());
                // --- ADD 2008/06/18 --------------------------------<<<<< 
            }
        }

        /// <summary>
        /// 請求書印刷パターン用Hashtableデータ削除処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターンデータオブジェクト</param>
        /// <remarks>
        /// <br>Note       : キャッシュ用Hashtableからデータの削除を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void RemoveDmdPrtPtnTbl(DmdPrtPtn dmdPrtPtn)
        {
            DataKeys dataKeys = new DataKeys();  // ADD 2008/06/18

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            if (this._dmdPrtPtnDBTable.ContainsKey(dmdPrtPtn.DemandPtnNo))
            {
                this._dmdPrtPtnDBTable.Remove(dmdPrtPtn.DemandPtnNo);
            }
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // --- ADD 2008/06/18 -------------------------------->>>>>
            dataKeys.dataInputSystem = 0;  // 0固定
            dataKeys.slipPrtKind = dmdPrtPtn.SlipPrtKind;
            dataKeys.slipPrtSetPaperId = dmdPrtPtn.SlipPrtSetPaperId;

            if (this._dmdPrtPtnDBTable.ContainsKey(dataKeys))
            {
                this._dmdPrtPtnDBTable.Remove(dataKeys);
            }
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }

        #endregion

        #region 請求印刷パターンUIデータクラス⇒ワーククラスコピー処理
        /// <summary>
        /// 請求印刷パターンUIデータメンバーコピー処理（UIデータクラス⇒ワーククラス）
        /// </summary>
        /// <param name="dmdPrtPtn">データクラス</param>
        /// <returns>クラス</returns>
        /// <remarks>
        /// <br>Note       : UIデータクラスからワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/02</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>																							
        /// <br>           : 自社名印字区分を追加</br>		
        /// </remarks>
        private DmdPrtPtnWork CopyToDmdPrtPtnWorkFromDmdPrtPtn(DmdPrtPtn dmdPrtPtn)
        {
            DmdPrtPtnWork dmdPrtPtnWork = new DmdPrtPtnWork();

            dmdPrtPtnWork.CreateDateTime = dmdPrtPtn.CreateDateTime; //作成日時
            dmdPrtPtnWork.UpdateDateTime = dmdPrtPtn.UpdateDateTime; //更新日時
            dmdPrtPtnWork.EnterpriseCode = dmdPrtPtn.EnterpriseCode; //企業コード
            dmdPrtPtnWork.FileHeaderGuid = dmdPrtPtn.FileHeaderGuid; //GUID
            dmdPrtPtnWork.UpdEmployeeCode = dmdPrtPtn.UpdEmployeeCode; //更新従業員コード
            dmdPrtPtnWork.UpdAssemblyId1 = dmdPrtPtn.UpdAssemblyId1; //更新アセンブリID1
            dmdPrtPtnWork.UpdAssemblyId2 = dmdPrtPtn.UpdAssemblyId2; //更新アセンブリID1
            dmdPrtPtnWork.LogicalDeleteCode = dmdPrtPtn.LogicalDeleteCode; //論理削除区分

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtnWork.DemandPtnNo = dmdPrtPtn.DemandPtnNo; //請求書パターン番号
            dmdPrtPtnWork.DemandPtnNoNm = dmdPrtPtn.DemandPtnNoNm; //請求書パターン番号
               --- DEL 2008/06/13 --------------------------------<<<<< */
            dmdPrtPtnWork.DmdTtlFormTitle1 = dmdPrtPtn.DmdTtlFormTitle1; //請求 鑑タイトル１
            dmdPrtPtnWork.DmdTtlFormTitle2 = dmdPrtPtn.DmdTtlFormTitle2; //請求 鑑タイトル２
            dmdPrtPtnWork.DmdTtlFormTitle3 = dmdPrtPtn.DmdTtlFormTitle3; //請求 鑑タイトル３
            dmdPrtPtnWork.DmdTtlFormTitle4 = dmdPrtPtn.DmdTtlFormTitle4; //請求 鑑タイトル４
            dmdPrtPtnWork.DmdTtlFormTitle5 = dmdPrtPtn.DmdTtlFormTitle5; //請求 鑑タイトル５
            dmdPrtPtnWork.DmdTtlFormTitle6 = dmdPrtPtn.DmdTtlFormTitle6; //請求 鑑タイトル６
            dmdPrtPtnWork.DmdTtlFormTitle7 = dmdPrtPtn.DmdTtlFormTitle7; //請求 鑑タイトル７
            dmdPrtPtnWork.DmdTtlFormTitle8 = dmdPrtPtn.DmdTtlFormTitle8; //請求 鑑タイトル８

            dmdPrtPtnWork.DmdTtlSetItemDiv1 = dmdPrtPtn.DmdTtlSetItemDiv1; //請求 鑑設定項目区分１
            dmdPrtPtnWork.DmdTtlSetItemDiv2 = dmdPrtPtn.DmdTtlSetItemDiv2; //請求 鑑設定項目区分２
            dmdPrtPtnWork.DmdTtlSetItemDiv3 = dmdPrtPtn.DmdTtlSetItemDiv3; //請求 鑑設定項目区分３
            dmdPrtPtnWork.DmdTtlSetItemDiv4 = dmdPrtPtn.DmdTtlSetItemDiv4; //請求 鑑設定項目区分４
            dmdPrtPtnWork.DmdTtlSetItemDiv5 = dmdPrtPtn.DmdTtlSetItemDiv5; //請求 鑑設定項目区分５
            dmdPrtPtnWork.DmdTtlSetItemDiv6 = dmdPrtPtn.DmdTtlSetItemDiv6; //請求 鑑設定項目区分６
            dmdPrtPtnWork.DmdTtlSetItemDiv7 = dmdPrtPtn.DmdTtlSetItemDiv7; //請求 鑑設定項目区分７
            dmdPrtPtnWork.DmdTtlSetItemDiv8 = dmdPrtPtn.DmdTtlSetItemDiv8; //請求 鑑設定項目区分８

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtnWork.PayTtlFormTitle1 = dmdPrtPtn.PayTtlFormTitle1; //支払 鑑タイトル１
            dmdPrtPtnWork.PayTtlFormTitle2 = dmdPrtPtn.PayTtlFormTitle2; //支払 鑑タイトル２
            dmdPrtPtnWork.PayTtlFormTitle3 = dmdPrtPtn.PayTtlFormTitle3; //支払 鑑タイトル３
            dmdPrtPtnWork.PayTtlFormTitle4 = dmdPrtPtn.PayTtlFormTitle4; //支払 鑑タイトル４
            dmdPrtPtnWork.PayTtlFormTitle5 = dmdPrtPtn.PayTtlFormTitle5; //支払 鑑タイトル５
            dmdPrtPtnWork.PayTtlFormTitle6 = dmdPrtPtn.PayTtlFormTitle6; //支払 鑑タイトル６
            dmdPrtPtnWork.PayTtlFormTitle7 = dmdPrtPtn.PayTtlFormTitle7; //支払 鑑タイトル７
            dmdPrtPtnWork.PayTtlFormTitle8 = dmdPrtPtn.PayTtlFormTitle8; //支払 鑑タイトル８
               --- DEL 2008/06/13 --------------------------------<<<<< */

            dmdPrtPtnWork.DmdFormTitle = dmdPrtPtn.DmdFormTitle; //請求書タイトル

            //dmdPrtPtnWork.PaymentFormTitle = dmdPrtPtn.PaymentFormTitle; //支払通知書タイトル  // DEL 2008/06/13

            dmdPrtPtnWork.DmdFormComent1 = dmdPrtPtn.DmdFormComent1; //請求書コメント１
            dmdPrtPtnWork.DmdFormComent2 = dmdPrtPtn.DmdFormComent2; //請求書コメント２
            dmdPrtPtnWork.DmdFormComent3 = dmdPrtPtn.DmdFormComent3; //請求書コメント３

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtnWork.DmdFmDmdTtlGenCd1 = dmdPrtPtn.DmdFmDmdTtlGenCd1; //請求書請求集計分類１
            dmdPrtPtnWork.DmdFmDmdTtlGenCd2 = dmdPrtPtn.DmdFmDmdTtlGenCd2; //請求書請求集計分類２
            dmdPrtPtnWork.DmdFmDmdTtlGenCd3 = dmdPrtPtn.DmdFmDmdTtlGenCd3; //請求書請求集計分類３
            dmdPrtPtnWork.DmdFmPayTtlGenCd1 = dmdPrtPtn.DmdFmPayTtlGenCd1; //請求書支払集計分類１
            dmdPrtPtnWork.DmdFmPayTtlGenCd2 = dmdPrtPtn.DmdFmPayTtlGenCd2; //請求書支払集計分類２
            dmdPrtPtnWork.DmdFmPayTtlGenCd3 = dmdPrtPtn.DmdFmPayTtlGenCd3; //請求書支払集計分類３
            dmdPrtPtnWork.DmdFmDmdTtlGenNm2 = dmdPrtPtn.DmdFmDmdTtlGenNm2; //請求書請求集計分類名称２
            dmdPrtPtnWork.DmdFmDmdTtlGenNm3 = dmdPrtPtn.DmdFmDmdTtlGenNm3; //請求書請求集計分類名称３
            dmdPrtPtnWork.DmdTtlGenDefltNm = dmdPrtPtn.DmdTtlGenDefltNm; //請求集計分類デフォルト名称
            dmdPrtPtnWork.PayTtlGenDefltNm = dmdPrtPtn.PayTtlGenDefltNm; //支払集計分類デフォルト名称
            dmdPrtPtnWork.DmdDtlUnitPrtDiv = dmdPrtPtn.DmdDtlUnitPrtDiv; //請求明細単価別出力有無
            dmdPrtPtnWork.PayDtlUnitPrtDiv = dmdPrtPtn.PayDtlUnitPrtDiv; //支払明細単価別出力有無
            dmdPrtPtnWork.ThTmDmdZeroPrtDiv = dmdPrtPtn.ThTmDmdZeroPrtDiv; //今回請求額ゼロ時印字有無
            dmdPrtPtnWork.DmdDtlPrcZeroPrtDiv = dmdPrtPtn.DmdDtlPrcZeroPrtDiv; //請求明細金額ゼロ時印字有無
            dmdPrtPtnWork.PayDtlPrcZeroPrtDiv = dmdPrtPtn.PayDtlPrcZeroPrtDiv; //支払明細金額ゼロ時印字有無
            dmdPrtPtnWork.MinusDmdPrtDiv = dmdPrtPtn.MinusDmdPrtDiv; //マイナス請求時印刷区分
            dmdPrtPtnWork.DmdFmDepoTtlPrtDiv = dmdPrtPtn.DmdFmDepoTtlPrtDiv; //請求書入金集計明細印字区分
            dmdPrtPtnWork.CmplDmdMdGoodsCd1 = dmdPrtPtn.CmplDmdMdGoodsCd1; //強制請求出力商品区分１
            dmdPrtPtnWork.CmplDmdMdGoodsCd2 = dmdPrtPtn.CmplDmdMdGoodsCd2; //強制請求出力商品区分２
            dmdPrtPtnWork.CmplDmdMdGoodsCd3 = dmdPrtPtn.CmplDmdMdGoodsCd3; //強制請求出力商品区分３
            dmdPrtPtnWork.CmplDmdMdGoodsCd4 = dmdPrtPtn.CmplDmdMdGoodsCd4; //強制請求出力商品区分４
            dmdPrtPtnWork.CmplDmdMdGoodsCd5 = dmdPrtPtn.CmplDmdMdGoodsCd5; //強制請求出力商品区分５
            dmdPrtPtnWork.CmplDmdMdGoodsCd6 = dmdPrtPtn.CmplDmdMdGoodsCd6; //強制請求出力商品区分６
            dmdPrtPtnWork.CmplDmdMdGoodsCd7 = dmdPrtPtn.CmplDmdMdGoodsCd7; //強制請求出力商品区分７
            dmdPrtPtnWork.CmplDmdMdGoodsCd8 = dmdPrtPtn.CmplDmdMdGoodsCd8; //強制請求出力商品区分８
            dmdPrtPtnWork.CmplDmdMdGoodsCd9 = dmdPrtPtn.CmplDmdMdGoodsCd9; //強制請求出力商品区分９
            dmdPrtPtnWork.CmplDmdMdGoodsCd10 = dmdPrtPtn.CmplDmdMdGoodsCd10; //強制請求出力商品区分１０
            dmdPrtPtnWork.CmplPayMdGoodsCd1 = dmdPrtPtn.CmplPayMdGoodsCd1; //強制支払出力商品区分１
            dmdPrtPtnWork.CmplPayMdGoodsCd2 = dmdPrtPtn.CmplPayMdGoodsCd2; //強制支払出力商品区分２
            dmdPrtPtnWork.CmplPayMdGoodsCd3 = dmdPrtPtn.CmplPayMdGoodsCd3; //強制支払出力商品区分３
            dmdPrtPtnWork.CmplPayMdGoodsCd4 = dmdPrtPtn.CmplPayMdGoodsCd4; //強制支払出力商品区分４
            dmdPrtPtnWork.CmplPayMdGoodsCd5 = dmdPrtPtn.CmplPayMdGoodsCd5; //強制支払出力商品区分５
            dmdPrtPtnWork.CmplPayMdGoodsCd6 = dmdPrtPtn.CmplPayMdGoodsCd6; //強制支払出力商品区分６
            dmdPrtPtnWork.CmplPayMdGoodsCd7 = dmdPrtPtn.CmplPayMdGoodsCd7; //強制支払出力商品区分７
            dmdPrtPtnWork.CmplPayMdGoodsCd8 = dmdPrtPtn.CmplPayMdGoodsCd8; //強制支払出力商品区分８
            dmdPrtPtnWork.CmplPayMdGoodsCd9 = dmdPrtPtn.CmplPayMdGoodsCd9; //強制支払出力商品区分９
            dmdPrtPtnWork.CmplPayMdGoodsCd10 = dmdPrtPtn.CmplPayMdGoodsCd10; //強制支払出力商品区分１０
           --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            dmdPrtPtnWork.DataInputSystem    = dmdPrtPtn.DataInputSystem;    // データ入力システム
            dmdPrtPtnWork.SlipPrtKind        = dmdPrtPtn.SlipPrtKind;        // 伝票印刷種別
            dmdPrtPtnWork.SlipPrtSetPaperId  = dmdPrtPtn.SlipPrtSetPaperId;  // 伝票印刷設定用帳票ID
            dmdPrtPtnWork.SlipComment        = dmdPrtPtn.SlipComment;        // 伝票コメント
            dmdPrtPtnWork.OutputFormFileName = dmdPrtPtn.OutputFormFileName; // 出力ファイル名
            dmdPrtPtnWork.TopMargin          = dmdPrtPtn.TopMargin;          // 上余白
            dmdPrtPtnWork.LeftMargin         = dmdPrtPtn.LeftMargin;         // 左余白
            dmdPrtPtnWork.RightMargin        = dmdPrtPtn.RightMargin;        // 右余白
            dmdPrtPtnWork.BottomMargin       = dmdPrtPtn.BottomMargin;       // 下余白
            dmdPrtPtnWork.CopyCount          = dmdPrtPtn.CopyCount;          // 複写枚数
            dmdPrtPtnWork.DmdFormTitle2      = dmdPrtPtn.DmdFormTitle2;      // 請求書タイトル２
            dmdPrtPtnWork.DmdDtlOutlineCode  = dmdPrtPtn.DmdDtlOutlineCode;  // 請求明細摘要区分
            dmdPrtPtnWork.DmdDtlPtnOdrDiv    = dmdPrtPtn.DmdDtlPtnOdrDiv;    // 請求明細書印字順位区分
            dmdPrtPtnWork.SlipTtlPrtDiv      = dmdPrtPtn.SlipTtlPrtDiv;      // 伝票計印字有無
            dmdPrtPtnWork.AddDayTtlPrtDiv    = dmdPrtPtn.AddDayTtlPrtDiv;    // 計上日計印字有無
            dmdPrtPtnWork.CustomerTtlPrtDiv  = dmdPrtPtn.CustomerTtlPrtDiv;  // 得意先計印字有無
            dmdPrtPtnWork.DtlPrcZeroPrtDiv   = dmdPrtPtn.DtlPrcZeroPrtDiv;   // 明細金額ゼロ時印字有無
            dmdPrtPtnWork.DepoDtlPrcPrtDiv   = dmdPrtPtn.DepoDtlPrcPrtDiv;   // 入金明細印字有無区分
            dmdPrtPtnWork.BillHonorificTtl   = dmdPrtPtn.BillHonorificTtl;   // 請求書敬称
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            dmdPrtPtnWork.ListPricePrtCd = dmdPrtPtn.ListPricePrtCd;        // 標準価格印字区分
            dmdPrtPtnWork.PartsNoPrtCd = dmdPrtPtn.PartsNoPrtCd;            // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            dmdPrtPtnWork.AnnotationPrtCd = dmdPrtPtn.AnnotationPrtCd;      //注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            dmdPrtPtnWork.CoNmPrintOutCd = dmdPrtPtn.CoNmPrintOutCd;
            // --- ADD  2011/02/16 ----------<<<<<

            // dmdPrtPtnWork.CellphoneIncOutDiv = dmdPrtPtn.CellphoneIncOutDiv; //機種別インセンティブ出力区分  // 2007.09.18 hikita del

            return dmdPrtPtnWork;
        }
        
        #endregion

        #region 請求印刷パターンワーククラス⇒UIデータクラスコピー処理
        /// <summary>
        /// 請求印刷パターンUIデータメンバーコピー処理（ワーククラス⇒UIデータクラス）
        /// </summary>
        /// <param name="dmdPrtPtnWork">ワーククラス</param>
        /// <returns>クラス</returns>
        /// <remarks>
        /// <br>Note       : ワーククラスからUIクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/02</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>																							
        /// <br>           : 自社名印字区分を追加</br>		
        /// </remarks>
        private DmdPrtPtn CopyToDmdPrtPtnFromDmdPrtPtnWork(DmdPrtPtnWork dmdPrtPtnWork)
        {
            DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();
           
            dmdPrtPtn.CreateDateTime = dmdPrtPtnWork.CreateDateTime; //作成日時
            dmdPrtPtn.UpdateDateTime = dmdPrtPtnWork.UpdateDateTime; //更新日時
            dmdPrtPtn.EnterpriseCode = dmdPrtPtnWork.EnterpriseCode; //企業コード
            dmdPrtPtn.FileHeaderGuid = dmdPrtPtnWork.FileHeaderGuid; //GUID
            dmdPrtPtn.UpdEmployeeCode = dmdPrtPtnWork.UpdEmployeeCode; //更新従業員コード
            dmdPrtPtn.UpdAssemblyId1 = dmdPrtPtnWork.UpdAssemblyId1; //更新アセンブリID1
            dmdPrtPtn.UpdAssemblyId2 = dmdPrtPtnWork.UpdAssemblyId2; //更新アセンブリID1
            dmdPrtPtn.LogicalDeleteCode = dmdPrtPtnWork.LogicalDeleteCode; //論理削除区分

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtn.DemandPtnNo = dmdPrtPtnWork.DemandPtnNo; //請求書パターン番号
            dmdPrtPtn.DemandPtnNoNm = dmdPrtPtnWork.DemandPtnNoNm; //請求書パターン名称
               --- DEL 2008/06/13 --------------------------------<<<<< */
            dmdPrtPtn.DmdTtlFormTitle1 = dmdPrtPtnWork.DmdTtlFormTitle1.TrimEnd(); //請求 鑑タイトル１
            dmdPrtPtn.DmdTtlFormTitle2 = dmdPrtPtnWork.DmdTtlFormTitle2.TrimEnd(); //請求 鑑タイトル２
            dmdPrtPtn.DmdTtlFormTitle3 = dmdPrtPtnWork.DmdTtlFormTitle3.TrimEnd(); //請求 鑑タイトル３
            dmdPrtPtn.DmdTtlFormTitle4 = dmdPrtPtnWork.DmdTtlFormTitle4.TrimEnd(); //請求 鑑タイトル４
            dmdPrtPtn.DmdTtlFormTitle5 = dmdPrtPtnWork.DmdTtlFormTitle5.TrimEnd(); //請求 鑑タイトル５
            dmdPrtPtn.DmdTtlFormTitle6 = dmdPrtPtnWork.DmdTtlFormTitle6.TrimEnd(); //請求 鑑タイトル６
            dmdPrtPtn.DmdTtlFormTitle7 = dmdPrtPtnWork.DmdTtlFormTitle7.TrimEnd(); //請求 鑑タイトル７
            dmdPrtPtn.DmdTtlFormTitle8 = dmdPrtPtnWork.DmdTtlFormTitle8.TrimEnd(); //請求 鑑タイトル８

            dmdPrtPtn.DmdTtlSetItemDiv1 = dmdPrtPtnWork.DmdTtlSetItemDiv1; //請求 鑑設定項目区分１
            dmdPrtPtn.DmdTtlSetItemDiv2 = dmdPrtPtnWork.DmdTtlSetItemDiv2; //請求 鑑設定項目区分２
            dmdPrtPtn.DmdTtlSetItemDiv3 = dmdPrtPtnWork.DmdTtlSetItemDiv3; //請求 鑑設定項目区分３
            dmdPrtPtn.DmdTtlSetItemDiv4 = dmdPrtPtnWork.DmdTtlSetItemDiv4; //請求 鑑設定項目区分４
            dmdPrtPtn.DmdTtlSetItemDiv5 = dmdPrtPtnWork.DmdTtlSetItemDiv5; //請求 鑑設定項目区分５
            dmdPrtPtn.DmdTtlSetItemDiv6 = dmdPrtPtnWork.DmdTtlSetItemDiv6; //請求 鑑設定項目区分６
            dmdPrtPtn.DmdTtlSetItemDiv7 = dmdPrtPtnWork.DmdTtlSetItemDiv7; //請求 鑑設定項目区分７
            dmdPrtPtn.DmdTtlSetItemDiv8 = dmdPrtPtnWork.DmdTtlSetItemDiv8; //請求 鑑設定項目区分８

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtn.PayTtlFormTitle1 = dmdPrtPtnWork.PayTtlFormTitle1.TrimEnd(); //支払 鑑タイトル１
            dmdPrtPtn.PayTtlFormTitle2 = dmdPrtPtnWork.PayTtlFormTitle2.TrimEnd(); //支払 鑑タイトル２
            dmdPrtPtn.PayTtlFormTitle3 = dmdPrtPtnWork.PayTtlFormTitle3.TrimEnd(); //支払 鑑タイトル３
            dmdPrtPtn.PayTtlFormTitle4 = dmdPrtPtnWork.PayTtlFormTitle4.TrimEnd(); //支払 鑑タイトル４
            dmdPrtPtn.PayTtlFormTitle5 = dmdPrtPtnWork.PayTtlFormTitle5.TrimEnd(); //支払 鑑タイトル５
            dmdPrtPtn.PayTtlFormTitle6 = dmdPrtPtnWork.PayTtlFormTitle6.TrimEnd(); //支払 鑑タイトル６
            dmdPrtPtn.PayTtlFormTitle7 = dmdPrtPtnWork.PayTtlFormTitle7.TrimEnd(); //支払 鑑タイトル７
            dmdPrtPtn.PayTtlFormTitle8 = dmdPrtPtnWork.PayTtlFormTitle8.TrimEnd(); //支払 鑑タイトル８
               --- DEL 2008/06/13 --------------------------------<<<<< */

            dmdPrtPtn.DmdFormTitle = dmdPrtPtnWork.DmdFormTitle.TrimEnd(); //請求書タイトル

            //dmdPrtPtn.PaymentFormTitle = dmdPrtPtnWork.PaymentFormTitle.TrimEnd(); //支払通知書タイトル  // DEL 2008/06/13

            dmdPrtPtn.DmdFormComent1 = dmdPrtPtnWork.DmdFormComent1.TrimEnd(); //請求書コメント１
            dmdPrtPtn.DmdFormComent2 = dmdPrtPtnWork.DmdFormComent2.TrimEnd(); //請求書コメント２
            dmdPrtPtn.DmdFormComent3 = dmdPrtPtnWork.DmdFormComent3.TrimEnd(); //請求書コメント３

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            dmdPrtPtn.DmdFmDmdTtlGenCd1 = dmdPrtPtnWork.DmdFmDmdTtlGenCd1; //請求書請求集計分類１
            dmdPrtPtn.DmdFmDmdTtlGenCd2 = dmdPrtPtnWork.DmdFmDmdTtlGenCd2; //請求書請求集計分類２
            dmdPrtPtn.DmdFmDmdTtlGenCd3 = dmdPrtPtnWork.DmdFmDmdTtlGenCd3; //請求書請求集計分類３
            dmdPrtPtn.DmdFmPayTtlGenCd1 = dmdPrtPtnWork.DmdFmPayTtlGenCd1; //請求書支払集計分類１
            dmdPrtPtn.DmdFmPayTtlGenCd2 = dmdPrtPtnWork.DmdFmPayTtlGenCd2; //請求書支払集計分類２
            dmdPrtPtn.DmdFmPayTtlGenCd3 = dmdPrtPtnWork.DmdFmPayTtlGenCd3; //請求書支払集計分類３
            dmdPrtPtn.DmdFmDmdTtlGenNm2 = dmdPrtPtnWork.DmdFmDmdTtlGenNm2.TrimEnd(); //請求書請求集計分類名称２
            dmdPrtPtn.DmdFmDmdTtlGenNm3 = dmdPrtPtnWork.DmdFmDmdTtlGenNm3.TrimEnd(); //請求書請求集計分類名称３
            dmdPrtPtn.DmdTtlGenDefltNm = dmdPrtPtnWork.DmdTtlGenDefltNm.TrimEnd(); //請求集計分類デフォルト名称
            dmdPrtPtn.PayTtlGenDefltNm = dmdPrtPtnWork.PayTtlGenDefltNm.TrimEnd(); //支払集計分類デフォルト名称
            dmdPrtPtn.DmdDtlUnitPrtDiv = dmdPrtPtnWork.DmdDtlUnitPrtDiv; //請求明細単価別出力有無
            dmdPrtPtn.PayDtlUnitPrtDiv = dmdPrtPtnWork.PayDtlUnitPrtDiv; //支払明細単価別出力有無
            dmdPrtPtn.ThTmDmdZeroPrtDiv = dmdPrtPtnWork.ThTmDmdZeroPrtDiv; //今回請求額ゼロ時印字有無
            dmdPrtPtn.DmdDtlPrcZeroPrtDiv = dmdPrtPtnWork.DmdDtlPrcZeroPrtDiv; //請求明細金額ゼロ時印字有無
            dmdPrtPtn.PayDtlPrcZeroPrtDiv = dmdPrtPtnWork.PayDtlPrcZeroPrtDiv; //支払明細金額ゼロ時印字有無
            dmdPrtPtn.MinusDmdPrtDiv = dmdPrtPtnWork.MinusDmdPrtDiv; //マイナス請求時印刷区分
            dmdPrtPtn.DmdFmDepoTtlPrtDiv = dmdPrtPtnWork.DmdFmDepoTtlPrtDiv; //請求書入金集計明細印字区分
            dmdPrtPtn.CmplDmdMdGoodsCd1 = dmdPrtPtnWork.CmplDmdMdGoodsCd1.TrimEnd(); //強制請求出力商品区分１
            dmdPrtPtn.CmplDmdMdGoodsCd2 = dmdPrtPtnWork.CmplDmdMdGoodsCd2.TrimEnd(); //強制請求出力商品区分２
            dmdPrtPtn.CmplDmdMdGoodsCd3 = dmdPrtPtnWork.CmplDmdMdGoodsCd3.TrimEnd(); //強制請求出力商品区分３
            dmdPrtPtn.CmplDmdMdGoodsCd4 = dmdPrtPtnWork.CmplDmdMdGoodsCd4.TrimEnd(); //強制請求出力商品区分４
            dmdPrtPtn.CmplDmdMdGoodsCd5 = dmdPrtPtnWork.CmplDmdMdGoodsCd5.TrimEnd(); //強制請求出力商品区分５
            dmdPrtPtn.CmplDmdMdGoodsCd6 = dmdPrtPtnWork.CmplDmdMdGoodsCd6.TrimEnd(); //強制請求出力商品区分６
            dmdPrtPtn.CmplDmdMdGoodsCd7 = dmdPrtPtnWork.CmplDmdMdGoodsCd7.TrimEnd(); //強制請求出力商品区分７
            dmdPrtPtn.CmplDmdMdGoodsCd8 = dmdPrtPtnWork.CmplDmdMdGoodsCd8.TrimEnd(); //強制請求出力商品区分８
            dmdPrtPtn.CmplDmdMdGoodsCd9 = dmdPrtPtnWork.CmplDmdMdGoodsCd9.TrimEnd(); //強制請求出力商品区分９
            dmdPrtPtn.CmplDmdMdGoodsCd10 = dmdPrtPtnWork.CmplDmdMdGoodsCd10.TrimEnd(); //強制請求出力商品区分１０
            dmdPrtPtn.CmplPayMdGoodsCd1 = dmdPrtPtnWork.CmplPayMdGoodsCd1.TrimEnd(); //強制支払出力商品区分１
            dmdPrtPtn.CmplPayMdGoodsCd2 = dmdPrtPtnWork.CmplPayMdGoodsCd2.TrimEnd(); //強制支払出力商品区分２
            dmdPrtPtn.CmplPayMdGoodsCd3 = dmdPrtPtnWork.CmplPayMdGoodsCd3.TrimEnd(); //強制支払出力商品区分３
            dmdPrtPtn.CmplPayMdGoodsCd4 = dmdPrtPtnWork.CmplPayMdGoodsCd4.TrimEnd(); //強制支払出力商品区分４
            dmdPrtPtn.CmplPayMdGoodsCd5 = dmdPrtPtnWork.CmplPayMdGoodsCd5.TrimEnd(); //強制支払出力商品区分５
            dmdPrtPtn.CmplPayMdGoodsCd6 = dmdPrtPtnWork.CmplPayMdGoodsCd6.TrimEnd(); //強制支払出力商品区分６
            dmdPrtPtn.CmplPayMdGoodsCd7 = dmdPrtPtnWork.CmplPayMdGoodsCd7.TrimEnd(); //強制支払出力商品区分７
            dmdPrtPtn.CmplPayMdGoodsCd8 = dmdPrtPtnWork.CmplPayMdGoodsCd8.TrimEnd(); //強制支払出力商品区分８
            dmdPrtPtn.CmplPayMdGoodsCd9 = dmdPrtPtnWork.CmplPayMdGoodsCd9.TrimEnd(); //強制支払出力商品区分９
            dmdPrtPtn.CmplPayMdGoodsCd10 = dmdPrtPtnWork.CmplPayMdGoodsCd10.TrimEnd(); //強制支払出力商品区分１０
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
            dmdPrtPtn.DataInputSystem    = dmdPrtPtnWork.DataInputSystem;              //  データ入力システム
            dmdPrtPtn.SlipPrtKind        = dmdPrtPtnWork.SlipPrtKind;                  // 伝票印刷種別
            dmdPrtPtn.SlipPrtSetPaperId  = dmdPrtPtnWork.SlipPrtSetPaperId.TrimEnd();  // 伝票印刷設定用帳票ID
            dmdPrtPtn.SlipComment        = dmdPrtPtnWork.SlipComment.TrimEnd();        // 伝票コメント
            dmdPrtPtn.OutputFormFileName = dmdPrtPtnWork.OutputFormFileName.TrimEnd(); // 出力ファイル名
            dmdPrtPtn.TopMargin          = dmdPrtPtnWork.TopMargin;                    // 上余白
            dmdPrtPtn.LeftMargin         = dmdPrtPtnWork.LeftMargin;                   // 左余白
            dmdPrtPtn.RightMargin        = dmdPrtPtnWork.RightMargin;                  // 右余白
            dmdPrtPtn.BottomMargin       = dmdPrtPtnWork.BottomMargin;                 // 下余白
            dmdPrtPtn.CopyCount          = dmdPrtPtnWork.CopyCount;                    // 複写枚数
            dmdPrtPtn.DmdFormTitle2      = dmdPrtPtnWork.DmdFormTitle2.TrimEnd();      // 請求書タイトル２
            dmdPrtPtn.DmdDtlOutlineCode  = dmdPrtPtnWork.DmdDtlOutlineCode;            // 請求明細摘要区分
            dmdPrtPtn.DmdDtlPtnOdrDiv    = dmdPrtPtnWork.DmdDtlPtnOdrDiv;              // 請求明細書印字順位区分
            dmdPrtPtn.SlipTtlPrtDiv      = dmdPrtPtnWork.SlipTtlPrtDiv;                // 伝票計印字有無
            dmdPrtPtn.AddDayTtlPrtDiv    = dmdPrtPtnWork.AddDayTtlPrtDiv;              // 計上日計印字有無
            dmdPrtPtn.CustomerTtlPrtDiv  = dmdPrtPtnWork.CustomerTtlPrtDiv;            // 得意先計印字有無
            dmdPrtPtn.DtlPrcZeroPrtDiv   = dmdPrtPtnWork.DtlPrcZeroPrtDiv;             // 明細金額ゼロ時印字有無
            dmdPrtPtn.DepoDtlPrcPrtDiv   = dmdPrtPtnWork.DepoDtlPrcPrtDiv;             // 入金明細印字有無区分
            dmdPrtPtn.BillHonorificTtl   = dmdPrtPtnWork.BillHonorificTtl.TrimEnd();   // 請求書敬称
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            dmdPrtPtn.ListPricePrtCd = dmdPrtPtnWork.ListPricePrtCd;        // 標準価格印字区分
            dmdPrtPtn.PartsNoPrtCd = dmdPrtPtnWork.PartsNoPrtCd;            // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            dmdPrtPtn.AnnotationPrtCd = dmdPrtPtnWork.AnnotationPrtCd;      //注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            dmdPrtPtn.CoNmPrintOutCd = dmdPrtPtnWork.CoNmPrintOutCd;
            // --- ADD  2011/02/16 ---------<<<<<

            // dmdPrtPtn.CellphoneIncOutDiv = dmdPrtPtnWork.CellphoneIncOutDiv; //機種別インセンティブ出力区分 // 2007.09.18 hikita del
            
            return dmdPrtPtn;
        }

        #endregion

        #region ガイド起動処理
        /// <summary>
        /// 請求書印刷パターン設定選択ガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="dmdPrtPtn">選択データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: 請求書印刷パターン設定の一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 23010 中村 仁</br>
        /// <br>Date		: 2007/07/04</br>
        /// </remarks>
        //public int ExecuteGuid(string enterpriseCode, out DmdPrtPtn dmdPrtPtn)
        public int ExecuteGuid(string enterpriseCode, int slipPrtKind, out DmdPrtPtn dmdPrtPtn)
        {
            return ExecuteGuid(out dmdPrtPtn, enterpriseCode, slipPrtKind);
        }

        /// <summary>
        /// 請求書印刷パターン設定選択ガイド起動処理
        /// </summary>
        /// <param name="dmdPrtPtn">選択データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		:請求書印刷パターン設定の一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 23010 中村 仁</br>
        /// <br>Date		: 2007/07/04</br>
        /// </remarks>
        //public int ExecuteGuid(out DmdPrtPtn dmdPrtPtn, string enterpriseCode)
        public int ExecuteGuid(out DmdPrtPtn dmdPrtPtn, string enterpriseCode, int slipPrtKind)
        {
            int status = -1;
            dmdPrtPtn = new DmdPrtPtn();
            Object objDmdPrtPtn = dmdPrtPtn;

            TableGuideParent tableGuideParent = new TableGuideParent("DMDPRTPTNGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            //企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("SlipPrtKind", slipPrtKind);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                TableGuideParent.HashTableToClassProperty(retObj, ref objDmdPrtPtn);
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }
            return status;
        }

        #endregion

        #region IGeneralGuidData Method
        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 23010 中村 仁</br>
        /// <br>Date		: 2007/07/04</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status   = -1;
            string enterpriseCode = "";//企業コード
            int slipPrtKind = -1;  // ADD 2008/06/18           

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            } 
            else 
            {
                // 企業コード設定無し ⇒ 有り得ないのでエラー
                return status;
            }

            // --- ADD 2008/06/18 -------------------------------->>>>>
            if (inParm.ContainsKey("SlipPrtKind"))
            {
                slipPrtKind = (int)inParm["SlipPrtKind"];
            }
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            //マスタREAD
            status = this.SearchDs(ref guideList, enterpriseCode, slipPrtKind);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                {
                    status = 4;
                    break;
                }
                default:
                status = -1;
                 break;
            }

            return status;
        }
        #endregion

        /// <summary>
		/// キャッシュ取得処理
		/// </summary>
		/// <param name="retList">データバッファ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="mode">0:論理削除を除く,1:論理削除を含む</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データバッファを取得します</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007/07/03</br>
		/// </remarks>
		//public int GetBuff(out ArrayList retList, string enterpriseCode, int mode)  // DEL 2008/06/18
        public int GetBuff(out ArrayList retList, string enterpriseCode, int slipPrtKind)  // ADD 2008/06/18
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            retList = new ArrayList();
            retList.Clear();
		
			// ガイド用バッファにデータが無ければリモートより取得する
			//if(_mdPrtPtnCashList == null)
            if (this._dmdPrtPtnDBTable == null || slipPrtKind != _slipPrtKind)
            {
                #region DEL
                //_mdPrtPtnCashList = new ArrayList();                
                //_mdPrtPtnCashList.Clear();
					
                //DmdPrtPtnWork dmdPrtPtnWork     = new DmdPrtPtnWork();
                //dmdPrtPtnWork.EnterpriseCode    = enterpriseCode;
  
                //Object retObj;
                //Object paraObj = dmdPrtPtnWork as Object;

                //// 検索処理
                //status = this._iDmdPrtPtnDB.Search(out retObj, paraObj, 0, 0);
                #endregion

                //status = GetDmdPrtPtnDataBuffer(enterpriseCode);  // DEL 2008/06/18

                // --- ADD 2008/06/18 -------------------------------->>>>>
                if (this._dmdPrtPtnDBTable != null)
                {
                    this._dmdPrtPtnDBTable.Clear();
                    this._dmdPrtPtnDBTable = null;
                }
                status = GetDmdPrtPtnDataBuffer(enterpriseCode, slipPrtKind);
                // --- ADD 2008/06/18 --------------------------------<<<<< 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (DmdPrtPtn dmdPrtPtn in this._dmdPrtPtnDBTable.Values)
                    {                     
                        retList.Add(dmdPrtPtn);
                    }
                    //ソート処理
                    retList.Sort(new CompareDmdPrtPtn());

                    //ArrayList wkList = retObj as ArrayList;                             
                    //DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();

                    //foreach (DmdPrtPtnWork wkDmdPrtPtnWork in wkList)
                    //{
                    //    dmdPrtPtn = CopyToDmdPrtPtnFromDmdPrtPtnWork(wkDmdPrtPtnWork);
                    //    retList.Add(dmdPrtPtn);
                    //    _mdPrtPtnCashList.Add(dmdPrtPtn);
                    //}
                    //ソート処理
                    //retList.Sort(new CompareDmdPrtPtn());
                }
			}
            else
            {
                //キャッシュ有
                foreach(DmdPrtPtn dmdPrtPtn in this._dmdPrtPtnDBTable.Values)
                {	            			       
				    retList.Add(dmdPrtPtn);			        
                }
                //ソート処理
                retList.Sort(new CompareDmdPrtPtn());
            }
	
            if(retList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // 印刷種別保持
            this._slipPrtKind = slipPrtKind;  // ADD 2008/06/18

			return status;
		}


        #region ガイド用Search

        /// <summary>
        /// 請求書印刷パターン設定検索処理
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求書印刷パターン設定の検索処理を行い、起動モードに応じて取得結果をデータセットで返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/04</br>
        /// </remarks>
        //private int SearchDs(ref DataSet ds, string enterpriseCode)  // DEL 2008/06/18
        private int SearchDs(ref DataSet ds, string enterpriseCode, int slipPrtKind)  // ADD 2008/06/18
        {
            int status = 0;

            ArrayList retList = null;
            ArrayList notLogicalDeletList = new ArrayList();

            //status = this.GetBuff( out retList, enterpriseCode, 0 );  // DEL 2008/06/18
            status = this.GetBuff(out retList, enterpriseCode, slipPrtKind);  // ADD 2008/06/18
            if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
            {
                //論理削除データを除く
                foreach(DmdPrtPtn demand in retList)
                {
                    if(demand.LogicalDeleteCode == 0)
                    {
                        notLogicalDeletList.Add(demand);
                    }
                }

                DmdPrtPtn[] dmdPrtPtns = notLogicalDeletList.ToArray( typeof( DmdPrtPtn) ) as DmdPrtPtn[];
                byte[] retbyte = XmlByteSerializer.Serialize(dmdPrtPtns);
                XmlByteSerializer.ReadXml( ref ds ,retbyte );
            }
          
            return status;
        }

        #endregion

        
        #endregion
    }

    #region IComparer

    /// <summary>
    /// 請求書印刷パターンデータ比較用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : IComparable インターフェイスの実装。</br>
    /// <br>Programmer : 23010 中村　仁</br>
    /// <br>Date       : 2007/07/03</br>
    /// </remarks>
    internal class CompareDmdPrtPtn : IComparer
    {
        /// <summary>
        /// List比較メソッド
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <remarks>
        /// <br>Note       : xとyを比較し、小さいときはマイナス、</br>
        /// <br>           : 大きいときはプラス、同じときはゼロを返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int Compare(object x, object y)
        {
            // --- ADD 2008/06/18 -------------------------------->>>>>
            string wkStrX = ""; 
            string wkStrY = ""; 
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            DmdPrtPtn dmdPrtPtnX = (DmdPrtPtn)x;
            DmdPrtPtn dmdPrtPtnY = (DmdPrtPtn)y;

            //return (dmdPrtPtnX.DemandPtnNo - dmdPrtPtnY.DemandPtnNo);  // DEL 2008/06/18 

            // --- ADD 2008/06/18 -------------------------------->>>>>
            wkStrX = dmdPrtPtnX.SlipPrtKind.ToString() + dmdPrtPtnX.SlipPrtSetPaperId;
            wkStrY = dmdPrtPtnX.SlipPrtKind.ToString() + dmdPrtPtnY.SlipPrtSetPaperId;

            return (wkStrX.CompareTo(wkStrY));
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }
    }

    #endregion
}
