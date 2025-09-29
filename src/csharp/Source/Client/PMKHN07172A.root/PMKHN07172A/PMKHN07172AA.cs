//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 結合マスタ（エクスポート）
// プログラム概要   : 結合マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 結合マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public class JoinPartsSetExpAcs
    {
        private static bool _isLocalDBRead = false;

        /// <summary>商品セットリモートオブジェクト格納バッファ</summary>
        private IJoinPartsUDB _joinPartsUDB;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// 結合マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 結合マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public JoinPartsSetExpAcs()
        {
            this._joinPartsUDB = (IJoinPartsUDB)MediationJoinPartsUDB.GetJoinPartsUDB();
            this._makerAcs = new MakerAcs();
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
        /// 結合マスタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinPartsExpWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, JoinPartsExpWork joinPartsExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, joinPartsExpWork);
        }

        /// <summary>
        /// 結合マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinPartsExpWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, JoinPartsExpWork joinPartsExpWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, joinPartsExpWork);
        }

        /// <summary>
        /// 結合マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="joinPartsExpWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタ検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, JoinPartsExpWork joinPartsExpWork)
        {
            JoinPartsUWork goodsSetWork = new JoinPartsUWork();

            goodsSetWork.EnterpriseCode = enterpriseCode;

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // 検索結果
            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            object retobj = new ArrayList();

            status = this._joinPartsUDB.Search(ref retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND|| status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                paraList = retobj as ArrayList;
                foreach (JoinPartsUWork joinPartsUWork in paraList)
                {
                    // 抽出処理
                    checkstatus = DataCheck(joinPartsUWork, joinPartsExpWork);
                    if (checkstatus == 0)
                    {
                        //ＢＬグループ情報クラスへメンバコピー
                        retList.Add(CopyToJoinPartsSetFromSecInfoSetWork(joinPartsUWork, enterpriseCode));
                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理（結合マスタワーククラス⇒結合マスタクラス）
        /// </summary>
        /// <param name="joinPartsUWork">結合マスタワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>結合マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタワーククラスから結合マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private JoinPartsSetExp CopyToJoinPartsSetFromSecInfoSetWork(JoinPartsUWork joinPartsUWork, string enterpriseCode)
        {
            JoinPartsSetExp joinPartsSetExp = new JoinPartsSetExp();

            joinPartsSetExp.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            joinPartsSetExp.JoinSourceMakerName = GetMakerName(joinPartsUWork.JoinSourceMakerCode, enterpriseCode);
            joinPartsSetExp.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            joinPartsSetExp.JoinSourPartsNoNoneH = joinPartsUWork.JoinSourPartsNoNoneH;
            //joinPartsSetExp.GoodsNameKana = goodName;
            joinPartsSetExp.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            joinPartsSetExp.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            joinPartsSetExp.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            joinPartsSetExp.JoinDestMakerName = GetMakerName(joinPartsUWork.JoinDestMakerCd, enterpriseCode);
            joinPartsSetExp.JoinQty = joinPartsUWork.JoinQty;
            joinPartsSetExp.JoinSpecialNote = joinPartsUWork.JoinSpecialNote;

            return joinPartsSetExp;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// </remarks>
        private string GetMakerName(int makerCode, string enterpriseCode)
        {
            string makerName = "";
            ReadMaker(enterpriseCode);
            if (this._MakerDic.ContainsKey(makerCode))
            {
                makerName = this._MakerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// メーカー読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー一覧を読み込みます。</br>
        /// </remarks>
        private void ReadMaker(string enterpriseCode)
        {
            try
            {
                if (this._MakerDic.Count == 0)
                {
                    this._MakerDic = new Dictionary<int, MakerUMnt>();

                    ArrayList retList;

                    int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (MakerUMnt mkerUMnt in retList)
                        {
                            if (mkerUMnt.LogicalDeleteCode == 0)
                            {
                                this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._MakerDic = new Dictionary<int, MakerUMnt>();

                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt mkerUMnt in retList)
                    {
                        if (mkerUMnt.LogicalDeleteCode == 0)
                        {
                            this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="joinPartsUWork">検索結果</param>
        /// <param name="joinPartsPrintWork">抽出条件</param>
        /// <returns></returns>
        private int DataCheck(JoinPartsUWork joinPartsUWork, JoinPartsExpWork joinPartsPrintWork)
        {
            int status = 0;

            // 論理削除区分
            if (joinPartsUWork.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // 結合元メーカーコード
            if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0 &&
                joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt ||
                   joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // 結合元品番
            if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty) &&
                !joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0 ||
                    joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }
}
