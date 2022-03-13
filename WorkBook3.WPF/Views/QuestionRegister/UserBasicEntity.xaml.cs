using System.Windows;
using System.Windows.Controls;

namespace WorkBook3.WPF.Views.QuestionRegister
{
    /// <summary>
    /// Interaction logic for UserBasicEntity
    /// </summary>
    public partial class UserBasicEntity : UserControl
    {
        public UserBasicEntity()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Content.Equals("【A】"))
            {
                this.ChoiceStringLocal.Text = "1.【A】\n2.【A】\n3.【A】\n4.【A】\n";
                this.QuestionString.Text = "以下の記述中の【A】に入る適切な言葉を選びなさい。";
            }

            if (radioButton.Content.Equals("【A】【B】"))
            {
                this.ChoiceStringLocal.Text = "1.【A】【B】\n2.【A】【B】\n3.【A】【B】\n4.【A】【B】\n";
                this.QuestionString.Text = "以下の記述中の【A】と【B】に入る適切な言葉を選びなさい。";
            }

            if (radioButton.Content.Equals("なし"))
            {
                this.ChoiceStringLocal.Text = "1.\n2.\n3.\n4.\n";
            }
        }
    }
}
