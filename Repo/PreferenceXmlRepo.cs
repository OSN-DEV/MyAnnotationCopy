using MyAnnotationCopy.AppCommon;
using System.IO;
using System.Text;

namespace MyAnnotationCopy.Repo {
    public class PreferenceXmlRepo : IPreferenceRepo {

        #region Declaration
        #endregion

        #region Public Method
        /// <summary>
        /// データを読み込む
        /// </summary>
        public override void Load() {
            if (System.IO.File.Exists(Constants.AppDataFile)) {
                using (var reader = new StreamReader(Constants.AppDataFile, new UTF8Encoding(false))) {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(PreferenceXmlRepo));
                    this.Copy((PreferenceXmlRepo)serializer.Deserialize(reader));

                }
            } else {
                this.SettingDetail = new Detail[Constants.MaxRowCount];
                for (var i = 0; i < this.SettingDetail.Length; i++) {
                    this.SettingDetail[i] = new Detail();
                }
                this.Save();
            }
        }

        /// <summary>
        /// データを保存する
        /// </summary>
        public override void Save() {
            using (var writer = new StreamWriter(Constants.AppDataFile, false, new UTF8Encoding(false))) {
                var seralizer = new System.Xml.Serialization.XmlSerializer(typeof (PreferenceXmlRepo));
                seralizer.Serialize(writer, this);
            }
        }
        #endregion


        #region Private Method
        /// <summary>
        /// メンバーの情報をコピーする。
        /// </summary>
        private void Copy(PreferenceXmlRepo src) {
            this.X = src.X;
            this.Y = src.Y;
            this.CurrentNumber = src.CurrentNumber;
            this.SettingDetail = new Detail[Constants.MaxRowCount];
            for (var i = 0; i < this.SettingDetail.Length; i++) {
                this.SettingDetail[i] = new Detail();
                this.SettingDetail[i].IsUseIncrement = src.SettingDetail[i].IsUseIncrement;
                this.SettingDetail[i].IsUseWide = src.SettingDetail[i].IsUseWide;
                this.SettingDetail[i].Prefix = src.SettingDetail[i].Prefix;
                this.SettingDetail[i].Safix = src.SettingDetail[i].Safix;
            }
        }
        #endregion
    }
}
