using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    
    /// <summary>
    /// TSP問合せクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   TspRequest</br>
    /// <br>Programmer       :   32470 小原</br>
    /// <br>Date             :   2020/12/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class TspRequest
    {

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        public TspRequest()
        { 
        
        
        
        }

        /// <summary>
        /// コンストラクタ 
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="pmEnterpriseCode">PM企業コード</param>
        /// <param name="tspCommNo">TSP通信番号</param>
        /// <param name="tspCommCount">TSP通信回数</param>
        /// <param name="commConditionDivCd">通信状態区分</param>
        public TspRequest(string enterpriseCode, string pmEnterpriseCode, Int32 tspCommNo, Int32 tspCommCount, Int32 commConditionDivCd)
        {

            _enterpriseCode = enterpriseCode;
            _pmEnterpriseCode = pmEnterpriseCode;
            _tspCommNo = tspCommNo;
            _tspCommCount = tspCommCount;
            _commConditionDivCd = commConditionDivCd;

        }


        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>PM企業コード</summary>
        /// <remarks>部品商の企業コード</remarks>
        private string _pmEnterpriseCode = "";

        /// <summary>TSP通信番号</summary>
        /// <remarks>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</remarks>
        private Int32 _tspCommNo;

        /// <summary>TSP通信回数</summary>
        /// <remarks>PM側が１発注に対して回答を行う回数</remarks>
        private Int32 _tspCommCount;

        /// <summary>通信状態区分</summary>
        /// <remarks>0:未処理,1:送信済み,2:処理済,9:エラー</remarks>
        private Int32 _commConditionDivCd;

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }


        /// public propaty name  :  PmEnterpriseCode
        /// <summary>PM企業コードプロパティ</summary>
        /// <value>部品商の企業コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmEnterpriseCode
        {
            get { return _pmEnterpriseCode; }
            set { _pmEnterpriseCode = value; }
        }

        /// public propaty name  :  TspCommNo
        /// <summary>TSP通信番号プロパティ</summary>
        /// <value>１送信毎に振られる番号(PM側にて採番 or 発注時はSF側の番号採番)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommNo
        {
            get { return _tspCommNo; }
            set { _tspCommNo = value; }
        }

        /// public propaty name  :  TspCommCount
        /// <summary>TSP通信回数プロパティ</summary>
        /// <value>PM側が１発注に対して回答を行う回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP通信回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TspCommCount
        {
            get { return _tspCommCount; }
            set { _tspCommCount = value; }
        }

        /// public propaty name  :  CommConditionDivCd
        /// <summary>通信状態区分プロパティ</summary>
        /// <value>0:未処理,1:送信済み,2:処理済,9:エラー</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信状態区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CommConditionDivCd
        {
            get { return _commConditionDivCd; }
            set { _commConditionDivCd = value; }
        }


    }


}
