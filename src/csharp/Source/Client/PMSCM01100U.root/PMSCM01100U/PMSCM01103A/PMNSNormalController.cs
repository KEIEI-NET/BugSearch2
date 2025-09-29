//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/06/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/03/30  修正内容 : 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2011/02/22  修正内容 : 回答区分のセット仕様を修正。(回答済みor一部回答の判断)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/09  修正内容 : SCM仕掛一覧№10641対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting; // ADD m.suzuki 2011/02/22
using Broadleaf.Application.Remoting.Adapter; // ADD m.suzuki 2011/02/22

using Broadleaf.Application.Controller.Agent;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS用単体起動モード回答送信処理コントローラクラス
    /// </summary>
    public sealed class PMNSNormalController : NormalModeController
    {
        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        private IIOWriteScmDB _ioWriteScmDB;

        /// <summary>
        /// SCM-IOWriter
        /// </summary>
        protected IIOWriteScmDB IOWriteScmDB
        {
            get
            {
                if ( _ioWriteScmDB == null )
                {
                    _ioWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
                }
                return _ioWriteScmDB;
            }
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

        #region <Override>

        #region <SCMIO生成>
        /// <summary>
        /// SCM I/Oを生成します。
        /// </summary>
        /// <param name="dataPath">データパス</param>
        /// <returns>PM.NSのSCM I/O</returns>
        /// <see cref="SCMSendController"/>
        protected override SCMIOAgent CreateSCMIO(string dataPath)
        {
            // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
            //return new PMNSIOAgent();
            // DEL 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<
            // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ---------->>>>>
            return new PMNSIOAgent(false);   // 得意先情報が必要
            // ADD 2010/03/30 得意先情報を取得する処理が少々遅いので、画面表示をしない場合は得意先情報を取得しない ----------<<<<<
        }
        #endregion

        #region <送信後更新処理>
        /// <summary>
        /// SCM受注データを更新します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSendController"/>
        protected override int UpdateAfterSend()
        {
            if (((List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First).Count == 0)
            {
                // 対象0件
                WriteLog("更新対象レコードが0件です。");
                return 0;
            }

            List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList = (List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First;
            List<ISCMOrderCarRecord> userSCMOrderCarRecordList = (List<ISCMOrderCarRecord>)SCMWebDB.WritedResult.Second;
            List<ISCMOrderAnswerRecord> userSCMOrderAnswerRecordList = (List<ISCMOrderAnswerRecord>)SCMWebDB.WritedResult.Third;

            // 型変換
            List<SCMAcOdrDataWork> writeHeaderList = new List<SCMAcOdrDataWork>();
            foreach (UserSCMOrderHeaderRecord userSCMOrderHeaderRecord in userSCMOrderHeaderRecordList)
            {
                writeHeaderList.Add(userSCMOrderHeaderRecord.RealRecord);
            }

            List<SCMAcOdrDtCarWork> writeCarList = new List<SCMAcOdrDtCarWork>();
            foreach (UserSCMOrderCarRecord userSCMOrderCarRecord in userSCMOrderCarRecordList)
            {
                writeCarList.Add(userSCMOrderCarRecord.RealRecord);
            }

            List<SCMAcOdrDtlAsWork> writeAnswerList = new List<SCMAcOdrDtlAsWork>();
            foreach (UserSCMOrderAnswerRecord userSCMOrderAnswerRecord in userSCMOrderAnswerRecordList)
            {
                writeAnswerList.Add(userSCMOrderAnswerRecord.RealRecord);
            }

            // IOWriterの引数
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();
            // --- UPD m.suzuki 2011/02/22 ---------->>>>>
            //foreach (SCMAcOdrDataWork header in writeHeaderList)
            for ( int index = 0; index < writeHeaderList.Count; index++ )
            // --- UPD m.suzuki 2011/02/22 ----------<<<<<
            {
                // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                SCMAcOdrDataWork header = writeHeaderList[index];
                // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                SCMAcOdrDtCarWork car;
                List<SCMAcOdrDtlAsWork> answerList;

                // ヘッダに紐づくデータを取得
                this.GetRelatedSCMOdrData(header, writeAnswerList, writeCarList,
                                                out answerList, out car);

                // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                // 登録用SCM受注データ(header)の更新
                this.ReflectSCMAcOdrData( ref header, answerList );
                // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                ArrayList answerArrayList = new ArrayList();
                answerArrayList.AddRange(answerList);

                // 1更新処理リストに追加
                CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

                oneWriteList.Add(header); // 受注データ
                oneWriteList.Add(car); // 受注データ(車両)
                oneWriteList.Add(answerArrayList); // 受注明細データ(回答)

                writeList.Add(oneWriteList);
            }

            // 更新処理実行
            object writePara = writeList;

            // Write実行
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = SCMIO.UpdateData(writePara);

            return status;
        }
        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        /// <summary>
        /// 登録用SCM受注データ更新(header)
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        private void ReflectSCMAcOdrData( ref SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList )
        {
            //----------------------------------------
            // UserDB読み込み
            //----------------------------------------
            # region [UserDB読み込み]
            // 条件設定
            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = header.EnterpriseCode;
            readPara.InquiryNumber = header.InquiryNumber;
            readPara.InqOtherSecCd = header.InqOtherSecCd;
            readPara.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = header.InqOriginalSecCd;
            readPara.AnswerDivCds = new int[] { 0, 10, 20 }; // 0:アクションなし,10:一部回答,20:回答完了
            // (↓問合せ・発注・返品を区別する)
            readPara.InqOrdDivCd = header.InqOrdDivCd;
            readPara.CancelDivs = new short[] { header.CancelDiv };

            // 読み込み
            object retObj = new CustomSerializeArrayList();
            int status = this.IOWriteScmDB.ScmRead( ref retObj, (object)readPara );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;
            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList;
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList;

            // データ分割
            IOWriterUtil.ExpandSCMReadRet( retObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork );
            # endregion

            //----------------------------------------
            // 問い合わせと回答の付き合わせ
            //----------------------------------------
            bool existsAllAnswer = this.ExistsAllAnswer( header, answerList, scmDetailWorkList, scmAnswerWorkList );

            //----------------------------------------
            // header更新
            //----------------------------------------
            // 回答区分(10:一部回答,20:回答完了)
            if ( existsAllAnswer )
            {
                header.AnswerDivCd = 20; // 20:回答完了
            }
            else
            {
                header.AnswerDivCd = 10; // 10:一部回答
            }
        }

        /// <summary>
        /// 回答済みチェック処理処理
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        /// <param name="scmDetailWorkList"></param>
        /// <param name="scmAnswerWorkList"></param>
        /// <returns>true: 明細に対して回答が全て存在する。／false: まだ未回答の明細がある。</returns>
        private bool ExistsAllAnswer( SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList, List<SCMAcOdrDtlIqWork> scmDetailWorkList, List<SCMAcOdrDtlAsWork> scmAnswerWorkList )
        {
            // 問い合わせゼロ件なら全て回答済みとみなす
            if ( scmDetailWorkList == null || scmDetailWorkList.Count.Equals( 0 ) ) return true;

            // それ以外で回答ゼロ件なら未回答ありとみなす。
            if ( (answerList == null || answerList.Count.Equals( 0 )) &&
                 (scmAnswerWorkList == null || scmAnswerWorkList.Count.Equals( 0 )) ) return false;


            foreach ( SCMAcOdrDtlIqWork inq in scmDetailWorkList )
            {
                // 30:キャンセル確定はチェック対象外(回答不要の為)
                if ( inq.CancelCndtinDiv == 30 ) continue;

                bool existsAns = false;

                // 今回更新する回答リストから探す
                foreach ( SCMAcOdrDtlAsWork ans in answerList )
                {
                    if ( IsParenthoodRowNumber( ans, inq ) )
                    {
                        existsAns = true;
                        break;
                    }
                }

                if ( !existsAns )
                {
                    // 既にUserDBに存在する回答リストから探す
                    foreach ( SCMAcOdrDtlAsWork ans in scmAnswerWorkList )
                    {
                        if ( IsParenthood( ans, inq ) )
                        {
                            existsAns = true;
                            break;
                        }
                    }
                }

                // 回答が無い明細が１件でもあればfalse ⇒ 一部回答
                if ( !existsAns )
                {
                    return false;
                }
            }

            // 全件回答がある ⇒ 回答済み
            return true;
        }
        /// <summary>
        /// 対応するか判定します。
        /// </summary>
        /// <param name="ans">検索結果の回答データ</param>
        /// <param name="inq">検索結果の明細データ</param>
        /// <returns>
        /// ※リモートの検索結果を前提としてるため、問合せ行番号と問合せ行番号枝番の比較のみです・
        /// <c>true</c> :対応します。<br/>
        /// <c>false</c>:対応しません。
        /// </returns>
        internal static bool IsParenthood( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            if ( ans.InqRowNumber.Equals( inq.InqRowNumber ) && ans.InqRowNumDerivedNo.Equals( inq.InqRowNumDerivedNo ) )
            {
                if ( ans.UpdateDate > inq.UpdateDate )
                {
                    return true;
                }
                else if ( ans.UpdateDate == inq.UpdateDate )
                {
                    return (ans.UpdateTime > inq.UpdateTime);
                }
            }
            return false;
        }
        /// <summary>
        /// 対応するか判定します。(行番号・行番号枝番のみで判定)
        /// </summary>
        /// <param name="ans"></param>
        /// <param name="inq"></param>
        /// <returns></returns>
        internal static bool IsParenthoodRowNumber( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            if ( ans.InqRowNumber.Equals( inq.InqRowNumber ) && ans.InqRowNumDerivedNo.Equals( inq.InqRowNumDerivedNo ) )
            {
                return true;
            }
            return false;
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<
        #endregion

        #region <削除ボタン押下時の削除処理>
        /// <summary>
        /// 削除ボタン押下時の削除処理
        /// </summary>
        /// <returns></returns>
        protected override int ExecuteDelete(DataRowView drv)
        {
            // キーの取得
            string inqOriginalEpCd = drv.Row[SendingHeaderTable.InqOriginalEpCdColumn.ColumnName].ToString().Trim();	//@@@@20230303
            string inqOriginalSecCd = drv.Row[SendingHeaderTable.InqOriginalSecCdColumn.ColumnName].ToString();
            string inqOtherEpCd = drv.Row[SendingHeaderTable.InqOtherEpCdColumn.ColumnName].ToString();
            string inqOtherSecCd = drv.Row[SendingHeaderTable.InqOtherSecCdColumn.ColumnName].ToString();
            Int64 inquiryNumber = (Int64)drv.Row[SendingHeaderTable.InquiryNumberColumn.ColumnName];
            Int32 inqOrdDivCd = (Int32)drv.Row[SendingHeaderTable.InqOrdDivCdColumn.ColumnName];
            Int32 acptAnOdrStatus = (Int32)drv.Row[SendingHeaderTable.AcptAnOdrStatusColumn.ColumnName];
            string salesSlipNum = drv.Row[SendingHeaderTable.SalesSlipNumColumn.ColumnName].ToString();

            // 該当データの取得
            List<SCMAcOdrDataWork> allHeader = SCMIO.CreateUserHeaderRecordList();
            List<SCMAcOdrDtCarWork> allCar = SCMIO.CreateUserCarRecordList();
            List<SCMAcOdrDtlAsWork> allAnswer = SCMIO.CreateUserAnswerRecordList();

            SCMAcOdrDataWork header = allHeader.Find(
                delegate(SCMAcOdrDataWork headerWork)
                {
                    if (headerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && headerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && headerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && headerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && headerWork.InquiryNumber == inquiryNumber
                        && headerWork.InqOrdDivCd == inqOrdDivCd
                        && headerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && headerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            SCMAcOdrDtCarWork car = allCar.Find(
                delegate(SCMAcOdrDtCarWork carWork)
                {
                    if (carWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && carWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && carWork.InquiryNumber == inquiryNumber
                        && carWork.AcptAnOdrStatus == acptAnOdrStatus
                        && carWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            List<SCMAcOdrDtlAsWork> answerList = allAnswer.FindAll(
                delegate(SCMAcOdrDtlAsWork answerWork)
                {
                    if (answerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && answerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && answerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && answerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && answerWork.InquiryNumber == inquiryNumber
                        && answerWork.InqOrdDivCd == inqOrdDivCd
                        && answerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && answerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 更新年月日の更新
            DateTime updateDate = DateTime.Now;
            Int32 updateTime = updateDate.Hour * 10000000 + updateDate.Minute * 100000 + updateDate.Second * 1000 + updateDate.Millisecond;

            // ADD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------------->>>>>
            // 問合せ番号がゼロ（ダイレクト回答）時は物理削除を行う
            if (header.InquiryNumber == 0)
            {
                header.LogicalDeleteCode = 1;
                if (car != null)
                {
                    car.LogicalDeleteCode = 1;
                }
            }
            // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------<<<<<

            header.UpdateDate = updateDate;
            header.UpdateTime = updateTime;

            foreach (SCMAcOdrDtlAsWork answer in answerList)
            {
                // ADD 2014/04/09 SCM仕掛一覧№10641対応 ---------------------------------->>>>>
                // 問合せ番号がゼロ（ダイレクト回答）時は物理削除を行う
                if (header.InquiryNumber == 0)
                {
                    answer.LogicalDeleteCode = 1;
                }
                // ADD 2014/04/09 SCM仕掛一覧№10641対応 ----------------------------------<<<<<
                answer.UpdateDate = updateDate;
                answer.UpdateTime = updateTime;
            }

            ArrayList answerArrayList = new ArrayList();
            answerArrayList.AddRange(answerList);

            // IOWriterの引数
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();

            // 1更新処理リストに追加
            CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

            oneWriteList.Add(header); // 受注データ
            if (car != null)
            {
                oneWriteList.Add(car); // 受注データ(車両)
            }
            oneWriteList.Add(answerArrayList); // 受注明細データ(回答)

            writeList.Add(oneWriteList);

            object writePara = writeList;

            int status = SCMIO.UpdateData(writePara);

            return status;
        }
        #endregion

        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PMNSNormalController() : base() { }

        #endregion // </Constructor>
    }
}
