using System;
using System.Collections;
// 2008.02.12 96012 ローカルＤＢ参照対応 Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.12 96012 ローカルＤＢ参照対応 end
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;     // 2006.09.05 TAKAHASHI ADD
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
// 2008.02.12 96012 ローカルＤＢ参照対応 Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.12 96012 ローカルＤＢ参照対応 end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 伝票印刷設定テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 伝票印刷設定テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 23006  高橋 明子</br>
	/// <br>Date       : 2005.08.31</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 高橋 明子</br>
	/// <br>				・仕様変更のため、項目追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.14  23006 高橋 明子</br>
	/// <br>				・仕様変更のため、項目追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.15  23006 高橋 明子</br>
	/// <br>				・仕様変更のため、項目追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.16  23006 高橋 明子</br>
	/// <br>				・仕様変更のため、項目追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.25  23006 高橋 明子</br>
	/// <br>				・鈑金オフライン対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.05  23006 高橋 明子</br>
	/// <br>				・親マスタ反映同期対応</br>
	/// <br></br>
	/// <br>Update Note : 2006.01.24  22024 寺坂 誉志</br>
	/// <br>				・ファイルレイアウト変更に伴う項目追加</br>
	/// <br>Update Note : 2006.01.30  23002 上野　耕平</br>
	/// <br>				・ファイルレイアウト変更に伴う項目追加</br>
	/// <br>Update Note : 2006.03.14  23010 中村　仁</br>
	/// <br>				・ファイルレイアウト変更に伴う項目追加</br>
    /// <br></br>
    /// <br>Update Note : 2006.04.25  22024 寺坂 誉志</br>
    /// <br>				・変更情報ローカル保存対応</br>
	/// <br></br>
	/// <br>Update Note : 2006.06.21  22024 寺坂 誉志</br>
	/// <br>				・導入オプションチェック処理を追加</br>
	/// <br></br>
    /// <br>Update Note : 2006.09.13  23006 高橋 明子</br>
    /// <br>			   ・XMLローカル保存対応</br>
	/// <br>Update Note : 2007.12.17  30167 上野　弘貴</br>
	/// <br>               ・DC.NS対応（ファイルレイアウト変更・ガイド追加）</br>
    /// <br>Update Note : 2008.02.05  96012　日色 馨</br>
    /// <br>               ・ローカルＤＢ参照対応</br>
    /// <br>Update Note : 2009.07.13 20056 對馬 大輔 LoginInfoAcquisition.OnlineFlagを参照して制御切替を行わない(常にOnline)</br>
    /// <br>Update Note : 2009/12/31  張凱</br>
    /// <br>              ・ PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>              ・ 伝票備考桁数、伝票備考２桁数、伝票備考３桁数を追加対応</br>
    /// <br>Update Note : 2010/08/06  caowj</br>
    /// <br>              ・ PM.NS1012</br>
    /// <br>              ・ 伝票印刷ﾊﾟﾀｰﾝ設定対応</br>
    /// <br>Update Note : 2011/02/16  鄧潘ハン</br>
    /// <br>             ・自社名称１，２が縦倍角になっていない不具合の対応</br>
    /// <br>Update Note : 2011/07/19  chenyd</br>
    /// <br>             ・回答区分追加の対応</br>
    /// </remarks>
	public class SlipPrtSetAcs : IGeneralGuideData
	{
		#region -- リモートオブジェクト格納バッファ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// リモートオブジェクト格納バッファ
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.08.30</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private ISlipPrtSetDB _iSlipPrtSetDB = null;

        // --ADD 2010/08/06--------------------------------------------------------------->>>>>
        private ICustSlipMngDB _iCustSlipMngDB = null;
        // --ADD 2010/08/06---------------------------------------------------------------<<<<<

		// プリンタ名取得用
		private PrtManage prtManage;
		private PrtManageAcs prtManageAcs;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		// Static格納用HashTable
		private static Hashtable _static_SlipPrtSetTable = null;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
        // オフラインデータ格納先パス
        private string _offlineDataDirPath = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END
        // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
        private SlipPrtSetLcDB _slipPrtSetLcDB = null;
        private static bool _isLocalDBRead = false;
        /// <summary>
        /// ローカルＤＢReadモード
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.12 96012 ローカルＤＢ参照対応 end
        #endregion

		//----- h.ueno add---------- start 2007.12.17
		#region Public Members
		// ガイド設定ファイル名
		private const string GUIDE_XML_FILENAME = "SLIPPRTSETGUIDEPARENT.XML";   // XMLファイル名
		
		// ガイドパラメータ
		private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";       // 企業コード
		
		// ガイド項目タイプ
		private const string GUIDE_TYPE_STR = "System.String";              // String型

		// ガイド項目名
		private const string GUIDE_DATAINPUTSYSTEM_TITLE		= "DataInputSystem";		// データ入力システム
		private const string GUIDE_DATAINPUTSYSTEMNAME_TITLE	= "DataInputSystemName";	// データ入力システム名
		private const string GUIDE_SLIPPRTKIND_TITLE			= "SlipPrtKind";			// 伝票印刷種別
		private const string GUIDE_SLIPPRTKINDNAME_TITLE		= "SlipPrtKindName";		// 伝票印刷種別名
		private const string GUIDE_SLIPPRTSETPAPERID_TITLE		= "SlipPrtSetPaperId";		// 伝票印刷設定用帳票ID
		private const string GUIDE_SLIPCOMMENT_TITLE			= "SlipComment";			// 伝票コメント
		
		#endregion
		//----- h.ueno add---------- end   2007.12.17

////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//		#region -- ＸＭＬファイル名 --
//		/*----------------------------------------------------------------------------------*/
//		/// <summary>
//		/// ＸＭＬファイル名
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : </br>
//		/// <br>Programmer : 23006  高橋 明子</br>
//		/// <br>Date       : 2005.08.30</br>
//		/// </remarks>
//		private string _fileNamePrtInfoSet;
//		#endregion
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////

		#region -- コンストラクタ --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		static SlipPrtSetAcs()
		{
			// Static格納用HashTable
			_static_SlipPrtSetTable = new Hashtable();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.08.30</br>
		/// <br></br>
		/// <br>Note       : オフライン対応</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// <br>UpdateNote : 2010.08.06 caowj</br>
        /// <br>           : PM.NS1012対応</br>
        /// </remarks>
        public SlipPrtSetAcs()
        {
////////////////////////////////////////////// 2006.01.24 TERASAKA DEL STA //
//			// ＸＭＬファイル名を設定
//			this._fileNamePrtInfoSet = "PrtInfoSet.xml";
// 2006.01.24 TERASAKA DEL END //////////////////////////////////////////////

            // プリンタ名取得用
            prtManage = new PrtManage();
            prtManageAcs = new PrtManageAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.09.13 TAKAHASHI ADD START
            // オフラインデータ格納先パス
            this._offlineDataDirPath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.09.13 TAKAHASHI ADD END

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// オンラインの場合
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // リモートオブジェクト取得
            //        this._iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();
            //    }
            //    catch (Exception)
            //    {
            //        // オフライン時はnullをセット
            //        this._iSlipPrtSetDB = null;
            //    }
            //}
            //else
            //// オフラインの場合
            //{
            //    // オフラインシリアライズデータ作成部品I/O
            //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            //    // HashTableのKey設定
            //    string[] keyList = new string[1];
            //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;

            //    // ローカルファイル読込み処理
            //    //object wkObj = offlineDataSerializer.DeSerialize("SlipPrtSetAcs", keyList);                             // 2006.09.13 TAKAHASHI DELETE
            //    object wkObj = offlineDataSerializer.DeSerialize("SlipPrtSetAcs", keyList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD

            //    ArrayList wkList = wkObj as ArrayList;

            //    // 伝票印刷設定ワーククラス（ArrayList）→UIクラス（Static）変換処理
            //    CopyToSlipPrtSetFromSlipPrtSetWork(wkList);
            //}

            try
            {
                // リモートオブジェクト取得
                this._iSlipPrtSetDB = (ISlipPrtSetDB)MediationSlipPrtSetDB.GetSlipPrtSetDB();
                // --ADD 2010/08/06--------------------------------------------------------------->>>>>
                this._iCustSlipMngDB = (ICustSlipMngDB)MediationCustSlipMngDB.GetCustSlipMngDB();
                // --ADD 2010/08/06---------------------------------------------------------------<<<<<
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iSlipPrtSetDB = null;
                // --ADD 2010/08/06--------------------------------------------------------------->>>>>
                this._iCustSlipMngDB = null;
                // --ADD 2010/08/06---------------------------------------------------------------<<<<<
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
            // ローカルDBアクセスオブジェクト取得
            this._slipPrtSetLcDB = new SlipPrtSetLcDB();
            // 2008.02.12 96012 ローカルＤＢ参照対応 end
        }
		#endregion

		#region -- オンラインモード 列挙型 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// オンラインモードの列挙型です。
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.08.30</br>
		/// </remarks>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}
		#endregion

		#region -- オンラインモード取得処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.30</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSlipPrtSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}
		#endregion

		#region -- 読み込み処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定読み込み処理
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定を読み込みます。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.30</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public int ReadSlipPrtSet(out SlipPrtSet slipPrtSet, string enterpriseCode, int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{			
			try
			{
				slipPrtSet = null;
				SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
				
				int status = 0;

				slipPrtSetWork.EnterpriseCode  = enterpriseCode;
				slipPrtSetWork.DataInputSystem = dataInputSystem;

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
				slipPrtSetWork.SlipPrtKind = slipPrtKind;
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
				slipPrtSetWork.SlipPrtSetPaperId = slipPrtSetPaperId;
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

                // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
                //// オンラインの場合
				//if (LoginInfoAcquisition.OnlineFlag)
				//{
				//	// 伝票印刷設定ワーククラス→ＸＭＬ（バイナリ）
				//	byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
                //
				//	// 読み込み処理
				//	status = this._iSlipPrtSetDB.Read(ref parabyte,0);
                //
				//	if (status == 0)
				//	{
				//		// 伝票印刷設定ワーククラス←ＸＭＬ（バイナリ）
				//		slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));
                ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
				//		if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
				//			(!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
				//			(!slipPrtSetWork.OptionCode.Trim().Equals("0")))
				//		{
				//			PurchaseStatus purchaseStatus
				//				= LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
				//			if (purchaseStatus < PurchaseStatus.Contract)
				//			{
				//				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				//			}
				//		}
                //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //
				//		// 伝票印刷設定データクラス←伝票印刷設定ワーククラス
				//		slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                //
				//		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
				//		// HashTableのKey
				//		string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
				//			+ "," + slipPrtSet.SlipPrtSetPaperId;
                //
				//		// スタティック領域に情報を保持
				//		_static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
				//		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
				//	}
				//}
				//// オフラインの場合
				//else
				//{
				//	status = ReadStaticMemory(out slipPrtSet, dataInputSystem, slipPrtKind, slipPrtSetPaperId);
				//}
                if (_isLocalDBRead)
                {
                    // 読み込み処理
                    status = this._slipPrtSetLcDB.Read(ref slipPrtSetWork, 0);
                    if (status == 0)
                    {
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                        //if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetWork.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //    {
                        //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        //    }
                        //}
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END
                        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                        // 伝票印刷設定データクラス←伝票印刷設定ワーククラス
                        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                        // HashTableのKey
                        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                            + "," + slipPrtSet.SlipPrtSetPaperId;
                        // スタティック領域に情報を保持
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    }
                }
                else
                {
                    // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //// オンラインの場合
                    //if (LoginInfoAcquisition.OnlineFlag)
                    //{
                    //    // 伝票印刷設定ワーククラス→ＸＭＬ（バイナリ）
                    //    byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);
                    
                    //    // 読み込み処理
                    //    status = this._iSlipPrtSetDB.Read(ref parabyte,0);
                    
                    //    if (status == 0)
                    //    {
                    //        // 伝票印刷設定ワーククラス←ＸＭＬ（バイナリ）
                    //        slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte,typeof(SlipPrtSetWork));
                    ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                    //        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                    //        //if ((!slipPrtSetWork.OptionCode.Trim().Equals(string.Empty)) &&
                    //        //    (!slipPrtSetWork.OptionCode.Trim().Equals(null)) &&
                    //        //    (!slipPrtSetWork.OptionCode.Trim().Equals("0")))
                    //        //{
                    //        //    PurchaseStatus purchaseStatus
                    //        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetWork.OptionCode);
                    //        //    if (purchaseStatus < PurchaseStatus.Contract)
                    //        //    {
                    //        //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    //        //    }
                    //        //}
                    //        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END                        
                    //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                    ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                    //        ReadSlipPrtSetFromXml(ref slipPrtSetWork);
                    //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                    
                    //        // 伝票印刷設定データクラス←伝票印刷設定ワーククラス
                    //        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                    
                    //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                    //        // HashTableのKey
                    //        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                    //            + "," + slipPrtSet.SlipPrtSetPaperId;
                    
                    //        // スタティック領域に情報を保持
                    //        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                    //    }
                    //}
                    //// オフラインの場合
                    //else
                    //{
                    //    status = ReadStaticMemory(out slipPrtSet, dataInputSystem, slipPrtKind, slipPrtSetPaperId);
                    //}

                    // 伝票印刷設定ワーククラス→ＸＭＬ（バイナリ）
                    byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

                    // 読み込み処理
                    status = this._iSlipPrtSetDB.Read(ref parabyte, 0);

                    if (status == 0)
                    {
                        // 伝票印刷設定ワーククラス←ＸＭＬ（バイナリ）
                        slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
                        ReadSlipPrtSetFromXml(ref slipPrtSetWork);

                        // 伝票印刷設定データクラス←伝票印刷設定ワーククラス
                        slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);

                        string keysOfHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
                            + "," + slipPrtSet.SlipPrtSetPaperId;

                        // スタティック領域に情報を保持
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSet;
                    }
                    // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // 2008.02.12 96012 ローカルＤＢ参照対応 end

				return status;
			}
			catch (Exception)
			{				
				slipPrtSet = null;

				// オフライン時はnullをセット
				this._iSlipPrtSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static領域保持処理（オフライン対応）
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <param name="dataInputSystem"></param>
		/// <param name="slipPrtKind"></param>
		/// <param name="slipPrtSetPaperId"></param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 取得した値をStatic領域に保持します。（オフライン対応）</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out SlipPrtSet slipPrtSet, int dataInputSystem, int slipPrtKind, string slipPrtSetPaperId)
		{
			slipPrtSet = new SlipPrtSet();

			// HashTableのKey
			string keysOfHashTable = dataInputSystem.ToString() + "," + slipPrtKind.ToString() + "," + slipPrtSetPaperId;

			if (_static_SlipPrtSetTable == null)
			{
				return -1;
			}

			// Staticからデータを検索する
			if (_static_SlipPrtSetTable[keysOfHashTable] == null)
			{
				return 4;
			}
			else
			{
////////////////////////////////////////////// 2006.06.21 TERASAKA DEL STA //
//				slipPrtSet = (SlipPrtSet)_static_SlipPrtSetTable[keysOfHashTable];
// 2006.06.21 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
				SlipPrtSet slipPrtSetTemp = (SlipPrtSet)_static_SlipPrtSetTable[keysOfHashTable];
                // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                //{
                //    PurchaseStatus purchaseStatus
                //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                //    if (purchaseStatus < PurchaseStatus.Contract)
                //    {
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }
                //}
                // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END                        
// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
				SlipPrtSetWork slipPrtSetWorkTemp = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSetTemp);
				if (ReadSlipPrtSetFromXml(ref slipPrtSetWorkTemp) == 0)
				{
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
				}
				else
				{
					slipPrtSet = slipPrtSetTemp;
				}
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
			}
			
			return 0;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Static領域全件取得処理（オフライン対応）
		/// </summary>
		/// <param name="retList">クラスList</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <remarks>
		/// <br>Note       : Static領域のデータ全件を取得します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			string keyObHashTable = null;

			if (_static_SlipPrtSetTable == null)
			{
				return -1;
			}
			else if (_static_SlipPrtSetTable.Count == 0)
			{
				return 9;
			}

			foreach (SlipPrtSet slipPrtSet in _static_SlipPrtSetTable.Values)
			{
				keyObHashTable = slipPrtSet.DataInputSystem.ToString() + "," + slipPrtSet.SlipPrtKind.ToString()
					+ "," + slipPrtSet.SlipPrtSetPaperId;
				sortedList.Add(keyObHashTable, slipPrtSet);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}
		#endregion

		#region -- デシリアライズ処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定クラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定クラスをデシリアライズします。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public SlipPrtSet SlipPrtSetDeserialize(string fileName)
		{
			SlipPrtSet slipPrtSet = null;

			// ファイル名を渡して伝票印刷設定ワーククラスをデシリアライズする
			SlipPrtSetWork slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(fileName,typeof(SlipPrtSetWork));

			// デシリアライズ結果を伝票印刷設定クラスへコピー
			if (slipPrtSetWork != null) slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);

			return slipPrtSet;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定Listクラスデシリアライズ処理
		/// </summary>
		/// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
		/// <returns>伝票印刷設定クラスLIST</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定リストクラスをデシリアライズします。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public ArrayList SlipPrtSetListDeserialize(string fileName)
		{
			ArrayList slipPrtSetList = new ArrayList();
			slipPrtSetList.Clear();

			// ファイル名を渡して伝票印刷設定クラスをデシリアライズする
			SlipPrtSetWork[] slipPrtSetWorks = (SlipPrtSetWork[])XmlByteSerializer.Deserialize(fileName, typeof(SlipPrtSetWork[]));

			// デシリアライズ結果を伝票印刷設定クラスへコピー
			foreach (SlipPrtSetWork slipPrtSetWork in slipPrtSetWorks)
			{
				slipPrtSetList.Add(CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork));
			}

			return slipPrtSetList;
		}
		#endregion

		#region -- 登録･更新処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定登録・更新処理
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報の登録・更新を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int WriteSlipPrtSet(ref SlipPrtSet slipPrtSet)
		{
            // 伝票印刷設定データクラス→伝票印刷設定ワーク
            SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

            // 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
            byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

            int status = 0;

            try
            {
                // 書き込み処理
                status = this._iSlipPrtSetDB.Write(ref parabyte);
                // 2008.06.10 30413 犬飼 書き込み処理完了後の後処理をコメント化 >>>>>>START
                //if ( status == 0 )
                //{
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //    ArrayList retList;
                //    if ( SearchSlipPrtSetFromXml(out retList, LoginInfoAcquisition.EnterpriseCode) == 0 )
                //    {                        
                //        retList = DBAndXMLDataMergeParts.MergeSlipPrtSetForWriteToXml(slipPrtSetWork, retList);
                //    }
                //    else
                //    {
                //        retList = new ArrayList();
                //        retList.Add(slipPrtSetWork);
                //    }
                //    
			    //    // 書き込み処理
                //    OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
                //    string[] keyList = new string[1];
                //    keyList[0] = LoginInfoAcquisition.EnterpriseCode;
                //    
                    //status = offlineDataSerializer.Serialize("SlipPrtSetAcs_1", keyList, retList);                             // 2006.09.13 TAKAHASHI DELETE
                //    status = offlineDataSerializer.Serialize("SlipPrtSetAcs_1", keyList, retList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //    // 伝票印刷設定ワーク←ＸＭＬ
                //    slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
                //    // 伝票印刷設定データクラス←伝票印刷設定ワーク
                //    slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
                //}
                // 2008.06.10 30413 犬飼 書き込み処理完了後の後処理をコメント化 <<<<<<END
            }
            catch ( Exception )
            {
                // オフライン時はnullをセット
                this._iSlipPrtSetDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定登録・更新処理（オフライン対応）
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報の登録・更新を行います。（オフライン対応）</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 0;

			if (_static_SlipPrtSetTable.Count != 0)
			{
				// HashTableのKey
				string [] keyList = new string[1];
				keyList[0] = LoginInfoAcquisition.EnterpriseCode;

				SortedList sortedList = new SortedList();
				SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

				ArrayList slipPrtSetList = new ArrayList();

				foreach (SlipPrtSet slipPrtSet in _static_SlipPrtSetTable.Values)
				{
					slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);
					slipPrtSetList.Add(slipPrtSetWork);
				}

				// 伝票印刷設定ワーク→（バイナリ）
                //status = offlineDataSerializer.Serialize("SlipPrtSetAcs", keyList, slipPrtSetList);                             // 2006.09.13 TAKAHASHI DELETE
                status = offlineDataSerializer.Serialize("SlipPrtSetAcs", keyList, slipPrtSetList, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD
			}

			return status;
		}
		#endregion

//----- h.ueno add---------- start 2007.12.17

		/// <summary>
		/// 伝票印刷設定削除処理
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報の論理削除を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int LogicalDelete(ref SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// 伝票印刷設定データクラス→伝票印刷設定ワーク
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// 論理削除
				status = this._iSlipPrtSetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// 伝票印刷設定ワーク←ＸＭＬ
					slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));
					
					// 伝票印刷設定データクラス←伝票印刷設定ワーク
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSlipPrtSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 伝票印刷設定物理削除処理
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報の物理削除を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int Delete(SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// 伝票印刷設定データクラス→伝票印刷設定ワーク
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// 物理削除
				status = this._iSlipPrtSetDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSlipPrtSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}

		/// <summary>
		/// 伝票印刷設定論理削除復活処理
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報の復活を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int Revival(ref SlipPrtSet slipPrtSet)
		{
			try
			{
				int status = 0;

				// 伝票印刷設定データクラス→伝票印刷設定ワーク
				SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

				// 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
				byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

				// 復活処理
				status = this._iSlipPrtSetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// 伝票印刷設定ワーク←ＸＭＬ
					slipPrtSetWork = (SlipPrtSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SlipPrtSetWork));

					// 伝票印刷設定データクラス←伝票印刷設定ワーク
					slipPrtSet = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iSlipPrtSetDB = null;
				// 通信エラーは-1を戻す
				return -1;
			}
		}
		
//----- h.ueno add---------- end   2007.12.17

		#region -- シリアライズ処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定シリアライズ処理
		/// </summary>
		/// <param name="slipPrtSet">シリアライズ対象伝票印刷設定クラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定情報のシリアライズを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public void SlipPrtSetSerialize(SlipPrtSet slipPrtSet,string fileName)
		{
			// 伝票印刷設定ワーク←伝票印刷設定データクラス
			SlipPrtSetWork slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(slipPrtSet);

			// 伝票印刷設定ワーククラスをシリアライズ
			XmlByteSerializer.Serialize(slipPrtSetWork,fileName);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定Listシリアライズ処理
		/// </summary>
		/// <param name="slipPrtSetList">シリアライズ対象伝票印刷設定Listクラス</param>
		/// <param name="fileName">シリアライズファイル名</param>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定List情報のシリアライズを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public void SlipPrtSetListSerialize(ArrayList slipPrtSetList, string fileName)
		{
			// ArrayListから配列を生成
			SlipPrtSet[] slipPrtSets = (SlipPrtSet[])slipPrtSetList.ToArray(typeof(SlipPrtSet));

			// 伝票印刷設定クラスをシリアライズ
			XmlByteSerializer.Serialize(slipPrtSets,fileName);
		}
		#endregion

		#region -- 検索処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定の全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSlipPrtSet(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;

			// 伝票印刷設定検索処理
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchAllSlipPrtSet(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;

			// 伝票印刷設定検索処理
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定伝票印刷設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevSlipPrtSetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevSlipPrtSet">前回最終担当者データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して伝票印刷設定の検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSpecificationSlipPrtSet(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,SlipPrtSet prevSlipPrtSet)
		{			
			// 伝票印刷設定検索処理
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevSlipPrtSet);			
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 件数指定伝票印刷設定検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevSlipPrtSetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="readCnt">読込件数</param>		
		/// <param name="prevSlipPrtSet">前回最終伝票印刷設定データオブジェクト（初回はnull指定必須）</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 件数を指定して伝票印刷設定の検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public int SearchSpecificationAllSlipPrtSet(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,SlipPrtSet prevSlipPrtSet)
		{			
			// 伝票印刷設定検索処理
			return SearchSlipPrtSetProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,readCnt,prevSlipPrtSet);	
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevSlipPrtSetがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
		/// <param name="prevSlipPrtSet">前回最終伝票印刷設定データオブジェクト（初回はnull指定必須）</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定の検索処理を行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		private int SearchSlipPrtSetProc(
			out ArrayList retList,
			out int retTotalCnt,
			out bool nextData,
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			int readCnt,
			SlipPrtSet prevSlipPrtSet)
		{
			int status = 0;
			
			// 伝票印刷設定クラス⇒伝票印刷設定ワーククラス
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

			if (prevSlipPrtSet != null) 
			{
				slipPrtSetWork = CopyToSlipPrtSetWorkFromSlipPrtSet(prevSlipPrtSet);
			}

			slipPrtSetWork.EnterpriseCode = enterpriseCode;
			
			// 検索結果リストを初期化
			retList = new ArrayList();
			retList.Clear();

			// 読込対象データ総件数0で初期化
			retTotalCnt = 0;

			nextData = false;

			// サーチ用リスト初期化
			ArrayList paraList = new ArrayList();
			paraList.Clear();
			
			// 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
			object paraobj = slipPrtSetWork;
			object retobj = null;

            // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
            //// オフラインの場合
			//if (!LoginInfoAcquisition.OnlineFlag)
			//{
			//	status = SearchStaticMemory(out retList);
            //
			//}
			//// オンラインの場合
			//else
			//{
			//	// 検索処理
			//	status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0,logicalMode);
            //
			//	if (status == 0)
			//	{
			//		ArrayList slipPrtSetWorkList = new ArrayList();
			//		slipPrtSetWorkList = retobj as ArrayList;
            //
            //////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
            //        ArrayList xmlList;
            //        if ( SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0 )
            //        {
            //            slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
            //        }
            //// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
			//		foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
			//		{
			//			SlipPrtSet slipPrtSetTemp = new SlipPrtSet();
            //
			//			// 伝票印刷設定←伝票印刷設定ワーク
			//			slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
            //////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
			//			if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
			//				(!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
			//				(!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
			//			{
			//				PurchaseStatus purchaseStatus
			//					= LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
			//				if (purchaseStatus < PurchaseStatus.Contract)
			//					continue;
			//			}
            //// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
            //
			//			// 読込結果コレクションへ追加
			//			retList.Add(slipPrtSetTemp);
            //
			//			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
			//			// HashTableのKey
			//			string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
			//				+ "," + slipPrtSetTemp.SlipPrtSetPaperId;
            //
			//			// スタティック領域に情報を保持
			//			_static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
			//			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
			//		}
			//	}
			//}
            if (_isLocalDBRead)
            {
                // 検索処理
                List<SlipPrtSetWork> workList = new List<SlipPrtSetWork>();
                status = this._slipPrtSetLcDB.Search(out workList, slipPrtSetWork, 0, logicalMode);
                if (status == 0)
                {
                    ArrayList slipPrtSetWorkList = new ArrayList();
                    slipPrtSetWorkList.AddRange(workList);

                    ArrayList xmlList;
                    if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                    }
                    foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                    {
                        SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                        // 伝票印刷設定←伝票印刷設定ワーク
                        slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END
                        // 読込結果コレクションへ追加
                        retList.Add(slipPrtSetTemp);
                        // HashTableのKey
                        string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                            + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                        // スタティック領域に情報を保持
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                    }
                }
            }
            else
            {
                // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// オフラインの場合
                //if (!LoginInfoAcquisition.OnlineFlag)
                //{
                //    status = SearchStaticMemory(out retList);

                //}
                //// オンラインの場合
                //else
                //{
                //    // 検索処理
                //    status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, logicalMode);

                //    if (status == 0)
                //    {
                //        ArrayList slipPrtSetWorkList = new ArrayList();
                //        slipPrtSetWorkList = retobj as ArrayList;

                //        ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                //        ArrayList xmlList;
                //        if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                //        {
                //            // 2008.06.06 30413 犬飼 プリンタ管理No削除による取得メソッド変更 >>>>>>START
                //            // SFCMN00721Bのメソッドではエラーになるため、代わりのメソッドを実行するように修正
                //            //slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                //            slipPrtSetWorkList = MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                //            // 2008.06.06 30413 犬飼 プリンタ管理No削除による取得メソッド変更 <<<<<<END
                            
                //        }
                //        // 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                //        foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                //        {
                //            SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                //            // 伝票印刷設定←伝票印刷設定ワーク
                //            slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                //            ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                //            // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                //            //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                //            //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                //            //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                //            //{
                //            //    PurchaseStatus purchaseStatus
                //            //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                //            //    if (purchaseStatus < PurchaseStatus.Contract)
                //            //        continue;
                //            //}
                //            // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END
                //            // 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////

                //            // 読込結果コレクションへ追加
                //            retList.Add(slipPrtSetTemp);

                //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                //            // HashTableのKey
                //            string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                //                + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                //            // スタティック領域に情報を保持
                //            _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                //        }
                //    }
                //}

                // 検索処理
                status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, logicalMode);

                if (status == 0)
                {
                    ArrayList slipPrtSetWorkList = new ArrayList();
                    slipPrtSetWorkList = retobj as ArrayList;

                    ////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
                    ArrayList xmlList;
                    if (SearchSlipPrtSetFromXml(out xmlList, LoginInfoAcquisition.EnterpriseCode) == 0)
                    {
                        // 2008.06.06 30413 犬飼 プリンタ管理No削除による取得メソッド変更 >>>>>>START
                        // SFCMN00721Bのメソッドではエラーになるため、代わりのメソッドを実行するように修正
                        //slipPrtSetWorkList = DBAndXMLDataMergeParts.MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                        slipPrtSetWorkList = MergeSlipPrtSet(slipPrtSetWorkList, xmlList);
                        // 2008.06.06 30413 犬飼 プリンタ管理No削除による取得メソッド変更 <<<<<<END

                    }
                    // 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
                    foreach (SlipPrtSetWork slipPrtSetWorkTemp in slipPrtSetWorkList)
                    {
                        SlipPrtSet slipPrtSetTemp = new SlipPrtSet();

                        // 伝票印刷設定←伝票印刷設定ワーク
                        slipPrtSetTemp = CopyToSlipPrtSetFromSlipPrtSetWork(slipPrtSetWorkTemp);
                        ////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END
                        // 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////

                        // 読込結果コレクションへ追加
                        retList.Add(slipPrtSetTemp);

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.25 TAKAHASHI ADD START
                        // HashTableのKey
                        string keysOfHashTable = slipPrtSetTemp.DataInputSystem.ToString() + "," + slipPrtSetTemp.SlipPrtKind.ToString()
                            + "," + slipPrtSetTemp.SlipPrtSetPaperId;

                        // スタティック領域に情報を保持
                        _static_SlipPrtSetTable[keysOfHashTable] = slipPrtSetTemp;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.25 TAKAHASHI ADD END
                    }
                }
                // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // 2008.02.12 96012 ローカルＤＢ参照対応 end
			
			// 全件リードの場合は戻り値の件数をセット
			if (readCnt == 0)
			{
				retTotalCnt = retList.Count;
			}
				
			return status;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// 伝票印刷設定検索処理（DataSet用）
		/// </summary>
		/// <param name="ds">取得結果格納用DataSet</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定の検索処理を行い、取得結果をDataSetで返します。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012　日色 馨</br>
        /// <br>           : ローカルＤＢ参照対応</br>
        /// </remarks>
		public int SearchSlipPrtSetDS(ref DataSet ds,string enterpriseCode)
		{
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
			slipPrtSetWork.EnterpriseCode = enterpriseCode;

			// 伝票印刷設定ワーク→ＸＭＬ（バイナリ）
			object paraobj = slipPrtSetWork;
			object retobj = null;

            // 2008.02.12 96012 ローカルＤＢ参照対応 Begin
            //// 検索処理
			//int status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0,0);
            //
			//if (status == 0) XmlByteSerializer.ReadXml(ref ds, (byte[])retobj);
			//
            int status;
            if (_isLocalDBRead)
            {
                // 検索処理
                List<SlipPrtSetWork> workList = new List<SlipPrtSetWork>();
                status = this._slipPrtSetLcDB.Search(out workList, slipPrtSetWork, 0, 0);
                if (status == 0)
                {
                    byte[] bytes = XmlByteSerializer.Serialize(workList);
                    XmlByteSerializer.ReadXml(ref ds, bytes);
                }
            }
            else
            {
                // 検索処理
                status = this._iSlipPrtSetDB.Search(out retobj, paraobj, 0, 0);

                if (status == 0) XmlByteSerializer.ReadXml(ref ds, (byte[])retobj);
            }
            // 2008.02.12 96012 ローカルＤＢ参照対応 end
				
			return status;
		}
////////////////////////////////////////////// 2006.04.25 TERASAKA ADD STA //
        /// <summary>
        /// 伝票印刷設定検索処理
        /// </summary>
		/// <param name="retList">取得結果格納用</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : XMLより伝票印刷設定マスタの検索処理を行い、取得結果をArrayListで返します。</br>
        /// <br>Programmer : 22024　寺坂 誉志</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        public int SearchSlipPrtSetFromXml(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;
            string[] keyArray = new string[1] { enterpriseCode };
            retList = new ArrayList();
            ArrayList readList;

            OfflineDataSerializer serializer = new OfflineDataSerializer();
            try
            {
                //readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray);                              // 2006.09.13 TAKAHASHI DELETE
                readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray, this._offlineDataDirPath);      // 2006.09.13 TAKAHASHI ADD

                if ( readList != null )
                {
                    foreach ( SlipPrtSetWork slipPrtSetTemp in readList )
                    {
////////////////////////////////////////////// 2006.06.21 TERASAKA ADD STA //
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 >>>>>>START
                        //if ((!slipPrtSetTemp.OptionCode.Trim().Equals(string.Empty)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals(null)) &&
                        //    (!slipPrtSetTemp.OptionCode.Trim().Equals("0")))
                        //{
                        //    PurchaseStatus purchaseStatus
                        //        = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(slipPrtSetTemp.OptionCode);
                        //    if (purchaseStatus < PurchaseStatus.Contract)
                        //        continue;
                        //}
                        // 2008.09.24 30413 犬飼 マスタ抽出時にチェックしているので不要 <<<<<<END                        
// 2006.06.21 TERASAKA ADD END //////////////////////////////////////////////
                        retList.Add(slipPrtSetTemp);
                    }
                }
                else
                {
                    status = 4;
                }
            }
            catch ( Exception )
            {
                // 通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }

        // --ADD 2010/08/06--------------------------------------------------------------->>>>>
        /// <summary>
        /// 得意先（伝票管理）読み込み処理
        /// </summary>
        /// <param name="custSlipMngWork">得意先（伝票管理）ワークオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先（伝票管理）ワークを読み込み、ステータスを返します。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int SearchCustSlipMng(ref CustSlipMngWork custSlipMngWork)
        {
            object outObj = custSlipMngWork as object;
            object obj = custSlipMngWork as object;

            int status = this._iCustSlipMngDB.Search(out outObj, obj, 0, ConstantManagement.LogicalMode.GetData01);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList custSlipMngWorkList = new ArrayList();
                custSlipMngWorkList = outObj as ArrayList;
                for (int i = 0; i < custSlipMngWorkList.Count; i++)
                {
                    custSlipMngWork = custSlipMngWorkList[i] as CustSlipMngWork;
                }
            }

            return status;
        }

        /// <summary>
        /// 伝票設定パターンマスタ 読み込み処理
        /// </summary>
        /// <param name="slipPrtSetWork">伝票設定パターンマスタ ワークオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票設定パターンマスタ 読み込み、ステータスを返します。</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int SearchSlipPrtSet(SlipPrtSetWork slipPrtSetWork)
        {
            // 伝票印刷設定ワーククラス→ＸＭＬ（バイナリ）
            byte[] parabyte = XmlByteSerializer.Serialize(slipPrtSetWork);

            // 読み込み処理
            int status = this._iSlipPrtSetDB.Read(ref parabyte, 0);

            return status;
        }

        /// <summary>
        /// 得意先（伝票管理）物理削除処理
        /// </summary>
        /// <param name="custSlipMngWork">得意先（伝票管理）ワークオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先（伝票管理）物理削除処理</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date       : 2010/08/06</br>
        /// </remarks>
        public int DeleteCustSlipMng(CustSlipMngWork custSlipMngWork)
        {
            // 得意先（伝票管理）ワーククラス→ＸＭＬ（バイナリ）
            byte[] parabyte = XmlByteSerializer.Serialize(custSlipMngWork);

            // 物理削除処理
            int status = this._iCustSlipMngDB.Delete(parabyte);

            return status;
        }
        // --ADD 2010/08/06---------------------------------------------------------------<<<<<

        /// <summary>
        /// 伝票印刷設定読み込み処理
        /// </summary>
		/// <param name="slipPrtSetWork">伝票印刷設定ワークオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : XMLより伝票印刷設定を読み込み、引数と同じキーのレコードがあった場合はマージします。</br>
        /// <br>Programmer : 22024　寺坂 誉志</br>
        /// <br>Date       : 2006.04.25</br>
        /// </remarks>
        private int ReadSlipPrtSetFromXml(ref SlipPrtSetWork slipPrtSetWork)
        {
            int status = 0;
            bool isExistRecord = false;
            string[] keyArray = new string[1] { LoginInfoAcquisition.EnterpriseCode };
            ArrayList readList;

            OfflineDataSerializer serializer = new OfflineDataSerializer();
            try
            {
                //readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray);                             // 2006.09.13 TAKAHASHI DELETE
                readList = (ArrayList)serializer.DeSerialize("SlipPrtSetAcs_1", keyArray, this._offlineDataDirPath);     // 2006.09.13 TAKAHASHI ADD

                if ( readList != null )
                {
                    foreach ( SlipPrtSetWork slipPrtSetTemp in readList )
                    {
                        // キーが一致するデータがある場合XMLデータを優先する
                        if ( ( slipPrtSetWork.EnterpriseCode.Equals(slipPrtSetTemp.EnterpriseCode) ) &&
                            ( slipPrtSetWork.DataInputSystem.Equals(slipPrtSetTemp.DataInputSystem) ) &&
                            ( slipPrtSetWork.SlipPrtKind.Equals(slipPrtSetTemp.SlipPrtKind) ) &&
                            ( slipPrtSetWork.SlipPrtSetPaperId.Equals(slipPrtSetTemp.SlipPrtSetPaperId) ) )
                        {
                            slipPrtSetWork.TopMargin = slipPrtSetTemp.TopMargin;
                            slipPrtSetWork.BottomMargin = slipPrtSetTemp.BottomMargin;
                            slipPrtSetWork.LeftMargin = slipPrtSetTemp.LeftMargin;
                            slipPrtSetWork.RightMargin = slipPrtSetTemp.RightMargin;
                            // 2008.06.05 30413 犬飼 プリンタ管理No削除 >>>>>>START
                            //slipPrtSetWork.PrinterMngNo = slipPrtSetTemp.PrinterMngNo;
                            // 2008.06.05 30413 犬飼 プリンタ管理No削除 <<<<<<END
                            isExistRecord = true;
                        }
                    }
                    if ( !isExistRecord )
                    {
                        status = 4;
                    }
                }
                else
                {
                    status = 4;
                }
            }
            catch ( Exception )
            {
                // 通信エラーは-1を戻す
                status = -1;
            }
            return status;
        }
// 2006.04.25 TERASAKA ADD END //////////////////////////////////////////////
		#endregion

		#region -- クラスメンバーコピー処理 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（伝票印刷設定ワーククラス⇒伝票印刷設定クラス）
		/// </summary>
		/// <param name="slipPrtSetWork">伝票印刷設定ワーククラス</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定ワーククラスから伝票印刷設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
        /// <br>Update Note: 2009/12/31 張凱 PM.NS保守依頼④対応</br>
        /// <br>Update Note: 2011/02/16  鄧潘ハン</br>
        /// <br>             自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		private SlipPrtSet CopyToSlipPrtSetFromSlipPrtSetWork(SlipPrtSetWork slipPrtSetWork)
		{
			SlipPrtSet slipPrtSet = new SlipPrtSet();

			slipPrtSet.CreateDateTime		= slipPrtSetWork.CreateDateTime;
			slipPrtSet.UpdateDateTime		= slipPrtSetWork.UpdateDateTime;
			slipPrtSet.EnterpriseCode		= slipPrtSetWork.EnterpriseCode;
			slipPrtSet.FileHeaderGuid		= slipPrtSetWork.FileHeaderGuid;
			slipPrtSet.UpdEmployeeCode		= slipPrtSetWork.UpdEmployeeCode;
			slipPrtSet.UpdAssemblyId1		= slipPrtSetWork.UpdAssemblyId1;
			slipPrtSet.UpdAssemblyId2		= slipPrtSetWork.UpdAssemblyId2;
			slipPrtSet.LogicalDeleteCode	= slipPrtSetWork.LogicalDeleteCode;

			slipPrtSet.DataInputSystem     = slipPrtSetWork.DataInputSystem;
			slipPrtSet.OutputPgId          = slipPrtSetWork.OutputPgId;
			slipPrtSet.OutputPgClassId     = slipPrtSetWork.OutputPgClassId;
			slipPrtSet.OutputFormFileName  = slipPrtSetWork.OutputFormFileName;
			slipPrtSet.EnterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
			slipPrtSet.PrtCirculation      = slipPrtSetWork.PrtCirculation;
			slipPrtSet.SlipFormCd          = slipPrtSetWork.SlipFormCd;
			slipPrtSet.OutConfimationMsg   = slipPrtSetWork.OutConfimationMsg;
			slipPrtSet.OptionCode          = slipPrtSetWork.OptionCode;
            // 2008.06.05 30413 犬飼 プリンタ管理No削除 >>>>>>START
			//slipPrtSet.PrinterMngNo        = slipPrtSetWork.PrinterMngNo;
            // 2008.06.05 30413 犬飼 プリンタ管理No削除 <<<<<<END
            slipPrtSet.TopMargin = slipPrtSetWork.TopMargin;
			slipPrtSet.LeftMargin          = slipPrtSetWork.LeftMargin;
			slipPrtSet.PrtPreviewExistCode = slipPrtSetWork.PrtPreviewExistCode;
			slipPrtSet.OutputPurpose       = slipPrtSetWork.OutputPurpose;
			// 伝票タイプ別列ID
			slipPrtSet.EachSlipTypeColId1  = slipPrtSetWork.EachSlipTypeColId1;
			slipPrtSet.EachSlipTypeColId2  = slipPrtSetWork.EachSlipTypeColId2;
			slipPrtSet.EachSlipTypeColId3  = slipPrtSetWork.EachSlipTypeColId3;
			slipPrtSet.EachSlipTypeColId4  = slipPrtSetWork.EachSlipTypeColId4;
			slipPrtSet.EachSlipTypeColId5  = slipPrtSetWork.EachSlipTypeColId5;
			slipPrtSet.EachSlipTypeColId6  = slipPrtSetWork.EachSlipTypeColId6;
			slipPrtSet.EachSlipTypeColId7  = slipPrtSetWork.EachSlipTypeColId7;
			slipPrtSet.EachSlipTypeColId8  = slipPrtSetWork.EachSlipTypeColId8;
			slipPrtSet.EachSlipTypeColId9  = slipPrtSetWork.EachSlipTypeColId9;
			slipPrtSet.EachSlipTypeColId10 = slipPrtSetWork.EachSlipTypeColId10;
            // 伝票タイプ別列名称
			slipPrtSet.EachSlipTypeColNm1  = slipPrtSetWork.EachSlipTypeColNm1;
			slipPrtSet.EachSlipTypeColNm2  = slipPrtSetWork.EachSlipTypeColNm2;
			slipPrtSet.EachSlipTypeColNm3  = slipPrtSetWork.EachSlipTypeColNm3;
			slipPrtSet.EachSlipTypeColNm4  = slipPrtSetWork.EachSlipTypeColNm4;
			slipPrtSet.EachSlipTypeColNm5  = slipPrtSetWork.EachSlipTypeColNm5;
			slipPrtSet.EachSlipTypeColNm6  = slipPrtSetWork.EachSlipTypeColNm6;
			slipPrtSet.EachSlipTypeColNm7  = slipPrtSetWork.EachSlipTypeColNm7;
			slipPrtSet.EachSlipTypeColNm8  = slipPrtSetWork.EachSlipTypeColNm8;
			slipPrtSet.EachSlipTypeColNm9  = slipPrtSetWork.EachSlipTypeColNm9;
			slipPrtSet.EachSlipTypeColNm10 = slipPrtSetWork.EachSlipTypeColNm10;
			// 伝票タイプ別列印字区分
			slipPrtSet.EachSlipTypeColPrt1  = slipPrtSetWork.EachSlipTypeColPrt1;
			slipPrtSet.EachSlipTypeColPrt2  = slipPrtSetWork.EachSlipTypeColPrt2;
			slipPrtSet.EachSlipTypeColPrt3  = slipPrtSetWork.EachSlipTypeColPrt3;
			slipPrtSet.EachSlipTypeColPrt4  = slipPrtSetWork.EachSlipTypeColPrt4;
			slipPrtSet.EachSlipTypeColPrt5  = slipPrtSetWork.EachSlipTypeColPrt5;
			slipPrtSet.EachSlipTypeColPrt6  = slipPrtSetWork.EachSlipTypeColPrt6;
			slipPrtSet.EachSlipTypeColPrt7  = slipPrtSetWork.EachSlipTypeColPrt7;
			slipPrtSet.EachSlipTypeColPrt8  = slipPrtSetWork.EachSlipTypeColPrt8;
			slipPrtSet.EachSlipTypeColPrt9  = slipPrtSetWork.EachSlipTypeColPrt9;
			slipPrtSet.EachSlipTypeColPrt10 = slipPrtSetWork.EachSlipTypeColPrt10;

			slipPrtSet.SlipFontName  = slipPrtSetWork.SlipFontName;
			slipPrtSet.SlipFontSize  = slipPrtSetWork.SlipFontSize;
			slipPrtSet.SlipFontStyle = slipPrtSetWork.SlipFontStyle;

            // 2008.06.05 30413 犬飼 プリンタ管理No名称削除 >>>>>>START
			//slipPrtSet.PrinterMngName = GetPrinterMngName(slipPrtSetWork.EnterpriseCode, slipPrtSetWork.PrinterMngNo);
            // 2008.06.05 30413 犬飼 プリンタ管理No名称削除 <<<<<<END
			

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSet.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;
			slipPrtSet.SlipComment       = slipPrtSetWork.SlipComment;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
			slipPrtSet.SlipPrtKind  = slipPrtSetWork.SlipPrtKind;
			slipPrtSet.RightMargin  = slipPrtSetWork.RightMargin;
			slipPrtSet.BottomMargin = slipPrtSetWork.BottomMargin;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.15 TAKAHASHI ADD START
			slipPrtSet.SlipBaseColorRed1 = slipPrtSetWork.SlipBaseColorRed1;
			slipPrtSet.SlipBaseColorRed2 = slipPrtSetWork.SlipBaseColorRed2;
			slipPrtSet.SlipBaseColorRed3 = slipPrtSetWork.SlipBaseColorRed3;
			slipPrtSet.SlipBaseColorRed4 = slipPrtSetWork.SlipBaseColorRed4;
			slipPrtSet.SlipBaseColorRed5 = slipPrtSetWork.SlipBaseColorRed5;

			slipPrtSet.SlipBaseColorGrn1 = slipPrtSetWork.SlipBaseColorGrn1;
			slipPrtSet.SlipBaseColorGrn2 = slipPrtSetWork.SlipBaseColorGrn2;
			slipPrtSet.SlipBaseColorGrn3 = slipPrtSetWork.SlipBaseColorGrn3;
			slipPrtSet.SlipBaseColorGrn4 = slipPrtSetWork.SlipBaseColorGrn4;
			slipPrtSet.SlipBaseColorGrn5 = slipPrtSetWork.SlipBaseColorGrn5;

			slipPrtSet.SlipBaseColorBlu1 = slipPrtSetWork.SlipBaseColorBlu1;
			slipPrtSet.SlipBaseColorBlu2 = slipPrtSetWork.SlipBaseColorBlu2;
			slipPrtSet.SlipBaseColorBlu3 = slipPrtSetWork.SlipBaseColorBlu3;
			slipPrtSet.SlipBaseColorBlu4 = slipPrtSetWork.SlipBaseColorBlu4;
			slipPrtSet.SlipBaseColorBlu5 = slipPrtSetWork.SlipBaseColorBlu5;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.15 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
			//slipPrtSet.CustTelNoPrtDivCd = slipPrtSetWork.CustTelNoPrtDivCd;
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			slipPrtSet.CopyCount  = slipPrtSetWork.CopyCount;
			slipPrtSet.TitleName1 = slipPrtSetWork.TitleName1;
			slipPrtSet.TitleName2 = slipPrtSetWork.TitleName2;
			slipPrtSet.TitleName3 = slipPrtSetWork.TitleName3;
			slipPrtSet.TitleName4 = slipPrtSetWork.TitleName4;
			slipPrtSet.SpecialPurpose1 = slipPrtSetWork.SpecialPurpose1;
			slipPrtSet.SpecialPurpose2 = slipPrtSetWork.SpecialPurpose2;
			slipPrtSet.SpecialPurpose3 = slipPrtSetWork.SpecialPurpose3;
			slipPrtSet.SpecialPurpose4 = slipPrtSetWork.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
			//slipPrtSet.BarCodeAcpOdrNoPrtCd = slipPrtSetWork.BarCodeAcpOdrNoPrtCd;
			//slipPrtSet.BarCodeCustCodePrtCd = slipPrtSetWork.BarCodeCustCodePrtCd;
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
			//2006.12.08 deleted by T-Kidate
            //slipPrtSet.BarCodeCarMngNoPrtCd = slipPrtSetWork.BarCodeCarMngNoPrtCd;
			///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
			
			// 2006/03/14 H.NAKAMURA ADD STA
			slipPrtSet.TitleName102 = slipPrtSetWork.TitleName102;
			slipPrtSet.TitleName103 = slipPrtSetWork.TitleName103;
			slipPrtSet.TitleName104 = slipPrtSetWork.TitleName104;
			slipPrtSet.TitleName105 = slipPrtSetWork.TitleName105;
			slipPrtSet.TitleName202 = slipPrtSetWork.TitleName202;
			slipPrtSet.TitleName203 = slipPrtSetWork.TitleName203;
			slipPrtSet.TitleName204 = slipPrtSetWork.TitleName204;
			slipPrtSet.TitleName205 = slipPrtSetWork.TitleName205;
			slipPrtSet.TitleName302 = slipPrtSetWork.TitleName302;
			slipPrtSet.TitleName303 = slipPrtSetWork.TitleName303;
			slipPrtSet.TitleName304 = slipPrtSetWork.TitleName304;
			slipPrtSet.TitleName305 = slipPrtSetWork.TitleName305;
			slipPrtSet.TitleName402 = slipPrtSetWork.TitleName402;
			slipPrtSet.TitleName403 = slipPrtSetWork.TitleName403;
			slipPrtSet.TitleName404 = slipPrtSetWork.TitleName404;
			slipPrtSet.TitleName405 = slipPrtSetWork.TitleName405;

            // 2008.06.05 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSet.Note1 = slipPrtSetWork.Note1;                            // 備考１
            slipPrtSet.Note2 = slipPrtSetWork.Note2;                            // 備考２
            slipPrtSet.Note3 = slipPrtSetWork.Note3;                            // 備考３
            slipPrtSet.QRCodePrintDivCd = slipPrtSetWork.QRCodePrintDivCd;      // QRコード印字区分
            slipPrtSet.TimePrintDivCd = slipPrtSetWork.TimePrintDivCd;          // 時刻印字区分
            slipPrtSet.ReissueMark = slipPrtSetWork.ReissueMark;                // 再発行マーク
            slipPrtSet.RefConsTaxDivCd = slipPrtSetWork.RefConsTaxDivCd;        // 参考消費税区分
            slipPrtSet.RefConsTaxPrtNm = slipPrtSetWork.RefConsTaxPrtNm;        // 参考消費税印字名称
            slipPrtSet.DetailRowCount = slipPrtSetWork.DetailRowCount;          // 明細行数
            // 2008.06.05 30413 犬飼 項目の追加 <<<<<<END

            // 2008.08.28 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSet.HonorificTitle = slipPrtSetWork.HonorificTitle;          // 敬称
            // 2008.08.28 30413 犬飼 項目の追加 <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSet.SlipNoteCharCnt = slipPrtSetWork.SlipNoteCharCnt;          // 伝票備考桁数
            slipPrtSet.SlipNote2CharCnt = slipPrtSetWork.SlipNote2CharCnt;        // 伝票備考２桁数
            slipPrtSet.SlipNote3CharCnt = slipPrtSetWork.SlipNote3CharCnt;        // 伝票備考３桁数
            // --- ADD 2009/12/31 ----------<<<<<

            // 2008.12.11 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSet.ConsTaxPrtCd = slipPrtSetWork.ConsTaxPrtCdRF;              // 消費税印字
            // 2008.12.11 30413 犬飼 項目の追加 <<<<<<END

            //2006.12.08 deleted by T-Kidate
            //slipPrtSet.MainWorkLinePrtDivCd = slipPrtSetWork.MainWorkLinePrtDivCd;

			//2006/03/14 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////契約番号印字区分
			//slipPrtSet.ContractNoPrtDivCd = slipPrtSetWork.ContractNoPrtDivCd;
			////契約携帯電話番号印字区分
			//slipPrtSet.ContCpNoPrtDivCd = slipPrtSetWork.ContCpNoPrtDivCd;
			//----- h.ueno del---------- end   2007.12.17

            slipPrtSet.EntNmPrtExpDiv = slipPrtSetWork.EntNmPrtExpDiv; // ADD 2011/02/16
            // --- ADD START 2011/07/19 ---------->>>>>
            slipPrtSet.SCMAnsMarkPrtDiv = slipPrtSetWork.SCMAnsMarkPrtDiv;
            slipPrtSet.NormalPrtMark = slipPrtSetWork.NormalPrtMark;
            slipPrtSet.SCMManualAnsMark = slipPrtSetWork.SCMManualAnsMark;
            slipPrtSet.SCMAutoAnsMark = slipPrtSetWork.SCMAutoAnsMark;
            // --- ADD END 2011/07/19 ----------<<<<<

			return slipPrtSet;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.26 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（伝票印刷設定ワーククラス⇒伝票印刷設定クラス）
		/// </summary>
		/// <param name="slipPrtSetWorkList">伝票印刷設定ワーククラスリスト</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定ワーククラスから伝票印刷設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		private void CopyToSlipPrtSetFromSlipPrtSetWork(ArrayList slipPrtSetWorkList)
		{
			// HashTableのKey
			string keyOfHashTable = null;

			// ArrayListが空の場合
			if (slipPrtSetWorkList == null)
				return;

			foreach (SlipPrtSetWork slipPrtSetWork in slipPrtSetWorkList)
			{
				SlipPrtSet slipPrtSet = new SlipPrtSet();

				keyOfHashTable = slipPrtSetWork.DataInputSystem.ToString() + "," + slipPrtSetWork.SlipPrtKind + ","
					+ slipPrtSetWork.SlipPrtSetPaperId;

				slipPrtSet.CreateDateTime	 = slipPrtSetWork.CreateDateTime;
				slipPrtSet.UpdateDateTime	 = slipPrtSetWork.UpdateDateTime;
				slipPrtSet.EnterpriseCode	 = slipPrtSetWork.EnterpriseCode;
				slipPrtSet.FileHeaderGuid	 = slipPrtSetWork.FileHeaderGuid;
				slipPrtSet.UpdEmployeeCode	 = slipPrtSetWork.UpdEmployeeCode;
				slipPrtSet.UpdAssemblyId1	 = slipPrtSetWork.UpdAssemblyId1;
				slipPrtSet.UpdAssemblyId2	 = slipPrtSetWork.UpdAssemblyId2;
				slipPrtSet.LogicalDeleteCode = slipPrtSetWork.LogicalDeleteCode;

				slipPrtSet.DataInputSystem     = slipPrtSetWork.DataInputSystem;
				slipPrtSet.OutputPgId          = slipPrtSetWork.OutputPgId;
				slipPrtSet.OutputPgClassId     = slipPrtSetWork.OutputPgClassId;
				slipPrtSet.OutputFormFileName  = slipPrtSetWork.OutputFormFileName;
				slipPrtSet.EnterpriseNamePrtCd = slipPrtSetWork.EnterpriseNamePrtCd;
				slipPrtSet.PrtCirculation      = slipPrtSetWork.PrtCirculation;
				slipPrtSet.SlipFormCd          = slipPrtSetWork.SlipFormCd;
				slipPrtSet.OutConfimationMsg   = slipPrtSetWork.OutConfimationMsg;
				slipPrtSet.OptionCode          = slipPrtSetWork.OptionCode;
                // 2008.06.05 30413 犬飼 プリンタ管理No削除 >>>>>>START
				//slipPrtSet.PrinterMngNo        = slipPrtSetWork.PrinterMngNo;
                // 2008.06.05 30413 犬飼 プリンタ管理No削除 <<<<<<END
				slipPrtSet.TopMargin           = slipPrtSetWork.TopMargin;
				slipPrtSet.LeftMargin          = slipPrtSetWork.LeftMargin;
				slipPrtSet.PrtPreviewExistCode = slipPrtSetWork.PrtPreviewExistCode;
				slipPrtSet.OutputPurpose       = slipPrtSetWork.OutputPurpose;
				// 伝票タイプ別列ID
				slipPrtSet.EachSlipTypeColId1  = slipPrtSetWork.EachSlipTypeColId1;
				slipPrtSet.EachSlipTypeColId2  = slipPrtSetWork.EachSlipTypeColId2;
				slipPrtSet.EachSlipTypeColId3  = slipPrtSetWork.EachSlipTypeColId3;
				slipPrtSet.EachSlipTypeColId4  = slipPrtSetWork.EachSlipTypeColId4;
				slipPrtSet.EachSlipTypeColId5  = slipPrtSetWork.EachSlipTypeColId5;
				slipPrtSet.EachSlipTypeColId6  = slipPrtSetWork.EachSlipTypeColId6;
				slipPrtSet.EachSlipTypeColId7  = slipPrtSetWork.EachSlipTypeColId7;
				slipPrtSet.EachSlipTypeColId8  = slipPrtSetWork.EachSlipTypeColId8;
				slipPrtSet.EachSlipTypeColId9  = slipPrtSetWork.EachSlipTypeColId9;
				slipPrtSet.EachSlipTypeColId10 = slipPrtSetWork.EachSlipTypeColId10;
				// 伝票タイプ別列名称
				slipPrtSet.EachSlipTypeColNm1  = slipPrtSetWork.EachSlipTypeColNm1;
				slipPrtSet.EachSlipTypeColNm2  = slipPrtSetWork.EachSlipTypeColNm2;
				slipPrtSet.EachSlipTypeColNm3  = slipPrtSetWork.EachSlipTypeColNm3;
				slipPrtSet.EachSlipTypeColNm4  = slipPrtSetWork.EachSlipTypeColNm4;
				slipPrtSet.EachSlipTypeColNm5  = slipPrtSetWork.EachSlipTypeColNm5;
				slipPrtSet.EachSlipTypeColNm6  = slipPrtSetWork.EachSlipTypeColNm6;
				slipPrtSet.EachSlipTypeColNm7  = slipPrtSetWork.EachSlipTypeColNm7;
				slipPrtSet.EachSlipTypeColNm8  = slipPrtSetWork.EachSlipTypeColNm8;
				slipPrtSet.EachSlipTypeColNm9  = slipPrtSetWork.EachSlipTypeColNm9;
				slipPrtSet.EachSlipTypeColNm10 = slipPrtSetWork.EachSlipTypeColNm10;
				// 伝票タイプ別列印字区分
				slipPrtSet.EachSlipTypeColPrt1  = slipPrtSetWork.EachSlipTypeColPrt1;
				slipPrtSet.EachSlipTypeColPrt2  = slipPrtSetWork.EachSlipTypeColPrt2;
				slipPrtSet.EachSlipTypeColPrt3  = slipPrtSetWork.EachSlipTypeColPrt3;
				slipPrtSet.EachSlipTypeColPrt4  = slipPrtSetWork.EachSlipTypeColPrt4;
				slipPrtSet.EachSlipTypeColPrt5  = slipPrtSetWork.EachSlipTypeColPrt5;
				slipPrtSet.EachSlipTypeColPrt6  = slipPrtSetWork.EachSlipTypeColPrt6;
				slipPrtSet.EachSlipTypeColPrt7  = slipPrtSetWork.EachSlipTypeColPrt7;
				slipPrtSet.EachSlipTypeColPrt8  = slipPrtSetWork.EachSlipTypeColPrt8;
				slipPrtSet.EachSlipTypeColPrt9  = slipPrtSetWork.EachSlipTypeColPrt9;
				slipPrtSet.EachSlipTypeColPrt10 = slipPrtSetWork.EachSlipTypeColPrt10;

				slipPrtSet.SlipFontName      = slipPrtSetWork.SlipFontName;
				slipPrtSet.SlipFontSize      = slipPrtSetWork.SlipFontSize;
				slipPrtSet.SlipFontStyle     = slipPrtSetWork.SlipFontStyle;
                // 2008.06.05 30413 犬飼 プリンタ管理No名称削除 >>>>>>START
				//slipPrtSet.PrinterMngName    = GetPrinterMngName(slipPrtSetWork.EnterpriseCode, slipPrtSetWork.PrinterMngNo);
                // 2008.06.05 30413 犬飼 プリンタ管理No名称削除 <<<<<<END
				slipPrtSet.SlipPrtSetPaperId = slipPrtSetWork.SlipPrtSetPaperId;
				slipPrtSet.SlipComment       = slipPrtSetWork.SlipComment;
				slipPrtSet.SlipPrtKind       = slipPrtSetWork.SlipPrtKind;
				slipPrtSet.RightMargin       = slipPrtSetWork.RightMargin;
				slipPrtSet.BottomMargin      = slipPrtSetWork.BottomMargin;

				slipPrtSet.SlipBaseColorRed1 = slipPrtSetWork.SlipBaseColorRed1;
				slipPrtSet.SlipBaseColorRed2 = slipPrtSetWork.SlipBaseColorRed2;
				slipPrtSet.SlipBaseColorRed3 = slipPrtSetWork.SlipBaseColorRed3;
				slipPrtSet.SlipBaseColorRed4 = slipPrtSetWork.SlipBaseColorRed4;
				slipPrtSet.SlipBaseColorRed5 = slipPrtSetWork.SlipBaseColorRed5;

				slipPrtSet.SlipBaseColorGrn1 = slipPrtSetWork.SlipBaseColorGrn1;
				slipPrtSet.SlipBaseColorGrn2 = slipPrtSetWork.SlipBaseColorGrn2;
				slipPrtSet.SlipBaseColorGrn3 = slipPrtSetWork.SlipBaseColorGrn3;
				slipPrtSet.SlipBaseColorGrn4 = slipPrtSetWork.SlipBaseColorGrn4;
				slipPrtSet.SlipBaseColorGrn5 = slipPrtSetWork.SlipBaseColorGrn5;

				slipPrtSet.SlipBaseColorBlu1 = slipPrtSetWork.SlipBaseColorBlu1;
				slipPrtSet.SlipBaseColorBlu2 = slipPrtSetWork.SlipBaseColorBlu2;
				slipPrtSet.SlipBaseColorBlu3 = slipPrtSetWork.SlipBaseColorBlu3;
				slipPrtSet.SlipBaseColorBlu4 = slipPrtSetWork.SlipBaseColorBlu4;
				slipPrtSet.SlipBaseColorBlu5 = slipPrtSetWork.SlipBaseColorBlu5;

                // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
                //slipPrtSet.CustTelNoPrtDivCd = slipPrtSetWork.CustTelNoPrtDivCd;
                // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
				slipPrtSet.CopyCount  = slipPrtSetWork.CopyCount;
				slipPrtSet.TitleName1 = slipPrtSetWork.TitleName1;
				slipPrtSet.TitleName2 = slipPrtSetWork.TitleName2;
				slipPrtSet.TitleName3 = slipPrtSetWork.TitleName3;
				slipPrtSet.TitleName4 = slipPrtSetWork.TitleName4;
				slipPrtSet.SpecialPurpose1 = slipPrtSetWork.SpecialPurpose1;
				slipPrtSet.SpecialPurpose2 = slipPrtSetWork.SpecialPurpose2;
				slipPrtSet.SpecialPurpose3 = slipPrtSetWork.SpecialPurpose3;
				slipPrtSet.SpecialPurpose4 = slipPrtSetWork.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

				////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
                // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
				//slipPrtSet.BarCodeAcpOdrNoPrtCd = slipPrtSetWork.BarCodeAcpOdrNoPrtCd;
				//slipPrtSet.BarCodeCustCodePrtCd = slipPrtSetWork.BarCodeCustCodePrtCd;
                // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
                //2006.12.08 deleted by T-Kidate
                //slipPrtSet.BarCodeCarMngNoPrtCd = slipPrtSetWork.BarCodeCarMngNoPrtCd;
				///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
				
				// 2006/03/14 H.NAKAMURA ADD STA
				slipPrtSet.TitleName102 = slipPrtSetWork.TitleName102;
				slipPrtSet.TitleName103 = slipPrtSetWork.TitleName103;
				slipPrtSet.TitleName104 = slipPrtSetWork.TitleName104;
				slipPrtSet.TitleName105 = slipPrtSetWork.TitleName105;
				slipPrtSet.TitleName202 = slipPrtSetWork.TitleName202;
				slipPrtSet.TitleName203 = slipPrtSetWork.TitleName203;
				slipPrtSet.TitleName204 = slipPrtSetWork.TitleName204;
				slipPrtSet.TitleName205 = slipPrtSetWork.TitleName205;
				slipPrtSet.TitleName302 = slipPrtSetWork.TitleName302;
				slipPrtSet.TitleName303 = slipPrtSetWork.TitleName303;
				slipPrtSet.TitleName304 = slipPrtSetWork.TitleName304;
				slipPrtSet.TitleName305 = slipPrtSetWork.TitleName305;
				slipPrtSet.TitleName402 = slipPrtSetWork.TitleName402;
				slipPrtSet.TitleName403 = slipPrtSetWork.TitleName403;
				slipPrtSet.TitleName404 = slipPrtSetWork.TitleName404;
				slipPrtSet.TitleName405 = slipPrtSetWork.TitleName405;

                // 2008.06.05 30413 犬飼 項目の追加 >>>>>>START
                slipPrtSet.Note1 = slipPrtSetWork.Note1;                            // 備考１
                slipPrtSet.Note2 = slipPrtSetWork.Note2;                            // 備考２
                slipPrtSet.Note3 = slipPrtSetWork.Note3;                            // 備考３
                slipPrtSet.QRCodePrintDivCd = slipPrtSetWork.QRCodePrintDivCd;      // QRコード印字区分
                slipPrtSet.TimePrintDivCd = slipPrtSetWork.TimePrintDivCd;          // 時刻印字区分
                slipPrtSet.ReissueMark = slipPrtSetWork.ReissueMark;                // 再発行マーク
                slipPrtSet.RefConsTaxDivCd = slipPrtSetWork.RefConsTaxDivCd;        // 参考消費税区分
                slipPrtSet.RefConsTaxPrtNm = slipPrtSetWork.RefConsTaxPrtNm;        // 参考消費税印字名称
                slipPrtSet.DetailRowCount = slipPrtSetWork.DetailRowCount;          // 明細行数
                // 2008.06.05 30413 犬飼 項目の追加 <<<<<<END

                // 2008.08.28 30413 犬飼 項目の追加 >>>>>>START
                slipPrtSet.HonorificTitle = slipPrtSetWork.HonorificTitle;          // 敬称
                // 2008.08.28 30413 犬飼 項目の追加 <<<<<<END

                // --- ADD 2009/12/31 ---------->>>>>
                slipPrtSet.SlipNoteCharCnt = slipPrtSetWork.SlipNoteCharCnt;          // 伝票備考桁数
                slipPrtSet.SlipNote2CharCnt = slipPrtSetWork.SlipNote2CharCnt;        // 伝票備考２桁数
                slipPrtSet.SlipNote3CharCnt = slipPrtSetWork.SlipNote3CharCnt;        // 伝票備考３桁数
                // --- ADD 2009/12/31 ----------<<<<<

                // 2008.12.11 30413 犬飼 項目の追加 >>>>>>START
                slipPrtSet.ConsTaxPrtCd = slipPrtSetWork.ConsTaxPrtCdRF;              // 消費税印字
                // 2008.12.11 30413 犬飼 項目の追加 <<<<<<END

                //2006.12.08 deleted by T-Kidate
                //slipPrtSet.MainWorkLinePrtDivCd = slipPrtSetWork.MainWorkLinePrtDivCd;
				
                //2006/03/14 H.NAKAMURA ADD END

				//----- h.ueno del---------- start 2007.12.17
				////2006.12.08 added by T-Kidate
				////契約番号印字区分
				//slipPrtSet.ContractNoPrtDivCd = slipPrtSetWork.ContractNoPrtDivCd;
				////契約携帯電話番号印字区分
				//slipPrtSet.ContCpNoPrtDivCd = slipPrtSetWork.ContCpNoPrtDivCd;
				//----- h.ueno del---------- end   2007.12.17

				_static_SlipPrtSetTable[keyOfHashTable] = slipPrtSet;
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.26 TAKAHASHI ADD END
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（伝票印刷設定クラス⇒伝票印刷設定ワーククラス）
		/// </summary>
		/// <param name="slipPrtSet">伝票印刷設定ワーククラス</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定クラスから伝票印刷設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 23006　高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
        /// <br>Update Note: 2009/12/31 張凱 PM.NS保守依頼④対応</br>
        /// <br>Update Note: 2010/08/06 caowj PM.NS1012対応</br>
        /// <br>Update Note: 2011/02/16  鄧潘ハン</br>
        /// <br>             自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		private SlipPrtSetWork CopyToSlipPrtSetWorkFromSlipPrtSet(SlipPrtSet slipPrtSet)
		{
			SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

			slipPrtSetWork.CreateDateTime		= slipPrtSet.CreateDateTime;
			slipPrtSetWork.UpdateDateTime		= slipPrtSet.UpdateDateTime;
			slipPrtSetWork.EnterpriseCode		= slipPrtSet.EnterpriseCode;
			slipPrtSetWork.FileHeaderGuid		= slipPrtSet.FileHeaderGuid;
			slipPrtSetWork.UpdEmployeeCode		= slipPrtSet.UpdEmployeeCode;
			slipPrtSetWork.UpdAssemblyId1		= slipPrtSet.UpdAssemblyId1;
			slipPrtSetWork.UpdAssemblyId2		= slipPrtSet.UpdAssemblyId2;
			slipPrtSetWork.LogicalDeleteCode	= slipPrtSet.LogicalDeleteCode;

			slipPrtSetWork.DataInputSystem     = slipPrtSet.DataInputSystem;
			slipPrtSetWork.OutputPgId          = slipPrtSet.OutputPgId.TrimEnd();
			slipPrtSetWork.OutputPgClassId     = slipPrtSet.OutputPgClassId.TrimEnd();
			slipPrtSetWork.OutputFormFileName  = slipPrtSet.OutputFormFileName.TrimEnd();
			slipPrtSetWork.EnterpriseNamePrtCd = slipPrtSet.EnterpriseNamePrtCd;
			slipPrtSetWork.PrtCirculation      = slipPrtSet.PrtCirculation;
			slipPrtSetWork.SlipFormCd          = slipPrtSet.SlipFormCd;
			slipPrtSetWork.OutConfimationMsg   = slipPrtSet.OutConfimationMsg.TrimEnd();
			slipPrtSetWork.OptionCode          = slipPrtSet.OptionCode;
            // 2008.06.05 30413 犬飼 プリンタ管理No削除 >>>>>>START
            //slipPrtSetWork.PrinterMngNo        = slipPrtSet.PrinterMngNo;
            // 2008.06.05 30413 犬飼 プリンタ管理No削除 <<<<<<END
			slipPrtSetWork.TopMargin           = slipPrtSet.TopMargin;
			slipPrtSetWork.LeftMargin          = slipPrtSet.LeftMargin;
			slipPrtSetWork.PrtPreviewExistCode = slipPrtSet.PrtPreviewExistCode;
			slipPrtSetWork.OutputPurpose       = slipPrtSet.OutputPurpose;
			// 伝票タイプ別列ID
			slipPrtSetWork.EachSlipTypeColId1  = slipPrtSet.EachSlipTypeColId1.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId2  = slipPrtSet.EachSlipTypeColId2.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId3  = slipPrtSet.EachSlipTypeColId3.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId4  = slipPrtSet.EachSlipTypeColId4.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId5  = slipPrtSet.EachSlipTypeColId5.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId6  = slipPrtSet.EachSlipTypeColId6.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId7  = slipPrtSet.EachSlipTypeColId7.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId8  = slipPrtSet.EachSlipTypeColId8.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId9  = slipPrtSet.EachSlipTypeColId9.TrimEnd();
			slipPrtSetWork.EachSlipTypeColId10 = slipPrtSet.EachSlipTypeColId10.TrimEnd();
			// 伝票タイプ別列名称
			slipPrtSetWork.EachSlipTypeColNm1  = slipPrtSet.EachSlipTypeColNm1.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm2  = slipPrtSet.EachSlipTypeColNm2.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm3  = slipPrtSet.EachSlipTypeColNm3.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm4  = slipPrtSet.EachSlipTypeColNm4.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm5  = slipPrtSet.EachSlipTypeColNm5.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm6  = slipPrtSet.EachSlipTypeColNm6.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm7  = slipPrtSet.EachSlipTypeColNm7.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm8  = slipPrtSet.EachSlipTypeColNm8.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm9  = slipPrtSet.EachSlipTypeColNm9.TrimEnd();
			slipPrtSetWork.EachSlipTypeColNm10 = slipPrtSet.EachSlipTypeColNm10.TrimEnd();
			// 伝票タイプ別列印字区分
			slipPrtSetWork.EachSlipTypeColPrt1  = slipPrtSet.EachSlipTypeColPrt1;
			slipPrtSetWork.EachSlipTypeColPrt2  = slipPrtSet.EachSlipTypeColPrt2;
			slipPrtSetWork.EachSlipTypeColPrt3  = slipPrtSet.EachSlipTypeColPrt3;
			slipPrtSetWork.EachSlipTypeColPrt4  = slipPrtSet.EachSlipTypeColPrt4;
			slipPrtSetWork.EachSlipTypeColPrt5  = slipPrtSet.EachSlipTypeColPrt5;
			slipPrtSetWork.EachSlipTypeColPrt6  = slipPrtSet.EachSlipTypeColPrt6;
			slipPrtSetWork.EachSlipTypeColPrt7  = slipPrtSet.EachSlipTypeColPrt7;
			slipPrtSetWork.EachSlipTypeColPrt8  = slipPrtSet.EachSlipTypeColPrt8;
			slipPrtSetWork.EachSlipTypeColPrt9  = slipPrtSet.EachSlipTypeColPrt9;
			slipPrtSetWork.EachSlipTypeColPrt10 = slipPrtSet.EachSlipTypeColPrt10;

			slipPrtSetWork.SlipFontName  = slipPrtSet.SlipFontName.TrimEnd();
			slipPrtSetWork.SlipFontSize  = slipPrtSet.SlipFontSize;
			slipPrtSetWork.SlipFontStyle = slipPrtSet.SlipFontStyle;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			slipPrtSetWork.SlipPrtSetPaperId = slipPrtSet.SlipPrtSetPaperId.TrimEnd();
			slipPrtSetWork.SlipComment       = slipPrtSet.SlipComment.TrimEnd();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.14 TAKAHASHI ADD START
			slipPrtSetWork.SlipPrtKind  = slipPrtSet.SlipPrtKind;
			slipPrtSetWork.RightMargin  = slipPrtSet.RightMargin;
			slipPrtSetWork.BottomMargin = slipPrtSet.BottomMargin;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.14 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.15 TAKAHASHI ADD START
			slipPrtSetWork.SlipBaseColorRed1 = slipPrtSet.SlipBaseColorRed1;
			slipPrtSetWork.SlipBaseColorRed2 = slipPrtSet.SlipBaseColorRed2;
			slipPrtSetWork.SlipBaseColorRed3 = slipPrtSet.SlipBaseColorRed3;
			slipPrtSetWork.SlipBaseColorRed4 = slipPrtSet.SlipBaseColorRed4;
			slipPrtSetWork.SlipBaseColorRed5 = slipPrtSet.SlipBaseColorRed5;

			slipPrtSetWork.SlipBaseColorGrn1 = slipPrtSet.SlipBaseColorGrn1;
			slipPrtSetWork.SlipBaseColorGrn2 = slipPrtSet.SlipBaseColorGrn2;
			slipPrtSetWork.SlipBaseColorGrn3 = slipPrtSet.SlipBaseColorGrn3;
			slipPrtSetWork.SlipBaseColorGrn4 = slipPrtSet.SlipBaseColorGrn4;
			slipPrtSetWork.SlipBaseColorGrn5 = slipPrtSet.SlipBaseColorGrn5;

			slipPrtSetWork.SlipBaseColorBlu1 = slipPrtSet.SlipBaseColorBlu1;
			slipPrtSetWork.SlipBaseColorBlu2 = slipPrtSet.SlipBaseColorBlu2;
			slipPrtSetWork.SlipBaseColorBlu3 = slipPrtSet.SlipBaseColorBlu3;
			slipPrtSetWork.SlipBaseColorBlu4 = slipPrtSet.SlipBaseColorBlu4;
			slipPrtSetWork.SlipBaseColorBlu5 = slipPrtSet.SlipBaseColorBlu5;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.15 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.16 TAKAHASHI ADD START
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
			//slipPrtSetWork.CustTelNoPrtDivCd = slipPrtSet.CustTelNoPrtDivCd;
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.16 TAKAHASHI ADD END
////////////////////////////////////////////// 2006.01.24 TERASAKA ADD STA //
			slipPrtSetWork.CopyCount  = slipPrtSet.CopyCount;
			slipPrtSetWork.TitleName1 = slipPrtSet.TitleName1;
			slipPrtSetWork.TitleName2 = slipPrtSet.TitleName2;
			slipPrtSetWork.TitleName3 = slipPrtSet.TitleName3;
			slipPrtSetWork.TitleName4 = slipPrtSet.TitleName4;
			slipPrtSetWork.SpecialPurpose1 = slipPrtSet.SpecialPurpose1;
			slipPrtSetWork.SpecialPurpose2 = slipPrtSet.SpecialPurpose2;
			slipPrtSetWork.SpecialPurpose3 = slipPrtSet.SpecialPurpose3;
			slipPrtSetWork.SpecialPurpose4 = slipPrtSet.SpecialPurpose4;
// 2006.01.24 TERASAKA ADD END //////////////////////////////////////////////

			////////////////////////////////////////////// 2006.01.30 UENO ADD STA //
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 >>>>>>START
			//slipPrtSetWork.BarCodeAcpOdrNoPrtCd = slipPrtSet. ;
			//slipPrtSetWork.BarCodeCustCodePrtCd = slipPrtSet.BarCodeCustCodePrtCd;
            // 2008.06.05 30413 犬飼 ビルドエラーのため、コメント化 <<<<<<END
            //2006.12.08 deleted by T-Kidate
            //slipPrtSetWork.BarCodeCarMngNoPrtCd = slipPrtSet.BarCodeCarMngNoPrtCd;
			///// 2006.01.30 UENO ADD END //////////////////////////////////////////////
			
			// 2006/03/14 H.NAKAMURA ADD STA
			slipPrtSetWork.TitleName102 = slipPrtSet.TitleName102;
			slipPrtSetWork.TitleName103 = slipPrtSet.TitleName103;
			slipPrtSetWork.TitleName104 = slipPrtSet.TitleName104;
			slipPrtSetWork.TitleName105 = slipPrtSet.TitleName105;
			slipPrtSetWork.TitleName202 = slipPrtSet.TitleName202;
			slipPrtSetWork.TitleName203 = slipPrtSet.TitleName203;
			slipPrtSetWork.TitleName204 = slipPrtSet.TitleName204;
			slipPrtSetWork.TitleName205 = slipPrtSet.TitleName205;
			slipPrtSetWork.TitleName302 = slipPrtSet.TitleName302;
			slipPrtSetWork.TitleName303 = slipPrtSet.TitleName303;
			slipPrtSetWork.TitleName304 = slipPrtSet.TitleName304;
			slipPrtSetWork.TitleName305 = slipPrtSet.TitleName305; 
			slipPrtSetWork.TitleName402 = slipPrtSet.TitleName402;
			slipPrtSetWork.TitleName403 = slipPrtSet.TitleName403;
		    slipPrtSetWork.TitleName404 = slipPrtSet.TitleName404;
			slipPrtSetWork.TitleName405 = slipPrtSet.TitleName405;

            // 2008.06.05 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSetWork.Note1 = slipPrtSet.Note1;                            // 備考１
            slipPrtSetWork.Note2 = slipPrtSet.Note2;                            // 備考２
            slipPrtSetWork.Note3 = slipPrtSet.Note3;                            // 備考３
            slipPrtSetWork.QRCodePrintDivCd = slipPrtSet.QRCodePrintDivCd;      // QRコード印字区分
            slipPrtSetWork.TimePrintDivCd = slipPrtSet.TimePrintDivCd;          // 時刻印字区分
            slipPrtSetWork.ReissueMark = slipPrtSet.ReissueMark;                // 再発行マーク
            slipPrtSetWork.RefConsTaxDivCd = slipPrtSet.RefConsTaxDivCd;        // 参考消費税区分
            slipPrtSetWork.RefConsTaxPrtNm = slipPrtSet.RefConsTaxPrtNm;        // 参考消費税印字名称
            slipPrtSetWork.DetailRowCount = slipPrtSet.DetailRowCount;          // 明細行数
            // 2008.06.05 30413 犬飼 項目の追加 <<<<<<END

            // 2008.08.28 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSetWork.HonorificTitle = slipPrtSet.HonorificTitle;          // 敬称
            // 2008.08.28 30413 犬飼 項目の追加 <<<<<<END

            // --- ADD 2009/12/31 ---------->>>>>
            slipPrtSetWork.SlipNoteCharCnt = slipPrtSet.SlipNoteCharCnt;          // 伝票備考桁数
            slipPrtSetWork.SlipNote2CharCnt = slipPrtSet.SlipNote2CharCnt;        // 伝票備考２桁数
            slipPrtSetWork.SlipNote3CharCnt = slipPrtSet.SlipNote3CharCnt;        // 伝票備考３桁数
            // --- ADD 2009/12/31 ----------<<<<<

            // 2008.12.11 30413 犬飼 項目の追加 >>>>>>START
            slipPrtSetWork.ConsTaxPrtCdRF = slipPrtSet.ConsTaxPrtCd;              // 消費税印字
            // 2008.12.11 30413 犬飼 項目の追加 <<<<<<END

            //2006.12.08 deleted by T-Kidate
            //slipPrtSetWork.MainWorkLinePrtDivCd = slipPrtSet.MainWorkLinePrtDivCd;
			
            //2006/03/14 H.NAKAMURA ADD END

			//----- h.ueno del---------- start 2007.12.17
			////2006.12.08 added by T-Kidate
			////契約番号印字区分
			//slipPrtSetWork.ContractNoPrtDivCd = slipPrtSet.ContractNoPrtDivCd;
			////契約携帯電話番号印字区分
			//slipPrtSetWork.ContCpNoPrtDivCd = slipPrtSet.ContCpNoPrtDivCd;
			//----- h.ueno del---------- end   2007.12.17

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            slipPrtSetWork.CustomerCode = slipPrtSet.CustomerCode;
            slipPrtSetWork.UpdateFlag = slipPrtSet.UpdateFlag;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
            slipPrtSetWork.EntNmPrtExpDiv = slipPrtSet.EntNmPrtExpDiv; // ADD 2011/02/16

            // --- ADD START 2011/07/19 ---------->>>>>
            slipPrtSetWork.SCMAnsMarkPrtDiv = slipPrtSet.SCMAnsMarkPrtDiv;
            slipPrtSetWork.NormalPrtMark = slipPrtSet.NormalPrtMark;
            slipPrtSetWork.SCMManualAnsMark = slipPrtSet.SCMManualAnsMark;
            slipPrtSetWork.SCMAutoAnsMark = slipPrtSet.SCMAutoAnsMark;
            // --- ADD END 2011/07/19 ----------<<<<<

			return slipPrtSetWork;
		}
		#endregion

		#region -- 名称取得 --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// プリンタ管理№名称取得
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="printerMngNo">プリンタ管理№</param>
		/// <returns>プリンタ管理№名称</returns>
		/// <remarks>
		/// <br>Note       : プリンタ管理№からプリンタ管理№名称を取得します。</br>
		/// <br>Programmer : 23006  高橋 明子</br>
		/// <br>Date       : 2005.08.31</br>
		/// </remarks>
		public string GetPrinterMngName(string enterpriseCode, int printerMngNo)
		{
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI ADD START
			int status = 0;

			int getMode = 1;

			ArrayList guideBuff = new ArrayList();
			
			status = prtManageAcs.GetBuff(out guideBuff, enterpriseCode, getMode);

			if (status != 0)
			{
				return "未登録";
			}

			foreach (PrtManage prtManageGuide in guideBuff)
			{
				if (prtManageGuide.PrinterMngNo == printerMngNo)
				{
					if (prtManageGuide.LogicalDeleteCode == 0)
					{
						return prtManageGuide.PrinterName;
					}
					else
					{
						return "削除済";
					}
				}
			}

			return "未登録";
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI ADD END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.12.05 TAKAHASHI DELETE START
//			int status = prtManageAcs.Read(out prtManage, enterpriseCode, printerMngNo);
//
//			switch (status)
//			{
//				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
//				{
//					if (prtManage.LogicalDeleteCode == 0)
//					{
//						return prtManage.PrinterName;
//					}
//					else
//					{
//						return "削除済";
//					}
//				}
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					return "未登録";
//				}
//				default :
//				{
//					return "";
//				}
//			}
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.12.05 TAKAHASHI DELETE END
		}
		#endregion

//----- h.ueno add---------- start 2007.12.17
		#region Guide Methods
		
		/// <summary>
		/// マスタガイド起動処理
		/// </summary>
		/// <param name="SlipPrtSet">取得データ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note       : マスタの一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int ExecuteGuid(out SlipPrtSet SlipPrtSet, string enterpriseCode)
		{
			int status = -1;
			SlipPrtSet = new SlipPrtSet();
			
			TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();
			
			inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);		// 企業コード

			// ガイド起動
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				// 選択データの取得
				SlipPrtSet = CopyToSlipPrtSetFromGuideData(retObj);
				status = 0;
			}
			// キャンセル
			else
			{
				status = 1;
			}

			return status;
		}

		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note	   : 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";
			
			// 企業コード設定有り
			if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA))
			{
				enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
			}
			// 企業コード設定無し
			else
			{
				// 有り得ないのでエラー
				return status;
			}
			
			// マスタテーブル読込み
			//DataSet retList;
			ArrayList retList = null;
			status = this.SearchAllSlipPrtSet(out retList, enterpriseCode);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// ガイド初期起動時
						if (guideList.Tables.Count == 0)
						{
							// ガイド用データセット列情報構築
							this.GuideDataSetColumnConstruction(ref guideList);
						}

						// ガイド用データセットの作成
						this.GetGuideDataSet(ref guideList, retList, inParm);

						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					{
						status = -1;
						break;
					}
			}

			return status;
		}

		/// <summary>
		/// ガイド用データセット作成処理
		/// </summary>
		/// <param name="retDataSet">結果取得データセット</param>>
		/// <param name="retList">格納アレイリスト</param>>
		/// <param name="inParm">パラメータ</param>>
		/// <remarks>
		/// <br>Note	   : ガイド用データセット処理を行なう</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
		{
			SlipPrtSet slipPrtSet = null;
			DataRow guideRow = null;
			
			// 行を初期化して新しいデータを追加
			retDataSet.Tables[0].Rows.Clear();
			retDataSet.Tables[0].BeginLoadData();

			int dataCnt = 0;
			while (dataCnt < retList.Count)
			{
				slipPrtSet = (SlipPrtSet)retList[dataCnt];
				guideRow = retDataSet.Tables[0].NewRow();
				// データコピー処理
				CopyToGuideRowFromSlipPrtSet(ref guideRow, slipPrtSet);
				// データ追加
				retDataSet.Tables[0].Rows.Add(guideRow);
				
				dataCnt++;
			}

			retDataSet.Tables[0].EndLoadData();
		}

		/// <summary>
		/// ガイド用データセット列情報構築処理
		/// </summary>
		/// <param name="guideList">ガイド用データセット</param>>
		/// <remarks>
		/// <br>Note       : ガイド用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void GuideDataSetColumnConstruction(ref DataSet guideList)
		{
			DataTable table = new DataTable();
			DataColumn column;

			// データシステム
			column = new DataColumn();
			column.DataType = typeof(int);
			column.ColumnName = GUIDE_DATAINPUTSYSTEM_TITLE;
			table.Columns.Add(column);

			// データシステム名
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_DATAINPUTSYSTEMNAME_TITLE;
			table.Columns.Add(column);

			// 伝票印刷種別
			column = new DataColumn();
			column.DataType = typeof(int);
			column.ColumnName = GUIDE_SLIPPRTKIND_TITLE;
			table.Columns.Add(column);

			// 伝票印刷種別名
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPPRTKINDNAME_TITLE;
			table.Columns.Add(column);

			// 伝票印刷設定用帳票ID
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPPRTSETPAPERID_TITLE;
			table.Columns.Add(column);

			// 伝票コメント
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SLIPCOMMENT_TITLE;
			table.Columns.Add(column);
			
			// テーブルコピー
			guideList.Tables.Add(table.Clone());
		}

		/// <summary>
		/// クラスメンバコピー処理 (ガイド選択データ⇒伝票印刷設定クラス)
		/// </summary>
		/// <param name="guideData">ガイド選択データ</param>
		/// <returns>伝票印刷設定クラス</returns>
		/// <remarks>
		/// <br>Note       : ガイド選択データから伝票印刷設定クラスへメンバコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private SlipPrtSet CopyToSlipPrtSetFromGuideData(Hashtable guideData)
		{
			SlipPrtSet slipPrtSet = new SlipPrtSet();
			slipPrtSet.DataInputSystem = (int)guideData[GUIDE_DATAINPUTSYSTEM_TITLE];
			slipPrtSet.SlipPrtKind = (int)guideData[GUIDE_SLIPPRTKIND_TITLE];
			slipPrtSet.SlipPrtSetPaperId = (string)guideData[GUIDE_SLIPPRTSETPAPERID_TITLE];
			return slipPrtSet;
		}

		/// <summary>
		/// DataRowコピー処理（伝票印刷設定クラス⇒ガイド用DataRow）
		/// </summary>
		/// <param name="guideRow">ガイド用DataRow</param>
		/// <param name="slipPrtSet">伝票印刷設定クラス</param>
		/// <remarks>
		/// <br>Note       : 伝票印刷設定クラスからガイド用DataRowへコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		private void CopyToGuideRowFromSlipPrtSet(ref DataRow guideRow, SlipPrtSet slipPrtSet)
		{
			guideRow[GUIDE_DATAINPUTSYSTEM_TITLE] = slipPrtSet.DataInputSystem;						// データ入力システム
            // 2008.06.05 30413 犬飼 既存だと名称設定している箇所が無いので、データ入力システム名の設定する >>>>>>START
			//guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = slipPrtSet.DataInputSystemName;				// データ入力システム名
            switch (slipPrtSet.DataInputSystem)
            {
                case 0:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "共通";
                    break;
                case 1:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "整備";
                    break;
                case 2:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "鈑金";
                    break;
                case 3:
                    guideRow[GUIDE_DATAINPUTSYSTEMNAME_TITLE] = "車販";
                    break;
            }
            // 2008.06.05 30413 犬飼 既存だと名称設定している箇所が無いので、データ入力システム名の設定する <<<<<<END
			guideRow[GUIDE_SLIPPRTKIND_TITLE] = slipPrtSet.SlipPrtKind;								// 伝票印刷種別
            // 2008.06.05 30413 犬飼 ビルドエラーのため、伝票印刷種別名の設定を変更 >>>>>>START
			//guideRow[GUIDE_SLIPPRTKINDNAME_TITLE]
			//	= SlipPrtSet.GetSortedListNm(slipPrtSet.SlipPrtKind, SlipPrtSet._slipPrtKindList);	// 伝票印刷種別名
            switch (slipPrtSet.SlipPrtKind)
            {
                case 10:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "見積書";
                    break;
                case 20:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "指示書";
                    break;
                case 21:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "承り書";
                    break;
                case 30:
                    // 2008.10.17 30413 犬飼 納品書→売上伝票に変更 >>>>>>START
                    //guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "納品書";
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "売上伝票";
                    // 2008.10.17 30413 犬飼 納品書→売上伝票に変更 <<<<<<END
                    break;
                case 40:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "返品伝票";
                    break;
                case 100:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "ワークシート";
                    break;
                case 110:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "ボディ寸法図";
                    break;
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 >>>>>>START
                case 120:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "受注伝票";
                    break;
                case 130:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "貸出伝票";
                    break;
                case 140:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "見積伝票";
                    break;
                case 150:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "在庫移動伝票";
                    break;
                case 160:
                    guideRow[GUIDE_SLIPPRTKINDNAME_TITLE] = "ＵＯＥ伝票";
                    break;
                // 2008.10.17 30413 犬飼 伝票印刷種別の追加 <<<<<<END
            }
            // 2008.06.05 30413 犬飼 ビルドエラーのため、伝票印刷種別名の設定を変更 <<<<<<END
			guideRow[GUIDE_SLIPPRTSETPAPERID_TITLE] = slipPrtSet.SlipPrtSetPaperId;					// 伝票印刷設定用帳票ID
			guideRow[GUIDE_SLIPCOMMENT_TITLE] = slipPrtSet.SlipComment;								// 伝票コメント
		}
		#endregion

		#region 各種変換
		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>string型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public static string NullChgStr(object obj)
		{
			string ret;
			try
			{
				if (obj == null)
				{
					ret = "";
				}
				else
				{
					ret = obj.ToString();
				}
			}
			catch
			{
				ret = "";
			}
			return ret;
		}

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>int型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.17</br>
		/// </remarks>
		public static int NullChgInt(object obj)
		{
			int ret;
			try
			{
				if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
				{
					ret = 0;
				}
				else
				{
					ret = Convert.ToInt32(obj);
				}
			}
			catch
			{
				ret = 0;
			}
			return ret;
		}

        /// <summary>
        /// プリンタ管理情報取得
        /// </summary>
        /// <param name="dbList">ＤＢリスト</param>
        /// <param name="xmlList">ＸＭＬリスト</param>
        /// <returns>ArrayList型データ</returns>
        /// <remarks>
        /// <br>Note       : XMLリストからプリンタ管理情報を取得(SFCMN00721Bから置き換え)</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public static ArrayList MergeSlipPrtSet(ArrayList dbList, ArrayList xmlList)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i != dbList.Count; i++)
            {
                SlipPrtSetWork work = (SlipPrtSetWork)dbList[i];
                if (work != null)
                {
                    for (int j = 0; j != xmlList.Count; j++)
                    {
                        SlipPrtSetWork work2 = (SlipPrtSetWork)xmlList[j];
                        if ((work2 != null)
                            && (work.EnterpriseCode.Equals(work2.EnterpriseCode))
                            && (work.DataInputSystem.Equals(work2.DataInputSystem))
                            && (work.SlipPrtKind.Equals(work2.SlipPrtKind))
                            && (work.SlipPrtSetPaperId.Equals(work2.SlipPrtSetPaperId))
                            && (work.FileHeaderGuid.Equals(work2.FileHeaderGuid)))
                        {
                            work.TopMargin = work2.TopMargin;
                            work.BottomMargin = work2.BottomMargin;
                            work.LeftMargin = work2.LeftMargin;
                            work.RightMargin = work2.RightMargin;
                        }
                    }
                    list.Add(work);
                }
            }
            return list;
        }
        #endregion

        //----- h.ueno add---------- end   2007.12.17
    }
}