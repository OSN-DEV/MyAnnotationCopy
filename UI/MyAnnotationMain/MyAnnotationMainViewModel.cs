using MyAnnotationCopy.Data;
using MyAnnotationCopy.UseCase;
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
        private readonly MyAnnotationMainWindow _window;
        private readonly IPreferenceUseCase _useCase;
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
        internal MyAnnotationMainViewModel(MyAnnotationMainWindow window, IPreferenceUseCase useCase) {
            this._window = window;
            this._useCase = useCase;
            this.Initialize();
        }
        #endregion

        #region Internal Method
        /// <summary>
        /// アプリ終了時処理
        /// </summary>
        internal void AppClosing() {
            this.AppData.X = this._window.Left;
            this.AppData.Y = this._window.Top;
            this._useCase.Save(this.AppData);
        }
        #endregion

        #region Private Method(Event)
        /// <summary>
        /// カウントアップ クリック時処理
        /// </summary>
        private void CountUpClick() {
            if (this.AppData.CurrentNumber < 999) {
                this.AppData.CurrentNumber++;
            }
        }

        /// <summary>
        /// カウントダウン クリック時処理
        /// </summary>
        private void CountDownClick() {
            if (1 < this.AppData.CurrentNumber) {
                this.AppData.CurrentNumber--;
            }
        }

        /// <summary>
        /// リセット クリック時処理
        /// </summary>
        private void ResetClick() {
            this.AppData.CurrentNumber = 1;
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
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            this._window.Title = $"アノテーションコピーツール({asm.GetName().Version})";

            //
            this.AppData = this._useCase.Load();
        }
        #endregion

    }
}
