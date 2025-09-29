# region ※using
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先請求金額マスタアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先請求金額マスタのアクセス制御を行います。</br>
	/// <br>Programmer	: 渡邉貴裕</br>
	/// <br>Date		: 2007.04.03</br>
    /// <br>Update Note : 2008/08/08 30414 忍 幸史 Partsman用に変更</br>
	/// </remarks>
	public class CustDmdPrcAcs
	{
		# region ■Private Member
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ICustDmdPrcDB _iCustDmdPrcDB = null;
		/// <summary>ユーザーガイドオブジェクト格納バッファ(HashTable)</summary>
//		private Hashtable _CustDmdPrcGdBdTable;
		/// <summary>ユーザーガイドオブジェクト格納バッファ(ArrayList)</summary>
//		private ArrayList _CustDmdPrcGdBdList;
		/// <summary>キャリアマスタクラスStatic</summary>
//		private static Hashtable _carrierTable = null;
		# endregion				    
		  
		# region ■Constracter
		/// <summary>
		/// 得意先請求金額マスタアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先請求金額マスタアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcAcs()
		{

    		try
			{
				// リモートオブジェクト取得
				this._iCustDmdPrcDB = (ICustDmdPrcDB)MediationCustDmdPrcDB.GetCustDmdPrcDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iCustDmdPrcDB = null;
			}
		}
		# endregion

		#region ■Public Method

		/// <summary>
		/// キャリアクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>キャリアクラス</returns>
		/// <remarks>
		/// <br>Note       : キャリアクラスをデシリアライズします。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcUpdate Deserialize(string fileName)
		{
			CustDmdPrcUpdate carrier = null;

			// ファイル名を渡してキャリアワーククラスをデシリアライズする
			CustDmdPrcWork carrierWork = (CustDmdPrcWork)XmlByteSerializer.Deserialize(fileName,typeof(CustDmdPrcWork));

			return carrier;
		}

		/// <summary>
		/// キャリアListクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>キャリアクラスLIST</returns>
		/// <remarks>
		/// <br>Note       : キャリアリストクラスをデシリアライズします。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// ファイル名を渡してキャリアワーククラスをデシリアライズする
			CustDmdPrcWork[] carrierWorks = (CustDmdPrcWork[])XmlByteSerializer.Deserialize(fileName,typeof(CustDmdPrcWork[]));

			//デシリアライズ結果をキャリアクラスへコピー
			if (carrierWorks != null) 
			{
				al.Capacity = carrierWorks.Length;
				for(int i=0; i < carrierWorks.Length; i++)
				{
//					al.Add(CopyToCustDmdPrc(carrierWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// キャリアシリアライズ処理
		/// </summary>
		/// <param name="carrier">シリアライズ対象キャリアクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : キャリア情報のシリアライズを行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public void Serialize(CustDmdPrcUpdate carrier ,string fileName)
		{
			//キャリアクラスからキャリアワーカークラスにメンバコピー
//			CustDmdPrcWork carrierWork = CopyToCustDmdPrcWorkFromCustDmdPrc(carrier);
			//キャリアワーカークラスをシリアライズ
//			XmlByteSerializer.Serialize(carrierWork,fileName);
		}

		/// <summary>
		/// キャリアListシリアライズ処理
		/// </summary>
		/// <param name="carrieres">シリアライズ対象キャリアListクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : キャリアList情報のシリアライズを行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public void ListSerialize(ArrayList carrieres,string fileName)
		{
			CustDmdPrcWork[] carrierWorks = new CustDmdPrcWork[carrieres.Count];
			for(int i= 0; i < carrieres.Count; i++)
			{
//				carrierWorks[i] = CopyToCustDmdPrcWorkFromCustDmdPrc((CustDmdPrcUpdParam)carrieres[i]);
			}
			//キャリアワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(carrierWorks,fileName);
		}


		/// <summary>
		/// キャリア検索処理（論理削除除く）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : キャリア検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// キャリア検索処理（論理削除含む）
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>取得結果</returns>
		/// <remarks>
		/// <br>Note       : キャリア検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// キャリア数検索処理
		/// </summary>
		/// <param name="retTotalCnt">データ件数</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:全ﾃﾞｰﾀ)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : キャリア数の検索を行います。</br>
		/// <br>Programmer : 渡邉貴裕</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			CustDmdPrcWork carrierWork = new CustDmdPrcWork();
			carrierWork.EnterpriseCode = enterpriseCode;
			
			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(carrierWork);

			// キャリア検索
            int status = 0;
            retTotalCnt = 1;
			if (status != 0) retTotalCnt = 0;
				
			return status;
		}

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addUpdate">計上日付</param>
        /// <param name="totalDay">対象締日</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 登録を行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        public int RegistDmdData(string enterpriseCode,
                                 string sectionCode,
                                 DateTime addUpdate,
                                 int totalDay,
                                 out string msg)
        {   
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;   //企業
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;        //計上拠点
            custDmdPrcUpdateWork.AddUpDate = addUpdate;             // 計上日付
            custDmdPrcUpdateWork.AddUpYearMonth = addUpdate;
            custDmdPrcUpdateWork.CustomerTotalDay = totalDay;       //締日                        
            custDmdPrcUpdateWork.ProcCntntsFlag = 1;                // 1 売上締次更新
            custDmdPrcUpdateWork.UpdObjectFlag = 1;                 // 1:全得意先 2:個別得意先指定 3:個別得意先固定
                        
            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status;
            msg = "";

            try
            {
                status = this._iCustDmdPrcDB.Write(ref paraObj, out retObj, out msg);
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="addUpdate">前回締処理日</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 解除処理を行います。</br>
        /// <br>Programer  : 30414 忍 幸史</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        public int BanishDmdData(string enterpriseCode, 
                                 string sectionCode,
                                 DateTime addUpdate,
                                 out string msg)
        {
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;   // 企業
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;        // 拠点
            custDmdPrcUpdateWork.AddUpDate = addUpdate;             // 前回締処理日
            custDmdPrcUpdateWork.ProcCntntsFlag = 2;                 

            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status;
            msg = "";

            try
            {
                status = this._iCustDmdPrcDB.Delete(ref paraObj, out msg);
            }
            catch
            {
                status = -1;
            }

            return status;
        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/08 Partsman用に変更
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 登録処理
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        public int RegistDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, DateTime addUpdate, DateTime addUpYM, ArrayList setCustomer, ArrayList setTotalDay, int totalDay, int setOption, int mode, out string msg)
        {

            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode; //企業
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;      //計上拠点
            custDmdPrcUpdateWork.AddUpDate = addUpdate;
            custDmdPrcUpdateWork.AddUpYearMonth = addUpYM;

            custDmdPrcUpdateWork.CustomerCode1 = (int)setCustomer[0];
            custDmdPrcUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            custDmdPrcUpdateWork.CustomerCode2 = (int)setCustomer[1];
            custDmdPrcUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            custDmdPrcUpdateWork.CustomerCode3 = (int)setCustomer[2];
            custDmdPrcUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            custDmdPrcUpdateWork.CustomerCode4 = (int)setCustomer[3];
            custDmdPrcUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            custDmdPrcUpdateWork.CustomerCode5 = (int)setCustomer[4];
            custDmdPrcUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            custDmdPrcUpdateWork.CustomerCode6 = (int)setCustomer[5];
            custDmdPrcUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            custDmdPrcUpdateWork.CustomerCode7 = (int)setCustomer[6];
            custDmdPrcUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            custDmdPrcUpdateWork.CustomerCode8 = (int)setCustomer[7];
            custDmdPrcUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            custDmdPrcUpdateWork.CustomerCode9 = (int)setCustomer[8];
            custDmdPrcUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            custDmdPrcUpdateWork.CustomerCode10 = (int)setCustomer[9];
            custDmdPrcUpdateWork.Customer10TotalDay = (int)setTotalDay[9];

            custDmdPrcUpdateWork.CustomerTotalDay = totalDay; //締日                        

            custDmdPrcUpdateWork.ProcCntntsFlag = mode; // 1 売上締次更新 2 請求準備処理
            custDmdPrcUpdateWork.UpdObjectFlag = setOption; // 1:全得意先 2:個別得意先指定 3:個別得意先固定

            //		    byte[] parabyte = XmlByteSerializer.Serialize(custDmdPrcUpdateWork);
            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;
            //            object retObj = new object();

            int status = this._iCustDmdPrcDB.Write(ref paraObj, out retObj, out msg);

            retTotalCnt = 0;

            return status;
        }

        /// <summary>
        /// 解除処理
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <param name="setOption"></param>
        /// <param name="target"></param>
        /// <param name="mode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int BanishDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, ArrayList setCustomer, ArrayList setTotalDay, int totalDay, int setOption, int mode, out string msg)
        {
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;  // 企業
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;       // 拠点

            custDmdPrcUpdateWork.CustomerCode1 = (int)setCustomer[0];
            custDmdPrcUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            custDmdPrcUpdateWork.CustomerCode2 = (int)setCustomer[1];
            custDmdPrcUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            custDmdPrcUpdateWork.CustomerCode3 = (int)setCustomer[2];
            custDmdPrcUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            custDmdPrcUpdateWork.CustomerCode4 = (int)setCustomer[3];
            custDmdPrcUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            custDmdPrcUpdateWork.CustomerCode5 = (int)setCustomer[4];
            custDmdPrcUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            custDmdPrcUpdateWork.CustomerCode6 = (int)setCustomer[5];
            custDmdPrcUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            custDmdPrcUpdateWork.CustomerCode7 = (int)setCustomer[6];
            custDmdPrcUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            custDmdPrcUpdateWork.CustomerCode8 = (int)setCustomer[7];
            custDmdPrcUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            custDmdPrcUpdateWork.CustomerCode9 = (int)setCustomer[8];
            custDmdPrcUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            custDmdPrcUpdateWork.CustomerCode10 = (int)setCustomer[9];
            custDmdPrcUpdateWork.Customer10TotalDay = (int)setTotalDay[9];
            custDmdPrcUpdateWork.CustomerTotalDay = totalDay; //締日

            custDmdPrcUpdateWork.UpdObjectFlag = setOption;  // 全得意先指定有無(1 全部 2 個別指定 3 個別除外)
            custDmdPrcUpdateWork.ProcCntntsFlag = mode; // 1 締次更新 2 請求準備処理

            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status = this._iCustDmdPrcDB.Delete(ref paraObj, out msg);

            retTotalCnt = 0;

            return status;

        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman用に変更

        #endregion

        #region ■Private Method


        /// <summary>
        /// ローカルファイル読込み処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ローカルファイルを読込んで、情報をStaticに保持します。</br>
        /// <br>Programer  : 渡邉貴裕</br>
        /// <br>Date       : 2006.12.19</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // オフラインシリアライズデータ作成部品I/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search用 --- //
            // KeyList設定
            string[] carrierKeys = new string[1];
            carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ローカルファイル読込み処理
            object wkObj = offlineDataSerializer.DeSerialize("CustDmdPrcAcs", carrierKeys);
            // ArrayListにセット
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                // キャリアクラスワーカークラス（ArrayList） ⇒ UIクラス（Static）変換処理
                //				CopyToStaticFromWorker(wkList);
            }
        }
        #endregion
    }
}
