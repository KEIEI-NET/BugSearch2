using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 全体項目表示名称設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 全体項目表示名称設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2006.08.28</br>
	/// </remarks>
	public class AlItmDspNmAcs
	{
		#region << Private Members

		/// <summary>リモートオブジェクト格納バッファ</summary>
		private IAlItmDspNmDB       _iAlItmDspNmDB       = null;

		/// <summary>全体項目表示名称設定スタティックオブジェクト</summary>
		private static AlItmDspNm   _alItmDspNmStaticBuf = null;

		#endregion

		#region << Constructor >>

		/// <summary>
		/// 全体項目表示名称設定テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public AlItmDspNmAcs()
		{
			try {
				// リモートオブジェクト取得
				this._iAlItmDspNmDB = MediationAlItmDspNmDB.GetAlItmDspNmDB();
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iAlItmDspNmDB = null;
			}
		}

		#endregion

		#region << GetOnlineMode >>

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードの取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if( this._iAlItmDspNmDB == null ) {
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

		#region << Read Methods >>

		/// <summary>
		/// 全体項目表示名称設定読み込み処理 (通常)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定の読み込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public int Read( out AlItmDspNm alItmDspNm, string enterpriseCode )
		{
			int status = 0;

			alItmDspNm = null;

			// オンラインの場合
			if( LoginInfoAcquisition.OnlineFlag == true ) {
				// リモートから取得
				status = this.ReadProc( out alItmDspNm, enterpriseCode );
			}
			// オフラインの場合
			else {
				status = this.ReadOfflineProc( out AlItmDspNmAcs._alItmDspNmStaticBuf, enterpriseCode );
			}

			return status;
		}

		/// <summary>
		/// 全体項目表示名称設定読み込み処理 (スタティックデータ取得)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : スタティックデータから全体項目表示名称設定の読み込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public int ReadStatic( out AlItmDspNm alItmDspNm, string enterpriseCode )
		{
			int status = 0;

			alItmDspNm = null;

			try {
				if( AlItmDspNmAcs._alItmDspNmStaticBuf == null ) {
					// オンラインの場合
					if( LoginInfoAcquisition.OnlineFlag == true ) {
						// リモートから取得
						status = this.ReadProc( out AlItmDspNmAcs._alItmDspNmStaticBuf, enterpriseCode );
					}
					// オフラインの場合
					else {
						status = this.ReadOfflineProc( out AlItmDspNmAcs._alItmDspNmStaticBuf, enterpriseCode );
					}

					switch( status ) {
						case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							break;
						}
						case ( int )ConstantManagement.DB_Status.ctDB_EOF:
						case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						{
							break;
						}
						default:
						{
							return status;
						}
					}
				}

				if( AlItmDspNmAcs._alItmDspNmStaticBuf != null ) {
					alItmDspNm = AlItmDspNmAcs._alItmDspNmStaticBuf.Clone();
				}
				else {
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// 全体項目表示名称設定読み込み処理 (メイン)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定の読み込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private int ReadProc( out AlItmDspNm alItmDspNm, string enterpriseCode )
		{
			int status = 0;

			try {
				alItmDspNm = null;

				// キー情報をセット
				AlItmDspNmWork alItmDspNmWork  = new AlItmDspNmWork();
				alItmDspNmWork.EnterpriseCode  = enterpriseCode;    // 企業コード
                // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 >>>>>>START
				//alItmDspNmWork.DspNameManageNo = 0;                 // 表示名称管理No (0固定)
                // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 <<<<<<END
				
				object paraobj = alItmDspNmWork;

				// 受託協定料金明細読み込み
				status = this._iAlItmDspNmDB.Read( ref paraobj, 0 );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				    alItmDspNmWork = paraobj as AlItmDspNmWork;

				    if( alItmDspNmWork != null ) {
				        // 結果をメンバコピー
				        alItmDspNm = this.CopyToAlItmDspNmFromAlItmDspNmWork( alItmDspNmWork );
				    }
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				alItmDspNm = null;
				this._iAlItmDspNmDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}


		/// <summary>
		/// 全体項目表示名称設定読み込み処理 (オフライン)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定の読み込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private int ReadOfflineProc( out AlItmDspNm alItmDspNm, string enterpriseCode )
		{
			int status = 0;

			alItmDspNm = null;

			try {
				status = this.LoadOfflineData( enterpriseCode );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( AlItmDspNmAcs._alItmDspNmStaticBuf != null ) {
						alItmDspNm = AlItmDspNmAcs._alItmDspNmStaticBuf.Clone();
					}
					else {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

		#endregion

		#region << Write Methods >>

		/// <summary>
		/// 書き込み処理
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定オブジェクトの書き込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public int Write( ref AlItmDspNm alItmDspNm )
		{
			return this.WriteProc( ref alItmDspNm );
		}		

		/// <summary>
		/// 書き込み処理 (メイン)
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定オブジェクト</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定オブジェクトの書き込みを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private int WriteProc( ref AlItmDspNm alItmDspNm )
		{
			int status = 0;

			try {
				AlItmDspNmWork alItmDspNmWork = this.CopyToAlItmDspNmWorkFromAlItmDspNm( alItmDspNm );

				// XMLシリアライズ
				byte[] parabyte = XmlByteSerializer.Serialize( alItmDspNmWork );

				// 受託協定料金明細書き込み
				status = this._iAlItmDspNmDB.Write( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// デシリアライズしてワーククラスを取得
					alItmDspNmWork = ( AlItmDspNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( AlItmDspNmWork ) );
					
					alItmDspNm = this.CopyToAlItmDspNmFromAlItmDspNmWork( alItmDspNmWork );
				}
			}
			catch( Exception ) {
				// オフライン時はnullをセット
				this._iAlItmDspNmDB = null;

				// 通信エラーは-1を返す
				status = -1;
			}

			return status;
		}

		#endregion

		#region << オフライン保存関連 >>

		/// <summary>
		/// オフラインデータの書き込み
		/// </summary>
		/// <param name="sender">object</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : static な領域に保持されたデータをローカルファイルに書き込みます。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public int WriteOfflineData( object sender )
		{
			int status = 0;
			string enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			try {
				// 保存用データ取得
				AlItmDspNm alItmDspNm = null;
				status = this.ReadStatic( out alItmDspNm, enterpriseCode );
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					AlItmDspNmWork alItmDspNmWork = this.CopyToAlItmDspNmWorkFromAlItmDspNm( alItmDspNm );

					// オフライン保存オブジェクト
					OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

					// キーを設定
					string[] keyList	= new string[ 2 ];
					keyList[ 0 ]		= enterpriseCode.TrimEnd();    // 企業コード
					keyList[ 1 ]		= "0";                         // 表示名称管理No (0固定)

					// オフラインデータを書き込み
					status = offlineDataSerializer.Serialize( "AlItmDspNmAcs", keyList, alItmDspNmWork );
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ローカルファイルデータロード処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ローカルファイルのデータをロードし、static な領域に格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private int LoadOfflineData( string enterpriseCode )
		{
			int status = 0;

			try {
				// オフライン保存オブジェクト
				OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

				// キーを設定
				string[] keyList	= new string[ 1 ];
				keyList[ 0 ]		= enterpriseCode.TrimEnd();    // 企業コード
				keyList[ 1 ]		= "0";                         // 表示名称管理No (0固定)

				// ローカルファイルから読込
				object retobj = offlineDataSerializer.DeSerialize( "AlItmDspNmAcs", keyList );

				AlItmDspNmWork alItmDspNmWork = retobj as AlItmDspNmWork;
				if( alItmDspNmWork != null ) {
					AlItmDspNmAcs._alItmDspNmStaticBuf = this.CopyToAlItmDspNmFromAlItmDspNmWork( alItmDspNmWork );
				}
				else {
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception ) {
				status = -1;
			}

			return status;
		}

		#endregion

		#region << 主連絡先名称取得 >>

		/// <summary>
		/// 主連絡先表示名称取得処理
		/// </summary>
		/// <param name="mainContactCode">主連絡先区分</param>
		/// <returns>主連絡先表示名称</returns>
		/// <remarks>
		/// <br>Note       : 主連絡先表示名称の取得を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public string GetMainContactDspName( int mainContactCode )
		{
			string mainContactDspName = "";

			AlItmDspNm alItmDspNm = null;
            //int status = this.ReadStatic(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
            int status = this.Read(out alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				switch( mainContactCode ) {
					// 自宅
					case 0:
					{
						mainContactDspName = alItmDspNm.HomeTelNoDspName;
						break;
					}
					// 勤務先
					case 1:
					{
						mainContactDspName = alItmDspNm.OfficeTelNoDspName;
						break;
					}
					// 携帯
					case 2:
					{
						mainContactDspName = alItmDspNm.MobileTelNoDspName;
						break;
					}
					// 自宅FAX
					case 3:
					{
						mainContactDspName = alItmDspNm.HomeFaxNoDspName;
						break;
					}
					// 勤務先FAX
					case 4:
					{
						mainContactDspName = alItmDspNm.OfficeFaxNoDspName;
						break;
					}
					// その他
					case 5:
					{
						mainContactDspName = alItmDspNm.OtherTelNoDspName;
						break;
					}
					default:
					{
						mainContactDspName = "";
						break;
					}
				}
			}

			return mainContactDspName;
		}

		#endregion

		#region << 追加情報表示名称取得 >>

		/// <summary>
		/// 追加情報表示名称取得処理
		/// </summary>
		/// <param name="addInfoCd">追加情報区分(1,2,3)</param>
		/// <returns>追加情報表示名称</returns>
		/// <remarks>
		/// <br>Note       : 追加情報表示名称を取得します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public string GetAddInfoDspName( int addInfoCd )
		{
			string addInfoDspName = "";

			AlItmDspNm alItmDspNm = null;
			int status = this.ReadStatic( out alItmDspNm, LoginInfoAcquisition.EnterpriseCode );
			if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				switch( addInfoCd ) {
					// 追加情報1
					case 1:
					{
						addInfoDspName = alItmDspNm.AddInfo1DspName;
						break;
					}
					// 追加情報2
					case 2:
					{
						addInfoDspName = alItmDspNm.AddInfo2DspName;
						break;
					}
					// 追加情報3
					case 3:
					{
						addInfoDspName = alItmDspNm.AddInfo3DspName;
						break;
					}
					default:
					{
						addInfoDspName = "";
						break;
					}
				}
			}

			return addInfoDspName;
		}

		#endregion

		#region << Class Member Copy Methods >>

		/// <summary>
		/// クラスメンバコピー処理（全体項目表示名称設定クラス→全体項目表示名称設定ワーククラス）
		/// </summary>
		/// <param name="alItmDspNm">全体項目表示名称設定クラス</param>
		/// <returns>全体項目表示名称設定ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定クラスから全体項目表示名称設定ワーククラスへメンバコピーを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private AlItmDspNmWork CopyToAlItmDspNmWorkFromAlItmDspNm( AlItmDspNm alItmDspNm )
		{
			AlItmDspNmWork alItmDspNmWork = new AlItmDspNmWork();

			alItmDspNmWork.CreateDateTime     = alItmDspNm.CreateDateTime;        //作成日時
			alItmDspNmWork.UpdateDateTime     = alItmDspNm.UpdateDateTime;        //更新日時
			alItmDspNmWork.EnterpriseCode     = alItmDspNm.EnterpriseCode;        //企業コード
			alItmDspNmWork.FileHeaderGuid     = alItmDspNm.FileHeaderGuid;        //GUID
			alItmDspNmWork.UpdEmployeeCode    = alItmDspNm.UpdEmployeeCode;       //更新従業員コード
			alItmDspNmWork.UpdAssemblyId1     = alItmDspNm.UpdAssemblyId1;        //更新アセンブリID1
			alItmDspNmWork.UpdAssemblyId2     = alItmDspNm.UpdAssemblyId2;        //更新アセンブリID2
			alItmDspNmWork.LogicalDeleteCode  = alItmDspNm.LogicalDeleteCode;     //論理削除区分

            // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 >>>>>>START
            //alItmDspNmWork.DspNameManageNo    = alItmDspNm.DspNameManageNo;       //表示名称管理No
            // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 <<<<<<END
			alItmDspNmWork.HomeTelNoDspName   = alItmDspNm.HomeTelNoDspName;      //自宅TEL表示名称
			alItmDspNmWork.OfficeTelNoDspName = alItmDspNm.OfficeTelNoDspName;    //勤務先TEL表示名称
			alItmDspNmWork.MobileTelNoDspName = alItmDspNm.MobileTelNoDspName;    //携帯TEL表示名称
			alItmDspNmWork.OtherTelNoDspName  = alItmDspNm.OtherTelNoDspName;     //その他TEL表示名称
			alItmDspNmWork.HomeFaxNoDspName   = alItmDspNm.HomeFaxNoDspName;      //自宅FAX表示名称
			alItmDspNmWork.OfficeFaxNoDspName = alItmDspNm.OfficeFaxNoDspName;    //勤務先FAX表示名称
			alItmDspNmWork.AddInfo1DspName    = alItmDspNm.AddInfo1DspName;       //追加情報1表示名称
			alItmDspNmWork.AddInfo2DspName    = alItmDspNm.AddInfo2DspName;       //追加情報2表示名称
			alItmDspNmWork.AddInfo3DspName    = alItmDspNm.AddInfo3DspName;       //追加情報3表示名称

            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            alItmDspNmWork.JoinDspName = alItmDspNm.JoinDspName;                    // 結合表示名称
            alItmDspNmWork.StockRateDspName = alItmDspNm.StockRateDspName;          // 仕入率表示名称
            alItmDspNmWork.UnitCostDspName = alItmDspNm.UnitCostDspName;            // 原単価表示名称
            alItmDspNmWork.ProfitDspName = alItmDspNm.ProfitDspName;                // 粗利額表示名称
            alItmDspNmWork.ProfitRateDspName = alItmDspNm.ProfitRateDspName;        // 粗利率表示名称
            alItmDspNmWork.OutTaxDspName = alItmDspNm.OutTaxDspName;                // 外税表示名称
            alItmDspNmWork.InTaxDspName = alItmDspNm.InTaxDspName;                  // 内税表示名称
            alItmDspNmWork.ListPriceDspName = alItmDspNm.ListPriceDspName;          // 定価表示名称
            alItmDspNmWork.DeliHonorTtlDef = alItmDspNm.DeliHonorTtlDef;            // 納品書敬称初期値
            alItmDspNmWork.BillHonorTtlDef = alItmDspNm.BillHonorTtlDef;            // 請求書敬称初期値
            alItmDspNmWork.EstmHonorTtlDef = alItmDspNm.EstmHonorTtlDef;            // 見積書敬称初期値
            alItmDspNmWork.RectHonorTtlDef = alItmDspNm.RectHonorTtlDef;            // 発注書敬称初期値
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END

			return alItmDspNmWork;
		}

		/// <summary>
		/// クラスメンバコピー処理（全体項目表示名称設定ワーククラス→全体項目表示名称設定クラス）
		/// </summary>
		/// <param name="alItmDspNmWork">全体項目表示名称設定ワーククラス</param>
		/// <returns>全体項目表示名称設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 全体項目表示名称設定ワーククラスから全体項目表示名称設定クラスへメンバコピーを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		private AlItmDspNm CopyToAlItmDspNmFromAlItmDspNmWork( AlItmDspNmWork alItmDspNmWork )
		{
			AlItmDspNm alItmDspNm = new AlItmDspNm();

			alItmDspNm.CreateDateTime     = alItmDspNmWork.CreateDateTime;        //作成日時
			alItmDspNm.UpdateDateTime     = alItmDspNmWork.UpdateDateTime;        //更新日時
			alItmDspNm.EnterpriseCode     = alItmDspNmWork.EnterpriseCode;        //企業コード
			alItmDspNm.FileHeaderGuid     = alItmDspNmWork.FileHeaderGuid;        //GUID
			alItmDspNm.UpdEmployeeCode    = alItmDspNmWork.UpdEmployeeCode;       //更新従業員コード
			alItmDspNm.UpdAssemblyId1     = alItmDspNmWork.UpdAssemblyId1;        //更新アセンブリID1
			alItmDspNm.UpdAssemblyId2     = alItmDspNmWork.UpdAssemblyId2;        //更新アセンブリID2
			alItmDspNm.LogicalDeleteCode  = alItmDspNmWork.LogicalDeleteCode;     //論理削除区分

            // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 >>>>>>START
            //alItmDspNm.DspNameManageNo    = alItmDspNmWork.DspNameManageNo;       //表示名称管理No
            // 2008.06.05 30413 犬飼 ビルドエラーのためコメント化 <<<<<<END
			alItmDspNm.HomeTelNoDspName   = alItmDspNmWork.HomeTelNoDspName;      //自宅TEL表示名称
			alItmDspNm.OfficeTelNoDspName = alItmDspNmWork.OfficeTelNoDspName;    //勤務先TEL表示名称
			alItmDspNm.MobileTelNoDspName = alItmDspNmWork.MobileTelNoDspName;    //携帯TEL表示名称
			alItmDspNm.OtherTelNoDspName  = alItmDspNmWork.OtherTelNoDspName;     //その他TEL表示名称
			alItmDspNm.HomeFaxNoDspName   = alItmDspNmWork.HomeFaxNoDspName;      //自宅FAX表示名称
			alItmDspNm.OfficeFaxNoDspName = alItmDspNmWork.OfficeFaxNoDspName;    //勤務先FAX表示名称
			alItmDspNm.AddInfo1DspName    = alItmDspNmWork.AddInfo1DspName;       //追加情報1表示名称
			alItmDspNm.AddInfo2DspName    = alItmDspNmWork.AddInfo2DspName;       //追加情報2表示名称
			alItmDspNm.AddInfo3DspName    = alItmDspNmWork.AddInfo3DspName;       //追加情報3表示名称

            // 2008.06.05 30413 犬飼 表示名称項目追加 >>>>>>START
            alItmDspNm.JoinDspName = alItmDspNmWork.JoinDspName;                    // 結合表示名称
            alItmDspNm.StockRateDspName = alItmDspNmWork.StockRateDspName;          // 仕入率表示名称
            alItmDspNm.UnitCostDspName = alItmDspNmWork.UnitCostDspName;            // 原単価表示名称
            alItmDspNm.ProfitDspName = alItmDspNmWork.ProfitDspName;                // 粗利額表示名称
            alItmDspNm.ProfitRateDspName = alItmDspNmWork.ProfitRateDspName;        // 粗利率表示名称
            alItmDspNm.OutTaxDspName = alItmDspNmWork.OutTaxDspName;                // 外税表示名称
            alItmDspNm.InTaxDspName = alItmDspNmWork.InTaxDspName;                  // 内税表示名称
            alItmDspNm.ListPriceDspName = alItmDspNmWork.ListPriceDspName;          // 定価表示名称
            alItmDspNm.DeliHonorTtlDef = alItmDspNmWork.DeliHonorTtlDef;            // 納品書敬称初期値
            alItmDspNm.BillHonorTtlDef = alItmDspNmWork.BillHonorTtlDef;            // 請求書敬称初期値
            alItmDspNm.EstmHonorTtlDef = alItmDspNmWork.EstmHonorTtlDef;            // 見積書敬称初期値
            alItmDspNm.RectHonorTtlDef = alItmDspNmWork.RectHonorTtlDef;            // 発注書敬称初期値
            // 2008.06.05 30413 犬飼 表示名称項目追加 <<<<<<END

			return alItmDspNm;
		}

		#endregion
	}
}
