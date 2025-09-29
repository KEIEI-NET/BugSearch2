using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Library.Windows.Forms.TDateEdit3
{
    /// <summary>
    /// TDateEdit3
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���t�̃R���|�[�l���g�N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.12.18</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2009.01.21 20056 ���n ���</br>
    /// <br>           : �E�ȉ��̑Ή����s��</br>
    /// <br>           : �@�t���[���ŕ\������ꍇ�ACreate�ň�u���X�g����ʕ\�������B</br>
    /// </remarks>
    [ToolboxBitmap(typeof(TDateEdit3), "TDateEdit3.TDateEdit3.bmp")]
    public partial class TDateEdit3 : TDateEdit2
    {
        Dictionary<string, string> _genDic = new Dictionary<string, string>();  // <����, ����>
        Dictionary<string, int> _indexDic = new Dictionary<string, int>();      // <����, ����Index>
        ArrayList _rGList = new ArrayList();                                    // �������X�g

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public TDateEdit3()
        {
            InitializeComponent();

            // 2009.01.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            base.JpGenCombo2.DroppedDown = true;                                                    // ������DropDown�Ȃ���
            // 2009.01.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// OnCreateControl
        /// </summary>
        protected override void OnCreateControl()
        {
            // 2009.01.21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //base.JpGenCombo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;               // DropDown�֕ύX
            //base.JpGenCombo2.DroppedDown = true;                                                    // ������DropDown�Ȃ���
            base.JpGenCombo2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;               // DropDown�֕ύX
            // 2009.01.21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            base.JpGenCombo2.KeyPress += new KeyPressEventHandler(JpGenCombo2_KeyPress);            // �����R���{KeyPress�C�x���g�ǉ�
            base.JpGenCombo2.AfterExitEditMode += new EventHandler(JpGenCombo2_AfterExitEditMode);  // �����R���{AfterExitEditMode�C�x���g�ǉ�

            #region �����R���{��GotFocus�C�x���g�폜
            MethodInfo methodInfo;
            TDateEdit td = new TDateEdit();
            string fullName = td.GetType().FullName;
            string assemblyName = td.GetType().Assembly.GetName().Name;

            this.GetMethodInfo(assemblyName, fullName, new object[] { }, "JpGenCombo2_GotFocus", new object[] { }, out methodInfo);

            Type handlerType = typeof(EventHandler);
            TComboEditor tComboEditor = base.JpGenCombo2;
            Delegate eventMethod = Delegate.CreateDelegate(handlerType, this, methodInfo);
            base.JpGenCombo2.GetType().GetEvent("GotFocus").RemoveEventHandler(base.JpGenCombo2, eventMethod);
            #endregion

            #region �e�탊�X�g�擾
            string ryakGou = string.Empty;
            TDateTime.GetGengouList(out _rGList);
            for (int i = 0; i < _rGList.Count; i++)
            {
                ryakGou = TDateTime.GetRyakGou(_rGList[i].ToString());
                _genDic.Add(ryakGou, _rGList[i].ToString());
                _indexDic.Add(ryakGou, i);
            }
            #endregion

            base.OnCreateControl();
        }

        /// <summary>
        /// OnEnter
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (!_rGList.Contains(base.JpGenCombo2.Text.Trim())) base.JpGenCombo2.SelectedIndex = 0;
        }

        /// <summary>
        /// OnLeave
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)
        {
            if ((base.GetDateYear() == 0) &&
                (base.GetDateMonth() == 0) &&
                (base.GetDateDay() == 0))
            {
                base.JpGenCombo2.ResetText();
                base.JpGenCombo2.SelectedIndex = -1;
            }
            base.OnLeave(e);
        }

        /// <summary>
        /// JpGenCombo2_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JpGenCombo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // �Ώۗ����ȊO��Key�N���A
            if (_genDic.ContainsKey(e.KeyChar.ToString().ToUpper()))
            {
                // ���͗����̑ΏۂƂȂ錳��Index�ݒ�
                base.JpGenCombo2.SelectedIndex = this._indexDic[e.KeyChar.ToString().ToUpper()];
            }
            e.Handled = false;
            e.KeyChar = Char.MinValue;
        }

        /// <summary>
        /// JpGenCombo2_AfterExitEditMode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void JpGenCombo2_AfterExitEditMode(object sender, EventArgs e)
        {
            // �����ȊO�̓��͒l���ݒ肳��Ă���ꍇ�́A�\��������
            if (!_rGList.Contains(base.JpGenCombo2.Text.Trim())) base.JpGenCombo2.SelectedIndex = 0;
        }

        /// <summary>
        /// ���\�b�h���擾����
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="className"></param>
        /// <param name="createArgs"></param>
        /// <param name="methodName"></param>
        /// <param name="executeArgs"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        private bool GetMethodInfo(string assemblyName, string className, object[] createArgs, string methodName, object[] executeArgs, out MethodInfo methodInfo)
        {
            bool result = false;
            methodInfo = null;

            System.Reflection.Assembly asm = System.Reflection.Assembly.Load(assemblyName);
            Type objType = asm.GetType(className);
            if (objType != null)
            {
                object obj = Activator.CreateInstance(objType, createArgs);

                if (obj != null)
                {
                    methodInfo = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                    return (methodInfo != null);
                }
            }
            return result;
        }
    }
}