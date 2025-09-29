//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理アクセスクラス
// プログラム概要   : データセンターに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 提供削除対象定義情報クラス
    /// </summary>
    /// <remarks>
    /// Note       : 提供削除対象定義情報です。<br />
    /// Programmer : 呉元嘯<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class OfferData
    {
        #region ■ private Member ■
        private const string TBL_ADDICARSPECTTLRF = "追加諸元名称マスタ";
        private const string TBL_BLGROUPRF = "ＢＬグループコードマスタ";
        private const string TBL_CARMODELRF = "車輌型式マスタ";
        private const string TBL_CARNRMLEQPRF = "車輌カタログ標準装備マスタ";
        private const string TBL_CATEGORYRF = "類別マスタ";
        private const string TBL_CEQPDEFDSPRF = "車輌装備初期表示用マスタ";
        private const string TBL_CLGPNOINDXRF = "カタログ部品品番インデックスマスタ";
        private const string TBL_CLGPNOINFORF = "カタログ部品品番情報マスタ";
        private const string TBL_CLGPTNOEXCRF = "カタログ品番最新品番変換マスタ";
        private const string TBL_COLORCDRF = "カラーコードマスタ";
        private const string TBL_CTGEQUIPPTRF = "類別装備部品マスタ";
        private const string TBL_CTGRYEQUIPRF = "類別装備マスタ";
        private const string TBL_CTGYMDLLNKRF = "類別・車輌型式連携マスタ";
        private const string TBL_GOODSMGROUPRF = "商品中分類マスタ";
        private const string TBL_JOINPARTSRF = "結合マスタ";
        private const string TBL_JOINSUBSTRF = "結合代替マスタ";
        private const string TBL_MAKERNAMERF = "メーカー名称マスタ（提供）";
        private const string TBL_MDLNMSRCHRF = "車種名称検索マスタ";
        private const string TBL_MODELNAMERF = "車種名称マスタ（提供）";
        private const string TBL_OFRSUPPLIERRF = "仕入先マスタ（提供）";
        private const string TBL_ORGCARMODELRF = "オリジナル型式マスタ";
        private const string TBL_ORGPARTSNORF = "オリジナル部品マスタ";
        private const string TBL_PARTSPOSCODERF = "部位コードマスタ";
        private const string TBL_PARTSSUBSTRF = "部品代替マスタ";
        private const string TBL_PLATEMDLLNKRF = "モデルプレート車輌型式連携マスタ";
        private const string TBL_PMAKERNMRF = "部品メーカー名称マスタ（提供）";
        private const string TBL_POSTNUMBERRF = "郵便番号マスタ";
        private const string TBL_PRDTYPYEARRF = "生産年式マスタ";
        private const string TBL_PRIMEPARTSRF = "優良部品マスタ";
        private const string TBL_PRMPRTPRICERF = "優良価格マスタ";
        private const string TBL_PRMSETNOTERF = "優良設定用備考マスタ";
        private const string TBL_PRMSETTINGCHGRF = "優良設定変更マスタ";
        private const string TBL_PRMSETTINGRF = "優良設定マスタ";
        private const string TBL_PRTSCLRINFRF = "部品カラーコード情報マスタ";
        private const string TBL_PRTSEQPINFRF = "部品装備情報マスタ";
        private const string TBL_PRTSTRMINFRF = "部品トリムコード情報マスタ";
        private const string TBL_PTMKRPRICERF = "部品価格マスタ";
        private const string TBL_SEARCHPRTCTLRF = "検索品目制御マスタ";
        private const string TBL_SEARCHPRTNMRF = "検索部品名称マスタ";
        private const string TBL_SETPARTSRF = "セットマスタ";
        private const string TBL_SETSUBSTRF = "セット代替マスタ";
        private const string TBL_TBOSEARCHRF = "TBO検索マスタ";
        private const string TBL_TBSPARTSCODERF = "ＢＬコードマスタ";
        private const string TBL_TRIMCDRF = "トリムコードマスタ";
        private const string TBL_PRIUPDHISRF = "価格改正更新履歴データ";

        private const string TBL_ID_ADDICARSPECTTLRF = "ADDICARSPECTTLRF";
        private const string TBL_ID_BLGROUPRF = "BLGROUPRF";
        private const string TBL_ID_CARMODELRF = "CARMODELRF";
        private const string TBL_ID_CARNRMLEQPRF = "CARNRMLEQPRF";
        private const string TBL_ID_CATEGORYRF = "CATEGORYRF";
        private const string TBL_ID_CEQPDEFDSPRF = "CEQPDEFDSPRF";
        private const string TBL_ID_CLGPNOINDXRF = "CLGPNOINDXRF";
        private const string TBL_ID_CLGPNOINFORF = "CLGPNOINFORF";
        private const string TBL_ID_CLGPTNOEXCRF = "CLGPTNOEXCRF";
        private const string TBL_ID_COLORCDRF = "COLORCDRF";
        private const string TBL_ID_CTGEQUIPPTRF = "CTGEQUIPPTRF";
        private const string TBL_ID_CTGRYEQUIPRF = "CTGRYEQUIPRF";
        private const string TBL_ID_CTGYMDLLNKRF = "CTGYMDLLNKRF";
        private const string TBL_ID_GOODSMGROUPRF = "GOODSMGROUPRF";
        private const string TBL_ID_JOINPARTSRF = "JOINPARTSRF";
        private const string TBL_ID_JOINSUBSTRF = "JOINSUBSTRF";
        private const string TBL_ID_MAKERNAMERF = "MAKERNAMERF";
        private const string TBL_ID_MDLNMSRCHRF = "MDLNMSRCHRF";
        private const string TBL_ID_MODELNAMERF = "MODELNAMERF";
        private const string TBL_ID_OFRSUPPLIERRF = "OFRSUPPLIERRF";
        private const string TBL_ID_ORGCARMODELRF = "ORGCARMODELRF";
        private const string TBL_ID_ORGPARTSNORF = "ORGPARTSNORF";
        private const string TBL_ID_PARTSPOSCODERF = "PARTSPOSCODERF";
        private const string TBL_ID_PARTSSUBSTRF = "PARTSSUBSTRF";
        private const string TBL_ID_PLATEMDLLNKRF = "PLATEMDLLNKRF";
        private const string TBL_ID_PMAKERNMRF = "PMAKERNMRF";
        private const string TBL_ID_POSTNUMBERRF = "POSTNUMBERRF";
        private const string TBL_ID_PRDTYPYEARRF = "PRDTYPYEARRF";
        private const string TBL_ID_PRIMEPARTSRF = "PRIMEPARTSRF";
        private const string TBL_ID_PRMPRTPRICERF = "PRMPRTPRICERF";
        private const string TBL_ID_PRMSETNOTERF = "PRMSETNOTERF";
        private const string TBL_ID_PRMSETTINGCHGRF = "PRMSETTINGCHGRF";
        private const string TBL_ID_PRMSETTINGRF = "PRMSETTINGRF";
        private const string TBL_ID_PRTSCLRINFRF = "PRTSCLRINFRF";
        private const string TBL_ID_PRTSEQPINFRF = "PRTSEQPINFRF";
        private const string TBL_ID_PRTSTRMINFRF = "PRTSTRMINFRF";
        private const string TBL_ID_PTMKRPRICERF = "PTMKRPRICERF";
        private const string TBL_ID_SEARCHPRTCTLRF = "SEARCHPRTCTLRF";
        private const string TBL_ID_SEARCHPRTNMRF = "SEARCHPRTNMRF";
        private const string TBL_ID_SETPARTSRF = "SETPARTSRF";
        private const string TBL_ID_SETSUBSTRF = "SETSUBSTRF";
        private const string TBL_ID_TBOSEARCHRF = "TBOSEARCHRF";
        private const string TBL_ID_TBSPARTSCODERF = "TBSPARTSCODERF";
        private const string TBL_ID_TRIMCDRF = "TRIMCDRF";
        private const string TBL_ID_PRIUPDHISRF = "PRIUPDHISRF";

        private const Int32 OFFERDATA_CODE = 0;
        private const Int32 USERDATA_CODE = 9;

        private string FIELD = string.Empty;

        #endregion

        /// <summary>
        /// 定義提供削除対象情報
        /// </summary>
        /// <remarks>
        /// Note       : 定義提供削除対象情報。<br />
        /// Programmer : 呉元嘯<br />
        /// Date       : 2009.06.16<br />
        /// </remarks>
        public ArrayList GetOfferDataList()
        {
            // 各テーブル対象
            OfferDataDeleteWork _offerDataDeleteWork = null;
            // テーブル対象リスト
            ArrayList offerDataList = new ArrayList();

            // 追加諸元名称マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ADDICARSPECTTLRF;
            _offerDataDeleteWork.TableID = TBL_ID_ADDICARSPECTTLRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ＢＬグループコードマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_BLGROUPRF;
            _offerDataDeleteWork.TableID = TBL_ID_BLGROUPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 車輌型式マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CARMODELRF;
            _offerDataDeleteWork.TableID = TBL_ID_CARMODELRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 車輌カタログ標準装備マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CARNRMLEQPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CARNRMLEQPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 類別マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CATEGORYRF;
            _offerDataDeleteWork.TableID = TBL_ID_CATEGORYRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 車輌装備初期表示用マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CEQPDEFDSPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CEQPDEFDSPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // カタログ部品品番インデックスマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPNOINDXRF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPNOINDXRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // カタログ部品品番情報マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPNOINFORF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPNOINFORF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // カタログ品番最新品番変換マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CLGPTNOEXCRF;
            _offerDataDeleteWork.TableID = TBL_ID_CLGPTNOEXCRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // カラーコードマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_COLORCDRF;
            _offerDataDeleteWork.TableID = TBL_ID_COLORCDRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 類別装備部品マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGEQUIPPTRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGEQUIPPTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 類別装備マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGRYEQUIPRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGRYEQUIPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 類別・車輌型式連携マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_CTGYMDLLNKRF;
            _offerDataDeleteWork.TableID = TBL_ID_CTGYMDLLNKRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 商品中分類マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_GOODSMGROUPRF;
            _offerDataDeleteWork.TableID = TBL_ID_GOODSMGROUPRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 結合マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_JOINPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_JOINPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 結合代替マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_JOINSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_JOINSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // メーカー名称マスタ（提供）
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MAKERNAMERF;
            _offerDataDeleteWork.TableID = TBL_ID_MAKERNAMERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 車種名称検索マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MDLNMSRCHRF;
            _offerDataDeleteWork.TableID = TBL_ID_MDLNMSRCHRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 車種名称マスタ（提供）
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_MODELNAMERF;
            _offerDataDeleteWork.TableID = TBL_ID_MODELNAMERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 仕入先マスタ（提供）
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_OFRSUPPLIERRF;
            _offerDataDeleteWork.TableID = TBL_ID_OFRSUPPLIERRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // オリジナル型式マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ORGCARMODELRF;
            _offerDataDeleteWork.TableID = TBL_ID_ORGCARMODELRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // オリジナル部品マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_ORGPARTSNORF;
            _offerDataDeleteWork.TableID = TBL_ID_ORGPARTSNORF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部位コードマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PARTSPOSCODERF;
            _offerDataDeleteWork.TableID = TBL_ID_PARTSPOSCODERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品代替マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PARTSSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_PARTSSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // モデルプレート車輌型式連携マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PLATEMDLLNKRF;
            _offerDataDeleteWork.TableID = TBL_ID_PLATEMDLLNKRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品メーカー名称マスタ（提供）
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PMAKERNMRF;
            _offerDataDeleteWork.TableID = TBL_ID_PMAKERNMRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 郵便番号マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_POSTNUMBERRF;
            _offerDataDeleteWork.TableID = TBL_ID_POSTNUMBERRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 生産年式マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRDTYPYEARRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRDTYPYEARRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 優良部品マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRIMEPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRIMEPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 優良価格マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMPRTPRICERF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMPRTPRICERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 優良設定用備考マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETNOTERF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETNOTERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 優良設定変更マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETTINGCHGRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETTINGCHGRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 優良設定マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRMSETTINGRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRMSETTINGRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品カラーコード情報マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSCLRINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSCLRINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品装備情報マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSEQPINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSEQPINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品トリムコード情報マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRTSTRMINFRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRTSTRMINFRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 部品価格マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PTMKRPRICERF;
            _offerDataDeleteWork.TableID = TBL_ID_PTMKRPRICERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 検索品目制御マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SEARCHPRTCTLRF;
            _offerDataDeleteWork.TableID = TBL_ID_SEARCHPRTCTLRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 検索部品名称マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SEARCHPRTNMRF;
            _offerDataDeleteWork.TableID = TBL_ID_SEARCHPRTNMRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // セットマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SETPARTSRF;
            _offerDataDeleteWork.TableID = TBL_ID_SETPARTSRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // セット代替マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_SETSUBSTRF;
            _offerDataDeleteWork.TableID = TBL_ID_SETSUBSTRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // TBO検索マスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TBOSEARCHRF;
            _offerDataDeleteWork.TableID = TBL_ID_TBOSEARCHRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // ＢＬコードマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TBSPARTSCODERF;
            _offerDataDeleteWork.TableID = TBL_ID_TBSPARTSCODERF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // トリムコードマスタ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_TRIMCDRF;
            _offerDataDeleteWork.TableID = TBL_ID_TRIMCDRF;
            _offerDataDeleteWork.Code = OFFERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);
            // 価格改正更新履歴データ
            _offerDataDeleteWork = new OfferDataDeleteWork();
            _offerDataDeleteWork.TableName = TBL_PRIUPDHISRF;
            _offerDataDeleteWork.TableID = TBL_ID_PRIUPDHISRF;
            _offerDataDeleteWork.Code = USERDATA_CODE;
            _offerDataDeleteWork.Field = FIELD;
            offerDataList.Add(_offerDataDeleteWork);

            return offerDataList;
        }
    }
}
