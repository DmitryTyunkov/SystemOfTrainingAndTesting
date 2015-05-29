using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemOfTrainingAndTesting
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Строка информации о пользователе
        /// </summary>
        private string userString;
        /// <summary>
        /// Строка с названием и описанием выбранного теста
        /// </summary>
        private string selectTestString;
        /// <summary>
        /// Строка с ответом
        /// </summary>
        private string selectAnswerString;
        /// <summary>
        /// Номер вопроса
        /// </summary>
        private int questionNumber;
        /// <summary>
        /// Список верных ответов
        /// </summary>
        private List<int> correctAnswers = new List<int>();
        /// <summary>
        /// Список ответов
        /// </summary>
        private List<string> answerString = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для создания главного окна
        /// </summary>
        private void CreateMainWindow()
        {
            #region Убираем элементы с формы
            this.Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форму
            #region Добавляем label для отображения информации о пользователе
            System.Windows.Forms.Label labelUser = new System.Windows.Forms.Label();
            labelUser.Parent = this;
            labelUser.Text = userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new System.Drawing.Point(this.ClientSize.Width - (labelUser.Width + 13), 13);
            this.Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            System.Windows.Forms.Label labelTitle = new System.Windows.Forms.Label();
            labelTitle.Parent = this;
            labelTitle.Text = "Выбирите необходимый режим";
            labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            this.Controls.Add(labelTitle);
            #endregion
            #region Добавляем кнопку "Обучение"
            System.Windows.Forms.Button buttonTraining = new System.Windows.Forms.Button();
            buttonTraining.Parent = this;
            buttonTraining.Text = "Обучение";
            buttonTraining.Size = new System.Drawing.Size(75 * 3, 23 * 3);
            buttonTraining.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonTraining.Width / 2,
                labelTitle.Height + labelTitle.Location.Y + 13);
            buttonTraining.Visible = true;
            buttonTraining.TabIndex = 0;
            buttonTraining.Click += new System.EventHandler(this.buttonTraining_Click);
            this.Controls.Add(buttonTraining);
            #endregion
            #region Добавляем кнопку "Тестирование"
            System.Windows.Forms.Button buttonTesting = new System.Windows.Forms.Button();
            buttonTesting.Parent = this;
            buttonTesting.Text = "Тестирование";
            buttonTesting.Size = new System.Drawing.Size(75 * 3, 23 * 3);
            buttonTesting.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonTesting.Width / 2,
                buttonTraining.Height + buttonTraining.Location.Y + 13);
            buttonTesting.Visible = true;
            buttonTesting.TabIndex = 1;
            buttonTesting.Click += new System.EventHandler(this.buttonTesting_Click);
            this.Controls.Add(buttonTesting);
            #endregion
            #region Добавление кнопки в зависимости от привелегий пользователя
            switch (UserInfo.level)
            {
                case 0:
                    #region Добавляем кнопку "Управление"
                    System.Windows.Forms.Button buttonControl = new System.Windows.Forms.Button();
                    buttonControl.Parent = this;
                    buttonControl.Text = "Управление";
                    buttonControl.Size = new System.Drawing.Size(75 * 3, 23 * 3);
                    buttonControl.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonTraining.Width / 2,
                        buttonTesting.Height + buttonTesting.Location.Y + 13);
                    buttonControl.Visible = true;
                    buttonControl.TabIndex = 2;
                    buttonControl.Click += new System.EventHandler(this.buttonControl_Click);
                    this.Controls.Add(buttonControl);
                    #endregion
                    break;
                case 1:
                    #region Добавляем кнопку "Статистика"
                    System.Windows.Forms.Button buttonStatistics = new System.Windows.Forms.Button();
                    buttonStatistics.Parent = this;
                    buttonStatistics.Text = "Статистика";
                    buttonStatistics.Size = new System.Drawing.Size(75 * 3, 23 * 3);
                    buttonStatistics.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonTraining.Width / 2,
                        buttonTesting.Height + buttonTesting.Location.Y + 13);
                    buttonStatistics.Visible = true;
                    buttonStatistics.TabIndex = 2;
                    buttonStatistics.Click += new System.EventHandler(this.buttonStatistics_Click);
                    this.Controls.Add(buttonStatistics);
                    #endregion
                    break;
                default:
                    throw new Exception("Неверный уровень прав пользователя", null);
            }
            #endregion
            #endregion
        }
        /// <summary>
        /// Метод для создания окна обучения
        /// </summary>
        private void CreateTrainingWindow()
        {
            #region Убираем элементы с формы
            this.Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            System.Windows.Forms.Label labelUser = new System.Windows.Forms.Label();
            labelUser.Parent = this;
            labelUser.Text = userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new System.Drawing.Point(this.ClientSize.Width - (labelUser.Width + 13), 13);
            this.Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            System.Windows.Forms.Label labelTitle = new System.Windows.Forms.Label();
            labelTitle.Parent = this;
            labelTitle.Text = "Выбирите необходимую тему";
            labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            this.Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными темами
            System.Windows.Forms.ListBox listBoxThems = new System.Windows.Forms.ListBox();
            listBoxThems.Parent = this;
            listBoxThems.TabIndex = 0;
            listBoxThems.Size = new System.Drawing.Size(this.ClientSize.Width - 26, this.ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13 * 3 - 23);
            listBoxThems.Visible = true;
            listBoxThems.Location = new System.Drawing.Point(13, labelTitle.Height + labelTitle.Location.Y + 13);
            this.Controls.Add(listBoxThems);
            #endregion
            #region Добавляем кнопку "Выбрать"
            System.Windows.Forms.Button buttonSelect = new System.Windows.Forms.Button();
            buttonSelect.Parent = this;
            buttonSelect.Text = "Выбрать";
            buttonSelect.Size = new System.Drawing.Size(75, 23);
            buttonSelect.Location = new System.Drawing.Point(this.ClientSize.Width - buttonSelect.Width - 13,
                listBoxThems.Height + listBoxThems.Location.Y + 13);
            buttonSelect.Visible = true;
            buttonSelect.TabIndex = 2;
            buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            this.Controls.Add(buttonSelect);
            #endregion
            #region Добавить кнопку "Назад"
            System.Windows.Forms.Button buttonBack = new System.Windows.Forms.Button();
            buttonBack.Parent = this;
            buttonBack.Text = "Назад";
            buttonBack.Size = new System.Drawing.Size(75, 23);
            buttonBack.Location = new System.Drawing.Point(13, listBoxThems.Height + listBoxThems.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.Controls.Add(buttonBack);
            #endregion
            #endregion
        }
        /// <summary>
        /// Метод для создания окна тестирования
        /// </summary>
        private void CreateTestingWindow()
        {
            #region Убираем элементы с формы
            this.Controls.Clear();
            #endregion
            Find.FindTests();
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            System.Windows.Forms.Label labelUser = new System.Windows.Forms.Label();
            labelUser.Parent = this;
            labelUser.Text = userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new System.Drawing.Point(this.ClientSize.Width - (labelUser.Width + 13), 13);
            this.Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            System.Windows.Forms.Label labelTitle = new System.Windows.Forms.Label();
            labelTitle.Parent = this;
            labelTitle.Text = "Выбирите необходимый тест";
            labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            this.Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными тестами
            System.Windows.Forms.ListBox listBoxTests = new System.Windows.Forms.ListBox();
            listBoxTests.Parent = this;
            listBoxTests.TabIndex = 0;
            listBoxTests.Size = new System.Drawing.Size(this.ClientSize.Width - 26, this.ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13 * 3 - 23);
            listBoxTests.Visible = true;
            listBoxTests.Location = new System.Drawing.Point(13, labelTitle.Height + labelTitle.Location.Y + 13);
            listBoxTests.SelectionMode = SelectionMode.One;
            foreach (string item in TestsInfo.titleAndDescription)
            {
                listBoxTests.Items.Add(item);
            }
            listBoxTests.SelectedIndexChanged += new System.EventHandler(listBoxTests_SelectedIndexChanged);
            listBoxTests.SelectedIndex = 0;
            this.Controls.Add(listBoxTests);
            #endregion
            #region Добавляем кнопку "Выбрать"
            System.Windows.Forms.Button buttonSelect = new System.Windows.Forms.Button();
            buttonSelect.Parent = this;
            buttonSelect.Text = "Выбрать";
            buttonSelect.Size = new System.Drawing.Size(75, 23);
            buttonSelect.Location = new System.Drawing.Point(this.ClientSize.Width - buttonSelect.Width - 13,
                listBoxTests.Height + listBoxTests.Location.Y + 13);
            buttonSelect.Visible = true;
            buttonSelect.TabIndex = 2;
            buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            this.Controls.Add(buttonSelect);
            #endregion
            #region Добавить кнопку "Назад"
            System.Windows.Forms.Button buttonBack = new System.Windows.Forms.Button();
            buttonBack.Parent = this;
            buttonBack.Text = "Назад";
            buttonBack.Size = new System.Drawing.Size(75, 23);
            buttonBack.Location = new System.Drawing.Point(13, listBoxTests.Height + listBoxTests.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.Controls.Add(buttonBack);
            #endregion
            #endregion
        }
        /// <summary>
        /// Метод для создания окна статистики
        /// </summary>
        private void CreateStatisticsWindow()
        {
            #region Убираем элементы с формы
            this.Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            System.Windows.Forms.Label labelUser = new System.Windows.Forms.Label();
            labelUser.Parent = this;
            labelUser.Text = userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new System.Drawing.Point(this.ClientSize.Width - (labelUser.Width + 13), 13);
            this.Controls.Add(labelUser);
            #endregion
            #region Добавление вкладок
            System.Windows.Forms.TabControl tabControl = new System.Windows.Forms.TabControl();
            tabControl.Parent = this;
            tabControl.Location = new System.Drawing.Point(0, labelUser.Height);
            tabControl.TabIndex = 0;
            tabControl.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - labelUser.Height - 23 - 13 * 2);
            tabControl.Visible = true;
            this.Controls.Add(tabControl);
            System.Windows.Forms.TabPage tabPageTraining = new System.Windows.Forms.TabPage();
            tabPageTraining.Location = new System.Drawing.Point(4, 22);
            tabPageTraining.Padding = new System.Windows.Forms.Padding(3);
            tabPageTraining.Size = new System.Drawing.Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26);
            tabPageTraining.TabIndex = 0;
            tabPageTraining.Text = "Обучение";
            tabControl.Controls.Add(tabPageTraining);
            System.Windows.Forms.TabPage tabPageTesting = new System.Windows.Forms.TabPage();
            tabPageTesting.Location = new System.Drawing.Point(4, 22);
            tabPageTesting.Padding = new System.Windows.Forms.Padding(3);
            tabPageTesting.Size = new System.Drawing.Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26);
            tabPageTesting.TabIndex = 1;
            tabPageTesting.Text = "Тестирование";
            tabControl.Controls.Add(tabPageTesting);
            #endregion
            #region Добавляем listBox с доступными тестами
            System.Windows.Forms.ListBox listBoxTests = new System.Windows.Forms.ListBox();
            //listBoxTests.Parent = this;
            listBoxTests.TabIndex = 0;
            listBoxTests.Size = new System.Drawing.Size(tabPageTesting.Size.Width - 26, tabPageTesting.Size.Height - 13 * 2);
            listBoxTests.Visible = true;
            listBoxTests.Location = new System.Drawing.Point(13, 13);
            tabPageTesting.Controls.Add(listBoxTests);
            #endregion
            #region Добавляем listBox с доступными темами
            System.Windows.Forms.ListBox listBoxThems = new System.Windows.Forms.ListBox();
            //listBoxTests.Parent = this;
            listBoxThems.TabIndex = 0;
            listBoxThems.Size = new System.Drawing.Size(tabPageTesting.Size.Width - 26, tabPageTesting.Size.Height - 13 * 2);
            listBoxThems.Visible = true;
            listBoxThems.Location = new System.Drawing.Point(13, 13);
            tabPageTraining.Controls.Add(listBoxThems);
            #endregion
            #region Добавить кнопку "Назад"
            System.Windows.Forms.Button buttonBack = new System.Windows.Forms.Button();
            buttonBack.Parent = this;
            buttonBack.Text = "Назад";
            buttonBack.Size = new System.Drawing.Size(75, 23);
            buttonBack.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonBack.Width / 2, tabControl.Height + tabControl.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.Controls.Add(buttonBack);
            #endregion
            #endregion
        }
        /// <summary>
        /// Метод для создания окна вопроса
        /// </summary>
        private void CreateQuestionWindow()
        {
            #region Убираем элементы с формы
            this.Controls.Clear();
            #endregion
            selectAnswerString = null;
            Find.FindAnswers(QuestionsInfo.id[questionNumber]);
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            System.Windows.Forms.Label labelUser = new System.Windows.Forms.Label();
            labelUser.Parent = this;
            labelUser.Text = userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new System.Drawing.Point(this.ClientSize.Width - (labelUser.Width + 13), 13);
            this.Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения вопроса
            System.Windows.Forms.Label labelQuestion = new System.Windows.Forms.Label();
            labelQuestion.Parent = this;
            labelQuestion.Text = QuestionsInfo.question[questionNumber];
            int position = 0;
            while (position < labelQuestion.Text.Length - 30)
            {
                position = labelQuestion.Text.IndexOf(" ", position + 30);
                if (position > 0)
                {
                    labelQuestion.Text = labelQuestion.Text.Insert(position, "\r\n");
                }
                else
                {
                    position = labelQuestion.Text.Length;
                }
            }
            labelQuestion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelQuestion.AutoSize = true;
            labelQuestion.Visible = true;
            labelQuestion.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - labelQuestion.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            this.Controls.Add(labelQuestion);
            #endregion
            #region Добавляем ответы
            System.Drawing.Point answerLocation = new System.Drawing.Point();
            switch (QuestionsInfo.typeAnswer[questionNumber])
            {
                #region Выбор одного варианта ответа
                case 0:
                    for (int i = 0; i < AnswersInfo.answer.Count; i++)
                    {
                        System.Windows.Forms.RadioButton radioButtonAnswer = new System.Windows.Forms.RadioButton();
                        radioButtonAnswer.Parent = this;
                        radioButtonAnswer.Text = AnswersInfo.answer[i];
                        radioButtonAnswer.Visible = true;
                        radioButtonAnswer.AutoSize = true;
                        radioButtonAnswer.Location = new System.Drawing.Point(13,labelQuestion.Height + labelQuestion.Location.Y + 13 + i*3*13);
                        answerLocation = radioButtonAnswer.Location;
                        radioButtonAnswer.CheckedChanged += new EventHandler(radioButtonAnswer_CheckedChanged);
                        if (answerString.Contains(radioButtonAnswer.Text))
                        {
                            radioButtonAnswer.Checked = true;
                        }
                        this.Controls.Add(radioButtonAnswer);
                    }
                    break;
                #endregion
            }
            #endregion
            #region Добавляем кнопку "Следующий"
            System.Windows.Forms.Button buttonNext = new System.Windows.Forms.Button();
            buttonNext.Parent = this;
            if (questionNumber == QuestionsInfo.id.Count - 1)
            {
                buttonNext.Text = "Завершить";
            }
            else
            {
                buttonNext.Text = "Следующий";
            }
            buttonNext.Size = new System.Drawing.Size(85, 23);
            buttonNext.Location = new System.Drawing.Point(this.ClientSize.Width - buttonNext.Width - 13,
                answerLocation.Y + 13 * 3);
            buttonNext.Visible = true;
            buttonNext.TabIndex = AnswersInfo.answer.Count + 2;
            buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.Controls.Add(buttonNext);
            #endregion
            #region Добавить кнопку "Предыдущий"
            System.Windows.Forms.Button buttonPrevious = new System.Windows.Forms.Button();
            buttonPrevious.Parent = this;
            buttonPrevious.Text = "Предыдущий";
            buttonPrevious.Size = new System.Drawing.Size(85, 23);
            buttonPrevious.Location = new System.Drawing.Point(13, answerLocation.Y + 13 * 3);
            buttonPrevious.Visible = true;
            if (questionNumber == 0)
            {
                buttonPrevious.Enabled = false;
            }
            else
            {
                buttonPrevious.Enabled = true;
            }
            buttonPrevious.TabIndex = AnswersInfo.answer.Count + 1;
            buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            this.Controls.Add(buttonPrevious);
            #endregion
            #endregion
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            if (Authorization.Auth(this.textBoxLogin.Text, this.textBoxPassword.Text, out userString))
            {
                #region Изменяем размеры и параметры формы
                this.ClientSize = new System.Drawing.Size(640, 480);
                this.MaximizeBox = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.MinimumSize = new System.Drawing.Size(640, 480);
                #endregion
                CreateMainWindow();
            }
            else
            {
                MessageBox.Show(userString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            CreateTrainingWindow();
            //MessageBox.Show("Click to training button","Click message",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonTesting_Click(object sender, EventArgs e)
        {
            CreateTestingWindow();
            //MessageBox.Show("Click to testing button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            CreateStatisticsWindow();
            //MessageBox.Show("Click to statistics button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to control button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int index = TestsInfo.titleAndDescription.IndexOf(selectTestString);
            Find.FindQuestions(TestsInfo.id[index]);
            #region Сброс в начальное значение счетчика и очистка списков
            questionNumber = 0;
            correctAnswers.Clear();
            answerString.Clear();
            #endregion
            CreateQuestionWindow();
            //MessageBox.Show("Click to select button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CreateMainWindow();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            #region Добавление очередного ответа в список и проверка на правильность
            if (selectAnswerString != null)
            {
                answerString.Add(selectAnswerString);
                int index = AnswersInfo.answer.IndexOf(selectAnswerString);
                if (AnswersInfo.correctAnswer[index])
                {
                    if (!correctAnswers.Contains(QuestionsInfo.id[questionNumber]))
                    {
                        correctAnswers.Add(QuestionsInfo.id[questionNumber]);
                    }
                }
                else
                {
                    if (correctAnswers.Contains(QuestionsInfo.id[questionNumber]))
                    {
                        correctAnswers.Remove(QuestionsInfo.id[questionNumber]);
                    }
                }
            }
            #endregion
            questionNumber++;
            #region Выбор действия в зависимости от типа кнопки
            if (questionNumber == QuestionsInfo.id.Count)
            {
                MessageBox.Show(correctAnswers.Count.ToString());
                CreateMainWindow();
            }
            else
            {
                CreateQuestionWindow();
            }
            #endregion
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            #region Добавление очередного ответа в список
            if (selectAnswerString != null)
            {
                answerString.Add(selectAnswerString);
            }
            #endregion
            questionNumber--;
            CreateQuestionWindow();
        }

        private void listBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox listBox = sender as System.Windows.Forms.ListBox;
            if (listBox == null)
            {
                return;
            }
            selectTestString = listBox.SelectedItem.ToString();
        }

        private void radioButtonAnswer_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = sender as System.Windows.Forms.RadioButton;
            if (radioButton == null)
            {
                return;
            }
            if (radioButton.Checked)
            {
                selectAnswerString = radioButton.Text;
            }
            
        }
    }
}
