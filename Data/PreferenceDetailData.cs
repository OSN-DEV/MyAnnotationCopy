using OsnCsLib.WPFComponent.Bind;

namespace MyAnnotationCopy.Data {
    /// <summary>
    /// アプリケーションデータ(詳細) データモデル
    /// </summary>
    internal class PreferenceDetailData : BaseBindable {

        #region Internal Property
        /// <summary>
        /// 自動カウント使用有無
        /// </summary>
        private bool _isUseIncrement;
        internal bool IsUseIncrement {
            set { base.SetProperty(ref this._isUseIncrement, value); }
            get { return this._isUseIncrement; }
        }

        /// <summary>
        /// 全角変換使用有無
        /// </summary>
        private bool _isUseWide;
        internal bool IsUseWide {
            set { base.SetProperty(ref this._isUseWide, value); }
            get { return this._isUseWide; }
        }

        /// <summary>
        /// プレフィックス
        /// </summary>
        private string _prefix;
        internal string Prefix {
            set { base.SetProperty(ref this._prefix, value); }
            get { return this._prefix; }
        }

        /// <summary>
        /// サフィックス
        /// </summary>
        private string _safix;
        internal string Safix {
            set { base.SetProperty(ref this._safix, value); }
            get { return this._safix; }
        }
        #endregion

    }
}
