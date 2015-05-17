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
        private string userString;
        private int userAccess;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            if (Authorization.Auth(this.textBoxLogin.Text, this.textBoxPassword.Text, out userString, out userAccess))
            {
                #region Убираем элементы с формы
                this.Controls.Clear();
                #endregion
                #region Изменяем размеры и параметры формы
                this.ClientSize = new System.Drawing.Size(640, 480);
                this.MaximizeBox = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.MinimumSize = new System.Drawing.Size(640, 480);
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
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
                labelTitle.AutoSize = true;
                labelTitle.Visible = true;
                labelTitle.Location = new System.Drawing.Point(this.ClientSize.Width/2 - labelTitle.Width/2,
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
                switch (userAccess)
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
                        throw new Exception("Неверный уровень прав пользователя",null);
                }
                #endregion
                #endregion
            }
            else
            {
                MessageBox.Show(userString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonTraining_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to training button","Click message",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonTesting_Click(object sender, EventArgs e)
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
            this.Controls.Add(listBoxTests);
            #endregion
            #region Добавляем кнопку "Начать"
            System.Windows.Forms.Button buttonSelect = new System.Windows.Forms.Button();
            buttonSelect.Parent = this;
            buttonSelect.Text = "Выбрать";
            buttonSelect.Size = new System.Drawing.Size(75, 23);
            buttonSelect.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - buttonSelect.Width / 2,
                listBoxTests.Height + listBoxTests.Location.Y + 13);
            buttonSelect.Visible = true;
            buttonSelect.TabIndex = 1;
            buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            this.Controls.Add(buttonSelect);
            #endregion
            #endregion

            //MessageBox.Show("Click to testing button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to statistics button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to control button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click to select button", "Click message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
