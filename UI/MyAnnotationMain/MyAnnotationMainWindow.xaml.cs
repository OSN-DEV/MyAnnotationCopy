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

            this._viewModel = new MyAnnotationMainViewModel(this);
            this.DataContext = this._viewModel;
        }
        #endregion
    }
}
