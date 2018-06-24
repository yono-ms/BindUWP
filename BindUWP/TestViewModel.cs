using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BindUWP
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; } = "初期値";
        public string Description { get; set; }

        private string name;

        [Required(ErrorMessage = "お名前を入力してください。")]
        [RegularExpression("[^0-9A-Za-z]+", ErrorMessage = "英数字は使用できません。")]
        [StringLength(4, ErrorMessage = "お名前は{1}桁以内で入力してください。")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NameError = ValidateProperty(value);
                OnPropertyChanged();
            }
        }

        private string nameError;

        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanCommit));
            }
        }

        public string NameTitle { get; set; } = "お名前";

        public bool CanCommit
        {
            get
            {
                return string.IsNullOrEmpty(NameError);
            }
        }

        public void Commit()
        {
            System.Diagnostics.Debug.WriteLine("Commit.");
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TestViewModel()
        {
            Title = "コンストラクタで設定したタイトル";
            Description = "コンストラクタで設定した説明文です。";
            NextButtonText = "コンストラクタで設定したボタンテキスト";
            Name = "";
        }

        private string nextButtonText;

        public string NextButtonText
        {
            get { return nextButtonText; }
            set
            {
                nextButtonText = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティバリデーションを実行する.
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <returns>エラーメッセージ</returns>
        private String ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            var context = new ValidationContext(this) { MemberName = propertyName };
            var validationErrors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, validationErrors))
            {
                var errors = validationErrors.Select(e => e.ErrorMessage);
                var result = string.Join("\n", errors);
                return result;
            } else
            {
                return null;
            }
        }
    }
}
