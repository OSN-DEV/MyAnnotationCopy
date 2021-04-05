using MyAnnotationCopy.Data;
using OsnCsLib.WPFComponent.Bind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnnotationCopy.UI.MyAnnotationMain {
    /// <summary>
    /// アノテーションメイン画面のビューモデル
    /// </summary>
    internal class MyAnnotationMainViewModel : BaseBindable {

        #region Declaration
        MyAnnotationMainWindow _window;
        #endregion

        #region Public Property
        public PreferenceData AppData { set; get; }

        /// <summary>
        /// カウントアップコマンド
        /// </summary>
        public DelegateCommand CountUpCommand { set; get; }

        /// <summary>
        /// カウントダウンコマンド
        /// </summary>
        public DelegateCommand CountDownCommand { set; get; }

        /// <summary>
        /// リセットコマンド
        /// </summary>
        public DelegateCommand ResetCommand { set; get; }
        #endregion

        #region Constructor
        internal MyAnnotationMainViewModel(MyAnnotationMainWindow window) {
            this._window = window;
            this.Initialize();
        }
        #endregion

        #region Internal Method
        /// <summary>
        /// アプリ終了時処理
        /// </summary>
        internal void AppClosing() {
            // TODO : アプリケーションデータを保存する
        }
        #endregion

        #region Private Method(Event)
        /// <summary>
        /// カウントアップ クリック時処理
        /// </summary>
        private void CountUpClick() {

        }

        /// <summary>
        /// カウントダウン クリック時処理
        /// </summary>
        private void CountDownClick() {

        }

        /// <summary>
        /// リセット クリック時処理
        /// </summary>
        private void ResetClick() {

        }
        #endregion

        #region Private Method
        /// <summary>
        /// カウントアップ・ダウンの実行可否
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteCountButtonEvent() {
            return true;
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        private void Initialize() {
            // 
            this.CountUpCommand = new DelegateCommand(this.CountUpClick, CanExecuteCountButtonEvent);
            this.CountDownCommand = new DelegateCommand(this.CountDownClick, CanExecuteCountButtonEvent);
            this.ResetCommand = new DelegateCommand(this.ResetClick);

            // 
            this.AppData = new PreferenceData(); // TODO 保存しているデータの読込
        }
        #endregion

    }
}
