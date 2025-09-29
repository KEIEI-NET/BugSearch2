//**********************************************************************
// システム         :   PM.NS
// プログラム名称   :   仕入総括マスタ一覧表印刷 印刷条件クラス
// プログラム概要   : 　
//----------------------------------------------------------------------
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号             作成担当 : FSI菅原　要
// 作 成 日  2012/09/07 修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    # region [仕入先総括マスタ一覧表印刷　印刷条件クラス]
    /// <summary>
    /// 仕入先総括マスタ一覧表印刷　印刷条件クラス
    /// </summary>
    public class SumSuppStPrintUIParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>総括拠点コード_開始</summary>
        private string _sumSectionCodeSt;
        /// <summary>総括拠点コード_終了</summary>
        private string _sumSectionCodeEd;
        /// <summary>総括仕入先コード_開始</summary>
        private Int32 _sumSupplierCdSt;
        /// <summary>総括仕入先コード_終了</summary>
        private Int32 _sumSupplierCdEd;
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 総括拠点コード_開始
        /// </summary>
        public string SumSectionCodeSt
        {
            get { return _sumSectionCodeSt; }
            set { _sumSectionCodeSt = value; }
        }
        /// <summary>
        /// 総括拠点コード_終了
        /// </summary>
        public string SumSectionCodeEd
        {
            get { return _sumSectionCodeEd; }
            set { _sumSectionCodeEd = value; }
        }
        /// <summary>
        /// 総括仕入先コード_開始
        /// </summary>
        public Int32 SumSupplierCdSt
        {
            get { return _sumSupplierCdSt; }
            set { _sumSupplierCdSt = value; }
        }
        /// <summary>
        /// 総括仕入先コード_終了
        /// </summary>
        public Int32 SumSupplierCdEd
        {
            get { return _sumSupplierCdEd; }
            set { _sumSupplierCdEd = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sumSectionCodeSt">総括拠点コード_開始</param>
        /// <param name="sumSectionCodeEd">総括拠点コード_終了</param>
        /// <param name="sumSupplierCdSt">総括仕入先コード_開始</param>
        /// <param name="sumSupplierCdEd">総括仕入先コード_終了</param>
        public SumSuppStPrintUIParaWork(string enterpriseCode, string sumSectionCodeSt, string sumSectionCodeEd, Int32 sumSupplierCdSt, Int32 sumSupplierCdEd)
        {
            _enterpriseCode = enterpriseCode;
            _sumSectionCodeSt = sumSectionCodeSt;
            _sumSectionCodeEd = sumSectionCodeEd;
            _sumSupplierCdSt = sumSupplierCdSt;
            _sumSupplierCdEd = sumSupplierCdEd;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SumSuppStPrintUIParaWork()
        {
        }

    }
    # endregion
}
