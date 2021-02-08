using System.Linq;
using System.Windows.Forms;
using WorkTimer.Domain.Models.Models.QuickActions;
using WorkTimer.UI.Models;

namespace WorkTimer.CustomControls.QuickActions
{
    public partial class AskForm : Form
    {
        public AskForm()
        {
            InitializeComponent();
            TopMost = true;
        }

        public AskModel Question { get; set; }

        public AskAnswerModel Answer { get; private set; }

        public void Init()
        {
            questionLabel.Text = Question.Text;
            okButton.Enabled = false;
            var questions = Question.Answers;
            foreach (var question in questions)
            {
                answerListBox.Items.Add(new ListBoxItem<AskAnswerModel>()
                {
                    Text = question.Text,
                    Data = question,
                });
            }

            var selectedQuestion = questions.FirstOrDefault(q => q.Default);
            if (selectedQuestion != null)
            {
                answerListBox.SetSelected(questions.ToList().IndexOf(selectedQuestion), true);
                SelectedAnswerChanged();
            }
            
            BringToFront();
        }

        private void answerListBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            SelectedAnswerChanged();
        }

        private void SelectedAnswerChanged()
        {
            Answer = (answerListBox.SelectedItem as ListBoxItem<AskAnswerModel>)?.Data;
            if (Answer == null)
            {
                okButton.Enabled = false;
                return;
            }

            okButton.Enabled = true;
        }

        private void okButton_Click(object sender, System.EventArgs e)
        {
            CloseForm();
        }

        private void answerListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!okButton.Enabled)
            {
                return;
            }

            CloseForm();
        }

        private void CloseForm()
        {
            DialogResult = DialogResult.OK;
            base.Close();
        }
    }
}
