using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受発注管理全体設定テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受発注管理全体設定テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 日色 馨</br>
    /// <br>Date       : 2007.12.14</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// <br>UpdateNote : 2008.12.01 21024　佐々木 健</br>
    /// <br>           : Searchメソッドの追加</br>
    /// </remarks>
    public class AcptAnOdrTtlStAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IAcptAnOdrTtlStDB _iAcptAnOdrTtlStDB = null;
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private AcptAnOdrTtlStLcDB _acptAnOdrTtlStLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        /// <summary>
        /// 受発注管理全体設定テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public AcptAnOdrTtlStAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iAcptAnOdrTtlStDB = (IAcptAnOdrTtlStDB)MediationAcptAnOdrTtlStDB.GetAcptAnOdrTtlStDB();
			}
			catch (Exception ex)
			{
				if(ex.Message=="")
					this._iAcptAnOdrTtlStDB = null;
				
				//オフライン時はnullをセット
 				this._iAcptAnOdrTtlStDB = null;
			}
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._acptAnOdrTtlStLcDB = new AcptAnOdrTtlStLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
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
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        public int GetOnlineMode()
		{
 			if (this._iAcptAnOdrTtlStDB == null)
 			{
				return (int)OnlineMode.Offline;
 			}
 			else
 			{
				return (int)OnlineMode.Online;
 			}
		}

        /// <summary>
        /// 受発注管理全体設定読み込み処理
        /// </summary>
        /// <param name="acptAnOdrTtlSt">受発注管理全体設定オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>受発注管理全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定を読み込みます。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
        public int Read(out AcptAnOdrTtlSt acptAnOdrTtlSt, string enterpriseCode)
		{			
			try
			{
				acptAnOdrTtlSt = null;
				AcptAnOdrTtlStWork acptAnOdrTtlStWork	= new AcptAnOdrTtlStWork();
				acptAnOdrTtlStWork.EnterpriseCode	= enterpriseCode;

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);
                //
				////受発注管理全体設定読み込み
				//int status = this._iAcptAnOdrTtlStDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XMLの読み込み
				//	acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(AcptAnOdrTtlStWork));
				//	// クラス内メンバコピー
				//	acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    status = this._acptAnOdrTtlStLcDB.Read(ref acptAnOdrTtlStWork, 0);
                    if (status == 0)
                    {
                        // クラス内メンバコピー
                        acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);
                    
                    //受発注管理全体設定読み込み
                    status = this._iAcptAnOdrTtlStDB.Read(ref parabyte,0);
                    if (status == 0)
                    {
                    	// XMLの読み込み
                    	acptAnOdrTtlStWork = (AcptAnOdrTtlStWork)XmlByteSerializer.Deserialize(parabyte,typeof(AcptAnOdrTtlStWork));
                    	// クラス内メンバコピー
                    	acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
                return status;
			}
			catch (Exception)
			{
				//通信エラーは-1を戻す
				acptAnOdrTtlSt = null;
				//オフライン時はnullをセット
				this._iAcptAnOdrTtlStDB = null;
				return -1;
			}
		}

        // 2008.12.01 Add >>>
        /// <summary>
        /// 受発注管理全体設定検索処理(論理削除データは除外)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の検索処理を行います。論理削除データは抽出されません。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<

        /// <summary>
        /// 受発注管理全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// 受発注管理全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            acptAnOdrTtlStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = acptAnOdrTtlStWork;
            object retobj = null;

            // 受発注管理全体設定全件検索
            status = this._iAcptAnOdrTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (AcptAnOdrTtlStWork wkAcptAnOdrTtlStWork in wkList)
                    {
                        retList.Add(CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(wkAcptAnOdrTtlStWork));
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 受発注管理全体設定登録・更新処理
        /// </summary>
        /// <param name="acptAnOdrTtlSt">受発注管理全体設定クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        public int Write(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            AcptAnOdrTtlStWork acptAnOdrTtlStWork;
            ArrayList paraList = new ArrayList();

            // UIデータクラス→ワーク
            acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);
            paraList.Add(acptAnOdrTtlStWork);
            object paraobj = paraList;

            int status = 0;
            try
            {
                status = _iAcptAnOdrTtlStDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }
                // ワーク→UIデータクラス
                paraList = (ArrayList)paraobj;
                foreach (AcptAnOdrTtlStWork acptAnOdrTtlStWork2 in paraList)
                {
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork2);
                }
                return (0);
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iAcptAnOdrTtlStDB = null;
                //通信エラーは-1を戻す
                status = -1;
            }
            return status;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            // --- ADD 2008/06/06 -------------------------------->>>>>
            int status = 0;

            try
            {
                // 受発注管理全体設定クラスを受発注管理全体設定ワーククラスへメンバコピー
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // 保存
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受発注管理全体設定ワーククラスから受発注管理全体設定クラスへメンバコピー
                    ArrayList wklist = (ArrayList)paraObj;
                    acptAnOdrTtlStWork = wklist[0] as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iAcptAnOdrTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
            // --- ADD 2008/06/06 --------------------------------<<<<< 
        }

        /// <summary>
        /// 受発注管理全体設定論理削除処理
        /// </summary>
        /// <param name="estimateDefSet">受発注管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int LogicalDelete(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;

            try
            {
                // 受発注管理全体設定クラスを受発注管理全体設定ワーククラスへメンバコピー
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // 論理削除
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受発注管理全体設定ワーククラスを受発注管理全体設定クラスにメンバコピー
                    acptAnOdrTtlStWork = paraObj as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iAcptAnOdrTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 受発注管理全体設定物理削除処理
        /// </summary>
        /// <param name="estimateDefSet">受発注管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete(AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;
            try
            {
                // 受発注管理全体設定クラスを受発注管理全体設定ワーククラスへメンバコピー
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);
                // XML変換し、文字列をバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(acptAnOdrTtlStWork);

                // 受発注管理全体設定物理削除
                status = this._iAcptAnOdrTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iAcptAnOdrTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 受発注管理全体設定論理削除復活処理
        /// </summary>
        /// <param name="estimateDefSet">受発注管理全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Revival(ref AcptAnOdrTtlSt acptAnOdrTtlSt)
        {
            int status = 0;

            try
            {
                // 受発注管理全体設定クラスを受発注管理全体設定ワーククラスへメンバコピー
                AcptAnOdrTtlStWork acptAnOdrTtlStWork = CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(acptAnOdrTtlSt);

                // 受発注管理全体設定を復活
                Object paraObj = (object)acptAnOdrTtlStWork;
                status = this._iAcptAnOdrTtlStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受発注管理全体設定ワーククラスを受発注管理全体設定クラスにメンバコピー
                    acptAnOdrTtlStWork = paraObj as AcptAnOdrTtlStWork;
                    acptAnOdrTtlSt = CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(acptAnOdrTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iAcptAnOdrTtlStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
		/// 受発注管理全体設定シリアライズ処理
		/// </summary>
		/// <param name="AcptAnOdrTtlSt">シリアライズ対象受発注管理全体設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 受発注管理全体設定のシリアライズを行います。</br>
		/// <br>Programmer : 日色 馨</br>
		/// <br>Date       : 2007.12.14</br>
		/// </remarks>
		public void AcptAnOdrTtlStSerialize(AcptAnOdrTtlSt AcptAnOdrTtlSt,string fileName)
		{
			//プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(AcptAnOdrTtlSt,fileName);
		}

		/// <summary>
		/// 受発注管理全体設定Listシリアライズ処理
		/// </summary>
		/// <param name="AcptAnOdrTtlStList">シリアライズ対象受発注管理全体設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 受発注管理全体設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 日色 馨</br>
		/// <br>Date       : 2007.12.14</br>
		/// </remarks>
		public void AcptAnOdrTtlStListSerialize(ArrayList AcptAnOdrTtlStList,string fileName)
		{
			// ArrayListから配列を生成
			AcptAnOdrTtlSt[] AcptAnOdrTtlSts = (AcptAnOdrTtlSt[])AcptAnOdrTtlStList.ToArray(typeof(AcptAnOdrTtlSt));
			// プリンタ管理ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(AcptAnOdrTtlSts,fileName);

		}

        /// <summary>
        /// クラスメンバーコピー処理（受発注管理全体設定ワーククラス⇒受発注管理全体設定クラス）
        /// </summary>
        /// <param name="AcptAnOdrTtlStWork">受発注管理全体設定ワーククラス</param>
        /// <returns>受発注管理全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定ワーククラスから受発注管理全体設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private AcptAnOdrTtlSt CopyToAcptAnOdrTtlStFromAcptAnOdrTtlStWork(AcptAnOdrTtlStWork AcptAnOdrTtlStWork)
		{
			AcptAnOdrTtlSt AcptAnOdrTtlSt = new AcptAnOdrTtlSt();

			//ファイルヘッダ部分
			AcptAnOdrTtlSt.CreateDateTime			= AcptAnOdrTtlStWork.CreateDateTime;
			AcptAnOdrTtlSt.UpdateDateTime			= AcptAnOdrTtlStWork.UpdateDateTime;
			AcptAnOdrTtlSt.EnterpriseCode			= AcptAnOdrTtlStWork.EnterpriseCode;
			AcptAnOdrTtlSt.FileHeaderGuid			= AcptAnOdrTtlStWork.FileHeaderGuid;
			AcptAnOdrTtlSt.UpdEmployeeCode		    = AcptAnOdrTtlStWork.UpdEmployeeCode;
			AcptAnOdrTtlSt.UpdAssemblyId1			= AcptAnOdrTtlStWork.UpdAssemblyId1;
			AcptAnOdrTtlSt.UpdAssemblyId2			= AcptAnOdrTtlStWork.UpdAssemblyId2;
			AcptAnOdrTtlSt.LogicalDeleteCode		= AcptAnOdrTtlStWork.LogicalDeleteCode;
            //AcptAnOdrTtlSt.OrderNumberCompo = AcptAnOdrTtlStWork.OrderNumberCompo;       // DEL 2008/06/06
            AcptAnOdrTtlSt.EstmCountReflectDiv = AcptAnOdrTtlStWork.EstmCountReflectDiv;
            AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv = AcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv;
            AcptAnOdrTtlSt.FaxOrderDiv = AcptAnOdrTtlStWork.FaxOrderDiv;
            //AcptAnOdrTtlSt.DotKulOrderDiv = AcptAnOdrTtlStWork.DotKulOrderDiv;           // DEL 2008/06/06 
            AcptAnOdrTtlSt.SectionCode = AcptAnOdrTtlStWork.SectionCode;  // ADD 2008/06/06 

			return AcptAnOdrTtlSt;
		}

        /// <summary>
        /// クラスメンバーコピー処理（受発注管理全体設定クラス⇒受発注管理全体設定ワーククラス）
        /// </summary>
        /// <param name="AcptAnOdrTtlSt">受発注管理全体設定ワーククラス</param>
        /// <returns>受発注管理全体設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 受発注管理全体設定クラスから受発注管理全体設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 日色 馨</br>
        /// <br>Date       : 2007.12.14</br>
        /// </remarks>
        private AcptAnOdrTtlStWork CopyToAcptAnOdrTtlStWorkFromAcptAnOdrTtlSt(AcptAnOdrTtlSt AcptAnOdrTtlSt)
		{
			AcptAnOdrTtlStWork AcptAnOdrTtlStWork = new AcptAnOdrTtlStWork();

			AcptAnOdrTtlStWork.CreateDateTime			= AcptAnOdrTtlSt.CreateDateTime;
			AcptAnOdrTtlStWork.UpdateDateTime			= AcptAnOdrTtlSt.UpdateDateTime;
			AcptAnOdrTtlStWork.EnterpriseCode			= AcptAnOdrTtlSt.EnterpriseCode.Trim();
			AcptAnOdrTtlStWork.FileHeaderGuid			= AcptAnOdrTtlSt.FileHeaderGuid;
			AcptAnOdrTtlStWork.UpdEmployeeCode		    = AcptAnOdrTtlSt.UpdEmployeeCode;
			AcptAnOdrTtlStWork.UpdAssemblyId1			= AcptAnOdrTtlSt.UpdAssemblyId1;
			AcptAnOdrTtlStWork.UpdAssemblyId2			= AcptAnOdrTtlSt.UpdAssemblyId2;
			AcptAnOdrTtlStWork.LogicalDeleteCode		= AcptAnOdrTtlSt.LogicalDeleteCode;
            //AcptAnOdrTtlStWork.OrderNumberCompo = AcptAnOdrTtlSt.OrderNumberCompo;      // DEL 2008/06/06
            AcptAnOdrTtlStWork.EstmCountReflectDiv = AcptAnOdrTtlSt.EstmCountReflectDiv;
            AcptAnOdrTtlStWork.AcpOdrrSlipPrtDiv = AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv;
            AcptAnOdrTtlStWork.FaxOrderDiv = AcptAnOdrTtlSt.FaxOrderDiv;
            //AcptAnOdrTtlStWork.DotKulOrderDiv = AcptAnOdrTtlSt.DotKulOrderDiv;          // DEL 2008/06/06

            AcptAnOdrTtlStWork.SectionCode = AcptAnOdrTtlSt.SectionCode;  // ADD 2008/06/06 

            return AcptAnOdrTtlStWork;
		}
	}
}
