using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public TestViewModel()
        {
            Title = "コンストラクタで設定したタイトル";
            Description = "コンストラクタで設定した説明文です。";
            NextButtonText = "コンストラクタで設定したボタンテキスト";
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
    }
}
