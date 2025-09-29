using System;
using System.Collections;
using System.Data;
using System.Reflection;
// 2008.02.08 96012 ローカルＤＢ参照対応 Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.08 96012 ローカルＤＢ参照対応 end

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
	/// 自社名称テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自社名称テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2005.09.09</br>
    /// -----------------------------------------------------------------------
    /// <br>Date       : 2007.05.17</br>
    /// <br>Programmer : 20031 古賀　小百合</br>
    /// <br>UpdateNote : 項目追加</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
    /// <br>           : ローカルＤＢ参照対応(拠点情報)</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/04 30414　忍　幸史</br>
    /// <br>           : 住所2削除</br>
    /// </remarks>
	public class CompanyNmAcs
	{
		// リモートオブジェクト格納バッファ
		private ICompanyNmDB	_iCompanyNmDB = null;
        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        private CompanyNmLcDB _companyNmLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

		// 拠点情報取得部品
		private SecInfoAcs      _secInfoAcs   = null;

        // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ローカルＤＢ参照対応 end

        /// <summary>
		/// 自社名称テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自社名称テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public CompanyNmAcs()
		{
            // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
            //this._secInfoAcs = new SecInfoAcs(1);
            // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end
            try
            {
				// リモートオブジェクト取得
				this._iCompanyNmDB = ( ICompanyNmDB )MediationCompanyNmDB.GetCompanyNmDB();
			}
			catch(Exception) {
				// オフライン時はnullをセット
				this._iCompanyNmDB = null;
			}
            // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._companyNmLcDB = new CompanyNmLcDB();
            // 2008.02.08 96012 ローカルＤＢ参照対応 end
        }

        // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
        /// <summary>
        /// ローカルＤＢ対応拠点情報クラス作成処理
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
        /// <br>Programmer : 96012 日色　馨</br>
        /// <br>Date       : 2008.02.12</br>
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
        // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end

        /// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// オンラインモードを取得します
			if( this._iCompanyNmDB == null ) {
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// 自社名称読込処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="companyNameCd">自社名称コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の読み込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public int Read( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;

			try {
				companyNm = null;

				// パラメータを設定
				CompanyNmWork companyNmWork		= new CompanyNmWork();
				companyNmWork.EnterpriseCode	= enterpriseCode;		// 企業コード
				companyNmWork.CompanyNameCd		= companyNameCd;		// 自社名称コード

                // 2008.02.08 96012 ローカルＤＢ参照対応 Begin
                //// XMLへ変換し、文字列のバイナリ化
				//byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );
                //
				//// 自社名称読み込み
				//status = this._iCompanyNmDB.Read( ref parabyte, 0 );
                //
				//if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				//	// 自社名称ワーククラスをデシリアライズ
				//	companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
				//	// 自社名称ワーククラスから自社名称クラスへメンバコピー
				//	companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );
				//}
                if (_isLocalDBRead)
                {
                    // 自社名称読み込み
                    status = this._companyNmLcDB.Read(ref companyNmWork, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 自社名称ワーククラスから自社名称クラスへメンバコピー
                        companyNm = CopyToCompanyNmFromCompanyNmWork(companyNmWork);
                    }
                }
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(companyNmWork);
                    // 自社名称読み込み
                    status = this._iCompanyNmDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 自社名称ワーククラスをデシリアライズ
                        companyNmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte, typeof(CompanyNmWork));
                        // 自社名称ワーククラスから自社名称クラスへメンバコピー
                        companyNm = CopyToCompanyNmFromCompanyNmWork(companyNmWork);
                    }
                }
                // 2008.02.08 96012 ローカルＤＢ参照対応 end
                return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				companyNm = null;
				this._iCompanyNmDB = null;

				// 通信エラーは-1を返す。
				return -1;
			}
		}

		/// <summary>
		/// 自社名称登録・更新処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の登録・更新を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Write( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				// 自社名称クラスを自社名称ワーククラスへメンバコピー
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );

				// XMLへ変換し、文字列のバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

                // 自社名称を保存
				status = this._iCompanyNmDB.Write( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// 自社名称ワーククラスをデシリアライズ
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// 自社名称ワーククラスから自社名称クラスへメンバコピー
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end
                    // 拠点情報取得部品スタティックデータリセット
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCompanyNmDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
		/// 自社名称論理削除処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の論理削除を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int LogicalDelete( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				#region 2006.09.12 R.AKIYAMA DEL
//				// 拠点設定をチェック
//				SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
//				ArrayList secInfoSetList = null;
//				status = secInfoSetAcs.SearchAll( out secInfoSetList, companyNm.EnterpriseCode );
//				// 作業で検索したレコードが存在するとき
//				if( status == 0 ) {
//					foreach( SecInfoSet secInfoSet in secInfoSetList ) {
//						for( int ix = 0; ix < 10; ix++ ) {
//							if( secInfoSet.GetCompanyNameCd( ix ) == companyNm.CompanyNameCd ) {
//								// 参照されている場合は以下の処理をキャンセル（-2を返す）
//								return -2;
//							}
//						}
//					}
//				}
				#endregion

				// 自社名称クラスを自社名称ワーククラスへメンバコピー
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML変換し、文字列をバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// 自社名称を論理削除
				status = this._iCompanyNmDB.LogicalDelete( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// 自社名称ワーククラスをデシリアライズ
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// 自社名称ワーククラスを自社名称クラスにメンバコピー
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end
                    // 拠点情報取得部品スタティックデータリセット
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCompanyNmDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
		/// 自社名称論理削除復活処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の論理削除復活を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Revival( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				// 自社名称クラスを自社名称ワーククラスへメンバコピー
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML変換し、文字列をバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// 自社名称を復活
				status = this._iCompanyNmDB.RevivalLogicalDelete( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// 自社名称ワーククラスをデシリアライズ
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// 自社名称ワーククラスを自社名称クラスにメンバコピー
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end
                    // 拠点情報取得部品スタティックデータリセット
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iCompanyNmDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
		/// 自社名称物理削除処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の物理削除を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete( CompanyNm companyNm )
		{
			int status = 0;
			try {
				// 自社名称クラスを自社名称ワーククラスへメンバコピー
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML変換し、文字列をバイナリ化
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// 自社名称物理削除
				status = this._iCompanyNmDB.Delete( parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ローカルＤＢ参照対応(拠点情報) end
                    // 拠点情報取得部品スタティックデータリセット
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// オフライン時はnullを設定
				this._iCompanyNmDB = null;

				// 通信エラーは-1を返す
				return -1;
			}
		}

		/// <summary>
		/// 自社名称検索処理(論理削除データ除く)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の検索処理を行います。論理削除データは抽出対象外です。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, 0 );
		}

		/// <summary>
		/// 自社名称検索処理(論理削除データ含む)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の検索処理を行います。論理削除データも抽出対象に含みます。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchAll( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01 );
		}

		/// <summary>
		/// 自社名称検索処理(メイン)
		/// </summary>
		/// <param name="retList">検索結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の検索処理を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int SearchProc( out ArrayList retList, string enterpriseCode, 
			ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;
			
			retList = new ArrayList();
			retList.Clear();

			CompanyNmWork companyNmWork		= new CompanyNmWork();
			companyNmWork.EnterpriseCode	= enterpriseCode;		// 企業コード

			ArrayList wkList = new ArrayList();
			wkList.Clear();

			object paraobj	= companyNmWork;
			object retobj	= null;

            // 2008.02.08 96012 ローカルＤＢ参照対応 end
            //// 自社名称全件検索
			//status = this._iCompanyNmDB.Search( out retobj, paraobj, 0, logicalMode );
            //
			//if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
			//	wkList = retobj as ArrayList;
			//	if( wkList != null ) {
			//		foreach( CompanyNmWork wkCompanyNmWork in wkList ) {
			//			retList.Add( CopyToCompanyNmFromCompanyNmWork( wkCompanyNmWork ) );
			//		}
			//	}
			//}
            if (_isLocalDBRead)
            {
                List<CompanyNmWork> workList = new List<CompanyNmWork>();
                // 自社名称全件検索
                status = this._companyNmLcDB.Search(out workList, companyNmWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNmWork wkCompanyNmWork in workList)
                    {
                        retList.Add(CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork));
                    }
                }
            }
            else
            {
                // 自社名称全件検索
                status = this._iCompanyNmDB.Search(out retobj, paraobj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkList = retobj as ArrayList;
                    if (wkList != null)
                    {
                        foreach (CompanyNmWork wkCompanyNmWork in wkList)
                        {
                            retList.Add(CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork));
                        }
                    }
                }
            }
            // 2008.02.08 96012 ローカルＤＢ参照対応 end

			return status;
		}

		/// <summary>
		/// クラスメンバコピー処理(自社名称ワーククラス→自社名称クラス)
		/// </summary>
		/// <param name="companyNmWork">自社名称ワーククラス</param>
		/// <returns>自社名称クラス</returns>
		/// <remarks>
		/// <br>Note       : 自社名称ワーククラスから自社名称クラスへメンバコピーを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private CompanyNm CopyToCompanyNmFromCompanyNmWork( CompanyNmWork companyNmWork )
		{
			CompanyNm companyNm = new CompanyNm();

			// 共通ヘッダ
			companyNm.CreateDateTime		= companyNmWork.CreateDateTime;
			companyNm.UpdateDateTime		= companyNmWork.UpdateDateTime;
			companyNm.EnterpriseCode		= companyNmWork.EnterpriseCode;
			companyNm.FileHeaderGuid		= companyNmWork.FileHeaderGuid;
			companyNm.UpdEmployeeCode		= companyNmWork.UpdEmployeeCode;
			companyNm.UpdAssemblyId1		= companyNmWork.UpdAssemblyId1;
			companyNm.UpdAssemblyId2		= companyNmWork.UpdAssemblyId2;
			companyNm.LogicalDeleteCode		= companyNmWork.LogicalDeleteCode;

			companyNm.CompanyNameCd			= companyNmWork.CompanyNameCd;				// 自社名称コード
			companyNm.CompanyPr				= companyNmWork.CompanyPr;					// 自社PR文
			companyNm.CompanyName1			= companyNmWork.CompanyName1;				// 自社名称1
			companyNm.CompanyName2			= companyNmWork.CompanyName2;				// 自社名称2
			companyNm.PostNo				= companyNmWork.PostNo;						// 郵便番号
			companyNm.Address1				= companyNmWork.Address1;					// 住所1（都道府県市区郡・町村・字）
            //companyNm.Address2				= companyNmWork.Address2;					// 住所2（丁目）  // DEL 2008/06/04
			companyNm.Address3				= companyNmWork.Address3;					// 住所3（番地）
			companyNm.Address4				= companyNmWork.Address4;					// 住所4（アパート名称）
			companyNm.CompanyTelNo1			= companyNmWork.CompanyTelNo1;				// 自社電話番号1
			companyNm.CompanyTelNo2			= companyNmWork.CompanyTelNo2;				// 自社電話番号2
			companyNm.CompanyTelNo3			= companyNmWork.CompanyTelNo3;				// 自社電話番号3
			companyNm.CompanyTelTitle1		= companyNmWork.CompanyTelTitle1;			// 自社電話番号タイトル1
			companyNm.CompanyTelTitle2		= companyNmWork.CompanyTelTitle2;			// 自社電話番号タイトル2
			companyNm.CompanyTelTitle3		= companyNmWork.CompanyTelTitle3;			// 自社電話番号タイトル3
			companyNm.TransferGuidance		= companyNmWork.TransferGuidance;			// 銀行振込案内文
			companyNm.AccountNoInfo1		= companyNmWork.AccountNoInfo1;				// 銀行口座1
			companyNm.AccountNoInfo2		= companyNmWork.AccountNoInfo2;				// 銀行口座2
			companyNm.AccountNoInfo3		= companyNmWork.AccountNoInfo3;				// 銀行口座3
			companyNm.CompanySetNote1		= companyNmWork.CompanySetNote1;			// 自社設定摘要1
			companyNm.CompanySetNote2		= companyNmWork.CompanySetNote2;			// 自社設定摘要2

            # region 2007.05.17  S.Koga  DEL
            ///////////////////////////////////////////////////////////////////// 2005.10.04 AKIYAMA ADD STA //
            //companyNm.TakeInImageGroupCd	= companyNmWork.TakeInImageGroupCd;			// 取込画像グループコード
            // 2005.10.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            # endregion

            // 2007.05.17  S.Koga  add ----------------------------------------
            companyNm.ImageInfoDiv = companyNmWork.ImageInfoDiv;
            companyNm.ImageInfoCode = companyNmWork.ImageInfoCode;
            // ----------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2006.01.13 NAKAMURA ADD END ADD STA //
			companyNm.CompanyUrl			= companyNmWork.CompanyUrl;			// 自社ＵＲＬ
// 2006.01.13 NAKAMURA ADD END /////////////////////////////////////////////////////////////////////

			companyNm.CompanyPrSentence2    = companyNmWork.CompanyPrSentence2;		//自社PR文２
			companyNm.ImageCommentForPrt1   = companyNmWork.ImageCommentForPrt1;	//画像印字用コメント１
			companyNm.ImageCommentForPrt2   = companyNmWork.ImageCommentForPrt2;	//画像印字用コメント２


			return companyNm;
		}

		/// <summary>
		/// クラスメンバコピー処理(自社名称クラス→自社名称ワーククラス)
		/// </summary>
		/// <param name="companyNm">自社名称クラス</param>
		/// <returns>自社名称ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : 自社名称クラスから自社名称ワーククラスへメンバコピーを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private CompanyNmWork CopyToCompanyNmWorkFromCompanyNm( CompanyNm companyNm )
		{
			CompanyNmWork companyNmWork = new CompanyNmWork();

			// 共通ヘッダ
			companyNmWork.CreateDateTime		= companyNm.CreateDateTime;
			companyNmWork.UpdateDateTime		= companyNm.UpdateDateTime;
			companyNmWork.EnterpriseCode		= companyNm.EnterpriseCode;
			companyNmWork.FileHeaderGuid		= companyNm.FileHeaderGuid;
			companyNmWork.UpdEmployeeCode		= companyNm.UpdEmployeeCode;
			companyNmWork.UpdAssemblyId1		= companyNm.UpdAssemblyId1.TrimEnd();
			companyNmWork.UpdAssemblyId2		= companyNm.UpdAssemblyId2.TrimEnd();
			companyNmWork.LogicalDeleteCode		= companyNm.LogicalDeleteCode;
			
			companyNmWork.CompanyNameCd			= companyNm.CompanyNameCd;				// 自社名称コード
			companyNmWork.CompanyPr				= companyNm.CompanyPr.TrimEnd();		// 自社PR文
			companyNmWork.CompanyName1			= companyNm.CompanyName1.TrimEnd();		// 自社名称1
			companyNmWork.CompanyName2			= companyNm.CompanyName2.TrimEnd();		// 自社名称2
			companyNmWork.PostNo				= companyNm.PostNo.TrimEnd();			// 郵便番号
			companyNmWork.Address1				= companyNm.Address1.TrimEnd();			// 住所1（都道府県市区郡・町村・字）
            //companyNmWork.Address2				= companyNm.Address2;					// 住所2（丁目）  // DEL 2008/06/04
			companyNmWork.Address3				= companyNm.Address3.TrimEnd();			// 住所3（番地）
			companyNmWork.Address4				= companyNm.Address4.TrimEnd();			// 住所4（アパート名称）
			companyNmWork.CompanyTelNo1			= companyNm.CompanyTelNo1.TrimEnd();	// 自社電話番号1
			companyNmWork.CompanyTelNo2			= companyNm.CompanyTelNo2.TrimEnd();	// 自社電話番号2
			companyNmWork.CompanyTelNo3			= companyNm.CompanyTelNo3.TrimEnd();	// 自社電話番号3
			companyNmWork.CompanyTelTitle1		= companyNm.CompanyTelTitle1.TrimEnd();	// 自社電話番号タイトル1
			companyNmWork.CompanyTelTitle2		= companyNm.CompanyTelTitle2.TrimEnd();	// 自社電話番号タイトル2
			companyNmWork.CompanyTelTitle3		= companyNm.CompanyTelTitle3.TrimEnd();	// 自社電話番号タイトル3
			companyNmWork.TransferGuidance		= companyNm.TransferGuidance.TrimEnd();	// 銀行振込案内文
			companyNmWork.AccountNoInfo1		= companyNm.AccountNoInfo1.TrimEnd();	// 銀行口座1
			companyNmWork.AccountNoInfo2		= companyNm.AccountNoInfo2.TrimEnd();	// 銀行口座2
			companyNmWork.AccountNoInfo3		= companyNm.AccountNoInfo3.TrimEnd();	// 銀行口座3
			companyNmWork.CompanySetNote1		= companyNm.CompanySetNote1.TrimEnd();	// 自社設定摘要1
			companyNmWork.CompanySetNote2		= companyNm.CompanySetNote2.TrimEnd();	// 自社設定摘要2

            # region 2007.05.17  S.Koga  DEL
            ///////////////////////////////////////////////////////////////////// 2005.10.04 AKIYAMA ADD STA //
			//companyNmWork.TakeInImageGroupCd	= companyNm.TakeInImageGroupCd;			// 取込画像グループコード
            // 2005.10.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            # endregion

            // 2007.05.17  S.Koga  add ----------------------------------------
            companyNmWork.ImageInfoDiv = companyNm.ImageInfoDiv;
            companyNmWork.ImageInfoCode = companyNm.ImageInfoCode;
            // ----------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2006.01.13 NAKAMURA ADD END ADD STA //
			companyNmWork.CompanyUrl			= companyNm.CompanyUrl.TrimEnd();			// 自社ＵＲＬ
// 2006.01.13 NAKAMURA ADD END /////////////////////////////////////////////////////////////////////
			companyNmWork.CompanyPrSentence2    = companyNm.CompanyPrSentence2.TrimEnd(); //自社PR文２
			companyNmWork.ImageCommentForPrt1   = companyNm.ImageCommentForPrt1.TrimEnd(); //画像印字用コメント１
			companyNmWork.ImageCommentForPrt2   = companyNm.ImageCommentForPrt2.TrimEnd(); //画像印字用コメント２




			return companyNmWork;
		}
	}
}
