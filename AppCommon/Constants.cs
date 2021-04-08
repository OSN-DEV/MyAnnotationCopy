using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnnotationCopy.AppCommon {
    /// <summary>
    /// 定数定義
    /// </summary>
    internal class Constants {

        /// <summary>
        /// 明細の最大行数
        /// </summary>
        internal const int MaxRowCount = 5;

        /// <summary>
        /// アプリケーションデータ
        /// </summary>
        internal static readonly string AppDataFile = OsnCsLib.Common.Util.GetAppPath() + @"app.data";
    }
}
