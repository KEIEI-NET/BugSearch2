//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������ꗗ�\ ���o�����N���X
//                  :   PMKAU02004E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   22018 ��ؐ��b
// Date             :   2010/07/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   NoDepSalListCdtn
    /// <summary>
    ///                      �������ꗗ�\���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������ꗗ�\���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2010/07/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class NoDepSalListCdtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�J�n�������_�R�[�h</summary>
        private string _demandAddUpSecCdSt = "";

        /// <summary>�I���������_�R�[�h</summary>
        private string _demandAddUpSecCdEd = "";

        /// <summary>�J�n�������Ӑ�R�[�h</summary>
        private Int32 _claimCodeSt;

        /// <summary>�I���������Ӑ�R�[�h</summary>
        private Int32 _claimCodeEd;

        /// <summary>���t�敪</summary>
        /// <remarks>0:�����, 1:���͓�</remarks>
        private Int32 _targetDateDiv;

        /// <summary>�J�n�Ώۓ�</summary>
        /// <remarks>yyyymmdd</remarks>
        private Int32 _dateSt;

        /// <summary>�I���Ώۓ�</summary>
        /// <remarks>yyyymmdd</remarks>
        private Int32 _dateEd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  DemandAddUpSecCdSt
        /// <summary>�J�n�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DemandAddUpSecCdSt
        {
            get { return _demandAddUpSecCdSt; }
            set { _demandAddUpSecCdSt = value; }
        }

        /// public propaty name  :  DemandAddUpSecCdEd
        /// <summary>�I���������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DemandAddUpSecCdEd
        {
            get { return _demandAddUpSecCdEd; }
            set { _demandAddUpSecCdEd = value; }
        }

        /// public propaty name  :  ClaimCodeSt
        /// <summary>�J�n�������Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCodeSt
        {
            get { return _claimCodeSt; }
            set { _claimCodeSt = value; }
        }

        /// public propaty name  :  ClaimCodeEd
        /// <summary>�I���������Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���������Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCodeEd
        {
            get { return _claimCodeEd; }
            set { _claimCodeEd = value; }
        }

        /// public propaty name  :  TargetDateDiv
        /// <summary>���t�敪�v���p�e�B</summary>
        /// <value>0:�����, 1:���͓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���t�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetDateDiv
        {
            get { return _targetDateDiv; }
            set { _targetDateDiv = value; }
        }

        /// public propaty name  :  DateSt
        /// <summary>�J�n�Ώۓ��v���p�e�B</summary>
        /// <value>yyyymmdd</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۓ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DateSt
        {
            get { return _dateSt; }
            set { _dateSt = value; }
        }

        /// public propaty name  :  DateEd
        /// <summary>�I���Ώۓ��v���p�e�B</summary>
        /// <value>yyyymmdd</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۓ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DateEd
        {
            get { return _dateEd; }
            set { _dateEd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// �������ꗗ�\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>NoDepSalListCdtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NoDepSalListCdtn()
        {
        }

        /// <summary>
        /// �������ꗗ�\���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="demandAddUpSecCdSt">�J�n�������_�R�[�h</param>
        /// <param name="demandAddUpSecCdEd">�I���������_�R�[�h</param>
        /// <param name="claimCodeSt">�J�n�������Ӑ�R�[�h</param>
        /// <param name="claimCodeEd">�I���������Ӑ�R�[�h</param>
        /// <param name="targetDateDiv">���t�敪(0:�����, 1:���͓�)</param>
        /// <param name="dateSt">�J�n�Ώۓ�(yyyymmdd)</param>
        /// <param name="dateEd">�I���Ώۓ�(yyyymmdd)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>NoDepSalListCdtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NoDepSalListCdtn( string enterpriseCode, string demandAddUpSecCdSt, string demandAddUpSecCdEd, Int32 claimCodeSt, Int32 claimCodeEd, Int32 targetDateDiv, Int32 dateSt, Int32 dateEd, string enterpriseName )
        {
            this._enterpriseCode = enterpriseCode;
            this._demandAddUpSecCdSt = demandAddUpSecCdSt;
            this._demandAddUpSecCdEd = demandAddUpSecCdEd;
            this._claimCodeSt = claimCodeSt;
            this._claimCodeEd = claimCodeEd;
            this._targetDateDiv = targetDateDiv;
            this._dateSt = dateSt;
            this._dateEd = dateEd;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// �������ꗗ�\���o�������[�N��������
        /// </summary>
        /// <returns>NoDepSalListCdtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����NoDepSalListCdtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NoDepSalListCdtn Clone()
        {
            return new NoDepSalListCdtn( this._enterpriseCode, this._demandAddUpSecCdSt, this._demandAddUpSecCdEd, this._claimCodeSt, this._claimCodeEd, this._targetDateDiv, this._dateSt, this._dateEd, this._enterpriseName );
        }

        /// <summary>
        /// �������ꗗ�\���o�������[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�NoDepSalListCdtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( NoDepSalListCdtn target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.DemandAddUpSecCdSt == target.DemandAddUpSecCdSt)
                 && (this.DemandAddUpSecCdEd == target.DemandAddUpSecCdEd)
                 && (this.ClaimCodeSt == target.ClaimCodeSt)
                 && (this.ClaimCodeEd == target.ClaimCodeEd)
                 && (this.TargetDateDiv == target.TargetDateDiv)
                 && (this.DateSt == target.DateSt)
                 && (this.DateEd == target.DateEd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// �������ꗗ�\���o�������[�N��r����
        /// </summary>
        /// <param name="noDepSalListCdtn1">
        ///                    ��r����NoDepSalListCdtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="noDepSalListCdtn2">��r����NoDepSalListCdtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( NoDepSalListCdtn noDepSalListCdtn1, NoDepSalListCdtn noDepSalListCdtn2 )
        {
            return ((noDepSalListCdtn1.EnterpriseCode == noDepSalListCdtn2.EnterpriseCode)
                 && (noDepSalListCdtn1.DemandAddUpSecCdSt == noDepSalListCdtn2.DemandAddUpSecCdSt)
                 && (noDepSalListCdtn1.DemandAddUpSecCdEd == noDepSalListCdtn2.DemandAddUpSecCdEd)
                 && (noDepSalListCdtn1.ClaimCodeSt == noDepSalListCdtn2.ClaimCodeSt)
                 && (noDepSalListCdtn1.ClaimCodeEd == noDepSalListCdtn2.ClaimCodeEd)
                 && (noDepSalListCdtn1.TargetDateDiv == noDepSalListCdtn2.TargetDateDiv)
                 && (noDepSalListCdtn1.DateSt == noDepSalListCdtn2.DateSt)
                 && (noDepSalListCdtn1.DateEd == noDepSalListCdtn2.DateEd)
                 && (noDepSalListCdtn1.EnterpriseName == noDepSalListCdtn2.EnterpriseName));
        }
        /// <summary>
        /// �������ꗗ�\���o�������[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�NoDepSalListCdtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( NoDepSalListCdtn target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.DemandAddUpSecCdSt != target.DemandAddUpSecCdSt ) resList.Add( "DemandAddUpSecCdSt" );
            if ( this.DemandAddUpSecCdEd != target.DemandAddUpSecCdEd ) resList.Add( "DemandAddUpSecCdEd" );
            if ( this.ClaimCodeSt != target.ClaimCodeSt ) resList.Add( "ClaimCodeSt" );
            if ( this.ClaimCodeEd != target.ClaimCodeEd ) resList.Add( "ClaimCodeEd" );
            if ( this.TargetDateDiv != target.TargetDateDiv ) resList.Add( "TargetDateDiv" );
            if ( this.DateSt != target.DateSt ) resList.Add( "DateSt" );
            if ( this.DateEd != target.DateEd ) resList.Add( "DateEd" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }

        /// <summary>
        /// �������ꗗ�\���o�������[�N��r����
        /// </summary>
        /// <param name="noDepSalListCdtn1">��r����NoDepSalListCdtn�N���X�̃C���X�^���X</param>
        /// <param name="noDepSalListCdtn2">��r����NoDepSalListCdtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   NoDepSalListCdtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( NoDepSalListCdtn noDepSalListCdtn1, NoDepSalListCdtn noDepSalListCdtn2 )
        {
            ArrayList resList = new ArrayList();
            if ( noDepSalListCdtn1.EnterpriseCode != noDepSalListCdtn2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( noDepSalListCdtn1.DemandAddUpSecCdSt != noDepSalListCdtn2.DemandAddUpSecCdSt ) resList.Add( "DemandAddUpSecCdSt" );
            if ( noDepSalListCdtn1.DemandAddUpSecCdEd != noDepSalListCdtn2.DemandAddUpSecCdEd ) resList.Add( "DemandAddUpSecCdEd" );
            if ( noDepSalListCdtn1.ClaimCodeSt != noDepSalListCdtn2.ClaimCodeSt ) resList.Add( "ClaimCodeSt" );
            if ( noDepSalListCdtn1.ClaimCodeEd != noDepSalListCdtn2.ClaimCodeEd ) resList.Add( "ClaimCodeEd" );
            if ( noDepSalListCdtn1.TargetDateDiv != noDepSalListCdtn2.TargetDateDiv ) resList.Add( "TargetDateDiv" );
            if ( noDepSalListCdtn1.DateSt != noDepSalListCdtn2.DateSt ) resList.Add( "DateSt" );
            if ( noDepSalListCdtn1.DateEd != noDepSalListCdtn2.DateEd ) resList.Add( "DateEd" );
            if ( noDepSalListCdtn1.EnterpriseName != noDepSalListCdtn2.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }
    }
}
