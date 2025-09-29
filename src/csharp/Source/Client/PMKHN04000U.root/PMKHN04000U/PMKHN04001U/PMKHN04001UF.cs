using System;
using System.Text;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 抽出条件入力情報クラス
    /// </summary>
	public class CustomerSearchExtractionConditionInfo : CustomerSearchPara
	{
		/// <summary>
		/// 抽出条件入力情報クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   抽出条件入力情報クラスのコンストラクタです</br>
		/// <br>Programer        :   22018　鈴木正臣</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
        /// <br>             MANTIS:14720 得意先名検索追加</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public CustomerSearchExtractionConditionInfo() : base()
		{
			this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.AcceptWholeSale = -1;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        }

		/// <summary>
		/// インスタンス化処理
		/// </summary>
		/// <param name="source">元クラス</param>
		/// <returns>インスタンス化後の得意先車両検索条件クラス</returns>
        /// <remarks>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public static CustomerSearchExtractionConditionInfo Create(CustomerSearchExtractionConditionInfo source)
		{
			CustomerSearchExtractionConditionInfo customerSearchExtractionConditionInfo = new CustomerSearchExtractionConditionInfo();
			customerSearchExtractionConditionInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 検索タイプは元情報を保持する
			customerSearchExtractionConditionInfo.CustomerSubCodeSearchType = source.CustomerSubCodeSearchType;
			customerSearchExtractionConditionInfo.KanaSearchType = source.KanaSearchType;

            // 2009/12/02 Add >>>
            customerSearchExtractionConditionInfo.NameSearchType = source.NameSearchType;
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            customerSearchExtractionConditionInfo.CustomerSnmSearchType = source.CustomerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<

            // ---ADD 2010/08/06-------------------->>>
            customerSearchExtractionConditionInfo.TelNumSearchType = source.TelNumSearchType;
            // ---ADD 2010/08/06--------------------<<<

			return customerSearchExtractionConditionInfo;
		}

		/// <summary>
		/// 抽出条件入力情報クラス複製処理
		/// </summary>
		/// <returns>CusCarSearchExtractionConditionInfoクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいCusCarSearchExtractionConditionInfoクラスのインスタンスを返します</br>
		/// <br>Programer        :   22018　鈴木正臣</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public new CustomerSearchExtractionConditionInfo Clone()
		{
			CustomerSearchExtractionConditionInfo ret = new CustomerSearchExtractionConditionInfo();
			CustomerSearchPara customerSearchPara = base.Clone();

			ret.EnterpriseCode = customerSearchPara.EnterpriseCode;
			ret.CustomerCode = customerSearchPara.CustomerCode;
			ret.CustomerSubCode = customerSearchPara.CustomerSubCode;
			ret.Kana = customerSearchPara.Kana;
			ret.SearchTelNo = customerSearchPara.SearchTelNo;
			ret.LogicalDeleteDataPickUp = customerSearchPara.LogicalDeleteDataPickUp;
			ret.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
			ret.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
			ret.KanaSearchType = customerSearchPara.KanaSearchType;

			ret.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
			ret.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
			ret.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
			ret.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
			ret.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
			ret.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
			ret.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
			ret.CustomerAgentNm = customerSearchPara.CustomerAgentNm;
			ret.BillCollecterCd = customerSearchPara.BillCollecterCd;
			ret.BillCollecterNm = customerSearchPara.BillCollecterNm;
			ret.LogicalDeleteDataPickUp = customerSearchPara.LogicalDeleteDataPickUp;
			ret.EnterpriseName = customerSearchPara.EnterpriseName;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ret.MngSectionCode = customerSearchPara.MngSectionCode;
            ret.MngSectionName = customerSearchPara.MngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            ret.Name = customerSearchPara.Name;
            ret.NameSearchType = customerSearchPara.NameSearchType;
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            ret.TelNum = customerSearchPara.TelNum;
            ret.TelNumSearchType = customerSearchPara.TelNumSearchType;
            // ---ADD 2010/08/06--------------------<<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            ret.CustomerSnm = customerSearchPara.CustomerSnm;
            ret.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<

			return ret;
		}

		/// <summary>
		/// 抽出条件入力情報クラスクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCusCarSearchExtractionConditionInfoクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CusCarSearchExtractionConditionInfoクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   22018　鈴木正臣</br>
		/// </remarks>
		public bool Equals(CustomerSearchExtractionConditionInfo target)
		{
			return base.Equals(target);
		}
	
		/// <summary>
		/// 抽出条件入力情報クラスクラス比較処理
		/// </summary>
		/// <param name="customerSearchExtractionConditionInfo1">
		///                    比較するCusCarSearchExtractionConditionInfoクラスのインスタンス
		/// </param>
		/// <param name="customerSearchExtractionConditionInfo2">比較するCusCarSearchExtractionConditionInfoクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CusCarSearchExtractionConditionInfoクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   22018　鈴木正臣</br>
		/// </remarks>
		public static bool Equals(CustomerSearchExtractionConditionInfo customerSearchExtractionConditionInfo1, CustomerSearchExtractionConditionInfo customerSearchExtractionConditionInfo2)
		{
			return CustomerSearchPara.Equals(customerSearchExtractionConditionInfo1, customerSearchExtractionConditionInfo2);
		}

		/// <summary>
		/// 抽出条件入力情報クラスクラス比較処理
		/// </summary>
		/// <param name="target">比較対象のCusCarSearchExtractionConditionInfoクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CusCarSearchExtractionConditionInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   22018　鈴木正臣</br>
		/// </remarks>
		public ArrayList Compare(CustomerSearchExtractionConditionInfo target)
		{
			return base.Compare(target);
		}

		/// <summary>
		/// 抽出条件入力情報クラスクラス比較処理
		/// </summary>
		/// <param name="customerSearchExtractionConditionInfo1">比較するCusCarSearchExtractionConditionInfoクラスのインスタンス</param>
		/// <param name="customerSearchExtractionConditionInfo2">比較するCusCarSearchExtractionConditionInfoクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CusCarSearchExtractionConditionInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(CustomerSearchExtractionConditionInfo customerSearchExtractionConditionInfo1, CustomerSearchExtractionConditionInfo customerSearchExtractionConditionInfo2)
		{
			return CustomerSearchPara.Compare(customerSearchExtractionConditionInfo1, customerSearchExtractionConditionInfo2);
		}

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// </remarks>
		public override string ToString()
		{
			StringBuilder message = new StringBuilder();

			// 得意先コード
			if (this.CustomerCode != 0)
			{
				message.Append("\r\n" + "得意先コード : " + this.CustomerCode.ToString());
			}

			// 得意先サブコード
			if (this.CustomerSubCode.Trim() != "")
			{
				message.Append("\r\n" + "得意先サブコード : " + this.CustomerSubCode.ToString());
			}

			// カナ
			if (this.Kana.Trim() != "")
			{
				message.Append("\r\n" + "得意先名(ｶﾅ) : " + this.Kana.ToString());
			}

            // 2009/12/02 Add >>>
            // 得意先名
            if (this.Name.Trim() != "")
            {
                message.Append("\r\n" + "得意先名 : " + this.Name.ToString());
            }
            // 2009/12/02 Add <<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            // 得意先略称
            if (this.CustomerSnm.Trim() != "")
            {
                message.Append("\r\n" + "得意先略称 : " + this.CustomerSnm.ToString());
            }
            // 2011/7/22 XUJS ADD END<<<<<<

			// 電話番号（下４桁）
			if (this.SearchTelNo.Trim() != "")
			{
				message.Append("\r\n" + "電話番号（検索番号） : " + this.SearchTelNo.ToString());
			}
			
			// 得意先種別
			StringBuilder customerKindName = new StringBuilder();
			if (this.AcceptWholeSale != 0)
			{
				if (customerKindName.ToString() != "") customerKindName.Append("／");
				customerKindName.Append("業販先");
			}

			if (customerKindName.ToString() != "")
			{
				message.Append("\r\n" + "得意先種別 : " + customerKindName.ToString());
			}

			if ((this.CustAnalysCode1 != 0) || (this.CustAnalysCode2 != 0) || (this.CustAnalysCode3 != 0) || (this.CustAnalysCode4 != 0) || (this.CustAnalysCode5 != 0) || (this.CustAnalysCode6 != 0))
			{
				message.Append("\r\n" + "分析コード : " + this.CustAnalysCode1.ToString() + "-" + this.CustAnalysCode2.ToString() + "-" + this.CustAnalysCode3.ToString() + "-" + this.CustAnalysCode4.ToString() + "-" + this.CustAnalysCode5.ToString() + "-" + this.CustAnalysCode6.ToString());
			}

			if (this.CustomerAgentCd != "")
			{
				message.Append("\r\n" + "得意先担当者 : " + this.CustomerAgentNm.ToString());
			}

            // ---ADD 2010/08/06-------------------->>>
            // 電話番号
            if (this.TelNum.Trim() != "")
            {
                message.Append("\r\n" + "電話番号 : " + this.TelNum.ToString());
            }
            // ---ADD 2010/08/06--------------------<<<

			return message.ToString();
		}

	}
}
