//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産発注処理
// プログラム概要   : 日産発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                  日産Web-UOEとの連携用データとして、UOE発注データから日産Web-UOE用システム連携ファイルの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/18  修正内容 : Redmine4004-4006、4030、4043対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/19  修正内容 : Redmine4006、4030対応
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 呉元嘯
// 修 正 日  2010/03/29  修正内容 : Redmine4311対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 譚洪
// 修 正 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 譚洪
// 修 正 日  2011/01/13  修正内容 : Redmine18531対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/02/25  修正内容 : 日産UOE自動化、Ｂ対応分の組み込み
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : 曹文傑
// 修 正 日  2011/03/15  修正内容 : Redmine #19908の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI 今野
// 作 成 日  2012/09/24  修正内容 : トヨタ発注処理データのソート処理追加
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;           // ADD 2010/12/31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 日産発注処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 日産発注処理のアクセス制御を行います。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2010/03/08</br>
    /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4004-4006、4030、4043対応</br>
    /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4006、4030対応</br>
    /// <br>UpdateNote : 2010/03/29 呉元嘯 Redmine4311対応</br>
    /// <br>UpdateNote : 2010/12/31 譚洪 UOE自動化改良</br>
    /// <br>UpdateNote : 2011/01/13 譚洪 Redmine18531対応</br>
    /// <br>UpdateNote : 2011/02/25 曹文傑 日産UOE自動化、Ｂ対応分の組み込み</br>
    /// <br>UpdateNote : 2011/03/15 曹文傑 Redmine #19908の対応</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// </remarks>
    public partial class NissanOrderProcAcs
    {
        // --- ADD 2012/09/24 ---------------------------->>>>>
        # region ■Inner Class
        /// <summary>
        /// トヨタ発注処理データソート用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : トヨタ発注処理データのソートを行うクラスです。</br>
        /// <br>Note       : 呼出番号、呼出番号枝番の順にソートします。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : IComparer<UOEOrderDtlWork>
        {
            #region IComparer メンバ

            public int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // NULLチェックする
                if (x == null || y == null)
                {
                    throw new ArgumentNullException();
                }

                // データを比較する
                if (x.OnlineNo > y.OnlineNo)
                {
                    return 1;
                }
                else if (x.OnlineNo < y.OnlineNo)
                {
                    return -1;
                }
                else
                {
                    if (x.OnlineRowNo > y.OnlineRowNo)
                    {
                        return 1;
                    }
                    else if (x.OnlineRowNo < y.OnlineRowNo)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 仕入明細データソート用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入明細データのソートを行うクラスです。</br>
        /// <br>Note       : シーケンス番号順にソートします。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class StockDetailWorkComparer : IComparer<StockDetailWork>
        {
            private readonly List<long> _CommonSeqNoList = new List<long>();

            public StockDetailWorkComparer(List<UOEOrderDtlWork> _uOEOrderDtlWorkList)
            {
                // シーケンス番号をリスト化する
                foreach (UOEOrderDtlWork item in _uOEOrderDtlWorkList)
                {
                    _CommonSeqNoList.Add(item.CommonSeqNo);
                }
            }

            #region IComparer メンバ

            public int Compare(StockDetailWork x, StockDetailWork y)
            {
                // NULLチェックする
                if (x == null || y == null || _CommonSeqNoList == null)
                {
                    throw new ArgumentNullException();
                }

                // インデックスを取得する
                int a = _CommonSeqNoList.IndexOf(x.CommonSeqNo);
                int b = _CommonSeqNoList.IndexOf(y.CommonSeqNo);
                if (a < 0 || b < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // データを比較する
                if (a > b)
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            #endregion
        }
        #endregion
        // --- ADD 2012/09/24 ----------------------------<<<<<

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2010/12/31

        //アクセスクラス
        private static NissanOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //データーテーブル
        private NissanOrderProcDataSet _dataSet;
        private NissanOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //従業員マスタ
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス

        //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private int setCount = 0;

        // ファイル（ストリーム）
        private FileStream _uoeFileStream = null;

        private string _commAssemblyId = string.Empty;  // ADD 2011/02/25

        private UOESupplier _uOESupplier = null;  // ADD 2011/03/15
        # endregion

        // --------UPD 2010/03/18 -------->>>>>
        #region F2WUOETextEditOrder
        //#region TelegramEditOrder0203
        ///// <summary>
        ///// ＵＯＥ送信電文作成＜発注＞（トヨタＰＤ４）
        ///// </summary>
        /// <summary>
        /// 日産Web-UOEシステム連携ファイル(発注)作成
        /// </summary>
        //public class F2WUOETextEditOrder
        private class F2WUOETextEditOrder
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//明細行数
            private const Int32 ctSndTelegramLen = 270; //送信電文サイズ
            # endregion

            #region Private Members
            //発注電文
            private byte[] disposalFlg = new byte[1];	/*      処理区分       */
            private byte[] relaNo = new byte[2];		/*           連番            */
            private byte[] remark = new byte[10];		/*      	 コメント         */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ﾗｲﾝ      部品番号        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          数量              */
            private byte[][] space = new byte[ctDetailLen -1][];	/*          Space              */
            private byte[] lastSpace = new byte[120];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (復改)          */

            //変数
            private Int32 _ln = 0;

            #endregion

            # region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
            //public TelegramEditOrder0203()
            public F2WUOETextEditOrder()
			{
                for (int i = 0; i < ctDetailLen; i++)
				{
                    posNo[i] = new byte[12];	// 部品番号
                    goodsCount[i] = new byte[4];	// 数量
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
				}
                for (int j = 0; j < 2; j++)
                {
                    // (復改)
                    fg[j] = new byte[1];
                }
				Clear();
			}
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                _ln = 0;
                
                // 明細部
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// 処理区分
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// 連番
                UoeCommonFnc.MemSet(ref remark, 0x20, remark.Length);		// コメント
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// 部品番号
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// 数量
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (復改)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <param name="page">ワーク</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (_ln == 0)
                {
                    # region ＜ヘッダー部＞
                    //＜ヘッダー部＞

                    // 処理区分 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // 連番 = 8部番毎ｶｳﾝﾄｱｯﾌﾟ
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark2, remark.Length);
                    // (復改):改行：CR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region ＜明細部＞
                //＜明細部＞
                if (_ln < ctDetailLen)
                {
                    // 部品番号
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //数量
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    if (_ln != ctDetailLen -1)
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ1桁)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ120桁)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //明細数インクリメント
                    _ln++;
                }

                # endregion

            }
            # endregion
            # endregion

            # region private Methods
            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //ヘッダー部
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// 処理区分
                ms.Write(relaNo, 0, relaNo.Length);			// 連番
                ms.Write(remark, 0, remark.Length);			// コメント
                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// 部品番号
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// 数量
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (復改)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        //業務区分
        private const Int32 ctTerminalDiv_Order = 1;	//発注
        #endregion
        // --------UPD 2010/03/18 --------<<<<<

        // --------ADD 2010/12/31--------->>>>>
        #region AUTOF2WUOETextEditOrder
        //#region TelegramEditOrder0203
        ///// <summary>
        ///// ＵＯＥ送信電文作成＜発注＞（トヨタＰＤ４）
        ///// </summary>
        /// <summary>
        /// 日産Web-UOEシステム連携ファイル(発注)作成
        /// </summary>
        //public class F2WUOETextEditOrder
        private class AUTOF2WUOETextEditOrder
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//明細行数
            private const Int32 ctSndTelegramLen = 270; //送信電文サイズ
            # endregion

            #region Private Members
            //発注電文
            private byte[] disposalFlg = new byte[1];	/*      処理区分       */
            private byte[] relaNo = new byte[2];		/*           連番            */
            private byte[] remark = new byte[10];		/*      	 コメント         */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ﾗｲﾝ      部品番号        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          数量              */
            private byte[][] space = new byte[ctDetailLen - 1][];	/*          Space              */
            private byte[] lastSpace = new byte[120];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (復改)          */

            //変数
            private Int32 _ln = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// </summary>
            //public TelegramEditOrder0203()
            public AUTOF2WUOETextEditOrder()
            {
                for (int i = 0; i < ctDetailLen; i++)
                {
                    posNo[i] = new byte[12];	// 部品番号
                    goodsCount[i] = new byte[4];	// 数量
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    // (復改)
                    fg[j] = new byte[1];
                }
                Clear();
            }
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                _ln = 0;

                // 明細部
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// 処理区分
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// 連番
                UoeCommonFnc.MemSet(ref remark, 0x20, remark.Length);		// コメント
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// 部品番号
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// 数量
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (復改)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <param name="page">ワーク</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (_ln == 0)
                {
                    # region ＜ヘッダー部＞
                    //＜ヘッダー部＞

                    // 処理区分 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // 連番 = 8部番毎ｶｳﾝﾄｱｯﾌﾟ
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark1, remark.Length);
                    // (復改):改行：CR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region ＜明細部＞
                //＜明細部＞
                if (_ln < ctDetailLen)
                {
                    // 部品番号
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //数量
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    if (_ln != ctDetailLen - 1)
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ1桁)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ120桁)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //明細数インクリメント
                    _ln++;
                }

                # endregion

            }
            # endregion
            # endregion

            # region private Methods
            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //ヘッダー部
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// 処理区分
                ms.Write(relaNo, 0, relaNo.Length);			// 連番
                ms.Write(remark, 0, remark.Length);			// コメント
                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// 部品番号
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// 数量
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (復改)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // --------ADD 2010/12/31--------->>>>>
        #region F2WUOESubTextEditOrder
        ///// <summary>
        ///// ＵＯＥ送信電文作成＜発注＞（トヨタＰＤ４）
        ///// </summary>
        /// <summary>
        /// 日産Web-UOEシステム連携ファイル(発注)作成
        /// </summary>
        private class F2WUOESubTextEditOrder
        {

            # region Const Members
            private const Int32 ctSubDetailLen = 8;	//サブ明細行数
            private const Int32 ctSndTelegramLen = 270; //送信電文サイズ
            # endregion

            #region Private Members
            //サブ発注電文
            private byte[] subDisposalFlg = new byte[1];	/*      サブ処理区分       */
            private byte[] subRelaNo = new byte[2];		/*           サブ連番            */
            private byte[] subDeliGoodsDiv = new byte[1];		/*           サブ納品区分            */
            private byte[] subEmployee = new byte[2];		/*           サブ依頼者            */
            private byte[] subSectionCode = new byte[3];		/*           サブ指定拠点            */
            private byte[] subRemark = new byte[10];		/*      	 サブコメント         */
            private byte[][] subBoCode = new byte[ctSubDetailLen][];		/*      	 サブBO区分         */
            private byte[][] fg = new byte[2][];	/*          (復改)          */

            //変数
            private Int32 _subLn = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public F2WUOESubTextEditOrder()
            {
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    subBoCode[i] = new byte[1];	// 部品番号
                }
                for (int j = 0; j < 2; j++)
                {
                    // (復改)
                    fg[j] = new byte[1];
                }
                Clear();
            }
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                _subLn = 0;

                // 明細部
                UoeCommonFnc.MemSet(ref subDisposalFlg, 0x20, subDisposalFlg.Length);		// 処理区分
                UoeCommonFnc.MemSet(ref subRelaNo, 0x20, subRelaNo.Length);		// 連番
                UoeCommonFnc.MemSet(ref subDeliGoodsDiv, 0x20, subDeliGoodsDiv.Length);		// 納品区分
                UoeCommonFnc.MemSet(ref subEmployee, 0x20, subEmployee.Length);		// 依頼者
                UoeCommonFnc.MemSet(ref subSectionCode, 0x20, subSectionCode.Length);		// 指定拠点
                UoeCommonFnc.MemSet(ref subRemark, 0x20, subRemark.Length);		// コメント
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref subBoCode[i], 0x20, subBoCode[i].Length);	// 部品番号
                }
                // (復改)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region サブデータ編集処理
            /// <summary>
            /// サブデータ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <param name="page">ワーク</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (_subLn == 0)
                {
                    # region ＜ヘッダー部＞
                    //＜ヘッダー部＞

                    // 処理区分 = "H";
                    UoeCommonFnc.MemSet(ref subDisposalFlg, 0x48, subDisposalFlg.Length);
                    // 連番 = 8部番毎ｶｳﾝﾄｱｯﾌﾟ
                    UoeCommonFnc.MemCopy(ref subRelaNo, page.ToString("00"), subRelaNo.Length);
                    // 納品区分
                    UoeCommonFnc.MemCopy(ref subDeliGoodsDiv, work.UOEDeliGoodsDiv, subDeliGoodsDiv.Length);
                    // 依頼者
                    UoeCommonFnc.MemCopy(ref subEmployee, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(), subEmployee.Length), subEmployee.Length);
                    // 指定拠点
                    UoeCommonFnc.MemCopy(ref subSectionCode, work.UOEResvdSection, subSectionCode.Length);
                    // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                    UoeCommonFnc.MemCopy(ref subRemark, work.UoeRemark2, subRemark.Length);
                    // (復改):改行：CR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region ＜サブ明細部＞
                //＜明細部＞
                if (_subLn < ctSubDetailLen)
                {
                    // BO区分
                    UoeCommonFnc.MemCopy(ref subBoCode[_subLn], work.BoCode, subBoCode[_subLn].Length);

                    //明細数インクリメント
                    _subLn++;
                }

                # endregion

            }
            # endregion
            # endregion

            # region private Methods
            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //ヘッダー部
                ms.Write(subDisposalFlg, 0, subDisposalFlg.Length);		// 処理区分
                ms.Write(subRelaNo, 0, subRelaNo.Length);			// 連番
                ms.Write(subDeliGoodsDiv, 0, subDeliGoodsDiv.Length);	// 納品区分
                ms.Write(subEmployee, 0, subEmployee.Length);			// 依頼者
                ms.Write(subSectionCode, 0, subSectionCode.Length);			// 指定拠点
                ms.Write(subRemark, 0, subRemark.Length);			// コメント
                //明細部
                for (int i = 0; i < ctSubDetailLen; i++)
                {
                    ms.Write(subBoCode[i], 0, subBoCode[i].Length);	// BO区分
                }
                // (復改)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // ---ADD 2011/02/25-------------->>>>>
        #region F2WUOETextEditOrder2
        /// <summary>
        /// 日産Web-UOEシステム連携ファイル(発注)作成(プログラムIDが「0205」と「0206」の場合)
        /// </summary>
        private class F2WUOETextEditOrder2
        {

            # region Const Members
            private const Int32 ctDetailLen = 8;	//明細行数
            private const Int32 ctSndTelegramLen = 270; //送信電文サイズ
            # endregion

            #region Private Members
            //発注電文
            private byte[] disposalFlg = new byte[1];	/*      処理区分       */
            private byte[] relaNo = new byte[2];		/*           連番            */
            private byte[] shippingCd = new byte[6];		/*    お届け先コード     */
            private byte[] deliGoodsDiv = new byte[1];		/*       納品区分      */
            private byte[] employeeCd = new byte[2];		/*     依頼者コード        */
            private byte[] resvdSection = new byte[3];		/*       指定拠点      */
            private byte[] remark1 = new byte[10];		/*      	 コメント1        */
            private byte[] remark2 = new byte[10];		/*      	 コメント2        */
            private byte[][] posNo = new byte[ctDetailLen][];	/* ﾗｲﾝ      部品番号        */
            private byte[][] goodsCount = new byte[ctDetailLen][];	/*          数量              */
            private byte[][] boCode = new byte[ctDetailLen][];	/*          BO            */
            private byte[][] space = new byte[ctDetailLen - 1][];	/*          Space              */
            private byte[] lastSpace = new byte[127];	/*          Space              */
            private byte[][] fg = new byte[2][];	/*          (復改)          */

            //変数
            private Int32 _ln = 0;

            #endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public F2WUOETextEditOrder2()
            {
                for (int i = 0; i < ctDetailLen; i++)
                {
                    posNo[i] = new byte[12];	// 部品番号
                    goodsCount[i] = new byte[4];	// 数量
                    boCode[i] = new byte[1];   // BO
                    if (i < ctDetailLen - 1)
                    {
                        space[i] = new byte[1];	// Space
                    }
                }
                for (int j = 0; j < 2; j++)
                {
                    // (復改)
                    fg[j] = new byte[1];
                }
                Clear();
            }
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                _ln = 0;

                // ヘッダー部
                UoeCommonFnc.MemSet(ref disposalFlg, 0x20, disposalFlg.Length);		// 処理区分
                UoeCommonFnc.MemSet(ref relaNo, 0x20, relaNo.Length);		// 連番
                UoeCommonFnc.MemSet(ref shippingCd, 0x20, shippingCd.Length);		// お届け先コード
                UoeCommonFnc.MemSet(ref deliGoodsDiv, 0x20, deliGoodsDiv.Length);		// 納品区分
                UoeCommonFnc.MemSet(ref employeeCd, 0x20, employeeCd.Length);		// 依頼者コード
                UoeCommonFnc.MemSet(ref resvdSection, 0x20, resvdSection.Length);		// 指定拠点
                UoeCommonFnc.MemSet(ref remark1, 0x20, remark1.Length);		// コメント1
                UoeCommonFnc.MemSet(ref remark2, 0x20, remark2.Length);		// コメント2

                // 明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref posNo[i], 0x20, posNo[i].Length);	// 部品番号
                    UoeCommonFnc.MemSet(ref goodsCount[i], 0x20, goodsCount[i].Length);	// 数量
                    UoeCommonFnc.MemSet(ref boCode[i], 0x20, boCode[i].Length);	// BO
                    if (i == ctDetailLen - 1)
                    {
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);	// Space
                    }
                    else
                    {
                        UoeCommonFnc.MemSet(ref space[i], 0x20, space[i].Length);	// Space
                    }
                }
                // (復改)
                UoeCommonFnc.MemSet(ref fg[0], 0x20, fg[0].Length);
                UoeCommonFnc.MemSet(ref fg[1], 0x20, fg[1].Length);
            }
            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <param name="page">ワーク</param>
            public void Telegram(UOEOrderDtlWork work, int page)
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (_ln == 0)
                {
                    # region ＜ヘッダー部＞
                    //＜ヘッダー部＞

                    // 処理区分 = "H";
                    UoeCommonFnc.MemSet(ref disposalFlg, 0x48, disposalFlg.Length);
                    // 連番 = 8部番毎ｶｳﾝﾄｱｯﾌﾟ
                    UoeCommonFnc.MemCopy(ref relaNo, page.ToString("00"), relaNo.Length);
                    // お届け先コード = 画面のお届け先コード
                    UoeCommonFnc.MemCopy(ref shippingCd, work.ShippingCd, shippingCd.Length);
                    // 納品区分 = 画面の納品区分
                    UoeCommonFnc.MemCopy(ref deliGoodsDiv, work.UOEDeliGoodsDiv, deliGoodsDiv.Length);
                    // 依頼者コード = 画面の依頼者コード
                    UoeCommonFnc.MemCopy(ref employeeCd, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(),employeeCd.Length), employeeCd.Length);
                    // 指定拠点 = 画面の指定拠点
                    UoeCommonFnc.MemCopy(ref resvdSection, work.UOEResvdSection, resvdSection.Length);
                    // コメント1 = 画面のリマーク１
                    UoeCommonFnc.MemCopy(ref remark1, work.UoeRemark1, remark1.Length);
                    // コメント2 = (ID0205:連携番号 ID0206:画面のリマーク２)
                    UoeCommonFnc.MemCopy(ref remark2, work.UoeRemark2, remark2.Length);
                    // (復改):改行：CR-LF
                    UoeCommonFnc.MemSet(ref fg[0], 0x0D, fg[0].Length);
                    UoeCommonFnc.MemSet(ref fg[1], 0x0A, fg[1].Length);
                    # endregion
                }

                # region ＜明細部＞
                //＜明細部＞
                if (_ln < ctDetailLen)
                {
                    // 部品番号
                    UoeCommonFnc.MemCopy(ref posNo[_ln], work.GoodsNoNoneHyphen, posNo[_ln].Length);

                    //数量
                    UoeCommonFnc.MemCopy(ref goodsCount[_ln], String.Format("{0:D4}", (int)work.AcceptAnOrderCnt), goodsCount[_ln].Length);

                    // BO
                    UoeCommonFnc.MemCopy(ref boCode[_ln], work.BoCode, boCode[_ln].Length);

                    if (_ln != ctDetailLen - 1)
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ1桁)
                        UoeCommonFnc.MemSet(ref space[_ln], 0x20, space[_ln].Length);
                    }
                    else
                    {
                        // Space = " "(半角ｽﾍﾟｰｽ120桁)
                        UoeCommonFnc.MemSet(ref lastSpace, 0x20, lastSpace.Length);
                    }
                    //明細数インクリメント
                    _ln++;
                }

                # endregion

            }
            # endregion
            # endregion

            # region private Methods
            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //ヘッダー部
                ms.Write(disposalFlg, 0, disposalFlg.Length);		// 処理区分
                ms.Write(relaNo, 0, relaNo.Length);			// 連番
                ms.Write(shippingCd, 0, shippingCd.Length);			// お届け先コード
                ms.Write(deliGoodsDiv, 0, deliGoodsDiv.Length);			// 納品区分
                ms.Write(employeeCd, 0, employeeCd.Length);			// 依頼者コード
                ms.Write(resvdSection, 0, resvdSection.Length);			// 指定拠点
                ms.Write(remark1, 0, remark1.Length);			// コメント1
                ms.Write(remark2, 0, remark2.Length);			// コメント2
                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(posNo[i], 0, posNo[i].Length);	// 部品番号
                    ms.Write(goodsCount[i], 0, goodsCount[i].Length);	// 数量
                    ms.Write(boCode[i], 0, boCode[i].Length);	// BO
                    if (i < ctDetailLen - 1)
                    {
                        ms.Write(space[i], 0, space[i].Length);	// Space
                    }
                    else
                    {
                        ms.Write(lastSpace, 0, lastSpace.Length);	// Space
                    }
                }
                // (復改)
                ms.Write(fg[0], 0, fg[0].Length);
                ms.Write(fg[1], 0, fg[1].Length);
                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // ---ADD 2011/02/25--------------<<<<<

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4006、4030対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4006、4030対応</br>
        /// </remarks>
        private NissanOrderProcAcs()
        {
            // 変数初期化
            //this._dataSet = new NissanOrderProcDataSet();// DEL 2010/03/19
            //this._orderDataTable = this._dataSet.OrderExpansion;// DEL 2010/03/18
            // -----------DEL 2010/03/19------------>>>>>
            //this._orderDataTable = this.DataSet.OrderExpansion;// ADD 2010/03/18
            // -----------DEL 2010/03/19------------<<<<<
            //this.orderDataTable.Rows.Clear();// DEL 2010/03/18
            this.OrderDataTable.Rows.Clear();// ADD 2010/03/18

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
        }

        /// <summary>
        /// ＵＯＥ発注処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ発注処理アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注処理アクセスクラス インスタンス取得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public static NissanOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new NissanOrderProcAcs();
            }

            return _supplierAcs;
        }
        # endregion

        #region データ変更フラグ
        /// <summary>データ変更フラグプロパティ（true:変更あり false:変更なし）</summary>
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
            }
        }
        #endregion

        #region ファイル（ストリーム）
        /// <summary>UOEfileStream</summary>
        //public FileStream UoeFileStream// DEL 2010/03/18
        private FileStream UoeFileStream// ADD 2010/03/18
        {
            get
            {
                return this._uoeFileStream;
            }
            set
            {
                this._uoeFileStream = value;
            }
        }
        #endregion

        # region 従業員マスタキャッシュ処理
        /// <summary>
        /// 従業員マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void CacheEmployee()
        {
            object returnEmployee;
            _employeeWork = new Dictionary<string, EmployeeWork>();
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = this._enterpriseCode; ;

            try
            {

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            if (employeeWork.LogicalDeleteCode == 0 &&
                                _employeeWork.ContainsKey(employeeWork.EmployeeCode.Trim()) != true)
                            {
                                this._employeeWork.Add(employeeWork.EmployeeCode.Trim(), employeeWork);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                _employeeWork = new Dictionary<string, EmployeeWork>();
            }

        }

        /// <summary>
        /// 従業員存在チェック
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員存在チェックを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public bool GetEmployeeName(string employeeCode, out string employeeName)
        {
            employeeName = string.Empty;

            if (!this._employeeWork.ContainsKey(employeeCode))
            {
                return false;
            }

            employeeName = this._employeeWork[employeeCode].Name.Trim();

            return true;
        }

        # endregion

        # region 発注検索データセット取得処理
        /// <summary>
        /// 発注検索データセット取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データセット取得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4006対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4006対応</br>
        /// </remarks>
        //public NissanOrderProcDataSet DataSet// DEL 2010/03/18
        private NissanOrderProcDataSet DataSet// ADD 2010/03/18
        {
            // ---------UPD 2010/03/19--------->>>>>
            //get { return this._dataSet; }
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new NissanOrderProcDataSet();
                }
                return _dataSet;
            }
            // ---------UPD 2010/03/19---------<<<<<
        }
        /// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        /// <remarks>
        /// <br>Note       : 有効入力行存在判定を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// </remarks>
        public bool StockRowExists()
        {
            //if (this._orderDataTable.Rows.Count > 0)// DEL 2010/03/18
            if (this.OrderDataTable.Rows.Count > 0)// ADD 2010/03/18
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region 発注検索データテーブル取得処理
        /// <summary>
        /// 発注検索データテーブル取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データテーブル取得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// <br>UpdateNote : 2010/03/19 呉元嘯 Redmine4030対応</br>
        /// </remarks>
        //public NissanOrderProcDataSet.OrderExpansionDataTable orderDataTable
        public NissanOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            // ------------UPD 2010/03/19------------>>>>>
            //get { return _orderDataTable; }
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
            // ------------UPD 2010/03/19------------<<<<<
        }
        # endregion

        #region 選択・非選択状態処理(指定型)
        /// <summary>
        /// 選択・非選択状態処理(指定型)
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <param name="selected">true:選択,false:非選択</param>
        /// <remarks>
        /// <br>Note       : 選択・非選択状態処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            //DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);// DEL 2010/03/18
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);// ADD 2010/03/18

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                //_row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;// DEL 2010/03/18
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;// ADD 2010/03/18
                _row.EndEdit();
            }
        }
        # endregion

        # region ■ 画面データクラス→＜検索用＞条件抽出クラス ■
        /// <summary>
        /// 画面データクラス→＜検索用＞条件抽出クラス
        /// </summary>
        /// <param name="inpDisplay">画面データクラス</param>
        /// <remarks>
        /// <br>Note       : 条件抽出を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(NissanInpDisplay inpDisplay)
        {
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            para.DataSendCodes = new int[1];
            para.DataSendCodes[0] = 0;
            return para;
        }

        // --- ADD 2010/12/31 --------- >>>>>
        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部入力値の保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>Update Note: 2011/02/25 曹文傑</br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        public void UpdtHedaerItem(NissanInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //オンライン番号
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１
                dataRow[this.OrderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // 従業員コード
                dataRow[this.OrderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // 従業員名称

                dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // 納品区分
                dataRow[this.OrderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;                // UOE指定拠点
                dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // 納品区分名称
                dataRow[this.OrderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;                // UOE指定拠点名称
                // ---ADD 2011/02/25------------->>>>>
                dataRow[this.OrderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // ＵＯＥリマーク２
                dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName] = inpHedDisplay.ShippingCd;                    // お届け先コード
                // ---ADD 2011/02/25-------------<<<<<
            }

        }
        // --- ADD 2010/12/31 --------- <<<<<

        # endregion

        # endregion

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// <br>Update Note: 2011/02/25 曹文傑</br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        public int SearchDB(NissanInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //グリッド用テーブルのクリア
                //this.orderDataTable.Rows.Clear();// DEL 2010/03/18
                this.OrderDataTable.Rows.Clear();// ADD 2010/03/18

                //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return (status);
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        return (status);
                    }
                }

                int index = 1;

                // --- ADD 2012/09/24 ---------------------------->>>>>
                // 取得した発注データをソートする(呼出番号、呼出番号枝番の順でソート)
                UOEOrderDtlWorkComparer UoeComp = new UOEOrderDtlWorkComparer();
                _uOEOrderDtlWorkList.Sort(UoeComp);

                // ソートした発注データのシーケンス番号順で、仕入明細データをソートする
                StockDetailWorkComparer StockComp = new StockDetailWorkComparer(_uOEOrderDtlWorkList);
                _stockDetailWorkList.Sort(StockComp);
                // --- ADD 2012/09/24 ----------------------------<<<<<

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    //NissanOrderProcDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();// DEL 2010/03/18
                    NissanOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();// ADD 2010/03/18
                    row.OrderNo = index++;
                    row.OnlineNo = uOEOrderDtlWork.OnlineNo;
                    row.InputDay = uOEOrderDtlWork.InputDay;
                    row.CustomerSnm = uOEOrderDtlWork.CustomerSnm;
                    row.CashRegisterNo = uOEOrderDtlWork.CashRegisterNo;
                    row.GoodsMakerCd = uOEOrderDtlWork.GoodsMakerCd;
                    row.GoodsNo = uOEOrderDtlWork.GoodsNo;
                    row.GoodsName = uOEOrderDtlWork.GoodsName;
                    row.AcceptAnOrderCnt = uOEOrderDtlWork.AcceptAnOrderCnt;
                    row.UoeRemark1 = uOEOrderDtlWork.UoeRemark1;
                    // ---ADD 2011/02/25--------------->>>>
                    if ("0206".Equals(uOEOrderDtlWork.CommAssemblyId))
                    {
                        row.UoeRemark2 = uOEOrderDtlWork.UoeRemark2;
                    }
                    else
                    {
                        row.UoeRemark2 = string.Empty;
                    }

                    row.ShippingCd = string.Empty;
                    // ---ADD 2011/02/25---------------<<<<
                    row.EmployeeCode = uOEOrderDtlWork.EmployeeCode;
                    row.EmployeeName = uOEOrderDtlWork.EmployeeName;
                    row.OnlineRowNo = uOEOrderDtlWork.OnlineRowNo;
                    row.UOEKind = uOEOrderDtlWork.UOEKind;
                    row.CommonSeqNo = uOEOrderDtlWork.CommonSeqNo;
                    row.SupplierFormal = uOEOrderDtlWork.SupplierFormal;
                    row.StockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                    row.UOEDeliGoodsDiv = uOEOrderDtlWork.UOEDeliGoodsDiv;
                    row.UOEResvdSection = uOEOrderDtlWork.UOEResvdSection;
                    row.FollowDeliGoodsDiv = uOEOrderDtlWork.FollowDeliGoodsDiv;
                    row.BoCode = uOEOrderDtlWork.BoCode;


                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    //this.orderDataTable.AddOrderExpansionRow(row);// DEL 2010/03/18
                    this.OrderDataTable.AddOrderExpansionRow(row);// ADD 2010/03/18
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        # endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除件数取得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18-----------<<<<<
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// ＵＯＥ発注データ選択しないの件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ選択しないの件数取得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
                // ----------UPD 2010/03/18-----------<<<<<
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region 発注ブロック数の算出
        /// <summary>
        /// ＵＯＥ発注データ発注セット数の算出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注セット数の算出を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// <br>Update Note: 2011/02/25 曹文傑</br>
        /// <br>             日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                // ----------UPD 2010/03/18----------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18-----------<<<<<
                // 送信明細数
                int detailIndex = 0;
                // 前回ｵﾝﾗｲﾝ番号
                int bfOnlineNo = 0;
                // ---UPD 2011/02/25--------------->>>>>
                //// 最大8明細
                //int maxDetailCount = 8;
                int maxDetailCount = 0;
                if ("0206".Equals(this._commAssemblyId))
                {
                    // 最大6明細
                    maxDetailCount = 6;
                }
                else
                {
                    // 最大8明細
                    maxDetailCount = 8;
                }
                // ---UPD 2011/02/25---------------<<<<<
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    //Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];// DEL 2010/03/18
                    Int32 onlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];// ADD 2010/03/18

                    if (ix == 0)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // 同じｵﾝﾗｲﾝ番号ではない場合
                    else if (bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // 同じｵﾝﾗｲﾝ番号場合
                    else if (bfOnlineNo == onlineNo)
                    {
                        detailIndex++;
                        if (detailIndex > maxDetailCount)
                        {
                            count++;
                            detailIndex = 1;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            this.setCount = count;
            return count;
        }

        # endregion

        #region ＵＯＥ発注データ更新処理
        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
               out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, 
               out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //保存データ取得処理
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                stockDetailWorkDelList = new List<StockDetailWork>();

                status = GetUOEOrderDtlWorkFromRowData(1, cashRegisterNo, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);

                // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                // 更新
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                return -1;
            }

            return status;
        }
        # endregion

        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4004、4043対応</br>
        /// <br>UpdateNote : 2011/02/25 曹文傑 日産UOE自動化、Ｂ対応分の組み込み</br>
        /// </remarks>
        public int WriteText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);// ADD 2010/03/18
            try
            {
                //TelegramEditOrder0203 telegramEditOrder0203 = new TelegramEditOrder0203();// DEL 2010/03/18
                F2WUOETextEditOrder f2WUOETextEditOrder = new F2WUOETextEditOrder();// ADD 2010/03/18
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //送信電文(JIS)
                        //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                        f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                        onlineNo = work.OnlineNo;
                    }
                    //発注番号が変更された
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                        tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //電文明細クラス全てのクリア
                        //telegramEditOrder0203.Clear();// DEL 2010/03/18
                        f2WUOETextEditOrder.Clear();// ADD 2010/03/18
                        //送信電文(JIS)
                        //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                        f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                            tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            //telegramEditOrder0203.Clear();// DEL 2010/03/18
                            f2WUOETextEditOrder.Clear();// ADD 2010/03/18

                            //送信電文(JIS)
                            //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                            f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                            detailCount = 1;
                        }
                        else
                        {
                            //送信電文(JIS)
                            //telegramEditOrder0203.Telegram(work, dataCount);// DEL 2010/03/18
                            f2WUOETextEditOrder.Telegram(work, dataCount);// ADD 2010/03/18
                        }
                    }

                }

                //tempbyte = telegramEditOrder0203.ToByteArray();// DEL 2010/03/18
                tempbyte = f2WUOETextEditOrder.ToByteArray();// ADD 2010/03/18

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //電文明細クラス全てのクリア
                //telegramEditOrder0203.Clear();// DEL 2010/03/18
                f2WUOETextEditOrder.Clear();// ADD 2010/03/18

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //this.CloseFileStream(this.UoeFileStream);// DEL 2010/03/18
                this.CloseFileStream();// ADD 2010/03/18
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ---ADD 2011/02/25-------------------->>>>
            finally
            {
                this.CloseFileStream();
            }
            // ---ADD 2011/02/25--------------------<<<<
            return status;
        }

        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 譚洪 Redmine18531対応</br>
        /// </remarks>
        public int WriteAutoText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                AUTOF2WUOETextEditOrder aUTOF2WUOETextEditOrder = new AUTOF2WUOETextEditOrder();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //送信電文(JIS)
                        aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //発注番号が変更された
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //電文明細クラス全てのクリア
                        aUTOF2WUOETextEditOrder.Clear();
                        //送信電文(JIS)
                        aUTOF2WUOETextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            aUTOF2WUOETextEditOrder.Clear();

                            //送信電文(JIS)
                            aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //送信電文(JIS)
                            aUTOF2WUOETextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = aUTOF2WUOETextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //電文明細クラス全てのクリア
                aUTOF2WUOETextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ADD 2011/01/13 --- >>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ADD 2011/01/13 --- <<<<<
            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// サブデータ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : サブデータ保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 譚洪 Redmine18531対応</br>
        /// </remarks>
        public int WriteSubText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                F2WUOESubTextEditOrder f2WUOESubTextEditOrder = new F2WUOESubTextEditOrder();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //送信電文(JIS)
                        f2WUOESubTextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //発注番号が変更された
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //電文明細クラス全てのクリア
                        f2WUOESubTextEditOrder.Clear();
                        //送信電文(JIS)
                        f2WUOESubTextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;

                            tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            f2WUOESubTextEditOrder.Clear();

                            //送信電文(JIS)
                            f2WUOESubTextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //送信電文(JIS)
                            f2WUOESubTextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = f2WUOESubTextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //電文明細クラス全てのクリア
                f2WUOESubTextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ADD 2011/01/13 --- >>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ADD 2011/01/13 --- <<<<<
            return status;
        }
        // --------ADD 2010/12/31---------<<<<<
        
        #region 選択データの取得処理
        /// <summary>
        /// 選択データの取得処理
        /// </summary>
        /// <param name="mode">0:全て 1:変更データ 2:選択データ</param>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ更新用リスト</param>
        /// <param name="stockDetailWorkList">仕入明細更新用リスト</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注データ削除用リスト</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除用リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択データの取得処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4030対応</br>
        /// <br>UpdateNote : 2011/03/15 曹文傑 Redmine #19908の対応</br>
        /// </remarks>
        public int GetUOEOrderDtlWorkFromRowData(int mode, int cashRegisterNo, int systemDiv, 
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, 
                                                                out string message)
        {
            // 戻値
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            message = "";
            try
            {
                // ----------UPD 2010/03/18---------->>>>>
                //DataView orderDataView = new DataView(this.orderDataTable);
                //orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // ----------UPD 2010/03/18----------<<<<<
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    // ----------UPD 2010/03/18---------->>>>>
                    //uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    //uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    //uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    //uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    //uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    //uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
                    // ----------UPD 2010/03/18----------<<<<<
                    key = MakeKey(uOEOrderDtlWork);

                    //データ取得処理
                    uOEresultList = this._uOEOrderDtlWorkList.FindAll(delegate(UOEOrderDtlWork target)
                    {
                        if (key.Equals(MakeKey(target)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (uOEresultList.Count != 0)
                    {
                        UOEOrderDtlWork uOEOrderDtlWorktemp = uOEresultList[0];
                        // ----------UPD 2010/03/18---------->>>>>
                        //if (mode == 1 && (systemDiv != 3 
                        //    || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        if (mode == 1 && (systemDiv != 3
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))

                        // ----------UPD 2010/03/18----------<<<<<
                        {
                            // 受信日付
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // 送信フラグ
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // 復旧フラグ
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // 送信端末番号
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;

                            // UOEリマーク1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            // 納品区分
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // 納品区分名称
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // 指定拠点
                            uOEOrderDtlWorktemp.UOEResvdSection = dataRow[this.OrderDataTable.UOEResvdSectionColumn.ColumnName].ToString();
                            // UOE指定拠点名称
                            uOEOrderDtlWorktemp.UOEResvdSectionNm = dataRow[this.OrderDataTable.UOEResvdSectionNmColumn.ColumnName].ToString();
                            // 従業員コード
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.OrderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            // 従業員名称
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.OrderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            // BO区分
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString().Trim();


                            // UOEリマーク２
                            // ---ADD 2011/03/15------------------>>>>>
                            //uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            if ("0206".Equals(uOEOrderDtlWorktemp.CommAssemblyId) && this._uOESupplier != null)
                            {
                                uOEOrderDtlWorktemp.UoeRemark2 = this._uOESupplier.MazdaSectionCode.Trim().PadRight(3,' ') + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            }
                            else
                            {
                            uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            }
                            // ---ADD 2011/03/15------------------<<<<<
                            // 受注数量
                            //uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());// DEL 2010/03/18
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());// ADD 2010/03/18
                            uOEOrderDtlWorkList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkList.Add(stockDetailWork);
                            }
                        }
                        else
                        {
                            uOEOrderDtlWorkDelList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkDelList.Add(stockDetailWork);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                status = -1;
            }

            return status;

        }

        // ---ADD 2011/02/25-------------->>>>>
        /// <summary>
        /// データ保存処理(プログラムIDが「0205」の場合)
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public int WriteText2(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                #region リマーク２とお届け先コードを再セットする。
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    DataView orderDataView = new DataView(this.OrderDataTable);
                    orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);

                    // 発注先マスタのプログラムを参照し、リマーク２へのセット内容変更を行う。
                    for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                    {
                        UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                        for (int j = 0; j < orderDataView.Count; j++)
                        {
                            NissanOrderProcDataSet.OrderExpansionRow dataRow = (NissanOrderProcDataSet.OrderExpansionRow)(orderDataView[j].Row);
                            if ((Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName] == work.OnlineNo)
                            {
                                // 0206の場合、画面のリマーク２をコメント2にセット。お届け先コードをセット。
                                if ("0206".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.UoeRemark2 = dataRow[this.OrderDataTable.UoeRemark2Column.ColumnName].ToString().Trim();
                                    work.ShippingCd = dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName].ToString().Trim().PadLeft(6, ' ');
                                }
                                // 0205の場合、お届け先コードをセット。
                                else if ("0205".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.ShippingCd = dataRow[this.OrderDataTable.ShippingCdColumn.ColumnName].ToString().Trim().PadLeft(6, ' ');
                                }
                                else
                                {
                                    // なし。
                                }
                                break;
                            }
                            else
                            {
                                // なし。
                            }
                        }
                    }
                }
                #endregion

                F2WUOETextEditOrder2 f2WUOETextEditOrder = new F2WUOETextEditOrder2();
                byte[] tempbyte = null;
                Int32 maxDataCount = 8;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 0;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    if (i == 0)
                    {
                        detailCount = 1;
                        dataCount = 1;
                        //送信電文(JIS)
                        f2WUOETextEditOrder.Telegram(work, dataCount);
                        onlineNo = work.OnlineNo;
                    }
                    //発注番号が変更された
                    else if (onlineNo != work.OnlineNo)
                    {
                        dataCount++;

                        tempbyte = f2WUOETextEditOrder.ToByteArray();

                        this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);
                        //電文明細クラス全てのクリア
                        f2WUOETextEditOrder.Clear();
                        //送信電文(JIS)
                        f2WUOETextEditOrder.Telegram(work, dataCount);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                    }
                    else
                    {
                        detailCount++;
                        if (detailCount > maxDataCount)
                        {
                            dataCount++;
                            tempbyte = f2WUOETextEditOrder.ToByteArray();

                            this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            f2WUOETextEditOrder.Clear();

                            //送信電文(JIS)
                            f2WUOETextEditOrder.Telegram(work, dataCount);
                            detailCount = 1;
                        }
                        else
                        {
                            //送信電文(JIS)
                            f2WUOETextEditOrder.Telegram(work, dataCount);
                        }
                    }

                }

                tempbyte = f2WUOETextEditOrder.ToByteArray();

                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //電文明細クラス全てのクリア
                f2WUOETextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                this.CloseFileStream();
            }
            return status;
        }

        /// <summary>
        /// ＵＯＥ発注データ発注セット数の算出用
        /// </summary>
        /// <param name="commAssemblyId">プログラムID</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注セット数の算出用</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public void SetCommAssemblyId(string commAssemblyId)
        {
            this._commAssemblyId = commAssemblyId;
        }

        /// <summary>
        /// 保存データチェック処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <param name="systemDivCd">システム区分</param>
        /// <param name="itemNameList">項目名称リスト</param>
        /// <param name="itemList">項目リスト</param>
        /// <returns>true:保存可 false:保存不可</returns>
        /// <remarks>
        /// <br>Note       : 保存データチェック処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/25</br>
        /// </remarks>
        public bool SaveDataCheck(int businessCode, int systemDivCd, out List<string> itemNameList, out List<string> itemList)
        {
            itemNameList = new List<string>();
            itemList = new List<string>();

            foreach (NissanOrderProcDataSet.OrderExpansionRow row in this.OrderDataTable)
            {
                if (row.InpSelect == true)
                {
                    // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                    if (systemDivCd == 3 && row.AcceptAnOrderCnt == 0)
                    {
                        continue;
                    }
                    //納品区分のチェック
                    // 発注の場合
                    if ((businessCode == ctTerminalDiv_Order)
                        && (string.IsNullOrEmpty(row.UOEDeliGoodsDivNm)))
                    {
                        itemNameList.Add("納品区分");
                        itemList.Add("OrderExpansion");
                    }

                    //指定拠点
                    if ((businessCode == ctTerminalDiv_Order)
                        && (string.IsNullOrEmpty(row.UOEResvdSectionNm)))
                    {
                        itemNameList.Add("指定拠点");
                        itemList.Add("OrderExpansion");
                    }

                    //依頼者
                    if ((businessCode == ctTerminalDiv_Order)
                    && (row.EmployeeCode.Trim() == ""))
                    {
                        itemNameList.Add("依頼者");
                        itemList.Add("OrderExpansion");
                    }
                }

                if (itemNameList.Count > 0) break;
            }
            if (itemNameList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // ---ADD 2011/02/25--------------<<<<<
        #endregion

        #region ＵＯＥ発注データ削除処理
        /// <summary>
        /// ＵＯＥ発注データ削除処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public int DeleteDB(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 削除対象のＵＯＥ発注データの取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;

                status = GetUOEOrderDtlWorkFromRowData(2, 0, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);

                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }

        # endregion

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="uOEOrderDtlWork">明細・行</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : Key作成処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private string MakeKey(UOEOrderDtlWork uOEOrderDtlWork)
        {
            // 明細・行Primary Key
            string key = uOEOrderDtlWork.OnlineNo.ToString() + uOEOrderDtlWork.OnlineRowNo.ToString() + uOEOrderDtlWork.UOEKind.ToString()
                + uOEOrderDtlWork.CommonSeqNo.ToString() + uOEOrderDtlWork.SupplierFormal.ToString() + uOEOrderDtlWork.StockSlipDtlNum.ToString();

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 明細・行Key作成処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // 明細・行Primary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key作成

        /// <summary>
        /// ファイルがオープン中チェック
        /// </summary>
        /// <param name="toyotaFlod">フォルダ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2010/03/18 呉元嘯 Redmine4005対応</br>
        /// <br>UpdateNote : 2010/03/29 呉元嘯 Redmine4311対応</br>
        /// </remarks>
        public bool GetCanWriteFlg(string toyotaFlod)
        {
            string mess = string.Empty;
            this.UoeFileStream = null;
            try
            {
                //this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);// DEL 2010/03/29
                this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);// ADD 2010/03/29
                return true;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                //this.CloseFileStream(this.UoeFileStream);// DEL 2010/03/18
                this.CloseFileStream();// ADD 2010/03/18
                return false;
            }
        }

        // ----------UPD 2010/03/18---------->>>>>
        ///// <summary>
        ///// ファイル（ストリーム）をクローズ
        ///// </summary>
        ///// <param name="fs">ファイル流</param>
        ///// <remarks>
        ///// <br>Note       :  ファイル（ストリーム）をクローズする。</br>
        ///// <br>Programmer : 呉元嘯</br>
        ///// <br>Date       : 2010/03/08</br>
        ///// </remarks>
        //public void CloseFileStream(FileStream fs)
        //{
        //    if (fs != null)
        //    {
        //        fs.Close();
        //    }
        //}
        /// <summary>
        /// ファイル（ストリーム）をクローズ
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ファイル（ストリーム）をクローズする。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/03/08</br>
        /// </remarks>
        public void CloseFileStream()
        {
            if (UoeFileStream != null)
            {
                UoeFileStream.Close();
            }
        }
        // ----------UPD 2010/03/18----------<<<<<

        // --------ADD 2010/12/31--------->>>>>
        #region 自動更新処理
        /// <summary>
        /// 自動更新処理
        /// </summary>
        /// <param name="dir">発注送信データファイル名称</param>
        /// <param name="subDir">発注送信データサブファイル名称</param>
        /// <param name="uoeSupplier">UOE発注先マスタ</param>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタ</param>
        /// <param name="errMess">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自動更新を行いします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            //string subDirStr = string.Empty;
            try
            {
                //if (!string.IsNullOrEmpty(subDir))
                //{
                //    // サブファイル暗号化プログラム呼び出し
                //    status = xEncryptsFile(subDir, 1);
                //}

                count = this.GetDeleteCount();

                //暗号化失敗或いはサブテキストファイル未作成場合
                //if ((status != 0) || (string.IsNullOrEmpty(subDir)))
                //{
                //    subDirStr = string.Empty;
                //}
                //else
                //{
                //    subDirStr = subDir;
                //}

                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "更新処理中";
                form.Message = "更新処理中です。";
                // ダイアログ表示
                form.Show();

                // 自動化プログラム呼び出し
                //UOE接続先情報マスタある場合
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(2, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDir, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(2, dir, 0, string.Empty, 0, subDir, count, ref errMess);
                }

                // ----------ADD 2010/08/31----------->>>>>
                // ダイアログを閉じる
                form.Close();
                // ----------ADD 2010/08/31-----------<<<<<

                switch ((Int16)status)
                {
                    case 0:
                        {
                            errMess = "正常終了。";
                            #region 回答テキストの取込処理
                            UOEOrderDtlNissanAcs uOEOrderDtlNissanAcs = new UOEOrderDtlNissanAcs();

                            AnswerDateNissanPara answerDateNissanPara = new AnswerDateNissanPara();
                            answerDateNissanPara.EnterpriseCode = this._enterpriseCode;
                            answerDateNissanPara.SectionCode = this._loginSectionCode;
                            answerDateNissanPara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            answerDateNissanPara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // 回答情報の取得を行います
                            status = uOEOrderDtlNissanAcs.DoSearch(answerDateNissanPara, out errMess);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // トランザクションデータの作成を行います
                                status = uOEOrderDtlNissanAcs.DoConfirm(answerDateNissanPara, out errMess);
                            }
                            #endregion
                            break;
                        }
                    case 1:
                        {
                            subMess = "電子カタログ起動済みエラー。";
                            break;
                        }
                    case -1:
                        {
                            subMess = "電子カタログエラー。";
                            break;
                        }
                    case -2:
                        {
                            subMess = "メーカー不正。";
                            break;
                        }
                    case -3:
                        {
                            subMess = "送信ファイル無し。";
                            break;
                        }
                    case -4:
                        {
                            subMess = "ソケットエラー。";
                            break;
                        }
                    case -5:
                        {
                            subMess = "パラメータエラー。";
                            break;
                        }
                    case -6:
                        {
                            subMess = "IPアドレス変換エラー。";
                            break;
                        }
                    case -7:
                        {
                            subMess = "回答ファイル無しエラー。";
                            break;
                        }
                    case -8:
                        {
                            subMess = "送受信ファイル削除エラー。";
                            break;
                        }
                    case -9:
                        {
                            subMess = "タイムアウト。";
                            break;
                        }
                    case -10:
                        {
                            subMess = "サービスタイムアウト。";
                            break;
                        }
                    case -11:
                        {
                            subMess = "受信ファイルタイムアウト。";
                            break;
                        }
                    case -12:
                        {
                            subMess = "クライアントタイムアウト。";
                            break;
                        }
                    case -999:
                        {
                            subMess = "その他エラー。";
                            break;
                        }
                    case 999:
                        {
                            subMess = "接続先未設定。";
                            break;
                        }
                }

                // PMPU9011.DLLの戻り値＝「0以外」の場合は
                if (!string.IsNullOrEmpty(subMess))
                {
                    //「ref msg」が入っている場合
                    if (!string.IsNullOrEmpty(errMess))
                    {
                        //上記エラーメッセージと改行後に「ref msg」の値も追加して、メッセージボックスの表示を行う
                        errMess = subMess + "\r\n" + errMess;
                    }
                    else
                    {
                        errMess = subMess;
                    }
                }
            }
            catch (Exception ex)
            {
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (Int16)status;

        }

        /// <summary>
        /// 自動化プログラム
        /// </summary>
        [DllImport("PMPU9011.dll")]
        public extern static int xPMPU9011(int imk, string dir, int port, string pcname, int itimeout, string sdir, int imei, ref string msg);
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // --------ADD 2011/03/15--------->>>>>
        /// <summary>
        /// UOE発注先マスタ設定処理（プログラム：0206のみ用）
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先マスタ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ設定処理する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/03/15</br>
        /// </remarks>
        public void SetUOESupplier(UOESupplier uOESupplier)
        {
            this._uOESupplier = uOESupplier;
        }
        // --------ADD 2011/03/15---------<<<<<
    }
}
