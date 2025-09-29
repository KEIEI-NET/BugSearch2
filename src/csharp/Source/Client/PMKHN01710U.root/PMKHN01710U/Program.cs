//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提案商品画面起動プログラム
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 3H 趙遠
// 作 成 日 : 2016/06/06   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace TBOExecutor
{
    static class Program
    {
        #region Private Constant
        private const string CT_PGID = "PMKHN01710U";
        private const string CT_PGNAME = "提案商品画面起動プログラム";
        private const string CT_ERRMSG_FAILED_SECTION  = "拠点マスタが取得できませんでした。";
        private const string CT_ERRMSG_FAILED_MAKER = "メーカーマスタが取得できませんでした。";
        private const string CT_ERRMSG_FAILED_SCM = "SCM企業拠点連結設定が取得できませんでした。";
        private const string CT_ERRMSG_NOT_FOUND_SCM = "有効なSCM企業拠点連結設定が存在しません。";
        private const string CT_ERRMSG_FAILED_EXEC_PROPOSE_GOODS = "提案商品登録画面が起動できませんでした。";
        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                ApplicationStartControl.StartApplication(
                        out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                // 起動パラメータ取得
                Propose_Para_Main main = new Propose_Para_Main();
                if (SearchMain(ref main))
                {
                    Application.EnableVisualStyles();
                    Application.Run(new PMKHN01710U(main));
                }
            }
            catch
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PGNAME, "", "", CT_ERRMSG_FAILED_EXEC_PROPOSE_GOODS, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note        : アプリケーション終了イベント。</br>
        /// <br>Programmer  : 3H 趙遠</br>
        /// <br>Date        : 2016/06/06</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            // メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();

            // アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="propose_Para_Main">提案商品起動パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer	: 3H 趙遠</br>
        /// <br>Date		: 2016/06/06</br>
        /// </remarks>
        private static bool SearchMain(ref Propose_Para_Main propose_Para_Main)
        {
            List<Propose_Para_Section> sectionParaList;
            List<Propose_Para_Maker> makerParaList;
            List<Propose_Para_SCM> scmParaList;

            // 提案商品起動パラメータ（拠点）リスト
            int status = GetSectionPara(out sectionParaList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PGNAME, "", "", CT_ERRMSG_FAILED_SECTION, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            // 提案商品起動パラメータ（メーカー）リスト
            status = GetMakerPara(out makerParaList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PGNAME, "", "", CT_ERRMSG_FAILED_MAKER, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            // 提案商品起動パラメータ（SCM企業拠点連結）リスト
            status = GetScmPara(out scmParaList);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PGNAME, "", "", CT_ERRMSG_FAILED_SCM, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (scmParaList.Count <= 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID, CT_PGNAME, "", "", CT_ERRMSG_NOT_FOUND_SCM, -1, null, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return false;
            }

            // 提案商品起動パラメータ(メイン)データ変換処理
            SetMainPara(sectionParaList, makerParaList, scmParaList, ref propose_Para_Main);

            return true;
        }

        #region データ取得処理
        /// <summary>
        /// 提案商品起動パラメータ(拠点)データ取得処理
        /// </summary>
        /// <param name="sectionParaList">提案商品起動パラメータ(拠点)リスト</param>
        /// <remarks>
        /// <br>Note		: 提案商品起動パラメータ(拠点)データ取得</br>
        /// <br>Programmer	: 3H 趙遠</br>
        /// <br>Date		: 2016/06/06</br>
        /// </remarks>
        private static int GetSectionPara(out List<Propose_Para_Section> sectionParaList)
        {
            sectionParaList = new List<Propose_Para_Section>();

            // 拠点情報検索処理（論理削除除く）
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            ArrayList sectionList = new ArrayList();
            int status = secInfoSetAcs.Search(out sectionList, LoginInfoAcquisition.EnterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SecInfoSet secInfoSet in sectionList)
                {
                    Propose_Para_Section propose_Para_Section = new Propose_Para_Section();
                    propose_Para_Section.SectionCode = secInfoSet.SectionCode;                      //拠点コード
                    propose_Para_Section.SectionGuideNm = secInfoSet.SectionGuideNm;                //拠点ガイド名称
                    propose_Para_Section.MainOfficeFuncFlag = secInfoSet.MainOfficeFuncFlag;        //本社機能フラグ
                    sectionParaList.Add(propose_Para_Section);
                }
            }

            return status;
        }

        /// <summary>
        /// 提案商品起動パラメータ(メーカー)データ取得処理
        /// </summary>
        /// <param name="makerParaList">提案商品起動パラメータ(メーカー)リスト</param>
        /// <remarks>
        /// <br>Note		: 提案商品起動パラメータ（拠点）データ取得</br>
        /// <br>Programmer	: 3H 趙遠</br>
        /// <br>Date		: 2016/06/06</br>
        /// </remarks>
        private static int GetMakerPara(out List<Propose_Para_Maker>  makerParaList)
        {
            makerParaList = new List<Propose_Para_Maker>();

            // メーカー情報検索
            MakerAcs makerAcs = new MakerAcs();
            DataSet ds = new DataSet();
            int status = makerAcs.Search(ref ds, LoginInfoAcquisition.EnterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DataTable dt = ds.Tables["MakerUMnt"];
                foreach (DataRow rows in dt.Rows)
                {
                    Propose_Para_Maker propose_Para_Maker = new Propose_Para_Maker();
                    propose_Para_Maker.GoodsMakerCd = Convert.ToInt32(rows["GoodsMakerCd"]);              //商品メーカーコード
                    propose_Para_Maker.MakerName = rows["MakerName"].ToString();                          //メーカー名称
                    propose_Para_Maker.MakerKanaName = rows["MakerKanaName"].ToString();                  //メーカーカナ名称
                    propose_Para_Maker.DisplayOrder = Convert.ToInt32(rows["DisplayOrder"]);              //表示順位
                    propose_Para_Maker.OfferDataDiv = Convert.ToInt32(rows["OfferDataDiv"]);              //提供データ区分
                    makerParaList.Add(propose_Para_Maker);
                }
            }

            return status;
        }

        /// <summary>
        /// SCM企業拠点連結設定マスタ取得処理
        /// </summary>
        /// <param name="scmParaList">提案商品起動パラメータ（SCM企業拠点連結）リスト</param>
        /// <remarks>
        /// <br>Note		: SCM企業拠点連結設定マスタ取得</br>
        /// <br>Programmer	: 3H 趙遠</br>
        /// <br>Date		: 2016/06/06</br>
        /// </remarks>
        private static int GetScmPara(out List<Propose_Para_SCM> scmParaList)
        {
            scmParaList = new List<Propose_Para_SCM>();

            bool msgDiv = false;
            string errMsg = string.Empty;
            List<ScmEpCnect> scmEpCnectList;
            List<ScmEpScCnt> scmEpScCntList = new List<ScmEpScCnt>();

            // SCM企業連結設定検索
            ScmEpCnectAcs scmEpCnectAcs = new ScmEpCnectAcs();
            int status = scmEpCnectAcs.SearchCnectOriginalEp(LoginInfoAcquisition.EnterpriseCode, ConstantManagement.LogicalMode.GetData0, out scmEpCnectList, out msgDiv, out errMsg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            // 連結有効のみ抽出
            scmEpCnectList = scmEpCnectList.FindAll(delegate(ScmEpCnect scmEpCnect) { return scmEpCnect.DiscDivCd == 0; });

            // SCM企業拠点連結設定検索
            ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
            status = scmEpScCntAcs.SearchCnectOriginalEpFromSc(LoginInfoAcquisition.EnterpriseCode, ConstantManagement.LogicalMode.GetData0, out scmEpScCntList, out msgDiv, out errMsg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;

            foreach (ScmEpScCnt scmEpScCnect in scmEpScCntList)
            {
                // 識別区分：1(連結無効)であれば対象外
                if (scmEpScCnect.DiscDivCd == 1) continue;
                // 通信方式(SCM)：0(しない) かつ 通信方式(PCC-UOE)：0(しない)であれば対象外
                if (scmEpScCnect.ScmCommMethod == 0 && scmEpScCnect.PccUoeCommMethod == 0) continue;

                ScmEpCnect findSCMEpCnect = scmEpCnectList.Find(delegate(ScmEpCnect scmEpCnect)
                {
                    return (scmEpScCnect.CnectOriginalEpCd == scmEpCnect.CnectOriginalEpCd) && (scmEpScCnect.CnectOtherEpCd == scmEpCnect.CnectOtherEpCd);
                });

                if (findSCMEpCnect != null)
                {
                    Propose_Para_SCM scm = new Propose_Para_SCM();
                    scm.CnectOriginalEpCd = scmEpScCnect.CnectOriginalEpCd;         //連結元企業コード
                    scm.CnectOriginalEpNm = findSCMEpCnect.CnectOriginalEpNm;       //連結元企業名称
                    scm.CnectOriginalSecCd = scmEpScCnect.CnectOriginalSecCd;       //連結元拠点コード
                    scm.CnectOriginalSecNm = scmEpScCnect.CnectOriginalSecNm;       //連結元拠点ガイド名称
                    scm.CnectOtherEpCd = scmEpScCnect.CnectOtherEpCd;               //連結先企業コード
                    scm.CnectOtherEpNm = findSCMEpCnect.CnectOtherEpNm;             //連結先企業名称
                    scm.CnectOtherSecCd = scmEpScCnect.CnectOtherSecCd;             //連結先拠点コード
                    scm.CnectOtherSecNm = scmEpScCnect.CnectOtherSecNm;             //連結先拠点ガイド名称
                    scm.DiscDivCd = scmEpScCnect.DiscDivCd;                         //識別区分
                    scm.ScmCommMethod = scmEpScCnect.ScmCommMethod;                 //通信方式(SCM)
                    scm.PccUoeCommMethod = scmEpScCnect.PccUoeCommMethod;           //通信方式(PCC-UOE)
                    scm.RcScmCommMethod = scmEpScCnect.RcScmCommMethod;             //通信方式(RC-SCM)
                    scm.DisplayOrder = 0;                                           //表示順位
                    scm.PrDispSystem = scmEpScCnect.PrDispSystem;                   //優先表示システム
                    scm.TabUseDiv = scmEpScCnect.TabUseDiv;                         //タブレット使用区分
                    scm.OldNewStatus = scmEpScCnect.OldNewStatus;                   //新旧切替ステータス
                    scm.UsualMnalStatus = scmEpScCnect.UsualMnalStatus;             //通常/手動ステータス
                    scm.PmDBId = scmEpScCnect.PmDBId;                               //パーツマンDBID
                    scm.PmUploadDiv = scmEpScCnect.PmUploadDiv;                     //パーツマンアップロード区分
                    scmParaList.Add(scm);
                }
            }

            return status;
        }
        #endregion

        #region データ変換処理
        /// <summary>
        /// 提案商品起動パラメータ(メイン)変換処理
        /// </summary>
        /// <param name="sectionList">拠点マスタのリスト</param>
        /// <param name="makerList">メーカーマスタのリスト</param>
        /// <param name="scmList">SCM企業拠点連結設定のリスト</param>
        /// <param name="scmList">企業コード</param>
        /// <param name="propose_Para_Main">提案商品起動パラメータ(メイン)</param>
        /// <remarks>
        /// <br>Note		: 提案商品起動パラメータ(メイン)変換処理</br>
        /// <br>Programmer	: 3H 趙遠</br>
        /// <br>Date		: 2016/06/06</br>
        /// </remarks>
        private static void SetMainPara(List<Propose_Para_Section> sectionList, List<Propose_Para_Maker> makerList, List<Propose_Para_SCM> scmList, ref Propose_Para_Main propose_Para_Main)
        {
            propose_Para_Main = new Propose_Para_Main();

            // 起動モード
            propose_Para_Main.BootMode = 1;
            // 企業コード
            propose_Para_Main.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 企業名
            propose_Para_Main.EnterpriseName = LoginInfoAcquisition.EnterpriseName.Trim();
            // 従業員コード
            propose_Para_Main.EmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // 従業員名称
            propose_Para_Main.EmployeeName = LoginInfoAcquisition.Employee.Name.Trim();
            // 拠点コード
            propose_Para_Main.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 提案商品起動パラメータ（SCM企業拠点連結）リスト
            propose_Para_Main.Propose_Para_SCM = scmList;
            // 提案商品起動パラメータ（拠点）リスト
            propose_Para_Main.Propose_Para_Section = sectionList;
            // 提案商品起動パラメータ（メーカー）リスト
            propose_Para_Main.Propose_Para_Maker = makerList;
        }
        #endregion
    }
}