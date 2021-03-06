using OsnCsLib.WPFComponent.Bind;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace MyAnnotationCopy.Component {
    /// <summary>
    /// アノテーション操作コントロール
    /// </summary>
    public partial class AnnottionControl : UserControl {

        #region Public Event
        public EventHandler<EventArgs> OnCurrentNumberChange;
        public event EventHandler<EventArgs> CurrentNumberChange {
            add { OnCurrentNumberChange += value; }
            remove { OnCurrentNumberChange -= value; }
        }
        #endregion


        #region Public Method
        /// <summary>
        /// 自動カウント使用有無
        /// </summary>
        public static readonly DependencyProperty IsUseIncrementProperty = RegisterProperty(nameof(IsUseIncrement), typeof(bool));
        public bool IsUseIncrement {
            get { return (bool)GetValue(IsUseIncrementProperty); }
            set { SetValue(IsUseIncrementProperty, value); }
        }

        /// <summary>
        /// 全角変換使用有無
        /// </summary>
        public static readonly DependencyProperty IsUseWideProperty = RegisterProperty(nameof(IsUseWide), typeof(bool));
        public bool IsUseWide {
            get { return (bool)GetValue(IsUseWideProperty); }
            set { SetValue(IsUseWideProperty, value); }
        }

        /// <summary>
        /// プレフィックス
        /// </summary>
        public static readonly DependencyProperty PrefixProperty = RegisterProperty(nameof(Prefix), typeof(string));
        public string Prefix {
            get { return (string)GetValue(PrefixProperty); }
            set { SetValue(PrefixProperty, value); }
        }

        /// <summary>
        /// 現在の番号ラベル
        /// </summary>
        public static readonly DependencyProperty CurrentNumberLabelProperty = RegisterProperty(nameof(CurrentNumberLabel), typeof(int));
        public int CurrentNumberLabel {
            get { return (int)GetValue(CurrentNumberLabelProperty); }
            set { SetValue(CurrentNumberLabelProperty, value); }
        }

        /// <summary>
        /// サフィックス
        /// </summary>
        public static readonly DependencyProperty SafixProperty = RegisterProperty(nameof(Safix), typeof(string));
        public string Safix {
            get { return (string)GetValue(SafixProperty); }
            set { SetValue(SafixProperty, value); }
        }

        /// <summary>
        /// コピーコマンド
        /// </summary>
        public DelegateCommand CopyCommand { set; get; }
        #endregion

        #region Constructor
        public AnnottionControl() {
            InitializeComponent();
            //this.CopyCommand = new DelegateCommand(CopyClick);
        }

        static AnnottionControl() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnnottionControl), new FrameworkPropertyMetadata(typeof(AnnottionControl)));
        }
        #endregion


        #region Private Method(Event)
        /// <summary>
        /// コピーボタン クリック時処理
        /// </summary>
        private void CopyClick(object sender, EventArgs e) {
            string num = this.CurrentNumberLabel.ToString();
            if (this.IsUseWide) {
                num = HanToZenNum(num);
            }
            SetTextToClipboard($"{this.Prefix}{num}{this.Safix}");

            if (this.IsUseIncrement) {
                OnCurrentNumberChange?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// プロパティを登録する
        /// </summary>
        /// <param name="name">プロパティ名</param>
        /// <param name="propertyType">プロパティの型</param>
        private static DependencyProperty RegisterProperty(string name, Type propertyType) {
            return DependencyProperty.Register(name, propertyType, typeof(AnnottionControl), new FrameworkPropertyMetadata());
        }

        /// <summary>
        /// テキストをクリップボードにコピーする
        /// </summary>
        /// <param name="text">コピーするテキスト</param>
        private static void SetTextToClipboard(string text) {
            try {
                Clipboard.Clear();
                System.Threading.Thread.Sleep(100);
                Clipboard.SetText(text, TextDataFormat.UnicodeText);
            } catch {
                try {
                    Clipboard.SetDataObject(text);
                } catch {
                }
            }
        }

        /// <summary>
        /// 半角数値を全角に変換する
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string HanToZenNum(string s) {
            return Regex.Replace(s, "[0-9]", p => ((char)(p.Value[0] - '0' + '０')).ToString());
        }
        #endregion

        private void Button_Click(object sender, RoutedEventArgs e) {

        }
    }
}
