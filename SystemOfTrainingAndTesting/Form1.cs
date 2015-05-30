using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SystemOfTrainingAndTesting
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Строка информации о пользователе
        /// </summary>
        private string _userString;

        /// <summary>
        /// Строка с названием и описанием выбранного теста
        /// </summary>
        private string _selectedTestString;

        /// <summary>
        /// Номер вопроса
        /// </summary>
        private int _questionNumber;

        /// <summary>
        /// Список выбранных ответов
        /// </summary>
        private string _selectedAnswerString;

        /// <summary>
        /// Список верных ответов
        /// </summary>
        private readonly List<int> _correctAnswers = new List<int>();

        /// <summary>
        /// Список ответов
        /// </summary>
        private readonly List<string> _answerString = new List<string>();

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
            Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форму
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label();
            labelUser.Parent = this;
            labelUser.Text = _userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label();
            labelTitle.Parent = this;
            labelTitle.Text = @"Выбирите необходимый режим";
            labelTitle.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем кнопку "Обучение"
            Button buttonTraining = new Button();
            buttonTraining.Parent = this;
            buttonTraining.Text = @"Обучение";
            buttonTraining.Size = new Size(75 * 3, 23 * 3);
            buttonTraining.Location = new Point(ClientSize.Width / 2 - buttonTraining.Width / 2,
                labelTitle.Height + labelTitle.Location.Y + 13);
            buttonTraining.Visible = true;
            buttonTraining.TabIndex = 0;
            buttonTraining.Click += buttonTraining_Click;
            Controls.Add(buttonTraining);
            #endregion
            #region Добавляем кнопку "Тестирование"
            Button buttonTesting = new Button();
            buttonTesting.Parent = this;
            buttonTesting.Text = @"Тестирование";
            buttonTesting.Size = new Size(75 * 3, 23 * 3);
            buttonTesting.Location = new Point(ClientSize.Width / 2 - buttonTesting.Width / 2,
                buttonTraining.Height + buttonTraining.Location.Y + 13);
            buttonTesting.Visible = true;
            buttonTesting.TabIndex = 1;
            buttonTesting.Click += buttonTesting_Click;
            Controls.Add(buttonTesting);
            #endregion
            #region Добавление кнопки в зависимости от привелегий пользователя
            switch (UserInfo.Level)
            {
                case 0:
                    #region Добавляем кнопку "Управление"
                    Button buttonControl = new Button();
                    buttonControl.Parent = this;
                    buttonControl.Text = @"Управление";
                    buttonControl.Size = new Size(75 * 3, 23 * 3);
                    buttonControl.Location = new Point(ClientSize.Width / 2 - buttonTraining.Width / 2,
                        buttonTesting.Height + buttonTesting.Location.Y + 13);
                    buttonControl.Visible = true;
                    buttonControl.TabIndex = 2;
                    buttonControl.Click += buttonControl_Click;
                    Controls.Add(buttonControl);
                    #endregion
                    break;
                case 1:
                    #region Добавляем кнопку "Статистика"
                    Button buttonStatistics = new Button();
                    buttonStatistics.Parent = this;
                    buttonStatistics.Text = @"Статистика";
                    buttonStatistics.Size = new Size(75 * 3, 23 * 3);
                    buttonStatistics.Location = new Point(ClientSize.Width / 2 - buttonTraining.Width / 2,
                        buttonTesting.Height + buttonTesting.Location.Y + 13);
                    buttonStatistics.Visible = true;
                    buttonStatistics.TabIndex = 2;
                    buttonStatistics.Click += buttonStatistics_Click;
                    Controls.Add(buttonStatistics);
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
            Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label();
            labelUser.Parent = this;
            labelUser.Text = _userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label();
            labelTitle.Parent = this;
            labelTitle.Text = @"Выбирите необходимую тему";
            labelTitle.Font = new Font("Microsoft Sans Serif", 21.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными темами
            ListBox listBoxThems = new ListBox();
            listBoxThems.Parent = this;
            listBoxThems.TabIndex = 0;
            listBoxThems.Size = new Size(ClientSize.Width - 26, ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13 * 3 - 23);
            listBoxThems.Visible = true;
            listBoxThems.Location = new Point(13, labelTitle.Height + labelTitle.Location.Y + 13);
            Controls.Add(listBoxThems);
            #endregion
            #region Добавляем кнопку "Выбрать"
            Button buttonSelect = new Button();
            buttonSelect.Parent = this;
            buttonSelect.Text = @"Выбрать";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.Location = new Point(ClientSize.Width - buttonSelect.Width - 13,
                listBoxThems.Height + listBoxThems.Location.Y + 13);
            buttonSelect.Visible = true;
            buttonSelect.TabIndex = 2;
            buttonSelect.Click += buttonSelect_Click;
            Controls.Add(buttonSelect);
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button();
            buttonBack.Parent = this;
            buttonBack.Text = @"Назад";
            buttonBack.Size = new Size(75, 23);
            buttonBack.Location = new Point(13, listBoxThems.Height + listBoxThems.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += buttonBack_Click;
            Controls.Add(buttonBack);
            #endregion
            #endregion
        }

        /// <summary>
        /// Метод для создания окна тестирования
        /// </summary>
        private void CreateTestingWindow()
        {
            #region Убираем элементы с формы
            Controls.Clear();
            #endregion
            SystemOfTrainingAndTesting.Select.SelectTests();
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label();
            labelUser.Parent = this;
            labelUser.Text = _userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label();
            labelTitle.Parent = this;
            labelTitle.Text = @"Выбирите необходимый тест";
            labelTitle.Font = new Font("Microsoft Sans Serif", 21.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            labelTitle.AutoSize = true;
            labelTitle.Visible = true;
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными тестами
            ListBox listBoxTests = new ListBox();
            listBoxTests.Parent = this;
            listBoxTests.TabIndex = 0;
            listBoxTests.Size = new Size(ClientSize.Width - 26, ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13 * 3 - 23);
            listBoxTests.Visible = true;
            listBoxTests.Location = new Point(13, labelTitle.Height + labelTitle.Location.Y + 13);
            listBoxTests.SelectionMode = SelectionMode.One;
            foreach (string item in TestsInfo.TitleAndDescription)
            {
                listBoxTests.Items.Add(item);
            }
            listBoxTests.SelectedIndexChanged += listBoxTests_SelectedIndexChanged;
            listBoxTests.SelectedIndex = 0;
            Controls.Add(listBoxTests);
            #endregion
            #region Добавляем кнопку "Выбрать"
            Button buttonSelect = new Button();
            buttonSelect.Parent = this;
            buttonSelect.Text = @"Выбрать";
            buttonSelect.Size = new Size(75, 23);
            buttonSelect.Location = new Point(ClientSize.Width - buttonSelect.Width - 13,
                listBoxTests.Height + listBoxTests.Location.Y + 13);
            buttonSelect.Visible = true;
            buttonSelect.TabIndex = 2;
            buttonSelect.Click += buttonSelect_Click;
            Controls.Add(buttonSelect);
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button();
            buttonBack.Parent = this;
            buttonBack.Text = @"Назад";
            buttonBack.Size = new Size(75, 23);
            buttonBack.Location = new Point(13, listBoxTests.Height + listBoxTests.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += buttonBack_Click;
            Controls.Add(buttonBack);
            #endregion
            #endregion
        }

        /// <summary>
        /// Метод для создания окна статистики
        /// </summary>
        private void CreateStatisticsWindow()
        {
            #region Убираем элементы с формы
            Controls.Clear();
            #endregion
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label();
            labelUser.Parent = this;
            labelUser.Text = _userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавление вкладок
            TabControl tabControl = new TabControl();
            tabControl.Parent = this;
            tabControl.Location = new Point(0, labelUser.Height);
            tabControl.TabIndex = 0;
            tabControl.Size = new Size(ClientSize.Width, ClientSize.Height - labelUser.Height - 23 - 13 * 2);
            tabControl.Visible = true;
            Controls.Add(tabControl);
            TabPage tabPageTraining = new TabPage();
            tabPageTraining.Location = new Point(4, 22);
            tabPageTraining.Padding = new Padding(3);
            tabPageTraining.Size = new Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26);
            tabPageTraining.TabIndex = 0;
            tabPageTraining.Text = @"Обучение";
            tabControl.Controls.Add(tabPageTraining);
            TabPage tabPageTesting = new TabPage();
            tabPageTesting.Location = new Point(4, 22);
            tabPageTesting.Padding = new Padding(3);
            tabPageTesting.Size = new Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26);
            tabPageTesting.TabIndex = 1;
            tabPageTesting.Text = @"Тестирование";
            tabControl.Controls.Add(tabPageTesting);
            #endregion
            #region Добавляем listBox с доступными тестами
            ListBox listBoxTests = new ListBox();
            //listBoxTests.Parent = this;
            listBoxTests.TabIndex = 0;
            listBoxTests.Size = new Size(tabPageTesting.Size.Width - 26, tabPageTesting.Size.Height - 13 * 2);
            listBoxTests.Visible = true;
            listBoxTests.Location = new Point(13, 13);
            tabPageTesting.Controls.Add(listBoxTests);
            #endregion
            #region Добавляем listBox с доступными темами
            ListBox listBoxThems = new ListBox();
            //listBoxTests.Parent = this;
            listBoxThems.TabIndex = 0;
            listBoxThems.Size = new Size(tabPageTesting.Size.Width - 26, tabPageTesting.Size.Height - 13 * 2);
            listBoxThems.Visible = true;
            listBoxThems.Location = new Point(13, 13);
            tabPageTraining.Controls.Add(listBoxThems);
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button();
            buttonBack.Parent = this;
            buttonBack.Text = @"Назад";
            buttonBack.Size = new Size(75, 23);
            buttonBack.Location = new Point(ClientSize.Width / 2 - buttonBack.Width / 2, tabControl.Height + tabControl.Location.Y + 13);
            buttonBack.Visible = true;
            buttonBack.TabIndex = 1;
            buttonBack.Click += buttonBack_Click;
            Controls.Add(buttonBack);
            #endregion
            #endregion
        }

        /// <summary>
        /// Метод для создания окна вопроса
        /// </summary>
        private void CreateQuestionWindow()
        {
            #region Убираем элементы с формы
            Controls.Clear();
            #endregion
            _selectedAnswerString = null;
            SystemOfTrainingAndTesting.Select.SelectAnswers(QuestionsInfo.Id[_questionNumber]);
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label();
            labelUser.Parent = this;
            labelUser.Text = _userString;
            labelUser.AutoSize = true;
            labelUser.Visible = true;
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения вопроса
            Label labelQuestion = new Label();
            labelQuestion.Parent = this;
            labelQuestion.Text = QuestionsInfo.Question[_questionNumber];
            int position = 0;
            while (position < labelQuestion.Text.Length - 30)
            {
                position = labelQuestion.Text.IndexOf(" ", position + 30, StringComparison.Ordinal);
                if (position > 0)
                {
                    labelQuestion.Text = labelQuestion.Text.Insert(position, "\r\n");
                }
                else
                {
                    position = labelQuestion.Text.Length;
                }
            }
            labelQuestion.TextAlign = ContentAlignment.TopCenter;
            labelQuestion.Font = new Font("Microsoft Sans Serif", 21.75F,
                FontStyle.Regular, GraphicsUnit.Point, 204);
            labelQuestion.AutoSize = true;
            labelQuestion.Visible = true;
            labelQuestion.Location = new Point(ClientSize.Width / 2 - labelQuestion.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelQuestion);
            #endregion
            #region Добавляем ответы
            Point answerLocation = new Point();
            switch (QuestionsInfo.TypeAnswer[_questionNumber])
            {
                #region Выбор одного варианта ответа
                case 0:
                    for (int i = 0; i < AnswersInfo.Answer.Count; i++)
                    {
                        RadioButton radioButtonAnswer = new RadioButton();
                        radioButtonAnswer.Parent = this;
                        radioButtonAnswer.Text = AnswersInfo.Answer[i];
                        radioButtonAnswer.Visible = true;
                        radioButtonAnswer.AutoSize = true;
                        radioButtonAnswer.Location = new Point(13, labelQuestion.Height + labelQuestion.Location.Y + 13 + i * 3 * 13);
                        answerLocation = radioButtonAnswer.Location;
                        radioButtonAnswer.CheckedChanged += radioButtonAnswer_CheckedChanged;
                        if (_answerString.Contains(radioButtonAnswer.Text))
                        {
                            radioButtonAnswer.Checked = true;
                        }
                        Controls.Add(radioButtonAnswer);
                    }
                    break;
                #endregion
            }
            #endregion
            #region Добавляем кнопку "Следующий"
            Button buttonNext = new Button();
            buttonNext.Parent = this;
            buttonNext.Text = _questionNumber == QuestionsInfo.Id.Count - 1 ? "Завершить" : "Следующий";
            buttonNext.Size = new Size(85, 23);
            buttonNext.Location = new Point(ClientSize.Width - buttonNext.Width - 13,
                answerLocation.Y + 13 * 3);
            buttonNext.Visible = true;
            buttonNext.TabIndex = AnswersInfo.Answer.Count + 2;
            buttonNext.Click += buttonNext_Click;
            Controls.Add(buttonNext);
            #endregion
            #region Добавить кнопку "Предыдущий"
            Button buttonPrevious = new Button();
            buttonPrevious.Parent = this;
            buttonPrevious.Text = @"Предыдущий";
            buttonPrevious.Size = new Size(85, 23);
            buttonPrevious.Location = new Point(13, answerLocation.Y + 13 * 3);
            buttonPrevious.Visible = true;
            buttonPrevious.Enabled = _questionNumber != 0;
            buttonPrevious.TabIndex = AnswersInfo.Answer.Count + 1;
            buttonPrevious.Click += buttonPrevious_Click;
            Controls.Add(buttonPrevious);
            #endregion
            #endregion
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            if (Authorization.Auth(textBoxLogin.Text, textBoxPassword.Text, out _userString))
            {
                #region Изменяем размеры и параметры формы
                ClientSize = new Size(640, 480);
                MaximizeBox = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                MinimumSize = new Size(640, 480);
                #endregion
                CreateMainWindow();
            }
            else
            {
                MessageBox.Show(_userString, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show(@"Click to control button", @"Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int index = TestsInfo.TitleAndDescription.IndexOf(_selectedTestString);
            SystemOfTrainingAndTesting.Select.SelectQuestions(TestsInfo.Id[index]);
            #region Сброс в начальное значение счетчика и очистка списков
            _questionNumber = 0;
            _correctAnswers.Clear();
            _answerString.Clear();
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
            if (_selectedAnswerString != null)
            {
                _answerString.Add(_selectedAnswerString);
                int index = AnswersInfo.Answer.IndexOf(_selectedAnswerString);
                if (AnswersInfo.CorrectAnswer[index])
                {
                    if (!_correctAnswers.Contains(QuestionsInfo.Id[_questionNumber]))
                    {
                        _correctAnswers.Add(QuestionsInfo.Id[_questionNumber]);
                    }
                }
                else
                {
                    if (_correctAnswers.Contains(QuestionsInfo.Id[_questionNumber]))
                    {
                        _correctAnswers.Remove(QuestionsInfo.Id[_questionNumber]);
                    }
                }
            }
            #endregion
            _questionNumber++;
            #region Выбор действия в зависимости от типа кнопки
            if (_questionNumber == QuestionsInfo.Id.Count)
            {
                MessageBox.Show(_correctAnswers.Count.ToString());
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
            if (_selectedAnswerString != null)
            {
                _answerString.Add(_selectedAnswerString);
            }
            #endregion
            _questionNumber--;
            CreateQuestionWindow();
        }

        private void listBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            if (listBox == null)
            {
                return;
            }
            _selectedTestString = listBox.SelectedItem.ToString();
        }

        private void radioButtonAnswer_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null)
            {
                return;
            }
            if (radioButton.Checked)
            {
                _selectedAnswerString = radioButton.Text;
            }

        }
    }
}
