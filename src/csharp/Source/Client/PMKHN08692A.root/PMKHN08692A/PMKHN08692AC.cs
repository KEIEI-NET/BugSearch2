using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 拠点情報テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点情報テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class SecPrintSetAcs 
	{

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ISecInfoSetDB _iSecInfoSetDB = null;
        private SectionInfoLcDB _sectionInfoLcDB = null;
        private static bool _isLocalDBRead = false;

		/// <summary>自社名称格納バッファ</summary>
		private Hashtable _companyNmTable = null;

        /// <summary>自社情報格納バッファ</summary>
        private Hashtable _companyInfTable = null;

        /// <summary>拠点倉庫名称格納バッファ</summary>
        private Hashtable _sectWarehouseNmTable = null;

		private SecInfoAcs _secInfoAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 拠点情報テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 拠点情報テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SecPrintSetAcs()
		{

			this._companyNmTable = null;
            this._companyInfTable = null;

			try
			{
				// リモートオブジェクト取得
				this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iSecInfoSetDB = null;
			}
            // ローカルDBアクセスオブジェクト取得
            this._sectionInfoLcDB = new SectionInfoLcDB();
        }

        /// <summary>
        /// ローカルＤＢ対応拠点情報クラス作成処理
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
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
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSecInfoSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 拠点情報全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SectionPrintWork sectionPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0,  sectionPrintWork);
		}

		/// <summary>
		/// 拠点情報検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode, SectionPrintWork sectionPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0,  sectionPrintWork);
		}

		

		/// <summary>
		/// 拠点情報検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SectionPrintWork sectionPrintWork)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;
			
			//次データ有無初期化
			nextData = false;
			//0で初期化
			retTotalCnt = 0;

            int checkstatus = 0;

			SecInfoSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

			// 拠点情報検索
			int status = 0;
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // 拠点情報検索
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                if (status == 0)
                {
                    //拠点情報クラスへメンバコピー
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // 抽出処理
                        checkstatus = DataCheck(workList[i], sectionPrintWork);
                        if (checkstatus == 0)
                        {
                            //拠点情報クラスへメンバコピー
                            retList.Add(CopyToSecInfoSetFromSecInfoSetWork(workList[i]));
                        }
                        
                    }
                }
            }
            else
            {
                if (readCnt == 0)
                {
                	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
                }
                else
                {
                	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
                }
                if (status == 0)
                {
                	// XMLの読み込み
                	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));

                	for(int i = 0;i < al.Length;i++)
                	{
                		//サーチ結果取得
                		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];

                        // 抽出処理
                        checkstatus = DataCheck(wkSecInfoSetWork, sectionPrintWork);
                        if (checkstatus == 0)
                        {
                            //拠点情報クラスへメンバコピー
                            retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
                        }
                		
                	}
                }
            }
            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

		/// <summary>
        /// 自社名称取得処理
		/// </summary>
		/// <param name="companyName1">自社名称１</param>
		/// <param name="companyName2">自社名称２</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称コードから自社情報を取得します</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int GetCompanyName( out string companyName1, out string companyName2, out string postco,
                                   out string address1, out string address3, out string address4,
                                   out string companyTelNo1, out string companyTelNo2,out string companyTelNo3,
                                   out string companySetNote1, out string companySetNote2,
                                   string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			CompanyNm companyNm = null;
            
			companyName1 = "";
			companyName2 = "";
            postco = "";
            address1 = "";
            address3 = "";
            address4 = "";
            companyTelNo1 = "";
            companyTelNo2 = "";
            companyTelNo3 = "";
            companySetNote1 = "";
            companySetNote2 = "";
			if( companyNameCd > 0 ) {

				// 自社名称読み込み
				status = ReadCompanyNm( out companyNm, enterpriseCode, companyNameCd );
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( companyNm.LogicalDeleteCode == 0 ) {
						companyName1 = companyNm.CompanyName1;
						companyName2 = companyNm.CompanyName2;
                        postco = companyNm.PostNo;
                        address1 = companyNm.Address1;
                        address3 = companyNm.Address3;
                        address4 = companyNm.Address4;
                        companyTelNo1 = companyNm.CompanyTelNo1;
                        companyTelNo2 = companyNm.CompanyTelNo2;
                        companyTelNo3 = companyNm.CompanyTelNo3;
                        companySetNote1 = companyNm.CompanySetNote1;
                        companySetNote2 = companyNm.CompanySetNote2;
					}
					else {
                        companyName1 = "削除済";
						status = -1;
					}
				}
				else {
                    companyName1 = "未登録";
				}
			}

			return status;
		}

		/// <summary>
        /// 自社名称読込処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <returns>STATUS</returns>
		public int ReadCompanyNm( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			companyNm = null;

				status = SetCompanyNmTable( enterpriseCode );
				if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// 読み込み失敗
					return status;
				}

			// テーブルにキーが存在している
			if( this._companyNmTable.ContainsKey( companyNameCd ) == true ) {
				companyNm = ( ( CompanyNm )this._companyNmTable[ companyNameCd ] ).Clone();
			}
			else {
				status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			return status;
		}

		/// <summary>
		/// 自社名称検索処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の検索処理を行い、バッファに格納します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
		private int SetCompanyNmTable( string enterpriseCode )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyNmTable == null)
            {
                this._companyNmTable = new Hashtable();
                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                companyNmAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._companyNmTable.Clear();
                status = companyNmAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNm companyNm in retList)
                    {
                        if (this._companyNmTable.ContainsKey(companyNm.CompanyNameCd) == false)
                        {
                            this._companyNmTable.Add(companyNm.CompanyNameCd, companyNm.Clone());
                        }
                    }
                }
            }

			return status;
		}

        /// <summary>
        /// 自社情報検索
        /// </summary>
        /// <param name="companyTelTitle3"></param>
        /// <param name="companyTelTitle3"></param>
        /// <param name="companyTelTitle3"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int GetCompanyInf(out string companyTelTitle1, out string companyTelTitle2, out string companyTelTitle3, string enterpriseCode)
        {
            int status = 0;
            CompanyInf companyInf = null;

            companyTelTitle1 = "";
            companyTelTitle2 = "";
            companyTelTitle3 = "";

            // 自社情報読み込み
            status = ReadCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (companyInf.LogicalDeleteCode == 0)
                {
                    companyTelTitle1 = companyInf.CompanyTelTitle1;
                    companyTelTitle2 = companyInf.CompanyTelTitle2;
                    companyTelTitle3 = companyInf.CompanyTelTitle3;
                }
                else
                {
                    status = -1;
                }
            }

            return status;
        }

        /// <summary>
        /// 自社情報読込処理
        /// </summary>
        /// <param name="companyInf"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            int status = 0;
            companyInf = null;

            status = SetCompanyInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読み込み失敗
                return status;
            }

            // テーブルにキーが存在している
            if (this._companyInfTable.ContainsKey(0) == true)
            {
                companyInf = ((CompanyInf)this._companyInfTable[0]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// 自社情報検索処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetCompanyInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyInfTable == null)
            {
                this._companyInfTable = new Hashtable();
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.IsLocalDBRead = _isLocalDBRead;
                CompanyInf companyInf = null;
                this._companyInfTable.Clear();
                status = companyInfAcs.Read(out companyInf, enterpriseCode);

                this._companyInfTable.Add(0, companyInf.Clone());
            }

            return status;
        }

        /// <summary>
        /// 拠点倉庫名称の取得処理
        /// </summary>
        /// <param name="warehouseName">拠点倉庫名称</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">拠点倉庫コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点倉庫コードから拠点倉庫名称を取得します</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;

            warehouseName = "";

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            Warehouse warehouse = null;

            this._sectWarehouseNmTable = new Hashtable();

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = _isLocalDBRead;

            // 拠点倉庫名称の読込
            status = warehouseAcs.Read(out warehouse, enterpriseCode, sectionCode, warehouseCode);

            if (warehouseCode != "")
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        warehouseName = warehouse.WarehouseName;
                    }

                    else
                    {
                        warehouseName = "削除済";
                    }
                }

                else
                {
                    warehouseName = "未登録";
                }
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 読み込み失敗
                return status;
            }

            return status;
        }


        /// <summary>
        /// クラスメンバーコピー処理（拠点情報ワーククラス⇒拠点情報クラス）
        /// </summary>
        /// <param name="secInfoSetWork">拠点情報ワーククラス</param>
        /// <returns>拠点情報クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報ワーククラスから拠点情報クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private SecPrintSet CopyToSecInfoSetFromSecInfoSetWork(SecInfoSetWork secInfoSetWork)
        {

            SecPrintSet secPrintSet = new SecPrintSet();

            secPrintSet.SectionCode = secInfoSetWork.SectionCode;
            secPrintSet.CompanyNameCd1 = secInfoSetWork.CompanyNameCd1;

            // 自社名称取得
            for (int ix = 0; ix < 1; ix++)
            {
                string companyName1 = null;
                string companyName2 = null;
                string postco = null;
                string address1 = null;
                string address3 = null;
                string address4 = null;
                string companyTelNo1 = null;
                string companyTelNo2 = null;
                string companyTelNo3 = null;
                string companySetNote1 = null;
                string companySetNote2 = null;
                GetCompanyName(out companyName1, out companyName2, out postco,
                               out address1, out address3, out address4,
                               out companyTelNo1, out companyTelNo2,out companyTelNo3,
                               out companySetNote1, out companySetNote2,
                               secInfoSetWork.EnterpriseCode, secPrintSet.GetCompanyNameCd(ix));
                secPrintSet.CompanyName1 = companyName1;
                secPrintSet.CompanyName2 = companyName2;
                secPrintSet.PostNo = postco;
                secPrintSet.Address1 = address1;
                secPrintSet.Address3 = address3;
                secPrintSet.Address4  = address4;
                secPrintSet.CompanyTelNo1 = companyTelNo1;
                secPrintSet.CompanyTelNo2 = companyTelNo2;
                secPrintSet.CompanyTelNo3 = companyTelNo3;
                secPrintSet.CompanySetNote1 = companySetNote1;
                secPrintSet.CompanySetNote2 = companySetNote2;

            }

            // 電話名称タイトル
            string companyTelTitle1 = null;
            string companyTelTitle2 = null;
            string companyTelTitle3 = null;
            GetCompanyInf(out companyTelTitle1, out companyTelTitle2, out companyTelTitle3, secInfoSetWork.EnterpriseCode);
            if (companyTelTitle1.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle1 = "電話１";
            }
            else
            {
                secPrintSet.CompanyTelTitle1 = companyTelTitle1;
            }
            if (companyTelTitle2.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle2 = "電話２";
            }
            else
            {
                secPrintSet.CompanyTelTitle2 = companyTelTitle2;
            }
            if (companyTelTitle3.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle3 = "ＦＡＸ";
            }
            else
            {
                secPrintSet.CompanyTelTitle3 = companyTelTitle3;
            }

            secPrintSet.SectionGuideNm = secInfoSetWork.SectionGuideNm;
            secPrintSet.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;

            // 郵便番号・住所・電話番号

            secPrintSet.SectWarehouseCd1 = secInfoSetWork.SectWarehouseCd1;
            secPrintSet.SectWarehouseCd2 = secInfoSetWork.SectWarehouseCd2;
            secPrintSet.SectWarehouseCd3 = secInfoSetWork.SectWarehouseCd3;

            //拠点倉庫名称取得
            for (int ix = 0; ix < 3; ix++)
            {
                string warehouse1 = null;
                GetWarehouseName(out warehouse1, secInfoSetWork.EnterpriseCode,
                    secInfoSetWork.SectionCode, secPrintSet.GetSectWarehouseCd(ix));
                secPrintSet.SetSectWarehouseNm(warehouse1, ix);
            }

            


            return secPrintSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="secInfoSetWork"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(SecInfoSetWork secInfoSetWork, SectionPrintWork sectionPrintWork)
        {
            int status = 0;

            if (secInfoSetWork.LogicalDeleteCode != sectionPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = secInfoSetWork.UpdateDateTime.Year.ToString("0000") +
                                secInfoSetWork.UpdateDateTime.Month.ToString("00") +
                                secInfoSetWork.UpdateDateTime.Day.ToString("00");

            if (sectionPrintWork.LogicalDeleteCode == 1 &&
                sectionPrintWork.DeleteDateTimeSt != 0 &&
                sectionPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < sectionPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > sectionPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (sectionPrintWork.LogicalDeleteCode == 1 &&
                        sectionPrintWork.DeleteDateTimeSt != 0 &&
                        sectionPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < sectionPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (sectionPrintWork.LogicalDeleteCode == 1 &&
                       sectionPrintWork.DeleteDateTimeSt == 0 &&
                       sectionPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > sectionPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!sectionPrintWork.SectionCodeSt.Trim().Equals(string.Empty) &&
                !sectionPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) < Int32.Parse(sectionPrintWork.SectionCodeSt) ||
                   Int32.Parse(secInfoSetWork.SectionCode) > Int32.Parse(sectionPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!sectionPrintWork.SectionCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) < Int32.Parse(sectionPrintWork.SectionCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!sectionPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) > Int32.Parse(sectionPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
