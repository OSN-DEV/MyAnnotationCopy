using MyAnnotationCopy.AppCommon;
using OsnCsLib.WPFComponent.Bind;

namespace MyAnnotationCopy.Data {
    /// <summary>
    /// アプリケーションデータ データモデル
    /// </summary>
    public class PreferenceData : BaseBindable {

        #region Internal Property
        /// <summary>
        /// ウィンドウのX座標
        /// </summary>
        private double _x;
        public double X {
            set { base.SetProperty(ref this._x, value); }
            get { return this._x; }
        }

        /// <summary>
        /// ウィンドウのY座標
        /// </summary>
        private double _y;
        public double Y {
            set { base.SetProperty(ref this._y, value); }
            get { return this._y; }
        }

        /// <summary>
        /// 現在の番号
        /// </summary>
        private int _currentNumber = 1;
        public int CurrentNumber {
            set { base.SetProperty(ref this._currentNumber, value); }
            get { return this._currentNumber; }
        }

        /// <summary>
        /// 設定詳細
        /// </summary>
        private PreferenceDetailData[] _settingDetail = new PreferenceDetailData[Constants.MaxRowCount];
        public PreferenceDetailData[] SettingDetail {
            set { base.SetProperty(ref this._settingDetail, value); }
            get { return this._settingDetail; }
        }
        #endregion

        #region Constructor
        public PreferenceData() { }

        #endregion
    }
}
