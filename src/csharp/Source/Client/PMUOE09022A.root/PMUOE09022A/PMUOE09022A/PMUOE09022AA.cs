//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE発注先設定
// プログラム概要   : UOE発注先マスタテーブルのアクセス制御を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 犬飼
// 作 成 日  2008/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 修 正 日  2008/10/21  修正内容 : 通信アセンブリIDによって変わる入力項目を取得できるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/01  修正内容 : ホンダe-Parts項目追加に伴う修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.1】
//                                  トヨタ電子カタログで使用する送信・受信データの保存場所を設定する
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 修 正 日  2010/03/08  修正内容 : PM1006
//                                  UOE発注データを登録する機能で入力制御の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内
// 修 正 日  2010/04/06  修正内容 : 品番検索速度アップ対応
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : jiangk
// 修 正 日  2010/04/23  修正内容 : PM1007C
//                                  UOE発注データを登録する機能で入力制御の対応
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 譚洪
// 作 成 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号 10607734-00 作成担当 : 施ヘイ中
// 作 成 日  2011/01/28  修正内容 : 回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更
//----------------------------------------------------------------------------//
// 管理番号 10607734-01 作成担当 : liyp
// 作 成 日  2011/03/01 修正内容 : 回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更
//----------------------------------------------------------------------------//
// 管理番号 10702591-00 作成担当 : 施ヘイ中
// 作 成 日  2011/05/10  修正内容 : マッダ制御用情報への項目追加
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : LIUSY
// 修 正 日  2011/11/24  修正内容 : PM1113A 卸NET-WEB対応に伴う仕様追加
//                                  ※2012/04/16　マージ作業
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : yangmj
// 作 成 日  2011/12/15 修正内容 : Redmine#27386トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : 高川 悟
// 作 成 日  2012/09/10 修正内容 : BL管理ユーザーコード対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE発注先マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE発注先マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.26</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.10.21 21024　佐々木 健</br>
    /// <br>           : 通信アセンブリIDによって変わる入力項目を取得できるように修正</br>
    /// <br>           : 2009/06/01 照田 貴志　ホンダe-Parts項目追加に伴う修正</br>
    /// <br>UpdateNote : 2009/12/29 xuxh</br>
    /// <br>           : 【要件No.1】トヨタ電子カタログで使用する送信・受信データの保存場所を設定する</br>
    /// <br>UpdateNote : 2010/03/08 楊明俊</br>
    /// <br>           : PM1006 UOE発注データを登録する機能で入力制御の対応</br>
	/// <br>UpdateNote : 2010/04/23 jiangk</br>
	/// <br>           : PM1007C UOE発注データを登録する機能で入力制御の対応</br>
    /// <br>UpdateNote : 2010/05/07 高峰</br>
    /// <br>           : PM1008 明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote : 2010/12/31 譚洪</br>
    /// <br>           : UOE自動化改良</br>
    /// <br>UpdateNote : 2011/01/28 施ヘイ中</br>
    /// <br>           :（トヨタWEBUOE用自動連携用の設定区分）の変更</br>
    /// <br>UpdateNote : 2011/03/01 liyp</br>
    /// <br>             回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
    /// <br>UpdateNote : 2011/05/10 施ヘイ中</br>
    /// <br>           : マッダ制御用情報への項目追加</br>
    /// <br>UpdateNote : 2013/04/15 donggy</br>
    /// <br>管理番号   : 10900691-00 2013/05/15配信分</br>
    /// <br>             Redmine#35020　検索見積」の「発注検索画面」のレスポンス低下のトリガーの排除</br>
    /// </remarks>
    public class UOESupplierAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        // UOE発注先マスタ
        private IUOESupplierDB _iUOESupplierDB = null;

        // 2008.10.21 Add >>>
        // 入力制御用のディクショナリ
        private static Dictionary<string, UOEInputControlInfo> uOESupplierInputInfoDictionary;
        // 2008.10.21 Add <<<

        // 2008.11.05 30413 犬飼 UOEガイド名称アクセスクラスの追加 >>>>>>START
        UOEGuideNameAcs _uoeGuideNameAcs;
        // 2008.11.05 30413 犬飼 UOEガイド名称アクセスクラスの追加 <<<<<<END

        // -- ADD 2010/04/06 --------------------------------->>>
        //キャッシュ用
        private static Dictionary<string, UOESupplier> _uOESupplierDic;
        // -- ADD 2010/04/06 ---------------------------------<<<

        #endregion


        #region Private Struct
        // 2008.10.21 Add >>>
        # region [UOE入力制御用情報]
        /// <summary>
        /// UOE入力制御用情報
        /// </summary>
        private struct UOEInputControlInfo
        {
            /// <summary>リマーク１入力可否</summary>
            private bool _enabledUOERemark1;
            /// <summary>リマーク２入力可否</summary>
            private bool _enabledUOERemark2;
            /// <summary>リマーク１入力桁数</summary>
            private int _maxLengthUOERemark1;
            /// <summary>リマーク２入力桁数</summary>
            private int _maxLengthUOERemark2;
            /// <summary>納品区分入力可否</summary>
            private bool _enabledDeliveredGoodsDiv;
            /// <summary>フォロー納品区分入力可否</summary>
            private bool _enabledFollowDeliGoodsDiv;
            /// <summary>指定拠点入力可否</summary>
            private bool _enabledUOEResvdSection;
            /// <summary>純正区分</summary>
            private PureCodeDiv _pureCode;

            /// <summary>リマーク１入力可否</summary>
            public bool EnabledUOERemark1
            {
                get { return _enabledUOERemark1; }
                set { _enabledUOERemark1 = value; }
            }
            /// <summary>リマーク２入力可否</summary>
            public bool EnabledUOERemark2
            {
                get { return _enabledUOERemark2; }
                set { _enabledUOERemark2 = value; }
            }
            /// <summary>リマーク１入力桁数</summary>
            public int MaxLengthUOERemark1
            {
                get { return _maxLengthUOERemark1; }
                set { _maxLengthUOERemark1 = value; }
            }
            /// <summary>リマーク２入力桁数</summary>
            public int MaxLengthUOERemark2
            {
                get { return _maxLengthUOERemark2; }
                set { _maxLengthUOERemark2 = value; }
            }
            /// <summary>納品区分入力可否</summary>
            public bool EnabledDeliveredGoodsDiv
            {
                get { return _enabledDeliveredGoodsDiv; }
                set { _enabledDeliveredGoodsDiv = value; }
            }
            /// <summary>フォロー納品区分入力可否</summary>
            public bool EnabledFollowDeliGoodsDiv
            {
                get { return _enabledFollowDeliGoodsDiv; }
                set { _enabledFollowDeliGoodsDiv = value; }
            }

            /// <summary>指定拠点入力可否</summary>
            public bool EnabledUOEResvdSection
            {
                get { return _enabledUOEResvdSection; }
                set { _enabledUOEResvdSection = value; }
            }

            /// <summary>純正区分</summary>
            public PureCodeDiv PureCodeDiv
            {
                get { return _pureCode; }
                set { _pureCode = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enabledUOERemark1">リマーク１入力可否</param>
            /// <param name="enabledUOERemark2">リマーク２入力可否</param>
            /// <param name="enabledDeliveredGoodsDiv">納品区分入力可否</param>
            /// <param name="enabledFollowDeliGoodsDiv">フォロー納品区分入力可否</param>
            /// <param name="enabledUOEResvdSection">担当拠点入力可否</param>
            /// <param name="maxLengthUOERemark1">リマーク１入力桁数</param>
            /// <param name="maxLengthUOERemark2">リマーク２入力桁数</param>
            /// <param name="pureCode">純正区分</param>
            public UOEInputControlInfo(bool enabledUOERemark1, bool enabledUOERemark2, bool enabledDeliveredGoodsDiv, bool enabledFollowDeliGoodsDiv, bool enabledUOEResvdSection, int maxLengthUOERemark1, int maxLengthUOERemark2,PureCodeDiv pureCode)
            {
                _enabledUOERemark1 = enabledUOERemark1;
                _enabledUOERemark2 = enabledUOERemark2;
                _maxLengthUOERemark1 = maxLengthUOERemark1;
                _maxLengthUOERemark2 = maxLengthUOERemark2;
                _enabledDeliveredGoodsDiv = enabledDeliveredGoodsDiv;
                _enabledFollowDeliGoodsDiv = enabledFollowDeliGoodsDiv;
                _enabledUOEResvdSection = enabledUOEResvdSection;
                _pureCode = pureCode;
            }
        }
        # endregion
        // 2008.10.21 Add <<<

        #endregion


        #region Constructor

        /// <summary>
        /// UOE発注先マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public UOESupplierAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iUOESupplierDB = (IUOESupplierDB)MediationUOESupplierDB.GetUOESupplierDB();

                // 2008.11.05 30413 犬飼 UOEガイド名称アクセスクラスの追加 >>>>>>START
                this._uoeGuideNameAcs = new UOEGuideNameAcs();
                // 2008.11.05 30413 犬飼 UOEガイド名称アクセスクラスの追加 <<<<<<END
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESupplierDB = null;
            }
        }

        // 2008.10.21 Add >>>
        /// <summary>
        /// スタティック コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2010/03/08 楊明俊 日産Web-UOE入力制御の対応</br>
		/// <br>UpdateNote : 2010/04/23 jiangk 三菱Web-UOE入力制御の対応</br>
        /// <br>UpdateNote : 2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
        /// <br>UpdateNote : 2011/01/28 施ヘイ中 PM1102A  トヨタWEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/03/01 liyp PM1103A  回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更</br>
        /// <br>UpdateNote : 2011/05/10 施ヘイ中 PM1105A  マッダ制御用情報への項目追加</br>
        /// </remarks>
        static UOESupplierAcs()
        {
            uOESupplierInputInfoDictionary = new Dictionary<string, UOEInputControlInfo>();

            // トヨタ
            uOESupplierInputInfoDictionary.Add("0102", new UOEInputControlInfo(true, true, true, true, true, 8, 10, PureCodeDiv.Pure));

            // ニッサン
            uOESupplierInputInfoDictionary.Add("0202", new UOEInputControlInfo(true, true, true, false, true, 10, 10, PureCodeDiv.Pure));

            // ミツビシ
            uOESupplierInputInfoDictionary.Add("0301", new UOEInputControlInfo(true, false, true, false, true, 8, 0, PureCodeDiv.Pure));

            // 旧マツダ
            uOESupplierInputInfoDictionary.Add("0401", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Pure));

            // 新マツダ
            uOESupplierInputInfoDictionary.Add("0402", new UOEInputControlInfo(true, false, true, false, true, 20, 0, PureCodeDiv.Pure));

            // ホンダ
            uOESupplierInputInfoDictionary.Add("0501", new UOEInputControlInfo(true, false, true, false, true, 15, 0, PureCodeDiv.Pure));

            // ホンダ(e-Parts)
            //uOESupplierInputInfoDictionary.Add("0502", new UOEInputControlInfo(true, false, true, false, true, 15, 0, PureCodeDiv.Pure));     //DEL 2009/06/01
            uOESupplierInputInfoDictionary.Add("0502", new UOEInputControlInfo(true, false, false, false, false, 15, 0, PureCodeDiv.Pure));     //ADD 2009/06/01

            // スバル
            uOESupplierInputInfoDictionary.Add("0801", new UOEInputControlInfo(true, true, true, false, true, 8, 10, PureCodeDiv.Pure));

            // 優良
            uOESupplierInputInfoDictionary.Add("1001", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));

            // トヨタ電子カタログ連動項目
            uOESupplierInputInfoDictionary.Add("0103", new UOEInputControlInfo(true, false, true, true, true, 8, 10, PureCodeDiv.Pure)); // ADD 2009/12/29 xuxh

            // ---ADD 2010/03/08 ---------------------------------------->>>>>
            // 日産Web-UOE連動項目
            uOESupplierInputInfoDictionary.Add("0203", new UOEInputControlInfo(false, false, false, false, false, 0, 0, PureCodeDiv.Pure));
            // ---ADD 2010/03/08 ----------------------------------------<<<<<

            // ---ADD 2010/12/31 ---------------------------------------->>>>>
            // 日産Web-UOE連動項目（自動の場合）
            uOESupplierInputInfoDictionary.Add("0204", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Pure));

            // 三菱Web-UOE連動項目（自動の場合）
            uOESupplierInputInfoDictionary.Add("0303", new UOEInputControlInfo(true, false, true, false, false, 15, 0, PureCodeDiv.Pure));
            // ---ADD 2010/12/31 ----------------------------------------<<<<<

            // ---ADD 2011/01/28 ---------------------------------------->>>>>
            // トヨタ電子Web-UOE連動項目（自動の場合）
            uOESupplierInputInfoDictionary.Add("0104", new UOEInputControlInfo(true, true, true, true, true, 8, 10, PureCodeDiv.Pure)); 
            // ---ADD 2011/01/28 ----------------------------------------<<<<<
            // ---ADD 2011/03/01 ---------------------------------------->>>>>
            // 日産Web-UOE連動項目（自動の場合）
            uOESupplierInputInfoDictionary.Add("0205", new UOEInputControlInfo(true, false, true, false, true, 10, 10, PureCodeDiv.Pure));
            // 日産Web-UOE連動項目（自動の場合）
            uOESupplierInputInfoDictionary.Add("0206", new UOEInputControlInfo(true, true, true, false, true, 10, 10, PureCodeDiv.Pure)); 
            // ---ADD 2011/03/01 ----------------------------------------<<<<<
			// ---ADD 2010/04/23 ---------------------------------------->>>>>
            // 三菱Web-UOE連動項目
			uOESupplierInputInfoDictionary.Add("0302", new UOEInputControlInfo(false, false, false, false, false, 0, 0, PureCodeDiv.Pure));
			// ---ADD 2010/04/23 ----------------------------------------<<<<<
            // ---ADD 2010/05/07 ---------------------------------------->>>>>
            // 明治UOE-WEB連動項目
            uOESupplierInputInfoDictionary.Add("1004", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // マツダUOE-WEB連動項目
            uOESupplierInputInfoDictionary.Add("0403", new UOEInputControlInfo(true, false, false, false, false, 20, 0, PureCodeDiv.Pure));
            // ---ADD 2011/05/10 ----------------------------------------<<<<<
            // ---ADD 2011/11/24----------------------------------------<<<<<
            // 卸NET-WEB
            uOESupplierInputInfoDictionary.Add("1003", new UOEInputControlInfo(true, false, true, false, true, 10, 0, PureCodeDiv.Prime));
            // ---ADD 2011/11/24----------------------------------------<<<<<
            // 初期値
            uOESupplierInputInfoDictionary.Add(string.Empty, new UOEInputControlInfo(true, true, true, false, true, 20, 20, PureCodeDiv.Pure));
        }
        // 2008.10.21 Add <<<

        #endregion

        #region Public Enums
        /// <summary>
        /// 純正区分
        /// </summary>
        public enum PureCodeDiv:int
        {
            Pure = 0,
            Prime=1
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOESupplierDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOE発注先マスタ読み込み処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="uoeSupplierCd">UOE発注先コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先情報を読み込みます。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Read(out UOESupplier uoeSupplier, string enterpriseCode, int uoeSupplierCd, string sectionCode)
        {
            try
            {
                // キー情報の設定
                uoeSupplier = null;
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                uoeSupplierWork.EnterpriseCode = enterpriseCode;
                uoeSupplierWork.UOESupplierCd = uoeSupplierCd;
                uoeSupplierWork.SectionCode = sectionCode;
                // UOE発注先ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeSupplierWork;

                // ADD 2010/07/22 ----->>>>
                if (this._iUOESupplierDB == null)
                {
                    this._iUOESupplierDB = (IUOESupplierDB)MediationUOESupplierDB.GetUOESupplierDB();
                }
                // ADD 2010/07/22 -----<<<<

                //UOE発注先マスタ読み込み
                int status = this._iUOESupplierDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // 読み込み結果をUOE発注先ワーカークラスに設定
                    UOESupplierWork wkUOESupplierWork = (UOESupplierWork)paraObj;
                    // UOE発注先ワーカークラスからUOE発注先クラスにコピー
                    uoeSupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                }
                // ADD 2010/07/22 ----->>>>
                else
                {
                    return status;
                }
                // ADD 2010/07/22 -----<<<<

                // -- ADD 2010/04/06 ----------->>>
                //取得情報をキャッシュ(未登録の場合もキャッシュする。発注先未設定のユーザーへの対応)
                UpdateCache(uoeSupplier);
                // -- ADD 2010/04/06 -----------<<<

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESupplierDB = null;
                //通信エラーは-1を戻す
                uoeSupplier = null;
                return -1;
            }
        }

        // -- ADD 2010/04/06 ------------------------>>>
        /// <summary>
        /// UOE発注先マスタ読み込み処理（キャッシュ有）
        /// </summary>
        /// <param name="uoeSupplier"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="uoeSupplierCd"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadCache(out UOESupplier uoeSupplier, string enterpriseCode, int uoeSupplierCd, string sectionCode)
        {
            uoeSupplier = null;

            //パラメータが不正の場合は取得処理は行わない
            if (string.IsNullOrEmpty(enterpriseCode) || uoeSupplierCd == 0 || string.IsNullOrEmpty(sectionCode))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // キャッシュから取得
            int status = this.GetFromCache(out uoeSupplier, enterpriseCode, uoeSupplierCd, sectionCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.Read(out uoeSupplier, enterpriseCode, uoeSupplierCd, sectionCode);
            }

            return status;
        }
        // -- ADD 2010/04/06 ------------------------<<<

        /// <summary>
        /// UOE発注先シリアライズ処理
        /// </summary>
        /// <param name="uoeSupplier">シリアライズ対象UOE発注先クラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOE発注先のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void Serialize(UOESupplier uoeSupplier, string fileName)
        {
            // UOE発注先クラスからUOE発注先ワーカークラスにメンバコピー
            UOESupplierWork uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);

            // UOE発注先ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeSupplierWork, fileName);
        }

        /// <summary>
        /// UOE発注先Listシリアライズ処理
        /// </summary>
        /// <param name="uoeSupplierList">シリアライズ対象UOE発注先Listクラス</param>
        /// <param name="fileName">シリアライズファイル名</param>
        /// <remarks>
        /// <br>Note       : UOE発注先List情報のシリアライズを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeSupplierList, string fileName)
        {
            UOESupplierWork[] uoeSupplierWorks = new UOESupplierWork[uoeSupplierList.Count];

            for (int i = 0; i < uoeSupplierList.Count; i++)
            {
                uoeSupplierWorks[i] = CopyToUOESupplierWorkFromUOESupplier((UOESupplier)uoeSupplierList[i]);
            }

            // UOE発注先ワーカークラスをシリアライズ
            XmlByteSerializer.Serialize(uoeSupplierWorks, fileName);
        }

        /// <summary>
        /// UOE発注先クラスデシリアライズ処理
        /// </summary>
        /// <param name="fileName">デシリアライズ対象XMLファイルフルパス</param>
        /// <returns>UOE発注先クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先クラスをデシリアライズします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public UOESupplier Deserialize(string fileName)
        {
            UOESupplier uoeSupplier = null;

            // ファイル名を渡してUOE発注先ワーククラスをデシリアライズする
            UOESupplierWork uoeSupplierWork = (UOESupplierWork)XmlByteSerializer.Deserialize(fileName, typeof(UOESupplierWork));

            // デシリアライズ結果をUOE発注先クラスへコピー
            if (uoeSupplierWork != null) uoeSupplier = CopyToUOESupplierFromUOESupplierWork(uoeSupplierWork);

            return uoeSupplier;
        }

        /// <summary>
        /// UOE発注先登録・更新処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先の登録・更新を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Write(ref UOESupplier uoeSupplier)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();
            ArrayList paraList = new ArrayList();

            // UOE発注先クラスからUOE発注先ワーククラスにメンバコピー
            uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);

            // UOE発注先の登録・更新情報を設定
            paraList.Add(uoeSupplierWork);

            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOE発注先書き込み
                status = this._iUOESupplierDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeSupplier = new UOESupplier();

                    // UOE発注先ワーククラスからUOE発注先クラスにメンバコピー
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iUOESupplierDB = null;
                // 通信エラーは-1を戻す
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOE発注先論理削除処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先情報の論理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref UOESupplier uoeSupplier)
        {
            int status = 0;

            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE発注先クラスからUOE発注先ワーククラスにメンバコピー
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE発注先の論理削除情報を設定
                paraList.Add(uoeSupplierWork);

                object paraObj = paraList;

                // UOE発注先クラス論理削除
                status = this._iUOESupplierDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    
                    uoeSupplier = new UOESupplier();
                    // UOE発注先ワーククラスからUOE発注先クラスにメンバコピー
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE発注先物理削除処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先情報の物理削除を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Delete(UOESupplier uoeSupplier)
        {
            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE発注先クラスからUOE発注先ワーククラスにメンバコピー
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE発注先の物理削除情報を設定
                paraList.Add(uoeSupplierWork);

                object paraObj = paraList;

                // UOE発注先物理削除
                int status = this._iUOESupplierDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE発注先論理削除復活処理
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先名称オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先情報の復活を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int Revival(ref UOESupplier uoeSupplier)
        {
            try
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                ArrayList paraList = new ArrayList();

                // UOE発注先クラスからUOE発注先ワーククラスにメンバコピー
                uoeSupplierWork = CopyToUOESupplierWorkFromUOESupplier(uoeSupplier);
                // UOE発注先の復活情報を設定
                paraList.Add(uoeSupplierWork);

                object paraobj = paraList;

                // 復活処理
                int status = this._iUOESupplierDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;

                    uoeSupplier = new UOESupplier();
                    // UOE発注先ワーククラスからUOE発注先クラスにメンバコピー
                    uoeSupplier = this.CopyToUOESupplierFromUOESupplierWork((UOESupplierWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iUOESupplierDB = null;
                //通信エラーは-1を戻す
                return -1;
            }
        }

        /// <summary>
        /// UOE発注先マスタ検索処理（DataSet用）
        /// </summary>
        /// <param name="ds">取得結果格納用DataSet</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : 取得結果をDataSetで返します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode, string sectionCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // UOE発注先マスタサーチ
            status = SearchAll(out retList, enterpriseCode, sectionCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [全て] --- //
            // そのまま全件返す
            foreach (UOESupplier wkUOESupplier in wkList)
            {
                if (wkUOESupplier.LogicalDeleteCode == 0)
                {
                    // 2008.12.05 30413 犬飼 重複キーのチェックを追加 >>>>>>START
                    //wkSort.Add(wkUOESupplier.UOESupplierCd, wkUOESupplier);
                    if (!wkSort.ContainsKey(wkUOESupplier.UOESupplierCd))
                    {
                        wkSort.Add(wkUOESupplier.UOESupplierCd, wkUOESupplier);
                    }
                    // 2008.12.05 30413 犬飼 重複キーのチェックを追加 <<<<<<END
                }
            }

            UOESupplier[] uoeSuppliers = new UOESupplier[wkSort.Count];

            // データを元に戻す
            for (int i = 0; i < wkSort.Count; i++)
            {
                uoeSuppliers[i] = (UOESupplier)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(uoeSuppliers);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// UOE発注先検索処理（論理削除含まない）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先の検索処理を行います。論理削除データは抽出対象に含まれません。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE発注先マスタ（論理削除含まない）
            status = SearchUOESupplier(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOE発注先検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE発注先マスタ
            status = SearchUOESupplier(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode ,ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        // --- ADD donggy 2013/04/15 for Redmine#35020 --->>>>>>>>>
        /// <summary>
        /// UOE発注先検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="uoeSupplierWorkList">指定発注リスト</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定UOE発注先の検索処理を行います。</br>
        /// <br>Programmer : donggy</br>
        /// <br>Date       : 2013/04/15</br>
        /// </remarks>
        public int SearchBySupplierCds(out ArrayList retList, List<UOESupplier> uoeSupplierList)
        {
            List<UOESupplierWork> uoeSupplierWorkList = new List<UOESupplierWork>();
            // 検索条件リストを作成します
            foreach (UOESupplier uoeSupplier in uoeSupplierList)
            {
                UOESupplierWork uoeSupplierWork = new UOESupplierWork();
                uoeSupplierWork.SectionCode = uoeSupplier.SectionCode;
                uoeSupplierWork.EnterpriseCode = uoeSupplier.EnterpriseCode;
                uoeSupplierWork.UOESupplierCd = uoeSupplier.UOESupplierCd;
                uoeSupplierWorkList.Add(uoeSupplierWork);
            }
            int status = 0;
            retList = new ArrayList();
            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // UOE発注先ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeSupplierWorkList;

                // 指定発注先コードの情報の一括読込
                status = this._iUOESupplierDB.Search(ref retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESupplierWork wkUOESupplierWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                UOESupplier wkUOESupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkUOESupplier);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            return status;
        }
        // --- ADD donggy 2013/04/15 for Redmine#35020 ---<<<<<<<<<
        public int GetUOEGuideData(out ArrayList retList, UOEGuideName uoeGuideName)
        {
            return this.SearchUOEGuideName(out retList, uoeGuideName);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（UOE発注先ワーククラス⇒UOE発注先クラス）
        /// </summary>
        /// <param name="uoeSupplierWork">UOE発注先ワーククラス</param>
        /// <returns>UOE発注先クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先ワーククラスからUOE発注先クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// <br>UpdateNote : 2011/12/15 yangmj</br>
        /// <br>           : Redmine#27386トヨタUOEWebタクティー品番の発注対応</br>
        /// </remarks>
        private UOESupplier CopyToUOESupplierFromUOESupplierWork(UOESupplierWork uoeSupplierWork)
        {
            UOESupplier uoeSupplier = new UOESupplier();

            uoeSupplier.CreateDateTime = uoeSupplierWork.CreateDateTime;
            uoeSupplier.UpdateDateTime = uoeSupplierWork.UpdateDateTime;
            uoeSupplier.EnterpriseCode = uoeSupplierWork.EnterpriseCode;
            uoeSupplier.FileHeaderGuid = uoeSupplierWork.FileHeaderGuid;
            uoeSupplier.UpdEmployeeCode = uoeSupplierWork.UpdEmployeeCode;
            uoeSupplier.UpdAssemblyId1 = uoeSupplierWork.UpdAssemblyId1;
            uoeSupplier.UpdAssemblyId2 = uoeSupplierWork.UpdAssemblyId2;
            uoeSupplier.LogicalDeleteCode = uoeSupplierWork.LogicalDeleteCode;
            uoeSupplier.SectionCode = uoeSupplierWork.SectionCode;                      // 拠点コード

            uoeSupplier.UOESupplierCd = uoeSupplierWork.UOESupplierCd;                  // UOE発注先コード
            uoeSupplier.UOESupplierName = uoeSupplierWork.UOESupplierName;              // UOE発注先名称
            uoeSupplier.GoodsMakerCd = uoeSupplierWork.GoodsMakerCd;                    // 商品メーカーコード
            uoeSupplier.TelNo = uoeSupplierWork.TelNo;                                  // 電話番号
            uoeSupplier.UOETerminalCd = uoeSupplierWork.UOETerminalCd;                  // UOE端末コード
            uoeSupplier.UOEHostCode = uoeSupplierWork.UOEHostCode;                      // UOEホストコード
            uoeSupplier.UOEConnectPassword = uoeSupplierWork.UOEConnectPassword;        // UOE接続パスワード
            uoeSupplier.UOEConnectUserId = uoeSupplierWork.UOEConnectUserId;            // UOE接続ユーザID
            uoeSupplier.UOEIDNum = uoeSupplierWork.UOEIDNum;                            // UOEID番号
            uoeSupplier.CommAssemblyId = uoeSupplierWork.CommAssemblyId;                // 通信アセンブリID
            uoeSupplier.ConnectVersionDiv = uoeSupplierWork.ConnectVersionDiv;          // 接続バージョン区分
            uoeSupplier.UOEShipSectCd = uoeSupplierWork.UOEShipSectCd;                  // UOE出庫拠点コード
            uoeSupplier.UOESalSectCd = uoeSupplierWork.UOESalSectCd;                    // UOE売上拠点コード
            uoeSupplier.UOEReservSectCd = uoeSupplierWork.UOEReservSectCd;              // UOE指定拠点コード
            uoeSupplier.ReceiveCondition = uoeSupplierWork.ReceiveCondition;            // 受信状況
            uoeSupplier.SubstPartsNoDiv = uoeSupplierWork.SubstPartsNoDiv;              // 代替品番区分
            uoeSupplier.PartsNoPrtCd = uoeSupplierWork.PartsNoPrtCd;                    // 品番印刷区分
            uoeSupplier.ListPriceUseDiv = uoeSupplierWork.ListPriceUseDiv;              // 定価使用区分
            uoeSupplier.StockSlipDtRecvDiv = uoeSupplierWork.StockSlipDtRecvDiv;        // 仕入データ受信区分
            uoeSupplier.CheckCodeDiv = uoeSupplierWork.CheckCodeDiv;                    // チェックコード区分
            uoeSupplier.BusinessCode = uoeSupplierWork.BusinessCode;                    // 業務区分
            uoeSupplier.UOEResvdSection = uoeSupplierWork.UOEResvdSection;              // UOE指定拠点
            uoeSupplier.EmployeeCode = uoeSupplierWork.EmployeeCode;                    // 従業員コード
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //uoeSupplier.DeliveredGoodsDiv = uoeSupplierWork.DeliveredGoodsDiv;          // 納品区分
            uoeSupplier.UOEDeliGoodsDiv = uoeSupplierWork.UOEDeliGoodsDiv;              // UOE納品区分
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            uoeSupplier.BoCode = uoeSupplierWork.BoCode;                                // BO区分
            uoeSupplier.UOEOrderRate = uoeSupplierWork.UOEOrderRate;                    // UOE発注レート
            uoeSupplier.EnableOdrMakerCd1 = uoeSupplierWork.EnableOdrMakerCd1;          // 発注可能メーカーコード１
            uoeSupplier.EnableOdrMakerCd2 = uoeSupplierWork.EnableOdrMakerCd2;          // 発注可能メーカーコード２
            uoeSupplier.EnableOdrMakerCd3 = uoeSupplierWork.EnableOdrMakerCd3;          // 発注可能メーカーコード３
            uoeSupplier.EnableOdrMakerCd4 = uoeSupplierWork.EnableOdrMakerCd4;          // 発注可能メーカーコード４
            uoeSupplier.EnableOdrMakerCd5 = uoeSupplierWork.EnableOdrMakerCd5;          // 発注可能メーカーコード５
            uoeSupplier.EnableOdrMakerCd6 = uoeSupplierWork.EnableOdrMakerCd6;          // 発注可能メーカーコード６

            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            uoeSupplier.OdrPrtsNoHyphenCd1 = uoeSupplierWork.OdrPrtsNoHyphenCd1;          // 発注可能メーカーコード１
            uoeSupplier.OdrPrtsNoHyphenCd2 = uoeSupplierWork.OdrPrtsNoHyphenCd2;          // 発注可能メーカーコード２
            uoeSupplier.OdrPrtsNoHyphenCd3 = uoeSupplierWork.OdrPrtsNoHyphenCd3;          // 発注可能メーカーコード３
            uoeSupplier.OdrPrtsNoHyphenCd4 = uoeSupplierWork.OdrPrtsNoHyphenCd4;          // 発注可能メーカーコード４
            uoeSupplier.OdrPrtsNoHyphenCd5 = uoeSupplierWork.OdrPrtsNoHyphenCd5;          // 発注可能メーカーコード５
            uoeSupplier.OdrPrtsNoHyphenCd6 = uoeSupplierWork.OdrPrtsNoHyphenCd6;          // 発注可能メーカーコード６
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<

            uoeSupplier.instrumentNo = uoeSupplierWork.instrumentNo;                    // 機器番号
            uoeSupplier.UOETestMode = uoeSupplierWork.UOETestMode;                      // UOEテストモード
            uoeSupplier.UOEItemCd = uoeSupplierWork.UOEItemCd;                          // UOEアイテムコード
            uoeSupplier.HondaSectionCode = uoeSupplierWork.HondaSectionCode;            // ホンダ担当拠点
            uoeSupplier.AnswerSaveFolder = uoeSupplierWork.AnswerSaveFolder;            // 回答保存フォルダ
            uoeSupplier.MazdaSectionCode = uoeSupplierWork.MazdaSectionCode;            // マツダ自拠点コード
            uoeSupplier.EmergencyDiv = uoeSupplierWork.EmergencyDiv;                    // 緊急区分
            uoeSupplier.DaihatsuOrdreDiv = uoeSupplierWork.DaihatsuOrdreDiv;            // 発注手配区分（ダイハツ）
            uoeSupplier.SupplierCd = uoeSupplierWork.SupplierCd;                        // 仕入先コード
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            uoeSupplier.UOELoginUrl = uoeSupplierWork.UOELoginUrl;                      // ログイン用URL
            uoeSupplier.UOEOrderUrl = uoeSupplierWork.UOEOrderUrl;                      // 発注用URL
            uoeSupplier.UOEStockCheckUrl = uoeSupplierWork.UOEStockCheckUrl;            // 在庫確認用URL
            uoeSupplier.UOEForcedTermUrl = uoeSupplierWork.UOEForcedTermUrl;            // 強制終了用URL
            uoeSupplier.InqOrdDivCd = uoeSupplierWork.InqOrdDivCd;                      // 接続種別
            uoeSupplier.LoginTimeoutVal = uoeSupplierWork.LoginTimeoutVal;              // ログイン認証時間
            uoeSupplier.EPartsUserId = uoeSupplierWork.EPartsUserId;                    // ユーザID
            uoeSupplier.EPartsPassWord = uoeSupplierWork.EPartsPassWord;                // パスワード
            // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            uoeSupplier.BLMngUserCode = uoeSupplierWork.BLMngUserCode;                  // BL管理ユーザーコード
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            return uoeSupplier;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UOE発注先クラス⇒UOE発注先ワーククラス）
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先ワーククラス</param>
        /// <returns>UOE発注先クラス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先クラスからUOE発注先ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private UOESupplierWork CopyToUOESupplierWorkFromUOESupplier(UOESupplier uoeSupplier)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            uoeSupplierWork.CreateDateTime = uoeSupplier.CreateDateTime;
            uoeSupplierWork.UpdateDateTime = uoeSupplier.UpdateDateTime;
            uoeSupplierWork.EnterpriseCode = uoeSupplier.EnterpriseCode;
            uoeSupplierWork.FileHeaderGuid = uoeSupplier.FileHeaderGuid;
            uoeSupplierWork.UpdEmployeeCode = uoeSupplier.UpdEmployeeCode;
            uoeSupplierWork.UpdAssemblyId1 = uoeSupplier.UpdAssemblyId1;
            uoeSupplierWork.UpdAssemblyId2 = uoeSupplier.UpdAssemblyId2;
            uoeSupplierWork.LogicalDeleteCode = uoeSupplier.LogicalDeleteCode;
            uoeSupplierWork.SectionCode = uoeSupplier.SectionCode;                      // 拠点コード

            uoeSupplierWork.UOESupplierCd = uoeSupplier.UOESupplierCd;                  // UOE発注先コード
            uoeSupplierWork.UOESupplierName = uoeSupplier.UOESupplierName;              // UOE発注先名称
            uoeSupplierWork.GoodsMakerCd = uoeSupplier.GoodsMakerCd;                    // 商品メーカーコード
            uoeSupplierWork.TelNo = uoeSupplier.TelNo;                                  // 電話番号
            uoeSupplierWork.UOETerminalCd = uoeSupplier.UOETerminalCd;                  // UOE端末コード
            uoeSupplierWork.UOEHostCode = uoeSupplier.UOEHostCode;                      // UOEホストコード
            uoeSupplierWork.UOEConnectPassword = uoeSupplier.UOEConnectPassword;        // UOE接続パスワード
            uoeSupplierWork.UOEConnectUserId = uoeSupplier.UOEConnectUserId;            // UOE接続ユーザID
            uoeSupplierWork.UOEIDNum = uoeSupplier.UOEIDNum;                            // UOEID番号
            uoeSupplierWork.CommAssemblyId = uoeSupplier.CommAssemblyId;                // 通信アセンブリID
            uoeSupplierWork.ConnectVersionDiv = uoeSupplier.ConnectVersionDiv;          // 接続バージョン区分
            uoeSupplierWork.UOEShipSectCd = uoeSupplier.UOEShipSectCd;                  // UOE出庫拠点コード
            uoeSupplierWork.UOESalSectCd = uoeSupplier.UOESalSectCd;                    // UOE売上拠点コード
            uoeSupplierWork.UOEReservSectCd = uoeSupplier.UOEReservSectCd;              // UOE指定拠点コード
            uoeSupplierWork.ReceiveCondition = uoeSupplier.ReceiveCondition;            // 受信状況
            uoeSupplierWork.SubstPartsNoDiv = uoeSupplier.SubstPartsNoDiv;              // 代替品番区分
            uoeSupplierWork.PartsNoPrtCd = uoeSupplier.PartsNoPrtCd;                    // 品番印刷区分
            uoeSupplierWork.ListPriceUseDiv = uoeSupplier.ListPriceUseDiv;              // 定価使用区分
            uoeSupplierWork.StockSlipDtRecvDiv = uoeSupplier.StockSlipDtRecvDiv;        // 仕入データ受信区分
            uoeSupplierWork.CheckCodeDiv = uoeSupplier.CheckCodeDiv;                    // チェックコード区分
            uoeSupplierWork.BusinessCode = uoeSupplier.BusinessCode;                    // 業務区分
            uoeSupplierWork.UOEResvdSection = uoeSupplier.UOEResvdSection;              // UOE指定拠点
            uoeSupplierWork.EmployeeCode = uoeSupplier.EmployeeCode;                    // 従業員コード
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
            //uoeSupplierWork.DeliveredGoodsDiv = uoeSupplier.DeliveredGoodsDiv;          // 納品区分
            uoeSupplierWork.UOEDeliGoodsDiv = uoeSupplier.UOEDeliGoodsDiv;              // UOE納品区分
            // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
            uoeSupplierWork.BoCode = uoeSupplier.BoCode;                                // BO区分
            uoeSupplierWork.UOEOrderRate = uoeSupplier.UOEOrderRate;                    // UOE発注レート
            uoeSupplierWork.EnableOdrMakerCd1 = uoeSupplier.EnableOdrMakerCd1;          // 発注可能メーカーコード１
            uoeSupplierWork.EnableOdrMakerCd2 = uoeSupplier.EnableOdrMakerCd2;          // 発注可能メーカーコード２
            uoeSupplierWork.EnableOdrMakerCd3 = uoeSupplier.EnableOdrMakerCd3;          // 発注可能メーカーコード３
            uoeSupplierWork.EnableOdrMakerCd4 = uoeSupplier.EnableOdrMakerCd4;          // 発注可能メーカーコード４
            uoeSupplierWork.EnableOdrMakerCd5 = uoeSupplier.EnableOdrMakerCd5;          // 発注可能メーカーコード５
            uoeSupplierWork.EnableOdrMakerCd6 = uoeSupplier.EnableOdrMakerCd6;          // 発注可能メーカーコード６
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応----->>>>>
            uoeSupplierWork.OdrPrtsNoHyphenCd1 = uoeSupplier.OdrPrtsNoHyphenCd1;          // 発注可能メーカーコード１
            uoeSupplierWork.OdrPrtsNoHyphenCd2 = uoeSupplier.OdrPrtsNoHyphenCd2;          // 発注可能メーカーコード２
            uoeSupplierWork.OdrPrtsNoHyphenCd3 = uoeSupplier.OdrPrtsNoHyphenCd3;          // 発注可能メーカーコード３
            uoeSupplierWork.OdrPrtsNoHyphenCd4 = uoeSupplier.OdrPrtsNoHyphenCd4;          // 発注可能メーカーコード４
            uoeSupplierWork.OdrPrtsNoHyphenCd5 = uoeSupplier.OdrPrtsNoHyphenCd5;          // 発注可能メーカーコード５
            uoeSupplierWork.OdrPrtsNoHyphenCd6 = uoeSupplier.OdrPrtsNoHyphenCd6;          // 発注可能メーカーコード６
            //------ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応-----<<<<<
            uoeSupplierWork.instrumentNo = uoeSupplier.instrumentNo;                    // 機器番号
            uoeSupplierWork.UOETestMode = uoeSupplier.UOETestMode;                      // UOEテストモード
            uoeSupplierWork.UOEItemCd = uoeSupplier.UOEItemCd;                          // UOEアイテムコード
            uoeSupplierWork.HondaSectionCode = uoeSupplier.HondaSectionCode;            // ホンダ担当拠点
            uoeSupplierWork.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;            // 回答保存フォルダ
            uoeSupplierWork.MazdaSectionCode = uoeSupplier.MazdaSectionCode;            // マツダ自拠点コード
            uoeSupplierWork.EmergencyDiv = uoeSupplier.EmergencyDiv;                    // 緊急区分
            uoeSupplierWork.DaihatsuOrdreDiv = uoeSupplier.DaihatsuOrdreDiv;            // 発注手配区分（ダイハツ）
            uoeSupplierWork.SupplierCd = uoeSupplier.SupplierCd;                        // 仕入先コード
            // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
            uoeSupplierWork.UOELoginUrl = uoeSupplier.UOELoginUrl;                      // ログイン用URL
            uoeSupplierWork.UOEOrderUrl = uoeSupplier.UOEOrderUrl;                      // 発注用URL
            uoeSupplierWork.UOEStockCheckUrl = uoeSupplier.UOEStockCheckUrl;            // 在庫確認用URL
            uoeSupplierWork.UOEForcedTermUrl = uoeSupplier.UOEForcedTermUrl;            // 強制終了用URL
            uoeSupplierWork.InqOrdDivCd = uoeSupplier.InqOrdDivCd;                      // 接続種別
            uoeSupplierWork.LoginTimeoutVal = uoeSupplier.LoginTimeoutVal;              // ログイン認証時間
            uoeSupplierWork.EPartsUserId = uoeSupplier.EPartsUserId;                    // ユーザID
            uoeSupplierWork.EPartsPassWord = uoeSupplier.EPartsPassWord;                // パスワード
            // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
            uoeSupplierWork.BLMngUserCode = uoeSupplier.BLMngUserCode;                  // BL管理ユーザーコード
            // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

            return uoeSupplierWork;
        }

        /// <summary>
        /// UOE発注先検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先の検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        private int SearchUOESupplier(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode,string sectionCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOESupplierWork uoeSupplierWork = new UOESupplierWork();

            // 次データ有無初期化
            nextData = false;
            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // セキュリティレベルキー指定
                uoeSupplierWork.EnterpriseCode = enterpriseCode;
                uoeSupplierWork.SectionCode = sectionCode;

                // UOE発注先ワーカークラスをオブジェクトに設定
                object paraObj = (object)uoeSupplierWork;
                
                // 全件読込
                status = this._iUOESupplierDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESupplierWork wkUOESupplierWork in workList)
                            {
                                // リモートパラメータデータ ⇒ データクラス
                                UOESupplier wkUOESupplier = CopyToUOESupplierFromUOESupplierWork(wkUOESupplierWork);
                                // データクラスを読込結果へコピー
                                retList.Add(wkUOESupplier);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        private int SearchUOEGuideName(out ArrayList retList, UOEGuideName uoeGuideName)
        {
            int status = -1;

            status = this._uoeGuideNameAcs.Search(out retList, uoeGuideName);

            return status;
        }

        // -- ADD 2010/04/06 --------------------------------------->>>
        /// <summary>
        /// キー情報生成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">受託契約管理コード</param>
        /// <returns>生成したキー情報</returns>
        public string ConstructionKey(string enterpriseCode, int supplierCode, string sectionCode)
        {
            string key = string.Empty;
            key = enterpriseCode.Trim() + "-" + supplierCode.ToString() + "-" + sectionCode.Trim();
            return key;
        }

        /// <summary>
        /// キャッシュ更新処理
        /// </summary>
        /// <param name="supplier"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private void UpdateCache(UOESupplier supplier)
        {
            // staticディクショナリが無ければ生成
            if (_uOESupplierDic == null)
            {
                _uOESupplierDic = new Dictionary<string, UOESupplier>();
            }
            // 既存ならば削除
            if (_uOESupplierDic.ContainsKey(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode)))
            {
                _uOESupplierDic.Remove(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode));
            }
            // 追加
            _uOESupplierDic.Add(ConstructionKey(supplier.EnterpriseCode, supplier.UOESupplierCd, supplier.SectionCode), supplier);
        }

        /// <summary>
        /// キャッシュ取得処理
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private int GetFromCache(out UOESupplier uoeSupplier, string enterpriseCode, int supplierCode, string sectionCode)
        {
            uoeSupplier = null;

            if (_uOESupplierDic != null)
            {
                // キャッシュから取得
                if (_uOESupplierDic.ContainsKey(ConstructionKey(enterpriseCode, supplierCode, sectionCode)))
                {
                    uoeSupplier = _uOESupplierDic[ConstructionKey(enterpriseCode, supplierCode, sectionCode)];
                }
            }

            if (uoeSupplier == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }

        /// <summary>
        /// キャッシュ削除処理
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>金額端数処理取得を含めてReadの利用頻度を考慮し、キャッシュ制御を行います。</remarks>
        private void DeleteFromCache(string enterpriseCode, int supplierCode, string sectionCode)
        {
            if (_uOESupplierDic != null)
            {
                // キャッシュから削除
                if (_uOESupplierDic.ContainsKey(ConstructionKey(enterpriseCode, supplierCode, sectionCode)))
                {
                    _uOESupplierDic.Remove(ConstructionKey(enterpriseCode, supplierCode, sectionCode));
                }
            }
        }

        /// <summary>
        /// キャッシュ全削除処理
        /// </summary>
        public void DeleteAllFromCache()
        {
            _uOESupplierDic = new Dictionary<string, UOESupplier>();
        }
        // -- ADD 2010/04/06 ---------------------------------------<<<

        #endregion

        #region Guid Methods

        /// <summary>
        /// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
        /// <remarks>
        /// <br>Note		: 汎用ガイド設定用データを取得します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            // 企業コード設定有り
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // 企業コード設定無し
            else
            {
                // 有り得ないのでエラー
                return status;
            }
            //企業コード
            if (inParm.ContainsKey("SectionCode"))
            {
                sectionCode = inParm["SectionCode"].ToString();
            }

            // UOE発注先マスタテーブル読込み
            status = Search(ref guideList, enterpriseCode,sectionCode);

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

        /// <summary>
        /// UOE発注先マスタガイド起動処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="maker">取得データ</param>
        /// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
        /// <remarks>
        /// <br>Note		: UOE発注先マスタの一覧表示機能を持つガイドを起動します。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, string sectionCode, out UOESupplier uoeSupplier)
        {
            int status = -1;
            uoeSupplier = new UOESupplier();

            TableGuideParent tableGuideParent = new TableGuideParent("UOESUPPLIERGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // 企業コード
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("SectionCode", sectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 企業コード
                uoeSupplier.EnterpriseCode = retObj["EnterpriseCode"].ToString();
                // 拠点コード
                uoeSupplier.SectionCode = retObj["SectionCode"].ToString();
                // UOE発注先コード
                string strCode = retObj["UOESupplierCd"].ToString();
                uoeSupplier.UOESupplierCd = int.Parse(strCode);
                // UOE発注先名称
                uoeSupplier.UOESupplierName = retObj["UOESupplierName"].ToString();
                // 商品メーカーコード
                strCode = retObj["GoodsMakerCd"].ToString();
                uoeSupplier.GoodsMakerCd = int.Parse(strCode);
                // 仕入先コード
                strCode = retObj["SupplierCd"].ToString();
                uoeSupplier.SupplierCd = int.Parse(strCode);
                // 電話番号
                uoeSupplier.TelNo = retObj["TelNo"].ToString();
                // UOE端末コード
                uoeSupplier.UOETerminalCd = retObj["UOETerminalCd"].ToString();
                // UOEホストコード
                uoeSupplier.UOEHostCode = retObj["UOEHostCode"].ToString();
                // UOE接続パスワード
                uoeSupplier.UOEConnectPassword = retObj["UOEConnectPassword"].ToString();
                // UOE接続ユーザID
                uoeSupplier.UOEConnectUserId = retObj["UOEConnectUserId"].ToString();
                // UOEID番号
                uoeSupplier.UOEIDNum = retObj["UOEIDNum"].ToString();
                // 通信アセンブリID
                uoeSupplier.CommAssemblyId = retObj["CommAssemblyId"].ToString();
                // 接続バージョン区分
                strCode = retObj["ConnectVersionDiv"].ToString();
                uoeSupplier.ConnectVersionDiv = int.Parse(strCode);
                // UOE出庫拠点コード
                uoeSupplier.UOEShipSectCd = retObj["UOEShipSectCd"].ToString();
                // UOE売上拠点コード
                uoeSupplier.UOESalSectCd = retObj["UOESalSectCd"].ToString();
                // UOE指定拠点コード
                uoeSupplier.UOEReservSectCd = retObj["UOEReservSectCd"].ToString();
                // 受信状況
                strCode = retObj["ReceiveCondition"].ToString();
                uoeSupplier.ReceiveCondition = int.Parse(strCode);
                // 代替品番区分
                strCode = retObj["SubstPartsNoDiv"].ToString();
                uoeSupplier.SubstPartsNoDiv = int.Parse(strCode);
                // 品番印刷区分
                strCode = retObj["PartsNoPrtCd"].ToString();
                uoeSupplier.PartsNoPrtCd = int.Parse(strCode);
                // 定価使用区分
                strCode = retObj["ListPriceUseDiv"].ToString();
                uoeSupplier.ListPriceUseDiv = int.Parse(strCode);
                // 仕入データ受信区分
                strCode = retObj["StockSlipDtRecvDiv"].ToString();
                uoeSupplier.StockSlipDtRecvDiv = int.Parse(strCode);
                // チェックコード区分
                strCode = retObj["CheckCodeDiv"].ToString();
                uoeSupplier.CheckCodeDiv = int.Parse(strCode);
                // 業務区分
                strCode = retObj["BusinessCode"].ToString();
                uoeSupplier.BusinessCode = int.Parse(strCode);
                // UOE指定拠点
                uoeSupplier.UOEResvdSection = retObj["UOEResvdSection"].ToString();
                // 従業員コード
                uoeSupplier.EmployeeCode = retObj["EmployeeCode"].ToString();
                // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 >>>>>>START
                //// 納品区分
                //strCode = retObj["DeliveredGoodsDiv"].ToString();
                //uoeSupplier.DeliveredGoodsDiv = int.Parse(strCode);
                // UOE納品区分
                uoeSupplier.UOEDeliGoodsDiv = retObj["UOEDeliGoodsDiv"].ToString();
                // 2008.11.11 30413 犬飼 納品区分をUOE納品区分に修正 <<<<<<END
                // BO区分
                uoeSupplier.BoCode = retObj["BoCode"].ToString();
                // UOE発注レート
                uoeSupplier.UOEOrderRate = retObj["UOEOrderRate"].ToString();
                // 機器番号
                uoeSupplier.instrumentNo = retObj["instrumentNo"].ToString();
                // UOEテストモード
                uoeSupplier.UOETestMode = retObj["UOETestMode"].ToString();
                // UOEアイテムコード
                uoeSupplier.UOEItemCd = retObj["UOEItemCd"].ToString();
                // ホンダ担当拠点
                uoeSupplier.HondaSectionCode = retObj["HondaSectionCode"].ToString();
                // 回答保存フォルダ
                uoeSupplier.AnswerSaveFolder = retObj["AnswerSaveFolder"].ToString();
                // マツダ自拠点コード
                uoeSupplier.MazdaSectionCode = retObj["MazdaSectionCode"].ToString();
                // 緊急区分
                uoeSupplier.EmergencyDiv = retObj["EmergencyDiv"].ToString();
                // 発注可能メーカーコード１
                strCode = retObj["EnableOdrMakerCd1"].ToString();
                uoeSupplier.EnableOdrMakerCd1 = int.Parse(strCode);
                // 発注可能メーカーコード２
                strCode = retObj["EnableOdrMakerCd2"].ToString();
                uoeSupplier.EnableOdrMakerCd2 = int.Parse(strCode);
                // 発注可能メーカーコード３
                strCode = retObj["EnableOdrMakerCd3"].ToString();
                uoeSupplier.EnableOdrMakerCd3 = int.Parse(strCode);
                // 発注可能メーカーコード４
                strCode = retObj["EnableOdrMakerCd4"].ToString();
                uoeSupplier.EnableOdrMakerCd4 = int.Parse(strCode);
                // 発注可能メーカーコード５
                strCode = retObj["EnableOdrMakerCd5"].ToString();
                uoeSupplier.EnableOdrMakerCd5 = int.Parse(strCode);
                // 発注可能メーカーコード６
                strCode = retObj["EnableOdrMakerCd6"].ToString();
                uoeSupplier.EnableOdrMakerCd6 = int.Parse(strCode);
                // ---ADD 2009/06/01 ----------------------------------------------------------->>>>>
                // ログイン用URL
                uoeSupplier.UOELoginUrl = retObj["UOELoginUrl"].ToString();
                // 発注用URL
                uoeSupplier.UOEOrderUrl = retObj["UOEOrderUrl"].ToString();
                // 在庫確認用URL
                uoeSupplier.UOEStockCheckUrl = retObj["UOEStockCheckUrl"].ToString();
                // 強制終了用URL
                uoeSupplier.UOEForcedTermUrl = retObj["UOEForcedTermUrl"].ToString();
                // 接続種別
                strCode = retObj["InqOrdDivCd"].ToString();
                uoeSupplier.InqOrdDivCd = int.Parse(strCode);
                // ログイン認証時間
                strCode = retObj["LoginTimeoutVal"].ToString();
                uoeSupplier.LoginTimeoutVal = int.Parse(strCode);
                // ユーザID
                uoeSupplier.EPartsUserId = retObj["EPartsUserId"].ToString();
                // パスワード
                uoeSupplier.EPartsPassWord = retObj["EPartsPassWord"].ToString();
                // ---ADD 2009/06/01 -----------------------------------------------------------<<<<<
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 ----->>>>>>>>>>>>>>>>>>>>
                uoeSupplier.BLMngUserCode = retObj["BLMngUserCode"].ToString();
                // 2012/09/10 ADD TAKAGAWA BL管理ユーザーコード対応 -----<<<<<<<<<<<<<<<<<<<<

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


        #region Public Static Methods


        // 2008.10.21 Add >>>

        /// <summary>
        /// ＵＯＥリマーク１有効無効判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:有効</returns>
        public static bool EnabledUOERemark1(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOERemark1;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOERemark1;
        }

        /// <summary>
        /// ＵＯＥリマーク２有効無効判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:有効</returns>
        public static bool EnabledUOERemark2(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOERemark2;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOERemark2;
        }

        /// <summary>
        /// 納品区分有効無効判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:有効</returns>
        public static bool EnabledDeliveredGoodsDiv(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledDeliveredGoodsDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledDeliveredGoodsDiv;
        }

        /// <summary>
        /// フォロー納品区分有効無効判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:有効</returns>
        public static bool EnabledFollowDeliGoodsDiv(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledFollowDeliGoodsDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledFollowDeliGoodsDiv;
        }

        /// <summary>
        /// 指定拠点有効無効判定
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>True:有効</returns>
        public static bool EnabledUOEResvdSection(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].EnabledUOEResvdSection;
            else
                return uOESupplierInputInfoDictionary[string.Empty].EnabledUOEResvdSection;
        }

        /// <summary>
        /// リマーク１最大桁数
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>リマーク１最大桁数</returns>
        public static int MaxLengthUOERemark1(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].MaxLengthUOERemark1;
            else
                return uOESupplierInputInfoDictionary[string.Empty].MaxLengthUOERemark1;
        }

        /// <summary>
        /// リマーク２最大桁数
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>リマーク２最大桁数</returns>
        public static int MaxLengthUOERemark2(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].MaxLengthUOERemark2;
            else
                return uOESupplierInputInfoDictionary[string.Empty].MaxLengthUOERemark2;
        }

        /// <summary>
        /// 純正区分
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>純正区分</returns>
        public static PureCodeDiv PureCodeUOESupplier(string commAssemblyId)
        {
            commAssemblyId = commAssemblyId.Trim().PadLeft(4, '0');             //ADD 2009/06/01
            if (uOESupplierInputInfoDictionary.ContainsKey(commAssemblyId))
                return uOESupplierInputInfoDictionary[commAssemblyId].PureCodeDiv;
            else
                return uOESupplierInputInfoDictionary[string.Empty].PureCodeDiv;
        }

        // 2008.10.21 Add <<<

        #endregion
    }
}
