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

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 請求全体設定クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求全体設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 22035 三橋 弘憲</br>
	/// <br>Date       : 2005.07.30</br>
	/// <br></br>
	/// <br>Update Note: 2006.06.01 23001 秋山　亮介</br>
    /// <br>                        1.前受金算定区分を追加</br>
    /// <br>Update Note: 2006.12.13 22022 段上 知子</br>
    /// <br>					    1.SF版を流用し携帯版を作成</br>
    /// <br>					    2.未使用項目を固定値へ変更(マイナス諸費用残高調整区分・前受金算定区分を削除)</br>
    /// <br>Programmer : 30415 柴田 倫幸</br>
    /// <br>Date       : 2008/06/16</br>	
    /// <br></br>
	/// </remarks>
	public class BillAllStAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IBillAllStDB _iBillAllStDB = null;

		/// <summary>
		/// 請求全体設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求全体設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public BillAllStAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iBillAllStDB = (IBillAllStDB)MediationBillAllStDB.GetBillAllStDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
 				this._iBillAllStDB = null; 
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
		/// オンラインモード取得
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>		
		public int GetOnlineMode()
		{
			if (this._iBillAllStDB == null)
			{
			return (int)OnlineMode.Offline;
			}
			else
			{
			return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 請求全体設定読み込み処理
		/// </summary>
		/// <param name="billallset">請求全体設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>   
		/// <remarks>
		/// <br>Note       : 請求全体設定を読み込みます。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int Read(out BillAllSt billallset, string enterpriseCode, string sectionCode)

		{			
			try
			{
				billallset = null;
				BillAllStWork billallsetWork = new BillAllStWork();
				billallsetWork.EnterpriseCode = enterpriseCode;
                billallsetWork.SectionCode = sectionCode;

				// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize(billallsetWork);  // DEL 2008/06/16

                Object paraObj = (object)billallsetWork;  // ADD 2008/06/16

				//請求全体設定読み込み
				//int status = this._iBillAllStDB.Read(ref parabyte,0);  // DEL 2008/06/16
                int status = this._iBillAllStDB.Read(ref paraObj, 0);  // ADD 2008/06/16

				if (status == 0)
				{
					// XMLの読み込み
					//billallsetWork = (BillAllStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillAllStWork));
                    ArrayList wklist = (ArrayList)paraObj;
                    billallsetWork = wklist[0] as BillAllStWork;
                    // クラス内メンバコピー
					billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
				}
				return status;
			}
			catch (Exception)
			{				
				//通信エラーは-1を戻す
				billallset = null;
				//オフライン時はnullをセット
				this._iBillAllStDB = null;
				return -1;
			}
		}

        /// <summary>
        /// 請求全体設定検索処理(論理削除データ含む)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定の検索処理を行います。論理削除データも抽出対象に含みます。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

		/// <summary>
		/// 請求全体設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>請求全体設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 請求全体設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public BillAllSt Deserialize(string fileName)
		{
			BillAllSt billallset = null;

			// ファイル名を渡して>請求全体設定ワーククラスをデシリアライズする
			BillAllStWork billallsetWork = (BillAllStWork)XmlByteSerializer.Deserialize(fileName,typeof(BillAllStWork));
			//デシリアライズ結果を>請求全体設定クラスへコピー
			if (billallsetWork != null) billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
			return billallset;
		}
		
		/// <summary>
		/// 請求全体設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>請求全体設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 請求全体設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>		
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// ファイル名を渡して請求全体設定ワーククラスをデシリアライズする
			BillAllStWork[] billallsetWorks = (BillAllStWork[])XmlByteSerializer.Deserialize(fileName,typeof(BillAllStWork[]));

			//デシリアライズ結果を請求全体設定クラスへコピー
			if (billallsetWorks != null) 
			{
				al.Capacity = billallsetWorks.Length;
				for(int i=0; i < billallsetWorks.Length; i++)
				{
					al.Add(CopyToAutoliasetFromBillAllStWork(billallsetWorks[i]));
				}
			}
			return al;
		}

		/// <summary>
		/// 請求全体設定登録・更新処理
		/// </summary>
		/// <param name="billallset">請求全体設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 請求全体設定の登録・更新を行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int Write(ref BillAllSt billallset)
		{
            ArrayList wklist = new ArrayList();

			// クラスからワーカークラスにメンバコピー
			BillAllStWork billallsetWork = CopyToBillAllStWorkFromBillAllSt(billallset);

			// XMLへ変換し、文字列のバイナリ化
			//byte[] parabyte = XmlByteSerializer.Serialize(billallsetWork);  // DEL 2008/06/16

            //Object paraObj = (object)billallsetWork;  // DEL 2008/06/16

            // --- ADD 2008/06/16 -------------------------------->>>>>
            wklist.Add(billallsetWork);
            Object paraObj = wklist;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			int status = 0;
			try
			{
				//書き込み
				//status = this._iBillAllStDB.Write(ref parabyte);
                status = this._iBillAllStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    //billallsetWork = (BillAllStWork)paraObj;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billallsetWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    // クラス内メンバコピー
					billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
				}
			}
			catch (Exception)
			{
				//オフライン時はnullをセット
				this._iBillAllStDB = null;
				//通信エラーは-1を戻す
				status = -1;
			}
			return status;
		}

        /// <summary>
        /// 請求全体設定論理削除処理
        /// </summary>
        /// <param name="estimateDefSet">請求全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定の論理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int LogicalDelete(ref BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();  // ADD 2008/06/16

            try
            {
                // 請求全体設定クラスを請求全体設定ワーククラスへメンバコピー
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                //Object paraObj = (object)billAllStWork;  // DEL 2008/06/16

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object paraObj = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // 請求全体設定を論理削除
                status = this._iBillAllStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 請求全体設定ワーククラスを請求全体設定クラスにメンバコピー
                    //billAllStWork = paraObj as BillAllStWork;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billAllStWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    billAllSt = CopyToAutoliasetFromBillAllStWork(billAllStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iBillAllStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 請求全体設定物理削除処理
        /// </summary>
        /// <param name="estimateDefSet">請求全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定の物理削除を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int Delete(BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();

            try
            {
                // 請求全体設定クラスを請求全体設定ワーククラスへメンバコピー
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object parabyte = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // XML変換し、文字列をバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(billAllStWork);  // DEL 2008/06/16

                // 請求全体設定物理削除
                status = this._iBillAllStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullを設定
                this._iBillAllStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

        /// <summary>
        /// 請求全体設定論理削除復活処理
        /// </summary>
        /// <param name="estimateDefSet">請求全体設定オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定の論理削除復活を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int Revival(ref BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();

            try
            {
                // 請求全体設定クラスを請求全体設定ワーククラスへメンバコピー
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object paraObj = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // 復活
                //Object paraObj = (object)billAllStWork;  // DEL 2008/06/16
                status = this._iBillAllStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 請求全体設定ワーククラスを請求全体設定クラスにメンバコピー
                    //billAllStWork = paraObj as BillAllStWork;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billAllStWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    billAllSt = CopyToAutoliasetFromBillAllStWork(billAllStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iBillAllStDB = null;

                // 通信エラーは-1を返す
                return -1;
            }
        }

		/// <summary>
		/// 請求全体設定シリアライズ処理
		/// </summary>
		/// <param name="billallset">シリアライズ対象請求全体設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 請求全体設定のシリアライズを行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void Serialize(BillAllSt billallset,string fileName)
		{
		//クラスからワーカークラスにメンバコピー
			BillAllStWork stockttlWork = CopyToBillAllStWorkFromBillAllSt(billallset);
			//従ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(stockttlWork,fileName);
		}

		/// <summary>
		/// 請求全体設定Listシリアライズ処理
		/// </summary>
		/// <param name="billallsetList">シリアライズ対象請求全体設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 請求全体設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void ListSerialize(ArrayList billallsetList,string fileName)
		{
			BillAllStWork[] billallsetWorks = new BillAllStWork[billallsetList.Count];
			for(int i= 0; i < billallsetList.Count; i++)
			{
				billallsetWorks[i] = CopyToBillAllStWorkFromBillAllSt((BillAllSt)billallsetList[i]);
			}
			//請求全体設定ワーカークラスをシリアライズ
			XmlByteSerializer.Serialize(billallsetWorks,fileName);
		}

        /// <summary>
        /// 請求全体設定検索処理(メイン)
        /// </summary>
        /// <param name="retList">検索結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求全体設定の検索処理を行います。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            BillAllStWork billAllStWork = new BillAllStWork();
            billAllStWork.EnterpriseCode = enterpriseCode;		// 企業コード

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = billAllStWork;
            object retobj = wkList;

            // 請求全体設定全件検索
            status = this._iBillAllStDB.Search(ref retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (BillAllStWork wkBillAllStWork in wkList)
                    {
                        retList.Add(CopyToAutoliasetFromBillAllStWork(wkBillAllStWork));
                    }
                }
            }

            return status;
        }

		/// <summary>
		/// クラスメンバーコピー処理（請求全体設定ワーククラス⇒請求全体設定クラス）
		/// </summary>
		/// <param name="billallsetWork">請求全体設定ワーククラス</param>
		/// <returns>請求全体設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 請求全体設定ワーククラスから請求全体設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private BillAllSt CopyToAutoliasetFromBillAllStWork(BillAllStWork billallsetWork)
		{
			BillAllSt billallset = new BillAllSt();

			//ファイルヘッダ部分
			billallset.CreateDateTime       = billallsetWork.CreateDateTime;
			billallset.UpdateDateTime       = billallsetWork.UpdateDateTime;
			billallset.EnterpriseCode       = billallsetWork.EnterpriseCode;
			billallset.FileHeaderGuid       = billallsetWork.FileHeaderGuid;
			billallset.UpdEmployeeCode      = billallsetWork.UpdEmployeeCode;
			billallset.UpdAssemblyId1       = billallsetWork.UpdAssemblyId1;
			billallset.UpdAssemblyId2       = billallsetWork.UpdAssemblyId2;
			billallset.LogicalDeleteCode    = billallsetWork.LogicalDeleteCode;

            billallset.SectionCode          = billallsetWork.SectionCode;  // ADD 2008/06/16

			//データ部分
            /* --- DEL 2008/06/16 -------------------------------->>>>>
			billallset.BillAllStCd          = billallsetWork.BillAllStCd;
			billallset.MinusVarCstBlAdjstCd = billallsetWork.MinusVarCstBlAdjstCd;
               --- DEL 2008/06/16 --------------------------------<<<<< */
            
            billallset.AllowanceProcCd      = billallsetWork.AllowanceProcCd;
			billallset.DepositSlipMntCd     = billallsetWork.DepositSlipMntCd;
            billallset.CollectPlnDiv        = billallsetWork.CollectPlnDiv;


            //billallset.BfRmonCalcDivCd      = billallsetWork.BfRmonCalcDivCd;  // DEL 2008/06/16

			//billallset.StockAllStMngCd     = billallsetWork.StockAllStMngCd;
			//billallset.ValidDtConsTaxRate1 = billallsetWork.ValidDtConsTaxRate1;
			//billallset.ConsTaxRate1        = billallsetWork.ConsTaxRate1;
			//billallset.ValidDtConsTaxRate2 = billallsetWork.ValidDtConsTaxRate2;
			//billallset.ConsTaxRate2        = billallsetWork.ConsTaxRate2;
			//billallset.ValidDtConsTaxRate3 = billallsetWork.ValidDtConsTaxRate3;
			//billallset.ConsTaxRate3        = billallsetWork.ConsTaxRate3;
			//billallset.ConsTaxFracProcDiv  = billallsetWork.ConsTaxFracProcDiv;
			//billallset.AutoEntryStockCd    = billallsetWork.AutoEntryStockCd;     
			//billallset.MinusVarCstBlAdjstCd     = billallsetWork.MinusVarCstBlAdjstCd;
			//billallset.AllowanceProcCd   = billallsetWork.AllowanceProcCd;
			//billallset.DepositSlipMntCd = billallsetWork.DepositSlipMntCd;

            // --- ADD 2008/06/16 -------------------------------->>>>>
            billallset.CustomerTotalDay1 = billallsetWork.CustomerTotalDay1;
            billallset.CustomerTotalDay2 = billallsetWork.CustomerTotalDay2;
            billallset.CustomerTotalDay3 = billallsetWork.CustomerTotalDay3;
            billallset.CustomerTotalDay4 = billallsetWork.CustomerTotalDay4;
            billallset.CustomerTotalDay5 = billallsetWork.CustomerTotalDay5;
            billallset.CustomerTotalDay6 = billallsetWork.CustomerTotalDay6;
            billallset.CustomerTotalDay7 = billallsetWork.CustomerTotalDay7;
            billallset.CustomerTotalDay8 = billallsetWork.CustomerTotalDay8;
            billallset.CustomerTotalDay9 = billallsetWork.CustomerTotalDay9;
            billallset.CustomerTotalDay10 = billallsetWork.CustomerTotalDay10;
            billallset.CustomerTotalDay11 = billallsetWork.CustomerTotalDay11;
            billallset.CustomerTotalDay12 = billallsetWork.CustomerTotalDay12;

            billallset.SupplierTotalDay1 = billallsetWork.SupplierTotalDay1;
            billallset.SupplierTotalDay2 = billallsetWork.SupplierTotalDay2;
            billallset.SupplierTotalDay3 = billallsetWork.SupplierTotalDay3;
            billallset.SupplierTotalDay4 = billallsetWork.SupplierTotalDay4;
            billallset.SupplierTotalDay5 = billallsetWork.SupplierTotalDay5;
            billallset.SupplierTotalDay6 = billallsetWork.SupplierTotalDay6;
            billallset.SupplierTotalDay7 = billallsetWork.SupplierTotalDay7;
            billallset.SupplierTotalDay8 = billallsetWork.SupplierTotalDay8;
            billallset.SupplierTotalDay9 = billallsetWork.SupplierTotalDay9;
            billallset.SupplierTotalDay10 = billallsetWork.SupplierTotalDay10;
            billallset.SupplierTotalDay11 = billallsetWork.SupplierTotalDay11;
            billallset.SupplierTotalDay12 = billallsetWork.SupplierTotalDay12;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return billallset;
		}

		/// <summary>
		/// クラスメンバーコピー処理（請求全体設定クラス⇒請求全体設定ワーククラス）
		/// </summary>
		/// <param name="billallset">請求全体クラス</param>
		/// <returns>請求全体ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : 請求全体設定クラスから請求全体設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private BillAllStWork CopyToBillAllStWorkFromBillAllSt(BillAllSt billallset)
		{
 			BillAllStWork billallsetWork = new BillAllStWork();
			//ファイルヘッダ部分
			billallsetWork.CreateDateTime       = billallset.CreateDateTime;
			billallsetWork.UpdateDateTime       = billallset.UpdateDateTime;
			billallsetWork.EnterpriseCode       = billallset.EnterpriseCode;
			billallsetWork.FileHeaderGuid       = billallset.FileHeaderGuid;
			billallsetWork.UpdEmployeeCode      = billallset.UpdEmployeeCode;
			billallsetWork.UpdAssemblyId1       = billallset.UpdAssemblyId1;
			billallsetWork.UpdAssemblyId2       = billallset.UpdAssemblyId2;
			billallsetWork.LogicalDeleteCode    = billallset.LogicalDeleteCode;

            billallsetWork.SectionCode = billallset.SectionCode;  // ADD 2008/06/16

			//データ部分
            /* --- DEL 2008/06/16 -------------------------------->>>>>
			billallsetWork.BillAllStCd          = billallset.BillAllStCd;
			billallsetWork.MinusVarCstBlAdjstCd = billallset.MinusVarCstBlAdjstCd;
               --- DEL 2008/06/16 --------------------------------<<<<< */
            billallsetWork.AllowanceProcCd      = billallset.AllowanceProcCd;
			billallsetWork.DepositSlipMntCd     = billallset.DepositSlipMntCd;
            billallsetWork.CollectPlnDiv        = billallset.CollectPlnDiv;

			//billallsetWork.BfRmonCalcDivCd      = billallset.BfRmonCalcDivCd;  // ADD 2008/06/16

            // --- ADD 2008/06/16 -------------------------------->>>>>
            billallsetWork.CustomerTotalDay1 = billallset.CustomerTotalDay1;
            billallsetWork.CustomerTotalDay2 = billallset.CustomerTotalDay2;
            billallsetWork.CustomerTotalDay3 = billallset.CustomerTotalDay3;
            billallsetWork.CustomerTotalDay4 = billallset.CustomerTotalDay4;
            billallsetWork.CustomerTotalDay5 = billallset.CustomerTotalDay5;
            billallsetWork.CustomerTotalDay6 = billallset.CustomerTotalDay6;
            billallsetWork.CustomerTotalDay7 = billallset.CustomerTotalDay7;
            billallsetWork.CustomerTotalDay8 = billallset.CustomerTotalDay8;
            billallsetWork.CustomerTotalDay9 = billallset.CustomerTotalDay9;
            billallsetWork.CustomerTotalDay10 = billallset.CustomerTotalDay10;
            billallsetWork.CustomerTotalDay11 = billallset.CustomerTotalDay11;
            billallsetWork.CustomerTotalDay12 = billallset.CustomerTotalDay12;

            billallsetWork.SupplierTotalDay1 = billallset.SupplierTotalDay1;
            billallsetWork.SupplierTotalDay2 = billallset.SupplierTotalDay2;
            billallsetWork.SupplierTotalDay3 = billallset.SupplierTotalDay3;
            billallsetWork.SupplierTotalDay4 = billallset.SupplierTotalDay4;
            billallsetWork.SupplierTotalDay5 = billallset.SupplierTotalDay5;
            billallsetWork.SupplierTotalDay6 = billallset.SupplierTotalDay6;
            billallsetWork.SupplierTotalDay7 = billallset.SupplierTotalDay7;
            billallsetWork.SupplierTotalDay8 = billallset.SupplierTotalDay8;
            billallsetWork.SupplierTotalDay9 = billallset.SupplierTotalDay9;
            billallsetWork.SupplierTotalDay10 = billallset.SupplierTotalDay10;
            billallsetWork.SupplierTotalDay11 = billallset.SupplierTotalDay11;
            billallsetWork.SupplierTotalDay12 = billallset.SupplierTotalDay12;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return billallsetWork;
		}
		
		/// <summary>
		/// 対象データチェック
		/// </summary>
		/// <param name="billallset">対象データ</param>
		/// <param name="billallsetPara">パラメータ</param>
		/// <returns>チェック結果（true:OK false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 対象データとパラメータを比較します。</br>
		/// <br>Programmer : 22035 三橋 弘憲</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private bool checkTarGetData(BillAllSt billallset,BillAllSt billallsetPara)
		{
			// 企業コードを比較
			if (billallsetPara.EnterpriseCode != null)
			{
				if (!billallsetPara.EnterpriseCode.Equals(billallset.EnterpriseCode))
					return false;
			}
			return true;
		}
		
	}
}
