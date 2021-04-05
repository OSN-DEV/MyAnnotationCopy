using MyAnnotationCopy.AppCommon;

namespace MyAnnotationCopy.Repo {
    public abstract class IPreferenceRepo {

        #region Declaration

        public class Detail {
            /// <summary>
            /// 自動カウント使用有無
            /// </summary>
            public bool IsUseIncrement { set; get; }

            /// <summary>
            /// 全角変換使用有無
            /// </summary>
            public bool IsUseWide { set; get; }

            /// <summary>
            /// プレフィックス
            /// </summary>
            public string Prefix { set; get; }

            /// <summary>
            /// サフィックス
            /// </summary>
            public string Safix { set; get; }
        }
        #endregion

        #region Public Property
        /// <summary>
        /// ウィンドウのX座標
        /// </summary>
        public double X { set; get; }

        /// <summary>
        /// ウィンドウのY座標
        /// </summary>
        public double Y { set; get; }

        /// <summary>
        /// 現在の番号
        /// </summary>
        public int CurrentNumber { set; get; }

        /// <summary>
        /// 設定詳細
        /// </summary>
        internal Detail[] SettingDetail { set; get; } = new Detail[Constants.MaxRowCount];
        #endregion

        #region Internal Method
        /// <summary>
        /// データをロードする
        /// </summary>
        public abstract void Load();

        /// <summary>
        /// データを保存する
        /// </summary>
        public abstract void Save();
        #endregion
    }
}
