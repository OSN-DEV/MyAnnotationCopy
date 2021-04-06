using MyAnnotationCopy.Repo;
using MyAnnotationCopy.UseCase;
using System.Windows;

namespace MyAnnotationCopy.UI.MyAnnotationMain {
    /// <summary>
    /// アノテーションメイン画面
    /// </summary>
    public partial class MyAnnotationMainWindow : Window {

        #region Declaration
        private readonly MyAnnotationMainViewModel _viewModel;
        #endregion

        #region Constructor
        public MyAnnotationMainWindow() {
            InitializeComponent();

            this._viewModel = new MyAnnotationMainViewModel(this, new PreferenceUseCase(new PreferenceXmlRepo()));
            this.DataContext = this._viewModel;

            this.Closing += (sender, e) => {
                this._viewModel.AppClosing();
            };
        }
        #endregion

        #region Event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentNumberChange(object sender, System.EventArgs e) {
            this._viewModel.CountUpCommand.Execute(null);
        }
        #endregion
    }
}
