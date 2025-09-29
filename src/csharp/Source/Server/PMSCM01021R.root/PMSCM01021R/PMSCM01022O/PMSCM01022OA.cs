//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データDBインターフェース
//                  :   PMSCM01022O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// 管理番号 　　　　　　    作成担当：譚洪
// 修正日    2011/08/10     修正内容：PMSCMXXXX2C.DLLはダミーを削除
// ---------------------------------------------------------------------//
// 管理番号 　　　　　　    作成担当：30744 湯上 千加子
// 修正日    2014/03/11     修正内容：SCM仕掛一覧№10639対応
// ---------------------------------------------------------------------//
// 管理番号  11170130-00　　作成担当：譚洪
// 修正日    2015/08/28    修正内容：Redmine#47284 SCM仕掛一覧№10722対応
//                         前回受信日時を保管するファイルが破損防止対応（PMのユーザーDBにデータを登録する機能となる）
// ---------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;  // ADD 2010/02/26  // DEL 2011/08/10

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM関連データDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM関連データDBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteScmDB
    {
        // -- DEL 2010/04/15 使わなくなったので削除------------------>>>
        #region [削除]
        //// -- ADD 2010/03/04 ＩＡＡＥ限定機能------------------------>>>
        ///// <summary>
        ///// 追加
        ///// </summary>
        //void WriteCustDat(string acntId, int customerCode);

        ///// <summary>
        ///// 削除
        ///// </summary>
        //void DeleteCustDat(string account);

        ///// <summary>
        ///// 取得
        ///// </summary>
        //int ReadCustDat(string account);
        //// -- ADD 2010/03/04 ＩＡＡＥ限定機能------------------------<<<


        //// -- ADD 2010/02/26 ------------------------>>>
        ///// <summary>
        ///// 接続情報の追加
        ///// </summary>
        ///// <param name="info">接続情報</param>
        //void AddConnectionInfo(CMTConnectionInfo info);

        ///// <summary>
        ///// 接続情報の削除
        ///// </summary>
        ///// <param name="info">接続情報</param>
        //void DeleteConnectionInfo(CMTConnectionInfo info);

        ///// <summary>
        ///// 接続情報の削除
        ///// </summary>
        ///// <param name="cashRegisterNo">端末番号</param>
        //void DeleteConnectionInfo(int cashRegisterNo);

        ///// <summary>
        ///// 接続情報のクリア（全端末の情報をクリアする）
        ///// </summary>
        //void ClearConnectionInfo();
        #endregion
        // -- DEL 2010/04/15 使わなくなったので削除------------------<<<

        /// <summary>
        /// 新着件数取得用
        /// </summary>
        /// <param name="retAcOdrDataObj">検索結果</param>
        /// <param name="paraSCMReadObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 未回答のＳＣＭ受注データを取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010.02.26</br>
        [MustCustomSerialization]
        int GetOrderNewCount(
//            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retAcOdrDataObj,
            object paraSCMReadObj
            );
        // -- ADD 2010/02/26 ------------------------<<<

        /// <summary>
        /// SCM関連データ情報を取得します。
        /// </summary>
        /// <param name="retScmCsObj">SCM関連データ結果オブジェクト</param>
        /// <param name="paraSCMReadObj">読み込みパラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM関連データのキー値が一致するSCM関連データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmRead(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// SCM関連データ情報を取得します。
        /// </summary>
        /// <param name="retScmCsObj">SCM関連データ結果オブジェクト</param>
        /// <param name="paraSCMReadObj">読み込みパラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM関連データのキー値が一致するSCM関連データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// 未送信のSCM関連データ情報のリストを取得します。
        /// </summary>
        /// <param name="retScmCsObj">検索結果</param>
        /// <param name="paraSCMReadObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 未送信のSCM関連データのキー値が一致する、全てのSCM関連データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmZeroSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, object paraSCMReadObj);

        // ADD 2014/03/11 SCM仕掛一覧№10639対応 ---------------------------------------------------------->>>>>
        /// <summary>
        /// 未送信のSCM関連データ情報のリストを取得します。
        /// </summary>
        /// <param name="retScmCsObj">検索結果</param>
        /// <param name="paraSCMReadObj">抽出条件パラメータワーク</param>
        /// <param name="paraSalesSlipNumList">抽出条件パラメータワーク</param>
        /// <param name="paraInquiryNumber">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 未送信のSCM関連データのキー値が一致する、全てのSCM関連データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmZeroSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, object paraSCMReadObj, object paraSalesSlipNumList, long paraInquiryNumber);
        // ADD 2014/03/11 SCM仕掛一覧№10639対応 ----------------------------------------------------------<<<<<

        /// <summary>
        /// ＳＣＭ受注データを取得します。
        /// </summary>
        /// <param name="retAcOdrDataObj">検索結果(SCM受注データインスタンス)</param>
        /// <param name="paraSCMReadObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 回答区分で絞り込んだ最新のＳＣＭ受注データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.05.26</br>
        [MustCustomSerialization]
        int ScmAnswerRead(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            out object retAcOdrDataObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// ＳＣＭ受注明細データ(問合せ・発注)の最新レコードを１件のみ取得します。
        /// </summary>
        /// <param name="retAcOdrDtlIqObj">検索結果(SCM受注明細データ(問合せ・発注)インスタンス)</param>
        /// <param name="paraSCMReadObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 最新のＳＣＭ受注明細データ(問合せ・発注)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int ScmDtlIqRead(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork")]
            out object retAcOdrDtlIqObj,
            object paraSCMReadObj
            );

        // -- ADD 2010/04/15 ----------------------------------------->>>
        /// <summary>
        /// ＳＣＭ受注データを取得します。(CTIで使用)
        /// </summary>
        /// <param name="retAcOdrDataObj">検索結果(SCM受注データインスタンス)</param>
        /// <param name="paraAcOdrDataObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ＳＣＭ受注データ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2010/04/15</br>
        [MustCustomSerialization]
        int GetSCMAcOdrData(
            // 2011/03/03 >>>
            //[CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            //out object retAcOdrDataObj,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList retAcOdrDataObj,
            // 2011/03/03 <<<
            object paraAcOdrDataObj
            );
        // -- ADD 2010/04/15 -----------------------------------------<<<

        //>>>2010/04/20
        /// <summary>
        /// ＳＣＭ受注データを取得します。
        /// </summary>
        /// <param name="retAcOdrDataObj">検索結果(SCM受注データインスタンス)</param>
        /// <param name="paraAcOdrDataObj">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ＳＣＭ受注データ情報を取得します。</br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2010/04/20</br>
        [MustCustomSerialization]
        int ScmAcOdrDataSearch(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            out object retAcOdrDataObj,
            object paraAcOdrDataObj
            );
        //<<<2010/04/20

        /// <summary>
        /// SCM関連データ情報を追加・更新します。
        /// </summary>
        /// <param name="retScmCsObj">追加・更新するSCM関連データ情報を含む CustomSerializeArrayList</param>
        /// <param name="writemode">更新モード 0:Insertのみ, 1:UpDateInsert</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : retScmCsList に格納されているSCM関連データ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmWrite(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, int writemode);

        /// <summary>
        /// SCM関連データ情報をDeleteInsertします。
        /// </summary>
        /// <param name="retScmCsObj">DeleteInsertするSCM関連データ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : retScmCsObj に格納されているSCM関連データ情報をDeleteInsertします。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmDeleteInsert(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj);

        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 新着最終取得日時を取得します
        /// </summary>
        /// <param name="scmTimeDataWork">抽出条件パラメータワーク</param>
        /// <param name="retscmTimeDataObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 新着最終取得日時を取得します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/08/28</br>
        [MustCustomSerialization]
        int SearchScmTimeData(
            ScmTimeDataWork scmTimeDataWork,
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.ScmTimeDataWork")]
            out object retscmTimeDataObj
            );

        /// <summary>
        /// SCM新着データ表示管理情報を登録、更新します
        /// </summary>
        /// <param name="scmReadWork">抽出条件パラメータワーク</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM新着データ表示管理情報を登録、更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2015/08/28</br>
        [MustCustomSerialization]
        int UpdateScmTimeData(
            ScmTimeDataWork scmReadWork
            );
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
