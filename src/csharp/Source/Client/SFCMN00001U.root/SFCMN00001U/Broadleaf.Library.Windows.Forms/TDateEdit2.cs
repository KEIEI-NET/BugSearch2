//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   画面ＵＩ部品(TDateEdit2)                         //
// Name Space       :   Broadleaf.Library.Windows.Forms					//
// Programer        :                                                   //
// Date             :                                                   //
//----------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号  11470076-00    作成担当：陳艶丹
// 修正日    2019/01/25     修正内容：新元号の追加対応
// ---------------------------------------------------------------------//
using Infragistics.Win;
using System;
using System.ComponentModel;
using System.Drawing;
using Broadleaf.Library.Globarization;// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
using System.Collections;// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
using System.Windows.Forms;// ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 画面ＵＩ部品(TDateEdit2)  
    /// </summary>
    /// <remarks>
    /// <br>Update Note: 2019/01/25 陳艶丹</br>	
    /// <br>管理番号   ：11470076-00</br>	 
    /// <br>             新元号の追加対応</br>
    /// </remarks>
    [ToolboxBitmap(typeof(TDateEdit2), "TDateEdit2.bmp")]
	public class TDateEdit2 : TDateEdit
	{
		public const string ctEraName_Heisei = "平成";
		public const string ctEraName_Showa = "昭和";
		public const string ctEraName_Taisho = "大正";
		public const string ctEraName_Meiji = "明治";
		private Container components;
		public TDateEdit2()
		{
			this.InitializeComponent();
            // ----- DEL BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
            //ValueListItem valueListItem = new ValueListItem();
            //ValueListItem valueListItem2 = new ValueListItem();
            //ValueListItem valueListItem3 = new ValueListItem();
            //valueListItem.DataValue = "ValueListItem1";
            //valueListItem.DisplayText = "昭和";
            //valueListItem2.DataValue = "ValueListItem2";
            //valueListItem2.DisplayText = "大正";
            //valueListItem3.DataValue = "ValueListItem3";
            //valueListItem3.DisplayText = "明治";
            //this.JpGenCombo2.Items.Add(valueListItem);
            //this.JpGenCombo2.Items.Add(valueListItem2);
            //this.JpGenCombo2.Items.Add(valueListItem3);
            // ----- DEL BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
            SetGengouMode(TDateTimeGengouMode.Default); // ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.components = new Container();
		}
		public void DeleteJpComboItem(string eraName)
		{
			for (int i = this.JpGenCombo2.Items.Count - 1; i >= 0; i--)
			{
				if (eraName.Equals(this.JpGenCombo2.Items[i].DisplayText))
				{
					this.JpGenCombo2.Items.RemoveAt(i);
					return;
				}
			}
		}

        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 ----->>>>>
        /// <summary>
        /// 元号モード変更処理。
        /// 本コンポーネント内の元号コンボボックスの内容を、指定されたモードによって変更します。
        /// </summary>
        /// <param name="mode">元号モード</param>
        /// <remarks>
        /// <br>Note       : 元号モード変更処理</br>
        /// <br>Programer  : 陳艶丹</br>
        /// <br>Date       : 2019/01/25</br>
        /// </remarks>
        public override void SetGengouMode(TDateTimeGengouMode mode)
        {
            // 元号リストをクリアする
            JpGenCombo2.Items.Clear();

            // 共通部品で元号リストを取得
            ArrayList eraList = null;
            TDateTime.GetGengouList(out eraList, mode);

            int index = 0;
            foreach (string eraName in eraList)
            {
                Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();
                valueListItem.DataValue = "ValueListItem" + index;
                valueListItem.DisplayText = eraName;
                JpGenCombo2.Items.Add(valueListItem);
                index++;
            }
        }
        // ----- ADD BY 陳艶丹 2019/01/25 FOR 新元号の追加対応 -----<<<<<
	}
}
