using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    //public delegate string GetSalesMonDetailsTargetSelectSectionCodeEventHandler(object sender);
    public delegate void ParentToolbarSalesMonDetailsTargetSettingEventHandler(object sender);

    /// public class name:	 ISalesMonDetailsTargetMDIChild
    /// <summary>
    /// 					 売上目標設定(要素別)インターフェースクラス
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 売上目標設定(要素別)インターフェースファイル</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007/05/08</br>
    /// <br>Update Note 	 :	 </br>
    /// <br></br>
    /// </remarks>
    public interface ISalesMonDetailsTargetMDIChild
    {
        string Title
        {
            get;
        }
        bool UndoButton
        {
            get;
        }

        //event GetSalesMonDetailsTargetSelectSectionCodeEventHandler GetSelectSectionCodeEvent;
        event ParentToolbarSalesMonDetailsTargetSettingEventHandler ParentToolbarSettingEvent;

        void AfterSectionChange();
        int BeforeClose(object parameter);
        int BeforeSectionChange();
        int BeforeTabChange(object parameter);
        int InitializeForm();
        void Show(object parameter);

        void UndoSalesMonTargetProc();

    }
}
