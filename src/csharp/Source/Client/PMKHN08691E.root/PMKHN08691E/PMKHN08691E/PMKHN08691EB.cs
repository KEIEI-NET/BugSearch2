using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecPrintSet
    /// <summary>
    ///                      拠点情報マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   拠点情報マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class SecPrintSet 
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>自社名称コード1</summary>
        /// <remarks>整備システムで使用する自社名称コード</remarks>
        private Int32 _companyNameCd1;

        /// <summary>自社名称1</summary>
        private string _companyName1 = "";

        /// <summary>自社名称2</summary>
        /// <remarks>YYYYMMDD</remarks>
        private string _companyName2 = "";

        /// <summary>拠点ガイド略称</summary>
        private string _sectionGuideSnm = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>郵便番号</summary>
        private string _postNo = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _address1 = "";

        /// <summary>住所3（番地）</summary>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _address4 = "";

        /// <summary>自社電話番号1</summary>
        private string _companyTelNo1 = "";

        /// <summary>自社電話番号2</summary>
        private string _companyTelNo2 = "";

        /// <summary>自社電話番号3</summary>
        private string _companyTelNo3 = "";

        /// <summary>自社電話番号タイトル1</summary>
        private string _companyTelTitle1 = "";

        /// <summary>自社電話番号タイトル2</summary>
        private string _companyTelTitle2 = "";

        /// <summary>自社電話番号タイトル3</summary>
        private string _companyTelTitle3 = "";

        /// <summary>拠点倉庫コード１</summary>
        private string _sectWarehouseCd1 = "";

        /// <summary>拠点倉庫コード２</summary>
        private string _sectWarehouseCd2 = "";

        /// <summary>拠点倉庫コード３</summary>
        private string _sectWarehouseCd3 = "";

        /// <summary>倉庫名称1</summary>
        private string _warehouseName1 = "";

        /// <summary>倉庫名称2</summary>
        private string _warehouseName2 = "";

        /// <summary>倉庫名称3</summary>
        private string _warehouseName3 = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>自社設定摘要1</summary>
        private string _companySetNote1 = "";

        /// <summary>自社設定摘要2</summary>
        private string _companySetNote2 = "";


        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CompanyNameCd1
        /// <summary>自社名称コード1プロパティ</summary>
        /// <value>整備システムで使用する自社名称コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompanyNameCd1
        {
            get { return _companyNameCd1; }
            set { _companyNameCd1 = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>自社名称1プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>自社名称2プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>自社電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>自社電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>自社電話番号3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  SectWarehouseCd1
        /// <summary>拠点倉庫コード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propaty name  :  SectWarehouseCd2
        /// <summary>拠点倉庫コード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propaty name  :  SectWarehouseCd3
        /// <summary>拠点倉庫コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }

        /// public propaty name  :  WarehouseName1
        /// <summary>倉庫名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName1
        {
            get { return _warehouseName1; }
            set { _warehouseName1 = value; }
        }

        /// public propaty name  :  WarehouseName2
        /// <summary>倉庫名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName2
        {
            get { return _warehouseName2; }
            set { _warehouseName2 = value; }
        }

        /// public propaty name  :  WarehouseName3
        /// <summary>倉庫名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName3
        {
            get { return _warehouseName3; }
            set { _warehouseName3 = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  CompanySetNote1
        /// <summary>自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanySetNote1
        {
            get { return _companySetNote1; }
            set { _companySetNote1 = value; }
        }

        /// public propaty name  :  CompanySetNote2
        /// <summary>自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanySetNote2
        {
            get { return _companySetNote2; }
            set { _companySetNote2 = value; }
        }


        /// <summary>
        /// 自社名称コード取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>自社名称コード</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称コードを取得します</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public int GetCompanyNameCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyNameCd1;
                    }
                default:
                    {
                        return 0;
                    }
            }
        }
        /// <summary>
        /// 拠点倉庫コード取得処理
        /// </summary>
        /// <param name="index">インデックス</param>
        /// <returns>拠点倉庫コード</returns>
        /// <remarks>
        /// <br>Note       : インデックスで指定した拠点倉庫コードを取得します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseCd1;
                    }
                case 1:
                    {
                        return this._sectWarehouseCd2;
                    }
                case 2:
                    {
                        return this._sectWarehouseCd3;
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// 拠点倉庫名称設定処理
        /// </summary>
        /// <param name="sectWarehouseNm">拠点倉庫名称</param>
        /// <param name="index">インデックス</param>
        /// <remarks>
        /// <br>Note       : インデックスで指定した自社名称を設定します</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseNm(string sectWarehouseNm, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._warehouseName1 = sectWarehouseNm;
                        break;
                    }
                case 1:
                    {
                        this._warehouseName2 = sectWarehouseNm;
                        break;
                    }
                case 2:
                    {
                        this._warehouseName3 = sectWarehouseNm;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// 拠点情報（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecPrintSet Clone()
        {
            return new SecPrintSet(this._sectionCode,this._companyNameCd1,this._companyName1,this._companyName2,this._sectionGuideSnm,this._sectionGuideNm,this._postNo,this._address1,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._sectWarehouseCd1,this._sectWarehouseCd2,this._sectWarehouseCd3,this._warehouseName1,this._warehouseName2,this._warehouseName3,this._warehouseName,this._companySetNote1,this._companySetNote2);
            
        }

        /// <summary>
        /// 拠点情報（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SecInfoSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SecPrintSet()
        {
        }

        /// <summary>
        /// 拠点情報（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="SectionCode"></param>
        /// <param name="CompanyNameCd1"></param>
        /// <param name="CompanyName1"></param>
        /// <param name="CompanyName2"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="PostNo"></param>
        /// <param name="Address1"></param>
        /// <param name="Address3"></param>
        /// <param name="Address4"></param>
        /// <param name="CompanyTelNo1"></param>
        /// <param name="CompanyTelNo2"></param>
        /// <param name="CompanyTelNo3"></param>
        /// <param name="CompanyTelTitle1"></param>
        /// <param name="CompanyTelTitle2"></param>
        /// <param name="CompanyTelTitle3"></param>
        /// <param name="SectWarehouseCd1"></param>
        /// <param name="SectWarehouseCd2"></param>
        /// <param name="SectWarehouseCd3"></param>
        /// <param name="WarehouseName1"></param>
        /// <param name="WarehouseName2"></param>
        /// <param name="WarehouseName3"></param>
        /// <param name="WarehouseName"></param>
        /// <param name="CompanySetNote1"></param>
        /// <param name="CompanySetNote2"></param>
        public SecPrintSet(string SectionCode, Int32 CompanyNameCd1, string CompanyName1, string CompanyName2, string SectionGuideSnm, string SectionGuideNm, string PostNo, string Address1, string Address3, string Address4, string CompanyTelNo1, string CompanyTelNo2, string CompanyTelNo3, string CompanyTelTitle1, string CompanyTelTitle2, string CompanyTelTitle3, string SectWarehouseCd1, string SectWarehouseCd2, string SectWarehouseCd3, string WarehouseName1, string WarehouseName2, string WarehouseName3, string WarehouseName, string CompanySetNote1, string CompanySetNote2)
        {
            this._sectionCode = SectionCode;
            this._companyNameCd1 = CompanyNameCd1;
            this._companyName1 = CompanyName1;
            this._companyName2 = CompanyName2;
            this._sectionGuideSnm = SectionGuideSnm;
            this._sectionGuideNm = SectionGuideNm;
            this._postNo = PostNo;
            this._address1 = Address1;
            this._address3 = Address3;
            this._address4 = Address4;
            this._companyTelNo1 = CompanyTelNo1;
            this._companyTelNo2 = CompanyTelNo2;
            this._companyTelNo3 = CompanyTelNo3;
            this._companyTelTitle1 = CompanyTelTitle1;
            this._companyTelTitle2 = CompanyTelTitle2;
            this._companyTelTitle3 = CompanyTelTitle3;
            this._sectWarehouseCd1 = SectWarehouseCd1;
            this._sectWarehouseCd2 = SectWarehouseCd2;
            this._sectWarehouseCd3 = SectWarehouseCd3;
            this._warehouseName1 = WarehouseName1;
            this._warehouseName2 = WarehouseName2;
            this._warehouseName3 = WarehouseName3;
            this._warehouseName = WarehouseName;
            this._companySetNote1 = CompanySetNote1;
            this._companySetNote2 = CompanySetNote2;

        }
    }
}
