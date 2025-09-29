using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePrtCmnExtPrmWork
    /// <summary>
    ///                      自由帳票共通抽出パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票共通抽出パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/7/23</br>
    /// <br>Genarated Date   :   2007/07/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
//    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePrtCmnExtPrmWork
    {
        /// <summary>
        /// 自由帳票共通抽出パラメータワークコンストラクタ
        /// </summary>
        /// <returns>FrePrtCmnExtPrmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePrtCmnExtPrmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePrtCmnExtPrmWork()
        {
        }

        /// <summary>
        /// コンストラクタオーバーロード(+1)
        /// </summary>
        /// <param name="selectItems">select項目</param>
        /// <param name="cipherItemsLs">暗号化項目IDリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCodeList">拠点コード</param>
        /// <param name="sectionNameList">拠点名称</param>
        /// <param name="sectionOptionDiv">拠点オプション有無</param>
        /// <param name="frePprECndWorkLs">抽出条件</param>
        public FrePrtCmnExtPrmWork(string selectItems, List<string> cipherItemsLs, string enterpriseCode, List<string>sectionCodeList,
            List<string> sectionNameList, bool sectionOptionDiv, List<FrePprECndWork> frePprECndWorkLs)
		{
            _selectItems = selectItems;
            _cipherItemsLs = cipherItemsLs;
            _enterpriseCode = enterpriseCode;
            _sectionCodeList = sectionCodeList;

            _sectionNameList = sectionNameList;
            _sectionOptionDiv = sectionOptionDiv;
            _frePprECndWorkLs = frePprECndWorkLs;
        }
        
        /// <summary>Select項目</summary>
        private string _selectItems = "";

        /// <summary>暗号化項目IDリスト</summary>
        private List<string> _cipherItemsLs;

        /// <summary>企業コード</summary>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private List<string> _sectionCodeList;

        /// <summary>拠点名称</summary>
        private List<string> _sectionNameList;

        /// <summary>拠点オプション有無</summary>
        private bool _sectionOptionDiv;

        /// <summary>抽出条件</summary>
        private List<FrePprECndWork> _frePprECndWorkLs;
     
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
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

        /// public propaty name  :  SelectItems
        /// <summary>Select項目プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Select項目プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectItems
        {
            get { return _selectItems; }
            set { _selectItems = value; }
        }

        /// public propaty name  :  CipherItemsLs
        /// <summary>暗号化項目IDリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   暗号化項目IDリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> CipherItemsLs
        {
            get { return _cipherItemsLs; }
            set { _cipherItemsLs = value; }
        }

        /// public propaty name  :  CipherItemsLs
        /// <summary>抽出条件リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出条件リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<FrePprECndWork> FrePprECndLs
        {
            get { return _frePprECndWorkLs; }
            set { _frePprECndWorkLs = value; }
        }

        /// <summary>拠点コード</summary>
        public List<string> SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// <summary>拠点名称</summary>
        public List<string> SectionNameList
        {
            get { return _sectionNameList; }
            set { _sectionNameList = value; }
        }
        
        /// <summary>拠点オプション有無</summary>
        public bool SectionOptionDiv
        {
            get { return _sectionOptionDiv; }
            set { _sectionOptionDiv = value; }
        }

        #region public methods
        /// <summary>
        /// 抽出条件のログを作成します
        /// </summary>
        /// <returns>正常：0　異常：-1</returns>
        public string GenerateExtCndPrmLog()
        {
            StringBuilder paraStr = new StringBuilder("Search Para: ");
            //企業コードは必須
            paraStr.Append("enterpriseCode:").Append(this._enterpriseCode);
            //拠点オプション有りの時
            if (SectionOptionDiv)
            {
                paraStr.Append(",SectionCode:");
                foreach (string secNm in this._sectionCodeList)
                {
                    paraStr.Append(secNm + "/");
                }
            }
            if (_frePprECndWorkLs != null)
            {
                foreach (FrePprECndWork eCnd in _frePprECndWorkLs)
                {
                    paraStr.Append("," + eCnd.ExtraConditionTitle + ":");
                    switch (eCnd.ExtraConditionDivCd)
                    {
                        case 1:
                            {   //数値型
                                paraStr.Append(eCnd.StExtraNumCode.ToString() + "～" + eCnd.EdExtraNumCode.ToString());
                                break;
                            }
                        case 2:
                        case 3:
                            {   //文字型
                                paraStr.Append(eCnd.StExtraCharCode + "～" + eCnd.EdExtraCharCode);
                                break;
                            }
                        case 4:
                            {   //日付型
                                paraStr.Append(eCnd.StartExtraDate.ToString() + "～" + eCnd.EndExtraDate.ToString());
                                break;
                            }
                        case 5:
                            {   //コンボボックス
                                paraStr.Append(eCnd.StExtraNumCode);
                                break;
                            }
                        case 6:
                            {   //チェックボックス
                                if (eCnd.CheckItemCode1 != -1) paraStr.Append(eCnd.CheckItemCode1.ToString() + "/");
                                if (eCnd.CheckItemCode2 != -1) paraStr.Append(eCnd.CheckItemCode2.ToString() + "/");
                                if (eCnd.CheckItemCode3 != -1) paraStr.Append(eCnd.CheckItemCode3.ToString() + "/");
                                if (eCnd.CheckItemCode4 != -1) paraStr.Append(eCnd.CheckItemCode4.ToString() + "/");
                                if (eCnd.CheckItemCode5 != -1) paraStr.Append(eCnd.CheckItemCode5.ToString() + "/");
                                if (eCnd.CheckItemCode6 != -1) paraStr.Append(eCnd.CheckItemCode6.ToString() + "/");
                                if (eCnd.CheckItemCode7 != -1) paraStr.Append(eCnd.CheckItemCode7.ToString() + "/");
                                if (eCnd.CheckItemCode8 != -1) paraStr.Append(eCnd.CheckItemCode8.ToString() + "/");
                                if (eCnd.CheckItemCode9 != -1) paraStr.Append(eCnd.CheckItemCode9.ToString() + "/");
                                if (eCnd.CheckItemCode10 != -1) paraStr.Append(eCnd.CheckItemCode10.ToString());
                                break;
                            }
                    }
                }
            }
            return paraStr.ToString();
        }
        #endregion
    }
}