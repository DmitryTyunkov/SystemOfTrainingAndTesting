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
        private readonly List<string> _selectedAnswerString = new List<string>();

        /// <summary>
        /// Список верных ответов
        /// </summary>
        private readonly List<int> _correctAnswers = new List<int>();

        /// <summary>
        /// Список ответов
        /// </summary>
        private readonly List<int> _answerId = new List<int>();

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
            Label labelUser = new Label
            {
                Parent = this, 
                Text = _userString, 
                AutoSize = true, 
                Visible = true
            };
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label
            {
                Parent = this,
                Text = @"Выбирите необходимый режим",
                Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = true,
                Visible = true
            };
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем кнопку "Обучение"
            Button buttonTraining = new Button
            {
                Parent = this,
                Text = @"Обучение",
                Size = new Size(75*3, 23*3),
                Visible = true,
                TabIndex = 0
            };
            buttonTraining.Location = new Point(ClientSize.Width / 2 - buttonTraining.Width / 2,
                labelTitle.Height + labelTitle.Location.Y + 13);
            Controls.Add(buttonTraining);
            buttonTraining.Click += buttonTraining_Click;
            #endregion
            #region Добавляем кнопку "Тестирование"
            Button buttonTesting = new Button
            {
                Parent = this, 
                Text = @"Тестирование", 
                Size = new Size(75*3, 23*3),
                Visible = true,
                TabIndex = 1
            };
            buttonTesting.Location = new Point(ClientSize.Width / 2 - buttonTesting.Width / 2,
                buttonTraining.Height + buttonTraining.Location.Y + 13);
            Controls.Add(buttonTesting);
            buttonTesting.Click += buttonTesting_Click;
            #endregion
            #region Добавление кнопки в зависимости от привелегий пользователя
            switch (Info.User.Level)
            {
                case 0:
                    #region Добавляем кнопку "Управление"
                    Button buttonControl = new Button
                    {
                        Parent = this,
                        Text = @"Управление",
                        Size = new Size(75*3, 23*3),
                        Location = new Point(ClientSize.Width/2 - buttonTraining.Width/2,
                            buttonTesting.Height + buttonTesting.Location.Y + 13),
                        Visible = true,
                        TabIndex = 2
                    };
                    Controls.Add(buttonControl);
                    buttonControl.Click += buttonControl_Click;
                    #endregion
                    break;
                case 1:
                    #region Добавляем кнопку "Статистика"
                    Button buttonStatistics = new Button
                    {
                        Parent = this,
                        Text = @"Статистика",
                        Size = new Size(75*3, 23*3),
                        Location = new Point(ClientSize.Width/2 - buttonTraining.Width/2,
                            buttonTesting.Height + buttonTesting.Location.Y + 13),
                        Visible = true,
                        TabIndex = 2
                    };
                    Controls.Add(buttonStatistics);
                    buttonStatistics.Click += buttonStatistics_Click;
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
            Label labelUser = new Label
            {
                Parent = this, 
                Text = _userString, 
                AutoSize = true, 
                Visible = true
            };
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label
            {
                Parent = this,
                Text = @"Выбирите необходимую тему",
                Font = new Font("Microsoft Sans Serif", 21.75F,
                    FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = true,
                Visible = true
            };
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными темами
            ListBox listBoxThems = new ListBox
            {
                Parent = this,
                TabIndex = 0,
                Size = new Size(ClientSize.Width - 26, 
                    ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13 * 3 - 23),
                Visible = true,
                Location = new Point(13, labelTitle.Height + labelTitle.Location.Y + 13)
            };
            Controls.Add(listBoxThems);
            #endregion
            #region Добавляем кнопку "Выбрать"
            Button buttonSelect = new Button
            {
                Parent = this, 
                Text = @"Выбрать", 
                Size = new Size(75, 23),
                Visible = true,
                TabIndex = 2
            };
            buttonSelect.Location = new Point(ClientSize.Width - buttonSelect.Width - 13,
                listBoxThems.Height + listBoxThems.Location.Y + 13);
            Controls.Add(buttonSelect);
            buttonSelect.Click += buttonSelect_Click;
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button
            {
                Parent = this,
                Text = @"Назад",
                Size = new Size(75, 23),
                Location = new Point(13, listBoxThems.Height + listBoxThems.Location.Y + 13),
                Visible = true,
                TabIndex = 1
            };
            Controls.Add(buttonBack);
            buttonBack.Click += buttonBack_Click;
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
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label
            {
                Parent = this, 
                Text = _userString,
                AutoSize = true,
                Visible = true
            };
            labelUser.Location = new Point(ClientSize.Width - labelUser.Width - 13, 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения заголовка
            Label labelTitle = new Label
            {
                Parent = this,
                Text = @"Выбирите необходимый тест",
                Font = new Font("Microsoft Sans Serif", 21.75F,
                    FontStyle.Regular, GraphicsUnit.Point, 204),
                AutoSize = true,
                Visible = true
            };
            labelTitle.Location = new Point(ClientSize.Width / 2 - labelTitle.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelTitle);
            #endregion
            #region Добавляем listBox с доступными тестами
            ListBox listBoxTests = new ListBox
            {
                Parent = this,
                TabIndex = 0,
                Size = new Size(ClientSize.Width - 26,
                    ClientSize.Height - labelTitle.Location.Y - labelTitle.Height - 13*3 - 23),
                Visible = true,
                Location = new Point(13, labelTitle.Height + labelTitle.Location.Y + 13),
                SelectionMode = SelectionMode.One
            };
            foreach (string item in Info.Tests.TitleAndDescription)
            {
                listBoxTests.Items.Add(item);
            }
            Controls.Add(listBoxTests);
            listBoxTests.SelectedIndexChanged += listBoxTests_SelectedIndexChanged;
            listBoxTests.SelectedIndex = 0;
            #endregion
            #region Добавляем кнопку "Выбрать"
            Button buttonSelect = new Button 
            {
                Parent = this,
                Text = @"Выбрать", 
                Size = new Size(75, 23),
                Visible = true,
                TabIndex = 2
            };
            buttonSelect.Location = new Point(ClientSize.Width - buttonSelect.Width - 13,
                listBoxTests.Height + listBoxTests.Location.Y + 13);
            Controls.Add(buttonSelect);
            buttonSelect.Click += buttonSelect_Click;
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button
            {
                Parent = this,
                Text = @"Назад",
                Size = new Size(75, 23),
                Location = new Point(13, listBoxTests.Height + listBoxTests.Location.Y + 13),
                Visible = true,
                TabIndex = 1
            };
            Controls.Add(buttonBack);
            buttonBack.Click += buttonBack_Click;
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
            Label labelUser = new Label
            {
                Parent = this, 
                Text = _userString, 
                AutoSize = true, 
                Visible = true
            };
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавление вкладок
            TabControl tabControl = new TabControl
            {
                Parent = this,
                Location = new Point(0, labelUser.Height),
                TabIndex = 0,
                Size = new Size(ClientSize.Width, ClientSize.Height - labelUser.Height - 23 - 13*2),
                Visible = true
            };
            Controls.Add(tabControl);
            TabPage tabPageTraining = new TabPage
            {
                Location = new Point(4, 22),
                Padding = new Padding(3),
                Size = new Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26),
                TabIndex = 0,
                Text = @"Обучение"
            };
            tabControl.Controls.Add(tabPageTraining);
            TabPage tabPageTesting = new TabPage
            {
                Location = new Point(4, 22),
                Padding = new Padding(3),
                Size = new Size(tabControl.Size.Width - 8, tabControl.Size.Width - 26),
                TabIndex = 1,
                Text = @"Тестирование"
            };
            tabControl.Controls.Add(tabPageTesting);
            #endregion
            #region Добавляем таблицу с доступными тестами
            DataGridView dataGridViewTests = new DataGridView
            {
                Location = new Point(13, 13),
                Size = new Size(tabPageTesting.Size.Width - 26,
                    tabPageTesting.Size.Height - 13*2),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells,
                Visible = true,
                ReadOnly = true
            };
            dataGridViewTests.Columns.Add("tests", "Тесты");
            dataGridViewTests.Columns.Add("number_of_correct_answers", "Количество верных ответов");
            dataGridViewTests.Columns.Add("number_of_question", "Количество вопросов");
            dataGridViewTests.Columns.Add("percent", "Процент");
            foreach (int idTest in Info.Tests.Id)
            {
                int index = Info.Tests.Id.IndexOf(idTest);
                int numberOfQuestion = Info.Tests.NumberOfQuestion[index];
                string[] row = new string[4];
                row[0] = Info.Tests.Title[index];
                index = Info.Statistics.IdTest.IndexOf(idTest);
                if (index == -1)
                {
                    row[1] = "не пройдено";
                    row[2] = numberOfQuestion.ToString();
                }
                else
                {
                    int numberOfCorrectAnswer = Info.Statistics.NumberOfCorrectAnswer[index];
                    double percent = Convert.ToDouble(numberOfCorrectAnswer)/numberOfQuestion;
                    row[1] = numberOfCorrectAnswer.ToString();
                    row[2] = numberOfQuestion.ToString();
                    row[3] = percent.ToString("P");
                }
                dataGridViewTests.Rows.Add(row);
            }
            tabPageTesting.Controls.Add(dataGridViewTests);
            #endregion
            #region Добавляем listBox с доступными темами
            ListBox listBoxThems = new ListBox
            {
                Size = new Size(tabPageTesting.Size.Width - 26,
                    tabPageTesting.Size.Height - 13*2),
                Location = new Point(13, 13),
                Visible = true,
                TabIndex = 0
            };
            tabPageTraining.Controls.Add(listBoxThems);
            #endregion
            #region Добавить кнопку "Назад"
            Button buttonBack = new Button
            {
                Parent = this,
                Text = @"Назад",
                Size = new Size(75, 23),
                Visible = true,
                TabIndex = 1
            };
            buttonBack.Location = new Point(ClientSize.Width / 2 - buttonBack.Width / 2,
                tabControl.Height + tabControl.Location.Y + 13);
            Controls.Add(buttonBack);
            buttonBack.Click += buttonBack_Click;
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
            _selectedAnswerString.Clear();
            SystemOfTrainingAndTesting.Select.SelectAnswers(Info.Questions.Id[_questionNumber]);
            #region Размещаем нужные элементы на форме
            #region Добавляем label для отображения информации о пользователе
            Label labelUser = new Label
            {
                Parent = this, 
                Text = _userString,
                AutoSize = true, 
                Visible = true
            };
            labelUser.Location = new Point(ClientSize.Width - (labelUser.Width + 13), 13);
            Controls.Add(labelUser);
            #endregion
            #region Добавляем label для отображения вопроса
            Label labelQuestion = new Label
            {
                Parent = this,
                Text = Info.Questions.Question[_questionNumber],
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Microsoft Sans Serif", 21.75F,
                    FontStyle.Regular, GraphicsUnit.Point, 204),
                Visible = true
            };
            #region Разбиение вопроса на несколько строк
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
            #endregion
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(ClientSize.Width / 2 - labelQuestion.Width / 2,
                labelUser.Height + labelUser.Location.Y + 13);
            Controls.Add(labelQuestion);
            #endregion
            #region Добавляем ответы
            Point answerLocation = new Point();
            switch (Info.Questions.TypeAnswer[_questionNumber])
            {
                #region Выбор одного варианта ответа
                case 0:
                    for (int i = 0; i < Info.Answers.Answer.Count; i++)
                    {
                        RadioButton radioButtonAnswer = new RadioButton
                        {
                            Parent = this,
                            Text = Info.Answers.Answer[i],
                            Visible = true,
                            AutoSize = true,
                            Location = new Point(13, labelQuestion.Height + labelQuestion.Location.Y + 13 + i*3*13)
                        };
                        Controls.Add(radioButtonAnswer);
                        answerLocation = radioButtonAnswer.Location;
                        radioButtonAnswer.CheckedChanged += radioButtonAnswer_CheckedChanged;
                        if (_answerId.Contains(Info.Answers.Id[i]))
                        {
                            radioButtonAnswer.Checked = true;
                        }
                    }
                    break;
                #endregion
                #region Выбор нескольких вариантов ответа
                case 1:
                    for (int i = 0; i < Info.Answers.Answer.Count; i++)
                    {
                        CheckBox checkBoxAnswer = new CheckBox
                        {
                            Parent = this,
                            Text = Info.Answers.Answer[i],
                            Visible = true,
                            AutoSize = true,
                            Location = new Point(13, labelQuestion.Height + labelQuestion.Location.Y + 13 + i*3*13),
                            TabIndex = i
                        };
                        Controls.Add(checkBoxAnswer);
                        answerLocation = checkBoxAnswer.Location;
                        checkBoxAnswer.CheckStateChanged += checkBoxAnswer_CheckStateChanged;
                        if (_answerId.Contains(Info.Answers.Id[i]))
                        {
                            checkBoxAnswer.CheckState = CheckState.Checked;
                        }
                    }
                    break;
                #endregion
            }
            #endregion
            #region Добавляем кнопку "Следующий"
            Button buttonNext = new Button
            {
                Parent = this,
                Text = _questionNumber == Info.Questions.Id.Count - 1 ? "Завершить" : "Следующий",
                Size = new Size(85, 23),
                Visible = true,
                TabIndex = Info.Answers.Answer.Count + 2
            };
            buttonNext.Location = new Point(ClientSize.Width - buttonNext.Width - 13,
                answerLocation.Y + 13 * 3);
            Controls.Add(buttonNext);
            buttonNext.Click += buttonNext_Click;
            #endregion
            #region Добавить кнопку "Предыдущий"
            Button buttonPrevious = new Button
            {
                Parent = this,
                Text = @"Предыдущий",
                Size = new Size(85, 23),
                Location = new Point(13, answerLocation.Y + 13*3),
                Visible = true,
                Enabled = _questionNumber != 0,
                TabIndex = Info.Answers.Answer.Count + 1,
            };
            Controls.Add(buttonPrevious);
            buttonPrevious.Click += buttonPrevious_Click;
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
        }

        private void buttonTesting_Click(object sender, EventArgs e)
        {
            SystemOfTrainingAndTesting.Select.SelectTests();
            CreateTestingWindow();
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            SystemOfTrainingAndTesting.Select.SelectTests();
            SystemOfTrainingAndTesting.Select.SelectStatistics();
            CreateStatisticsWindow();
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Click to control button", @"Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            int index = Info.Tests.TitleAndDescription.IndexOf(_selectedTestString);
            SystemOfTrainingAndTesting.Select.SelectQuestions(Info.Tests.Id[index]);
            #region Сброс в начальное значение счетчика и очистка списков
            _questionNumber = 0;
            _correctAnswers.Clear();
            _answerId.Clear();
            #endregion
            CreateQuestionWindow();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CreateMainWindow();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int i = 0; //Счетчик количества данных верных ответов на вопрос
            List<bool> answer = Info.Answers.CorrectAnswer.FindAll(p => p); //Для определения количества верных ответов на вопрос
            #region Удаляем все сохраненные ответы на текущий вопрос
            foreach (int id in Info.Answers.Id)
            {
                if (_answerId.Contains(id))
                {
                    _answerId.Remove(id);
                }
            }
            #endregion
            #region Добавление очередного ответа в список и проверка на правильность
            foreach (string selectedAnswerString in _selectedAnswerString)
            {
                int index = Info.Answers.Answer.IndexOf(selectedAnswerString);
                _answerId.Add(Info.Answers.Id[index]);
                if (Info.Answers.CorrectAnswer[index])
                {
                    if (!_correctAnswers.Contains(Info.Questions.Id[_questionNumber]))
                    {
                        i++;
                        if (i == answer.Count)
                        {
                            _correctAnswers.Add(Info.Questions.Id[_questionNumber]);
                        }
                    }
                }
                else
                {
                    if (_correctAnswers.Contains(Info.Questions.Id[_questionNumber]))
                    {
                        _correctAnswers.Remove(Info.Questions.Id[_questionNumber]);
                    }
                    break;
                }
            }
            #endregion
            _questionNumber++;
            #region Выбор действия в зависимости от типа кнопки
            if (_questionNumber == Info.Questions.Id.Count)
            {
                MessageBox.Show(@"Верных ответов: "+_correctAnswers.Count,@"Результат",MessageBoxButtons.OK,MessageBoxIcon.Information);
                int index = Info.Tests.TitleAndDescription.IndexOf(_selectedTestString);
                Insert.InsertStatistic(Info.Tests.Id[index], _correctAnswers.Count);
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
            #region Удаляем все сохраненные ответы на текущий вопрос
            foreach (int id in Info.Answers.Id)
            {
                if (_answerId.Contains(id))
                {
                    _answerId.Remove(id);
                }
            }
            #endregion
            #region Добавление очередного ответа в список
            foreach (string selectedAnswerString in _selectedAnswerString)
            {
                int index = Info.Answers.Answer.IndexOf(selectedAnswerString);
                _answerId.Add(Info.Answers.Id[index]);
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
                _selectedAnswerString.Add(radioButton.Text);
            }
            if (!radioButton.Checked && _selectedAnswerString.Contains(radioButton.Text))
            {
                _selectedAnswerString.Remove(radioButton.Text);
            }
        }

        private void checkBoxAnswer_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }
            if (checkBox.CheckState == CheckState.Checked)
            {
                _selectedAnswerString.Add(checkBox.Text);
            }
            if (checkBox.CheckState == CheckState.Unchecked && _selectedAnswerString.Contains(checkBox.Text))
            {
                _selectedAnswerString.Remove(checkBox.Text);
            }
        }
    }
}
