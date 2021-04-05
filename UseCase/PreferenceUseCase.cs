using MyAnnotationCopy.AppCommon;
using MyAnnotationCopy.Data;
using MyAnnotationCopy.Repo;

namespace MyAnnotationCopy.UseCase {
    internal class PreferenceUseCase : IPreferenceUseCase {

        #region Declaration
        private IPreferenceRepo _repo;
        #endregion

        #region Constructor
        internal PreferenceUseCase(IPreferenceRepo repo) {
            this._repo = repo;
        }
        #endregion

        #region Internal Method
        /// <summary>
        /// 保存しているデータを取得する
        /// </summary>
        /// <returns>アプリケーションデータ</returns>
        PreferenceData IPreferenceUseCase.Load() {
            this._repo.Load();
            var result = new PreferenceData() {
                X = this._repo.X,
                Y = this._repo.Y,
                CurrentNumber = this._repo.CurrentNumber,
            };
            result.SettingDetail = new PreferenceDetailData[Constants.MaxRowCount];
            for (var i = 0; i < result.SettingDetail.Length; i++) {
                var detail = new PreferenceDetailData();
                detail.IsUseIncrement = this._repo.SettingDetail[i].IsUseIncrement;
                detail.IsUseWide = this._repo.SettingDetail[i].IsUseWide;
                detail.Prefix = this._repo.SettingDetail[i].Prefix;
                detail.Safix = this._repo.SettingDetail[i].Safix;
                result.SettingDetail[i] = detail;
            }
            return result;
        }

        /// <summary>
        /// データを保存する
        /// </summary>
        /// <param name="data"></param>
        void IPreferenceUseCase.Save(PreferenceData data) {
            this._repo.X = data.X;
            this._repo.Y = data.Y;
            this._repo.CurrentNumber = data.CurrentNumber;
            for (var i = 0; i < data.SettingDetail.Length; i++) {
                this._repo.SettingDetail[i].IsUseIncrement = data.SettingDetail[i].IsUseIncrement;
                this._repo.SettingDetail[i].IsUseWide = data.SettingDetail[i].IsUseWide;
                this._repo.SettingDetail[i].Prefix = data.SettingDetail[i].Prefix;
                this._repo.SettingDetail[i].Safix = data.SettingDetail[i].Safix;
            }
            this._repo.Save();
        }
        #endregion

    }
}
