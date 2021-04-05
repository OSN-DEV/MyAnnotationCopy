﻿using MyAnnotationCopy.Data;

namespace MyAnnotationCopy.UseCase {
    internal interface IPreferenceUseCase {

        #region Internal Method
        /// <summary>
        /// 保存しているデータを取得する
        /// </summary>
        /// <returns>アプリケーションデータ</returns>
        PreferenceData Load();

        /// <summary>
        /// データを保存する
        /// </summary>
        /// <param name="data"></param>
        void Save(PreferenceData data);
        #endregion

    }
}
