using System;

namespace Broadleaf.Windows.Forms
{
    using GridRowType= Infragistics.Win.UltraWinGrid.UltraGridRow;
    using ColumnName = Broadleaf.Application.UIData.PrimeSettingInfo;

    /// <summary>
    /// �O���b�h�s�̃w���p�N���X
    /// </summary>
    public class GridRowHelper
    {
        #region <���b�v����O���b�h�s/>

        /// <summary>���b�v����O���b�h�s</summary>
        private readonly GridRowType _myGridRow;
        /// <summary>
        /// ���b�v����O���b�h�s���擾���܂��B
        /// </summary>
        /// <value>���b�v����O���b�h�s</value>
        public GridRowType MyGridRow { get { return _myGridRow; } }

        #endregion  // <���b�v����O���b�h�s/>

        #region <�����ރR�[�h/>

        /// <summary>�����ރR�[�h�̃J������</summary>
        private const string MIDDLE_CODE_COLUMN_NAME = ColumnName.COL_MIDDLEGENRECODE;
        /// <summary>
        /// �����ރR�[�h���擾���܂��B
        /// </summary>
        /// <value>�����ރR�[�h</value>
        public int MiddleCode
        {
            get { return (int)MyGridRow.Cells[MIDDLE_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <�����ރR�[�h/>

        #region <BL�R�[�h/>

        /// <summary>BL�R�[�h�̃J������</summary>
        private const string BL_CODE_COLUMN_NAME = ColumnName.COL_TBSPARTSCODE;
        /// <summary>
        /// BL�R�[�h���擾���܂��B
        /// </summary>
        /// <value>BL�R�[�h</value>
        public int BLCode
        {
            get { return (int)MyGridRow.Cells[BL_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <BL�R�[�h/>

        #region <���[�J�[�R�[�h/>

        /// <summary>���[�J�[�R�[�h�̃J������</summary>
        private const string MAKER_CODE_COLUMN_NAME = ColumnName.COL_PARTSMAKERCD;
        /// <summary>
        /// ���[�J�[�R�[�h���擾���܂��B
        /// </summary>
        /// <value>���[�J�[�R�[�h</value>
        public int MakerCode
        {
            get { return (int)MyGridRow.Cells[MAKER_CODE_COLUMN_NAME].Value; }
        }

        #endregion  // <���[�J�[�R�[�h/>

        #region <�\����/>

        /// <summary>�\�����̃J������</summary>
        //private const string MAKER_DISP_ORDER_COLUMN_NAME = ColumnName.COL_MAKERDISPORDER;
        private const string MAKER_DISP_ORDER_COLUMN_NAME = "UserMakerDispOrder";
        /// <summary>
        /// �\�����̃A�N�Z�T
        /// </summary>
        /// <value>�\����</value>
        public int MakerDispOrder
        {
            get { return (int)MyGridRow.Cells[MAKER_DISP_ORDER_COLUMN_NAME].Value; }
            set { MyGridRow.Cells[MAKER_DISP_ORDER_COLUMN_NAME].Value = value; }
        }

        #endregion  // <�\����/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="gridRowAdaptee">���b�v����O���b�h�s</param>
        public GridRowHelper(GridRowType gridRow)
        {
            _myGridRow = gridRow;
        }

        #endregion  // <Constractor/>
    }



    /// <summary>
    /// �\�[�g���ꂽ�O���b�h�s�̃w���p�N���X
    /// </summary>
    public abstract class SortedGridRowHelper
    {
        #region <�{���̃O���b�h�s/>

        /// <summary>�{���̃O���b�h�s</summary>
        private readonly GridRowHelper _realGridRow;
        /// <summary>
        /// �{���̃O���b�h�s���擾���܂��B
        /// </summary>
        /// <value>�{���̃O���b�h�s</value>
        protected GridRowHelper RealGridRow { get { return _realGridRow; } }

        /// <summary>
        /// �����ރR�[�h���擾���܂��B
        /// </summary>
        /// <value>�����ރR�[�h</value>
        public int MiddleCode
        {
            get { return RealGridRow.MiddleCode; }
        }

        /// <summary>
        /// BL�R�[�h���擾���܂��B
        /// </summary>
        /// <value>BL�R�[�h</value>
        public int BLCode
        {
            get { return RealGridRow.BLCode; }
        }

        /// <summary>
        /// ���[�J�[�R�[�h���擾���܂��B
        /// </summary>
        /// <value>���[�J�[�R�[�h</value>
        public int MakerCode
        {
            get { return RealGridRow.MakerCode; }
        }

        #endregion  // <�{���̃O���b�h�s/>

        #region <���O�̃O���b�h�s/>

        /// <summary>���O�̃O���b�h�s</summary>
        private readonly SortedGridRowHelper _previous;
        /// <summary>
        /// ���O�̃O���b�h�s���擾���܂��B
        /// </summary>
        /// <value>���O�̃O���b�h�s</value>
        protected SortedGridRowHelper Previous { get { return _previous; } }

        #endregion  // <���O�̃O���b�h�s/>

        #region <���̃O���b�h�s/>

        /// <summary>���̃O���b�h�s</summary>
        protected SortedGridRowHelper _next;
        /// <summary>
        /// ���̃O���b�h�s�̃A�N�Z�T
        /// </summary>
        /// <value>���̃O���b�h�s</value>
        protected SortedGridRowHelper Next { get { return _next; } }

        #endregion  // <���̃O���b�h�s/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGridRow">�{���̃O���b�h�s</param>
        /// <param name="previous">���O�̃O���b�h�s</param>
        protected SortedGridRowHelper(
            GridRowHelper realGridRow,
            SortedGridRowHelper previous
        )
        {
            _realGridRow = realGridRow;
            _previous = previous;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���̃O���b�h�s��ݒ肵�܂��B
        /// </summary>
        /// <param name="realGridRow">�{���̎��̃O���b�h�s</param>
        public abstract void SetNext(GridRowHelper realNextGridRow);

        /// <summary>
        /// �\�����̃A�N�Z�T
        /// </summary>
        /// <value>�\����</value>
        public int MakerDispOrder
        {
            get { return RealGridRow.MakerDispOrder; }
            set
            {
                RealGridRow.MakerDispOrder = value;

                if (Next != null)
                {
                    Next.IncrementMakerDispOrder(value);
                }
                if (Previous != null)
                {
                    Previous.DecrementMakerDispOrder(value);
                }
            }
        }

        /// <summary>
        /// �\�������C���N�������g���܂��B
        /// </summary>
        /// <param name="previousMakerDispOrder">���O�̕\����</param>
        protected virtual void IncrementMakerDispOrder(int previousMakerDispOrder)
        {
            // �������Ȃ�
        }

        /// <summary>
        /// �\�������f�N�������g���܂��B
        /// </summary>
        /// <param name="nextMakerDispOrder">���̕\����</param>
        protected virtual void DecrementMakerDispOrder(int nextMakerDispOrder)
        {
            // �����Ȃ�
        }

        /// <summary>
        /// �O���b�h�s���������܂��B
        /// </summary>
        /// <param name="middleCode">�����ރR�[�h</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns></returns>
        public SortedGridRowHelper Find(
            int middleCode,
            int blCode,
            int makerCode
        )
        {
            SortedGridRowHelper foundGridRow = null;

            // ���g���r
            if (
                MiddleCode.Equals(middleCode)
                    &&
                BLCode.Equals(blCode)
                    &&
                MakerCode.Equals(makerCode)
            )
            {
                foundGridRow = this;
            }

            // �����r
            if (foundGridRow == null)
            {
                foundGridRow = Next.Find(middleCode, blCode, makerCode);
            }

            // �O���r
            if (foundGridRow == null)
            {
                foundGridRow = Previous.Find(middleCode, blCode, makerCode);
            }

            return foundGridRow;
        }
    }



    /// <summary>
    /// ���O�̃O���b�h�s�̃w���p�N���X
    /// </summary>
    public sealed class PreviousGridRowHelper : SortedGridRowHelper
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGridRow">�{���̃O���b�h�s</param>
        /// <param name="previous">���O�̃O���b�h�s</param>
        public PreviousGridRowHelper(
            GridRowHelper realGridRow,
            SortedGridRowHelper previous
        ) : base(realGridRow, previous) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���̃O���b�h�s��ݒ肵�܂��B
        /// </summary>
        /// <param name="realGridRow">�{���̎��̃O���b�h�s</param>
        /// <exception cref="NotImplementedException">�{���\�b�h�͎�������Ă��܂���B</exception>
        public override void SetNext(GridRowHelper realNextGridRow)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// �\�������f�N�������g���܂��B
        /// </summary>
        /// <param name="nextMakerDispOrder">���̕\����</param>
        protected override void DecrementMakerDispOrder(int nextMakerDispOrder)
        {
            int previousMakerDispOrder = nextMakerDispOrder - 1;
            if (MakerDispOrder >= previousMakerDispOrder)
            {
                MakerDispOrder = previousMakerDispOrder;
            }
        }
    }



    /// <summary>
    /// ���̃O���b�h�s�̃w���p�N���X
    /// </summary>
    public sealed class NextGridRowHelper : SortedGridRowHelper
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="realGrid">�{���̃O���b�h�s</param>
        /// <param name="previous">���O�̃O���b�h�s</param>
        public NextGridRowHelper(
            GridRowHelper realGrid,
            SortedGridRowHelper previous
        ) : base(realGrid, previous) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���̃O���b�h�s��ݒ肵�܂��B
        /// </summary>
        /// <param name="realGridRow">�{���̎��̃O���b�h�s</param>
        public override void SetNext(GridRowHelper realNextGridRow)
        {
            if (Next == null)
            {
                _next = new NextGridRowHelper(realNextGridRow, new PreviousGridRowHelper(RealGridRow, Previous));
            }
            else
            {
                Next.SetNext(realNextGridRow);
            }
        }

        /// <summary>
        /// �\�������C���N�������g���܂��B
        /// </summary>
        /// <param name="previousMakerDispOrder">���O�̕\����</param>
        protected override void IncrementMakerDispOrder(int previousMakerDispOrder)
        {
            int nextMakerDispOrder = previousMakerDispOrder + 1;
            if (MakerDispOrder <= nextMakerDispOrder)
            {
                MakerDispOrder = nextMakerDispOrder;
            }
        }
    }
}
